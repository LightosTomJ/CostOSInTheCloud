using System;

namespace Desktop.common.nomitech.common.search.store
{
	using IndexWriter = org.apache.lucene.index.IndexWriter;
	using Directory = org.apache.lucene.store.Directory;
	using JdbcDirectory = org.apache.lucene.store.jdbc.JdbcDirectory;
	using Dialect = org.apache.lucene.store.jdbc.dialect.Dialect;
	using SearchFactoryImplementor = org.hibernate.search.engine.SearchFactoryImplementor;
	using BuildContext = org.hibernate.search.spi.BuildContext;
	using DirectoryProvider = org.hibernate.search.store.DirectoryProvider;

	public class LocalDBDirectoryProvider : object, DirectoryProvider<JdbcDirectory>
	{
	  private JdbcDirectory directory;

	  private LocalDBDirectoryDatasource dataSource;

	  private Dialect dialect;

	  private string tableName;

	  public virtual void initialize(string paramString, Properties paramProperties, SearchFactoryImplementor paramSearchFactoryImplementor)
	  {
		this.tableName = directoryProviderNameToTableName(paramString);
		string str1 = paramProperties.getProperty("jdbc_dialect");
		string str2 = paramProperties.getProperty("jdbc_driver");
		string str3 = paramProperties.getProperty("jdbc_url");
		if (str1.IndexOf("MySQL", StringComparison.Ordinal) != -1)
		{
		  str3 = str3 + "?emulateLocators=true";
		}
		try
		{
		  this.dialect = (Dialect)Type.GetType(str2).forName(str1).newInstance();
		  this.dataSource = new LocalDBDirectoryDatasource(str3, paramProperties.getProperty("jdbc_username"), paramProperties.getProperty("jdbc_password"), paramProperties.getProperty("jdbc_dialect"));
		  this.directory = new JdbcDirectory(this.dataSource, this.dialect, this.tableName);
		  try
		  {
			this.dataSource.Connection.prepareStatement("SELECT COUNT(*) FROM " + this.tableName).execute();
		  }
		  catch (SQLException)
		  {
			this.directory.create();
			IndexWriter indexWriter = new IndexWriter(this.directory, AnalyzerFinder.LocaleAnalyzer, true, IndexWriter.MaxFieldLength.UNLIMITED);
			indexWriter.UseCompoundFile = false;
			indexWriter.optimize();
			indexWriter.close();
		  }
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
	  }

	  public virtual void start()
	  {
	  }

	  public virtual void stop()
	  {
	  }

	  public virtual JdbcDirectory Directory
	  {
		  get
		  {
			  return this.directory;
		  }
	  }

	  public override bool Equals(object paramObject)
	  {
		  return this.tableName.Equals(paramObject);
	  }

	  public override int GetHashCode()
	  {
		sbyte b = 11;
		return 37 * b + this.tableName.GetHashCode();
	  }

	  private string directoryProviderNameToTableName(string paramString)
	  {
		string str = paramString.Substring(paramString.LastIndexOf('.') + 1);
		str = str.Substring(0, str.Length - 5);
		return str.ToUpper() + "_SEARCH";
	  }

	  public virtual void initialize(string paramString, Properties paramProperties, BuildContext paramBuildContext)
	  {
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\search\store\LocalDBDirectoryProvider.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}