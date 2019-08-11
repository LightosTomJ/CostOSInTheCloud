using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Desktop.common.org.jboss.security.auth.spi
{
	using Logger = org.jboss.logging.Logger;
	using TransactionDemarcationSupport = org.jboss.tm.TransactionDemarcationSupport;

	public class CostOSLoginModule : UsernamePasswordLoginModule
	{
	  private Logger authLogger = Logger.getLogger("CESLogger");

	  protected internal string dsJndiName;

	  protected internal string principalsQuery = "SELECT HASHKEY, AUTHTYPE FROM PRINCIPALS WHERE PRINCIPALID =? COLLATE SQL_Latin1_General_CP1_CS_AS AND ENBL = 1";

	  protected internal string rolesQuery = "SELECT ROLE, 'Roles' FROM ROLES WHERE PRINCIPALID =? COLLATE SQL_Latin1_General_CP1_CS_AS";

	  protected internal string ldapCongigQuery = "SELECT ENABLE, HOSTNAME, PORT, BASEDN, BINDDN, PASSWORD, ISSSL FROM AD";

	  protected internal bool suspendResume = true;

	  protected internal bool ldapEnabled = false;

	  protected internal string ldapHostname = null;

	  protected internal string ldapPort = null;

	  protected internal string ldapBaseDN = null;

	  protected internal string ldapBindDN = null;

	  protected internal string ldapPassword = null;

	  protected internal bool ldapSSL = false;

	  public virtual void initialize(Subject paramSubject, CallbackHandler paramCallbackHandler, System.Collections.IDictionary paramMap1, System.Collections.IDictionary paramMap2)
	  {
		try
		{
		  base.initialize(paramSubject, paramCallbackHandler, paramMap1, paramMap2);
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		this.dsJndiName = (string)paramMap2["dsJndiName"];
		if (string.ReferenceEquals(this.dsJndiName, null))
		{
		  this.dsJndiName = "java:/DefaultDS";
		}
		object @object = paramMap2["principalsQuery"];
		if (@object != null)
		{
		  this.principalsQuery = @object.ToString();
		}
		@object = paramMap2["rolesQuery"];
		if (@object != null)
		{
		  this.rolesQuery = @object.ToString();
		}
		@object = paramMap2["suspendResume"];
		if (@object != null)
		{
		  this.suspendResume = Convert.ToBoolean(@object.ToString());
		}
		if (this.log.TraceEnabled)
		{
		  this.log.trace("DatabaseServerLoginModule, dsJndiName=" + this.dsJndiName);
		  this.log.trace("principalsQuery=" + this.principalsQuery);
		  this.log.trace("rolesQuery=" + this.rolesQuery);
		  this.log.trace("suspendResume=" + this.suspendResume);
		}
		try
		{
		  initLdapConfig();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
	  }

	  private void initLdapConfig()
	  {
		InitialContext initialContext = new InitialContext();
		DataSource dataSource = (DataSource)initialContext.lookup(this.dsJndiName);
		connection = null;
		PreparedStatement preparedStatement = null;
		resultSet = null;
		try
		{
		  connection = dataSource.Connection;
		  preparedStatement = connection.prepareStatement(this.ldapCongigQuery);
		  resultSet = preparedStatement.executeQuery();
		  if (resultSet.next())
		  {
			this.ldapEnabled = resultSet.getBoolean(1);
			this.ldapHostname = resultSet.getString(2);
			this.ldapPort = "" + resultSet.getInt(3);
			this.ldapBaseDN = resultSet.getString(4);
			this.ldapBindDN = resultSet.getString(5);
			this.ldapPassword = decodeLdapPsw(resultSet.getString(6));
			this.ldapSSL = resultSet.getBoolean(7);
		  }
		  else
		  {
			this.ldapEnabled = false;
			this.ldapHostname = null;
			this.ldapPort = null;
			this.ldapBaseDN = null;
			this.ldapBindDN = null;
			this.ldapPassword = null;
			this.ldapSSL = false;
		  }
		}
		catch (Exception exception)
		{
		  if (resultSet != null)
		  {
			resultSet.close();
		  }
		  if (connection != null)
		  {
			connection.close();
		  }
		  throw exception;
		}
		finally
		{
		  if (resultSet != null)
		  {
			resultSet.close();
		  }
		  if (connection != null)
		  {
			connection.close();
		  }
		}
	  }

	  private string decodeLdapPsw(string paramString)
	  {
		try
		{
		  sbyte[] arrayOfByte1 = toByteArray(paramString);
		  sbyte[] arrayOfByte2 = new sbyte[] {1, -29, -94, 24, 87, -67, -104, -84};
		  string str = "DES";
		  SecretKeySpec secretKeySpec = new SecretKeySpec(arrayOfByte2, str);
		  Cipher cipher = Cipher.getInstance(str);
		  cipher.init(2, secretKeySpec);
		  return new string(cipher.doFinal(arrayOfByte1));
		}
		catch (Exception)
		{
		  return null;
		}
	  }

	  private sbyte[] toByteArray(string paramString)
	  {
		List<object> vector = new List<object>();
		sbyte b1 = 0;
		sbyte b2 = 0;
		while (b1 < paramString.Length)
		{
		  b2 = paramString.Substring(b1, true).Equals("-") ? 3 : 2;
		  string str = paramString.Substring(b1, b2);
		  b1 += b2;
		  int i = Convert.ToInt32(str, 16);
		  vector.Add(new sbyte?((sbyte)i));
		}
		if (vector.Count > 0)
		{
		  sbyte[] arrayOfByte = new sbyte[vector.Count];
		  for (sbyte b = 0; b < vector.Count; b++)
		  {
			sbyte? byte = (sbyte?)vector[b];
			arrayOfByte[b] = byte.Value;
		  }
		  return arrayOfByte;
		}
		return null;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected String getUsersPassword() throws javax.security.auth.login.LoginException
	  protected internal virtual string UsersPassword
	  {
		  get
		  {
			bool @bool = this.log.TraceEnabled;
			string str1 = Username;
			string str2 = null;
			string str3 = null;
			connection = null;
			preparedStatement = null;
			resultSet = null;
			transaction = null;
			if (this.suspendResume)
			{
			  transaction = TransactionDemarcationSupport.suspendAnyTransaction();
			  if (@bool)
			  {
				this.log.trace("suspendAnyTransaction");
			  }
			}
			try
			{
			  initialContext = new InitialContext();
			  DataSource dataSource = (DataSource)initialContext.lookup(this.dsJndiName);
			  connection = dataSource.Connection;
			  if (@bool)
			  {
				this.log.trace("Excuting query: " + this.principalsQuery + ", with username: " + str1);
			  }
			  preparedStatement = connection.prepareStatement(this.principalsQuery);
			  preparedStatement.setString(1, str1);
			  resultSet = preparedStatement.executeQuery();
			  if (!resultSet.next())
			  {
				if (@bool)
				{
				  this.log.trace("Query returned no matches from db");
				}
				throw new FailedLoginException("No matching username found in Principals");
			  }
			  str2 = resultSet.getString(1);
			  str3 = resultSet.getString(2);
			  if (str3.Equals("AD"))
			  {
				return "";
			  }
			  str2 = convertRawPassword(str2);
			  if (@bool)
			  {
				this.log.trace("Obtained user password");
			  }
			}
			catch (NamingException namingException)
			{
			  LoginException loginException = new LoginException("Error looking up DataSource from: " + this.dsJndiName);
			  loginException.initCause(namingException);
			  throw loginException;
			}
			catch (SQLException sQLException)
			{
			  LoginException loginException = new LoginException("Query failed");
			  loginException.initCause(sQLException);
			  throw loginException;
			}
			finally
			{
			  if (resultSet != null)
			  {
				try
				{
				  resultSet.close();
				}
				catch (SQLException)
				{
				}
			  }
			  if (preparedStatement != null)
			  {
				try
				{
				  preparedStatement.close();
				}
				catch (SQLException)
				{
				}
			  }
			  if (connection != null)
			  {
				try
				{
				  connection.close();
				}
				catch (SQLException)
				{
				}
			  }
			  if (this.suspendResume)
			  {
				TransactionDemarcationSupport.resumeAnyTransaction(transaction);
				if (this.log.TraceEnabled)
				{
				  this.log.trace("resumeAnyTransaction");
				}
			  }
			}
			return str2;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected java.security.acl.Group[] getRoleSets() throws javax.security.auth.login.LoginException
	  protected internal virtual Group[] RoleSets
	  {
		  get
		  {
			string str = Username;
			if (this.log.TraceEnabled)
			{
			  this.log.trace("getRoleSets using rolesQuery: " + this.rolesQuery + ", username: " + str);
			}
			return Util.getRoleSets(str, this.dsJndiName, this.rolesQuery, this, this.suspendResume);
		  }
	  }

	  protected internal virtual string convertRawPassword(string paramString)
	  {
		  return paramString;
	  }

	  protected internal virtual bool validatePassword(string paramString1, string paramString2)
	  {
		if ((string.ReferenceEquals(paramString1, null) || paramString1.Length == 0) && this.log.TraceEnabled)
		{
		  this.log.trace("Rejecting empty password");
		  return false;
		}
		string str1 = Username;
		string str2 = getAuthType(str1);
		if (string.ReferenceEquals(str2, null) || !str2.Equals("AD"))
		{
		  bool bool1 = base.validatePassword(paramString1, paramString2);
		  if (!bool1)
		  {
			this.authLogger.info("Bad password for username=" + str1 + ", " + CurrentClientIpAddress);
		  }
		  return bool1;
		}
		bool @bool = false;
		if (!string.ReferenceEquals(paramString1, null))
		{
		  try
		  {
			@bool = createLdapInitContext(str1, paramString1);
			@bool = true;
		  }
		  catch (Exception throwable)
		  {
			ValidateError = throwable;
		  }
		}
		try
		{
		  string[] arrayOfString = UsernameAndPassword;
		  str1 = arrayOfString[0];
		  if (!@bool)
		  {
			this.authLogger.info("Bad password for username=" + str1 + ", " + CurrentClientIpAddress);
		  }
		  else
		  {
			this.authLogger.info("User '" + str1 + "' authenticated, " + CurrentClientIpAddress);
		  }
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		return @bool;
	  }

	  private string getAuthType(string paramString)
	  {
		PreparedStatement preparedStatement = null;
		ResultSet resultSet = null;
		Connection connection = null;
		string str = null;
		try
		{
		  InitialContext initialContext = new InitialContext();
		  DataSource dataSource = (DataSource)initialContext.lookup(this.dsJndiName);
		  connection = dataSource.Connection;
		  preparedStatement = connection.prepareStatement("SELECT AUTHTYPE FROM PRINCIPALS WHERE ENBL = 1 AND PRINCIPALID = ? COLLATE SQL_Latin1_General_CP1_CS_AS");
		  preparedStatement.setString(1, paramString);
		  resultSet = preparedStatement.executeQuery();
		  if (resultSet.next())
		  {
			str = resultSet.getString(1);
		  }
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		if (resultSet != null)
		{
		  try
		  {
			resultSet.close();
		  }
		  catch (SQLException)
		  {
		  }
		}
		if (preparedStatement != null)
		{
		  try
		  {
			preparedStatement.close();
		  }
		  catch (SQLException)
		  {
		  }
		}
		if (connection != null)
		{
		  try
		  {
			connection.close();
		  }
		  catch (SQLException)
		  {
		  }
		}
		return str;
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
			if (i == -1 || j == -1)
			{
			  i = str.IndexOf('-') + 1;
			  j = str.LastIndexOf('-') - 1;
			}
			try
			{
			  return str.Substring(i, j - i);
			}
			catch (Exception)
			{
			  return str;
			}
		  }
	  }

	  private bool createLdapInitContext(string paramString1, string paramString2)
	  {
		string str = (string)this.options.get("searchTimeLimit");
		initialLdapContext = null;
		try
		{
		  initialLdapContext = constructInitialLdapContext(this.ldapBindDN, this.ldapPassword);
		  string str1 = "(sAMAccountName={0})";
		  string str2 = bindDNAuthentication(initialLdapContext, paramString1, paramString2, this.ldapBaseDN, str1);
		  Console.WriteLine("=============================================== USer DN : " + str2);
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
//ORIGINAL LINE: private javax.naming.ldap.InitialLdapContext constructInitialLdapContext(String paramString1, String paramString2) throws javax.naming.NamingException
	  private InitialLdapContext constructInitialLdapContext(string paramString1, string paramString2)
	  {
		Hashtable hashtable = new Hashtable(11);
		string str = "ldap://" + this.ldapHostname + ":" + this.ldapPort;
		hashtable["java.naming.factory.initial"] = "com.sun.jndi.ldap.LdapCtxFactory";
		hashtable["java.naming.provider.url"] = str;
		hashtable["java.naming.security.principal"] = paramString1;
		hashtable["java.naming.security.credentials"] = paramString2;
		if (this.ldapSSL)
		{
		  hashtable["java.naming.security.protocol"] = "ssl";
		}
		else
		{
		  hashtable["java.naming.security.protocol"] = "simple";
		}
		return new InitialLdapContext(hashtable, null);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected String bindDNAuthentication(javax.naming.ldap.InitialLdapContext paramInitialLdapContext, String paramString1, String paramString2, String paramString3, String paramString4) throws javax.naming.NamingException
	  protected internal virtual string bindDNAuthentication(InitialLdapContext paramInitialLdapContext, string paramString1, string paramString2, string paramString3, string paramString4)
	  {
		SearchControls searchControls = new SearchControls();
		searchControls.SearchScope = 2;
		searchControls.ReturningAttributes = new string[0];
		searchControls.TimeLimit = 5000;
		NamingEnumeration namingEnumeration = null;
		object[] arrayOfObject = new object[] {paramString1};
		namingEnumeration = paramInitialLdapContext.search(paramString3, paramString4, arrayOfObject, searchControls);
		if (!namingEnumeration.hasMore())
		{
		  namingEnumeration.close();
		  throw new NamingException("Search of baseDN(" + paramString3 + ") found no matches");
		}
		SearchResult searchResult = (SearchResult)namingEnumeration.next();
		string str1 = searchResult.Name;
		string str2 = null;
		if (searchResult.Relative == true)
		{
		  str2 = str1 + "," + paramString3;
		}
		else
		{
		  throw new NamingException("Can't follow referal for authentication: " + str1);
		}
		namingEnumeration.close();
		namingEnumeration = null;
		InitialLdapContext initialLdapContext = constructInitialLdapContext(str2, paramString2);
		initialLdapContext.close();
		return str2;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected String createPasswordHash(String paramString1, String paramString2, String paramString3) throws javax.security.auth.login.LoginException
	  protected internal virtual string createPasswordHash(string paramString1, string paramString2, string paramString3)
	  {
		  return UsersPassword.Equals("") ? paramString2 : base.createPasswordHash(paramString1, paramString2, paramString3);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\org\jboss\security\auth\spi\CostOSLoginModule.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}