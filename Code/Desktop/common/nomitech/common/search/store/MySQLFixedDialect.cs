namespace Desktop.common.nomitech.common.search.store
{
	using MySQLInnoDBDialect = org.apache.lucene.store.jdbc.dialect.MySQLInnoDBDialect;

	public class MySQLFixedDialect : MySQLInnoDBDialect
	{
	  public virtual string openBlobSelectQuote()
	  {
		  return "'";
	  }

	  public virtual string closeBlobSelectQuote()
	  {
		  return "'";
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\search\store\MySQLFixedDialect.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}