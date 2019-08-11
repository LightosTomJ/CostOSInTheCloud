using System;
using System.Collections;
using System.Threading;

namespace Desktop.common.org.jboss.security.auth.spi
{
	using Logger = org.jboss.logging.Logger;

	public class LdapExtLoginModule : UsernamePasswordLoginModule
	{
	  private const string ROLES_CTX_DN_OPT = "rolesCtxDN";

	  private const string ROLE_ATTRIBUTE_ID_OPT = "roleAttributeID";

	  private const string ROLE_ATTRIBUTE_IS_DN_OPT = "roleAttributeIsDN";

	  private const string ROLE_NAME_ATTRIBUTE_ID_OPT = "roleNameAttributeID";

	  private const string PARSE_ROLE_NAME_FROM_DN_OPT = "parseRoleNameFromDN";

	  private const string BIND_DN = "bindDN";

	  private const string BIND_CREDENTIAL = "bindCredential";

	  private const string BASE_CTX_DN = "baseCtxDN";

	  private const string BASE_FILTER_OPT = "baseFilter";

	  private const string ROLE_FILTER_OPT = "roleFilter";

	  private const string ROLE_RECURSION = "roleRecursion";

	  private const string DEFAULT_ROLE = "defaultRole";

	  private const string SEARCH_TIME_LIMIT_OPT = "searchTimeLimit";

	  private const string SEARCH_SCOPE_OPT = "searchScope";

	  private const string SECURITY_DOMAIN_OPT = "jaasSecurityDomain";

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

	  private SimpleGroup userRoles = new SimpleGroup("Roles");

	  private Logger authLogger = Logger.getLogger("CESLogger");

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected String getUsersPassword() throws javax.security.auth.login.LoginException
	  protected internal virtual string UsersPassword
	  {
		  get
		  {
			  return "";
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected java.security.acl.Group[] getRoleSets() throws javax.security.auth.login.LoginException
	  protected internal virtual Group[] RoleSets
	  {
		  get
		  {
			  return new Group[] {this.userRoles};
		  }
	  }

	  protected internal virtual bool validatePassword(string paramString1, string paramString2)
	  {
		bool @bool = false;
		if (!string.ReferenceEquals(paramString1, null))
		{
		  if (paramString1.Length == 0)
		  {
			bool bool1 = true;
			string str = (string)this.options.get("allowEmptyPasswords");
			if (!string.ReferenceEquals(str, null))
			{
			  bool1 = Convert.ToBoolean(str);
			}
			if (!bool1)
			{
			  this.log.trace("Rejecting empty password due to allowEmptyPasswords");
			  return false;
			}
		  }
		  try
		  {
			string str = Username;
			@bool = createLdapInitContext(str, paramString1);
			defaultRole();
			@bool = true;
		  }
		  catch (Exception throwable)
		  {
			Console.WriteLine(throwable.ToString());
			Console.Write(throwable.StackTrace);
			ValidateError = throwable;
		  }
		}
		try
		{
		  string[] arrayOfString = UsernameAndPassword;
		  string str1 = arrayOfString[0];
		  string str2 = arrayOfString[1];
		  if (!@bool)
		  {
			this.authLogger.info("Bad password for username=" + str1 + ", " + CurrentClientIpAddress);
		  }
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		return @bool;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private String getCurrentClientIpAddress() throws javax.security.auth.login.LoginException
	  private string CurrentClientIpAddress
	  {
		  get
		  {
			string str = Thread.CurrentThread.Name;
			int i = str.IndexOf('[') + 1;
			int j = str.IndexOf(']') - 1;
			return str.Substring(i, j - i);
		  }
	  }

	  private void defaultRole()
	  {
		try
		{
		  string str = (string)this.options.get("defaultRole");
		  if (string.ReferenceEquals(str, null) || str.Equals(""))
		  {
			return;
		  }
		  Principal principal = createIdentity(str);
		  this.log.trace("Assign user to role " + str);
		  this.userRoles.addMember(principal);
		}
		catch (Exception exception)
		{
		  this.log.debug("could not add default role to user", exception);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private boolean createLdapInitContext(String paramString, Object paramObject) throws Exception
	  private bool createLdapInitContext(string paramString, object paramObject)
	  {
		this.bindDN = (string)this.options.get("bindDN");
		this.bindCredential = (string)this.options.get("bindCredential");
		string str1 = (string)this.options.get("jaasSecurityDomain");
		if (!string.ReferenceEquals(str1, null))
		{
		  ObjectName objectName = new ObjectName(str1);
		  char[] arrayOfChar = DecodeAction.decode(this.bindCredential, objectName);
		  this.bindCredential = new string(arrayOfChar);
		}
		this.baseDN = (string)this.options.get("baseCtxDN");
		this.baseFilter = (string)this.options.get("baseFilter");
		this.roleFilter = (string)this.options.get("roleFilter");
		this.roleAttributeID = (string)this.options.get("roleAttributeID");
		if (string.ReferenceEquals(this.roleAttributeID, null))
		{
		  this.roleAttributeID = "role";
		}
		string str2 = (string)this.options.get("roleAttributeIsDN");
		this.roleAttributeIsDN = Convert.ToBoolean(str2);
		this.roleNameAttributeID = (string)this.options.get("roleNameAttributeID");
		if (string.ReferenceEquals(this.roleNameAttributeID, null))
		{
		  this.roleNameAttributeID = "name";
		}
		string str3 = (string)this.options.get("parseRoleNameFromDN");
		this.parseRoleNameFromDN = Convert.ToBoolean(str3);
		this.rolesCtxDN = (string)this.options.get("rolesCtxDN");
		string str4 = (string)this.options.get("roleRecursion");
		try
		{
		  this.recursion = int.Parse(str4);
		}
		catch (Exception)
		{
		  if (this.trace)
		  {
			this.log.trace("Failed to parse: " + str4 + ", disabling recursion");
		  }
		  this.recursion = 0;
		}
		string str5 = (string)this.options.get("searchTimeLimit");
		if (!string.ReferenceEquals(str5, null))
		{
		  try
		  {
			this.searchTimeLimit = int.Parse(str5);
		  }
		  catch (System.FormatException)
		  {
			if (this.trace)
			{
			  this.log.trace("Failed to parse: " + str5 + ", using searchTimeLimit=" + this.searchTimeLimit);
			}
		  }
		}
		string str6 = (string)this.options.get("searchScope");
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
		initialLdapContext = null;
		try
		{
		  initialLdapContext = constructInitialLdapContext(this.bindDN, this.bindCredential);
		  string str = bindDNAuthentication(initialLdapContext, paramString, paramObject, this.baseDN, this.baseFilter);
		  SearchControls searchControls = new SearchControls();
		  searchControls.SearchScope = this.searchScope;
		  searchControls.ReturningAttributes = new string[0];
		  searchControls.TimeLimit = this.searchTimeLimit;
		  rolesSearch(initialLdapContext, searchControls, paramString, str, this.recursion, 0);
		}
		finally
		{
		  if (initialLdapContext != null)
		  {
			initialLdapContext.close();
		  }
		}
		return true;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected String bindDNAuthentication(javax.naming.ldap.InitialLdapContext paramInitialLdapContext, String paramString1, Object paramObject, String paramString2, String paramString3) throws javax.naming.NamingException
	  protected internal virtual string bindDNAuthentication(InitialLdapContext paramInitialLdapContext, string paramString1, object paramObject, string paramString2, string paramString3)
	  {
		SearchControls searchControls = new SearchControls();
		searchControls.SearchScope = 2;
		searchControls.ReturningAttributes = new string[0];
		searchControls.TimeLimit = this.searchTimeLimit;
		NamingEnumeration namingEnumeration = null;
		object[] arrayOfObject = new object[] {paramString1};
		namingEnumeration = paramInitialLdapContext.search(paramString2, paramString3, arrayOfObject, searchControls);
		if (!namingEnumeration.hasMore())
		{
		  namingEnumeration.close();
		  throw new NamingException("Search of baseDN(" + paramString2 + ") found no matches");
		}
		SearchResult searchResult = (SearchResult)namingEnumeration.next();
		string str1 = searchResult.Name;
		string str2 = null;
		if (searchResult.Relative == true)
		{
		  str2 = str1 + "," + paramString2;
		}
		else
		{
		  throw new NamingException("Can't follow referal for authentication: " + str1);
		}
		namingEnumeration.close();
		namingEnumeration = null;
		InitialLdapContext initialLdapContext = constructInitialLdapContext(str2, paramObject);
		initialLdapContext.close();
		return str2;
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
				  this.log.trace("Using roleDN: " + str2);
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
				  catch (NamingException namingException)
				  {
					this.log.trace("Failed to query roleNameAttrName", namingException);
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

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private javax.naming.ldap.InitialLdapContext constructInitialLdapContext(String paramString, Object paramObject) throws javax.naming.NamingException
	  private InitialLdapContext constructInitialLdapContext(string paramString, object paramObject)
	  {
		Properties properties = new Properties();
		foreach (DictionaryEntry entry in this.options.entrySet())
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
		string str4 = (string)this.options.get("java.naming.provider.url");
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
		traceLdapEnv(properties);
		return new InitialLdapContext(properties, null);
	  }

	  private void traceLdapEnv(Properties paramProperties)
	  {
		if (this.trace)
		{
		  Properties properties = new Properties();
		  properties.putAll(paramProperties);
		  if (properties.containsKey("bindCredential"))
		  {
			properties.setProperty("bindCredential", "***");
		  }
		  if (properties.containsKey("java.naming.security.credentials"))
		  {
			properties.setProperty("java.naming.security.credentials", "***");
		  }
		  this.log.trace("Logging into LDAP server, env=" + properties.ToString());
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
			Principal principal = createIdentity(paramString);
			this.log.trace("Assign user to role " + paramString);
			this.userRoles.addMember(principal);
		  }
		  catch (Exception exception)
		  {
			this.log.debug("Failed to create principal: " + paramString, exception);
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
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\org\jboss\security\auth\spi\LdapExtLoginModule.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}