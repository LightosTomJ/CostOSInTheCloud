using System;

namespace Desktop.common.nomitech.common.search.store
{
	using ClassicAnalyzer = org.apache.lucene.analysis.standard.ClassicAnalyzer;
	using IndexWriter = org.apache.lucene.index.IndexWriter;
	using Directory = org.apache.lucene.store.Directory;
	using JdbcDirectory = org.apache.lucene.store.jdbc.JdbcDirectory;
	using Dialect = org.apache.lucene.store.jdbc.dialect.Dialect;
	using Version = org.apache.lucene.util.Version;
	using SearchFactoryImplementor = org.hibernate.search.engine.SearchFactoryImplementor;
	using BuildContext = org.hibernate.search.spi.BuildContext;
	using DirectoryProvider = org.hibernate.search.store.DirectoryProvider;

	public class ProjectDBDirectoryProvider : object, DirectoryProvider<JdbcDirectory>
	{
	  private JdbcDirectory directory;

	  private JDBCDirectoryDatasource dataSource;

	  private Dialect dialect;

	  private string tableName;

	  public virtual void initialize(string paramString, Properties paramProperties, SearchFactoryImplementor paramSearchFactoryImplementor)
	  {
		this.tableName = directoryProviderNameToTableName(paramString);
		try
		{
		  this.dialect = (Dialect)Type.GetType(paramProperties.getProperty("jdbc_driver")).forName(paramProperties.getProperty("jdbc_dialect")).newInstance();
		  this.dataSource = new JDBCDirectoryDatasource(paramProperties.getProperty("jdbc_url"), paramProperties.getProperty("jdbc_username"), paramProperties.getProperty("jdbc_password"), paramProperties.getProperty("jdbc_dialect"));
		  this.directory = new JdbcDirectory(this.dataSource, this.dialect, this.tableName);
		  try
		  {
			this.dataSource.Connection.prepareStatement("SELECT COUNT(*) FROM " + this.tableName).execute();
		  }
		  catch (SQLException)
		  {
			Console.WriteLine("Creating and Initializing Table: " + this.tableName + " for the First Time");
			this.directory.create();
			IndexWriter indexWriter = new IndexWriter(this.directory, new ClassicAnalyzer(Version.LUCENE_22), true, IndexWriter.MaxFieldLength.UNLIMITED);
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


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\search\store\ProjectDBDirectoryProvider.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}