using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common
{
	using GroupCodesProvider = Desktop.common.nomitech.common.@base.GroupCodesProvider;
	using ProjectUrlTable = Models.local.ProjectUrlTable;
	using AddOnUtil = Desktop.common.nomitech.common.util.AddOnUtil;
	using CryptUtil = Desktop.common.nomitech.common.util.CryptUtil;
	using Session = org.hibernate.Session;
	using SessionFactory = org.hibernate.SessionFactory;
	using Configuration = org.hibernate.cfg.Configuration;
	using PersistentClass = org.hibernate.mapping.PersistentClass;

	public class ProjectSessionFactory
	{
	  private SessionFactory _factory;

	  private Configuration _configuration;

	  private static IDictionary<int, ProjectSessionFactory> _instances = new Hashtable(0);

	  private static GroupCodesProvider s_groupCodesProvider = null;

	  public static GroupCodesProvider GroupCodesProvider
	  {
		  get
		  {
			  return s_groupCodesProvider;
		  }
	  }

	  public static GroupCodesProvider UpGroupCodesProvider
	  {
		  set
		  {
			  s_groupCodesProvider = value;
		  }
	  }

	  public ProjectSessionFactory(int paramInt)
	  {
		URL uRL = this.GetType().getResource("projectDB.xml");
		this._configuration = ProjectSessionFactoryBuilder.Instance.createConfiguration(uRL, paramInt, s_groupCodesProvider, false, "");
		this._factory = this._configuration.buildSessionFactory();
	  }

	  public static ProjectSessionFactory getInstance(int paramInt)
	  {
		if (!_instances.ContainsKey(Convert.ToInt32(paramInt)))
		{
		  _instances[Convert.ToInt32(paramInt)] = new ProjectSessionFactory(paramInt);
		}
		return (ProjectSessionFactory)_instances[Convert.ToInt32(paramInt)];
	  }

	  public static SessionFactory getSessionFactory(int paramInt)
	  {
		  return (getInstance(paramInt))._factory;
	  }

	  public static Configuration getConfiguration(int paramInt)
	  {
		  return (getInstance(paramInt))._configuration;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.sql.Connection getConnection(Desktop.common.nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable) throws java.sql.SQLException
	  public static Connection getConnection(ProjectUrlTable paramProjectUrlTable)
	  {
		  return getConnection(paramProjectUrlTable.Url, paramProjectUrlTable.Username, paramProjectUrlTable.Password);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.sql.Connection getConnection(String paramString1, String paramString2, String paramString3) throws java.sql.SQLException
	  public static Connection getConnection(string paramString1, string paramString2, string paramString3)
	  {
		string str1 = CryptUtil.Instance.decryptHexString(paramString2);
		string str2 = AddOnUtil.Instance.decryptHexString(paramString3);
		return DriverManager.getConnection(paramString1, str1, str2);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static org.hibernate.Session openSession(Desktop.common.nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable) throws java.sql.SQLException
	  public static Session openSession(ProjectUrlTable paramProjectUrlTable)
	  {
		  return getSessionFactory(paramProjectUrlTable.Dbms.Value).openSession(getConnection(paramProjectUrlTable), new ProjectDBInterceptor(paramProjectUrlTable));
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static org.hibernate.Session openSession(System.Nullable<int> paramInteger, String paramString1, String paramString2, String paramString3, ProjectDBInterceptor paramProjectDBInterceptor) throws java.sql.SQLException
	  public static Session openSession(int? paramInteger, string paramString1, string paramString2, string paramString3, ProjectDBInterceptor paramProjectDBInterceptor)
	  {
		  return getSessionFactory(paramInteger.Value).openSession(getConnection(paramString1, paramString2, paramString3), paramProjectDBInterceptor);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static org.hibernate.Session openSession(System.Nullable<int> paramInteger, String paramString1, String paramString2, String paramString3) throws java.sql.SQLException
	  public static Session openSession(int? paramInteger, string paramString1, string paramString2, string paramString3)
	  {
		  return getSessionFactory(paramInteger.Value).openSession(getConnection(paramString1, paramString2, paramString3));
	  }

	  public static IList<PersistentClass> listClasses()
	  {
		LinkedList linkedList = new LinkedList();
		System.Collections.IEnumerator iterator = getConfiguration(ProjectDBUtil.SQLSERVER_DBMS).ClassMappings;
		while (iterator.MoveNext())
		{
		  linkedList.AddLast(iterator.Current);
		}
		return linkedList;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\ProjectSessionFactory.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}