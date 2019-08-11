using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop.common.nomitech.common.migration.datamove
{
	using UIProgress = nomitech.common.ui.UIProgress;
	using StringUtils = nomitech.common.util.StringUtils;
	using SQLQuery = org.hibernate.SQLQuery;
	using Session = org.hibernate.Session;
	using Column = org.hibernate.mapping.Column;
	using PersistentClass = org.hibernate.mapping.PersistentClass;
	using Property = org.hibernate.mapping.Property;
	using CustomType = org.hibernate.type.CustomType;

	public class ProjectDBCEPDataMover
	{
	  private IList<string> SORT_TABLE_ORDER = Arrays.asList(new string[] {"WSDATAMAPPING", "WSCOLIDENT", "WSREVISION", "WSFILE", "PARAMITEM", "BOQITEM", "ASSEMBLY", "EQUIPMENT", "SUBCONTRACTOR", "LABOR", "SUPPLIER", "MATERIAL", "CONSUMABLE", "CNDON", "QUOTE", "XCELLFILE", "PROJECTTEMPLATE", "QUOTEITEM", "BOQITEM_ASSEMBLY", "BOQITEM_EQUIPMENT", "BOQITEM_SUBCONTRACTOR", "BOQITEM_LABOR", "BOQITEM_MATERIAL", "BOQITEM_CONSUMABLE", "BOQITEM_CONDITION", "ASSEMBLY_CHILD", "ASSEMBLY_EQUIPMENT", "ASSEMBLY_SUBCONTRACTOR", "ASSEMBLY_LABOR", "ASSEMBLY_MATERIAL", "ASSEMBLY_CONSUMABLE", "PARAMOUTPUT", "PARAMINPUT", "PARAMCONDITION", "CONCEPTUALS", "QUERYRESOURCE", "QUERYROW", "LOCPROF", "LOCFACTOR", "LAYOUTC", "LAYOUTCPANEL", "PROJECTEPS", "PROJECTINFO", "PROJECTURL", "FILTRO", "FILTROPROPERTY", "IFCELEMENT", "IFCPROPERTY", "TAKEOFFCON", "TAKEOFFAREA", "TAKEOFFLINE", "TAKEOFFPOINT", "TAKEOFFLEGEND"});

	  private UIProgress progress;

	  private ProjectDBUtil source;

	  private ProjectDBUtil dest;

	  private Connection sourceConnection;

	  private Connection destConnection;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public ProjectDBCEPDataMover(nomitech.common.ui.UIProgress paramUIProgress, nomitech.common.ProjectDBUtil paramProjectDBUtil1, nomitech.common.ProjectDBUtil paramProjectDBUtil2) throws Exception
	  public ProjectDBCEPDataMover(UIProgress paramUIProgress, ProjectDBUtil paramProjectDBUtil1, ProjectDBUtil paramProjectDBUtil2)
	  {
		this.progress = paramUIProgress;
		this.source = paramProjectDBUtil1;
		this.dest = paramProjectDBUtil2;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void initialize() throws Exception
	  private void initialize()
	  {
		this.progress.Indeterminate = true;
		this.progress.Progress = "Loading Source Database";
		if (!this.source.DBLoaded)
		{
		  this.source.loadDB();
		  this.source.unloadDB();
		}
		this.progress.Progress = "Loading Destination Database";
		if (!this.dest.DBLoaded)
		{
		  this.dest.loadDB();
		  this.dest.unloadDB();
		}
		this.sourceConnection = this.source.createJdbcConnection();
		this.destConnection = this.dest.createJdbcConnection();
		executeUpdateQuery(this.destConnection, "DELETE FROM PRJPROP");
		executeUpdateQuery(this.destConnection, "DELETE FROM PRJUSERPROP");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void cleanUp() throws Exception
	  private void cleanUp()
	  {
		this.progress.Indeterminate = true;
		this.progress.Progress = "Storing data...";
		try
		{
		  this.sourceConnection.close();
		}
		catch (Exception)
		{
		}
		try
		{
		  this.destConnection.close();
		}
		catch (Exception)
		{
		}
	  }

	  private string constructInsertPrefixForTable(ProjectDBUtil paramProjectDBUtil, string paramString)
	  {
		  return (paramProjectDBUtil.CollaborationMode && paramProjectDBUtil.Configuration.getProperty("hibernate.connection.url").StartsWith("jdbc:jtds:")) ? ("SET IDENTITY_INSERT " + paramString + " ON ") : "";
	  }

	  private string constructInsertSuffixForTable(ProjectDBUtil paramProjectDBUtil, string paramString)
	  {
		  return (paramProjectDBUtil.CollaborationMode && paramProjectDBUtil.Configuration.getProperty("hibernate.connection.url").StartsWith("jdbc:jtds:")) ? (" SET IDENTITY_INSERT " + paramString + " OFF") : "";
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void moveClassData() throws Exception
	  private void moveClassData()
	  {
		initialize();
		copyClassData();
		cleanUp();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void backUpAndRestore() throws Exception
	  private void backUpAndRestore()
	  {
		string str1 = ((ProjectServerDBUtil)this.source).ProjectUrl.DatabaseName;
		string str2 = ((ProjectServerDBUtil)this.dest).ProjectUrl.DatabaseName;
		string str3 = null;
		string str4 = null;
		this.dest.closeProject();
		this.dest.closeSession();
		this.progress.TotalTimes = 7;
		this.progress.Progress = "Backing up " + str1 + " to " + str2;
		Console.WriteLine("STARTED BACKUP [" + str2 + "] RESTORE TO [" + str1 + "]");
		Session session = DatabaseDBUtil.currentSession();
		try
		{
		  string str5 = stringFromQuery(session, "select physical_name from " + str1 + ".sys.database_files where physical_name not like '%.ldf'");
		  Console.WriteLine("  SOURCE DATABASE FILE: " + str5);
		  if (StringUtils.isNullOrBlank(str5))
		  {
			throw new System.InvalidOperationException("Null database file for: " + str1);
		  }
		  this.progress.incrementProgress(1);
		  DatabaseDBUtil.closeSession();
		  executeUpdate(DatabaseDBUtil.currentSession(), "ALTER DATABASE " + str2 + " MODIFY NAME = " + str2 + "tmp");
		  DatabaseDBUtil.closeSession();
		  session = DatabaseDBUtil.currentSession();
		  str3 = str2 + "tmp";
		  Console.WriteLine("  RENAMED DESTINATION TEMPORARILY FROM " + str2 + " TO: " + str3);
		  this.progress.incrementProgress(1);
		  string str6 = str5.Substring(0, str5.LastIndexOf("\\", StringComparison.Ordinal));
		  string str7 = str6 + "\\" + str1 + ".bak";
		  executeUpdate(session, "BACKUP DATABASE " + str1 + " TO DISK = '" + str7 + "' WITH COPY_ONLY");
		  str4 = str7;
		  Console.WriteLine("  BACKED UP " + str1 + " TO FILE: " + str7);
		  this.progress.incrementProgress(1);
		  System.Collections.IList list = session.createSQLQuery("RESTORE FILELISTONLY FROM DISK = '" + str7 + "'").list();
		  string str8 = null;
		  string str9 = null;
		  foreach (object[] arrayOfObject in list)
		  {
			string str12 = arrayOfObject[0].ToString();
			string str13 = arrayOfObject[2].ToString();
			if (string.ReferenceEquals(str8, null) && str13.Equals("D"))
			{
			  str8 = str12;
			  continue;
			}
			if (string.ReferenceEquals(str9, null) && str13.Equals("L"))
			{
			  str9 = str12;
			}
		  }
		  if (string.ReferenceEquals(str8, null))
		  {
			throw new Exception("No DATA file found in backup: " + str7);
		  }
		  if (string.ReferenceEquals(str9, null))
		  {
			throw new Exception("No LOG file found in backup: " + str7);
		  }
		  this.progress.incrementProgress(1);
		  string str10 = str6 + "\\" + str2;
		  str10 = StringUtils.replaceAll(str10, "cep_", "cep_b");
		  string str11 = "RESTORE DATABASE " + str2 + " FROM DISK = '" + str7 + "' WITH MOVE '" + str8 + "' TO '" + str10 + ".mdf', MOVE '" + str9 + "' TO '" + str10 + ".ldf'";
		  this.progress.Progress = "Restoring to " + str2;
		  executeUpdate(session, str11);
		  Console.WriteLine("  RESTORED FILE " + str7 + " TO DATABASE: " + str2);
		  this.progress.incrementProgress(1);
		  try
		  {
			executeUpdate(session, "IF DB_ID('" + str3 + "') IS NOT NULL BEGIN DROP DATABASE [" + str3 + "]; END");
			Console.WriteLine("  DROPPED TEMPORARY DATABASE " + str3);
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine("WARN: FAILED TO DROP DATABASE: " + str3);
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  this.progress.incrementProgress(1);
		  try
		  {
			executeUpdate(session, "EXECUTE master.dbo.xp_delete_file 0,N'" + str4 + "'");
			Console.WriteLine("  DELETED BACKUP: " + str4);
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine("WARN: FAILED TO DELETE BACKUP: " + str4);
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  this.progress.incrementProgress(1);
		  Console.WriteLine("SUCCESS");
		}
		catch (Exception exception)
		{
		  this.progress.Indeterminate = true;
		  Console.WriteLine("FAILED: " + exception.Message);
		  try
		  {
			if (!string.ReferenceEquals(str3, null))
			{
			  executeUpdate(session, "ALTER DATABASE " + str3 + " MODIFY NAME = " + str2);
			}
		  }
		  catch (Exception exception1)
		  {
			Console.WriteLine("WARN: FAILED TO ALTER DATABASE: " + str3);
			Console.WriteLine(exception1.ToString());
			Console.Write(exception1.StackTrace);
		  }
		  try
		  {
			if (!string.ReferenceEquals(str4, null))
			{
			  executeUpdate(session, "EXECUTE master.dbo.xp_delete_file 0,N'" + str4 + "'");
			}
		  }
		  catch (Exception exception1)
		  {
			Console.WriteLine("WARN: FAILED TO DELETE BACKUP: " + str4);
			Console.WriteLine(exception1.ToString());
			Console.Write(exception1.StackTrace);
		  }
		  DatabaseDBUtil.closeSession();
		  throw exception;
		}
		this.progress.Indeterminate = true;
		DatabaseDBUtil.closeSession();
	  }

	  private void executeUpdate(Session paramSession, string paramString)
	  {
		this.progress.Indeterminate = true;
		paramSession.createSQLQuery(paramString).executeUpdate();
		this.progress.Indeterminate = false;
	  }

	  private string stringFromQuery(Session paramSession, string paramString)
	  {
		SQLQuery sQLQuery = paramSession.createSQLQuery(paramString);
		System.Collections.IList list = sQLQuery.list();
		return (list.Count == 0) ? null : (string)list.GetEnumerator().next();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void copyClassData() throws Exception
	  private void copyClassData()
	  {
		this.progress.Indeterminate = true;
		this.progress.Progress = "Copying tables...";
		System.Collections.IList list = this.source.listClasses();
		list = sortClasses(list);
		foreach (PersistentClass persistentClass in list)
		{
		  if (persistentClass.Table.Name.EndsWith("View"))
		  {
			continue;
		  }
		  this.progress.Progress = "Copying Table " + persistentClass.Table.Name + "...";
		  try
		  {
			copyTable(persistentClass);
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
			throw exception;
		  }
		  this.progress.Indeterminate = true;
		}
	  }

	  private IList<PersistentClass> sortClasses(IList<PersistentClass> paramList)
	  {
		List<object> arrayList = new List<object>();
		foreach (string str in this.SORT_TABLE_ORDER)
		{
		  PersistentClass persistentClass = findClass(paramList, str);
		  if (persistentClass == null)
		  {
			continue;
		  }
		  arrayList.Add(persistentClass);
		  paramList.Remove(persistentClass);
		}
		foreach (PersistentClass persistentClass in paramList)
		{
		  arrayList.Add(persistentClass);
		}
		return arrayList;
	  }

	  private PersistentClass findClass(IList<PersistentClass> paramList, string paramString)
	  {
		foreach (PersistentClass persistentClass in paramList)
		{
		  if (persistentClass.Table.Name.ToUpper().Equals(paramString))
		  {
			return persistentClass;
		  }
		}
		Console.WriteLine("COULD NOT FIND: " + paramString);
		return null;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private java.sql.PreparedStatement prepareStatement(java.sql.Connection paramConnection, String paramString) throws Exception
	  private PreparedStatement prepareStatement(Connection paramConnection, string paramString)
	  {
		PreparedStatement preparedStatement = null;
		try
		{
		  preparedStatement = paramConnection.prepareStatement(paramString);
		}
		catch (SQLException sQLException)
		{
		  throw new Exception(sQLException);
		}
		return preparedStatement;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private java.sql.ResultSet executeResultSetQuery(java.sql.Connection paramConnection, String paramString) throws Exception
	  private ResultSet executeResultSetQuery(Connection paramConnection, string paramString)
	  {
		Statement statement = null;
		try
		{
		  statement = paramConnection.createStatement();
		  return statement.executeQuery(paramString);
		}
		catch (SQLException sQLException)
		{
		  throw new Exception(sQLException);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private boolean executeUpdateQuery(java.sql.Connection paramConnection, String paramString) throws Exception
	  private bool executeUpdateQuery(Connection paramConnection, string paramString)
	  {
		Statement statement = null;
		try
		{
		  statement = paramConnection.createStatement();
		  statement.executeUpdate(paramString);
		  return true;
		}
		catch (SQLException sQLException)
		{
		  throw new Exception(sQLException);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void copyTable(org.hibernate.mapping.PersistentClass paramPersistentClass) throws Exception
	  private void copyTable(PersistentClass paramPersistentClass)
	  {
		string str = paramPersistentClass.Table.Name;
		StringBuilder stringBuffer1 = new StringBuilder();
		StringBuilder stringBuffer2 = new StringBuilder();
		StringBuilder stringBuffer3 = new StringBuilder();
		System.Collections.IList list1 = this.source.listPropertyColumns(paramPersistentClass);
		System.Collections.IList list2 = this.source.listNonPropertyColumns(paramPersistentClass);
		System.Collections.IList list3 = this.source.listProperties(paramPersistentClass);
		System.Collections.IList list4 = this.source.listAllColumns(paramPersistentClass);
		stringBuffer1.Append("SELECT ");
		stringBuffer2.Append("INSERT INTO ");
		stringBuffer2.Append(str);
		stringBuffer2.Append("(");
		bool @bool = true;
		sbyte b = 1;
		HashSet<object> hashSet = new HashSet<object>();
		foreach (Column column in list4)
		{
		  string str1 = column.Name;
		  if (hashSet.Contains(str1))
		  {
			continue;
		  }
		  hashSet.Add(str1);
		  if (!@bool)
		  {
			stringBuffer1.Append(",");
			stringBuffer2.Append(",");
			stringBuffer3.Append(",");
		  }
		  else
		  {
			@bool = false;
		  }
		  stringBuffer1.Append(str1);
		  stringBuffer2.Append(str1);
		  stringBuffer3.Append("?");
		  b++;
		}
		stringBuffer1.Append(" FROM ");
		stringBuffer1.Append(str);
		stringBuffer2.Append(") VALUES (");
		stringBuffer2.Append(stringBuffer3);
		stringBuffer2.Append(")");
		preparedStatement = null;
		resultSet = null;
		try
		{
		  str1 = "select count(" + ((Column)list1[0]).Name + ") from " + str;
		  resultSet = executeResultSetQuery(this.sourceConnection, str1);
		  int i;
		  for (i = 0; resultSet.next(); i = resultSet.getInt(1))
		  {
			  ;
		  }
		  resultSet.close();
		  this.progress.Indeterminate = false;
		  this.progress.setProgress("Storing [" + str + "] data...", 0);
		  this.progress.TotalTimes = i;
		  preparedStatement = prepareStatement(this.destConnection, constructInsertPrefixForTable(this.dest, str) + stringBuffer2.ToString() + constructInsertSuffixForTable(this.dest, str));
		  resultSet = executeResultSetQuery(this.sourceConnection, stringBuffer1.ToString());
		  sbyte b1 = 0;
		  while (resultSet.next())
		  {
			b1++;
			int j;
			for (j = 1; j <= list1.Count; j++)
			{
			  Property property = (Property)list3[j - true];
			  if (property.Type is org.hibernate.type.BigDecimalType)
			  {
				preparedStatement.setBigDecimal(j, resultSet.getBigDecimal(j));
			  }
			  else if (property.Type is org.hibernate.type.BigIntegerType)
			  {
				preparedStatement.setBigDecimal(j, resultSet.getBigDecimal(j));
			  }
			  else if (property.Type is org.hibernate.type.LongType)
			  {
				preparedStatement.setBigDecimal(j, resultSet.getBigDecimal(j));
			  }
			  else if (property.Type is org.hibernate.type.BooleanType)
			  {
				preparedStatement.setBoolean(j, resultSet.getBoolean(j));
			  }
			  else if (property.Type is org.hibernate.type.DoubleType)
			  {
				preparedStatement.setBigDecimal(j, resultSet.getBigDecimal(j));
			  }
			  else if (property.Type is org.hibernate.type.IntegerType)
			  {
				preparedStatement.setBigDecimal(j, resultSet.getBigDecimal(j));
			  }
			  else if (property.Type is org.hibernate.type.TimestampType)
			  {
				preparedStatement.setTimestamp(j, resultSet.getTimestamp(j));
			  }
			  else if (property.Type is org.hibernate.type.DateType)
			  {
				preparedStatement.setDate(j, resultSet.getDate(j));
			  }
			  else if (property.Type is org.hibernate.type.BlobType)
			  {
				preparedStatement.setBlob(j, resultSet.getBlob(j));
			  }
			  else if (property.Type is org.hibernate.type.BinaryType)
			  {
				preparedStatement.setBytes(j, resultSet.getBytes(j));
			  }
			  else if (property.Type is nomitech.common.db.types.CostOSTextType)
			  {
				preparedStatement.setClob(j, resultSet.getClob(j));
			  }
			  else if (property.Type is nomitech.common.db.types.CostOSStringType)
			  {
				preparedStatement.setString(j, resultSet.getString(j));
			  }
			  else if (property.Type is CustomType)
			  {
				CustomType customType = (CustomType)property.Type;
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
				if (customType.Name.Equals(typeof(nomitech.common.db.types.NotNullTextType).FullName))
				{
				  preparedStatement.setClob(j, resultSet.getClob(j));
				}
				else
				{
				  string str2 = resultSet.getString(j);
				  if (!string.ReferenceEquals(str2, null) && str2.Length >= 255)
				  {
					str2 = str2.Substring(0, 254);
				  }
				  preparedStatement.setString(j, str2);
				}
			  }
			  else
			  {
				string str2 = resultSet.getString(j);
				if (!string.ReferenceEquals(str2, null) && str2.Length >= 255)
				{
				  str2 = str2.Substring(0, 254);
				}
				preparedStatement.setString(j, str2);
			  }
			}
			for (j = 1; j <= list2.Count; j++)
			{
			  int k = list1.Count + j;
			  Column column = (Column)list2[j - 1];
			  preparedStatement.setBigDecimal(k, resultSet.getBigDecimal(k));
			}
			preparedStatement.execute();
			this.progress.incrementProgress(1);
		  }
		}
		catch (SQLException sQLException)
		{
		  Console.WriteLine(sQLException.ToString());
		  Console.Write(sQLException.StackTrace);
		  throw new Exception(sQLException);
		}
		finally
		{
		  try
		  {
			if (preparedStatement != null)
			{
			  preparedStatement.close();
			}
		  }
		  catch (SQLException sQLException)
		  {
			throw new Exception(sQLException);
		  }
		  try
		  {
			if (resultSet != null)
			{
			  resultSet.close();
			}
		  }
		  catch (SQLException sQLException)
		  {
			throw new Exception(sQLException);
		  }
		}
		this.progress.Indeterminate = true;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void moveData(nomitech.common.ui.UIProgress paramUIProgress, nomitech.common.ProjectDBUtil paramProjectDBUtil1, nomitech.common.ProjectDBUtil paramProjectDBUtil2) throws Exception
	  public static void moveData(UIProgress paramUIProgress, ProjectDBUtil paramProjectDBUtil1, ProjectDBUtil paramProjectDBUtil2)
	  {
		ProjectDBCEPDataMover projectDBCEPDataMover = new ProjectDBCEPDataMover(paramUIProgress, paramProjectDBUtil1, paramProjectDBUtil2);
		projectDBCEPDataMover.moveClassData();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void moveDataBackUpRestore(nomitech.common.ui.UIProgress paramUIProgress, nomitech.common.ProjectDBUtil paramProjectDBUtil1, nomitech.common.ProjectDBUtil paramProjectDBUtil2) throws Exception
	  public static void moveDataBackUpRestore(UIProgress paramUIProgress, ProjectDBUtil paramProjectDBUtil1, ProjectDBUtil paramProjectDBUtil2)
	  {
		ProjectDBCEPDataMover projectDBCEPDataMover = new ProjectDBCEPDataMover(paramUIProgress, paramProjectDBUtil1, paramProjectDBUtil2);
		try
		{
		  projectDBCEPDataMover.backUpAndRestore();
		}
		catch (Exception exception)
		{
		  Console.WriteLine("COULD NOT MOVE DATA USING BACKUP / RESTORE");
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw exception;
		}
	  }

	  internal class HelpFilePojo
	  {
		  private readonly ProjectDBCEPDataMover outerInstance;

		  public HelpFilePojo(ProjectDBCEPDataMover outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		internal string name = "";

		internal string fileid = "";

		internal string filename = "";

		internal string filegroup = "";

		internal string size = "";

		internal string maxsize = "";

		internal string growth = "";

		internal string usage = "";

		public virtual string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}


		public virtual string Fileid
		{
			get
			{
				return this.fileid;
			}
			set
			{
				this.fileid = value;
			}
		}


		public virtual string Filename
		{
			get
			{
				return this.filename;
			}
			set
			{
				this.filename = value;
			}
		}


		public virtual string Filegroup
		{
			get
			{
				return this.filegroup;
			}
			set
			{
				this.filegroup = value;
			}
		}


		public virtual string Size
		{
			get
			{
				return this.size;
			}
			set
			{
				this.size = value;
			}
		}


		public virtual string Maxsize
		{
			get
			{
				return this.maxsize;
			}
			set
			{
				this.maxsize = value;
			}
		}


		public virtual string Growth
		{
			get
			{
				return this.growth;
			}
			set
			{
				this.growth = value;
			}
		}


		public virtual string Usage
		{
			get
			{
				return this.usage;
			}
			set
			{
				this.usage = value;
			}
		}

	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\datamove\ProjectDBCEPDataMover.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}