using System;

namespace Desktop.common.nomitech.common.search.store
{

	public class LocalDBDirectoryDatasource : DataSource
	{
	  private string url;

	  private string userId;

	  private string password;

	  private Connection connection;

	  private int loginTimeOut = 10;

	  private PrintWriter logWriter = new PrintWriter(System.out);

	  private bool isHSQL = false;

	  public LocalDBDirectoryDatasource(string paramString1, string paramString2, string paramString3, string paramString4)
	  {
		this.url = paramString1;
		this.userId = paramString2;
		this.password = paramString3;
		if (paramString4.ToUpper().IndexOf("HSQL", StringComparison.Ordinal) != -1)
		{
		  this.isHSQL = true;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.Connection getConnection() throws java.sql.SQLException
	  public virtual Connection Connection
	  {
		  get
		  {
			Properties properties = new Properties();
			properties.setProperty("user", this.userId);
			properties.setProperty("password", this.password);
			if (this.isHSQL)
			{
			  properties.setProperty("shutdown", "true");
			}
			return LocalDBConnectionPool.getLocalDBConnection(this.url, properties);
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.Connection getConnection(String paramString1, String paramString2) throws java.sql.SQLException
	  public virtual Connection getConnection(string paramString1, string paramString2)
	  {
		Properties properties = new Properties();
		properties.setProperty("user", paramString1);
		properties.setProperty("password", paramString2);
		if (this.isHSQL)
		{
		  properties.setProperty("shutdown", "true");
		}
		return LocalDBConnectionPool.getLocalDBConnection(this.url, properties);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.io.PrintWriter getLogWriter() throws java.sql.SQLException
	  public virtual PrintWriter LogWriter
	  {
		  get
		  {
			  return this.logWriter;
		  }
		  set
		  {
			  this.logWriter = value;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public int getLoginTimeout() throws java.sql.SQLException
	  public virtual int LoginTimeout
	  {
		  get
		  {
			  return this.loginTimeOut;
		  }
		  set
		  {
			  this.loginTimeOut = value;
		  }
	  }



//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public boolean isWrapperFor(Class paramClass) throws java.sql.SQLException
	  public virtual bool isWrapperFor(Type paramClass)
	  {
		  return false;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public <T> T unwrap(Class<T> paramClass) throws java.sql.SQLException
	  public virtual T unwrap<T>(Type paramClass)
	  {
			  paramClass = typeof(T);
		  return default(T);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void closeConnection() throws java.sql.SQLException
	  public virtual void closeConnection()
	  {
		if (!this.connection.Closed)
		{
		  this.connection.close();
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.logging.Logger getParentLogger() throws java.sql.SQLFeatureNotSupportedException
	  public virtual Logger ParentLogger
	  {
		  get
		  {
			  throw new SQLFeatureNotSupportedException();
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\search\store\LocalDBDirectoryDatasource.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}