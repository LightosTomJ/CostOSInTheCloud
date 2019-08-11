using System;
using System.IO;

namespace Desktop.common.nomitech.common
{
	using LocalDBConnectionPool = Desktop.common.nomitech.common.search.store.LocalDBConnectionPool;
	using HibernateException = org.hibernate.HibernateException;
	using Session = org.hibernate.Session;
	using SessionFactory = org.hibernate.SessionFactory;
	using Configuration = org.hibernate.cfg.Configuration;
	using Session = org.hibernate.classic.Session;

	public class HsqlDBUtil
	{
	  private static SessionFactory sessionFactory = null;

	  private static ThreadLocal session = null;

	  private static URL configXML = null;

	  private static Configuration configuration = null;

	  private static string installDir = "";

	  private static bool madeProperties = true;

	  private static string s_prevUsername = null;

	  private static string s_prevPassword = null;

	  private static string s_hostName = null;

	  private static bool s_driverLoaded = false;

	  public static string InstallDirectory
	  {
		  set
		  {
			  installDir = value;
		  }
	  }

	  private static SessionFactory SessionFactory
	  {
		  get
		  {
			if (sessionFactory == null)
			{
			  try
			  {
				configuration = (new Configuration()).configure();
				sessionFactory = configuration.buildSessionFactory();
			  }
			  catch (Exception throwable)
			  {
				Console.Error.WriteLine("Initial SessionFactory creation failed." + throwable);
			  }
			}
			return sessionFactory;
		  }
	  }

	  private static ThreadLocal Session
	  {
		  get
		  {
			if (session == null)
			{
			  session = new ThreadLocal();
			}
			return session;
		  }
	  }

	  public static Configuration Configuration
	  {
		  get
		  {
			  return configuration;
		  }
	  }

	  public static void loadDriver()
	  {
		if (s_driverLoaded)
		{
		  return;
		}
		try
		{
		  Type.GetType("org.hsqldb.jdbcDriver");
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  s_driverLoaded = false;
		}
		s_driverLoaded = true;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void testAuthorizedUser(String paramString1, String paramString2) throws Exception
	  public static void testAuthorizedUser(string paramString1, string paramString2)
	  {
		loadDriver();
		Properties properties = new Properties();
		properties.setProperty("user", paramString1);
		properties.setProperty("password", paramString2);
		properties.setProperty("shutdown", "true");
		Connection connection = null;
		try
		{
		  connection = DriverManager.getConnection("jdbc:hsqldb:" + installDir + "data/localDB", properties);
		  connection.close();
		}
		catch (Exception exception)
		{
		  if (connection != null)
		  {
			connection.close();
		  }
		  throw exception;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void changePassword(String paramString1, String paramString2, String paramString3) throws Exception
	  public static void changePassword(string paramString1, string paramString2, string paramString3)
	  {
		unloadDB(true);
		loadDriver();
		Properties properties = new Properties();
		properties.setProperty("user", paramString1);
		properties.setProperty("password", paramString2);
		properties.setProperty("shutdown", "true");
		Connection connection = DriverManager.getConnection("jdbc:hsqldb:" + installDir + "data/localDB", properties);
		Statement statement = connection.createStatement();
		statement.execute("SET PASSWORD \"" + paramString3.ToUpper() + "\"");
		statement.close();
		connection.close();
		loadDB(paramString1, paramString3, madeProperties);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void loadDB(String paramString1, String paramString2, boolean paramBoolean) throws Exception
	  public static void loadDB(string paramString1, string paramString2, bool paramBoolean)
	  {
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void connectDB(String paramString1, String paramString2, String paramString3) throws Exception
	  public static void connectDB(string paramString1, string paramString2, string paramString3)
	  {
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static boolean initDB(String paramString1, String paramString2) throws Exception
	  public static bool initDB(string paramString1, string paramString2)
	  {
		File file1 = new File(installDir + "data");
		if (file1.Directory && !deleteDirectory(file1))
		{
		  throw new Exception("could not initialize database, close any files that might be using it!");
		}
		file1.mkdir();
		File file2 = new File(installDir + "emptyDB");
		if (!file2.exists())
		{
		  throw new Exception("could not initialize database, emptyDB file not found");
		}
		ZipFile zipFile = new ZipFile(file2);
		System.Collections.IEnumerator enumeration = zipFile.entries();
		sbyte[] arrayOfByte = new sbyte[1024];
		while (enumeration.MoveNext())
		{
		  ZipEntry zipEntry = (ZipEntry)enumeration.Current;
		  File file = new File(installDir + "data" + File.separator + zipEntry.Name);
		  file.createNewFile();
		  FileStream fileOutputStream = new FileStream(file, FileMode.Create, FileAccess.Write);
		  Stream inputStream = zipFile.getInputStream(zipEntry);
		  int i;
		  while ((i = inputStream.Read(arrayOfByte, 0, arrayOfByte.Length)) > 0)
		  {
			fileOutputStream.Write(arrayOfByte, 0, i);
		  }
		  fileOutputStream.Flush();
		  fileOutputStream.Close();
		  inputStream.Close();
		}
		zipFile.close();
		loadDriver();
		Properties properties = new Properties();
		properties.setProperty("user", "SA");
		properties.setProperty("password", "");
		properties.setProperty("shutdown", "true");
		Connection connection = DriverManager.getConnection("jdbc:hsqldb:" + installDir + "data/localDB", properties);
		Statement statement = connection.createStatement();
		statement.execute("CREATE USER " + paramString1 + " PASSWORD \"" + paramString2 + "\"");
		statement.close();
		statement = connection.createStatement();
		statement.execute("GRANT DBA TO " + paramString1);
		statement.close();
		connection.close();
		properties = new Properties();
		properties.setProperty("user", paramString1);
		properties.setProperty("password", paramString2);
		properties.setProperty("shutdown", "true");
		connection = DriverManager.getConnection("jdbc:hsqldb:" + installDir + "data/localDB", properties);
		statement = connection.createStatement();
		statement.execute("DROP USER SA");
		statement.close();
		statement = connection.createStatement();
		statement.execute("SET SCRIPTFORMAT COMPRESSED");
		statement.close();
		statement = connection.createStatement();
		statement.execute("SHUTDOWN IMMEDIATELY");
		statement.close();
		connection.close();
		return true;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void importDB(java.io.File paramFile, String paramString1, String paramString2) throws Exception
	  public static void importDB(File paramFile, string paramString1, string paramString2)
	  {
		unloadDB(true);
		File file = new File(installDir + "data");
		if (file.Directory && !deleteDirectory(file))
		{
		  throw new Exception("data directory not deleted!");
		}
		file.mkdir();
		ZipFile zipFile = new ZipFile(paramFile);
		System.Collections.IEnumerator enumeration = zipFile.entries();
		sbyte[] arrayOfByte = new sbyte[1024];
		while (enumeration.MoveNext())
		{
		  ZipEntry zipEntry = (ZipEntry)enumeration.Current;
		  File file1 = new File(installDir + "data" + File.separator + zipEntry.Name);
		  file1.createNewFile();
		  FileStream fileOutputStream = new FileStream(file1, FileMode.Create, FileAccess.Write);
		  Stream inputStream = zipFile.getInputStream(zipEntry);
		  int i;
		  while ((i = inputStream.Read(arrayOfByte, 0, arrayOfByte.Length)) > 0)
		  {
			fileOutputStream.Write(arrayOfByte, 0, i);
		  }
		  fileOutputStream.Flush();
		  fileOutputStream.Close();
		  inputStream.Close();
		}
		loadDB(paramString1, paramString2, madeProperties);
		if (zipFile != null)
		{
		  zipFile.close();
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void exportDB(java.io.File paramFile, String paramString1, String paramString2) throws Exception
	  public static void exportDB(File paramFile, string paramString1, string paramString2)
	  {
		File file = new File(installDir + "data");
		if (!file.exists())
		{
		  throw new Exception("strange, database does not exist!");
		}
		paramFile.createNewFile();
		unloadDB(true);
		zipDirectory(file, paramFile);
		loadDB(paramString1, paramString2, madeProperties);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void exportDB(java.io.File paramFile) throws Exception
	  public static void exportDB(File paramFile)
	  {
		File file = new File(installDir + "data");
		if (!file.exists())
		{
		  throw new Exception("strange, database does not exist!");
		}
		paramFile.createNewFile();
		zipDirectory(file, paramFile);
	  }

	  public static void unloadDB(bool paramBoolean)
	  {
		closeSession();
		if (!sessionFactory.Closed)
		{
		  sessionFactory.close();
		}
		session = null;
		sessionFactory = null;
		try
		{
		  LocalDBConnectionPool.emptyPool();
		}
		catch (SQLException sQLException)
		{
		  Console.WriteLine(sQLException.ToString());
		  Console.Write(sQLException.StackTrace);
		}
		if (!paramBoolean)
		{
		  return;
		}
		Properties properties = new Properties();
		properties.setProperty("user", s_prevUsername);
		properties.setProperty("password", s_prevPassword);
		properties.setProperty("shutdown", "true");
		try
		{
		  Connection connection = DriverManager.getConnection("jdbc:hsqldb:" + installDir + "data/localDB", properties);
		  Statement statement = connection.createStatement();
		  statement.execute("SHUTDOWN IMMEDIATELY");
		  statement.close();
		  connection.close();
		}
		catch (Exception exception)
		{
		  Console.WriteLine("Could not shutdown db: " + exception.Message);
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
	  }

	  public static bool hasOpenedSession()
	  {
		Session session1 = (Session)Session.get();
		return !(session1 == null);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static org.hibernate.Session currentSession() throws org.hibernate.HibernateException
	  public static Session currentSession()
	  {
		if (configXML == null)
		{
		  throw new HibernateException("cfg file not set");
		}
		Session session1 = (Session)Session.get();
		if (session1 == null)
		{
		  session1 = SessionFactory.openSession();
		  session.set(session1);
		}
		return session1;
	  }

	  public static void closeSession()
	  {
		Session session1 = (Session)Session.get();
		if (session1 != null && session1.Open)
		{
		  session1.flush();
		  session1.close();
		}
		Session.set(null);
	  }

	  public static bool deleteDirectory(File paramFile)
	  {
		if (paramFile.exists())
		{
		  File[] arrayOfFile = paramFile.listFiles();
		  for (sbyte b = 0; b < arrayOfFile.Length; b++)
		  {
			if (arrayOfFile[b].Directory)
			{
			  deleteDirectory(arrayOfFile[b]);
			}
			else
			{
			  arrayOfFile[b].delete();
			}
		  }
		}
		return paramFile.delete();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static void zipDirectory(java.io.File paramFile1, java.io.File paramFile2) throws java.io.IOException, IllegalArgumentException
	  private static void zipDirectory(File paramFile1, File paramFile2)
	  {
		if (!paramFile1.Directory)
		{
		  throw new System.ArgumentException("Compress: not a directory:  " + paramFile1);
		}
		string[] arrayOfString = paramFile1.list();
		sbyte[] arrayOfByte = new sbyte[4096];
		ZipOutputStream zipOutputStream = new ZipOutputStream(new FileStream(paramFile2, FileMode.Create, FileAccess.Write));
		for (sbyte b = 0; b < arrayOfString.Length; b++)
		{
		  File file = new File(paramFile1, arrayOfString[b]);
		  if (!file.Directory)
		  {
			FileStream fileInputStream = new FileStream(file, FileMode.Open, FileAccess.Read);
			ZipEntry zipEntry = new ZipEntry(file.Name);
			zipOutputStream.putNextEntry(zipEntry);
			int i;
			while ((i = fileInputStream.Read(arrayOfByte, 0, arrayOfByte.Length)) != -1)
			{
			  zipOutputStream.write(arrayOfByte, 0, i);
			}
			fileInputStream.Close();
		  }
		}
		zipOutputStream.close();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\HsqlDBUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}