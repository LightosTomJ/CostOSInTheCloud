namespace Desktop.common.nomitech.common.logging.log4j
{
	using LogManager = Desktop.common.org.apache.log4j.LogManager;
	using PropertyConfigurator = Desktop.common.org.apache.log4j.PropertyConfigurator;

	public class Log4jLoggerFactory : LoggerFactory
	{
	  private bool isInitialized = false;

	  public virtual void initialize(string paramString)
	  {
		if (this.isInitialized)
		{
		  throw new System.InvalidOperationException("Log4jLoggerFactory already initialized");
		}
		PropertyConfigurator.configure(paramString);
		this.isInitialized = true;
	  }

	  public virtual Logger getLogger(string paramString)
	  {
		if (!this.isInitialized)
		{
		  throw new System.InvalidOperationException("Log4jLoggerFactory has not been initialized");
		}
		return new Log4jLogger(paramString);
	  }

	  public virtual void shutdown()
	  {
		  LogManager.shutdown();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\logging\log4j\Log4jLoggerFactory.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}