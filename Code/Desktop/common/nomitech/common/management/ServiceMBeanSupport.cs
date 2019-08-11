using System;

namespace Desktop.common.nomitech.common.management
{
	using Classes = nomitech.common.util.Classes;
	using Logger = org.apache.log4j.Logger;
	using NDC = org.apache.log4j.NDC;

	public class ServiceMBeanSupport : ServiceMBean
	{
	  protected internal readonly Logger log = Logger.getLogger(this.GetType());

	  protected internal MBeanServer server;

	  protected internal ObjectName serviceName;

	  protected internal string myName;

	  protected internal int state;

	  public ServiceMBeanSupport()
	  {
		  this.log.debug("Constructing");
	  }

	  public ServiceMBeanSupport(Type paramClass) : this(paramClass.FullName)
	  {
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
	  }

	  public ServiceMBeanSupport(string paramString) : this(Logger.getLogger(paramString))
	  {
	  }

	  public ServiceMBeanSupport(Logger paramLogger)
	  {
		  paramLogger.trace("Constructing");
	  }

	  public virtual Logger Logger
	  {
		  get
		  {
			  return this.log;
		  }
	  }

	  public virtual MBeanServer Server
	  {
		  get
		  {
			  return this.server;
		  }
	  }

	  public virtual ObjectName ObjectName
	  {
		  get
		  {
			  return this.serviceName;
		  }
	  }

	  public virtual string Name
	  {
		  get
		  {
			  return this.myName;
		  }
	  }

	  public virtual int State
	  {
		  get
		  {
			  return this.state;
		  }
	  }

	  public virtual string StateString
	  {
		  get
		  {
			  return ServiceMBean_Fields.states[this.state];
		  }
	  }

	  public virtual void create()
	  {
		this.log.info("Creating");
		NDC.push(Name);
		try
		{
		  createService();
		}
		catch (Exception exception)
		{
		  this.log.error("Initialization failed", exception);
		  throw exception;
		}
		finally
		{
		  NDC.pop();
		}
		this.log.info("Created");
	  }

	  public virtual void start()
	  {
		if (this.state != 5 && this.state != 0 && this.state != 4)
		{
		  return;
		}
		this.state = 2;
		this.log.info("Starting");
		NDC.push(Name);
		try
		{
		  startService();
		}
		catch (Exception exception)
		{
		  this.state = 4;
		  this.log.error("Starting failed", exception);
		  throw exception;
		}
		finally
		{
		  NDC.pop();
		}
		this.state = 3;
		this.log.info("Started");
	  }

	  public virtual void stop()
	  {
		if (this.state != 3)
		{
		  return;
		}
		this.state = 1;
		this.log.info("Stopping");
		NDC.push(Name);
		try
		{
		  stopService();
		}
		catch (Exception throwable)
		{
		  this.state = 4;
		  this.log.error("Stoping failed", throwable);
		  return;
		}
		finally
		{
		  NDC.pop();
		}
		this.state = 0;
		this.log.info("Stopped");
	  }

	  public virtual void destroy()
	  {
		if (this.state == 5)
		{
		  return;
		}
		if (this.state != 0)
		{
		  stop();
		}
		this.log.info("Destroying");
		NDC.push(Name);
		try
		{
		  destroyService();
		}
		catch (Exception throwable)
		{
		  this.log.error("Destroying failed", throwable);
		}
		finally
		{
		  NDC.pop();
		}
		this.state = 5;
		this.log.info("Destroyed");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public javax.management.ObjectName preRegister(javax.management.MBeanServer paramMBeanServer, javax.management.ObjectName paramObjectName) throws Exception
	  public virtual ObjectName preRegister(MBeanServer paramMBeanServer, ObjectName paramObjectName)
	  {
		this.server = paramMBeanServer;
		this.serviceName = getObjectName(paramMBeanServer, paramObjectName);
		this.myName = paramObjectName.getKeyProperty("name");
		if (string.ReferenceEquals(this.myName, null) || this.myName.Equals(""))
		{
		  this.myName = Classes.stripPackageName(this.GetType());
		}
		this.log.info("preRegister(), chosen myName=" + this.myName + ", objectName=" + this.serviceName);
		return paramObjectName;
	  }

	  public virtual void postRegister(bool? paramBoolean)
	  {
		this.log.debug("postRegister(" + paramBoolean + ")");
		if (!paramBoolean.Value)
		{
		  this.log.info("Registration is not done -> destroy");
		  stop();
		}
	  }

	  public virtual void preDeregister()
	  {
		  this.log.info("preDeregister()");
	  }

	  public virtual void postDeregister()
	  {
		this.log.info("postDeregister()");
		stop();
		this.server = null;
		this.serviceName = null;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected javax.management.ObjectName getObjectName(javax.management.MBeanServer paramMBeanServer, javax.management.ObjectName paramObjectName) throws Exception
	  protected internal virtual ObjectName getObjectName(MBeanServer paramMBeanServer, ObjectName paramObjectName)
	  {
		  return paramObjectName;
	  }

	  protected internal virtual void createService()
	  {
	  }

	  protected internal virtual void startService()
	  {
	  }

	  protected internal virtual void stopService()
	  {
	  }

	  protected internal virtual void destroyService()
	  {
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\management\ServiceMBeanSupport.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}