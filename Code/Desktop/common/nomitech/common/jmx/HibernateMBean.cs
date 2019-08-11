namespace Desktop.common.nomitech.common.jmx
{
	public interface HibernateMBean
	{
	  string SessionFactoryName {get;set;}


	  string DatasourceName {get;set;}


	  string Dialect {get;set;}


	  string Hbm2ddlAuto {get;set;}


	  string ShowSqlEnabled {get;set;}


	  string CacheProviderClass {get;set;}


//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void start() throws Exception;
	  void start();

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void stop() throws Exception;
	  void stop();
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\jmx\HibernateMBean.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}