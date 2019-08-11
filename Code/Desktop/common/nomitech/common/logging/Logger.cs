using System;

namespace Desktop.common.nomitech.common.logging
{
	public abstract class Logger
	{
	  public const string LOGGER_FACTORY_CONFIG_KEY = "nomitech.common.logging.LoggerFactoryConfig";

	  public const string LOGGER_FACTORY_CONFIG_VALUE = null;

	  public const string LOGGER_FACTORY_KEY = "nomitech.common.logging.LoggerFactory";

	  public const string LOGGER_FACTORY_VALUE = "nomitech.common.logging.simple.SimpleLoggerFactory";

	  private static LoggerFactory s_loggerFactory = null;

	  public static Logger getLogger(string paramString)
	  {
		  return s_loggerFactory.getLogger(paramString);
	  }

	  public static Logger getLogger(Type paramClass)
	  {
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		  return s_loggerFactory.getLogger(paramClass.FullName);
	  }

	  public static void shutdown()
	  {
		s_loggerFactory.shutdown();
		s_loggerFactory = null;
	  }

	  public abstract void error(object paramObject);

	  public abstract void error(object paramObject, Exception paramThrowable);

	  public abstract void warn(object paramObject);

	  public abstract void warn(object paramObject, Exception paramThrowable);

	  public abstract void info(object paramObject);

	  public abstract void info(object paramObject, Exception paramThrowable);

	  public abstract bool InfoEnabled {get;}

	  public abstract void debug(object paramObject);

	  public abstract void debug(object paramObject, Exception paramThrowable);

	  public abstract bool DebugEnabled {get;}

	  public abstract void trace(object paramObject);

	  public abstract void trace(object paramObject, Exception paramThrowable);

	  public abstract bool TraceEnabled {get;}

	  static Logger()
	  {
		string str1 = System.getProperty("nomitech.common.logging.LoggerFactory", "nomitech.common.logging.simple.SimpleLoggerFactory");
		string str2 = System.getProperty("nomitech.common.logging.LoggerFactoryConfig", LOGGER_FACTORY_CONFIG_VALUE);
		try
		{
		  s_loggerFactory = (LoggerFactory)System.Activator.CreateInstance(Type.GetType(str1));
		}
		catch (Exception)
		{
		}
		s_loggerFactory.initialize(str2);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\logging\Logger.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}