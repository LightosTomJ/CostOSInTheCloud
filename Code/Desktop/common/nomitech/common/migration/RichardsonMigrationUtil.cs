using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Numerics;

namespace Desktop.common.nomitech.common.migration
{
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using AssemblyConsumableTable = nomitech.common.db.local.AssemblyConsumableTable;
	using AssemblyEquipmentTable = nomitech.common.db.local.AssemblyEquipmentTable;
	using AssemblyLaborTable = nomitech.common.db.local.AssemblyLaborTable;
	using AssemblyMaterialTable = nomitech.common.db.local.AssemblyMaterialTable;
	using AssemblySubcontractorTable = nomitech.common.db.local.AssemblySubcontractorTable;
	using AssemblyTable = nomitech.common.db.local.AssemblyTable;
	using ConsumableTable = nomitech.common.db.local.ConsumableTable;
	using EquipmentTable = nomitech.common.db.local.EquipmentTable;
	using ExtraCode2Table = nomitech.common.db.local.ExtraCode2Table;
	using LaborTable = nomitech.common.db.local.LaborTable;
	using MaterialTable = nomitech.common.db.local.MaterialTable;
	using ParamItemInputTable = nomitech.common.db.local.ParamItemInputTable;
	using ParamItemOutputTable = nomitech.common.db.local.ParamItemOutputTable;
	using ParamItemTable = nomitech.common.db.local.ParamItemTable;
	using SubcontractorTable = nomitech.common.db.local.SubcontractorTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using BlankResourceInitializer = nomitech.common.expr.boqitem.BlankResourceInitializer;
	using CitiesToLocalizationLoader = Desktop.common.nomitech.common.migration.richardson.CitiesToLocalizationLoader;
	using RichardsonCrew = Desktop.common.nomitech.common.migration.richardson.RichardsonCrew;
	using RichardsonLineItem = Desktop.common.nomitech.common.migration.richardson.RichardsonLineItem;
	using RichardsonRapidDetail = Desktop.common.nomitech.common.migration.richardson.RichardsonRapidDetail;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using Query = org.hibernate.Query;
	using Session = org.hibernate.Session;
	using Transaction = org.hibernate.Transaction;

	public class RichardsonMigrationUtil
	{
	  private const bool ONLINE_REFERENCE = true;

	  private string LOCATION_PROFILE_ID = "O1";

	  private string DEFAULT_LOCATION_FACTOR = "US;;ALABAMA;;MOBILE;;36601";

	  private const double HOURS_OF_DAY = 8.0D;

	  private const double HOURS_OF_WEEK = 40.0D;

	  private const double HOURS_OF_MONTH = 160.0D;

	  private int NON_MULTI_GROUP_MAX_COUNT = 10000;

	  private bool MULTI_GROUP_LABORS = false;

	  private string PDF_PREFIX = "http://www.costdataonline.com/PDF.ASPx?acct=";

	  private string o_databaseURL;

	  private string o_username;

	  private string o_password;

	  private IDictionary<string, string> gcCache = new Hashtable();

	  private IDictionary<string, LaborTable> laborCraftCache = new Hashtable();

	  private IDictionary<string, LaborTable> laborTableCache = new Hashtable();

	  private IDictionary<string, IList<RichardsonCrew>> crewCache = new Hashtable();

	  private IDictionary<string, string> pdfLinkCache = new Hashtable();

	  private IDictionary<string, RichardsonLineItem> lineItemCache = new Hashtable();

	  private IDictionary<string, IList<RichardsonRapidDetail>> rapidDetailCache = new Hashtable();

	  private DateTime lastUpdate = DateTime.Now;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private RichardsonMigrationUtil(String paramString1, String paramString2, String paramString3, java.io.PrintWriter paramPrintWriter) throws Exception
	  private RichardsonMigrationUtil(string paramString1, string paramString2, string paramString3, PrintWriter paramPrintWriter)
	  {
		this.o_databaseURL = paramString1;
		this.o_username = paramString2;
		this.o_password = paramString3;
		Type.GetType("org.mariadb.jdbc.Driver");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void startMigration() throws Exception
	  private void startMigration()
	  {
		Connection connection = DriverManager.getConnection(this.o_databaseURL, this.o_username, this.o_password);
		Console.WriteLine("INFO: Saving Location Factors");
		loadFactors(connection);
		Session session = DatabaseDBUtil.currentSession();
		Transaction transaction = session.beginTransaction();
		try
		{
		  Console.WriteLine("INFO: Saving Group Codes...");
		  loadDetailedIndexAsGroupCode(connection, session);
		  transaction.commit();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  transaction.rollback();
		  connection.close();
		  DatabaseDBUtil.closeSession();
		  throw exception;
		}
		Console.WriteLine("INFO: Caching Crews...");
		cacheCrewTable(connection);
		Console.WriteLine("INFO: Caching Rapid Details...");
		cacheRapidsDetails(connection, session);
		Console.WriteLine("INFO: Saving Averaged Crafts As Labors...");
		loadCrewsAsLabors(connection, session);
		Console.WriteLine("INFO: Saving Resources...");
		loadLineItemsAsResources(connection, session);
		Console.WriteLine("INFO: Saving Rapids...");
		session = DatabaseDBUtil.currentSession();
		loadRapidsAsParamItems(connection, session);
		if (!connection.Closed)
		{
		  connection.close();
		}
		DatabaseDBUtil.closeSession();
		mergeAssemblies();
		Console.WriteLine("\n\n\nPDF LINKS TO SAVE: ");
		Console.WriteLine("-------------------------\n");
		System.Collections.IEnumerator iterator = this.pdfLinkCache.Keys.GetEnumerator();
		while (iterator.MoveNext())
		{
		  Console.WriteLine((string)iterator.Current);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadFactors(java.sql.Connection paramConnection) throws Exception
	  private void loadFactors(Connection paramConnection)
	  {
		  CitiesToLocalizationLoader.loadFactors(paramConnection);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadCrewsAsLabors(java.sql.Connection paramConnection, org.hibernate.Session paramSession) throws Exception
	  private void loadCrewsAsLabors(Connection paramConnection, Session paramSession)
	  {
		string str = "select * from CRAFT_Description ORDER BY ID";
		PreparedStatement preparedStatement = paramConnection.prepareStatement(str);
		ResultSet resultSet = preparedStatement.executeQuery();
		Transaction transaction = paramSession.beginTransaction();
		while (resultSet.next())
		{
		  string str1 = resultSet.getString(2);
		  string str2 = resultSet.getString(3);
		  LaborTable laborTable = BlankResourceInitializer.createBlankLabor(null);
		  laborTable.ItemCode = str2;
		  laborTable.Title = str1;
		  laborTable.StateProvince = "USA AVERAGE";
		  laborTable.Unit = "HOUR";
		  laborTable.Currency = "USD";
		  laborTable.GroupCode = "";
		  laborTable.GekCode = "";
		  laborTable.Project = "";
		  laborTable.EditorId = "richardson";
		  laborTable.ContactPerson = "";
		  laborTable.PhoneNumber = "";
		  laborTable.MobileNumber = "";
		  laborTable.FaxNumber = "";
		  laborTable.Email = "";
		  laborTable.Address = "";
		  laborTable.City = "";
		  laborTable.Country = "US";
		  laborTable.Notes = "CRAFTID: " + str2;
		  laborTable.Description = "";
		  laborTable.ExtraCode1 = "";
		  laborTable.ExtraCode2 = "";
		  laborTable.ExtraCode3 = "";
		  laborTable.ExtraCode4 = "";
		  laborTable.ExtraCode5 = "";
		  laborTable.ExtraCode6 = "";
		  laborTable.ExtraCode7 = "";
		  laborTable.ExtraCode8 = "";
		  laborTable.ExtraCode9 = "";
		  laborTable.ExtraCode10 = "";
		  str = "select Last_update,Base,Fringes from CRAFT WHERE Craft_id = '" + str2 + "' AND City_Id='0RICH0'";
		  PreparedStatement preparedStatement1 = paramConnection.prepareStatement(str);
		  ResultSet resultSet1 = preparedStatement1.executeQuery();
		  if (!resultSet1.next())
		  {
			Console.WriteLine("WARN: COULD NOT FIND CRAFT AVERAGE RATES FOR: " + str2);
			preparedStatement1.close();
			continue;
		  }
		  string str3 = resultSet1.getString(1);
		  laborTable.LastUpdate = this.lastUpdate;
		  laborTable.CreateDate = this.lastUpdate;
		  laborTable.CreateUserId = "RichardsonDBReader";
		  laborTable.Rate = new BigDecimalFixed(resultSet1.getDouble(2));
		  laborTable.IKA = new BigDecimalFixed(resultSet1.getDouble(3));
		  laborTable.recalculate();
		  preparedStatement1.close();
		  this.laborCraftCache[str2] = (LaborTable)laborTable.clone();
		}
		transaction.commit();
		preparedStatement.close();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void cacheCrewTable(java.sql.Connection paramConnection) throws Exception
	  private void cacheCrewTable(Connection paramConnection)
	  {
		string str = "select * from crew o order by o.id asc";
		PreparedStatement preparedStatement = paramConnection.prepareStatement(str);
		ResultSet resultSet = preparedStatement.executeQuery();
		while (resultSet.next())
		{
		  string str1 = resultSet.getString(2);
		  double d = resultSet.getDouble(3);
		  string str2 = resultSet.getString(4);
		  RichardsonCrew richardsonCrew = new RichardsonCrew(str2, d, str2);
		  System.Collections.IList list = (System.Collections.IList)this.crewCache[str1];
		  if (list == null)
		  {
			list = new List<object>(2);
			this.crewCache[str1] = list;
		  }
		  list.Add(richardsonCrew);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void cacheRapidsDetails(java.sql.Connection paramConnection, org.hibernate.Session paramSession) throws Exception
	  private void cacheRapidsDetails(Connection paramConnection, Session paramSession)
	  {
		string str = "select * from rapiddetail o order by o.RapidId asc ";
		PreparedStatement preparedStatement = paramConnection.prepareStatement(str);
		ResultSet resultSet = preparedStatement.executeQuery();
		bool @bool = false;
		Transaction transaction = paramSession.beginTransaction();
		while (resultSet.next())
		{
		  string str1 = resultSet.getString(2);
		  string str2 = resultSet.getString(3);
		  double d = resultSet.getDouble(4);
		  System.Collections.IList list = (System.Collections.IList)this.rapidDetailCache[str1];
		  if (list == null)
		  {
			list = new List<object>();
			this.rapidDetailCache[str1] = list;
		  }
		  list.Add(new RichardsonRapidDetail(str2, d));
		  if (this.lineItemCache[str2] == null)
		  {
			this.lineItemCache[str2] = new RichardsonLineItem();
		  }
		}
		transaction.commit();
		preparedStatement.close();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void mergeAssemblies() throws Exception
	  private void mergeAssemblies()
	  {
		Session session = DatabaseDBUtil.currentSession();
		session.beginTransaction();
		try
		{
		  System.Collections.IList list = session.createQuery("select distinct (o.extraCode4) from ParamItemTable o where o.notes like '%RAPIDID%'").list();
		  System.Collections.IEnumerator iterator = list.GetEnumerator();
		  int i = list.Count;
		  sbyte b = 0;
		  Console.WriteLine("\n\n\nCREATING " + i + " MERGED ASSEMBLIES");
		  while (iterator.MoveNext())
		  {
			string str = (string)iterator.Current;
			Query query = session.createQuery("from ParamItemTable o where o.extraCode4 = :c order by o.paramitemId");
			query.setString("c", str);
			Console.WriteLine("Processing [" + ++b + "/" + i + "] :" + str);
			if (str.ToLower().IndexOf("rooftop", StringComparison.Ordinal) == -1)
			{
			  continue;
			}
			MergedAssemblyGenerator.Instance.mergeToOne(session, query.list(), str);
			if (b % 10 == 0)
			{
			  session.Transaction.commit();
			  session.beginTransaction();
			}
		  }
		  session.Transaction.commit();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  if (DatabaseDBUtil.currentSession().Transaction.Active)
		  {
			DatabaseDBUtil.currentSession().Transaction.rollback();
		  }
		}
		DatabaseDBUtil.closeSession();
		Console.WriteLine("Finished Merging Assemblies");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadRapidsAsParamItems(java.sql.Connection paramConnection, org.hibernate.Session paramSession) throws Exception
	  private void loadRapidsAsParamItems(Connection paramConnection, Session paramSession)
	  {
		string str = "select * from rapidlist o order by o.RapidId asc ";
		PreparedStatement preparedStatement = paramConnection.prepareStatement(str);
		ResultSet resultSet = preparedStatement.executeQuery();
		sbyte b = 1;
		Transaction transaction = paramSession.beginTransaction();
		while (resultSet.next())
		{
		  string str1 = resultSet.getString(1);
		  string str2 = resultSet.getString(2);
		  string str3 = resultSet.getString(3);
		  string str4 = resultSet.getString(4);
		  string str5 = resultSet.getString(5);
		  saveOrUpdateParamItem(paramSession, str2, str3, str4, str5);
		  if (b % 'Ǵ' == '\x0000')
		  {
			Console.WriteLine("INFO: Finished Processing Rapids: " + b);
			transaction.commit();
			if (b % 'ᎈ' == '\x0000')
			{
			  Console.WriteLine("Sleeping for some time to Garbage collect!");
			  DatabaseDBUtil.closeSession();
			  System.GC.Collect();
			  Thread.Sleep(500L);
			  paramSession = DatabaseDBUtil.currentSession();
			}
			transaction = paramSession.beginTransaction();
		  }
		  b++;
		}
		transaction.commit();
		preparedStatement.close();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadLineItemsAsResources(java.sql.Connection paramConnection, org.hibernate.Session paramSession) throws Exception
	  private void loadLineItemsAsResources(Connection paramConnection, Session paramSession)
	  { // Byte code:
		//   0: ldc 'select * from lineitems o order by o.acct asc '
		//   2: astore_3
		//   3: aload_1
		//   4: aload_3
		//   5: invokeinterface prepareStatement : (Ljava/lang/String;)Ljava/sql/PreparedStatement;
		//   10: astore #4
		//   12: aload #4
		//   14: invokeinterface executeQuery : ()Ljava/sql/ResultSet;
		//   19: astore #5
		//   21: iconst_0
		//   22: istore #6
		//   24: aload_2
		//   25: invokeinterface beginTransaction : ()Lorg/hibernate/Transaction;
		//   30: astore #7
		//   32: aload #5
		//   34: invokeinterface next : ()Z
		//   39: ifeq -> 742
		//   42: aload #5
		//   44: iconst_1
		//   45: invokeinterface getString : (I)Ljava/lang/String;
		//   50: astore #8
		//   52: aload #5
		//   54: iconst_2
		//   55: invokeinterface getString : (I)Ljava/lang/String;
		//   60: astore #9
		//   62: aload #5
		//   64: iconst_3
		//   65: invokeinterface getString : (I)Ljava/lang/String;
		//   70: astore #10
		//   72: aload #5
		//   74: iconst_4
		//   75: invokeinterface getString : (I)Ljava/lang/String;
		//   80: astore #11
		//   82: aload #5
		//   84: iconst_5
		//   85: invokeinterface getDouble : (I)D
		//   90: dstore #12
		//   92: aload #5
		//   94: bipush #6
		//   96: invokeinterface getDouble : (I)D
		//   101: dstore #14
		//   103: aload #5
		//   105: bipush #7
		//   107: invokeinterface getDouble : (I)D
		//   112: dstore #16
		//   114: aload #5
		//   116: bipush #8
		//   118: invokeinterface getDouble : (I)D
		//   123: dstore #18
		//   125: aload #5
		//   127: bipush #9
		//   129: invokeinterface getDouble : (I)D
		//   134: dstore #20
		//   136: aload #5
		//   138: bipush #10
		//   140: invokeinterface getString : (I)Ljava/lang/String;
		//   145: astore #22
		//   147: aload #5
		//   149: bipush #11
		//   151: invokeinterface getString : (I)Ljava/lang/String;
		//   156: astore #23
		//   158: aload #5
		//   160: bipush #12
		//   162: invokeinterface getString : (I)Ljava/lang/String;
		//   167: astore #24
		//   169: iload #6
		//   171: sipush #500
		//   174: irem
		//   175: ifne -> 252
		//   178: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   181: new java/lang/StringBuilder
		//   184: dup
		//   185: invokespecial <init> : ()V
		//   188: ldc 'INFO: Finished Processing LineItems: '
		//   190: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   193: iload #6
		//   195: invokevirtual append : (I)Ljava/lang/StringBuilder;
		//   198: invokevirtual toString : ()Ljava/lang/String;
		//   201: invokevirtual println : (Ljava/lang/String;)V
		//   204: aload #7
		//   206: invokeinterface commit : ()V
		//   211: iload #6
		//   213: sipush #5000
		//   216: irem
		//   217: ifne -> 244
		//   220: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   223: ldc 'Sleeping for some time to Garbage collect!'
		//   225: invokevirtual println : (Ljava/lang/String;)V
		//   228: invokestatic closeSession : ()V
		//   231: invokestatic gc : ()V
		//   234: ldc2_w 500
		//   237: invokestatic sleep : (J)V
		//   240: invokestatic currentSession : ()Lorg/hibernate/Session;
		//   243: astore_2
		//   244: aload_2
		//   245: invokeinterface beginTransaction : ()Lorg/hibernate/Transaction;
		//   250: astore #7
		//   252: aload_0
		//   253: getfield MULTI_GROUP_LABORS : Z
		//   256: ifne -> 269
		//   259: iload #6
		//   261: aload_0
		//   262: getfield NON_MULTI_GROUP_MAX_COUNT : I
		//   265: irem
		//   266: ifne -> 269
		//   269: iload #6
		//   271: sipush #10000
		//   274: irem
		//   275: ifne -> 278
		//   278: aconst_null
		//   279: astore #25
		//   281: aconst_null
		//   282: astore #26
		//   284: aconst_null
		//   285: astore #27
		//   287: aconst_null
		//   288: astore #28
		//   290: aconst_null
		//   291: astore #29
		//   293: dload #20
		//   295: dconst_0
		//   296: dcmpl
		//   297: ifeq -> 427
		//   300: aload #11
		//   302: ldc 'HR'
		//   304: invokevirtual equals : (Ljava/lang/Object;)Z
		//   307: ifne -> 370
		//   310: aload #11
		//   312: ldc 'MO'
		//   314: invokevirtual equals : (Ljava/lang/Object;)Z
		//   317: ifne -> 370
		//   320: aload #11
		//   322: ldc 'WK'
		//   324: invokevirtual equals : (Ljava/lang/Object;)Z
		//   327: ifne -> 370
		//   330: aload #11
		//   332: ldc 'HOUR'
		//   334: invokevirtual equals : (Ljava/lang/Object;)Z
		//   337: ifne -> 370
		//   340: aload #11
		//   342: ldc 'DAY'
		//   344: invokevirtual equals : (Ljava/lang/Object;)Z
		//   347: ifne -> 370
		//   350: aload #11
		//   352: ldc 'MONTH'
		//   354: invokevirtual equals : (Ljava/lang/Object;)Z
		//   357: ifne -> 370
		//   360: aload #11
		//   362: ldc 'WEEK'
		//   364: invokevirtual equals : (Ljava/lang/Object;)Z
		//   367: ifeq -> 400
		//   370: aload_0
		//   371: aload_2
		//   372: aload #8
		//   374: aload #10
		//   376: aload #9
		//   378: dload #20
		//   380: aload #11
		//   382: aload #23
		//   384: aload_0
		//   385: getfield lastUpdate : Ljava/util/Date;
		//   388: invokespecial saveOrUpdateEquipmentTable : (Lorg/hibernate/Session;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;DLjava/lang/String;Ljava/lang/String;Ljava/util/Date;)Lnomitech/common/db/local/EquipmentTable;
		//   391: astore #26
		//   393: aload #26
		//   395: astore #25
		//   397: goto -> 427
		//   400: aload_0
		//   401: aload_2
		//   402: aload #8
		//   404: aload #10
		//   406: aload #9
		//   408: dload #20
		//   410: aload #11
		//   412: aload #23
		//   414: aload_0
		//   415: getfield lastUpdate : Ljava/util/Date;
		//   418: invokespecial saveOrUpdateConsumableTable : (Lorg/hibernate/Session;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;DLjava/lang/String;Ljava/lang/String;Ljava/util/Date;)Lnomitech/common/db/local/ConsumableTable;
		//   421: astore #29
		//   423: aload #29
		//   425: astore #25
		//   427: dload #14
		//   429: dconst_0
		//   430: dcmpl
		//   431: ifeq -> 463
		//   434: aload_0
		//   435: aload_2
		//   436: aload #8
		//   438: aload #10
		//   440: aload #9
		//   442: dload #12
		//   444: dload #14
		//   446: aload #11
		//   448: aload #23
		//   450: aload_0
		//   451: getfield lastUpdate : Ljava/util/Date;
		//   454: invokespecial saveOrUpdateMaterialTable : (Lorg/hibernate/Session;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;DDLjava/lang/String;Ljava/lang/String;Ljava/util/Date;)Lnomitech/common/db/local/MaterialTable;
		//   457: astore #27
		//   459: aload #27
		//   461: astore #25
		//   463: dload #18
		//   465: dconst_0
		//   466: dcmpl
		//   467: ifeq -> 499
		//   470: aload_0
		//   471: aload_2
		//   472: aload #8
		//   474: aload #10
		//   476: aload #9
		//   478: dload #12
		//   480: dload #18
		//   482: aload #11
		//   484: aload #23
		//   486: aload_0
		//   487: getfield lastUpdate : Ljava/util/Date;
		//   490: invokespecial saveOrUpdateSubcontractorTable : (Lorg/hibernate/Session;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;DDLjava/lang/String;Ljava/lang/String;Ljava/util/Date;)Lnomitech/common/db/local/SubcontractorTable;
		//   493: astore #28
		//   495: aload #28
		//   497: astore #25
		//   499: dload #16
		//   501: dconst_0
		//   502: dcmpl
		//   503: ifeq -> 544
		//   506: aload_0
		//   507: aload_2
		//   508: aload #8
		//   510: aload #10
		//   512: aload #9
		//   514: dload #12
		//   516: dload #16
		//   518: aload #22
		//   520: aload #11
		//   522: aload #23
		//   524: aload_0
		//   525: getfield lastUpdate : Ljava/util/Date;
		//   528: aload #26
		//   530: aload #27
		//   532: aload #28
		//   534: aload #29
		//   536: invokespecial saveOrUpdateAssemblyTable : (Lorg/hibernate/Session;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;DDLjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/Date;Lnomitech/common/db/local/EquipmentTable;Lnomitech/common/db/local/MaterialTable;Lnomitech/common/db/local/SubcontractorTable;Lnomitech/common/db/local/ConsumableTable;)Lnomitech/common/db/local/AssemblyTable;
		//   539: astore #25
		//   541: goto -> 705
		//   544: aload #28
		//   546: ifnull -> 592
		//   549: aload #27
		//   551: ifnull -> 592
		//   554: aload_0
		//   555: aload_2
		//   556: aload #8
		//   558: aload #10
		//   560: aload #9
		//   562: dload #12
		//   564: dload #16
		//   566: aload #22
		//   568: aload #11
		//   570: aload #23
		//   572: aload_0
		//   573: getfield lastUpdate : Ljava/util/Date;
		//   576: aload #26
		//   578: aload #27
		//   580: aload #28
		//   582: aload #29
		//   584: invokespecial saveOrUpdateAssemblyTable : (Lorg/hibernate/Session;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;DDLjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/Date;Lnomitech/common/db/local/EquipmentTable;Lnomitech/common/db/local/MaterialTable;Lnomitech/common/db/local/SubcontractorTable;Lnomitech/common/db/local/ConsumableTable;)Lnomitech/common/db/local/AssemblyTable;
		//   587: astore #25
		//   589: goto -> 705
		//   592: aload #26
		//   594: ifnull -> 602
		//   597: aload #27
		//   599: ifnonnull -> 612
		//   602: aload #29
		//   604: ifnull -> 650
		//   607: aload #27
		//   609: ifnull -> 650
		//   612: aload_0
		//   613: aload_2
		//   614: aload #8
		//   616: aload #10
		//   618: aload #9
		//   620: dload #12
		//   622: dload #16
		//   624: aload #22
		//   626: aload #11
		//   628: aload #23
		//   630: aload_0
		//   631: getfield lastUpdate : Ljava/util/Date;
		//   634: aload #26
		//   636: aload #27
		//   638: aload #28
		//   640: aload #29
		//   642: invokespecial saveOrUpdateAssemblyTable : (Lorg/hibernate/Session;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;DDLjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/Date;Lnomitech/common/db/local/EquipmentTable;Lnomitech/common/db/local/MaterialTable;Lnomitech/common/db/local/SubcontractorTable;Lnomitech/common/db/local/ConsumableTable;)Lnomitech/common/db/local/AssemblyTable;
		//   645: astore #25
		//   647: goto -> 705
		//   650: aload #26
		//   652: ifnull -> 660
		//   655: aload #28
		//   657: ifnonnull -> 670
		//   660: aload #29
		//   662: ifnull -> 705
		//   665: aload #28
		//   667: ifnull -> 705
		//   670: aload_0
		//   671: aload_2
		//   672: aload #8
		//   674: aload #10
		//   676: aload #9
		//   678: dload #12
		//   680: dload #16
		//   682: aload #22
		//   684: aload #11
		//   686: aload #23
		//   688: aload_0
		//   689: getfield lastUpdate : Ljava/util/Date;
		//   692: aload #26
		//   694: aload #27
		//   696: aload #28
		//   698: aload #29
		//   700: invokespecial saveOrUpdateAssemblyTable : (Lorg/hibernate/Session;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;DDLjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/Date;Lnomitech/common/db/local/EquipmentTable;Lnomitech/common/db/local/MaterialTable;Lnomitech/common/db/local/SubcontractorTable;Lnomitech/common/db/local/ConsumableTable;)Lnomitech/common/db/local/AssemblyTable;
		//   703: astore #25
		//   705: aload_0
		//   706: getfield lineItemCache : Ljava/util/Map;
		//   709: aload #23
		//   711: invokeinterface get : (Ljava/lang/Object;)Ljava/lang/Object;
		//   716: checkcast nomitech/common/migration/richardson/RichardsonLineItem
		//   719: astore #30
		//   721: aload #30
		//   723: ifnull -> 736
		//   726: aload #30
		//   728: aload #25
		//   730: aload #8
		//   732: iconst_1
		//   733: invokevirtual init : (Lnomitech/common/base/BaseTable;Ljava/lang/String;Z)V
		//   736: iinc #6, 1
		//   739: goto -> 32
		//   742: aload #7
		//   744: invokeinterface commit : ()V
		//   749: aload #4
		//   751: invokeinterface close : ()V
		//   756: return }

	  private void saveOrUpdateParamItem(Session paramSession, string paramString1, string paramString2, string paramString3, string paramString4) throws Exception
	  {
		string str1 = "A. Localization";
		DateTime date = DateTime.Now;
		ParamItemTable paramItemTable = BlankResourceInitializer.createBlankParamItem(null);
		string str2 = UOMConverter.convertImperialToMetricUnit(paramString4);
		if (string.ReferenceEquals(str2, null))
		{
		  Console.WriteLine("FATAL: UNIT WAS NULL FOR " + paramString4 + ". AND RAPIDID " + paramString2);
		  Environment.Exit(0);
		}
		string str3 = rapidTitleToGroupCode(paramSession, paramString2);
		paramItemTable.ItemCode = paramString2;
		paramItemTable.Title = paramString1;
		paramItemTable.Variable = "";
		paramItemTable.GroupName = "";
		paramItemTable.Icon = "";
		paramItemTable.CostModel = false;
		paramItemTable.SampleRate = BigDecimalMath.ZERO;
		paramItemTable.GroupCode = "";
		paramItemTable.GekCode = "";
		paramItemTable.ExtraCode1 = "";
		paramItemTable.ExtraCode2 = str3;
		paramItemTable.ExtraCode3 = "";
		paramItemTable.ExtraCode4 = "";
		paramItemTable.ExtraCode5 = "";
		paramItemTable.ExtraCode6 = "";
		paramItemTable.ExtraCode7 = "";
		paramItemTable.ExtraCode8 = "";
		paramItemTable.ExtraCode9 = "";
		paramItemTable.ExtraCode10 = "";
		paramItemTable.LastUpdate = new Timestamp(date.Ticks);
		paramItemTable.CreateDate = paramItemTable.LastUpdate;
		paramItemTable.CreateUserId = "richardson";
		paramItemTable.EditorId = "richardson";
		paramItemTable.InputSet = new HashSet<object>();
		paramItemTable.OutputSet = new HashSet<object>();
		paramItemTable.Notes = "RAPIDID: " + paramString2;
		paramItemTable.Description = paramString1 + ", MAIN ITEM SN: " + paramString3 + "\nPDF: " + acctToPDFLink(paramString2);
		paramItemTable.Unit = str2;
		long? long1 = paramItemTable.ParamitemId;
		if (long1 == null)
		{
		  long1 = (long?)paramSession.save(paramItemTable);
		}
		else
		{
		  paramSession.update(paramItemTable);
		}
		paramItemTable = (ParamItemTable)DatabaseDBUtil.loadBulk(typeof(ParamItemTable), new long?[] {long1})[0];
		System.Collections.IList list = (System.Collections.IList)this.rapidDetailCache[paramString2];
		this.lastUpdate = null;
		sbyte b1 = 1;
		ParamItemInputTable paramItemInputTable = new ParamItemInputTable();
		paramItemInputTable.Name = "UseLocation";
		paramItemInputTable.Label = paramItemInputTable.Name;
		paramItemInputTable.DataType = "datatype.boolean";
		paramItemInputTable.DefaultValue = "FALSE";
		paramItemInputTable.DependencyStatement = "";
		paramItemInputTable.ValidationStatement = "";
		paramItemInputTable.Description = "Click to use location factors";
		paramItemInputTable.Grouping = str1;
		paramItemInputTable.SelectionList = "";
		paramItemInputTable.SortOrder = Convert.ToInt32(b1++);
		paramItemInputTable.Pblk = true;
		paramItemInputTable.Hidden = false;
		paramItemInputTable.ParamItemTable = paramItemTable;
		long? long2 = (long?)paramSession.save(paramItemInputTable);
		paramItemInputTable = (ParamItemInputTable)paramSession.load(typeof(ParamItemInputTable), long2);
		paramItemTable.InputSet.Add(paramItemInputTable);
		paramSession.update(paramItemInputTable);
		paramItemInputTable = new ParamItemInputTable();
		paramItemInputTable.Name = "Location";
		paramItemInputTable.Label = paramItemInputTable.Name;
		paramItemInputTable.DataType = "datatype.locfactor";
		paramItemInputTable.DependencyStatement = "UseLocation=TRUE()";
		paramItemInputTable.ValidationStatement = "";
		paramItemInputTable.Description = "Choose a location factor";
		paramItemInputTable.Grouping = str1;
		paramItemInputTable.SelectionList = this.LOCATION_PROFILE_ID;
		paramItemInputTable.DefaultValue = this.DEFAULT_LOCATION_FACTOR;
		paramItemInputTable.SortOrder = Convert.ToInt32(b1++);
		paramItemInputTable.Pblk = true;
		paramItemInputTable.Hidden = false;
		paramItemInputTable.ParamItemTable = paramItemTable;
		long2 = (long?)paramSession.save(paramItemInputTable);
		paramItemInputTable = (ParamItemInputTable)paramSession.load(typeof(ParamItemInputTable), long2);
		paramItemTable.InputSet.Add(paramItemInputTable);
		paramSession.update(paramItemInputTable);
		sbyte b2 = 1;
		foreach (RichardsonRapidDetail richardsonRapidDetail in list)
		{
		  RichardsonLineItem richardsonLineItem = (RichardsonLineItem)this.lineItemCache[richardsonRapidDetail.ItemSerial];
		  ParamItemOutputTable paramItemOutputTable = new ParamItemOutputTable();
		  paramItemOutputTable.Title = richardsonLineItem.Title;
		  paramItemOutputTable.GenerationCondition = "TRUE()";
		  paramItemOutputTable.ProductivityEquation = "PRODUCTIVITY";
		  paramItemOutputTable.FactorEquation = "FACTOR";
		  paramItemOutputTable.EquLocEquation = "FACTOR";
		  paramItemOutputTable.SubLocEquation = "FACTOR";
		  paramItemOutputTable.LabLocEquation = "IF(UseLocation,Location,FACTOR)";
		  paramItemOutputTable.MatLocEquation = "FACTOR";
		  paramItemOutputTable.ConLocEquation = "FACTOR";
		  if (richardsonRapidDetail.ConversionFactor != null && richardsonRapidDetail.ConversionFactor.Value != 1.0D)
		  {
			paramItemOutputTable.QuantityEquation = richardsonRapidDetail.Qty + "/" + richardsonRapidDetail.ConversionFactor;
		  }
		  else
		  {
			paramItemOutputTable.QuantityEquation = "" + richardsonRapidDetail.Qty;
		  }
		  paramItemOutputTable.SortOrder = Convert.ToInt32(b2++);
		  paramItemOutputTable.ResourceIds = richardsonLineItem.ToString();
		  paramItemOutputTable.ParamItemTable = paramItemTable;
		  long2 = (long?)paramSession.save(paramItemOutputTable);
		  paramItemOutputTable = (ParamItemOutputTable)paramSession.load(typeof(ParamItemOutputTable), long2);
		  paramItemTable.OutputSet.Add(paramItemOutputTable);
		  if (this.lastUpdate == null)
		  {
			this.lastUpdate = richardsonLineItem.LastUpdate;
			continue;
		  }
		  if (this.lastUpdate < richardsonLineItem.LastUpdate)
		  {
			this.lastUpdate = richardsonLineItem.LastUpdate;
		  }
		}
		if (this.lastUpdate != null)
		{
		  paramItemTable.LastUpdate = this.lastUpdate;
		  paramItemTable.CreateDate = this.lastUpdate;
		}
		paramSession.update(paramItemTable);
	  }

	  private AssemblyTable saveOrUpdateAssemblyTable(Session paramSession, string paramString1, string paramString2, string paramString3, double paramDouble1, double paramDouble2, string paramString4, string paramString5, string paramString6, DateTime paramDate, EquipmentTable paramEquipmentTable, MaterialTable paramMaterialTable, SubcontractorTable paramSubcontractorTable, ConsumableTable paramConsumableTable) throws Exception
	  {
		AssemblyTable assemblyTable = BlankResourceInitializer.createBlankAssembly(null);
		double d = 1.0D;
		if (paramDouble2 != 0.0D)
		{
		  d = 1.0D / paramDouble2;
		}
		string str1 = UOMConverter.convertImperialToMetricUnit(paramString5);
		if (string.ReferenceEquals(str1, null))
		{
		  throw new Exception("FATAL: UNIT WAS NULL FOR " + paramString5 + ". AND ACCT " + paramString1);
		}
		string str2 = acctToGroupCode(paramSession, paramString1);
		assemblyTable.ItemCode = paramString1;
		assemblyTable.Title = paramString2;
		assemblyTable.GroupCode = "";
		assemblyTable.GekCode = "";
		assemblyTable.ExtraCode1 = "";
		assemblyTable.ExtraCode2 = str2;
		assemblyTable.ExtraCode3 = "";
		assemblyTable.ExtraCode4 = "";
		assemblyTable.ExtraCode5 = "";
		assemblyTable.ExtraCode6 = "";
		assemblyTable.ExtraCode7 = "";
		assemblyTable.ExtraCode8 = "";
		assemblyTable.ExtraCode9 = "";
		assemblyTable.ExtraCode10 = "";
		assemblyTable.Unit = str1;
		assemblyTable.EditorId = "richardson";
		assemblyTable.StateProvince = "USA AVERAGE";
		assemblyTable.Country = "US";
		assemblyTable.Currency = "USD";
		assemblyTable.Productivity = new BigDecimalFixed("" + d);
		assemblyTable.Project = "";
		assemblyTable.PublishedRate = BigDecimalMath.ZERO;
		assemblyTable.PublishedRevisionCode = paramString1;
		assemblyTable.BimMaterial = "";
		assemblyTable.BimType = "";
		assemblyTable.Notes = "ACCT: " + paramString1;
		assemblyTable.Description = paramString3 + ", SN: " + paramString6 + "\nPDF: " + acctToPDFLink(paramString1);
		assemblyTable.Virtual = false;
		assemblyTable.VirtualEquipment = false;
		assemblyTable.VirtualSubcontractor = false;
		assemblyTable.VirtualLabor = false;
		assemblyTable.VirtualMaterial = false;
		assemblyTable.VirtualConsumable = false;
		if (paramDate != null)
		{
		  assemblyTable.LastUpdate = new Timestamp(paramDate.Time);
		}
		else
		{
		  assemblyTable.LastUpdate = new Timestamp(DateTimeHelper.CurrentUnixTimeMillis());
		}
		assemblyTable.Quantity = BigDecimalMath.ZERO;
		assemblyTable.Accuracy = "enum.quotation.accuracy.estimated";
		assemblyTable.CreateDate = assemblyTable.LastUpdate;
		assemblyTable.CreateUserId = "richardson";
		Serializable serializable = assemblyTable.AssemblyId;
		if (serializable == null)
		{
		  serializable = paramSession.save(assemblyTable);
		}
		else
		{
		  paramSession.update(assemblyTable);
		}
		assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), serializable);
		if (paramDouble2 != 0.0D)
		{
		  ISet<object> set = assemblyTable.AssemblyLaborSet;
		  if (set == null)
		  {
			assemblyTable.AssemblyLaborSet = new HashSet<object>();
		  }
		  System.Collections.IList list = (System.Collections.IList)this.crewCache[paramString4];
		  if (list == null)
		  {
			Console.WriteLine("ERROR: Crew Id: " + paramString4 + " does not have a Crew! for assembly: " + assemblyTable);
			return null;
		  }
		  foreach (RichardsonCrew richardsonCrew in list)
		  {
			LaborTable laborTable = (LaborTable)this.laborCraftCache[richardsonCrew.CraftId];
			string str = richardsonCrew.CraftId;
			if (this.MULTI_GROUP_LABORS)
			{
			  str = str + str2;
			}
			laborTable = (LaborTable)this.laborTableCache[str];
			if (laborTable != null)
			{
			  if (DatabaseDBUtil.LocalCommunication)
			  {
				laborTable = (LaborTable)paramSession.get(typeof(LaborTable), laborTable.LaborId);
			  }
			  else
			  {
				laborTable = (LaborTable)DatabaseDBUtil.loadBulk(typeof(LaborTable), new long?[] {laborTable.LaborId})[0];
			  }
			}
			else
			{
			  laborTable = (LaborTable)this.laborCraftCache[richardsonCrew.CraftId];
			  laborTable = (LaborTable)laborTable.clone();
			  laborTable.ExtraCode2 = str2;
			  long? long1 = (long?)paramSession.save(laborTable);
			  laborTable.LaborId = long1;
			  this.laborTableCache[str] = (LaborTable)laborTable.clone();
			  if (DatabaseDBUtil.LocalCommunication)
			  {
				laborTable = (LaborTable)paramSession.get(typeof(LaborTable), long1);
			  }
			  else
			  {
				laborTable = (LaborTable)DatabaseDBUtil.loadBulk(typeof(LaborTable), new long?[] {long1})[0];
			  }
			}
			AssemblyLaborTable assemblyLaborTable = new AssemblyLaborTable();
			assemblyLaborTable.Factor1 = new BigDecimalFixed(richardsonCrew.Percentange);
			assemblyLaborTable.Factor2 = BigDecimalMath.ONE;
			assemblyLaborTable.Factor3 = BigDecimalMath.ONE;
			assemblyLaborTable.QuantityPerUnit = BigDecimalMath.ONE;
			assemblyLaborTable.QuantityPerUnitFormula = "";
			assemblyLaborTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
			assemblyLaborTable.LocalFactor = BigDecimalMath.ONE;
			assemblyLaborTable.LocalCountry = laborTable.Country;
			assemblyLaborTable.LocalStateProvince = laborTable.StateProvince;
			assemblyLaborTable.LastUpdate = assemblyTable.LastUpdate;
			assemblyLaborTable.ExchangeRate = decimal.One;
			long? long = (long?)paramSession.save(assemblyLaborTable);
			assemblyLaborTable.AssemblyLaborId = long;
			if (DatabaseDBUtil.LocalCommunication)
			{
			  assemblyTable.AssemblyLaborSet.Add(assemblyLaborTable);
			  paramSession.saveOrUpdate(assemblyTable);
			  assemblyLaborTable.LaborTable = laborTable;
			  assemblyLaborTable.AssemblyTable = assemblyTable;
			  paramSession.saveOrUpdate(assemblyLaborTable);
			  continue;
			}
			assemblyLaborTable = (AssemblyLaborTable)DatabaseDBUtil.associateAssemblyResource(assemblyTable, laborTable, assemblyLaborTable);
			assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), assemblyTable.Id);
		  }
		}
		if (paramEquipmentTable != null)
		{
		  AssemblyEquipmentTable assemblyEquipmentTable = new AssemblyEquipmentTable();
		  assemblyEquipmentTable.Factor1 = BigDecimalMath.ONE;
		  assemblyEquipmentTable.Factor2 = BigDecimalMath.ONE;
		  assemblyEquipmentTable.Factor3 = BigDecimalMath.ONE;
		  assemblyEquipmentTable.QuantityPerUnit = BigDecimalMath.ONE;
		  assemblyEquipmentTable.QuantityPerUnitFormula = "";
		  assemblyEquipmentTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
		  assemblyEquipmentTable.LocalFactor = BigDecimalMath.ONE;
		  assemblyEquipmentTable.LocalCountry = "";
		  assemblyEquipmentTable.LocalStateProvince = "";
		  assemblyEquipmentTable.ExchangeRate = decimal.One;
		  assemblyEquipmentTable.EnergyPrice = BigDecimalMath.ZERO;
		  assemblyEquipmentTable.FuelRate = BigDecimalMath.ZERO;
		  assemblyEquipmentTable.LastUpdate = assemblyTable.LastUpdate;
		  long? long = (long?)paramSession.save(assemblyEquipmentTable);
		  assemblyEquipmentTable.AssemblyEquipmentId = long;
		  if (DatabaseDBUtil.LocalCommunication)
		  {
			assemblyTable.AssemblyEquipmentSet.Add(assemblyEquipmentTable);
			paramSession.saveOrUpdate(assemblyTable);
			assemblyEquipmentTable.EquipmentTable = paramEquipmentTable;
			assemblyEquipmentTable.AssemblyTable = assemblyTable;
			paramSession.saveOrUpdate(assemblyEquipmentTable);
		  }
		  else
		  {
			assemblyEquipmentTable = (AssemblyEquipmentTable)DatabaseDBUtil.associateAssemblyResource(assemblyTable, paramEquipmentTable, assemblyEquipmentTable);
			assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), assemblyTable.Id);
		  }
		}
		if (paramSubcontractorTable != null)
		{
		  AssemblySubcontractorTable assemblySubcontractorTable = new AssemblySubcontractorTable();
		  assemblySubcontractorTable.Factor1 = BigDecimalMath.ONE;
		  assemblySubcontractorTable.Factor2 = BigDecimalMath.ONE;
		  assemblySubcontractorTable.Factor3 = BigDecimalMath.ONE;
		  assemblySubcontractorTable.QuantityPerUnit = BigDecimalMath.ONE;
		  assemblySubcontractorTable.QuantityPerUnitFormula = "";
		  assemblySubcontractorTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
		  assemblySubcontractorTable.LocalFactor = BigDecimalMath.ONE;
		  assemblySubcontractorTable.LocalCountry = paramSubcontractorTable.Country;
		  assemblySubcontractorTable.LocalStateProvince = paramSubcontractorTable.StateProvince;
		  assemblySubcontractorTable.ExchangeRate = decimal.One;
		  assemblySubcontractorTable.LastUpdate = assemblyTable.LastUpdate;
		  long? long = (long?)paramSession.save(assemblySubcontractorTable);
		  assemblySubcontractorTable.AssemblySubcontractorId = long;
		  if (DatabaseDBUtil.LocalCommunication)
		  {
			assemblySubcontractorTable.SubcontractorTable = paramSubcontractorTable;
			assemblySubcontractorTable.AssemblyTable = assemblyTable;
			paramSession.saveOrUpdate(assemblySubcontractorTable);
			paramSubcontractorTable.AssemblySubcontractorSet.add(assemblySubcontractorTable);
			paramSubcontractorTable.recalculate();
			paramSession.saveOrUpdate(paramSubcontractorTable);
			assemblyTable.AssemblySubcontractorSet.Add(assemblySubcontractorTable);
			assemblyTable.recalculate();
			paramSession.saveOrUpdate(assemblyTable);
		  }
		  else
		  {
			assemblySubcontractorTable = (AssemblySubcontractorTable)DatabaseDBUtil.associateAssemblyResource(assemblyTable, paramSubcontractorTable, assemblySubcontractorTable);
			assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), assemblyTable.Id);
		  }
		}
		if (paramMaterialTable != null)
		{
		  AssemblyMaterialTable assemblyMaterialTable = new AssemblyMaterialTable();
		  assemblyMaterialTable.Factor1 = BigDecimalMath.ONE;
		  assemblyMaterialTable.Factor2 = BigDecimalMath.ONE;
		  assemblyMaterialTable.Factor3 = BigDecimalMath.ONE;
		  assemblyMaterialTable.QuantityPerUnit = BigDecimalMath.ONE;
		  assemblyMaterialTable.QuantityPerUnitFormula = "";
		  assemblyMaterialTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
		  assemblyMaterialTable.LocalFactor = BigDecimalMath.ONE;
		  assemblyMaterialTable.LocalCountry = paramMaterialTable.Country;
		  assemblyMaterialTable.LocalStateProvince = paramMaterialTable.StateProvince;
		  assemblyMaterialTable.ExchangeRate = decimal.One;
		  assemblyMaterialTable.LastUpdate = assemblyTable.LastUpdate;
		  long? long = (long?)paramSession.save(assemblyMaterialTable);
		  assemblyMaterialTable.AssemblyMaterialId = long;
		  if (DatabaseDBUtil.LocalCommunication)
		  {
			paramMaterialTable.AssemblyMaterialSet.add(assemblyMaterialTable);
			paramMaterialTable.recalculate();
			paramSession.saveOrUpdate(paramMaterialTable);
			assemblyTable.AssemblyMaterialSet.Add(assemblyMaterialTable);
			paramSession.saveOrUpdate(assemblyTable);
			assemblyMaterialTable.MaterialTable = paramMaterialTable;
			assemblyMaterialTable.AssemblyTable = assemblyTable;
			paramSession.saveOrUpdate(assemblyMaterialTable);
		  }
		  else
		  {
			assemblyMaterialTable = (AssemblyMaterialTable)DatabaseDBUtil.associateAssemblyResource(assemblyTable, paramMaterialTable, assemblyMaterialTable);
			assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), assemblyTable.Id);
		  }
		}
		if (paramConsumableTable != null)
		{
		  AssemblyConsumableTable assemblyConsumableTable = new AssemblyConsumableTable();
		  assemblyConsumableTable.Factor1 = BigDecimalMath.ONE;
		  assemblyConsumableTable.Factor2 = BigDecimalMath.ONE;
		  assemblyConsumableTable.Factor3 = BigDecimalMath.ONE;
		  assemblyConsumableTable.QuantityPerUnit = BigDecimalMath.ONE;
		  assemblyConsumableTable.QuantityPerUnitFormula = "";
		  assemblyConsumableTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
		  assemblyConsumableTable.LocalFactor = BigDecimalMath.ONE;
		  assemblyConsumableTable.LocalCountry = paramConsumableTable.Country;
		  assemblyConsumableTable.LocalStateProvince = paramConsumableTable.StateProvince;
		  assemblyConsumableTable.LastUpdate = assemblyTable.LastUpdate;
		  assemblyConsumableTable.ExchangeRate = decimal.One;
		  long? long = (long?)paramSession.save(assemblyConsumableTable);
		  assemblyConsumableTable.AssemblyConsumableId = long;
		  if (DatabaseDBUtil.LocalCommunication)
		  {
			assemblyConsumableTable.ConsumableTable = paramConsumableTable;
			assemblyConsumableTable.AssemblyTable = assemblyTable;
			paramSession.saveOrUpdate(assemblyConsumableTable);
			paramConsumableTable.AssemblyConsumableSet.add(assemblyConsumableTable);
			paramConsumableTable.recalculate();
			paramSession.saveOrUpdate(paramConsumableTable);
			assemblyTable.AssemblyConsumableSet.Add(assemblyConsumableTable);
			assemblyTable.recalculate();
			paramSession.saveOrUpdate(assemblyTable);
		  }
		  else
		  {
			assemblyConsumableTable = (AssemblyConsumableTable)DatabaseDBUtil.associateAssemblyResource(assemblyTable, paramConsumableTable, assemblyConsumableTable);
			assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), assemblyTable.Id);
		  }
		}
		if (DatabaseDBUtil.LocalCommunication)
		{
		  assemblyTable.calculateRate();
		  paramSession.saveOrUpdate(assemblyTable);
		}
		return assemblyTable;
	  }

	  private SubcontractorTable saveOrUpdateSubcontractorTable(Session paramSession, string paramString1, string paramString2, string paramString3, double paramDouble1, double paramDouble2, string paramString4, string paramString5, DateTime paramDate)
	  {
		SubcontractorTable subcontractorTable = BlankResourceInitializer.createBlankSubcontractor(null);
		subcontractorTable.ItemCode = paramString1;
		subcontractorTable.Title = paramString2;
		string str = UOMConverter.convertImperialToMetricUnit(paramString4);
		if (string.ReferenceEquals(str, null))
		{
		  Console.WriteLine("FATAL: UNIT WAS NULL FOR " + paramString4 + ". AND ACCT " + paramString1);
		  Environment.Exit(0);
		}
		subcontractorTable.GroupCode = "";
		subcontractorTable.GekCode = "";
		subcontractorTable.ExtraCode1 = "";
		subcontractorTable.ExtraCode2 = acctToGroupCode(paramSession, paramString1);
		subcontractorTable.ExtraCode3 = "";
		subcontractorTable.ExtraCode4 = "";
		subcontractorTable.ExtraCode5 = "";
		subcontractorTable.ExtraCode6 = "";
		subcontractorTable.ExtraCode7 = "";
		subcontractorTable.ExtraCode8 = "";
		subcontractorTable.ExtraCode9 = "";
		subcontractorTable.ExtraCode10 = "";
		subcontractorTable.Unit = str;
		subcontractorTable.EditorId = "richardson";
		subcontractorTable.Address = "";
		subcontractorTable.ContactPerson = "";
		subcontractorTable.Rate = UOMConverter.convertImperialToMetricRate(paramString4, new BigDecimalFixed("" + paramDouble2));
		subcontractorTable.SubMaterialRate = BigDecimalMath.ZERO;
		subcontractorTable.IKA = BigDecimalMath.ZERO;
		subcontractorTable.City = "";
		subcontractorTable.Email = "";
		subcontractorTable.Company = "";
		subcontractorTable.FaxNumber = "";
		subcontractorTable.MobileNumber = "";
		subcontractorTable.PhoneNumber = "";
		subcontractorTable.Performance = "8";
		subcontractorTable.Url = "";
		subcontractorTable.Project = "";
		subcontractorTable.Country = "US";
		subcontractorTable.StateProvince = "USA AVERAGE";
		subcontractorTable.Currency = "USD";
		subcontractorTable.Accuracy = "enum.quotation.accuracy.estimated";
		subcontractorTable.Inclusion = "enum.inclusion.subonly";
		subcontractorTable.Quantity = new BigDecimalFixed("0");
		subcontractorTable.Notes = "ACCT: " + paramString1;
		subcontractorTable.Description = paramString3 + ", SN: " + paramString5 + "\nPDF: " + acctToPDFLink(paramString1);
		subcontractorTable.LastUpdate = new Timestamp(paramDate.Time);
		subcontractorTable.CreateDate = new Timestamp(paramDate.Time);
		subcontractorTable.CreateUserId = "RichardsonDBReader";
		long? long = subcontractorTable.SubcontractorId;
		if (long == null)
		{
		  long = (long?)paramSession.save(subcontractorTable);
		}
		else
		{
		  paramSession.update(subcontractorTable);
		}
		try
		{
		  subcontractorTable = (SubcontractorTable)DatabaseDBUtil.loadBulk(typeof(SubcontractorTable), new long?[] {long})[0];
		}
		catch (Exception exception)
		{
		  Console.WriteLine("When loading Subcontractor: " + exception.Message);
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		return subcontractorTable;
	  }

	  private MaterialTable saveOrUpdateMaterialTable(Session paramSession, string paramString1, string paramString2, string paramString3, double paramDouble1, double paramDouble2, string paramString4, string paramString5, DateTime paramDate)
	  {
		MaterialTable materialTable = BlankResourceInitializer.createBlankMaterial(null);
		materialTable.ItemCode = paramString1;
		materialTable.Title = paramString2;
		string str = UOMConverter.convertImperialToMetricUnit(paramString4);
		if (string.ReferenceEquals(str, null))
		{
		  Console.WriteLine("FATAL: UNIT WAS NULL FOR " + paramString4 + ". AND ACCT " + paramString1);
		  Environment.Exit(0);
		}
		materialTable.GroupCode = "";
		materialTable.GekCode = "";
		materialTable.ExtraCode1 = "";
		materialTable.ExtraCode2 = acctToGroupCode(paramSession, paramString1);
		materialTable.ExtraCode3 = "";
		materialTable.ExtraCode4 = "";
		materialTable.ExtraCode5 = "";
		materialTable.ExtraCode6 = "";
		materialTable.ExtraCode7 = "";
		materialTable.ExtraCode8 = "";
		materialTable.ExtraCode9 = "";
		materialTable.ExtraCode10 = "";
		materialTable.Unit = str;
		materialTable.EditorId = "richardson";
		materialTable.Weight = new BigDecimalFixed("" + paramDouble1);
		materialTable.WeightUnit = "LB";
		materialTable.Rate = UOMConverter.convertImperialToMetricRate(paramString4, new BigDecimalFixed("" + paramDouble2));
		materialTable.Project = "";
		materialTable.Country = "US";
		materialTable.RawMaterial = "enum.rm.unspecified";
		materialTable.RawMaterialReliance = BigDecimalMath.ZERO;
		materialTable.RawMaterial2 = "enum.rm.unspecified";
		materialTable.RawMaterialReliance2 = BigDecimalMath.ZERO;
		materialTable.RawMaterial3 = "enum.rm.unspecified";
		materialTable.RawMaterialReliance3 = BigDecimalMath.ZERO;
		materialTable.RawMaterial4 = "enum.rm.unspecified";
		materialTable.RawMaterialReliance4 = BigDecimalMath.ZERO;
		materialTable.RawMaterial5 = "enum.rm.unspecified";
		materialTable.RawMaterialReliance5 = BigDecimalMath.ZERO;
		materialTable.StateProvince = "USA AVERAGE";
		materialTable.Currency = "USD";
		materialTable.Notes = "ACCT: " + paramString1;
		materialTable.Description = paramString3 + ", SN: " + paramString5 + "\nPDF: " + acctToPDFLink(paramString1);
		materialTable.LastUpdate = new Timestamp(paramDate.Time);
		materialTable.Accuracy = "enum.quotation.accuracy.estimated";
		materialTable.Inclusion = "enum.inclusion.matonly";
		materialTable.Quantity = new BigDecimalFixed(0);
		materialTable.DistanceToSite = new BigDecimalFixed(0);
		materialTable.DistanceUnit = "MILE";
		materialTable.ShipmentRate = new BigDecimalFixed(0);
		materialTable.FabricationRate = new BigDecimalFixed(0);
		materialTable.TotalRate = materialTable.Rate;
		materialTable.CreateDate = new Timestamp(paramDate.Time);
		materialTable.CreateUserId = "RichardsonDBReader";
		materialTable.BimMaterial = "";
		materialTable.BimType = "";
		long? long = materialTable.MaterialId;
		if (long == null)
		{
		  long = (long?)paramSession.save(materialTable);
		}
		else
		{
		  paramSession.update(materialTable);
		}
		try
		{
		  materialTable = (MaterialTable)DatabaseDBUtil.loadBulk(typeof(MaterialTable), new long?[] {long})[0];
		}
		catch (Exception exception)
		{
		  Console.WriteLine("Error when loading Material: " + exception.Message);
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		return materialTable;
	  }

	  private ConsumableTable saveOrUpdateConsumableTable(Session paramSession, string paramString1, string paramString2, string paramString3, double paramDouble, string paramString4, string paramString5, DateTime paramDate)
	  {
		ConsumableTable consumableTable = BlankResourceInitializer.createBlankConsumable(null);
		consumableTable.ItemCode = paramString1;
		consumableTable.Title = paramString2;
		string str = UOMConverter.convertImperialToMetricUnit(paramString4);
		if (string.ReferenceEquals(str, null))
		{
		  Console.WriteLine("FATAL: UNIT WAS NULL FOR " + paramString4 + ". AND ACCT " + paramString1);
		  Environment.Exit(0);
		}
		consumableTable.GroupCode = "";
		consumableTable.GekCode = "";
		consumableTable.ExtraCode1 = "";
		consumableTable.ExtraCode2 = acctToGroupCode(paramSession, paramString1);
		consumableTable.ExtraCode3 = "";
		consumableTable.ExtraCode4 = "";
		consumableTable.ExtraCode5 = "";
		consumableTable.ExtraCode6 = "";
		consumableTable.ExtraCode7 = "";
		consumableTable.ExtraCode8 = "";
		consumableTable.ExtraCode9 = "";
		consumableTable.ExtraCode10 = "";
		consumableTable.Unit = str;
		consumableTable.EditorId = "richardson";
		consumableTable.Rate = UOMConverter.convertImperialToMetricRate(paramString4, new BigDecimalFixed("" + paramDouble));
		consumableTable.Project = "";
		consumableTable.Country = "US";
		consumableTable.StateProvince = "USA AVERAGE";
		consumableTable.Currency = "USD";
		consumableTable.Notes = "ACCT: " + paramString1;
		consumableTable.Description = paramString3 + ", SN: " + paramString5 + "\nPDF: " + acctToPDFLink(paramString1);
		consumableTable.LastUpdate = new Timestamp(paramDate.Time);
		consumableTable.CreateDate = new Timestamp(paramDate.Time);
		consumableTable.CreateUserId = "RichardsonDBReader";
		long? long = consumableTable.ConsumableId;
		if (long == null)
		{
		  long = (long?)paramSession.save(consumableTable);
		}
		else
		{
		  paramSession.update(consumableTable);
		}
		try
		{
		  consumableTable = (ConsumableTable)DatabaseDBUtil.loadBulk(typeof(ConsumableTable), new long?[] {long})[0];
		}
		catch (Exception exception)
		{
		  Console.WriteLine("Error when loading Material: " + exception.Message);
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		return consumableTable;
	  }

	  private EquipmentTable saveOrUpdateEquipmentTable(Session paramSession, string paramString1, string paramString2, string paramString3, double paramDouble, string paramString4, string paramString5, DateTime paramDate) throws Exception
	  {
		null = BlankResourceInitializer.createBlankEquipment(null);
		null.ItemCode = paramString1;
		null.Title = paramString2;
		null.Model = "";
		null.Make = "";
		null.Currency = "USD";
		null.GroupCode = "";
		null.GekCode = "";
		null.ExtraCode1 = "";
		null.ExtraCode2 = acctToGroupCode(paramSession, paramString1);
		null.ExtraCode3 = "";
		null.ExtraCode4 = "";
		null.ExtraCode5 = "";
		null.ExtraCode6 = "";
		null.ExtraCode7 = "";
		null.ExtraCode8 = "";
		null.ExtraCode9 = "";
		null.ExtraCode10 = "";
		null.Country = "US";
		null.StateProvince = "USA AVERAGE";
		null.EditorId = "richardson";
		string str = UOMConverter.convertImperialToMetricUnit(paramString4);
		if (string.ReferenceEquals(str, null))
		{
		  Console.WriteLine("FATAL: UNIT WAS NULL FOR " + paramString4 + ". AND ACCT " + paramString1);
		  Environment.Exit(0);
		}
		null.Unit = "HOUR";
		if (str.Equals("DAY"))
		{
		  paramDouble *= 0.125D;
		}
		else if (str.Equals("WEEK"))
		{
		  paramDouble *= 0.025D;
		}
		else if (str.Equals("MONTH"))
		{
		  paramDouble *= 0.00625D;
		}
		if (paramString3.ToLower().IndexOf("diesel", StringComparison.Ordinal) != -1)
		{
		  null.FuelType = "DIESEL";
		}
		else if (paramString3.ToLower().IndexOf("gas", StringComparison.Ordinal) != -1)
		{
		  null.FuelType = "PETROL";
		}
		else if (paramString3.ToLower().IndexOf("electric", StringComparison.Ordinal) != -1)
		{
		  null.FuelType = "ELECTRIC";
		}
		else
		{
		  null.FuelType = "OTHER";
		}
		null.DepreciationCalculationMethod = EquipmentTable.USER_DEFINED_METHOD;
		null.DepreciationYears = BigInteger.Parse("6");
		null.OccupationalFactor = new BigDecimalFixed("0.73");
		null.OccupationHoursPerMonth = new BigDecimalFixed("175.0");
		null.InitAquasitionPrice = BigDecimalMath.ZERO;
		null.InterestRate = new BigDecimalFixed("0.065");
		null.SalvageValue = BigDecimalMath.ZERO;
		null.LubricatesRate = BigDecimalMath.ZERO;
		null.TiresRate = BigDecimalMath.ZERO;
		null.FuelConsumption = BigDecimalMath.ZERO;
		null.SparePartsRate = BigDecimalMath.ZERO;
		null.ReservationRate = UOMConverter.convertImperialToMetricRate(paramString4, new BigDecimalFixed("" + paramDouble));
		null.DepreciationRate = BigDecimalMath.ZERO;
		null.FuelRate = BigDecimalMath.ZERO;
		null.TotalRate = UOMConverter.convertImperialToMetricRate(paramString4, new BigDecimalFixed("" + paramDouble));
		null.Notes = "ACCT: " + paramString1;
		null.Description = paramString3 + ", SN: " + paramString5 + "\nPDF: " + acctToPDFLink(paramString1);
		null.LastUpdate = new Timestamp(paramDate.Time);
		null.CreateDate = new Timestamp(paramDate.Time);
		null.CreateUserId = "RichardsonDBReader";
		long? long = null.EquipmentId;
		if (long == null)
		{
		  long = (long?)paramSession.save(null);
		}
		else
		{
		  paramSession.update(null);
		}
		return (EquipmentTable)DatabaseDBUtil.loadBulk(typeof(EquipmentTable), new long?[] {long})[0];
	  }

	  private string acctToPDFLink(string paramString)
	  {
		string str1 = "" + (new BigDecimalFixed(paramString.substring(0, 3))).longValue();
		string str2 = "" + (new BigDecimalFixed(paramString.substring(3, 3))).longValue();
		string str3 = this.PDF_PREFIX + str1 + "-" + str2;
		this.pdfLinkCache[str3] = str3;
		return str3;
	  }

	  private void loadDetailedIndexAsGroupCode(Connection paramConnection, Session paramSession) throws Exception
	  {
		string str = "select * from lineitems_detailed_index o order by o.acct";
		PreparedStatement preparedStatement = paramConnection.prepareStatement(str);
		ResultSet resultSet = preparedStatement.executeQuery();
		bool @bool = false;
		while (resultSet.next())
		{
		  string str1 = resultSet.getString(1);
		  string str2 = resultSet.getString(2);
		  string str3 = resultSet.getString(3);
		  string str4 = resultSet.getString(4);
		  ExtraCode2Table extraCode2Table = new ExtraCode2Table();
		  string str5 = str1.Substring(0, str1.Length - 3);
		  extraCode2Table.GroupCode = str5;
		  extraCode2Table.Title = str3;
		  extraCode2Table.Notes = str4;
		  extraCode2Table.Unit = "";
		  extraCode2Table.UnitFactor = BigDecimalMath.ONE;
		  extraCode2Table.Description = "";
		  extraCode2Table.LastUpdate = this.lastUpdate;
		  extraCode2Table.EditorId = "richardson";
		  string str6 = str1.Substring(0, str1.Length - 3);
		  this.gcCache[str6] = extraCode2Table.ToString();
		  paramSession.saveOrUpdate(extraCode2Table);
		  if (str2.Equals("1"))
		  {
			Console.WriteLine("INFO: Saving Codes for: " + extraCode2Table + " cache now is: " + this.gcCache.Count);
		  }
		}
		preparedStatement.close();
	  }

	  private string rapidTitleToGroupCode(Session paramSession, string paramString)
	  {
		if (paramString.IndexOf("LSS ") != -1)
		{
		  return (string)this.gcCache["015047000000"];
		}
		if (paramString.IndexOf("CS ") != -1)
		{
		  return (string)this.gcCache["015043000000"];
		}
		Console.WriteLine("WARN: Group Code not found for RAPID TITLE: " + paramString);
		return "";
	  }

	  private string acctToGroupCode(Session paramSession, string paramString)
	  {
		string str1 = paramString.substring(0, paramString.length() - 3);
		string str2 = (string)this.gcCache[str1];
		if (!string.ReferenceEquals(str2, null))
		{
		  return str2;
		}
		Console.WriteLine("NOT FOUND IN CACHE: " + str1 + " cache has size: " + this.gcCache.Count);
		System.Collections.IEnumerator iterator = paramSession.createQuery("from ExtraCode2Table o where o.groupCode like '" + str1 + "%'").list().GetEnumerator();
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
		if (iterator.hasNext())
		{
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
		  str2 = ((ExtraCode2Table)iterator.next()).ToString();
		  this.gcCache[str1] = str2;
		  return str2;
		}
		Console.WriteLine("WARN: Group Code not found for ACCT: " + paramString);
		return "";
	  }

	  public static void migrateFromMySQL(string paramString1, string paramString2, string paramString3, PrintWriter paramPrintWriter) throws Exception
	  {
		RichardsonMigrationUtil richardsonMigrationUtil = new RichardsonMigrationUtil(paramString1, paramString2, paramString3, paramPrintWriter);
		richardsonMigrationUtil.startMigration();
	  }
	  }


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\RichardsonMigrationUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
	}