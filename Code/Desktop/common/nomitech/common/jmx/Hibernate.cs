using System;

namespace Desktop.common.nomitech.common.jmx
{
	using CostOSString256Type = nomitech.common.db.types.CostOSString256Type;
	using CostOSTextType = nomitech.common.db.types.CostOSTextType;
	using DummyCodeLevelType = nomitech.common.db.types.DummyCodeLevelType;
	using NotNullStringType = nomitech.common.db.types.NotNullStringType;
	using NotNullTextType = nomitech.common.db.types.NotNullTextType;
	using UnitAliasType = nomitech.common.db.types.UnitAliasType;
	using NamingUtil = nomitech.common.util.NamingUtil;
	using Logger = org.apache.log4j.Logger;
	using HibernateException = org.hibernate.HibernateException;
	using SessionFactory = org.hibernate.SessionFactory;
	using Configuration = org.hibernate.cfg.Configuration;
	using Session = org.hibernate.classic.Session;

	public class Hibernate : HibernateMBean
	{
	  protected internal readonly Logger log = Logger.getLogger(this.GetType());

	  private Properties properties;

	  private string dataSourceName;

	  private string dialect;

	  private string sessionFactoryName;

	  private string cacheProviderClass;

	  private string hbm2ddlAuto;

	  private string showSqlEnabled;

	  private Configuration configuration;

	  private SessionFactory sessionFactory;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @PostConstruct public void postConstruct()
	  public virtual void postConstruct()
	  {
		string str1 = this.properties.getProperty("code");
		string str2 = this.properties.getProperty("name");
		requireNotNull(str1);
		requireNotNull(str2);
		try
		{
		  MBeanServer mBeanServer = ManagementFactory.PlatformMBeanServer;
		  ObjectName objectName = new ObjectName(str2);
		  mBeanServer.registerMBean(this, objectName);
		}
		catch (MalformedObjectNameException malformedObjectNameException)
		{
		  this.log.error("Malformed MBean name: " + str2);
		  throw new MBeanRegistrationException(malformedObjectNameException);
		}
		catch (InstanceAlreadyExistsException instanceAlreadyExistsException)
		{
		  this.log.error("Instance already exists: " + str2);
		  throw new MBeanRegistrationException(instanceAlreadyExistsException);
		}
		catch (NotCompliantMBeanException notCompliantMBeanException)
		{
		  this.log.error("Class is not a valid MBean: " + str1);
		  throw new MBeanRegistrationException(notCompliantMBeanException);
		}
		catch (MBeanRegistrationException mBeanRegistrationException)
		{
		  this.log.error("Error registering " + str2 + ", " + str1);
		  throw new MBeanRegistrationException(mBeanRegistrationException);
		}
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @PreDestroy public void preDestroy()
	  public virtual void preDestroy()
	  {
		string str = this.properties.getProperty("name");
		try
		{
		  MBeanServer mBeanServer = ManagementFactory.PlatformMBeanServer;
		  ObjectName objectName = new ObjectName(str);
		  mBeanServer.unregisterMBean(objectName);
		}
		catch (MalformedObjectNameException malformedObjectNameException)
		{
		  this.log.error("Malformed MBean name: " + str);
		  throw new MBeanRegistrationException(malformedObjectNameException);
		}
		catch (MBeanRegistrationException mBeanRegistrationException)
		{
		  this.log.error("Error unregistering " + str);
		  throw new MBeanRegistrationException(mBeanRegistrationException);
		}
		catch (InstanceNotFoundException instanceNotFoundException)
		{
		  this.log.error("Error unregistering " + str);
		  throw new MBeanRegistrationException(instanceNotFoundException);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void requireNotNull(String paramString) throws javax.management.MBeanRegistrationException
	  private void requireNotNull(string paramString)
	  {
		if (string.ReferenceEquals(paramString, null))
		{
		  throw new MBeanRegistrationException(new System.ArgumentException(), "code property not specified, stopping");
		}
	  }

	  public virtual Properties Properties
	  {
		  get
		  {
			  return this.properties;
		  }
		  set
		  {
			  this.properties = value;
		  }
	  }


	  public virtual string DatasourceName
	  {
		  get
		  {
			  return this.dataSourceName;
		  }
		  set
		  {
			  this.dataSourceName = value;
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
		  }
	  }


	  public virtual string ShowSqlEnabled
	  {
		  get
		  {
			  return this.showSqlEnabled;
		  }
		  set
		  {
			  this.showSqlEnabled = value;
		  }
	  }


//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private javax.naming.Context getInitialContext() throws Exception
	  private Context InitialContext
	  {
		  get
		  {
			  return NamingUtil.Instance.createInitialContext(false);
		  }
	  }

	  public virtual void start()
	  {
		this.configuration = buildConfiguration();
		this.sessionFactory = this.configuration.buildSessionFactory();
		bind();
		SessionFactory sessionFactory1 = this.sessionFactory;
		Session session = sessionFactory1.openSession();
		session.flush();
		session.close();
		logDebug("Done binding SessionFactory");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private final org.hibernate.cfg.Configuration buildConfiguration() throws Exception
	  private Configuration buildConfiguration()
	  {
		logDebug("Building SessionFactory; " + this);
		Configuration configuration1 = null;
		configuration1 = new Configuration();
		configuration1.Properties.clear();
		configuration1.addDirectory(new File(NamingUtil.Instance.getHarPath("")));
		configuration1.registerTypeOverride(new UnitAliasType(null, "unit_alias"));
		configuration1.setProperty("hibernate.search.indexing_strategy", "manual");
		configuration1.setProperty("hibernate.search.autoregister_listeners", "false");
		configuration1.setProperty("hibernate.temp.use_jdbc_metadata_defaults", "false");
		for (sbyte b = 1; b <= 9; b++)
		{
		  configuration1.registerTypeOverride(new DummyCodeLevelType("dotted", b, "eps_level" + b + "_code"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType("dotted", b, "location_level" + b + "_code"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType("dotted", b, "paramitem_level" + b + "_code"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType("dotted", b, "eps_level" + b + "_title"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType("dotted", b, "wbs1_level" + b + "_title"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType("dotted", b, "wbs2_level" + b + "_title"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType("dotted", b, "location_level" + b + "_title"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType("dotted", b, "paramitem_level" + b + "_title"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs1_level" + b + "_item_code"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs2_level" + b + "_item_code"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs1_level" + b + "_code"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs2_level" + b + "_code"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs1_level" + b + "_qty"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs2_level" + b + "_qty"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs1_level" + b + "_unit"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs2_level" + b + "_unit"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode1_level" + b + "_code"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode2_level" + b + "_code"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode3_level" + b + "_code"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode4_level" + b + "_code"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode5_level" + b + "_code"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode6_level" + b + "_code"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode7_level" + b + "_code"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode8_level" + b + "_code"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode9_level" + b + "_code"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs1_level" + b + "_title"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs2_level" + b + "_title"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode1_level" + b + "_title"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode2_level" + b + "_title"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode3_level" + b + "_title"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode4_level" + b + "_title"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode5_level" + b + "_title"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode6_level" + b + "_title"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode7_level" + b + "_title"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode8_level" + b + "_title"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode9_level" + b + "_title"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs1_level" + b + "_description"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs2_level" + b + "_description"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode1_level" + b + "_description"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode2_level" + b + "_description"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode3_level" + b + "_description"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode4_level" + b + "_description"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode5_level" + b + "_description"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode6_level" + b + "_description"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode7_level" + b + "_description"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode8_level" + b + "_description"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode9_level" + b + "_description"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs1_level" + b + "_unit"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "wbs2_level" + b + "_unit"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode1_level" + b + "_unit"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode2_level" + b + "_unit"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode3_level" + b + "_unit"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode4_level" + b + "_unit"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode5_level" + b + "_unit"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode6_level" + b + "_unit"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode7_level" + b + "_unit"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode8_level" + b + "_unit"));
		  configuration1.registerTypeOverride(new DummyCodeLevelType(null, null, b, "groupcode9_level" + b + "_unit"));
		}
		Properties properties1 = new Properties();
		configuration1.addProperties(properties1);
		if (!string.ReferenceEquals(this.dialect, null) && this.dialect.ToLower().IndexOf("oracle", StringComparison.Ordinal) != -1)
		{
		  configuration1.registerTypeOverride(new NotNullStringType(), new string[] {"costos_string"});
		  configuration1.registerTypeOverride(new NotNullTextType(), new string[] {"costos_text"});
		}
		else
		{
		  configuration1.registerTypeOverride(new CostOSString256Type(), new string[] {"costos_string"});
		  configuration1.registerTypeOverride(new CostOSTextType());
		}
		transferSettings(configuration1.Properties);
		return configuration1;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void logDebug(String paramString) throws javax.management.MBeanRegistrationException
	  private void logDebug(string paramString)
	  {
		  Console.WriteLine(paramString);
	  }

	  private void transferSettings(Properties paramProperties)
	  {
		if (string.ReferenceEquals(this.cacheProviderClass, null))
		{
		  this.cacheProviderClass = "org.hibernate.cache.HashtableCacheProvider";
		}
		setUnlessNull(paramProperties, "hibernate.connection.datasource", this.dataSourceName);
		setUnlessNull(paramProperties, "hibernate.dialect", this.dialect);
		setUnlessNull(paramProperties, "hibernate.cache.provider_class", this.cacheProviderClass);
		setUnlessNull(paramProperties, "hibernate.hbm2ddl.auto", this.hbm2ddlAuto);
		setUnlessNull(paramProperties, "hibernate.show_sql", this.showSqlEnabled);
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

	  private void bind()
	  {
		context = null;
		try
		{
		  context = InitialContext;
		  name = context.getNameParser("").parse(this.sessionFactoryName);
		  context.bind(name, this.sessionFactory);
		  name = context.getNameParser("").parse("hibernate/Configuration");
		  context.bind(name, this.configuration);
		}
		catch (Exception exception)
		{
		  throw new HibernateException("Unable to bind SessionFactory into JNDI", exception);
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
		context = null;
		try
		{
		  context = InitialContext;
		  name = context.getNameParser("").parse(this.sessionFactoryName);
		  context.unbind(name);
		}
		catch (Exception exception)
		{
		  throw new HibernateException("Unable to unbind SessionFactory from JNDI", exception);
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

	  public virtual void stop()
	  {
		unbind();
		this.sessionFactory.close();
		this.sessionFactory = null;
		this.configuration = null;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\jmx\Hibernate.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}