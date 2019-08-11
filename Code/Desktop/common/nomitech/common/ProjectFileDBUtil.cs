using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace Desktop.common.nomitech.common
{
	using ProjectGroupCodesProviderFactory = Desktop.common.nomitech.common.@base.ProjectGroupCodesProviderFactory;
	using ProjectUrlTable = Models.local.ProjectUrlTable;
	using CostOSString256Type = Models.types.CostOSString256Type;
	using CostOSTextType = Models.types.CostOSTextType;
	using GroupCodeType = Models.types.GroupCodeType;
	using UnitAliasType = Models.types.UnitAliasType;
	using ProgressCallback = Desktop.common.nomitech.common.util.ProgressCallback;
	using ZipUtil = Desktop.common.nomitech.common.util.ZipUtil;
	using HibernateException = org.hibernate.HibernateException;
	using Session = org.hibernate.Session;
	using SessionFactory = org.hibernate.SessionFactory;
	using Configuration = org.hibernate.cfg.Configuration;

	public class ProjectFileDBUtil : ProjectDBUtil
	{
	  private static URL configXML = null;

	  private SessionFactory o_sessionFactory = null;

	  private Configuration o_configuration = null;

	  private ThreadLocal o_session = null;

	  private string o_projectFolderName = "" + DateTimeHelper.CurrentUnixTimeMillis();

	  private ProjectDBProperties o_properties;

	  private bool b_isDBLoaded = false;

	  private static string installDir = "";

	  private Exception o_retException = null;

	  private File o_openedFile = null;

	  private IList<Session> aliveSessions = new LinkedList();

	  private ProjectUrlTable urlTable;

	  public static string InstallDirectory
	  {
		  set
		  {
			  installDir = value;
		  }
	  }

	  public static string setInstallDirectory()
	  {
		  return installDir;
	  }

	  public static URL ConfigXML
	  {
		  set
		  {
			  configXML = value;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public ProjectFileDBUtil(Desktop.common.nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable) throws Exception
	  public ProjectFileDBUtil(ProjectUrlTable paramProjectUrlTable)
	  {
		if (configXML == null)
		{
		  configXML = this.GetType().getResource("projectDB.xml");
		}
		this.urlTable = paramProjectUrlTable;
		ProjectUrlId = paramProjectUrlTable.ProjectUrlId;
		makeNewDB();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public ProjectFileDBUtil() throws Exception
	  public ProjectFileDBUtil()
	  {
		if (configXML == null)
		{
		  configXML = this.GetType().getResource("projectDB.xml");
		}
		makeNewDB();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public ProjectFileDBUtil(java.io.File paramFile, Desktop.common.nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable, Desktop.common.nomitech.common.base.ProjectGroupCodesProviderFactory paramProjectGroupCodesProviderFactory) throws Exception
	  public ProjectFileDBUtil(File paramFile, ProjectUrlTable paramProjectUrlTable, ProjectGroupCodesProviderFactory paramProjectGroupCodesProviderFactory)
	  {
		if (configXML == null)
		{
		  configXML = this.GetType().getResource("projectDB.xml");
		}
		ProjectUrlId = paramProjectUrlTable.ProjectUrlId;
		this.o_overridenFactory = paramProjectGroupCodesProviderFactory;
		this.urlTable = paramProjectUrlTable;
		if (paramFile.exists())
		{
		  this.o_openedFile = paramFile;
		  extractDBFile(paramFile);
		}
		else
		{
		  throw new Exception("project not found in path: " + paramFile.AbsolutePath);
		}
	  }

	  public override bool DBLoaded
	  {
		  get
		  {
			  return this.b_isDBLoaded;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void makeNewDB() throws Exception
	  private void makeNewDB()
	  {
		File file = makeProjectFolder(this.o_projectFolderName);
		file.mkdirs();
		this.o_properties = new ProjectDBProperties(this, false);
	  }

	  private File makeProjectFolder(string paramString)
	  {
		  return new File(installDir + "project" + File.separator + paramString);
	  }

	  public override File ProjectFolder
	  {
		  get
		  {
			  return makeProjectFolder(this.o_projectFolderName);
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void extractDBFile(java.io.File paramFile) throws Exception
	  private void extractDBFile(File paramFile)
	  {
		this.projectFolder = makeProjectFolder(this.o_projectFolderName);
		this.projectFolder.mkdirs();
		ZipUtil.unpackArchive(paramFile, this.projectFolder);
		File file = new File(installDir + "project" + File.separator + this.o_projectFolderName + File.separator + "projectDB.details");
		if (!paramFile.Name.equalsIgnoreCase("populatedExpenses") && file.exists())
		{
		  Console.WriteLine("Migrating from file to database..." + paramFile);
		  this.o_properties = new ProjectDBProperties(this, file.AbsoluteFile.ToString());
		  file.delete();
		  if (file.exists())
		  {
			throw new Exception("fatal error when upgrading project, could not delete previous details file");
		  }
		}
		else if (file.exists())
		{
		  file.delete();
		  if (file.exists())
		  {
			throw new Exception("fatal error when upgrading project, could not delete previous details file");
		  }
		  loadDB();
		}
		else
		{
		  loadDB();
		}
	  }

	  public override SessionFactory SessionFactory
	  {
		  get
		  {
			if (this.o_sessionFactory == null)
			{
			  try
			  {
				this.o_sessionFactory = (new Configuration()).configure().buildSessionFactory();
			  }
			  catch (Exception throwable)
			  {
				Console.Error.WriteLine("Initial SessionFactory creation failed." + throwable);
			  }
			}
			return this.o_sessionFactory;
		  }
	  }

	  public override Configuration Configuration
	  {
		  get
		  {
			  return this.o_configuration;
		  }
	  }

	  private ThreadLocal Session
	  {
		  get
		  {
			if (this.o_session == null)
			{
			  this.o_session = new ThreadLocal();
			}
			return this.o_session;
		  }
	  }

	  public override ProjectDBProperties Properties
	  {
		  get
		  {
			  return this.o_properties;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void flushCache() throws Exception
	  public override void flushCache()
	  {
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void loadDB() throws Exception
	  public override void loadDB()
	  {
		if (DBLoaded)
		{
		  return;
		}
		if (syncToEventDispatch && !SwingUtilities.EventDispatchThread)
		{
		  this.o_retException = null;
		  SwingUtilities.invokeAndWait(new RunnableAnonymousInnerClass(this));
		  if (this.o_retException != null)
		  {
			throw this.o_retException;
		  }
		  return;
		}
		if (this.o_properties != null && !string.ReferenceEquals(this.o_properties.PreviousVersion, null))
		{
		  if (this.o_properties.isOlderVersionFrom(this.o_properties.PreviousVersion, "4.0.1"))
		  {
			Console.WriteLine("Deleting indexes prior to 4.0.1 from version " + this.o_properties.PreviousVersion);
			try
			{
			  Console.WriteLine("deleting: " + new File(installDir + "project/" + this.o_projectFolderName + "/indexBase"));
			  deleteDirectory(new File(installDir + "project/" + this.o_projectFolderName + "/indexBase"));
			}
			catch (Exception exception)
			{
			  Console.WriteLine(exception.ToString());
			  Console.Write(exception.StackTrace);
			}
		  }
		  if (this.o_properties.isOlderVersionFrom(this.o_properties.PreviousVersion, "4.2.7"))
		  {
			Properties properties = new Properties();
			properties.setProperty("user", "SA");
			properties.setProperty("password", "");
			properties.setProperty("shutdown", "true");
			initDriver(HSQL_DBMS);
			Connection connection = DriverManager.getConnection("jdbc:hsqldb:" + installDir + "project/" + this.o_projectFolderName + "/projectDB", properties);
			if (!connection.AutoCommit)
			{
			  connection.commit();
			}
			Statement statement = connection.createStatement();
			try
			{
			  Console.WriteLine("Renaming the Condition Table to CNDON...");
			  statement.execute("DROP TABLE IF EXISTS CNDON");
			  statement.execute("ALTER TABLE CONDITION RENAME TO CNDON");
			  Console.WriteLine("OK!");
			}
			catch (Exception exception)
			{
			  Console.WriteLine(exception.ToString());
			  Console.Write(exception.StackTrace);
			  Console.WriteLine("TABLE WITH NAME CONDITION NOT FOUND!");
			}
			statement.close();
			connection.close();
		  }
		  if (this.o_properties.isOlderVersionFrom(this.o_properties.PreviousVersion, "4.6.0"))
		  {
			Properties properties = new Properties();
			properties.setProperty("user", "SA");
			properties.setProperty("password", "");
			properties.setProperty("shutdown", "true");
			initDriver(HSQL_DBMS);
			Connection connection = DriverManager.getConnection("jdbc:hsqldb:" + installDir + "project/" + this.o_projectFolderName + "/projectDB", properties);
			if (!connection.AutoCommit)
			{
			  connection.commit();
			}
			Statement statement = connection.createStatement();
			try
			{
			  Console.WriteLine("Updating data integrity...");
			  statement.execute("ALTER TABLE BOQITEM ALTER COLUMN DESCRIPTION LONGVARCHAR");
			  statement.execute("ALTER TABLE BOQITEM ALTER COLUMN NOTES LONGVARCHAR");
			  statement.execute("ALTER TABLE EQUIPMENT ALTER COLUMN DESCRIPTION LONGVARCHAR");
			  statement.execute("ALTER TABLE EQUIPMENT ALTER COLUMN NOTES LONGVARCHAR");
			  statement.execute("ALTER TABLE ASSEMBLY ALTER COLUMN DESCRIPTION LONGVARCHAR");
			  statement.execute("ALTER TABLE ASSEMBLY ALTER COLUMN NOTES LONGVARCHAR");
			  statement.execute("ALTER TABLE MATERIAL ALTER COLUMN DESCRIPTION LONGVARCHAR");
			  statement.execute("ALTER TABLE MATERIAL ALTER COLUMN NOTES LONGVARCHAR");
			  statement.execute("ALTER TABLE SUBCONTRACTOR ALTER COLUMN DESCRIPTION LONGVARCHAR");
			  statement.execute("ALTER TABLE SUBCONTRACTOR ALTER COLUMN NOTES LONGVARCHAR");
			  statement.execute("ALTER TABLE QUOTEITEM ALTER COLUMN TITLE LONGVARCHAR");
			  Console.WriteLine("OK!");
			}
			catch (Exception)
			{
			}
			statement.close();
			connection.close();
		  }
		}
		closeSession();
		this.o_configuration = new Configuration();
		this.o_configuration.configure(configXML);
		ISet<object> set = this.o_configuration.Properties.Keys;
		string[] arrayOfString = (string[])set.toArray(new string[set.Count]);
		foreach (string str in arrayOfString)
		{
		  if (str.IndexOf("search.default", StringComparison.Ordinal) != -1)
		  {
			this.o_configuration.Properties.remove(str);
		  }
		}
		this.o_configuration.setProperty("hibernate.connection.isolation", "1");
		this.o_configuration.setProperty("hibernate.cache.jdbc.batch_size", "50");
		this.o_configuration.setProperty("hibernate.cache.use_second_level_cache", "false");
		this.o_configuration.setProperty("hibernate.cache.use_query_cache", "false");
		this.o_configuration.setProperty("hibernate.cache.provider_class", "org.hibernate.cache.NoCacheProvider");
		this.o_configuration.setProperty("hibernate.search.indexing_strategy", "manual");
		this.o_configuration.setProperty("hibernate.search.autoregister_listeners", "false");
		this.o_configuration.setProperty("hibernate.temp.use_jdbc_metadata_defaults", "false");
		this.o_configuration.registerTypeOverride(new CostOSString256Type(), new string[] {"costos_string"});
		this.o_configuration.registerTypeOverride(new CostOSTextType());
		this.o_configuration.registerTypeOverride(new UnitAliasType(ProjectGroupCodesProvider, "unit_alias"));
		for (sbyte b = 1; b <= 9; b++)
		{
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)10, b, "eps_level" + b + "_code", (short)2));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)-1, b, "wbs1_level" + b + "_code", (short)2));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)-2, b, "wbs2_level" + b + "_code", (short)2));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)-3, b, "location_level" + b + "_code", (short)2));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)-4, b, "paramitem_level" + b + "_code", (short)2));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)10, b, "eps_level" + b + "_title", (short)0));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)-1, b, "wbs1_level" + b + "_title", (short)0));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)-2, b, "wbs2_level" + b + "_title", (short)0));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)-3, b, "location_level" + b + "_title", (short)0));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)-4, b, "paramitem_level" + b + "_title", (short)0));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)-1, b, "wbs1_level" + b + "_item_code", (short)5));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)-2, b, "wbs2_level" + b + "_item_code", (short)5));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)-1, b, "wbs1_level" + b + "_unit", (short)4));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)-2, b, "wbs2_level" + b + "_unit", (short)4));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)-1, b, "wbs1_level" + b + "_qty", (short)6));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)-2, b, "wbs2_level" + b + "_qty", (short)6));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)1, b, "groupcode1_level" + b + "_code", (short)2));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)2, b, "groupcode2_level" + b + "_code", (short)2));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)3, b, "groupcode3_level" + b + "_code", (short)2));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)4, b, "groupcode4_level" + b + "_code", (short)2));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)5, b, "groupcode5_level" + b + "_code", (short)2));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)6, b, "groupcode6_level" + b + "_code", (short)2));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)7, b, "groupcode7_level" + b + "_code", (short)2));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)8, b, "groupcode8_level" + b + "_code", (short)2));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)9, b, "groupcode9_level" + b + "_code", (short)2));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)1, b, "groupcode1_level" + b + "_title", (short)0));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)2, b, "groupcode2_level" + b + "_title", (short)0));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)3, b, "groupcode3_level" + b + "_title", (short)0));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)4, b, "groupcode4_level" + b + "_title", (short)0));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)5, b, "groupcode5_level" + b + "_title", (short)0));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)6, b, "groupcode6_level" + b + "_title", (short)0));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)7, b, "groupcode7_level" + b + "_title", (short)0));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)8, b, "groupcode8_level" + b + "_title", (short)0));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)9, b, "groupcode9_level" + b + "_title", (short)0));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)1, b, "groupcode1_level" + b + "_description", (short)1));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)2, b, "groupcode2_level" + b + "_description", (short)1));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)3, b, "groupcode3_level" + b + "_description", (short)1));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)4, b, "groupcode4_level" + b + "_description", (short)1));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)5, b, "groupcode5_level" + b + "_description", (short)1));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)6, b, "groupcode6_level" + b + "_description", (short)1));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)7, b, "groupcode7_level" + b + "_description", (short)1));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)8, b, "groupcode8_level" + b + "_description", (short)1));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)9, b, "groupcode9_level" + b + "_description", (short)1));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)1, b, "groupcode1_level" + b + "_unit", (short)4));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)2, b, "groupcode2_level" + b + "_unit", (short)4));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)3, b, "groupcode3_level" + b + "_unit", (short)4));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)4, b, "groupcode4_level" + b + "_unit", (short)4));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)5, b, "groupcode5_level" + b + "_unit", (short)4));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)6, b, "groupcode6_level" + b + "_unit", (short)4));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)7, b, "groupcode7_level" + b + "_unit", (short)4));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)8, b, "groupcode8_level" + b + "_unit", (short)4));
		  this.o_configuration.registerTypeOverride(new GroupCodeType(ProjectGroupCodesProvider, (short)9, b, "groupcode9_level" + b + "_unit", (short)4));
		}
		this.o_configuration.setListener("post-update", null);
		this.o_configuration.setListener("post-insert", null);
		this.o_configuration.setListener("post-delete", null);
		this.o_configuration.setProperty("hibernate.connection.url", "jdbc:hsqldb:" + installDir + "project/" + this.o_projectFolderName + "/projectDB;hsqldb.write_delay=false");
		this.o_sessionFactory = this.o_configuration.buildSessionFactory();
		Session session = currentSession();
		if (ProjectSchemaUpdateUtil.checkRequiresProjectIdUpdates(this))
		{
		  ProjectSchemaUpdateUtil.processProjectIdUpdates(this);
		}
		closeSession();
		ProjectDBUtil projectDBUtil;
		(projectDBUtil = ProjectDBUtil.currentProjectDBUtil()).CurrentProjectDBUtil = this;
		File file = new File(installDir + "project" + File.separator + this.o_projectFolderName + File.separator + "projectDB.details");
		if (!file.exists())
		{
		  this.b_isDBLoaded = true;
		  if (this.o_properties == null)
		  {
			this.o_properties = new ProjectDBProperties(this, true);
		  }
		  else
		  {
			this.o_properties.reloadProperties();
		  }
		  if (!string.ReferenceEquals(this.o_properties.PreviousVersion, null))
		  {
			updateNewerDatabase();
		  }
		  ProjectGroupCodesProvider.initializeProjectCaches();
		}
		ProjectDBUtil.CurrentProjectDBUtil = projectDBUtil;
	  }

	  private class RunnableAnonymousInnerClass : ThreadStart
	  {
		  private readonly ProjectFileDBUtil outerInstance;

		  public RunnableAnonymousInnerClass(ProjectFileDBUtil outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void run() throws Exception
		  public void run()
		  {
			try
			{
			  outerInstance.loadDB();
			}
			catch (Exception exception)
			{
			  outerInstance.o_retException = exception;
			}
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void unloadDB() throws Exception
	  public override void unloadDB()
	  {
		if (syncToEventDispatch && !SwingUtilities.EventDispatchThread)
		{
		  this.o_retException = null;
		  SwingUtilities.invokeAndWait(new RunnableAnonymousInnerClass2(this));
		  if (this.o_retException != null)
		  {
			throw this.o_retException;
		  }
		  return;
		}
		try
		{
		  this.b_isDBLoaded = false;
		  Properties properties = new Properties();
		  properties.setProperty("user", "SA");
		  properties.setProperty("password", "");
		  properties.setProperty("shutdown", "true");
		  Connection connection = DriverManager.getConnection("jdbc:hsqldb:" + installDir + "project/" + this.o_projectFolderName + "/projectDB", properties);
		  if (!connection.AutoCommit)
		  {
			connection.commit();
		  }
		  if (this.o_sessionFactory != null)
		  {
			try
			{
			  currentSession().beginTransaction().commit();
			  closeSession();
			}
			catch (Exception exception)
			{
			  Console.WriteLine(exception.ToString());
			  Console.Write(exception.StackTrace);
			}
		  }
		  foreach (Session session in this.aliveSessions)
		  {
			if (session.Open)
			{
			  try
			  {
				if (session.Transaction != null && session.Transaction.Active)
				{
				  session.Transaction.commit();
				}
				session.flush();
			  }
			  catch (Exception exception)
			  {
				Console.WriteLine(exception.ToString());
				Console.Write(exception.StackTrace);
			  }
			  try
			  {
				session.close();
			  }
			  catch (Exception exception)
			  {
				Console.WriteLine(exception.ToString());
				Console.Write(exception.StackTrace);
			  }
			}
		  }
		  this.aliveSessions.Clear();
		  if (this.o_sessionFactory != null && !this.o_sessionFactory.Closed)
		  {
			try
			{
			  this.o_sessionFactory.close();
			}
			catch (Exception exception)
			{
			  Console.WriteLine(exception.ToString());
			  Console.Write(exception.StackTrace);
			}
		  }
		  this.o_session = null;
		  this.o_sessionFactory = null;
		  Statement statement = connection.createStatement();
		  statement.execute("SHUTDOWN");
		  statement.close();
		  connection.close();
		}
		catch (Exception exception)
		{
		  Console.WriteLine("Could not shutdown Database dont save Project:\n " + exception.Message);
		  throw exception;
		}
	  }

	  private class RunnableAnonymousInnerClass2 : ThreadStart
	  {
		  private readonly ProjectFileDBUtil outerInstance;

		  public RunnableAnonymousInnerClass2(ProjectFileDBUtil outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void run() throws Exception
		  public void run()
		  {
			try
			{
			  outerInstance.unloadDB();
			}
			catch (Exception exception)
			{
			  outerInstance.o_retException = exception;
			}
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void saveDB(java.io.File paramFile) throws Exception
	  public override void saveDB(File paramFile)
	  {
		File file1 = new File(installDir + "project" + File.separator + this.o_projectFolderName);
		File file2 = new File(file1, "projectDB.backup");
		if (!file1.exists())
		{
		  file1.mkdirs();
		}
		paramFile.createNewFile();
		if (this.b_isDBLoaded)
		{
		  unloadDB();
		  if (file2.exists())
		  {
			file2.delete();
		  }
		  zipDirectory(file1, paramFile);
		  try
		  {
			loadDB();
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine("Got Exception when reloading database so placing in new folder!" + exception.Message);
			this.o_projectFolderName = "" + DateTimeHelper.CurrentUnixTimeMillis();
			extractDBFile(paramFile);
			loadDB();
		  }
		}
		else
		{
		  if (file2.exists())
		  {
			file2.delete();
		  }
		  zipDirectory(file1, paramFile);
		}
		this.o_openedFile = paramFile;
	  }

	  public override bool hasOpenedSession()
	  {
		Session session = (Session)Session.get();
		return (session == null) ? false : session.Open;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.hibernate.Session currentSession() throws org.hibernate.HibernateException
	  public override Session currentSession()
	  {
		Session session = (Session)Session.get();
		if (session == null)
		{
		  session = SessionFactory.openSession(this.prjDBInterceptor);
		  Session.set(session);
		  this.aliveSessions.Add(session);
		}
		else if (!session.Open)
		{
		  closeSession();
		  session = null;
		  session = currentSession();
		}
		return session;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void closeSession() throws Exception
	  public override void closeSession()
	  {
		Session session = (Session)Session.get();
		closeSession(session);
		Session.set(null);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void closeSession(org.hibernate.Session paramSession) throws org.hibernate.HibernateException
	  public override void closeSession(Session paramSession)
	  {
		if (paramSession == null)
		{
		  return;
		}
		if (this.aliveSessions.Contains(paramSession))
		{
		  this.aliveSessions.Remove(paramSession);
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
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.List loadBulk(Class paramClass, System.Nullable<long>[] paramArrayOfLong) throws Exception
	  public override System.Collections.IList loadBulk(Type paramClass, long?[] paramArrayOfLong)
	  {
		List<object> arrayList = new List<object>(paramArrayOfLong.Length);
		Session session = currentSession();
		foreach (long? long in paramArrayOfLong)
		{
		  arrayList.Add(session.load(paramClass, long));
		}
		return arrayList;
	  }

	  public override string UniqueId
	  {
		  get
		  {
			  return (this.o_openedFile != null) ? (this.o_openedFile.AbsolutePath + ";" + ProjectUrlId) : this.o_projectFolderName;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void closeProject() throws Exception
	  public override void closeProject()
	  {
		if (this.b_isDBLoaded)
		{
		  unloadDB();
		}
		s_utilInstanceMap.Remove(UniqueId);
		File file = new File(installDir + "project" + File.separator + this.o_projectFolderName);
		deleteDirectory(file);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deleteProjectsFolder() throws Exception
	  public static void deleteProjectsFolder()
	  {
		File file = new File(installDir + "project");
		deleteDirectory(file);
	  }

	  private static bool deleteDirectory(File paramFile)
	  {
		if (paramFile.exists())
		{
		  File[] arrayOfFile = paramFile.listFiles();
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
		return paramFile.delete();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void zipDirectory(java.io.File paramFile1, java.io.File paramFile2) throws java.io.IOException, IllegalArgumentException
	  private void zipDirectory(File paramFile1, File paramFile2)
	  {
		if (!paramFile1.Directory)
		{
		  throw new System.ArgumentException("Compress: not a directory:  " + paramFile1);
		}
		ZipUtil.zip(paramFile1, new FileStream(paramFile2, FileMode.Create, FileAccess.Write), new ProgressCallbackAnonymousInnerClass(this));
	  }

	  private class ProgressCallbackAnonymousInnerClass : ProgressCallback
	  {
		  private readonly ProjectFileDBUtil outerInstance;

		  public ProgressCallbackAnonymousInnerClass(ProjectFileDBUtil outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

	  }

	  public override bool CollaborationMode
	  {
		  get
		  {
			  return false;
		  }
	  }

	  public override int DbmsType
	  {
		  get
		  {
			  return CEP_FILE;
		  }
	  }

	  public override ProjectUrlTable ProjectUrl
	  {
		  get
		  {
			if (this.urlTable != null)
			{
			  return this.urlTable;
			}
			ProjectUrlTable projectUrlTable = new ProjectUrlTable();
			projectUrlTable.Dbms = Convert.ToInt32(CEP_FILE);
			return projectUrlTable;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\ProjectFileDBUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}