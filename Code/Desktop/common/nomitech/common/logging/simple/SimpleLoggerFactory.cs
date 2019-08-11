namespace Desktop.common.nomitech.common.logging.simple
{

	public class SimpleLoggerFactory : LoggerFactory
	{
	  public const string DEFAULT_TIMESTAMP_FORMAT = "yyyy-MM-dd HH:mm:ss,SSS";

	  private SimpleDateFormat formatter = null;

	  private bool isInitialized = false;

	  public virtual void initialize(string paramString)
	  {
		if (this.isInitialized)
		{
		  throw new System.InvalidOperationException("SimpleLoggerFactory already initialized");
		}
		this.formatter = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss,SSS");
		this.isInitialized = true;
	  }

	  public virtual Logger getLogger(string paramString)
	  {
		if (!this.isInitialized)
		{
		  throw new System.InvalidOperationException("SimpleLoggerFactory has not been initialized");
		}
		return new SimpleLogger(paramString, this.formatter);
	  }

	  public virtual void shutdown()
	  {
		  System.out.flush();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\logging\simple\SimpleLoggerFactory.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}