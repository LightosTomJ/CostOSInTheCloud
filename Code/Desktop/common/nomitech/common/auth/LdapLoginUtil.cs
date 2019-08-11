using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.auth
{
	using MBeanServerLocator = org.jboss.mx.util.MBeanServerLocator;
	using JaasSecurityDomainMBean = org.jboss.security.plugins.JaasSecurityDomainMBean;

	public class LdapLoginUtil
	{
	  protected internal string bindDN;

	  protected internal string bindCredential;

	  protected internal string baseDN;

	  protected internal string baseFilter;

	  protected internal string rolesCtxDN;

	  protected internal string roleFilter;

	  protected internal string roleAttributeID;

	  protected internal string roleNameAttributeID;

	  protected internal bool roleAttributeIsDN;

	  protected internal bool parseRoleNameFromDN;

	  protected internal int recursion = 0;

	  protected internal int searchTimeLimit = 10000;

	  protected internal int searchScope = 2;

	  protected internal bool trace;

	  private IList<string> userRoles;

	  private System.Collections.IDictionary options;

	  public LdapLoginUtil(System.Collections.IDictionary paramMap)
	  {
		  this.options = paramMap;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public javax.naming.ldap.InitialLdapContext makeLdapInitContext() throws Exception
	  public virtual InitialLdapContext makeLdapInitContext()
	  {
		this.bindDN = (string)this.options["bindDN"];
		this.bindCredential = (string)this.options["bindCredential"];
		string str1 = (string)this.options["jaasSecurityDomain"];
		if (!string.ReferenceEquals(str1, null))
		{
		  ObjectName objectName = new ObjectName(str1);
		  char[] arrayOfChar = LdapCodeAction.decode(this.bindCredential, objectName);
		  this.bindCredential = new string(arrayOfChar);
		}
		this.baseDN = (string)this.options["baseCtxDN"];
		this.baseFilter = (string)this.options["baseFilter"];
		this.roleFilter = (string)this.options["roleFilter"];
		this.roleAttributeID = (string)this.options["roleAttributeID"];
		if (string.ReferenceEquals(this.roleAttributeID, null))
		{
		  this.roleAttributeID = "role";
		}
		string str2 = (string)this.options["roleAttributeIsDN"];
		this.roleAttributeIsDN = Convert.ToBoolean(str2);
		this.roleNameAttributeID = (string)this.options["roleNameAttributeID"];
		if (string.ReferenceEquals(this.roleNameAttributeID, null))
		{
		  this.roleNameAttributeID = "name";
		}
		string str3 = (string)this.options["parseRoleNameFromDN"];
		this.parseRoleNameFromDN = Convert.ToBoolean(str3);
		this.rolesCtxDN = (string)this.options["rolesCtxDN"];
		string str4 = (string)this.options["roleRecursion"];
		try
		{
		  this.recursion = int.Parse(str4);
		}
		catch (Exception)
		{
		  this.recursion = 0;
		}
		string str5 = (string)this.options["searchTimeLimit"];
		if (!string.ReferenceEquals(str5, null))
		{
		  try
		  {
			this.searchTimeLimit = int.Parse(str5);
		  }
		  catch (System.FormatException)
		  {
		  }
		}
		string str6 = (string)this.options["searchScope"];
		if ("OBJECT_SCOPE".Equals(str6, StringComparison.OrdinalIgnoreCase))
		{
		  this.searchScope = 0;
		}
		else if ("ONELEVEL_SCOPE".Equals(str6, StringComparison.OrdinalIgnoreCase))
		{
		  this.searchScope = 1;
		}
		if ("SUBTREE_SCOPE".Equals(str6, StringComparison.OrdinalIgnoreCase))
		{
		  this.searchScope = 2;
		}
		return constructInitialLdapContext(this.bindDN, this.bindCredential);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private javax.naming.ldap.InitialLdapContext constructInitialLdapContext(String paramString, Object paramObject) throws javax.naming.NamingException
	  private InitialLdapContext constructInitialLdapContext(string paramString, object paramObject)
	  {
		Properties properties = new Properties();
		foreach (DictionaryEntry entry in this.options.SetOfKeyValuePairs())
		{
		  properties.put(entry.Key, entry.Value);
		}
		string str1 = properties.getProperty("java.naming.factory.initial");
		if (string.ReferenceEquals(str1, null))
		{
		  str1 = "com.sun.jndi.ldap.LdapCtxFactory";
		  properties.setProperty("java.naming.factory.initial", str1);
		}
		string str2 = properties.getProperty("java.naming.security.authentication");
		if (string.ReferenceEquals(str2, null))
		{
		  properties.setProperty("java.naming.security.authentication", "simple");
		}
		string str3 = properties.getProperty("java.naming.security.protocol");
		string str4 = (string)this.options["java.naming.provider.url"];
		if (string.ReferenceEquals(str4, null))
		{
		  str4 = "ldap://localhost:" + ((!string.ReferenceEquals(str3, null) && str3.Equals("ssl")) ? "636" : "389");
		}
		properties.setProperty("java.naming.provider.url", str4);
		if (!string.ReferenceEquals(paramString, null))
		{
		  properties.setProperty("java.naming.security.principal", paramString);
		}
		if (paramObject != null)
		{
		  properties.put("java.naming.security.credentials", paramObject);
		}
		return new InitialLdapContext(properties, null);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.List<String> findRolesOfUser(javax.naming.ldap.InitialLdapContext paramInitialLdapContext, javax.naming.directory.SearchControls paramSearchControls, String paramString1, String paramString2, int paramInt1, int paramInt2) throws javax.naming.NamingException
	  public virtual IList<string> findRolesOfUser(InitialLdapContext paramInitialLdapContext, SearchControls paramSearchControls, string paramString1, string paramString2, int paramInt1, int paramInt2)
	  {
		this.userRoles = new List<object>();
		rolesSearch(paramInitialLdapContext, paramSearchControls, paramString1, paramString2, paramInt1, paramInt2);
		return this.userRoles;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected void rolesSearch(javax.naming.ldap.InitialLdapContext paramInitialLdapContext, javax.naming.directory.SearchControls paramSearchControls, String paramString1, String paramString2, int paramInt1, int paramInt2) throws javax.naming.NamingException
	  protected internal virtual void rolesSearch(InitialLdapContext paramInitialLdapContext, SearchControls paramSearchControls, string paramString1, string paramString2, int paramInt1, int paramInt2)
	  {
		object[] arrayOfObject = new object[] {paramString1, paramString2};
		namingEnumeration = paramInitialLdapContext.search(this.rolesCtxDN, this.roleFilter, arrayOfObject, paramSearchControls);
		try
		{
		  while (namingEnumeration.hasMore())
		  {
			SearchResult searchResult = (SearchResult)namingEnumeration.next();
			string str = canonicalize(searchResult.Name);
			if (paramInt2 == 0 && this.roleAttributeIsDN && !string.ReferenceEquals(this.roleNameAttributeID, null))
			{
			  if (this.parseRoleNameFromDN)
			  {
				parseRole(str);
			  }
			  else
			  {
				string[] arrayOfString1 = new string[] {this.roleNameAttributeID};
				Attributes attributes1 = paramInitialLdapContext.getAttributes(str, arrayOfString1);
				Attribute attribute = attributes1.get(this.roleNameAttributeID);
				if (attribute != null)
				{
				  for (sbyte b = 0; b < attribute.size(); b++)
				  {
					string str1 = (string)attribute.get(b);
					addRole(str1);
				  }
				}
			  }
			}
			string[] arrayOfString = new string[] {this.roleAttributeID};
			Attributes attributes = paramInitialLdapContext.getAttributes(str, arrayOfString);
			if (attributes != null && attributes.size() > 0)
			{
			  Attribute attribute = attributes.get(this.roleAttributeID);
			  for (sbyte b = 0; b < attribute.size(); b++)
			  {
				string str1 = (string)attribute.get(b);
				if (this.roleAttributeIsDN && this.parseRoleNameFromDN)
				{
				  parseRole(str1);
				}
				else if (this.roleAttributeIsDN)
				{
				  string str2 = str1;
				  string[] arrayOfString1 = new string[] {this.roleNameAttributeID};
				  try
				  {
					Attributes attributes1 = paramInitialLdapContext.getAttributes(str2, arrayOfString1);
					Attribute attribute1 = attributes1.get(this.roleNameAttributeID);
					if (attribute1 != null)
					{
					  for (sbyte b1 = 0; b1 < attribute1.size(); b1++)
					  {
						str1 = (string)attribute1.get(b1);
						addRole(str1);
					  }
					}
				  }
				  catch (NamingException)
				  {
				  }
				}
				else
				{
				  addRole(str1);
				}
			  }
			}
			if (paramInt2 < paramInt1)
			{
			  rolesSearch(paramInitialLdapContext, paramSearchControls, paramString1, str, paramInt1, paramInt2 + 1);
			}
		  }
		}
		finally
		{
		  if (namingEnumeration != null)
		  {
			namingEnumeration.close();
		  }
		}
	  }

	  private string canonicalize(string paramString)
	  {
		string str = paramString;
		int i = paramString.Length;
		if (paramString.EndsWith("\"", StringComparison.Ordinal))
		{
		  str = paramString.Substring(0, i - 1) + "," + this.rolesCtxDN + "\"";
		}
		else
		{
		  str = paramString + "," + this.rolesCtxDN;
		}
		return str;
	  }

	  private void addRole(string paramString)
	  {
		if (!string.ReferenceEquals(paramString, null))
		{
		  try
		  {
			this.userRoles.Add(paramString);
		  }
		  catch (Exception)
		  {
		  }
		}
	  }

	  private void parseRole(string paramString)
	  {
		StringTokenizer stringTokenizer = new StringTokenizer(paramString, ",");
		while (stringTokenizer != null && stringTokenizer.hasMoreTokens())
		{
		  string str = stringTokenizer.nextToken();
		  if (str.IndexOf(this.roleNameAttributeID, StringComparison.Ordinal) > -1)
		  {
			StringTokenizer stringTokenizer1 = new StringTokenizer(str, "=");
			stringTokenizer1.nextToken();
			addRole(stringTokenizer1.nextToken());
		  }
		}
	  }

	  private class LdapCodeAction : PrivilegedExceptionAction
	  {
		internal string password;

		internal ObjectName serviceName;

		internal LdapCodeAction(string param1String, ObjectName param1ObjectName)
		{
		  this.password = param1String;
		  this.serviceName = param1ObjectName;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Object run() throws Exception
		public virtual object run()
		{
		  MBeanServer mBeanServer = MBeanServerLocator.locateJBoss();
		  JaasSecurityDomainMBean jaasSecurityDomainMBean = (JaasSecurityDomainMBean)MBeanServerInvocationHandler.newProxyInstance(mBeanServer, this.serviceName, typeof(JaasSecurityDomainMBean), false);
		  sbyte[] arrayOfByte = jaasSecurityDomainMBean.decode64(this.password);
		  string str = StringHelper.NewString(arrayOfByte, "UTF-8");
		  return str.ToCharArray();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: static char[] decode(String param1String, javax.management.ObjectName param1ObjectName) throws Exception
		internal static char[] decode(string param1String, ObjectName param1ObjectName)
		{
		  LdapCodeAction ldapCodeAction = new LdapCodeAction(param1String, param1ObjectName);
		  try
		  {
			return (char[])AccessController.doPrivileged(ldapCodeAction);
		  }
		  catch (PrivilegedActionException privilegedActionException)
		  {
			throw privilegedActionException.Exception;
		  }
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\auth\LdapLoginUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}