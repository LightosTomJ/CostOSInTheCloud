namespace Desktop.common.nomitech.common
{
	using Session = org.hibernate.Session;
	using Configuration = org.hibernate.cfg.Configuration;
	using Dialect = org.hibernate.dialect.Dialect;

	public interface SessionInterface
	{
	  Session currentSession();

	  void closeSession();

	  Configuration Configuration {get;}

	  Dialect Dialect {get;}

	  Connection Connection {get;}
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\SessionInterface.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}