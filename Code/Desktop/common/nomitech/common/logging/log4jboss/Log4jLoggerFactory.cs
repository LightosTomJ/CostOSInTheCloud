namespace Desktop.common.nomitech.common.logging.log4jboss
{

	public class Log4jLoggerFactory : LoggerFactory
	{
	  public virtual void initialize(string paramString)
	  {
	  }

	  public virtual Logger getLogger(string paramString)
	  {
		  return new Log4jLogger(paramString);
	  }

	  public virtual void shutdown()
	  {
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\logging\log4jboss\Log4jLoggerFactory.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}