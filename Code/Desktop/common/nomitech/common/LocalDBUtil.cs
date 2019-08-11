using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace Desktop.common.nomitech.common
{
	using MysqldResource = com.mysql.management.MysqldResource;
	using BaseDBProperties = Desktop.common.nomitech.common.@base.BaseDBProperties;
	using BaseDBUtil = Desktop.common.nomitech.common.@base.BaseDBUtil;
	using BaseTable = Desktop.common.nomitech.common.@base.BaseTable;
	using GroupCodesProvider = Desktop.common.nomitech.common.@base.GroupCodesProvider;
	using LayoutPanelTable = Models.layout.LayoutPanelTable;
	using LayoutTable = Models.layout.LayoutTable;
	using AssemblyTable = Models.local.AssemblyTable;
	using FileDefinitionTable = Models.local.FileDefinitionTable;
	using FilterPropertyTable = Models.local.FilterPropertyTable;
	using FilterTable = Models.local.FilterTable;
	using FunctionArgumentTable = Models.local.FunctionArgumentTable;
	using FunctionTable = Models.local.FunctionTable;
	using LocalizationFactorTable = Models.local.LocalizationFactorTable;
	using LocalizationProfileTable = Models.local.LocalizationProfileTable;
	using MaterialTable = Models.local.MaterialTable;
	using ParamItemConceptualResourceTable = Models.local.ParamItemConceptualResourceTable;
	using ParamItemInputTable = Models.local.ParamItemInputTable;
	using ParamItemOutputTable = Models.local.ParamItemOutputTable;
	using ParamItemQueryResourceTable = Models.local.ParamItemQueryResourceTable;
	using ParamItemTable = Models.local.ParamItemTable;
	using ProjectEPSTable = Models.local.ProjectEPSTable;
	using ProjectInfoTable = Models.local.ProjectInfoTable;
	using ProjectUrlTable = Models.local.ProjectUrlTable;
	using ProjectUserTable = Models.local.ProjectUserTable;
	using ProjectWBS2Table = Models.local.ProjectWBS2Table;
	using ProjectWBSTable = Models.local.ProjectWBSTable;
	using ReportDefinitionTable = Models.local.ReportDefinitionTable;
	using SupplierTable = Models.local.SupplierTable;
	using TakeoffAreaTable = Models.local.TakeoffAreaTable;
	using TakeoffConditionTable = Models.local.TakeoffConditionTable;
	using TakeoffLegendTable = Models.local.TakeoffLegendTable;
	using TakeoffLineTable = Models.local.TakeoffLineTable;
	using TakeoffPointTable = Models.local.TakeoffPointTable;
	using TakeoffTriangleTable = Models.local.TakeoffTriangleTable;
	using ProjectExcelFile = Models.proj.ProjectExcelFile;
	using ProjectTemplateTable = Models.proj.ProjectTemplateTable;
	using ProjectVariableTable = Models.proj.ProjectVariableTable;
	using RateBuildUpColumnsTable = Models.proj.RateBuildUpColumnsTable;
	using RateBuildUpTable = Models.proj.RateBuildUpTable;
	using RateDistributorTable = Models.proj.RateDistributorTable;
	using CostOSString256Type = Models.types.CostOSString256Type;
	using CostOSTextType = Models.types.CostOSTextType;
	using GroupCodeType = Models.types.GroupCodeType;
	using UnitAliasType = Models.types.UnitAliasType;
	using HqlParameterWithValue = Models.util.HqlParameterWithValue;
	using HqlResultValue = Models.util.HqlResultValue;
	using LocalDBConnectionPool = Desktop.common.nomitech.common.search.store.LocalDBConnectionPool;
	using IconUploadUtil = Desktop.common.nomitech.common.util.IconUploadUtil;
	using ProgressCallback = Desktop.common.nomitech.common.util.ProgressCallback;
	using ZipUtil = Desktop.common.nomitech.common.util.ZipUtil;
	using Analyzer = org.apache.lucene.analysis.Analyzer;
	using MultiFieldQueryParser = org.apache.lucene.queryParser.MultiFieldQueryParser;
	using Query = org.apache.lucene.search.Query;
	using Sort = org.apache.lucene.search.Sort;
	using SortField = org.apache.lucene.search.SortField;
	using Version = org.apache.lucene.util.Version;
	using HibernateException = org.hibernate.HibernateException;
	using Query = org.hibernate.Query;
	using Session = org.hibernate.Session;
	using SessionFactory = org.hibernate.SessionFactory;
	using Configuration = org.hibernate.cfg.Configuration;
	using Dialect = org.hibernate.dialect.Dialect;
	using SessionFactoryImplementor = org.hibernate.engine.SessionFactoryImplementor;
	using FullTextQuery = org.hibernate.search.FullTextQuery;
	using FullTextSession = org.hibernate.search.FullTextSession;
	using Search = org.hibernate.search.Search;

	public class LocalDBUtil : BaseDBUtil
	{
	  public const string UNKNOWN_FILE = "[OLD PROJECT - UNKNOWN URL/FILE]";

	  public const int ApplicationSQLServer = 0;

	  public const int SQLServer = 1;

	  public const int MYSQL = 2;

	  public const int MYSQLEmbedded = 3;

	  private const string databaseName = "CostOS";

	  private const string instanceName = "COESTIMSQL";

	  private string o_dbHost;

	  private string o_dbPort;

	  private string o_dbName;

	  private static LocalDBUtil s_instance = null;

	  public const string SORTED_SUFFIX = "_sorted";

	  public const string ID_SUFFIX = "Id";

	  private const string DEFAULT_DB_PROPERTIES_FILE_NAME = "data/localDB.info";

	  private const string ICON_DB_FOLDER = "data/icons/";

	  private SessionFactory sessionFactory = null;

	  private ThreadLocal session = null;

	  private URL configXML = null;

	  private Configuration configuration = null;

	  private string installDir = "./";

	  private string propertiesFileName = "data/localDB.info";

	  private bool madeProperties = true;

	  private string s_prevUsername = null;

	  private string s_prevPassword = null;

	  private string s_hostName = null;

	  private bool s_driverLoaded = false;

	  private int s_connectionType;

	  private GroupCodesProvider groupCodeProvider;

	  private MysqldResource mysqldResource;

	  private LocalDBProperties o_properties;

	  private LocalDBUtil()
	  {
		  this.o_properties = new LocalDBProperties(this.installDir + "data/localDB.info");
	  }

	  private LocalDBUtil(string paramString)
	  {
		this.installDir = paramString;
		this.propertiesFileName = "data/localDB.info";
		this.o_properties = new LocalDBProperties(paramString + this.propertiesFileName);
	  }

	  private LocalDBUtil(string paramString1, string paramString2)
	  {
		this.installDir = paramString1;
		this.propertiesFileName = paramString2;
		this.o_properties = new LocalDBProperties(paramString1 + paramString2);
	  }

	  public virtual void updateSchema()
	  {
		if (this.o_properties.LoadedFromServer)
		{
		  return;
		}
		string str = this.o_properties.getProperty("database.schema.version");
		if (string.ReferenceEquals(str, null))
		{
		  str = "1.0.0";
		}
		SchemaUpdateUtil.updateSchema(this.o_properties, str, new SessionInterfaceAnonymousInnerClass(this));
	  }

	  private class SessionInterfaceAnonymousInnerClass : SessionInterface
	  {
		  private readonly LocalDBUtil outerInstance;

		  public SessionInterfaceAnonymousInnerClass(LocalDBUtil outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.hibernate.Session currentSession() throws org.hibernate.HibernateException
		  public Session currentSession()
		  {
			  return outerInstance.currentSession();
		  }

		  public void closeSession()
		  {
			  outerInstance.closeSession();
		  }

		  public Configuration Configuration
		  {
			  get
			  {
				  return outerInstance.Configuration;
			  }
		  }

		  public Dialect Dialect
		  {
			  get
			  {
				  return ((SessionFactoryImplementor)outerInstance.SessionFactory).Dialect;
			  }
		  }

		  public Connection Connection
		  {
			  get
			  {
				  return null;
			  }
		  }
	  }

	  public virtual string InstallDirectory
	  {
		  set
		  {
			  this.installDir = value;
		  }
	  }

	  private SessionFactory SessionFactory
	  {
		  get
		  {
			if (this.sessionFactory == null)
			{
			  try
			  {
				this.configuration = (new Configuration()).configure();
				this.sessionFactory = this.configuration.buildSessionFactory();
			  }
			  catch (Exception throwable)
			  {
				Console.Error.WriteLine("Initial SessionFactory creation failed." + throwable);
			  }
			}
			return this.sessionFactory;
		  }
	  }

	  private ThreadLocal Session
	  {
		  get
		  {
			if (this.session == null)
			{
			  this.session = new ThreadLocal();
			}
			return this.session;
		  }
	  }

	  public virtual Configuration Configuration
	  {
		  get
		  {
			  return this.configuration;
		  }
	  }

	  public virtual void loadDriver()
	  {
		if (this.s_driverLoaded)
		{
		  return;
		}
		try
		{
		  if (this.s_connectionType == 2 || this.s_connectionType == 3)
		  {
			Type.GetType("org.mariadb.jdbc.Driver");
		  }
		  else
		  {
			Type.GetType("net.sourceforge.jtds.jdbc.Driver");
		  }
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  this.s_driverLoaded = false;
		}
		this.s_driverLoaded = true;
	  }

	  private string DatabaseURL
	  {
		  get
		  {
			  return (this.s_connectionType == 3) ? "jdbc:mysql://127.0.0.1:5732/localDB?createDatabaseIfNotExist=true&useUnicode=true&characterEncoding=utf8" : ((this.s_connectionType == 2) ? ("jdbc:mysql://" + this.o_dbHost + ":" + this.o_dbPort + "/" + this.o_dbName + "?createDatabaseIfNotExist=false&useUnicode=true&characterEncoding=utf8") : ((this.s_connectionType == 1) ? ("jdbc:jtds:sqlserver://" + this.o_dbHost + ":" + this.o_dbPort + ";databaseName=" + this.o_dbName) : ((this.s_connectionType == 0) ? "jdbc:jtds:sqlserver://127.0.0.1/CostOS;instance=COESTIMSQL" : null)));
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void testAuthorizedUser(String paramString1, String paramString2, String paramString3, String paramString4) throws Exception
	  public virtual void testAuthorizedUser(string paramString1, string paramString2, string paramString3, string paramString4)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public boolean testAuthorizedUser(String paramString1, String paramString2) throws Exception
	  public virtual bool testAuthorizedUser(string paramString1, string paramString2)
	  {
		bool @bool = true;
		if (this.mysqldResource == null)
		{
		  startMySQL();
		}
		loadDriver();
		Properties properties = new Properties();
		properties.setProperty("user", paramString1);
		properties.setProperty("password", paramString2);
		Connection connection = null;
		try
		{
		  connection = DriverManager.getConnection(DatabaseURL, properties);
		  connection.close();
		}
		catch (Exception exception)
		{
		  if (connection != null)
		  {
			connection.close();
		  }
		  @bool = false;
		  throw exception;
		}
		return @bool;
	  }

	  public virtual void notifyDataChanged(BaseTable paramBaseTable)
	  {
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void changePassword(String paramString1, String paramString2, String paramString3) throws Exception
	  public virtual void changePassword(string paramString1, string paramString2, string paramString3)
	  {
		Properties properties = new Properties();
		properties.setProperty("user", paramString1);
		properties.setProperty("password", paramString2);
		Connection connection = DriverManager.getConnection(DatabaseURL, properties);
		PreparedStatement preparedStatement = connection.prepareStatement("SET PASSWORD FOR " + paramString1 + "@localhost=PASSWORD(?)");
		preparedStatement.setObject(1, paramString3);
		preparedStatement.execute();
		preparedStatement.close();
		connection.close();
		Properties.setEncProperty("database.username", paramString1);
		Properties.setEncProperty("database.password", paramString3);
		this.s_prevUsername = paramString1;
		this.s_prevPassword = paramString3;
	  }

	  private void stopMySQL()
	  {
		if (this.s_connectionType == 3)
		{
		  if (this.mysqldResource == null)
		  {
			return;
		  }
		  this.mysqldResource.shutdown();
		  this.mysqldResource = null;
		}
	  }

	  private void startMySQL()
	  {
		if (this.s_connectionType == 3)
		{
		  if (this.mysqldResource != null)
		  {
			return;
		  }
		  File file = new File(this.installDir + "data");
		  this.mysqldResource = new MysqldResource(file);
		  if (this.mysqldResource.Running)
		  {
			Console.WriteLine("MySQL was already running.");
			return;
		  }
		  Hashtable hashMap = new Hashtable();
		  hashMap["port"] = this.o_dbPort;
		  hashMap["key_buffer"] = "32M";
		  hashMap["max_allowed_packet"] = "128M";
		  this.mysqldResource.start("costos-mysqld-thread", hashMap);
		  if (!this.mysqldResource.Running)
		  {
			throw new Exception("MySQL did not start.");
		  }
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void loadDB(Desktop.common.nomitech.common.base.GroupCodesProvider paramGroupCodesProvider, String paramString1, String paramString2, boolean paramBoolean) throws Exception
	  public virtual void loadDB(GroupCodesProvider paramGroupCodesProvider, string paramString1, string paramString2, bool paramBoolean)
	  {
		loadDriver();
		startMySQL();
		this.groupCodeProvider = paramGroupCodesProvider;
		this.configXML = this.GetType().getResource("localDB.xml");
		closeSession();
		this.configuration = (new Configuration()).configure(this.configXML);
		if (this.s_connectionType == 2 || this.s_connectionType == 3)
		{
		  this.configuration.setProperty("hibernate.connection.driver_class", "org.mariadb.jdbc.Driver");
		}
		else
		{
		  this.configuration.setProperty("hibernate.connection.driver_class", "net.sourceforge.jtds.jdbc.Driver");
		  this.configuration.setProperty("hibernate.dialect", "org.hibernate.dialect.SQLServerDialect");
		}
		this.configuration.setProperty("hibernate.connection.username", paramString1);
		this.configuration.setProperty("hibernate.connection.password", paramString2);
		this.configuration.setProperty("hibernate.connection.url", DatabaseURL);
		this.configuration.setProperty("hibernate.search.default.jdbc_url", DatabaseURL);
		this.configuration.setProperty("hibernate.search.default.jdbc_username", paramString1);
		this.configuration.setProperty("hibernate.search.default.jdbc_password", paramString2);
		this.configuration.setProperty("hibernate.connection.isolation", "1");
		this.configuration.setProperty("hibernate.temp.use_jdbc_metadata_defaults", "false");
		this.configuration.setProperty("hibernate.cache.jdbc.batch_size", "50");
		this.configuration.setProperty("hibernate.cache.use_second_level_cache", "false");
		this.configuration.setProperty("hibernate.cache.use_query_cache", "false");
		this.configuration.setProperty("hibernate.cache.provider_class", "org.hibernate.cache.NoCacheProvider");
		this.configuration.registerTypeOverride(new CostOSString256Type(), new string[] {"costos_string"});
		this.configuration.registerTypeOverride(new CostOSTextType());
		this.configuration.registerTypeOverride(new UnitAliasType(this.groupCodeProvider, "unit_alias"));
		for (sbyte b = 1; b <= 9; b++)
		{
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)10, b, "eps_level" + b + "_code", (short)2));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)-1, b, "wbs1_level" + b + "_code", (short)2));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)-2, b, "wbs2_level" + b + "_code", (short)2));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)-3, b, "location_level" + b + "_code", (short)2));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)-4, b, "paramitem_level" + b + "_code", (short)2));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)-1, b, "wbs1_level" + b + "_item_code", (short)5));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)-2, b, "wbs2_level" + b + "_item_code", (short)5));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)-1, b, "wbs1_level" + b + "_unit", (short)4));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)-2, b, "wbs2_level" + b + "_unit", (short)4));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)-1, b, "wbs1_level" + b + "_qty", (short)6));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)-2, b, "wbs2_level" + b + "_qty", (short)6));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)10, b, "eps_level" + b + "_title", (short)0));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)-1, b, "wbs1_level" + b + "_title", (short)0));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)-2, b, "wbs2_level" + b + "_title", (short)0));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)-3, b, "location_level" + b + "_title", (short)0));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)-4, b, "paramitem_level" + b + "_title", (short)0));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)1, b, "groupcode1_level" + b + "_code", (short)2));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)2, b, "groupcode2_level" + b + "_code", (short)2));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)3, b, "groupcode3_level" + b + "_code", (short)2));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)4, b, "groupcode4_level" + b + "_code", (short)2));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)5, b, "groupcode5_level" + b + "_code", (short)2));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)6, b, "groupcode6_level" + b + "_code", (short)2));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)7, b, "groupcode7_level" + b + "_code", (short)2));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)8, b, "groupcode8_level" + b + "_code", (short)2));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)9, b, "groupcode9_level" + b + "_code", (short)2));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)1, b, "groupcode1_level" + b + "_title", (short)0));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)2, b, "groupcode2_level" + b + "_title", (short)0));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)3, b, "groupcode3_level" + b + "_title", (short)0));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)4, b, "groupcode4_level" + b + "_title", (short)0));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)5, b, "groupcode5_level" + b + "_title", (short)0));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)6, b, "groupcode6_level" + b + "_title", (short)0));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)7, b, "groupcode7_level" + b + "_title", (short)0));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)8, b, "groupcode8_level" + b + "_title", (short)0));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)9, b, "groupcode9_level" + b + "_title", (short)0));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)1, b, "groupcode1_level" + b + "_description", (short)1));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)2, b, "groupcode2_level" + b + "_description", (short)1));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)3, b, "groupcode3_level" + b + "_description", (short)1));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)4, b, "groupcode4_level" + b + "_description", (short)1));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)5, b, "groupcode5_level" + b + "_description", (short)1));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)6, b, "groupcode6_level" + b + "_description", (short)1));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)7, b, "groupcode7_level" + b + "_description", (short)1));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)8, b, "groupcode8_level" + b + "_description", (short)1));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)9, b, "groupcode9_level" + b + "_description", (short)1));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)1, b, "groupcode1_level" + b + "_unit", (short)4));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)2, b, "groupcode2_level" + b + "_unit", (short)4));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)3, b, "groupcode3_level" + b + "_unit", (short)4));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)4, b, "groupcode4_level" + b + "_unit", (short)4));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)5, b, "groupcode5_level" + b + "_unit", (short)4));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)6, b, "groupcode6_level" + b + "_unit", (short)4));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)7, b, "groupcode7_level" + b + "_unit", (short)4));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)8, b, "groupcode8_level" + b + "_unit", (short)4));
		  this.configuration.registerTypeOverride(new GroupCodeType(this.groupCodeProvider, (short)9, b, "groupcode9_level" + b + "_unit", (short)4));
		}
		this.sessionFactory = this.configuration.buildSessionFactory();
		this.madeProperties = paramBoolean;
		if (paramBoolean)
		{
		  reloadProperties();
		  Properties.setEncProperty("database.username", paramString1);
		  Properties.setEncProperty("database.password", paramString2);
		  Properties.makeLocalUserAndRolesData();
		  Properties.storeDBProperties();
		}
		currentSession();
		closeSession();
		updateSchema();
		this.s_prevUsername = paramString1;
		this.s_prevPassword = paramString2;
		File file = new File("data/icons/");
		if (!file.exists())
		{
		  file.mkdir();
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public boolean initDB(String paramString1, String paramString2) throws Exception
	  public virtual bool initDB(string paramString1, string paramString2)
	  {
		File file = new File(this.installDir + "data");
		if (file.Directory && !deleteDirectory(file))
		{
		  throw new Exception("could not initialize database, close any files that might be using it!");
		}
		file.mkdir();
		loadDriver();
		Properties properties = new Properties();
		properties.setProperty("user", paramString1);
		properties.setProperty("password", paramString2);
		this.mysqldResource = new MysqldResource(file);
		Hashtable hashMap = new Hashtable();
		hashMap["port"] = this.o_dbHost;
		hashMap["initialize-user"] = "true";
		hashMap["initialize-user.user"] = paramString1;
		hashMap["initialize-user.password"] = paramString2;
		hashMap["default-character-set"] = "utf8";
		this.mysqldResource.start("costos-mysqld-thread", hashMap);
		if (!this.mysqldResource.Running)
		{
		  throw new Exception("MySQL did not start.");
		}
		Connection connection = DriverManager.getConnection(DatabaseURL, properties);
		connection.close();
		return true;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void importDB(java.io.File paramFile, String paramString1, String paramString2, Desktop.common.nomitech.common.util.ProgressCallback paramProgressCallback) throws Exception
	  public virtual void importDB(File paramFile, string paramString1, string paramString2, ProgressCallback paramProgressCallback)
	  {
		paramProgressCallback.progressStep("Closing Database...");
		unloadDB(true);
		File file = new File(this.installDir + "data");
		if (file.Directory && !deleteDirectory(file))
		{
		  throw new Exception("data directory not deleted!");
		}
		file.mkdir();
		ZipUtil.unzip(paramFile, file, paramProgressCallback);
		paramProgressCallback.NumProgressSteps = -1;
		paramProgressCallback.progressStep("Reloading Database....");
		loadDB(this.groupCodeProvider, paramString1, paramString2, this.madeProperties);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void exportDB(java.io.File paramFile, String paramString1, String paramString2, Desktop.common.nomitech.common.util.ProgressCallback paramProgressCallback) throws Exception
	  public virtual void exportDB(File paramFile, string paramString1, string paramString2, ProgressCallback paramProgressCallback)
	  {
		File file = new File(this.installDir + "data");
		if (!file.exists())
		{
		  throw new Exception("strange, database does not exist!");
		}
		paramFile.createNewFile();
		paramProgressCallback.progressStep("Closing Database...");
		unloadDB(true);
		Thread.Sleep(5000L);
		zipDirectory(file, paramFile, paramProgressCallback);
		paramProgressCallback.progressStep("Reloading Database...");
		loadDB(this.groupCodeProvider, paramString1, paramString2, this.madeProperties);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void exportDB(java.io.File paramFile, Desktop.common.nomitech.common.util.ProgressCallback paramProgressCallback) throws Exception
	  public virtual void exportDB(File paramFile, ProgressCallback paramProgressCallback)
	  {
		File file = new File(this.installDir + "data");
		if (!file.exists())
		{
		  throw new Exception("strange, database does not exist!");
		}
		paramFile.createNewFile();
		zipDirectory(file, paramFile, paramProgressCallback);
	  }

	  public virtual void unloadDB(bool paramBoolean)
	  {
		closeSession();
		if (!this.sessionFactory.Closed)
		{
		  this.sessionFactory.close();
		}
		this.session = null;
		this.sessionFactory = null;
		try
		{
		  LocalDBConnectionPool.emptyPool();
		}
		catch (SQLException sQLException)
		{
		  Console.WriteLine(sQLException.ToString());
		  Console.Write(sQLException.StackTrace);
		}
		if (!paramBoolean)
		{
		  return;
		}
		try
		{
		  stopMySQL();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		if (this.madeProperties)
		{
		  Properties.storeDBProperties();
		}
	  }

	  public virtual bool hasOpenedSession()
	  {
		Session session1 = (Session)Session.get();
		return !(session1 == null);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.hibernate.Session currentSession() throws org.hibernate.HibernateException
	  public virtual Session currentSession()
	  {
		if (this.configXML == null)
		{
		  throw new HibernateException("cfg file not set");
		}
		Session session1 = (Session)Session.get();
		if (session1 == null)
		{
		  session1 = SessionFactory.openSession();
		  this.session.set(session1);
		}
		else if (!session1.Open)
		{
		  closeSession();
		  session1 = null;
		  session1 = currentSession();
		}
		return session1;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.List loadBulk(Class paramClass, System.Nullable<long>[] paramArrayOfLong) throws Exception
	  public virtual System.Collections.IList loadBulk(Type paramClass, long?[] paramArrayOfLong)
	  {
		List<object> arrayList = new List<object>(paramArrayOfLong.Length);
		Session session1 = currentSession();
		foreach (long? long in paramArrayOfLong)
		{
		  arrayList.Add(session1.load(paramClass, long));
		}
		return arrayList;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void bulkSaveOrUpdate(Class paramClass, java.util.List paramList) throws Exception
	  public virtual void bulkSaveOrUpdate(Type paramClass, System.Collections.IList paramList)
	  {
		bool @bool = hasOpenedSession();
		Session session1 = currentSession();
		foreach (object @object in paramList)
		{
		  session1.saveOrUpdate(@object);
		}
		if (!@bool)
		{
		  closeSession();
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.List fullTextSearchSession(String paramString1, String[] paramArrayOfString, Class[] paramArrayOfClass, org.apache.lucene.analysis.Analyzer paramAnalyzer, int paramInt, String paramString2, boolean paramBoolean) throws Exception
	  public virtual System.Collections.IList fullTextSearchSession(string paramString1, string[] paramArrayOfString, Type[] paramArrayOfClass, Analyzer paramAnalyzer, int paramInt, string paramString2, bool paramBoolean)
	  {
		FullTextSession fullTextSession = Search.getFullTextSession(currentSession());
		fullTextSession.beginTransaction();
		try
		{
		  MultiFieldQueryParser multiFieldQueryParser = new MultiFieldQueryParser(Version.LUCENE_22, paramArrayOfString, paramAnalyzer);
		  Query query = multiFieldQueryParser.parse(paramString1);
		  FullTextQuery fullTextQuery = fullTextSession.createFullTextQuery(query, paramArrayOfClass);
		  if (!string.ReferenceEquals(paramString2, null) && !paramString2.EndsWith("Id", StringComparison.Ordinal))
		  {
			paramString2 = paramString2 + "_sorted";
			fullTextQuery = fullTextQuery.setSort(new Sort(new SortField(paramString2, 3, !paramBoolean)));
		  }
		  if (paramInt != -1)
		  {
			fullTextQuery = fullTextQuery.setMaxResults(paramInt);
		  }
		  LinkedList linkedList = new LinkedList();
		  System.Collections.IEnumerator iterator = fullTextQuery.list().GetEnumerator();
		  while (iterator.MoveNext())
		  {
			linkedList.AddLast(iterator.Current);
		  }
		  fullTextSession.Transaction.commit();
		  fullTextSession.flush();
		  return linkedList;
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  fullTextSession.Transaction.rollback();
		  throw exception;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.List fullTextSearchSession(String paramString1, Class paramClass, int paramInt, String paramString2, boolean paramBoolean) throws Exception
	  public virtual System.Collections.IList fullTextSearchSession(string paramString1, Type paramClass, int paramInt, string paramString2, bool paramBoolean)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.io.Serializable associateAssemblyResource(Desktop.common.nomitech.common.db.local.AssemblyTable paramAssemblyTable, Desktop.common.nomitech.common.base.BaseTable paramBaseTable, java.io.Serializable paramSerializable) throws Exception
	  public virtual Serializable associateAssemblyResource(AssemblyTable paramAssemblyTable, BaseTable paramBaseTable, Serializable paramSerializable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateAssemblyResource(java.io.Serializable paramSerializable) throws Exception
	  public virtual void deassociateAssemblyResource(Serializable paramSerializable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.math.BigDecimal recalculateAssemblyRate(Desktop.common.nomitech.common.db.local.AssemblyTable paramAssemblyTable) throws Exception
	  public virtual decimal recalculateAssemblyRate(AssemblyTable paramAssemblyTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

	  public virtual IList<string> ParamItemInputGroupings
	  {
		  get
		  {
			  throw new System.InvalidOperationException("invalid method");
		  }
	  }

	  public virtual IList<string> getAvailableVariables(long? paramLong)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateVariableWithTemplate(Desktop.common.nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, Desktop.common.nomitech.common.db.project.ProjectVariableTable paramProjectVariableTable) throws Exception
	  public virtual void associateVariableWithTemplate(ProjectTemplateTable paramProjectTemplateTable, ProjectVariableTable paramProjectVariableTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateVariableFromTemplate(Desktop.common.nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, Desktop.common.nomitech.common.db.project.ProjectVariableTable paramProjectVariableTable) throws Exception
	  public virtual void deassociateVariableFromTemplate(ProjectTemplateTable paramProjectTemplateTable, ProjectVariableTable paramProjectVariableTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateBuildUpColumnWithTemplate(Desktop.common.nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, Desktop.common.nomitech.common.db.project.RateBuildUpColumnsTable paramRateBuildUpColumnsTable) throws Exception
	  public virtual void associateBuildUpColumnWithTemplate(ProjectTemplateTable paramProjectTemplateTable, RateBuildUpColumnsTable paramRateBuildUpColumnsTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateRateBuildUpWithTemplate(Desktop.common.nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, Desktop.common.nomitech.common.db.project.RateBuildUpTable paramRateBuildUpTable) throws Exception
	  public virtual void associateRateBuildUpWithTemplate(ProjectTemplateTable paramProjectTemplateTable, RateBuildUpTable paramRateBuildUpTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateRateBuildUpFromTemplate(Desktop.common.nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, Desktop.common.nomitech.common.db.project.RateBuildUpTable paramRateBuildUpTable) throws Exception
	  public virtual void deassociateRateBuildUpFromTemplate(ProjectTemplateTable paramProjectTemplateTable, RateBuildUpTable paramRateBuildUpTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateDistributorWithTemplate(Desktop.common.nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, Desktop.common.nomitech.common.db.project.RateDistributorTable paramRateDistributorTable) throws Exception
	  public virtual void associateDistributorWithTemplate(ProjectTemplateTable paramProjectTemplateTable, RateDistributorTable paramRateDistributorTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateDistributorFromTemplate(Desktop.common.nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, Desktop.common.nomitech.common.db.project.RateDistributorTable paramRateDistributorTable) throws Exception
	  public virtual void deassociateDistributorFromTemplate(ProjectTemplateTable paramProjectTemplateTable, RateDistributorTable paramRateDistributorTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Desktop.common.nomitech.common.db.project.ProjectExcelFile associateExcelFileWithTemplate(System.Nullable<long> paramLong1, System.Nullable<long> paramLong2) throws Exception
	  public virtual ProjectExcelFile associateExcelFileWithTemplate(long? paramLong1, long? paramLong2)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

	  public virtual void closeSession()
	  {
		Session session1 = (Session)Session.get();
		closeSession(session1);
		Session.set(null);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void closeSession(org.hibernate.Session paramSession) throws org.hibernate.HibernateException
	  public virtual void closeSession(Session paramSession)
	  {
		if (paramSession == null)
		{
		  return;
		}
		try
		{
		  if (paramSession.Open)
		  {
			if (paramSession.Transaction != null)
			{
			  if (paramSession.Transaction.Active)
			  {
				paramSession.Transaction.commit();
			  }
			  else
			  {
				paramSession.beginTransaction().commit();
			  }
			  paramSession.flush();
			}
			else
			{
			  paramSession.beginTransaction().commit();
			  paramSession.flush();
			}
			paramSession.close();
		  }
		}
		catch (Exception exception)
		{
		  Console.WriteLine("Error when flushing session:" + exception.Message);
		}
		try
		{
		  if (paramSession.Open)
		  {
			paramSession.close();
		  }
		}
		catch (Exception exception)
		{
		  Console.WriteLine("Error when closing session:" + exception.Message);
		}
	  }

	  public virtual bool deleteDirectory(File paramFile)
	  {
		if (paramFile.exists())
		{
		  File[] arrayOfFile = paramFile.listFiles();
		  if (arrayOfFile != null)
		  {
			for (sbyte b = 0; b < arrayOfFile.Length; b++)
			{
			  if (arrayOfFile[b].Directory)
			  {
				deleteDirectory(arrayOfFile[b]);
			  }
			  else
			  {
				arrayOfFile[b].delete();
			  }
			}
		  }
		}
		return paramFile.delete();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void zipDirectory(java.io.File paramFile1, java.io.File paramFile2, Desktop.common.nomitech.common.util.ProgressCallback paramProgressCallback) throws java.io.IOException, IllegalArgumentException
	  private void zipDirectory(File paramFile1, File paramFile2, ProgressCallback paramProgressCallback)
	  {
		if (!paramFile1.Directory)
		{
		  throw new System.ArgumentException("Compress: not a directory:  " + paramFile1);
		}
		ZipUtil.zip(paramFile1, new FileStream(paramFile2, FileMode.Create, FileAccess.Write), paramProgressCallback);
	  }

	  public virtual void connectDB(GroupCodesProvider paramGroupCodesProvider, string paramString1, string paramString2)
	  {
		this.groupCodeProvider = paramGroupCodesProvider;
		Properties properties = new Properties();
		properties.setProperty("user", paramString1);
		properties.setProperty("password", paramString2);
		this.configXML = Thread.CurrentThread.ContextClassLoader.getResource("localDB.xml");
		closeSession();
		this.configuration = (new Configuration()).configure(this.configXML);
		this.configuration.setProperty("hibernate.connection.username", paramString1);
		this.configuration.setProperty("hibernate.connection.password", paramString2);
		this.configuration.setProperty("hibernate.connection.url", DatabaseURL);
		this.configuration.setProperty("hibernate.search.default.jdbc_url", DatabaseURL);
		this.configuration.setProperty("hibernate.search.default.jdbc_username", paramString1);
		this.configuration.setProperty("hibernate.search.default.jdbc_password", paramString2);
		this.sessionFactory = this.configuration.buildSessionFactory();
		reloadProperties();
	  }

	  public virtual void connectDB(GroupCodesProvider paramGroupCodesProvider, string paramString1, string paramString2, string paramString3, string paramString4)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateFilterWithProperty(Desktop.common.nomitech.common.db.local.FilterTable paramFilterTable, Desktop.common.nomitech.common.db.local.FilterPropertyTable paramFilterPropertyTable) throws Exception
	  public virtual void associateFilterWithProperty(FilterTable paramFilterTable, FilterPropertyTable paramFilterPropertyTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateFilterProperty(Desktop.common.nomitech.common.db.local.FilterPropertyTable paramFilterPropertyTable) throws Exception
	  public virtual void deassociateFilterProperty(FilterPropertyTable paramFilterPropertyTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

	  public virtual void removeFilterPropertys(FilterTable paramFilterTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateReportWithFile(Desktop.common.nomitech.common.db.local.ReportDefinitionTable paramReportDefinitionTable, Desktop.common.nomitech.common.db.local.FileDefinitionTable paramFileDefinitionTable) throws Exception
	  public virtual void associateReportWithFile(ReportDefinitionTable paramReportDefinitionTable, FileDefinitionTable paramFileDefinitionTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateFileDefinition(Desktop.common.nomitech.common.db.local.FileDefinitionTable paramFileDefinitionTable) throws Exception
	  public virtual void deassociateFileDefinition(FileDefinitionTable paramFileDefinitionTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void removeFileDefinitions(Desktop.common.nomitech.common.db.local.ReportDefinitionTable paramReportDefinitionTable) throws Exception
	  public virtual void removeFileDefinitions(ReportDefinitionTable paramReportDefinitionTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateSupplierWithMaterial(Desktop.common.nomitech.common.db.local.SupplierTable paramSupplierTable, Desktop.common.nomitech.common.db.local.MaterialTable paramMaterialTable) throws Exception
	  public virtual void associateSupplierWithMaterial(SupplierTable paramSupplierTable, MaterialTable paramMaterialTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateMaterialFromSupplier(Desktop.common.nomitech.common.db.local.MaterialTable paramMaterialTable) throws Exception
	  public virtual void deassociateMaterialFromSupplier(MaterialTable paramMaterialTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateLayoutWithPanel(Desktop.common.nomitech.common.db.layout.LayoutTable paramLayoutTable, Desktop.common.nomitech.common.db.layout.LayoutPanelTable paramLayoutPanelTable) throws Exception
	  public virtual void associateLayoutWithPanel(LayoutTable paramLayoutTable, LayoutPanelTable paramLayoutPanelTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateLayoutPanel(Desktop.common.nomitech.common.db.layout.LayoutPanelTable paramLayoutPanelTable) throws Exception
	  public virtual void deassociateLayoutPanel(LayoutPanelTable paramLayoutPanelTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateProfileWithFactor(Desktop.common.nomitech.common.db.local.LocalizationProfileTable paramLocalizationProfileTable, Desktop.common.nomitech.common.db.local.LocalizationFactorTable paramLocalizationFactorTable) throws Exception
	  public virtual void associateProfileWithFactor(LocalizationProfileTable paramLocalizationProfileTable, LocalizationFactorTable paramLocalizationFactorTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateFactor(Desktop.common.nomitech.common.db.local.LocalizationFactorTable paramLocalizationFactorTable) throws Exception
	  public virtual void deassociateFactor(LocalizationFactorTable paramLocalizationFactorTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void removeLayoutPanels(Desktop.common.nomitech.common.db.layout.LayoutTable paramLayoutTable) throws Exception
	  public virtual void removeLayoutPanels(LayoutTable paramLayoutTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

	  public virtual void associateWBSWithProjectInfo(ProjectInfoTable paramProjectInfoTable, ProjectWBSTable paramProjectWBSTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

	  public virtual void deassociateWBSFromProjectInfo(ProjectWBSTable paramProjectWBSTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateWBS2WithProjectInfo(Desktop.common.nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable, Desktop.common.nomitech.common.db.local.ProjectWBS2Table paramProjectWBS2Table) throws Exception
	  public virtual void associateWBS2WithProjectInfo(ProjectInfoTable paramProjectInfoTable, ProjectWBS2Table paramProjectWBS2Table)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateWBS2FromProjectInfo(Desktop.common.nomitech.common.db.local.ProjectWBS2Table paramProjectWBS2Table) throws Exception
	  public virtual void deassociateWBS2FromProjectInfo(ProjectWBS2Table paramProjectWBS2Table)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateFunctionWithArgument(Desktop.common.nomitech.common.db.local.FunctionTable paramFunctionTable, Desktop.common.nomitech.common.db.local.FunctionArgumentTable paramFunctionArgumentTable) throws Exception
	  public virtual void associateFunctionWithArgument(FunctionTable paramFunctionTable, FunctionArgumentTable paramFunctionArgumentTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateFunctionArgument(Desktop.common.nomitech.common.db.local.FunctionArgumentTable paramFunctionArgumentTable) throws Exception
	  public virtual void deassociateFunctionArgument(FunctionArgumentTable paramFunctionArgumentTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void removeFunctionArguments(Desktop.common.nomitech.common.db.local.FunctionTable paramFunctionTable) throws Exception
	  public virtual void removeFunctionArguments(FunctionTable paramFunctionTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateParamItemWithInput(Desktop.common.nomitech.common.db.local.ParamItemTable paramParamItemTable, Desktop.common.nomitech.common.db.local.ParamItemInputTable paramParamItemInputTable) throws Exception
	  public virtual void associateParamItemWithInput(ParamItemTable paramParamItemTable, ParamItemInputTable paramParamItemInputTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateInputFromParamItem(Desktop.common.nomitech.common.db.local.ParamItemInputTable paramParamItemInputTable) throws Exception
	  public virtual void deassociateInputFromParamItem(ParamItemInputTable paramParamItemInputTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateParamItemWithOutput(Desktop.common.nomitech.common.db.local.ParamItemTable paramParamItemTable, Desktop.common.nomitech.common.db.local.ParamItemOutputTable paramParamItemOutputTable) throws Exception
	  public virtual void associateParamItemWithOutput(ParamItemTable paramParamItemTable, ParamItemOutputTable paramParamItemOutputTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateOutputFromParamItem(Desktop.common.nomitech.common.db.local.ParamItemOutputTable paramParamItemOutputTable) throws Exception
	  public virtual void deassociateOutputFromParamItem(ParamItemOutputTable paramParamItemOutputTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateParamItemOutputWithConResource(Desktop.common.nomitech.common.db.local.ParamItemConceptualResourceTable paramParamItemConceptualResourceTable, Desktop.common.nomitech.common.db.local.ParamItemOutputTable paramParamItemOutputTable) throws Exception
	  public virtual void associateParamItemOutputWithConResource(ParamItemConceptualResourceTable paramParamItemConceptualResourceTable, ParamItemOutputTable paramParamItemOutputTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateConResourceFromOutput(Desktop.common.nomitech.common.db.local.ParamItemConceptualResourceTable paramParamItemConceptualResourceTable) throws Exception
	  public virtual void deassociateConResourceFromOutput(ParamItemConceptualResourceTable paramParamItemConceptualResourceTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateParamItemOutputWithQueryResource(Desktop.common.nomitech.common.db.local.ParamItemQueryResourceTable paramParamItemQueryResourceTable, Desktop.common.nomitech.common.db.local.ParamItemOutputTable paramParamItemOutputTable) throws Exception
	  public virtual void associateParamItemOutputWithQueryResource(ParamItemQueryResourceTable paramParamItemQueryResourceTable, ParamItemOutputTable paramParamItemOutputTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateQueryResourceFromOutput(Desktop.common.nomitech.common.db.local.ParamItemQueryResourceTable paramParamItemQueryResourceTable) throws Exception
	  public virtual void deassociateQueryResourceFromOutput(ParamItemQueryResourceTable paramParamItemQueryResourceTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public int getParamItemInputCount(System.Nullable<long> paramLong) throws Exception
	  public virtual int getParamItemInputCount(long? paramLong)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public int getParamItemOutputCount(System.Nullable<long> paramLong) throws Exception
	  public virtual int getParamItemOutputCount(long? paramLong)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.List loadAllDeepCopy(Class paramClass) throws Exception
	  public virtual System.Collections.IList loadAllDeepCopy(Type paramClass)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateProjectWithUrl(Desktop.common.nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable, Desktop.common.nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable) throws Exception
	  public virtual void associateProjectWithUrl(ProjectInfoTable paramProjectInfoTable, ProjectUrlTable paramProjectUrlTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateUrlFromProject(Desktop.common.nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable) throws Exception
	  public virtual void deassociateUrlFromProject(ProjectUrlTable paramProjectUrlTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateEPSWithProject(Desktop.common.nomitech.common.db.local.ProjectEPSTable paramProjectEPSTable, Desktop.common.nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable) throws Exception
	  public virtual void associateEPSWithProject(ProjectEPSTable paramProjectEPSTable, ProjectInfoTable paramProjectInfoTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateProjectFromEPS(Desktop.common.nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable) throws Exception
	  public virtual void deassociateProjectFromEPS(ProjectInfoTable paramProjectInfoTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.List<Desktop.common.nomitech.common.db.local.ProjectInfoTable> loadProjectInfosWithUrls(System.Nullable<long>[] paramArrayOfLong) throws Exception
	  public virtual IList<ProjectInfoTable> loadProjectInfosWithUrls(long?[] paramArrayOfLong)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateProjectWithUser(Desktop.common.nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable, Desktop.common.nomitech.common.db.local.ProjectUserTable paramProjectUserTable) throws Exception
	  public virtual void associateProjectWithUser(ProjectInfoTable paramProjectInfoTable, ProjectUserTable paramProjectUserTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

	  public virtual void deassociateUserFromProject(ProjectUserTable paramProjectUserTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.List<Desktop.common.nomitech.common.db.local.ProjectInfoTable> loadProjectInfosWithEPS(System.Nullable<long>[] paramArrayOfLong) throws Exception
	  public virtual IList<ProjectInfoTable> loadProjectInfosWithEPS(long?[] paramArrayOfLong)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.List<Desktop.common.nomitech.common.db.local.ProjectInfoTable> findProjectInfosAndEPSsByQuery(String paramString) throws Exception
	  public virtual IList<ProjectInfoTable> findProjectInfosAndEPSsByQuery(string paramString)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateProjectWithCondition(Desktop.common.nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable, Desktop.common.nomitech.common.db.local.TakeoffConditionTable paramTakeoffConditionTable) throws Exception
	  public virtual void associateProjectWithCondition(ProjectInfoTable paramProjectInfoTable, TakeoffConditionTable paramTakeoffConditionTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateConditionFromProject(Desktop.common.nomitech.common.db.local.TakeoffConditionTable paramTakeoffConditionTable) throws Exception
	  public virtual void deassociateConditionFromProject(TakeoffConditionTable paramTakeoffConditionTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.List<Desktop.common.nomitech.common.db.local.TakeoffConditionTable> findMapConditionsByQueryDeepCopy(String paramString) throws Exception
	  public virtual IList<TakeoffConditionTable> findMapConditionsByQueryDeepCopy(string paramString)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateConditionWithLine(Desktop.common.nomitech.common.db.local.TakeoffConditionTable paramTakeoffConditionTable, Desktop.common.nomitech.common.db.local.TakeoffLineTable paramTakeoffLineTable) throws Exception
	  public virtual void associateConditionWithLine(TakeoffConditionTable paramTakeoffConditionTable, TakeoffLineTable paramTakeoffLineTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateConditionWithArea(Desktop.common.nomitech.common.db.local.TakeoffConditionTable paramTakeoffConditionTable, Desktop.common.nomitech.common.db.local.TakeoffAreaTable paramTakeoffAreaTable) throws Exception
	  public virtual void associateConditionWithArea(TakeoffConditionTable paramTakeoffConditionTable, TakeoffAreaTable paramTakeoffAreaTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateConditionWithPoint(Desktop.common.nomitech.common.db.local.TakeoffConditionTable paramTakeoffConditionTable, Desktop.common.nomitech.common.db.local.TakeoffPointTable paramTakeoffPointTable) throws Exception
	  public virtual void associateConditionWithPoint(TakeoffConditionTable paramTakeoffConditionTable, TakeoffPointTable paramTakeoffPointTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void associateConditionWithLegend(Desktop.common.nomitech.common.db.local.TakeoffConditionTable paramTakeoffConditionTable, Desktop.common.nomitech.common.db.local.TakeoffLegendTable paramTakeoffLegendTable) throws Exception
	  public virtual void associateConditionWithLegend(TakeoffConditionTable paramTakeoffConditionTable, TakeoffLegendTable paramTakeoffLegendTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void setElevationSamplesOfLine(Desktop.common.nomitech.common.db.local.TakeoffLineTable paramTakeoffLineTable, java.util.List<Desktop.common.nomitech.common.db.local.TakeoffPointTable> paramList) throws Exception
	  public virtual void setElevationSamplesOfLine(TakeoffLineTable paramTakeoffLineTable, IList<TakeoffPointTable> paramList)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void setPolygonOfArea(Desktop.common.nomitech.common.db.local.TakeoffAreaTable paramTakeoffAreaTable, java.util.List<Desktop.common.nomitech.common.db.local.TakeoffPointTable> paramList) throws Exception
	  public virtual void setPolygonOfArea(TakeoffAreaTable paramTakeoffAreaTable, IList<TakeoffPointTable> paramList)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void setTrianglesOfArea(Desktop.common.nomitech.common.db.local.TakeoffAreaTable paramTakeoffAreaTable, java.util.List<Desktop.common.nomitech.common.db.local.TakeoffTriangleTable> paramList) throws Exception
	  public virtual void setTrianglesOfArea(TakeoffAreaTable paramTakeoffAreaTable, IList<TakeoffTriangleTable> paramList)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void removeElevationSamplesFromLine(Desktop.common.nomitech.common.db.local.TakeoffLineTable paramTakeoffLineTable) throws Exception
	  public virtual void removeElevationSamplesFromLine(TakeoffLineTable paramTakeoffLineTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void updateTakeoffPoints(java.util.List<Desktop.common.nomitech.common.db.local.TakeoffPointTable> paramList) throws Exception
	  public virtual void updateTakeoffPoints(IList<TakeoffPointTable> paramList)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void updateTakeoffTriangles(java.util.List<Desktop.common.nomitech.common.db.local.TakeoffTriangleTable> paramList) throws Exception
	  public virtual void updateTakeoffTriangles(IList<TakeoffTriangleTable> paramList)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

	  public virtual IList<string> AvailableReportGroupings
	  {
		  get
		  {
			  throw new System.InvalidOperationException("invalid method");
		  }
	  }

	  public virtual BaseDBProperties Properties
	  {
		  get
		  {
			  return this.o_properties;
		  }
	  }

	  public virtual BaseDBProperties reloadProperties()
	  {
		this.o_properties = new LocalDBProperties(this.installDir + this.propertiesFileName);
		return this.o_properties;
	  }

	  public virtual BaseDBProperties reloadProperties(string paramString)
	  {
		this.o_properties = new LocalDBProperties(this.installDir + paramString);
		return this.o_properties;
	  }

	  public virtual bool LocalCommunication
	  {
		  get
		  {
			  return true;
		  }
	  }

	  public virtual bool Enterprise
	  {
		  get
		  {
			  return false;
		  }
	  }

	  public virtual string getPathOfImage(string paramString, Type paramClass, long? paramLong)
	  {
		  return IconUploadUtil.getLocalPathOfImage(paramString, paramClass, paramLong);
	  }

	  public virtual string getPathOfIcon(string paramString, Type paramClass, int paramInt)
	  {
		  return IconUploadUtil.getLocalPathOfIcon(paramString, paramClass, paramInt);
	  }

	  public virtual string getPathOfJrxml(string paramString, Type paramClass, long? paramLong)
	  {
		  return IconUploadUtil.getLocalPathOfJrxml(paramString, paramClass, paramLong);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public boolean deleteIcon(String paramString, Class paramClass) throws Exception
	  public virtual bool deleteIcon(string paramString, Type paramClass)
	  {
		  return IconUploadUtil.deleteLocalIcon(paramString, paramClass);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public boolean deleteImage(String paramString, Class paramClass, System.Nullable<long> paramLong) throws Exception
	  public virtual bool deleteImage(string paramString, Type paramClass, long? paramLong)
	  {
		  return IconUploadUtil.deleteLocalImage(paramString, paramClass, paramLong);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public boolean deleteJrxml(String paramString, Class paramClass, System.Nullable<long> paramLong) throws Exception
	  public virtual bool deleteJrxml(string paramString, Type paramClass, long? paramLong)
	  {
		  return IconUploadUtil.deleteLocalJrxml(paramString, paramClass, paramLong);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public String uploadIcon(String paramString, Class paramClass) throws Exception
	  public virtual string uploadIcon(string paramString, Type paramClass)
	  {
		  return IconUploadUtil.uploadLocalIcon(paramString, paramClass);
	  }

	  public virtual string uploadImage(string paramString, Type paramClass, long? paramLong)
	  {
		  return IconUploadUtil.uploadLocalImage(paramString, paramClass, paramLong);
	  }

	  public virtual string uploadJrxml(string paramString, Type paramClass, long? paramLong)
	  {
		  return IconUploadUtil.uploadLocalJrxml(paramString, paramClass, paramLong);
	  }

	  public static LocalDBUtil Instance
	  {
		  get
		  {
			if (s_instance == null)
			{
			  s_instance = new LocalDBUtil();
			}
			return s_instance;
		  }
	  }

	  public static LocalDBUtil getInstance(string paramString)
	  {
		if (s_instance == null)
		{
		  s_instance = new LocalDBUtil(paramString);
		}
		return s_instance;
	  }

	  public static LocalDBUtil getInstance(string paramString1, string paramString2)
	  {
		if (s_instance == null)
		{
		  s_instance = new LocalDBUtil(paramString1, paramString2);
		}
		return s_instance;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public int executeUpdate(String paramString1, String paramString2, java.util.List<long> paramList) throws Exception
	  public virtual int executeUpdate(string paramString1, string paramString2, IList<long> paramList)
	  {
		int i = -1;
		if (paramList.Count < 1500)
		{
		  Query query = currentSession().createQuery(paramString1);
		  query.setParameterList(paramString2, paramList);
		  i = query.executeUpdate();
		}
		else
		{
		  int j = 0;
		  int k = paramList.Count;
		  while (true)
		  {
			int m = k - j;
			if (m <= 0)
			{
			  break;
			}
			if (m > 1500)
			{
			  m = 1500;
			}
			Query query = currentSession().createQuery(paramString1);
			query.setParameterList(paramString2, paramList.subList(j, j + m));
			i = query.executeUpdate();
			j += m;
		  }
		}
		return i;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.List<long> executeLongQuery(String paramString1, String paramString2, java.util.List<long> paramList) throws Exception
	  public virtual IList<long> executeLongQuery(string paramString1, string paramString2, IList<long> paramList)
	  {
		System.Collections.IList list = Collections.EMPTY_LIST;
		if (paramList.Count < 1500)
		{
		  Query query = currentSession().createQuery(paramString1);
		  query.setParameterList(paramString2, paramList);
		  list = query.list();
		}
		else
		{
		  list = new List<object>(paramList.Count);
		  int i = 0;
		  int j = paramList.Count;
		  while (true)
		  {
			int k = j - i;
			if (k <= 0)
			{
			  break;
			}
			if (k > 1500)
			{
			  k = 1500;
			}
			Query query = currentSession().createQuery(paramString1);
			query.setParameterList(paramString2, paramList.subList(i, i + k));
			list.AddRange(query.list());
			i += k;
		  }
		}
		return list;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Desktop.common.nomitech.common.db.local.AssemblyTable recalculateAndUpdate(Desktop.common.nomitech.common.db.local.AssemblyTable paramAssemblyTable, boolean paramBoolean) throws Exception
	  public virtual AssemblyTable recalculateAndUpdate(AssemblyTable paramAssemblyTable, bool paramBoolean)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void deassociateBuildUpColumnFromTemplate(Desktop.common.nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, Desktop.common.nomitech.common.db.project.RateBuildUpColumnsTable paramRateBuildUpColumnsTable) throws Exception
	  public virtual void deassociateBuildUpColumnFromTemplate(ProjectTemplateTable paramProjectTemplateTable, RateBuildUpColumnsTable paramRateBuildUpColumnsTable)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

	  public virtual IList<HqlResultValue[]> executeHqlQuery(string paramString, IList<HqlParameterWithValue> paramList)
	  {
		  throw new System.InvalidOperationException("invalid method");
	  }

	  public virtual int DbmsType
	  {
		  get
		  {
			  return ProjectDBUtil.MYSQL_DBMS;
		  }
	  }

	  public virtual bool UserLogEnabled
	  {
		  get
		  {
			  return false;
		  }
	  }

	  public virtual void setLocalConnection(string paramString1, string paramString2, string paramString3, int paramInt)
	  {
		this.o_dbHost = paramString1;
		this.o_dbPort = paramString2;
		this.o_dbName = paramString3;
		this.s_connectionType = paramInt;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\LocalDBUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}