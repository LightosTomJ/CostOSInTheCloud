namespace Desktop.common.nomitech.common.logging
{
	public interface LoggerFactory
	{
	  void initialize(string paramString);

	  Logger getLogger(string paramString);

	  void shutdown();
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\logging\LoggerFactory.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}