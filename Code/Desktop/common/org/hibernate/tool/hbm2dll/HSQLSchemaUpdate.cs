using System;
using System.Collections.Generic;
using System.IO;

namespace Desktop.common.org.hibernate.tool.hbm2ddl
{
	using Configuration = org.hibernate.cfg.Configuration;
	using NamingStrategy = org.hibernate.cfg.NamingStrategy;
	using Settings = org.hibernate.cfg.Settings;
	using Dialect = org.hibernate.dialect.Dialect;
	using FormatStyle = org.hibernate.jdbc.util.FormatStyle;
	using Formatter = org.hibernate.jdbc.util.Formatter;
	using SQLStatementLogger = org.hibernate.jdbc.util.SQLStatementLogger;
	using PropertiesHelper = org.hibernate.util.PropertiesHelper;
	using ReflectHelper = org.hibernate.util.ReflectHelper;

	public class HSQLSchemaUpdate
	{
	  private ConnectionHelper connectionHelper;

	  private Configuration configuration;

	  private Dialect dialect;

	  private System.Collections.IList exceptions;

	  private bool haltOnError = false;

	  private bool format = true;

	  private string outputFile = null;

	  private string delimiter;

	  private Formatter formatter;

	  private SQLStatementLogger sqlStatementLogger;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public HSQLSchemaUpdate(org.hibernate.cfg.Configuration paramConfiguration) throws org.hibernate.HibernateException
	  public HSQLSchemaUpdate(Configuration paramConfiguration) : this(paramConfiguration, paramConfiguration.Properties)
	  {
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public HSQLSchemaUpdate(org.hibernate.cfg.Configuration paramConfiguration, java.util.Properties paramProperties) throws org.hibernate.HibernateException
	  public HSQLSchemaUpdate(Configuration paramConfiguration, Properties paramProperties)
	  {
		this.configuration = paramConfiguration;
		this.dialect = Dialect.getDialect(paramProperties);
		Properties properties = new Properties();
		properties.putAll(this.dialect.DefaultProperties);
		properties.putAll(paramProperties);
		this.connectionHelper = new ManagedProviderConnectionHelper(properties);
		this.exceptions = new List<object>();
		this.formatter = (PropertiesHelper.getBoolean("hibernate.format_sql", properties) ? FormatStyle.DDL : FormatStyle.NONE).Formatter;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public HSQLSchemaUpdate(org.hibernate.cfg.Configuration paramConfiguration, org.hibernate.cfg.Settings paramSettings) throws org.hibernate.HibernateException
	  public HSQLSchemaUpdate(Configuration paramConfiguration, Settings paramSettings)
	  {
		this.configuration = paramConfiguration;
		this.dialect = paramSettings.Dialect;
		this.connectionHelper = new SuppliedConnectionProviderConnectionHelper(paramSettings.ConnectionProvider);
		this.exceptions = new List<object>();
		this.sqlStatementLogger = paramSettings.SqlStatementLogger;
		this.formatter = (this.sqlStatementLogger.FormatSql ? FormatStyle.DDL : FormatStyle.NONE).Formatter;
	  }

	  public static void Main(string[] paramArrayOfString)
	  {
		try
		{
		  Configuration configuration1 = new Configuration();
		  bool bool1 = true;
		  bool bool2 = true;
		  string str = null;
		  for (sbyte b = 0; b < paramArrayOfString.Length; b++)
		  {
			if (paramArrayOfString[b].StartsWith("--", StringComparison.Ordinal))
			{
			  if (paramArrayOfString[b].Equals("--quiet"))
			  {
				bool1 = false;
			  }
			  else if (paramArrayOfString[b].StartsWith("--properties=", StringComparison.Ordinal))
			  {
				str = paramArrayOfString[b].Substring(13);
			  }
			  else if (paramArrayOfString[b].StartsWith("--config=", StringComparison.Ordinal))
			  {
				configuration1.configure(paramArrayOfString[b].Substring(9));
			  }
			  else if (paramArrayOfString[b].StartsWith("--text", StringComparison.Ordinal))
			  {
				bool2 = false;
			  }
			  else if (paramArrayOfString[b].StartsWith("--naming=", StringComparison.Ordinal))
			  {
				configuration1.NamingStrategy = (NamingStrategy)ReflectHelper.classForName(paramArrayOfString[b].Substring(9)).newInstance();
			  }
			}
			else
			{
			  configuration1.addFile(paramArrayOfString[b]);
			}
		  }
		  if (!string.ReferenceEquals(str, null))
		  {
			Properties properties = new Properties();
			properties.putAll(configuration1.Properties);
			properties.load(new FileStream(str, FileMode.Open, FileAccess.Read));
			configuration1.Properties = properties;
		  }
		  (new SchemaUpdate(configuration1)).execute(bool1, bool2);
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
	  }

	  public virtual void execute(bool paramBoolean1, bool paramBoolean2)
	  {
		Connection connection = null;
		statement = null;
		fileWriter = null;
		this.exceptions.Clear();
		try
		{
		  try
		  {
			this.connectionHelper.prepare(true);
			connection = this.connectionHelper.Connection;
			databaseMetadata = new DatabaseMetadata(connection, this.dialect);
			statement = connection.createStatement();
		  }
		  catch (SQLException sQLException)
		  {
			this.exceptions.Add(sQLException);
			throw sQLException;
		  }
		  if (!string.ReferenceEquals(this.outputFile, null))
		  {
			fileWriter = new StreamWriter(this.outputFile);
		  }
		  string[] arrayOfString = this.configuration.generateSchemaUpdateScript(this.dialect, databaseMetadata);
		  for (sbyte b = 0; b < arrayOfString.Length; b++)
		  {
			string str1 = fixBIMCityStuff(arrayOfString[b]);
			string str2 = this.formatter.format(str1);
			try
			{
			  if (!string.ReferenceEquals(this.delimiter, null))
			  {
				str2 = str2 + this.delimiter;
			  }
			  if (paramBoolean1)
			  {
				Console.WriteLine(str2);
			  }
			  if (!string.ReferenceEquals(this.outputFile, null))
			  {
				fileWriter.write(str2 + "\n");
			  }
			  if (paramBoolean2)
			  {
				statement.executeUpdate(str2);
			  }
			}
			catch (SQLException sQLException)
			{
			  if (this.haltOnError)
			  {
				throw new JDBCException("Error during DDL export", sQLException);
			  }
			  this.exceptions.Add(sQLException);
			}
		  }
		}
		catch (Exception exception)
		{
		  this.exceptions.Add(exception);
		}
		finally
		{
		  try
		  {
			if (statement != null)
			{
			  statement.close();
			}
			this.connectionHelper.release();
		  }
		  catch (Exception exception)
		  {
			this.exceptions.Add(exception);
		  }
		  try
		  {
			if (fileWriter != null)
			{
			  fileWriter.close();
			}
		  }
		  catch (Exception exception)
		  {
			this.exceptions.Add(exception);
		  }
		}
	  }

	  private string fixBIMCityStuff(string paramString)
	  {
		  return (string.ReferenceEquals(paramString, null)) ? null : paramString.replaceAll("NVARCHAR\\(MAX\\)", "LONGVARCHAR").replaceAll("\\[uniqueidentifier\\] ROWGUIDCOL UNIQUE", "VARCHAR(256)").replaceAll("VARBINARY\\(MAX\\) FILESTREAM", "BLOB");
	  }

	  public virtual System.Collections.IList Exceptions
	  {
		  get
		  {
			  return this.exceptions;
		  }
	  }

	  public virtual bool HaltOnError
	  {
		  set
		  {
			  this.haltOnError = value;
		  }
	  }

	  public virtual bool Format
	  {
		  set
		  {
			  this.formatter = (value ? FormatStyle.DDL : FormatStyle.NONE).Formatter;
		  }
	  }

	  public virtual string OutputFile
	  {
		  set
		  {
			  this.outputFile = value;
		  }
	  }

	  public virtual string Delimiter
	  {
		  set
		  {
			  this.delimiter = value;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\org\hibernate\tool\hbm2ddl\HSQLSchemaUpdate.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}