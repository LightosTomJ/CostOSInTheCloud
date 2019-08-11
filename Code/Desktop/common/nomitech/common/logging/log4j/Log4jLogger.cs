using System;

namespace Desktop.common.nomitech.common.logging.log4j
{
	using Level = Desktop.common.org.apache.log4j.Level;
	using Logger = Desktop.common.org.apache.log4j.Logger;

	internal class Log4jLogger : Logger
	{
	  private Logger logger;

	  internal Log4jLogger(string paramString)
	  {
		  this.logger = (this.logger = null).getLogger(paramString);
	  }

	  public override void error(object paramObject)
	  {
		  this.logger.error(paramObject);
	  }

	  public override void warn(object paramObject)
	  {
		  this.logger.warn(paramObject);
	  }

	  public override void info(object paramObject)
	  {
		  this.logger.info(paramObject);
	  }

	  public override void debug(object paramObject)
	  {
		  this.logger.debug(paramObject);
	  }

	  public override void trace(object paramObject)
	  {
		  this.logger.log(Log4jTraceLevel.TRACE, paramObject);
	  }

	  public override void error(object paramObject, Exception paramThrowable)
	  {
		  this.logger.error(paramObject, paramThrowable);
	  }

	  public override void warn(object paramObject, Exception paramThrowable)
	  {
		  this.logger.warn(paramObject, paramThrowable);
	  }

	  public override void info(object paramObject, Exception paramThrowable)
	  {
		  this.logger.info(paramObject, paramThrowable);
	  }

	  public override void debug(object paramObject, Exception paramThrowable)
	  {
		  this.logger.debug(paramObject, paramThrowable);
	  }

	  public override void trace(object paramObject, Exception paramThrowable)
	  {
		  this.logger.log(Log4jTraceLevel.TRACE, paramObject, paramThrowable);
	  }

	  public override bool InfoEnabled
	  {
		  get
		  {
			Level level = Level.INFO;
			return !this.logger.isEnabledFor(level) ? false : level.isGreaterOrEqual(this.logger.EffectiveLevel);
		  }
	  }

	  public override bool DebugEnabled
	  {
		  get
		  {
			Level level = Level.DEBUG;
			return !this.logger.isEnabledFor(level) ? false : level.isGreaterOrEqual(this.logger.EffectiveLevel);
		  }
	  }

	  public override bool TraceEnabled
	  {
		  get
		  {
			Log4jTraceLevel log4jTraceLevel = Log4jTraceLevel.TRACE;
			return !this.logger.isEnabledFor(log4jTraceLevel) ? false : log4jTraceLevel.isGreaterOrEqual(this.logger.EffectiveLevel);
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\logging\log4j\Log4jLogger.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}