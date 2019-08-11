using System;
using System.Windows.Forms;

namespace Desktop.common.nomitech.common
{
	using BimEngineDBUtil = nomitech.bimengine.BimEngineDBUtil;
	using HibernateException = org.hibernate.HibernateException;
	using Session = org.hibernate.Session;
	using SessionFactory = org.hibernate.SessionFactory;
	using Configuration = org.hibernate.cfg.Configuration;
	using SchemaUpdate = org.hibernate.tool.hbm2ddl.SchemaUpdate;

	public class CostOSBimEngineDBUtil : BimEngineDBUtil
	{
	  private const string EXCEPTION_SEPARATOR = "====================================";

	  private SessionFactory sessionFactory = null;

	  private ThreadLocal session = null;

	  private URL configXML = null;

	  private Configuration configuration = null;

	  public static void init()
	  {
		  s_instance = new CostOSBimEngineDBUtil();
	  }

	  public virtual void connectDB(string paramString1, string paramString2, string paramString3, string paramString4, string paramString5)
	  {
		this.configXML = this.GetType().getResource("bimEngineDB.xml");
		closeSession();
		this.configuration = (new Configuration()).configure(this.configXML);
		this.configuration.setProperty("hibernate.connection.username", paramString4);
		this.configuration.setProperty("hibernate.connection.password", paramString5);
		this.configuration.setProperty("hibernate.connection.url", getDatabaseURL(paramString1, paramString2, paramString3));
		this.configuration.setProperty("hibernate.search.default.jdbc_url", getDatabaseURL(paramString1, paramString2, paramString3));
		this.configuration.setProperty("hibernate.search.default.jdbc_username", paramString4);
		this.configuration.setProperty("hibernate.search.default.jdbc_password", paramString5);
		this.configuration.setProperty("hibernate.connection.isolation", 8.ToString());
		this.configuration.setProperty("hibernate.dialect", "Desktop.common.nomitech.common.db.dialect.SQLServerDialect");
		this.sessionFactory = this.configuration.buildSessionFactory();
		SchemaUpdate schemaUpdate = new SchemaUpdate(this.configuration);
		schemaUpdate.execute(true, true);
		if (schemaUpdate.Exceptions.size() > 0)
		{
		  MessageBox.Show(null, getDatabaseFailureUpdateFrame(schemaUpdate.Exceptions), "Error while updating the database", MessageBoxIcon.None);
		}
	  }

	  private JPanel getDatabaseFailureUpdateFrame(System.Collections.IList paramList)
	  {
		StringWriter stringWriter = new StringWriter();
		PrintWriter printWriter = new PrintWriter(stringWriter);
		paramList.ForEach(paramObject =>
		{
		Exception exception = (Exception)paramObject;
		paramPrintWriter.println("====================================");
		paramPrintWriter.println(exception.GetType() + " : " + exception.Message);
		exception.printStackTrace(paramPrintWriter);
		paramPrintWriter.println();
		});
		JPanel jPanel = new JPanel();
		jPanel.Layout = new BorderLayout();
		JTextArea jTextArea = new JTextArea(stringWriter.ToString(), 100, 80);
		JScrollPane jScrollPane = new JScrollPane(jTextArea, 22, 32);
		jPanel.add(jScrollPane, "Center");
		return jPanel;
	  }

	  public virtual void disconnectDB()
	  {
		closeSession();
		if (!this.sessionFactory.Closed)
		{
		  this.sessionFactory.close();
		}
		this.session = null;
		this.sessionFactory = null;
		this.configXML = null;
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

	  private SessionFactory SessionFactory
	  {
		  get
		  {
			if (this.sessionFactory == null)
			{
			  try
			  {
				this.configuration = (new Configuration()).configure();
				this.sessionFactory = this.configuration.buildSessionFactory();
			  }
			  catch (Exception throwable)
			  {
				Console.Error.WriteLine("Initial SessionFactory creation failed." + throwable);
			  }
			}
			return this.sessionFactory;
		  }
	  }

	  public virtual void closeSession()
	  {
		Session session1 = (Session)Session.get();
		closeSession(session1);
		Session.set(null);
	  }

	  private ThreadLocal Session
	  {
		  get
		  {
			if (this.session == null)
			{
			  this.session = new ThreadLocal();
			}
			return this.session;
		  }
	  }

	  public virtual Configuration Configuration
	  {
		  get
		  {
			  return this.configuration;
		  }
	  }

	  public virtual bool hasOpenedSession()
	  {
		Session session1 = (Session)Session.get();
		return !(session1 == null);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.hibernate.Session currentSession() throws org.hibernate.HibernateException
	  public virtual Session currentSession()
	  {
		if (this.configXML == null)
		{
		  throw new HibernateException("cfg file not set");
		}
		Session session1 = (Session)Session.get();
		if (session1 == null)
		{
		  session1 = SessionFactory.openSession();
		  this.session.set(session1);
		}
		else if (!session1.Open)
		{
		  closeSession();
		  session1 = null;
		  session1 = currentSession();
		}
		return session1;
	  }

	  private string getDatabaseURL(string paramString1, string paramString2, string paramString3)
	  {
		  return "jdbc:jtds:sqlserver://" + paramString1 + ":" + paramString2 + ";databaseName=" + paramString3;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\CostOSBimEngineDBUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}