using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common
{
	using GroupCodesProvider = Desktop.common.nomitech.common.@base.GroupCodesProvider;
	using ProjectUrlTable = Desktop.common.nomitech.common.db.local.ProjectUrlTable;
	using ProjectNamingStrategy = Desktop.common.nomitech.common.db.ns.ProjectNamingStrategy;
	using CostOSString256Type = Desktop.common.nomitech.common.db.types.CostOSString256Type;
	using CostOSTextType = Desktop.common.nomitech.common.db.types.CostOSTextType;
	using GroupCodeType = Desktop.common.nomitech.common.db.types.GroupCodeType;
	using NotNullStringType = Desktop.common.nomitech.common.db.types.NotNullStringType;
	using NotNullTextType = Desktop.common.nomitech.common.db.types.NotNullTextType;
	using UnitAliasType = Desktop.common.nomitech.common.db.types.UnitAliasType;
	using AddOnUtil = Desktop.common.nomitech.common.util.AddOnUtil;
	using CryptUtil = Desktop.common.nomitech.common.util.CryptUtil;
	using StringUtils = Desktop.common.nomitech.common.util.StringUtils;
	using Configuration = org.hibernate.cfg.Configuration;

	public class ProjectSessionFactoryBuilder
	{
	  private static readonly ProjectSessionFactoryBuilder s_instance = new ProjectSessionFactoryBuilder();

	  public virtual Configuration createConfigurationFromUrl(URL paramURL, ProjectUrlTable paramProjectUrlTable, GroupCodesProvider paramGroupCodesProvider, bool paramBoolean, string paramString)
	  {
		string str1 = paramProjectUrlTable.Url;
		string str2 = CryptUtil.Instance.decryptHexString(paramProjectUrlTable.Username);
		string str3 = AddOnUtil.Instance.decryptHexString(paramProjectUrlTable.Password);
		int i = paramProjectUrlTable.Dbms.Value;
		return createConfiguration(paramURL, i, paramGroupCodesProvider, paramBoolean, str1, str2, str3, paramString);
	  }

	  public virtual Configuration createConfiguration(URL paramURL, int paramInt, GroupCodesProvider paramGroupCodesProvider, bool paramBoolean, string paramString1, string paramString2, string paramString3, string paramString4)
	  {
		Configuration configuration = createConfiguration(paramURL, paramInt, paramGroupCodesProvider, paramBoolean, paramString4);
		configuration.setProperty("hibernate.connection.url", paramString1);
		configuration.setProperty("hibernate.connection.username", paramString2);
		configuration.setProperty("hibernate.connection.password", paramString3);
		return configuration;
	  }

	  public virtual Configuration createConfiguration(URL paramURL, int paramInt, GroupCodesProvider paramGroupCodesProvider, bool paramBoolean, string paramString)
	  {
		Configuration configuration = (new Configuration()).configure(paramURL);
		if (!StringUtils.isNullOrBlank(paramString))
		{
		  configuration.NamingStrategy = new ProjectNamingStrategy(paramString);
		}
		ISet<object> set = configuration.Properties.Keys;
		string[] arrayOfString = (string[])set.toArray(new string[set.Count]);
		foreach (string str in arrayOfString)
		{
		  if (str.IndexOf("search.default", StringComparison.Ordinal) != -1 || str.IndexOf("dialect", StringComparison.Ordinal) != -1 || str.IndexOf("connection", StringComparison.Ordinal) != -1)
		  {
			configuration.Properties.remove(str);
		  }
		}
		configuration.setProperty("hibernate.search.indexing_strategy", "manual");
		configuration.setProperty("hibernate.search.autoregister_listeners", "false");
		configuration.setProperty("hibernate.temp.use_jdbc_metadata_defaults", "false");
		if (!paramBoolean)
		{
		  configuration.setProperty("hibernate.databaseSchemaUpdate", "false");
		  configuration.setProperty("hibernate.hbm2ddl.auto", "none");
		}
		if (paramInt == ProjectServerDBUtil.ORACLE_DBMS)
		{
		  configuration.registerTypeOverride(new NotNullStringType(), new string[] {"costos_string"});
		  configuration.registerTypeOverride(new NotNullTextType(), new string[] {"costos_text"});
		}
		else
		{
		  configuration.registerTypeOverride(new CostOSString256Type(), new string[] {"costos_string"});
		  configuration.registerTypeOverride(new CostOSTextType());
		}
		configuration.registerTypeOverride(new UnitAliasType(paramGroupCodesProvider, "unit_alias"));
		for (sbyte b = 1; b <= 9; b++)
		{
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)10, b, "eps_level" + b + "_code", (short)2));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)-1, b, "wbs1_level" + b + "_code", (short)2));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)-2, b, "wbs2_level" + b + "_code", (short)2));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)-3, b, "location_level" + b + "_code", (short)2));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)-4, b, "paramitem_level" + b + "_code", (short)2));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)-1, b, "wbs1_level" + b + "_item_code", (short)5));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)-2, b, "wbs2_level" + b + "_item_code", (short)5));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)-1, b, "wbs1_level" + b + "_unit", (short)4));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)-2, b, "wbs2_level" + b + "_unit", (short)4));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)-1, b, "wbs1_level" + b + "_qty", (short)6));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)-2, b, "wbs2_level" + b + "_qty", (short)6));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)10, b, "eps_level" + b + "_title", (short)0));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)-1, b, "wbs1_level" + b + "_title", (short)0));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)-2, b, "wbs2_level" + b + "_title", (short)0));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)-3, b, "location_level" + b + "_title", (short)0));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)-4, b, "paramitem_level" + b + "_title", (short)0));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)1, b, "groupcode1_level" + b + "_code", (short)2));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)2, b, "groupcode2_level" + b + "_code", (short)2));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)3, b, "groupcode3_level" + b + "_code", (short)2));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)4, b, "groupcode4_level" + b + "_code", (short)2));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)5, b, "groupcode5_level" + b + "_code", (short)2));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)6, b, "groupcode6_level" + b + "_code", (short)2));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)7, b, "groupcode7_level" + b + "_code", (short)2));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)8, b, "groupcode8_level" + b + "_code", (short)2));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)9, b, "groupcode9_level" + b + "_code", (short)2));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)1, b, "groupcode1_level" + b + "_title", (short)0));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)2, b, "groupcode2_level" + b + "_title", (short)0));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)3, b, "groupcode3_level" + b + "_title", (short)0));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)4, b, "groupcode4_level" + b + "_title", (short)0));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)5, b, "groupcode5_level" + b + "_title", (short)0));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)6, b, "groupcode6_level" + b + "_title", (short)0));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)7, b, "groupcode7_level" + b + "_title", (short)0));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)8, b, "groupcode8_level" + b + "_title", (short)0));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)9, b, "groupcode9_level" + b + "_title", (short)0));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)1, b, "groupcode1_level" + b + "_description", (short)1));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)2, b, "groupcode2_level" + b + "_description", (short)1));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)3, b, "groupcode3_level" + b + "_description", (short)1));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)4, b, "groupcode4_level" + b + "_description", (short)1));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)5, b, "groupcode5_level" + b + "_description", (short)1));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)6, b, "groupcode6_level" + b + "_description", (short)1));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)7, b, "groupcode7_level" + b + "_description", (short)1));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)8, b, "groupcode8_level" + b + "_description", (short)1));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)9, b, "groupcode9_level" + b + "_description", (short)1));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)1, b, "groupcode1_level" + b + "_unit", (short)4));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)2, b, "groupcode2_level" + b + "_unit", (short)4));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)3, b, "groupcode3_level" + b + "_unit", (short)4));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)4, b, "groupcode4_level" + b + "_unit", (short)4));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)5, b, "groupcode5_level" + b + "_unit", (short)4));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)6, b, "groupcode6_level" + b + "_unit", (short)4));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)7, b, "groupcode7_level" + b + "_unit", (short)4));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)8, b, "groupcode8_level" + b + "_unit", (short)4));
		  configuration.registerTypeOverride(new GroupCodeType(paramGroupCodesProvider, (short)9, b, "groupcode9_level" + b + "_unit", (short)4));
		}
		configuration.setProperty("hibernate.connection.isolation", "1");
		configuration.setProperty("hibernate.cache.jdbc.batch_size", "50");
		configuration.setProperty("hibernate.cache.use_second_level_cache", "false");
		configuration.setProperty("hibernate.cache.use_query_cache", "false");
		configuration.setProperty("hibernate.cache.provider_class", "org.hibernate.cache.NoCacheProvider");
		if (paramInt == ProjectServerDBUtil.ORACLE_DBMS)
		{
		  configuration.setProperty("hibernate.dialect", "org.hibernate.dialect.Oracle10gDialect");
		  configuration.setProperty("hibernate.connection.driver_class", "oracle.jdbc.driver.OracleDriver");
		}
		else if (paramInt == ProjectServerDBUtil.MYSQL_DBMS)
		{
		  configuration.setProperty("hibernate.dialect", "Desktop.common.nomitech.common.db.dialect.MySQL5Dialect");
		  configuration.setProperty("hibernate.connection.driver_class", "org.mariadb.jdbc.Driver");
		}
		else if (paramInt == ProjectServerDBUtil.SQLSERVER_DBMS)
		{
		  configuration.setProperty("hibernate.dialect", "Desktop.common.nomitech.common.db.dialect.SQLServerDialect");
		  configuration.setProperty("hibernate.connection.driver_class", "net.sourceforge.jtds.jdbc.Driver");
		}
		else
		{
		  configuration.setProperty("hibernate.dialect", "Desktop.common.nomitech.common.db.dialect.HSQLDialect");
		  configuration.setProperty("hibernate.connection.driver_class", "org.hsqldb.jdbcDriver");
		}
		return configuration;
	  }

	  public static ProjectSessionFactoryBuilder Instance
	  {
		  get
		  {
			  return s_instance;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\ProjectSessionFactoryBuilder.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}