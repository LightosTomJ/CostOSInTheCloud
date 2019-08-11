using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common
{
	using HibernateException = org.hibernate.HibernateException;
	using Session = org.hibernate.Session;
	using SessionFactory = org.hibernate.SessionFactory;
	using Configuration = org.hibernate.cfg.Configuration;
	using HSQLSchemaUpdate = org.hibernate.tool.hbm2ddl.HSQLSchemaUpdate;

	public class CostOSBimEngineFileDBUtil : System.IDisposable
	{
	  private const string JDBC_DRIVER = "org.hsqldb.jdbcDriver";

	  private const string HIBERNATE_DIALECT = "Desktop.common.nomitech.common.db.dialect.HSQLDialect";

	  internal static Configuration configuration;

	  internal static SessionFactory sessionFactory;

	  internal const string USERNAME = "SA";

	  internal const string PASSWORD = "";

	  internal Connection connection;

	  internal Properties schemaUpdateProperties;

	  internal Properties connectionProperties;

	  internal IList<Session> sessions = new List<object>();

	  internal string projectFolder;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public CostOSBimEngineFileDBUtil(String paramString) throws Exception
	  public CostOSBimEngineFileDBUtil(string paramString)
	  {
		initSessionFactory();
		this.projectFolder = paramString;
		string str = "jdbc:hsqldb:" + paramString + "/modelDB;shutdown=true";
		ProjectDBUtil.initDriver(ProjectDBUtil.HSQL_DBMS);
		this.connectionProperties = new Properties();
		this.connectionProperties.setProperty("user", "SA");
		this.connectionProperties.setProperty("password", "");
		this.connectionProperties.setProperty("shutdown", "true");
		this.schemaUpdateProperties = new Properties();
		this.schemaUpdateProperties.setProperty("hibernate.dialect", "Desktop.common.nomitech.common.db.dialect.HSQLDialect");
		this.schemaUpdateProperties.setProperty("hibernate.connection.driver_class", "org.hsqldb.jdbcDriver");
		this.schemaUpdateProperties.setProperty("hibernate.connection.url", str);
		this.schemaUpdateProperties.setProperty("hibernate.connection.username", "SA");
		this.schemaUpdateProperties.setProperty("hibernate.connection.password", "");
		HSQLSchemaUpdate hSQLSchemaUpdate = new HSQLSchemaUpdate(configuration, this.schemaUpdateProperties);
		hSQLSchemaUpdate.execute(true, true);
		this.connection = DriverManager.getConnection(str, this.connectionProperties);
	  }

	  public virtual Session createSession()
	  {
		  return sessionFactory.openSession(this.connection);
	  }

	  public virtual string ProjectFolder
	  {
		  get
		  {
			  return this.projectFolder;
		  }
	  }

	  private void initSessionFactory()
	  {
		if (sessionFactory != null)
		{
		  return;
		}
		URL uRL = this.GetType().getResource("bimEngineDB.xml");
		configuration = (new Configuration()).configure(uRL);
		configuration.setProperty("hibernate.connection.driver_class", "org.hsqldb.jdbcDriver");
		configuration.Properties.remove("hibernate.connection.url");
		configuration.Properties.remove("hibernate.connection.username");
		configuration.Properties.remove("hibernate.connection.password");
		configuration.setProperty("hibernate.dialect", "Desktop.common.nomitech.common.db.dialect.HSQLDialect");
		sessionFactory = configuration.buildSessionFactory();
	  }

	  public virtual void Dispose()
	  {
		this.sessions.ForEach(paramSession =>
		{
		if (paramSession.Open)
		{
			closeSession(paramSession);
		}
		});
		if (this.connection != null)
		{
		  try
		  {
			this.connection.close();
		  }
		  catch (SQLException sQLException)
		  {
			Console.WriteLine(sQLException.ToString());
			Console.Write(sQLException.StackTrace);
		  }
		}
		sessionFactory.close();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void closeSession(org.hibernate.Session paramSession) throws org.hibernate.HibernateException
	  public virtual void closeSession(Session paramSession)
	  {
		if (paramSession == null)
		{
		  return;
		}
		try
		{
		  if (paramSession.Open)
		  {
			if (paramSession.Transaction != null)
			{
			  if (paramSession.Transaction.Active)
			  {
				paramSession.Transaction.commit();
			  }
			  else
			  {
				paramSession.beginTransaction().commit();
			  }
			  paramSession.flush();
			}
			else
			{
			  paramSession.flush();
			}
			paramSession.close();
		  }
		}
		catch (Exception exception)
		{
		  Console.WriteLine("Error when flushing session:" + exception.Message);
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\CostOSBimEngineFileDBUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}