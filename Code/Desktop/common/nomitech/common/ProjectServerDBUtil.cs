using System;
using System.Collections.Generic;
using System.Threading;

namespace Desktop.common.nomitech.common
{
	using ProjectGroupCodesProvider = Desktop.common.nomitech.common.@base.ProjectGroupCodesProvider;
	using ProjectGroupCodesProviderFactory = Desktop.common.nomitech.common.@base.ProjectGroupCodesProviderFactory;
	using ParamItemCache = Models.cache.ParamItemCache;
	using WBS2Cache = Models.cache.WBS2Cache;
	using WBSCache = Models.cache.WBSCache;
	using ProjectUrlTable = Models.local.ProjectUrlTable;
	using AddOnUtil = Desktop.common.nomitech.common.util.AddOnUtil;
	using CryptUtil = Desktop.common.nomitech.common.util.CryptUtil;
	using StringUtils = Desktop.common.nomitech.common.util.StringUtils;
	using HibernateException = org.hibernate.HibernateException;
	using Session = org.hibernate.Session;
	using SessionFactory = org.hibernate.SessionFactory;
	using Configuration = org.hibernate.cfg.Configuration;
	using StringType = org.hibernate.type.StringType;

	public class ProjectServerDBUtil : ProjectDBUtil
	{
	  private static URL configXML = null;

	  private SessionFactory o_sessionFactory = null;

	  private Configuration o_configuration = null;

	  private ThreadLocal o_session = null;

	  private ProjectDBProperties o_properties;

	  private bool b_isDBLoaded = false;

	  private Exception o_retException = null;

	  private IList<Session> aliveSessions = Collections.synchronizedList(new LinkedList());

	  private ProjectUrlTable o_urlTable;

	  private int dbmsType = 0;

	  private bool requiresAlters = true;

	  private ProjectGroupCodesProvider sharedGroupCodesProvider = null;

	  public override ProjectGroupCodesProvider ProjectGroupCodesProvider
	  {
		  get
		  {
			  return (this.sharedGroupCodesProvider == null) ? base.ProjectGroupCodesProvider : this.sharedGroupCodesProvider;
		  }
	  }

	  public static URL ConfigXML
	  {
		  set
		  {
			  configXML = value;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public ProjectServerDBUtil(Desktop.common.nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable, java.util.Properties paramProperties) throws Exception
	  public ProjectServerDBUtil(ProjectUrlTable paramProjectUrlTable, Properties paramProperties)
	  {
		if (configXML == null)
		{
		  configXML = this.GetType().getResource("projectDB.xml");
		}
		string str1 = paramProjectUrlTable.Hostname;
		string str2 = paramProjectUrlTable.Port;
		string str3 = paramProjectUrlTable.DatabaseName;
		int i = paramProjectUrlTable.Dbms.Value;
		string str4 = paramProjectUrlTable.DbmsName;
		string str5 = paramProjectUrlTable.Username;
		string str6 = paramProjectUrlTable.Password;
		string str7 = paramProjectUrlTable.Url;
		bool? @bool = paramProjectUrlTable.CreatesNewDatabases;
		long? long = paramProjectUrlTable.ProjectUrlId;
		ProjectUrlId = long;
		makeNewDB(str1, str2, str3, str7, i, str4, str5, str6, paramProperties, @bool);
		this.requiresAlters = @bool.Value;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public ProjectServerDBUtil(Desktop.common.nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable, Desktop.common.nomitech.common.base.ProjectGroupCodesProviderFactory paramProjectGroupCodesProviderFactory) throws Exception
	  public ProjectServerDBUtil(ProjectUrlTable paramProjectUrlTable, ProjectGroupCodesProviderFactory paramProjectGroupCodesProviderFactory)
	  {
		if (configXML == null)
		{
		  configXML = this.GetType().getResource("projectDB.xml");
		  Console.WriteLine("xml is " + configXML);
		}
		this.o_overridenFactory = paramProjectGroupCodesProviderFactory;
		ProjectUrlId = paramProjectUrlTable.ProjectUrlId;
		connectDB(paramProjectUrlTable);
	  }

	  public override bool DBLoaded
	  {
		  get
		  {
			  return this.b_isDBLoaded;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private Desktop.common.nomitech.common.db.local.ProjectUrlTable connectDB(Desktop.common.nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable) throws Exception
	  private ProjectUrlTable connectDB(ProjectUrlTable paramProjectUrlTable)
	  {
		initDriver(paramProjectUrlTable.Dbms.Value);
		if (paramProjectUrlTable.Dbms.Value == SQLSERVER_DBMS)
		{
		  if (!(s_providerFactory is nomitech.ces.utils.DummyProjectGroupCodesProviderFactory))
		  {
			this.requiresAlters = checkRequiresAltering(paramProjectUrlTable);
		  }
		  else
		  {
			this.requiresAlters = true;
		  }
		}
		this.o_urlTable = paramProjectUrlTable;
		loadDB();
		return paramProjectUrlTable;
	  }

	  private bool checkRequiresAltering(ProjectUrlTable paramProjectUrlTable)
	  {
		if (paramProjectUrlTable.CreatesNewDatabases != null && !paramProjectUrlTable.CreatesNewDatabases.Value)
		{
		  return false;
		}
		Session session = DatabaseDBUtil.currentSession();
		try
		{
		  string str1 = "SELECT PVAL as VER FROM  " + paramProjectUrlTable.DatabaseName + ".dbo.PRJPROP WHERE PKEY LIKE 'costos.estimating.version' and PRJID = " + ProjectUrlId;
		  string str2 = (string)session.createSQLQuery(str1).addScalar("VER", StringType.INSTANCE).uniqueResult();
		  if (string.ReferenceEquals(str2, null))
		  {
			DatabaseDBUtil.closeSession();
			return true;
		  }
		  if (StringUtils.checkEquality(str2, ProjectDBProperties.PROPERTIES_VERSION))
		  {
			DatabaseDBUtil.closeSession();
			return false;
		  }
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		DatabaseDBUtil.closeSession();
		return true;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private Desktop.common.nomitech.common.db.local.ProjectUrlTable makeNewDB(String paramString1, String paramString2, String paramString3, String paramString4, int paramInt, String paramString5, String paramString6, String paramString7, java.util.Properties paramProperties, System.Nullable<bool> paramBoolean) throws Exception
	  private ProjectUrlTable makeNewDB(string paramString1, string paramString2, string paramString3, string paramString4, int paramInt, string paramString5, string paramString6, string paramString7, Properties paramProperties, bool? paramBoolean)
	  {
		initDriver(paramInt);
		this.dbmsType = paramInt;
		string str1 = CryptUtil.Instance.decryptHexString(paramString6);
		string str2 = AddOnUtil.Instance.decryptHexString(paramString7);
		if (!StringUtils.isNullOrBlank(paramString5) && (paramBoolean == null || paramBoolean.Value == true))
		{
		  string str3 = null;
		  string str4 = null;
		  if (paramInt == ProjectDBUtil.MYSQL_DBMS)
		  {
			str3 = "CREATE DATABASE " + paramString3;
			str4 = "mysql";
		  }
		  else if (paramInt == ProjectDBUtil.SQLSERVER_DBMS)
		  {
			paramInt = ProjectDBUtil.SQLSERVER_DBMS;
			str3 = "CREATE DATABASE " + paramString3;
			str4 = "master";
		  }
		  else if (paramInt == ProjectDBUtil.ORACLE_DBMS)
		  {
			paramInt = ProjectDBUtil.ORACLE_DBMS;
			str3 = "CREATE DATABASE " + paramString3;
			str4 = "sys";
		  }
		  string str5 = createJdbcUrl(paramString1, str4, paramString2, paramInt);
		  Connection connection = null;
		  Statement statement = null;
		  try
		  {
			connection = DriverManager.getConnection(str5, str1, str2);
			statement = connection.createStatement();
		  }
		  catch (Exception)
		  {
			str5 = ProjectDBUtil.createJdbcUrl(paramString1, "CostOS", paramString2, paramInt);
			connection = DriverManager.getConnection(str5, str1, str2);
			statement = connection.createStatement();
		  }
		  try
		  {
			statement.executeUpdate(str3);
		  }
		  catch (Exception exception)
		  {
			if (exception.Message.IndexOf("exists") == -1)
			{
			  Console.WriteLine(exception.ToString());
			  Console.Write(exception.StackTrace);
			  statement.close();
			  connection.close();
			  throw exception;
			}
		  }
		  statement.close();
		  connection.close();
		}
		else
		{
		  Connection connection = DriverManager.getConnection(paramString4, str1, str2);
		  if (!connection.AutoCommit)
		  {
			connection.commit();
		  }
		  connection.close();
		}
		this.o_properties = new ProjectDBProperties(this, false);
		if (paramProperties != null)
		{
		  this.o_properties.Properties = paramProperties;
		}
		this.o_urlTable = new ProjectUrlTable();
		this.o_urlTable.Hostname = paramString1;
		this.o_urlTable.Port = paramString2;
		this.o_urlTable.Dbms = Convert.ToInt32(paramInt);
		this.o_urlTable.Username = paramString6;
		this.o_urlTable.Password = paramString7;
		this.o_urlTable.DbmsName = paramString5;
		this.o_urlTable.Url = paramString4;
		this.o_urlTable.DatabaseName = paramString3;
		this.o_urlTable.CreateDate = DateTime.Now;
		this.o_urlTable.CreateUserId = DatabaseDBUtil.Properties.UserId;
		this.o_urlTable.LastUpdate = this.o_urlTable.CreateDate;
		this.o_urlTable.CreateUserId = this.o_urlTable.CreateUserId;
		this.o_urlTable.Frozen = false;
		this.o_urlTable.CreatesNewDatabases = paramBoolean;
		return this.o_urlTable;
	  }

	  public override SessionFactory SessionFactory
	  {
		  get
		  {
			if (this.o_sessionFactory == null)
			{
			  throw new System.ArgumentException("Session Factory is not loaded!");
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
		  loadDB();
		  SwingUtilities.invokeAndWait(new RunnableAnonymousInnerClass(this));
		  if (this.o_retException != null)
		  {
			throw this.o_retException;
		  }
		  return;
		}
		closeSession();
		this.dbmsType = this.o_urlTable.Dbms.Value;
		if (this.requiresAlters)
		{
		  this.o_configuration = ProjectSessionFactoryBuilder.Instance.createConfigurationFromUrl(configXML, this.o_urlTable, ProjectGroupCodesProvider, this.requiresAlters, this.o_urlTable.TablePrefix);
		  long l = DateTimeHelper.CurrentUnixTimeMillis();
		  Console.WriteLine("  BUILDING SESSION FACTORY...");
		  this.o_sessionFactory = this.o_configuration.buildSessionFactory();
		  Console.WriteLine("DONE IN: " + ((DateTimeHelper.CurrentUnixTimeMillis() - l) / 1000L));
		}
		else
		{
		  if (ProjectSessionFactory.GroupCodesProvider == null)
		  {
			ProjectSessionFactory.UpGroupCodesProvider = s_providerFactory.createSharedFactory();
		  }
		  this.sharedGroupCodesProvider = (ProjectGroupCodesProvider)ProjectSessionFactory.GroupCodesProvider;
		  long l = DateTimeHelper.CurrentUnixTimeMillis();
		  Console.WriteLine("  GETTING SESSION FACTORY...");
		  this.o_configuration = ProjectSessionFactory.getConfiguration(this.dbmsType);
		  this.o_sessionFactory = ProjectSessionFactory.getSessionFactory(this.dbmsType);
		  Console.WriteLine("DONE IN: " + ((DateTimeHelper.CurrentUnixTimeMillis() - l) / 1000L));
		}
		currentSession();
		closeSession();
		this.b_isDBLoaded = true;
		ProjectDBUtil projectDBUtil;
		(projectDBUtil = ProjectDBUtil.currentProjectDBUtil()).CurrentProjectDBUtil = this;
		if (this.o_properties == null)
		{
		  this.o_properties = new ProjectDBProperties(this, true);
		}
		else
		{
		  this.o_properties.reloadProperties();
		}
		if (!string.ReferenceEquals(this.o_properties.PreviousVersion, null) && this.requiresAlters && !(s_providerFactory is nomitech.ces.utils.DummyProjectGroupCodesProviderFactory))
		{
		  updateNewerDatabase();
		}
		if (this.sharedGroupCodesProvider == null)
		{
		  ProjectGroupCodesProvider.initializeProjectCaches();
		}
		else
		{
		  ((WBSCache)Wbs1Cache).initCache();
		  ((WBS2Cache)Wbs2Cache).initCache();
		  try
		  {
			((ParamItemCache)ParamItemCache).initializeCache();
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		}
		ProjectVariableCache.initCache();
		ProjectDBUtil.CurrentProjectDBUtil = projectDBUtil;
	  }

	  private class RunnableAnonymousInnerClass : ThreadStart
	  {
		  private readonly ProjectServerDBUtil outerInstance;

		  public RunnableAnonymousInnerClass(ProjectServerDBUtil outerInstance)
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
		  if (DBLoaded)
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
		  this.b_isDBLoaded = false;
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
			this.o_sessionFactory.close();
		  }
		  this.o_session = null;
		  this.o_sessionFactory = null;
		}
		catch (Exception exception)
		{
		  Console.WriteLine("Could not shutdown Database dont save Project:\n " + exception.Message);
		  throw exception;
		}
	  }

	  private class RunnableAnonymousInnerClass2 : ThreadStart
	  {
		  private readonly ProjectServerDBUtil outerInstance;

		  public RunnableAnonymousInnerClass2(ProjectServerDBUtil outerInstance)
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
		  if (this.sharedGroupCodesProvider == null)
		  {
			session = SessionFactory.openSession(this.prjDBInterceptor);
		  }
		  else
		  {
			try
			{
			  Connection connection = ProjectSessionFactory.getConnection(this.o_urlTable.Url, this.o_urlTable.Username, this.o_urlTable.Password);
			  session = SessionFactory.openSession(connection, this.prjDBInterceptor);
			}
			catch (Exception exception)
			{
			  throw new HibernateException(exception);
			}
		  }
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
			  return this.o_urlTable.Url + ";" + ProjectUrlId;
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
	  }

	  public override ProjectUrlTable ProjectUrl
	  {
		  get
		  {
			this.o_urlTable.ProjectUrlId = ProjectUrlId;
			return this.o_urlTable;
		  }
	  }

	  public override bool CollaborationMode
	  {
		  get
		  {
			  return true;
		  }
	  }

	  public override int DbmsType
	  {
		  get
		  {
			  return this.dbmsType;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\ProjectServerDBUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}