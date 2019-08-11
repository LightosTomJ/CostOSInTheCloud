using System;

namespace Desktop.common.nomitech.common.util
{
	using MBeanServerLocator = org.jboss.mx.util.MBeanServerLocator;

	public class NamingUtil
	{
	  private static int EJB_PORT = 1099;

	  private static int JMS_PORT = 8080;

	  private const sbyte jboss_APPSERVER = 1;

	  private const sbyte tomee_APPSERVER = 2;

	  private static NamingUtil s_instance;

	  private static sbyte appServer = 0;

	  private string jndiPrefix = null;

	  private string jndiResourcePrefix = null;

	  private string sarPathPrefix = null;

	  private string harPathPrefix = null;

	  private string warPathPrefix = null;

	  public static string extractRMIHost(string paramString)
	  {
		  return (paramString.IndexOf(":", StringComparison.Ordinal) != -1) ? (paramString.Substring(0, paramString.IndexOf(":", StringComparison.Ordinal)) + ":" + EJB_PORT) : (paramString + ":" + EJB_PORT);
	  }

	  public static string extractActiveMQHost(string paramString)
	  {
		if (paramString.StartsWith("http", StringComparison.Ordinal))
		{
		  paramString = StringUtils.replaceAll(paramString, "http://", "");
		  paramString = StringUtils.replaceAll(paramString, "https://", "");
		}
		return (paramString.IndexOf(":", StringComparison.Ordinal) != -1) ? (paramString.Substring(0, paramString.IndexOf(":", StringComparison.Ordinal)) + ":" + JMS_PORT) : (paramString + ":" + JMS_PORT);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void tryDetectAppServer(String paramString) throws Exception
	  public static void tryDetectAppServer(string paramString)
	  {
		if (!paramString.StartsWith("http://", StringComparison.Ordinal) && !paramString.StartsWith("https://", StringComparison.Ordinal))
		{
		  paramString = "http://" + paramString;
		}
		string str1 = paramString + "/ces/info/serverInfo.action";
		Properties properties = HTTPUtil.getPropertiesURL(str1, null, null);
		string str2 = (string)properties.get("appserver.name");
		if (string.ReferenceEquals(str2, null))
		{
		  throw new IllegalStateException("appserver is not defined in zdb.properties, possibly server is not updated");
		}
		if (str2.Equals("tomee"))
		{
		  appServer = 2;
		}
		else if (str2.Equals("jboss"))
		{
		  appServer = 1;
		}
		else
		{
		  throw new IllegalStateException("invalid appserver: " + str2);
		}
		EJB_PORT = int.Parse((string)properties.get("appserver.ejbPort"));
		JMS_PORT = int.Parse((string)properties.get("appserver.jmsPort"));
		s_instance = null;
	  }

	  private NamingUtil()
	  {
		if (appServer == 0)
		{
		  File file1 = new File("../server/default/deploy/ces.ear");
		  File file2 = new File("../apps/ces.ear");
		  if (file2.exists() && file2.Directory)
		  {
			appServer = 2;
		  }
		  else if (file1.exists() && file1.Directory)
		  {
			appServer = 1;
		  }
		  else
		  {
			appServer = 2;
		  }
		}
		if (appServer == 2)
		{
		  this.jndiPrefix = "openejb:/";
		  this.jndiResourcePrefix = "openejb:Resource/";
		  this.sarPathPrefix = "../apps/ces.ear/ces.sar/";
		  this.harPathPrefix = "../apps/ces.ear/ces.har/";
		  this.warPathPrefix = "../apps/ces.ear/ces/";
		}
		else if (appServer == 1)
		{
		  this.sarPathPrefix = "../server/default/deploy/ces.ear/ces.sar/";
		  this.warPathPrefix = "../server/default/deploy/ces.ear/ces.war/";
		  this.harPathPrefix = "../server/default/deploy/ces.ear/ces.har/";
		}
	  }

	  public virtual string getSarPath(string paramString)
	  {
		  return (!string.ReferenceEquals(this.sarPathPrefix, null)) ? (this.sarPathPrefix + paramString) : paramString;
	  }

	  public virtual string getHarPath(string paramString)
	  {
		  return (!string.ReferenceEquals(this.harPathPrefix, null)) ? (this.harPathPrefix + paramString) : paramString;
	  }

	  public virtual string getWarPath(string paramString)
	  {
		  return (!string.ReferenceEquals(this.warPathPrefix, null)) ? (this.warPathPrefix + paramString) : paramString;
	  }

	  public virtual string prefixName(string paramString)
	  {
		  return (!string.ReferenceEquals(this.jndiPrefix, null)) ? (this.jndiPrefix + paramString) : paramString;
	  }

	  public virtual string prefixResourceName(string paramString)
	  {
		  return (!string.ReferenceEquals(this.jndiResourcePrefix, null)) ? (this.jndiResourcePrefix + paramString) : paramString;
	  }

	  public static NamingUtil Instance
	  {
		  get
		  {
			if (s_instance == null)
			{
			  s_instance = new NamingUtil();
			}
			return s_instance;
		  }
	  }

	  public virtual MBeanServer locateMBeanServer()
	  {
		  return (appServer == 2) ? ManagementFactory.PlatformMBeanServer : MBeanServerLocator.locateJBoss();
	  }

	  public virtual string getMBeanHarObjectName(string paramString)
	  {
		  return (appServer == 2) ? ("tomee.har:service=" + paramString) : ("jboss.har:service=" + paramString);
	  }

	  public virtual string getMBeanSarObjectName(string paramString)
	  {
		  return (appServer == 2) ? ("tomee.ces:service=" + paramString) : ("jboss.ces:service=" + paramString);
	  }

	  public virtual string ConnectionFactoryName
	  {
		  get
		  {
			  return (appServer == 2) ? prefixResourceName("CostOSJmsConnectionFactory") : "java:ConnectionFactory";
		  }
	  }

	  public virtual string prefixTopicName(string paramString)
	  {
		if (JBoss)
		{
		  paramString = "topic/" + paramString;
		}
		else if (TomEE)
		{
		  paramString = prefixResourceName(paramString);
		}
		return paramString;
	  }

	  public virtual string prefixQueueName(string paramString)
	  {
		if (JBoss)
		{
		  paramString = "queue/" + paramString;
		}
		else if (TomEE)
		{
		  paramString = prefixResourceName(paramString);
		}
		return paramString;
	  }

	  public virtual bool TomEE
	  {
		  get
		  {
			  return (appServer == 2);
		  }
	  }

	  public virtual bool JBoss
	  {
		  get
		  {
			  return (appServer == 1);
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public javax.naming.Context createInitialContext(boolean paramBoolean) throws javax.naming.NamingException
	  public virtual Context createInitialContext(bool paramBoolean)
	  {
		Properties properties = new Properties();
		if (TomEE)
		{
		  if (paramBoolean)
		  {
			properties.put("java.naming.factory.initial", "org.apache.openejb.client.RemoteInitialContextFactory");
		  }
		  else
		  {
			properties.put("java.naming.factory.initial", "org.apache.openejb.client.LocalInitialContextFactory");
		  }
		  properties.put("openejb.authentication.realmName", "ces");
		}
		else if (JBoss)
		{
		  properties.put("java.naming.factory.initial", "org.jnp.interfaces.NamingContextFactory");
		}
		return new InitialContext(properties);
	  }

	  public virtual string ClientConnectionFactoryName
	  {
		  get
		  {
			  return TomEE ? "java:CostOSJmsConnectionFactory" : ConnectionFactoryName;
		  }
	  }

	  public virtual string getClientTopicName(string paramString)
	  {
		  return TomEE ? ("java:" + paramString) : prefixTopicName(paramString);
	  }

	  public virtual string getClientQueueName(string paramString)
	  {
		  return TomEE ? ("java:" + paramString) : prefixQueueName(paramString);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\NamingUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}