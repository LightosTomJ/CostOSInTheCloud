using System;
using System.Collections.Generic;
using System.Threading;

namespace Desktop.common.nomitech.common.jmx
{
	using CostOSString256Type = nomitech.common.db.types.CostOSString256Type;
	using CostOSTextType = nomitech.common.db.types.CostOSTextType;
	using DummyCodeLevelType = nomitech.common.db.types.DummyCodeLevelType;
	using NotNullStringType = nomitech.common.db.types.NotNullStringType;
	using NotNullTextType = nomitech.common.db.types.NotNullTextType;
	using UnitAliasType = nomitech.common.db.types.UnitAliasType;
	using NamingUtil = nomitech.common.util.NamingUtil;
	using HibernateException = org.hibernate.HibernateException;
	using Interceptor = org.hibernate.Interceptor;
	using SessionFactory = org.hibernate.SessionFactory;
	using Configuration = org.hibernate.cfg.Configuration;
	using StatisticsService = org.hibernate.jmx.StatisticsService;
	using SchemaExport = org.hibernate.tool.hbm2ddl.SchemaExport;
	using DeploymentException = org.jboss.deployment.DeploymentException;
	using DeploymentInfo = org.jboss.deployment.DeploymentInfo;
	using ListenerInjector = org.jboss.hibernate.ListenerInjector;
	using Logger = org.jboss.logging.Logger;
	using RepositoryClassLoader = org.jboss.mx.loading.RepositoryClassLoader;
	using ServiceMBeanSupport = org.jboss.system.ServiceMBeanSupport;
	using Util = org.jboss.util.naming.Util;

	public class HibernateSearch : ServiceMBeanSupport, HibernateSearchMBean
	{
	  private static readonly Logger log = Logger.getLogger(typeof(HibernateSearch));

	  public const string SESSION_FACTORY_CREATE = "hibernate.sessionfactory.create";

	  public const string SESSION_FACTORY_DESTROY = "hibernate.sessionfactory.destroy";

	  private string datasourceName;

	  private string dialect;

	  private string defaultSchema;

	  private string defaultCatalog;

	  private bool? sqlCommentsEnabled;

	  private int? maxFetchDepth;

	  private int? jdbcFetchSize;

	  private int? jdbcBatchSize;

	  private bool? batchVersionedDataEnabled;

	  private bool? jdbcScrollableResultSetEnabled;

	  private bool? getGeneratedKeysEnabled;

	  private bool? streamsForBinaryEnabled;

	  private string hbm2ddlAuto;

	  private string querySubstitutions;

	  private bool? showSqlEnabled;

	  private string username;

	  private string password;

	  private bool? secondLevelCacheEnabled = true;

	  private bool? queryCacheEnabled;

	  private string cacheProviderClass;

	  private ObjectName deployedTreeCacheObjectName;

	  private bool? minimalPutsEnabled;

	  private string cacheRegionPrefix;

	  private bool? structuredCacheEntriesEnabled;

	  private bool? statGenerationEnabled;

	  private bool? reflectionOptimizationEnabled;

	  private string sessionFactoryName;

	  private string sessionFactoryInterceptor;

	  private string listenerInjector;

	  private URL harUrl;

	  private bool scanForMappingsEnabled = false;

	  private HashSet<object> archiveClasspathUrls = new HashSet<object>();

	  private HashSet<object> directoryClasspathUrls = new HashSet<object>();

	  private bool dirty = false;

	  private SessionFactory sessionFactory;

	  private Configuration configuration;

	  private DateTime runningSince;

	  private ObjectName hibernateStatisticsServiceName;

	  protected internal virtual void createService()
	  {
		log.trace("forcing bytecode provider -> javassist");
		System.setProperty("hibernate.bytecode.provider", "javassist");
	  }

	  public virtual void startService()
	  {
		log.debug("Hibernate MBean starting; " + this);
		if (this.sessionFactory != null)
		{
		  destroySessionFactory();
		}
		this.harUrl = determineHarUrl();
		if (this.harUrl != null)
		{
		  log.trace("starting in har deployment mode");
		  if (this.scanForMappingsEnabled)
		  {
			log.trace("scan for mappings was enabled");
			scanForMappings();
		  }
		}
		else
		{
		  log.trace("starting in non-har deployment mode");
		  scanForMappings();
		}
		buildSessionFactory();
	  }

	  public virtual void stopService()
	  {
		destroySessionFactory();
		this.archiveClasspathUrls.Clear();
		this.directoryClasspathUrls.Clear();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private java.net.URL determineHarUrl() throws Exception
	  private URL determineHarUrl()
	  {
		log.trace("Attempting to determine HarUrl...");
		DeploymentInfo deploymentInfo = DeploymentInfo;
		if (deploymentInfo == null)
		{
		  log.warn("Unable to locate deployment info [" + ServiceName + "]");
		  return null;
		}
		string str = deploymentInfo.url.File;
		log.trace("checking our deployment unit [" + str + "]");
		return (str.EndsWith(".har", StringComparison.Ordinal) || str.EndsWith(".har/", StringComparison.Ordinal)) ? deploymentInfo.url : null;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private final org.hibernate.cfg.Configuration buildConfiguration() throws Exception
	  private Configuration buildConfiguration()
	  {
		log.debug("Building SessionFactory; " + this);
		this.configuration = new Configuration();
		this.configuration.Properties.clear();
		this.configuration.setProperty("hibernate.connection.isolation", "1");
		this.configuration.registerTypeOverride(new UnitAliasType(null, "unit_alias"));
		this.configuration.setProperty("hibernate.search.indexing_strategy", "manual");
		this.configuration.setProperty("hibernate.search.autoregister_listeners", "false");
		this.configuration.setProperty("hibernate.temp.use_jdbc_metadata_defaults", "false");
		for (sbyte b = 1; b <= 9; b++)
		{
		  this.configuration.registerTypeOverride(new DummyCodeLevelType("dotted", b, "eps_level" + b + "_code"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType("dotted", b, "location_level" + b + "_code"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType("dotted", b, "paramitem_level" + b + "_code"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType("dotted", b, "eps_level" + b + "_title"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType("dotted", b, "wbs1_level" + b + "_title"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType("dotted", b, "wbs2_level" + b + "_title"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType("dotted", b, "location_level" + b + "_title"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType("dotted", b, "paramitem_level" + b + "_title"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs1_level" + b + "_item_code"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs2_level" + b + "_item_code"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs1_level" + b + "_code"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs2_level" + b + "_code"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs1_level" + b + "_qty"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs2_level" + b + "_qty"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs1_level" + b + "_unit"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs2_level" + b + "_unit"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode1_level" + b + "_code"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode2_level" + b + "_code"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode3_level" + b + "_code"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode4_level" + b + "_code"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode5_level" + b + "_code"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode6_level" + b + "_code"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode7_level" + b + "_code"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode8_level" + b + "_code"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode9_level" + b + "_code"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs1_level" + b + "_title"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs2_level" + b + "_title"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode1_level" + b + "_title"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode2_level" + b + "_title"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode3_level" + b + "_title"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode4_level" + b + "_title"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode5_level" + b + "_title"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode6_level" + b + "_title"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode7_level" + b + "_title"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode8_level" + b + "_title"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode9_level" + b + "_title"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs1_level" + b + "_description"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs2_level" + b + "_description"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode1_level" + b + "_description"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode2_level" + b + "_description"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode3_level" + b + "_description"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode4_level" + b + "_description"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode5_level" + b + "_description"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode6_level" + b + "_description"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode7_level" + b + "_description"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode8_level" + b + "_description"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode9_level" + b + "_description"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs1_level" + b + "_unit"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs2_level" + b + "_unit"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode1_level" + b + "_unit"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode2_level" + b + "_unit"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode3_level" + b + "_unit"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode4_level" + b + "_unit"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode5_level" + b + "_unit"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode6_level" + b + "_unit"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode7_level" + b + "_unit"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode8_level" + b + "_unit"));
		  this.configuration.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode9_level" + b + "_unit"));
		}
		Properties properties = new Properties();
		this.configuration.addProperties(properties);
		ListenerInjector listenerInjector1 = generateListenerInjectorInstance();
		if (listenerInjector1 != null)
		{
		  listenerInjector1.injectListeners(ServiceName, this.configuration);
		}
		if (!string.ReferenceEquals(this.dialect, null) && this.dialect.ToLower().IndexOf("oracle", StringComparison.Ordinal) != -1)
		{
		  this.configuration.registerTypeOverride(new NotNullStringType(), new string[] {"costos_string"});
		  this.configuration.registerTypeOverride(new NotNullTextType(), new string[] {"costos_text"});
		}
		else
		{
		  this.configuration.registerTypeOverride(new CostOSString256Type(), new string[] {"costos_string"});
		  this.configuration.registerTypeOverride(new CostOSTextType());
		}
		handleMappings(this.configuration);
		transferSettings(this.configuration.Properties);
		Interceptor interceptor = generateInterceptorInstance();
		if (interceptor != null)
		{
		  this.configuration.Interceptor = interceptor;
		}
		return this.configuration;
	  }

	  private void buildSessionFactory()
	  {
		Configuration configuration1 = buildConfiguration();
		this.sessionFactory = configuration1.buildSessionFactory();
		try
		{
		  if (this.sessionFactory.Statistics != null && this.sessionFactory.Statistics.StatisticsEnabled)
		  {
			string str = ServiceName.ToString();
			if (str.IndexOf("type=service", StringComparison.Ordinal) != -1)
			{
			  str = str.replaceAll("type=service", "type=stats");
			}
			else
			{
			  str = str + ",type=stats";
			}
			this.hibernateStatisticsServiceName = new ObjectName(str);
			StatisticsService statisticsService = new StatisticsService();
			statisticsService.SessionFactory = this.sessionFactory;
			Server.registerMBean(statisticsService, this.hibernateStatisticsServiceName);
		  }
		  bind();
		}
		catch (Exception exception)
		{
		  forceCleanup();
		  throw exception;
		}
		this.dirty = false;
		sendNotification(new Notification("hibernate.sessionfactory.create", ServiceName, NextNotificationSequenceNumber));
		this.runningSince = DateTime.Now;
		log.info("SessionFactory successfully built and bound into JNDI [" + this.sessionFactoryName + "]");
	  }

	  private void destroySessionFactory()
	  {
		if (this.sessionFactory != null)
		{
		  unbind();
		  this.sessionFactory.close();
		  this.sessionFactory = null;
		  this.configuration = null;
		  this.runningSince = null;
		  if (this.hibernateStatisticsServiceName != null)
		  {
			try
			{
			  Server.unregisterMBean(this.hibernateStatisticsServiceName);
			}
			catch (Exception throwable)
			{
			  log.warn("unable to cleanup statistics mbean", throwable);
			}
		  }
		  sendNotification(new Notification("hibernate.sessionfactory.destroy", ServiceName, NextNotificationSequenceNumber));
		}
	  }

	  private void handleMappings(Configuration paramConfiguration)
	  {
		if (this.harUrl != null && !this.scanForMappingsEnabled)
		{
		  File file = new File(this.harUrl.File);
		  if (file.Directory)
		  {
			paramConfiguration.addDirectory(file);
		  }
		  else
		  {
			paramConfiguration.addJar(file);
		  }
		}
		foreach (File file in this.archiveClasspathUrls)
		{
		  log.debug("Passing archive [" + file + "] to Hibernate Configration");
		  paramConfiguration.addJar(file);
		}
		foreach (File file in this.directoryClasspathUrls)
		{
		  log.debug("Passing directory [" + file + "] to Hibernate Configration");
		  paramConfiguration.addDirectory(file);
		}
	  }

	  private void scanForMappings()
	  {
		URL[] arrayOfURL = null;
		ClassLoader classLoader = Thread.CurrentThread.ContextClassLoader;
		if (classLoader is RepositoryClassLoader)
		{
		  arrayOfURL = ((RepositoryClassLoader)classLoader).Classpath;
		}
		else if (classLoader is URLClassLoader)
		{
		  arrayOfURL = ((URLClassLoader)classLoader).URLs;
		}
		else
		{
		  throw new DeploymentException("Unable to determine urls from classloader [" + classLoader + "]");
		}
		for (sbyte b = 0; b < arrayOfURL.Length; b++)
		{
		  File file = new File(arrayOfURL[b].File);
		  log.trace("checking classpath entry [" + file + "]");
		  if (file.exists())
		  {
			if (!file.Directory)
			{
			  if (isArchive(file))
			  {
				log.trace("classpath entry was an archive file...");
				this.archiveClasspathUrls.Add(file);
			  }
			  else
			  {
				log.trace("classpath entry was a non-archive file...");
			  }
			}
			else
			{
			  log.trace("classpath entry was a directory...");
			  this.directoryClasspathUrls.Add(file);
			}
		  }
		}
	  }

	  private bool isArchive(File paramFile)
	  {
		try
		{
		  JarFile jarFile = new JarFile(paramFile);
		  jarFile.close();
		  return true;
		}
		catch (Exception)
		{
		  return false;
		}
	  }

	  public virtual void createSchema()
	  {
		  (new SchemaExport(buildConfiguration())).create(false, true);
	  }

	  public virtual void dropSchema()
	  {
		  (new SchemaExport(buildConfiguration())).drop(false, true);
	  }

	  private void transferSettings(Properties paramProperties)
	  {
		if (string.ReferenceEquals(this.cacheProviderClass, null))
		{
		  this.cacheProviderClass = "org.hibernate.cache.HashtableCacheProvider";
		}
		log.debug("Using JDBC batch size : " + this.jdbcBatchSize);
		setUnlessNull(paramProperties, "hibernate.connection.datasource", this.datasourceName);
		setUnlessNull(paramProperties, "hibernate.dialect", this.dialect);
		setUnlessNull(paramProperties, "hibernate.cache.provider_class", this.cacheProviderClass);
		setUnlessNull(paramProperties, "hibernate.cache.region_prefix", this.cacheRegionPrefix);
		setUnlessNull(paramProperties, "hibernate.cache.use_minimal_puts", this.minimalPutsEnabled);
		setUnlessNull(paramProperties, "hibernate.hbm2ddl.auto", this.hbm2ddlAuto);
		setUnlessNull(paramProperties, "hibernate.default_schema", this.defaultSchema);
		setUnlessNull(paramProperties, "hibernate.jdbc.batch_size", this.jdbcBatchSize);
		setUnlessNull(paramProperties, "hibernate.use_sql_comments", this.sqlCommentsEnabled);
		setUnlessNull(paramProperties, "hibernate.jdbc.fetch_size", this.jdbcFetchSize);
		setUnlessNull(paramProperties, "hibernate.jdbc.use_scrollable_resultset", this.jdbcScrollableResultSetEnabled);
		setUnlessNull(paramProperties, "hibernate.cache.use_query_cache", this.queryCacheEnabled);
		setUnlessNull(paramProperties, "hibernate.cache.use_structured_entries", this.structuredCacheEntriesEnabled);
		setUnlessNull(paramProperties, "hibernate.query.substitutions", this.querySubstitutions);
		setUnlessNull(paramProperties, "hibernate.max_fetch_depth", this.maxFetchDepth);
		setUnlessNull(paramProperties, "hibernate.show_sql", this.showSqlEnabled);
		setUnlessNull(paramProperties, "hibernate.jdbc.use_get_generated_keys", this.getGeneratedKeysEnabled);
		setUnlessNull(paramProperties, "hibernate.connection.username", this.username);
		setUnlessNull(paramProperties, "hibernate.connection.password", this.password);
		setUnlessNull(paramProperties, "hibernate.jdbc.batch_versioned_data", this.batchVersionedDataEnabled);
		setUnlessNull(paramProperties, "hibernate.jdbc.use_streams_for_binary", this.streamsForBinaryEnabled);
		setUnlessNull(paramProperties, "hibernate.bytecode.use_reflection_optimizer", this.reflectionOptimizationEnabled);
		setUnlessNull(paramProperties, "hibernate.generate_statistics", this.statGenerationEnabled);
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		setUnlessNull(paramProperties, "hibernate.transaction.manager_lookup_class", typeof(org.hibernate.transaction.JBossTransactionManagerLookup).FullName);
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		setUnlessNull(paramProperties, "hibernate.transaction.factory_class", typeof(org.hibernate.transaction.JTATransactionFactory).FullName);
		if (this.deployedTreeCacheObjectName != null)
		{
		  string str = this.deployedTreeCacheObjectName.ToString();
		  if (!string.ReferenceEquals(str, null) && !"".Equals(str))
		  {
			paramProperties.setProperty("hibernate.treecache.objectName", str);
		  }
		}
		paramProperties.setProperty("hibernate.transaction.flush_before_completion", "true");
		paramProperties.setProperty("hibernate.transaction.auto_close_session", "true");
		paramProperties.setProperty("hibernate.connection.agressive_release", "true");
		paramProperties.setProperty("hibernate.connection.release_mode", "after_statement");
	  }

	  private void setUnlessNull(Properties paramProperties, string paramString, object paramObject)
	  {
		if (paramObject != null)
		{
		  paramProperties.setProperty(paramString, paramObject.ToString());
		}
	  }

	  private ListenerInjector generateListenerInjectorInstance()
	  {
		if (string.ReferenceEquals(this.listenerInjector, null))
		{
		  return null;
		}
		log.info("attempting to use listener injector [" + this.listenerInjector + "]");
		try
		{
		  return (ListenerInjector)Thread.CurrentThread.ContextClassLoader.loadClass(this.listenerInjector).newInstance();
		}
		catch (Exception throwable)
		{
		  log.warn("Unable to generate specified listener injector", throwable);
		  return null;
		}
	  }

	  private Interceptor generateInterceptorInstance()
	  {
		if (string.ReferenceEquals(this.sessionFactoryInterceptor, null))
		{
		  return null;
		}
		log.info("Generating session factory interceptor instance [" + this.sessionFactoryInterceptor + "]");
		try
		{
		  return (Interceptor)Thread.CurrentThread.ContextClassLoader.loadClass(this.sessionFactoryInterceptor).newInstance();
		}
		catch (Exception throwable)
		{
		  log.warn("Unable to generate session factory interceptor instance", throwable);
		  return null;
		}
	  }

	  private void bind()
	  {
		context = null;
		try
		{
		  context = NamingUtil.Instance.createInitialContext(false);
		  Util.bind(context, this.sessionFactoryName, this.sessionFactory);
		  Util.bind(context, "hibernate/Configuration", this.configuration);
		}
		catch (NamingException namingException)
		{
		  throw new HibernateException("Unable to bind SessionFactory into JNDI", namingException);
		}
		finally
		{
		  if (context != null)
		  {
			try
			{
			  context.close();
			}
			catch (Exception)
			{
			}
		  }
		}
	  }

	  private void unbind()
	  {
		initialContext = null;
		try
		{
		  initialContext = new InitialContext();
		  Util.unbind(initialContext, this.sessionFactoryName);
		  Util.unbind(initialContext, "hibernate/Configuration");
		}
		catch (NamingException namingException)
		{
		  throw new HibernateException("Unable to unbind SessionFactory from JNDI", namingException);
		}
		finally
		{
		  if (initialContext != null)
		  {
			try
			{
			  initialContext.close();
			}
			catch (Exception)
			{
			}
		  }
		}
	  }

	  private void forceCleanup()
	  {
		try
		{
		  this.sessionFactory.close();
		  this.sessionFactory = null;
		}
		catch (Exception)
		{
		}
	  }

	  public override string ToString()
	  {
		  return base.ToString() + " [ServiceName=" + this.serviceName + ", JNDI=" + this.sessionFactoryName + "]";
	  }

	  public virtual void rebuildSessionFactory()
	  {
		destroySessionFactory();
		buildSessionFactory();
	  }

	  public virtual bool Dirty
	  {
		  get
		  {
			  return this.dirty;
		  }
	  }

	  public virtual bool SessionFactoryRunning
	  {
		  get
		  {
			  return (this.sessionFactory != null);
		  }
	  }

	  public virtual string Version
	  {
		  get
		  {
			  return "3.6.10";
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.hibernate.cfg.Configuration getConfiguration() throws Exception
	  public virtual Configuration Configuration
	  {
		  get
		  {
			  return this.configuration;
		  }
	  }

	  public virtual SessionFactory Instance
	  {
		  get
		  {
			  return this.sessionFactory;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.net.URL getHarUrl() throws Exception
	  public virtual URL HarUrl
	  {
		  get
		  {
			  return this.harUrl;
		  }
	  }

	  public virtual ObjectName StatisticsServiceName
	  {
		  get
		  {
			  return this.hibernateStatisticsServiceName;
		  }
	  }

	  public virtual DateTime RunningSince
	  {
		  get
		  {
			  return this.runningSince;
		  }
	  }

	  public virtual string SessionFactoryName
	  {
		  get
		  {
			  return this.sessionFactoryName;
		  }
		  set
		  {
			this.sessionFactoryName = value;
			this.dirty = true;
		  }
	  }


	  public virtual string DatasourceName
	  {
		  get
		  {
			  return this.datasourceName;
		  }
		  set
		  {
			this.datasourceName = value;
			this.dirty = true;
		  }
	  }


	  public virtual string Username
	  {
		  get
		  {
			  return this.username;
		  }
		  set
		  {
			this.username = value;
			this.dirty = true;
		  }
	  }


	  public virtual string Password
	  {
		  set
		  {
			this.password = value;
			this.dirty = true;
		  }
	  }

	  public virtual string DefaultSchema
	  {
		  get
		  {
			  return this.defaultSchema;
		  }
		  set
		  {
			this.defaultSchema = value;
			this.dirty = true;
		  }
	  }


	  public virtual string DefaultCatalog
	  {
		  get
		  {
			  return this.defaultCatalog;
		  }
		  set
		  {
			  this.defaultCatalog = value;
		  }
	  }


	  public virtual string Hbm2ddlAuto
	  {
		  get
		  {
			  return this.hbm2ddlAuto;
		  }
		  set
		  {
			this.hbm2ddlAuto = value;
			this.dirty = true;
		  }
	  }


	  public virtual string Dialect
	  {
		  get
		  {
			  return this.dialect;
		  }
		  set
		  {
			this.dialect = value;
			this.dirty = true;
		  }
	  }


	  public virtual int? MaxFetchDepth
	  {
		  get
		  {
			  return this.maxFetchDepth;
		  }
		  set
		  {
			this.maxFetchDepth = value;
			this.dirty = true;
		  }
	  }


	  public virtual int? JdbcBatchSize
	  {
		  get
		  {
			  return this.jdbcBatchSize;
		  }
		  set
		  {
			this.jdbcBatchSize = value;
			this.dirty = true;
		  }
	  }


	  public virtual int? JdbcFetchSize
	  {
		  get
		  {
			  return this.jdbcFetchSize;
		  }
		  set
		  {
			this.jdbcFetchSize = value;
			this.dirty = true;
		  }
	  }


	  public virtual bool? JdbcScrollableResultSetEnabled
	  {
		  get
		  {
			  return this.jdbcScrollableResultSetEnabled;
		  }
		  set
		  {
			this.jdbcScrollableResultSetEnabled = value;
			this.dirty = true;
		  }
	  }


	  public virtual bool? GetGeneratedKeysEnabled
	  {
		  get
		  {
			  return this.getGeneratedKeysEnabled;
		  }
		  set
		  {
			this.getGeneratedKeysEnabled = value;
			this.dirty = true;
		  }
	  }


	  public virtual string QuerySubstitutions
	  {
		  get
		  {
			  return this.querySubstitutions;
		  }
		  set
		  {
			this.querySubstitutions = value;
			this.dirty = true;
		  }
	  }


	  public virtual bool? SecondLevelCacheEnabled
	  {
		  get
		  {
			  return this.secondLevelCacheEnabled;
		  }
		  set
		  {
			this.secondLevelCacheEnabled = value;
			this.dirty = true;
		  }
	  }


	  public virtual bool? QueryCacheEnabled
	  {
		  get
		  {
			  return this.queryCacheEnabled;
		  }
		  set
		  {
			this.queryCacheEnabled = value;
			this.dirty = true;
		  }
	  }


	  public virtual string CacheProviderClass
	  {
		  get
		  {
			  return this.cacheProviderClass;
		  }
		  set
		  {
			this.cacheProviderClass = value;
			this.dirty = true;
		  }
	  }


	  public virtual string CacheRegionPrefix
	  {
		  get
		  {
			  return this.cacheRegionPrefix;
		  }
		  set
		  {
			this.cacheRegionPrefix = value;
			this.dirty = true;
		  }
	  }


	  public virtual bool? MinimalPutsEnabled
	  {
		  get
		  {
			  return this.minimalPutsEnabled;
		  }
		  set
		  {
			this.minimalPutsEnabled = value;
			this.dirty = true;
		  }
	  }


	  public virtual bool? UseStructuredCacheEntriesEnabled
	  {
		  get
		  {
			  return this.structuredCacheEntriesEnabled;
		  }
		  set
		  {
			  this.structuredCacheEntriesEnabled = value;
		  }
	  }


	  public virtual bool? ShowSqlEnabled
	  {
		  get
		  {
			  return this.showSqlEnabled;
		  }
		  set
		  {
			this.showSqlEnabled = value;
			this.dirty = true;
		  }
	  }


	  public virtual bool? SqlCommentsEnabled
	  {
		  get
		  {
			  return this.sqlCommentsEnabled;
		  }
		  set
		  {
			  this.sqlCommentsEnabled = value;
		  }
	  }


	  public virtual string SessionFactoryInterceptor
	  {
		  get
		  {
			  return this.sessionFactoryInterceptor;
		  }
		  set
		  {
			this.sessionFactoryInterceptor = value;
			this.dirty = true;
		  }
	  }


	  public virtual string ListenerInjector
	  {
		  get
		  {
			  return this.listenerInjector;
		  }
		  set
		  {
			  this.listenerInjector = value;
		  }
	  }


	  public virtual ObjectName DeployedTreeCacheObjectName
	  {
		  get
		  {
			  return this.deployedTreeCacheObjectName;
		  }
		  set
		  {
			  this.deployedTreeCacheObjectName = value;
		  }
	  }


	  public virtual bool? BatchVersionedDataEnabled
	  {
		  get
		  {
			  return this.batchVersionedDataEnabled;
		  }
		  set
		  {
			this.batchVersionedDataEnabled = value;
			this.dirty = true;
		  }
	  }


	  public virtual bool? StreamsForBinaryEnabled
	  {
		  get
		  {
			  return this.streamsForBinaryEnabled;
		  }
		  set
		  {
			this.streamsForBinaryEnabled = value;
			this.dirty = true;
		  }
	  }


	  public virtual bool? ReflectionOptimizationEnabled
	  {
		  get
		  {
			  return this.reflectionOptimizationEnabled;
		  }
		  set
		  {
			this.reflectionOptimizationEnabled = value;
			this.dirty = true;
		  }
	  }


	  public virtual bool? StatGenerationEnabled
	  {
		  get
		  {
			  return this.statGenerationEnabled;
		  }
		  set
		  {
			  this.statGenerationEnabled = value;
		  }
	  }


	  public virtual bool ScanForMappingsEnabled
	  {
		  get
		  {
			  return this.scanForMappingsEnabled;
		  }
		  set
		  {
			  this.scanForMappingsEnabled = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\jmx\HibernateSearch.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}