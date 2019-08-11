using System;
using System.Collections.Generic;
using System.IO;

namespace Desktop.common.nomitech.common
{
	using PrincipalsData = Desktop.common.nomitech.common.auth.PrincipalsData;
	using RolesData = Desktop.common.nomitech.common.auth.RolesData;
	using UserAndRolesData = Desktop.common.nomitech.common.auth.UserAndRolesData;
	using BaseDBProperties = Desktop.common.nomitech.common.@base.BaseDBProperties;
	using AddOnUtil = Desktop.common.nomitech.common.util.AddOnUtil;
	using CryptUtil = Desktop.common.nomitech.common.util.CryptUtil;
	using StringUtils = Desktop.common.nomitech.common.util.StringUtils;

	public class LocalDBProperties : Properties, BaseDBProperties
	{
	  public const string SCHEMA_VERSION = "6.2.20";

	  private static readonly string[] s_userRoles = new string[] {"CESProjectReader", "CESAssemblyWriter", "CESDatabaseUser", "CESDatabaseUser", "CESAssemblyWriter", "CESDatabaseUser", "CESDatabaseUser", "CESAssemblyWriter", "CESParamItemWriter", "CESAssemblyWriter", "CESProjectWriter", "CESDatabaseUser", "CESAssemblyWriter", "CESDatabaseUser", "CESAssemblyWriter", "CESDatabaseUser", "CESAssemblyWriter", "CESAssemblyWriter", "CESAssemblyWriter", "CESDatabaseUser", "CESDatabaseUser", "CESDatabaseUser", "CESDatabaseUser", "CESDatabaseUser", "CESDatabaseUser", "CESDatabaseUser", "CESDatabaseUser", "CESDatabaseUser", "CESDatabaseUser", "CESDatabaseUser", "CESDatabaseUser", "CESAssemblyWriter", "CESAssemblyWriter", "CESAssemblyWriter", "CESAssemblyWriter", "CESAssemblyWriter", "CESAssemblyWriter", "CESAssemblyWriter", "CESAssemblyWriter", "CESAssemblyWriter", "CESAssemblyWriter", "CESDatabaseUser", "CESDatabaseUser", "CESProjectReader"};

	  private const long serialVersionUID = 1L;

	  public const string OWN_READ = "OR";

	  public const string OWN_WRITE = "OW";

	  public const string ALL_READ = "R";

	  public const string ALL_WRITE = "W";

	  private string o_host = null;

	  private string o_userId = null;

	  private string o_password = null;

	  public static readonly string[] FIELDS = new string[] {"database.name", "database.author", "database.creationdate", "database.lastaccessdate", "database.accessibility", "database.accessmode", "database.decimal.scale", "database.divider.scale", "database.rounding.mode", "database.username", "database.password", "database.schema.version"};

	  public static readonly string[] GC_FIELDS = new string[] {"grouping.groupcode1.name", "grouping.groupcode2.name", "grouping.groupcode3.name", "grouping.groupcode4.name", "grouping.groupcode5.name", "grouping.groupcode6.name", "grouping.groupcode7.name", "grouping.groupcode8.name", "grouping.groupcode9.name"};

	  private File o_propFile = null;

	  private bool b_isLoadedFromServer = false;

	  private UserAndRolesData o_userRoleData = null;

	  public LocalDBProperties(string paramString)
	  {
		this.o_propFile = new File(paramString);
		if (this.o_propFile.File)
		{
		  try
		  {
			loadDBProperties(new FileStream(this.o_propFile, FileMode.Open, FileAccess.Read));
			if (StringUtils.isNullOrBlank(getProperty(FIELDS[2])))
			{
			  createBasicProperties();
			  storeDBProperties();
			}
		  }
		  catch (Exception)
		  {
			createDBProperties();
			storeDBProperties();
		  }
		}
		else
		{
		  createDBProperties();
		  storeDBProperties();
		}
	  }

	  public virtual UserAndRolesData UserAndRolesData
	  {
		  get
		  {
			  return this.o_userRoleData;
		  }
		  set
		  {
			this.o_userRoleData = value;
			string[] arrayOfString = this.o_userRoleData.Roles;
			setStringArrayProperty("database.accessibility", arrayOfString);
			setEncProperty("database.username", value.PrincipalsData.PrincipalId);
			setEncProperty("database.password", value.PrincipalsData.Password);
		  }
	  }


	  public virtual string UserId
	  {
		  get
		  {
			  return this.o_userId;
		  }
	  }

	  public virtual string Password
	  {
		  get
		  {
			  return this.o_password;
		  }
	  }

	  public virtual string Host
	  {
		  get
		  {
			  return this.o_host;
		  }
	  }

	  public virtual bool LoadedFromServer
	  {
		  get
		  {
			  return this.b_isLoadedFromServer;
		  }
	  }

	  public virtual void createDBProperties()
	  {
		if (this.b_isLoadedFromServer)
		{
		  return;
		}
		createBasicProperties();
		makeLocalUserAndRolesData();
	  }

	  private void createBasicProperties()
	  {
		if (this.b_isLoadedFromServer)
		{
		  return;
		}
		if (StringUtils.isNullOrBlank(getProperty(FIELDS[0])))
		{
		  setProperty(FIELDS[0], System.getProperty("user.name"));
		}
		if (StringUtils.isNullOrBlank(getProperty(FIELDS[1])))
		{
		  setProperty(FIELDS[1], System.getProperty("user.name"));
		}
		if (StringUtils.isNullOrBlank(getProperty(FIELDS[2])))
		{
		  setProperty(FIELDS[2], "" + DateTimeHelper.CurrentUnixTimeMillis());
		}
		if (StringUtils.isNullOrBlank(getProperty(FIELDS[3])))
		{
		  setProperty(FIELDS[3], "");
		}
		if (StringUtils.isNullOrBlank(getProperty(FIELDS[4])))
		{
		  setStringArrayProperty(FIELDS[4], s_userRoles);
		}
		if (StringUtils.isNullOrBlank(getProperty(FIELDS[5])))
		{
		  setProperty(FIELDS[5], "Local");
		}
		if (StringUtils.isNullOrBlank(getProperty(FIELDS[6])))
		{
		  setProperty(FIELDS[6], "2");
		}
		if (StringUtils.isNullOrBlank(getProperty(FIELDS[7])))
		{
		  setProperty(FIELDS[7], "32");
		}
		if (StringUtils.isNullOrBlank(getProperty(FIELDS[8])))
		{
		  setProperty(FIELDS[8], "4");
		}
		if (StringUtils.isNullOrBlank(getProperty(FIELDS[9])))
		{
		  setEncProperty(FIELDS[9], "sa");
		}
		if (StringUtils.isNullOrBlank(getProperty(FIELDS[10])))
		{
		  setEncProperty(FIELDS[10], "");
		}
		if (StringUtils.isNullOrBlank(getProperty(FIELDS[11])))
		{
		  setProperty(FIELDS[11], "6.2.20");
		}
		for (sbyte b = 0; b < GC_FIELDS.Length; b++)
		{
		  if (string.ReferenceEquals(getProperty(GC_FIELDS[b]), null))
		  {
			setProperty(GC_FIELDS[b], "");
		  }
		}
	  }

	  public virtual void storeDBProperties()
	  {
		try
		{
		  if (this.b_isLoadedFromServer)
		  {
			return;
		  }
		  if (!this.o_propFile.File)
		  {
			Console.WriteLine("Not a file: " + this.o_propFile.AbsolutePath + " but " + this.o_propFile.Directory);
			this.o_propFile.createNewFile();
		  }
		  setProperty(FIELDS[3], "" + DateTimeHelper.CurrentUnixTimeMillis());
		  FileStream fileOutputStream = new FileStream(this.o_propFile, FileMode.Create, FileAccess.Write);
		  store(fileOutputStream, "CostOS Database Properties");
		  fileOutputStream.Flush();
		  fileOutputStream.Close();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void loadDBProperties(java.io.FileInputStream paramFileInputStream) throws Exception
	  public virtual void loadDBProperties(FileStream paramFileInputStream)
	  {
		if (this.b_isLoadedFromServer)
		{
		  return;
		}
		load(paramFileInputStream);
		paramFileInputStream.Close();
		setStringArrayProperty(FIELDS[4], s_userRoles);
		if (string.ReferenceEquals(getProperty("database.accessmode"), null))
		{
		  setProperty("database.accessmode", "Local");
		}
		if (string.ReferenceEquals(getProperty("database.creationdate"), null))
		{
		  setProperty("database.accessmode", "Local");
		}
		for (sbyte b = 0; b < GC_FIELDS.Length; b++)
		{
		  if (string.ReferenceEquals(getProperty(GC_FIELDS[b]), null))
		  {
			setProperty(GC_FIELDS[b], "");
		  }
		}
		makeLocalUserAndRolesData();
	  }

	  public virtual void makeLocalUserAndRolesData()
	  {
		this.o_userRoleData = new UserAndRolesDataAnonymousInnerClass(this);
		PrincipalsData principalsData = new PrincipalsData();
		principalsData.PrincipalId = getEncProperty("database.username");
		principalsData.Password = getEncProperty("database.password");
		this.o_userRoleData.PrincipalsData = principalsData;
		string[] arrayOfString = getStringArrayProperty("database.accessibility");
		RolesData[] arrayOfRolesData = new RolesData[arrayOfString.Length];
		for (sbyte b = 0; b < arrayOfString.Length; b++)
		{
		  RolesData rolesData = new RolesData();
		  rolesData.PrincipalId = principalsData.PrincipalId;
		  rolesData.Role = arrayOfString[b];
		  rolesData.RoleId = arrayOfString[b];
		  arrayOfRolesData[b] = rolesData;
		}
		this.o_userRoleData.RolesData = arrayOfRolesData;
		this.o_userId = principalsData.PrincipalId;
		this.o_password = principalsData.Password;
	  }

	  private class UserAndRolesDataAnonymousInnerClass : UserAndRolesData
	  {
		  private readonly LocalDBProperties outerInstance;

		  public UserAndRolesDataAnonymousInnerClass(LocalDBProperties outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public bool isUserInRoleSSSS(string param1String)
		  {
			  return true;
		  }

		  public bool hasRole(string param1String)
		  {
			  return true;
		  }
	  }

	  public virtual void setIntProperty(string paramString, int paramInt)
	  {
		  setProperty(paramString, Convert.ToString(paramInt));
	  }

	  public virtual int getIntProperty(string paramString)
	  {
		try
		{
		  return int.Parse(getProperty(paramString));
		}
		catch (System.FormatException numberFormatException)
		{
		  Console.WriteLine("ERROR FOR PROPERTY: " + paramString);
		  Console.WriteLine(numberFormatException.ToString());
		  Console.Write(numberFormatException.StackTrace);
		  return -1;
		}
	  }

	  public virtual void setLongProperty(string paramString, long paramLong)
	  {
		  setProperty(paramString, Convert.ToString(paramLong));
	  }

	  public virtual long getLongProperty(string paramString)
	  {
		try
		{
		  return long.Parse(getProperty(paramString));
		}
		catch (System.FormatException numberFormatException)
		{
		  Console.WriteLine("ERROR FOR PROPERTY: " + paramString);
		  Console.WriteLine(numberFormatException.ToString());
		  Console.Write(numberFormatException.StackTrace);
		  return -1L;
		}
	  }

	  public virtual void setEncProperty(string paramString1, string paramString2)
	  {
		if (paramString1.IndexOf(".pass", StringComparison.Ordinal) != -1)
		{
		  setProperty(paramString1, AddOnUtil.Instance.encryptHexString(paramString2));
		}
		else
		{
		  setProperty(paramString1, CryptUtil.Instance.encryptHexString(paramString2));
		}
	  }

	  public virtual string getEncProperty(string paramString)
	  {
		if (string.ReferenceEquals(paramString, null) || string.ReferenceEquals(getProperty(paramString), null))
		{
		  return null;
		}
		if (paramString.IndexOf(".pass", StringComparison.Ordinal) != -1)
		{
		  string str = AddOnUtil.Instance.decryptHexString(getProperty(paramString));
		  if (!string.ReferenceEquals(str, null))
		  {
			return str;
		  }
		}
		return CryptUtil.Instance.decryptHexString(getProperty(paramString));
	  }

	  public virtual bool checkHasAccessibility(string paramString)
	  {
		string[] arrayOfString = (string[])getStringArrayProperty("database.accessibility");
		for (sbyte b = 0; b < arrayOfString.Length; b++)
		{
		  if (arrayOfString[b].Equals(paramString))
		  {
			return true;
		  }
		}
		return false;
	  }

	  public virtual void setStringArrayProperty(string paramString, string[] paramArrayOfString)
	  {
		string str = "";
		for (sbyte b = 0; b < paramArrayOfString.Length; b++)
		{
		  str = str + paramArrayOfString[b] + ",";
		}
		setProperty(paramString, str);
	  }

	  public virtual string[] getStringArrayProperty(string paramString)
	  {
		List<object> vector = new List<object>();
		string str = getProperty(paramString);
		for (sbyte b1 = 0; b1 < str.Length; b1++)
		{
		  for (int i = b1 + true; i <= str.Length; i++)
		  {
			string str1 = str.Substring(b1, i - b1);
			if (str1.EndsWith(",", StringComparison.Ordinal))
			{
			  vector.Add(str.Substring(b1, (i - 1) - b1));
			  b1 = i - 1;
			  i = str.Length;
			}
		  }
		}
		string[] arrayOfString = new string[vector.Count];
		for (sbyte b2 = 0; b2 < vector.Count; b2++)
		{
		  arrayOfString[b2] = (string)vector[b2];
		}
		return arrayOfString;
	  }

	  public virtual string ConnectionHost
	  {
		  get
		  {
			  return null;
		  }
	  }

	  public virtual void refreshUserId(string paramString, UserAndRolesData paramUserAndRolesData)
	  {
	  }

	  public virtual UserAndRolesData getUserAndRolesById(string paramString)
	  {
		  return null;
	  }

	  public virtual Color getUserColorById(string paramString)
	  {
		  return null;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\LocalDBProperties.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}