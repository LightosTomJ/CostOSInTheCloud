using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.auth
{
	using NamingUtil = nomitech.common.util.NamingUtil;
	using StringUtils = nomitech.common.util.StringUtils;
	using Logger = org.jboss.logging.Logger;
	using MBeanServerLocator = org.jboss.mx.util.MBeanServerLocator;
	using XMLLoginConfigImpl = org.jboss.security.auth.login.XMLLoginConfigImpl;

	public class ActiveDirectoryUserManagement : UserManagement
	{
	  protected internal readonly Logger log = Logger.getLogger(this.GetType());

	  private string[] attrIDs = new string[] {"cn", "name", "displayName", "description", "countryCode", "userPrincipalName", "sAMAccountName"};

	  private AppConfigurationEntry cesLdapConfig = null;

	  public virtual EJBLocalHome EJBLocalHome
	  {
		  get
		  {
			  return null;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public boolean isIdentical(javax.ejb.EJBLocalObject paramEJBLocalObject) throws javax.ejb.EJBException
	  public virtual bool isIdentical(EJBLocalObject paramEJBLocalObject)
	  {
		  return false;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Object getPrimaryKey() throws javax.ejb.EJBException
	  public virtual object PrimaryKey
	  {
		  get
		  {
			  return null;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void remove() throws javax.ejb.RemoveException, javax.ejb.EJBException
	  public virtual void remove()
	  {
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public ActiveDirectoryUserManagement() throws javax.ejb.RemoveException, javax.ejb.EJBException
	  public ActiveDirectoryUserManagement()
	  {
		  Configuration;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public javax.security.auth.login.AppConfigurationEntry getConfiguration() throws javax.ejb.EJBException
	  public virtual AppConfigurationEntry Configuration
	  {
		  get
		  {
			if (this.cesLdapConfig != null)
			{
			  return this.cesLdapConfig;
			}
			try
			{
			  MBeanServer mBeanServer = MBeanServerLocator.locateJBoss();
			  ObjectName objectName = new ObjectName("jboss.security:service=XMLLoginConfig");
			  object[] arrayOfObject = new object[] {null};
			  string[] arrayOfString = new string[] {"javax.security.auth.login.Configuration"};
			  object @object = mBeanServer.invoke(objectName, "getConfiguration", arrayOfObject, arrayOfString);
			  XMLLoginConfigImpl xMLLoginConfigImpl = (XMLLoginConfigImpl)@object;
			  AppConfigurationEntry[] arrayOfAppConfigurationEntry = xMLLoginConfigImpl.getAppConfigurationEntry("ces");
			  foreach (AppConfigurationEntry appConfigurationEntry in arrayOfAppConfigurationEntry)
			  {
				if (appConfigurationEntry.LoginModuleName.IndexOf("LdapExtLoginModule") != -1)
				{
				  this.cesLdapConfig = appConfigurationEntry;
				}
			  }
			  if (this.cesLdapConfig == null)
			  {
				throw new Exception("LDAP Configuration not available.");
			  }
			}
			catch (Exception exception)
			{
			  Console.WriteLine(exception.ToString());
			  Console.Write(exception.StackTrace);
			  throw new EJBException(exception.Message);
			}
			return this.cesLdapConfig;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void flushAuthenticationCache() throws javax.ejb.RemoveException, javax.ejb.EJBException
	  public virtual void flushAuthenticationCache()
	  {
		try
		{
		  if (NamingUtil.Instance.JBoss)
		  {
			MBeanServer mBeanServer = MBeanServerLocator.locateJBoss();
			string str = "jboss.security:service=JaasSecurityManager";
			ObjectName objectName = new ObjectName(str);
			object[] arrayOfObject = new object[] {"ces"};
			string[] arrayOfString = new string[] {"java.lang.String"};
			mBeanServer.invoke(objectName, "flushAuthenticationCache", arrayOfObject, arrayOfString);
		  }
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw new EJBException(exception.Message);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public boolean checkUserExists(String paramString) throws javax.ejb.EJBException
	  public virtual bool checkUserExists(string paramString)
	  {
		bool @bool = false;
		LdapLoginUtil ldapLoginUtil = new LdapLoginUtil(Configuration.Options);
		try
		{
		  InitialLdapContext initialLdapContext = ldapLoginUtil.makeLdapInitContext();
		  SearchControls searchControls = new SearchControls();
		  searchControls.SearchScope = 2;
		  searchControls.ReturningAttributes = new string[0];
		  searchControls.TimeLimit = 10000;
		  string str1 = Configuration.Options.get("rolesCtxDN").ToString();
		  string str2 = "(&(objectclass=person)(sAMAccountName=" + paramString + "))";
		  NamingEnumeration namingEnumeration = initialLdapContext.search(str1, str2, searchControls);
		  if (namingEnumeration.hasMoreElements())
		  {
			@bool = true;
		  }
		  namingEnumeration.close();
		  initialLdapContext.close();
		}
		catch (Exception exception)
		{
		  throw new EJBException(exception.Message);
		}
		return @bool;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public UserAndRolesData getUserAndRoleData(String paramString) throws javax.ejb.EJBException
	  public virtual UserAndRolesData getUserAndRoleData(string paramString)
	  {
		LdapLoginUtil ldapLoginUtil = new LdapLoginUtil(Configuration.Options);
		UserAndRolesData userAndRolesData = null;
		try
		{
		  InitialLdapContext initialLdapContext = ldapLoginUtil.makeLdapInitContext();
		  SearchControls searchControls = new SearchControls();
		  searchControls.SearchScope = 2;
		  searchControls.ReturningAttributes = this.attrIDs;
		  searchControls.TimeLimit = 10000;
		  string str1 = Configuration.Options.get("rolesCtxDN").ToString();
		  string str2 = "(&(objectclass=person)(sAMAccountName=" + paramString + "))";
		  NamingEnumeration namingEnumeration = initialLdapContext.search(str1, str2, searchControls);
		  if (namingEnumeration.hasMoreElements())
		  {
			userAndRolesData = resultToUserRolesData((SearchResult)namingEnumeration.nextElement(), initialLdapContext, ldapLoginUtil, true);
		  }
		  else
		  {
			throw new RemoteException(paramString + " was not found, it may have been deleted.");
		  }
		  initialLdapContext.close();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw new EJBException(exception.Message);
		}
		return userAndRolesData;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private UserAndRolesData resultToUserRolesData(javax.naming.directory.SearchResult paramSearchResult, javax.naming.ldap.InitialLdapContext paramInitialLdapContext, LdapLoginUtil paramLdapLoginUtil, boolean paramBoolean) throws Exception
	  private UserAndRolesData resultToUserRolesData(SearchResult paramSearchResult, InitialLdapContext paramInitialLdapContext, LdapLoginUtil paramLdapLoginUtil, bool paramBoolean)
	  {
		UserAndRolesData userAndRolesData = new UserAndRolesData();
		PrincipalsData principalsData = new PrincipalsData();
		Attributes attributes = paramSearchResult.Attributes;
		string str1 = StringUtils.getValueFromAttribute(attributes.get("displayName"));
		string str2 = StringUtils.getValueFromAttribute(attributes.get("description"));
		string str3 = StringUtils.getValueFromAttribute(attributes.get("sAMAccountName"));
		string str4 = StringUtils.getValueFromAttribute(attributes.get("userPrincipalName"));
		if (string.ReferenceEquals(str3, null))
		{
		  throw new Exception("sAMAccountName not found for: " + paramSearchResult.Name);
		}
		if (string.ReferenceEquals(str1, null))
		{
		  str1 = str3;
		}
		if (string.ReferenceEquals(str4, null))
		{
		  str4 = "";
		}
		principalsData.Name = str1;
		principalsData.EMail = str4;
		principalsData.PrincipalId = str3;
		principalsData.Password = "*******";
		userAndRolesData.PrincipalsData = principalsData;
		if (!paramBoolean)
		{
		  userAndRolesData.RolesData = new RolesData[0];
		}
		else
		{
		  SearchControls searchControls = new SearchControls();
		  searchControls.SearchScope = 2;
		  searchControls.ReturningAttributes = this.attrIDs;
		  searchControls.TimeLimit = 10000;
		  string str5 = str3 + "," + Configuration.Options.get("baseCtxDN");
		  string str6 = (string)Configuration.Options.get("roleRecursion");
		  int i = 0;
		  try
		  {
			i = int.Parse(str6);
		  }
		  catch (Exception)
		  {
			i = 0;
		  }
		  System.Collections.IList list = paramLdapLoginUtil.findRolesOfUser(paramInitialLdapContext, searchControls, str3, str5, i, 0);
		  List<object> arrayList = new List<object>(list.Count);
		  foreach (string str in list)
		  {
			arrayList.Add(new RolesData(str, str3, str, "Roles"));
		  }
		  userAndRolesData.RolesData = (RolesData[])arrayList.ToArray(typeof(RolesData));
		}
		return userAndRolesData;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.Collection getAllUserAndRoleData() throws javax.ejb.EJBException
	  public virtual System.Collections.ICollection AllUserAndRoleData
	  {
		  get
		  {
			LdapLoginUtil ldapLoginUtil = new LdapLoginUtil(Configuration.Options);
			List<object> arrayList = new List<object>();
			try
			{
			  InitialLdapContext initialLdapContext = ldapLoginUtil.makeLdapInitContext();
			  SearchControls searchControls = new SearchControls();
			  searchControls.SearchScope = 2;
			  searchControls.ReturningAttributes = this.attrIDs;
			  searchControls.TimeLimit = 10000;
			  string str1 = Configuration.Options.get("rolesCtxDN").ToString();
			  string str2 = str1;
			  if (Configuration.Options.get("rolesPlaceCtxDN") != null)
			  {
				str2 = Configuration.Options.get("rolesPlaceCtxDN").ToString();
			  }
			  string str3 = "(&(objectclass=person)(|(memberOf=CN=CESAdmin," + str2 + ")(memberOf=CN=" + "CESDatabaseUser" + "," + str2 + ")))";
			  NamingEnumeration namingEnumeration = initialLdapContext.search(str1, str3, searchControls);
			  while (namingEnumeration.hasMoreElements())
			  {
				arrayList.Add(resultToUserRolesData((SearchResult)namingEnumeration.nextElement(), initialLdapContext, ldapLoginUtil, false));
			  }
			  initialLdapContext.close();
			}
			catch (Exception exception)
			{
			  throw new EJBException(exception.Message);
			}
			return arrayList;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.Collection filterUserAndRoleDataByRole(String paramString) throws javax.ejb.EJBException
	  public virtual System.Collections.ICollection filterUserAndRoleDataByRole(string paramString)
	  {
		LdapLoginUtil ldapLoginUtil = new LdapLoginUtil(Configuration.Options);
		List<object> arrayList = new List<object>();
		try
		{
		  InitialLdapContext initialLdapContext = ldapLoginUtil.makeLdapInitContext();
		  SearchControls searchControls = new SearchControls();
		  searchControls.SearchScope = 2;
		  searchControls.ReturningAttributes = this.attrIDs;
		  searchControls.TimeLimit = 10000;
		  string str1 = Configuration.Options.get("rolesCtxDN").ToString();
		  string str2 = str1;
		  if (Configuration.Options.get("rolesPlaceCtxDN") != null)
		  {
			str2 = Configuration.Options.get("rolesPlaceCtxDN").ToString();
		  }
		  string str3 = "(&(objectclass=person)(|(memberOf=CN=" + paramString + "," + str2 + ")))";
		  NamingEnumeration namingEnumeration = initialLdapContext.search(str1, str3, searchControls);
		  while (namingEnumeration.hasMoreElements())
		  {
			arrayList.Add(resultToUserRolesData((SearchResult)namingEnumeration.nextElement(), initialLdapContext, ldapLoginUtil, false));
		  }
		  initialLdapContext.close();
		}
		catch (Exception exception)
		{
		  throw new EJBException(exception.Message);
		}
		return arrayList;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void addUserAndRoleData(UserAndRolesData paramUserAndRolesData) throws UserManagementException
	  public virtual void addUserAndRoleData(UserAndRolesData paramUserAndRolesData)
	  {
		  throw new UserManagementException("unsupported operation");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void removeUserAndRoleData(UserAndRolesData paramUserAndRolesData) throws UserManagementException
	  public virtual void removeUserAndRoleData(UserAndRolesData paramUserAndRolesData)
	  {
		  throw new UserManagementException("unsupported operation");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void updateUserAndRoleData(UserAndRolesData paramUserAndRolesData) throws UserManagementException
	  public virtual void updateUserAndRoleData(UserAndRolesData paramUserAndRolesData)
	  {
		  throw new UserManagementException("unsupported operation");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public boolean checkInTheSameTeam(String paramString1, String paramString2) throws javax.ejb.EJBException
	  public virtual bool checkInTheSameTeam(string paramString1, string paramString2)
	  {
		UserAndRolesData userAndRolesData1 = getUserAndRoleData(paramString1);
		UserAndRolesData userAndRolesData2 = getUserAndRoleData(paramString2);
		foreach (string str in userAndRolesData1.Roles)
		{
		  foreach (string str1 in userAndRolesData2.Roles)
		  {
			if (str.StartsWith("CESCostTeam", StringComparison.Ordinal) && str.Equals(str1))
			{
			  return true;
			}
		  }
		}
		return false;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.Collection findUserAndRoleDataByQuery(String paramString) throws javax.ejb.EJBException
	  public virtual System.Collections.ICollection findUserAndRoleDataByQuery(string paramString)
	  {
		LdapLoginUtil ldapLoginUtil = new LdapLoginUtil(Configuration.Options);
		List<object> arrayList = new List<object>();
		try
		{
		  InitialLdapContext initialLdapContext = ldapLoginUtil.makeLdapInitContext();
		  SearchControls searchControls = new SearchControls();
		  searchControls.SearchScope = 2;
		  searchControls.ReturningAttributes = this.attrIDs;
		  searchControls.TimeLimit = 10000;
		  string str1 = Configuration.Options.get("rolesCtxDN").ToString();
		  string str2 = str1;
		  if (Configuration.Options.get("rolesPlaceCtxDN") != null)
		  {
			str2 = Configuration.Options.get("rolesPlaceCtxDN").ToString();
		  }
		  string str3 = "(&(objectclass=person)(|(sAMAccountName=*" + paramString + "*)(name=*" + paramString + "*))(|(memberOf=CN=" + "CESAdmin" + "," + str2 + ")(memberOf=CN=" + "CESDatabaseUser" + "," + str2 + ")))";
		  NamingEnumeration namingEnumeration = initialLdapContext.search(str1, str3, searchControls);
		  while (namingEnumeration.hasMoreElements())
		  {
			arrayList.Add(resultToUserRolesData((SearchResult)namingEnumeration.nextElement(), initialLdapContext, ldapLoginUtil, false));
		  }
		  initialLdapContext.close();
		}
		catch (Exception exception)
		{
		  throw new EJBException(exception.Message);
		}
		return arrayList;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\auth\ActiveDirectoryUserManagement.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}