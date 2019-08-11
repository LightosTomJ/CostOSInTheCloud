using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Desktop.common.nomitech.common.migration.datamove
{
	using BaseEntityMetadataKeeper = Desktop.common.nomitech.common.migration.datamove.metadataKeeper.BaseEntityMetadataKeeper;
	using BaseSchemaHelper = Desktop.common.nomitech.common.migration.datamove.schemaHelper.BaseSchemaHelper;
	using UIProgress = nomitech.common.ui.UIProgress;
	using LogManager = org.apache.log4j.LogManager;
	using Logger = org.apache.log4j.Logger;

	public class BaseDBDataMover<T> : object where T : Desktop.common.nomitech.common.migration.datamove.metadataKeeper.BaseEntityMetadataKeeper
	{
	  internal static readonly Logger logger = LogManager.getLogger(typeof(BaseDBDataMover));

	  internal UIProgress progress;

	  internal int sourceDbms;

	  internal int destDbms;

	  internal Connection sourceConnection;

	  internal Connection destConnection;

	  internal BaseSchemaHelper<T> helper;

	  internal BaseDBDataMover()
	  {
	  }

	  internal BaseDBDataMover(int paramInt1, int paramInt2)
	  {
		this.sourceDbms = paramInt1;
		this.destDbms = paramInt2;
	  }

	  internal virtual void createMappingTable()
	  {
		dropMappingTable();
		try
		{
		  if (this.destDbms == ProjectDBUtil.SQLSERVER_DBMS)
		  {
			executeUpdateQuery(this.destConnection, "CREATE TABLE #FKMAPTABLE (SOURCE_ENTITY VARCHAR(256), FKEYNAME VARCHAR(256), TABLEID BIGINT, VAL BIGINT)");
		  }
		  else
		  {
			executeUpdateQuery(this.destConnection, "CREATE TABLE FKMAPTABLE (SOURCE_ENTITY VARCHAR(256), FKEYNAME VARCHAR(256), TABLEID BIGINT, VAL BIGINT)");
			executeUpdateQuery(this.destConnection, "CREATE UNIQUE INDEX IDX_FKMAP ON FKMAPTABLE (SOURCE_ENTITY, FKEYNAME, TABLEID)");
		  }
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
	  }

	  internal virtual void dropMappingTable()
	  {
		try
		{
		  if (this.destDbms == ProjectDBUtil.SQLSERVER_DBMS)
		  {
			executeUpdateQuery(this.destConnection, "DROP TABLE #FKMAPTABLE");
		  }
		  else
		  {
			executeUpdateQuery(this.destConnection, "DROP TABLE FKMAPTABLE");
		  }
		}
		catch (Exception)
		{
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: int executeUpdateQuery(java.sql.Connection paramConnection, String paramString) throws Exception
	  internal virtual int executeUpdateQuery(Connection paramConnection, string paramString)
	  {
		Statement statement = null;
		try
		{
		  if (logger.DebugEnabled)
		  {
			logger.debug("UPDATE: " + paramString);
		  }
		  statement = paramConnection.createStatement();
		  int i = statement.executeUpdate(paramString);
		  paramConnection.commit();
		  statement.close();
		  return i;
		}
		catch (SQLException sQLException)
		{
		  if (statement != null)
		  {
			statement.close();
		  }
		  throw new Exception(sQLException);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.sql.ResultSet executeSelectQuery(java.sql.Connection paramConnection, String paramString) throws Exception
	  internal virtual ResultSet executeSelectQuery(Connection paramConnection, string paramString)
	  {
		PreparedStatement preparedStatement = null;
		try
		{
		  if (logger.DebugEnabled)
		  {
			logger.debug("SELECT: " + paramString);
		  }
		  preparedStatement = paramConnection.prepareStatement(paramString);
		  return preparedStatement.executeQuery();
		}
		catch (SQLException sQLException)
		{
		  if (preparedStatement != null)
		  {
			preparedStatement.close();
		  }
		  throw new Exception(sQLException);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: long executeCountQuery(java.sql.Connection paramConnection, String paramString) throws Exception
	  internal virtual long executeCountQuery(Connection paramConnection, string paramString)
	  {
		PreparedStatement preparedStatement = null;
		try
		{
		  if (logger.DebugEnabled)
		  {
			logger.debug("COUNT: " + paramString);
		  }
		  preparedStatement = paramConnection.prepareStatement(paramString);
		  ResultSet resultSet = preparedStatement.executeQuery();
		  resultSet.next();
		  long l = resultSet.getLong(1);
		  if (logger.DebugEnabled)
		  {
			logger.debug("\tCount returned " + l + " rows");
		  }
		  return l;
		}
		catch (SQLException sQLException)
		{
		  if (preparedStatement != null)
		  {
			preparedStatement.close();
		  }
		  throw new Exception(sQLException);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: System.Nullable<long> executeInsertStatement(java.sql.Connection paramConnection, String paramString) throws Exception
	  internal virtual long? executeInsertStatement(Connection paramConnection, string paramString)
	  {
		long? long = null;
		Statement statement = null;
		try
		{
		  StringBuilder stringBuilder = null;
		  if (logger.DebugEnabled)
		  {
			stringBuilder = (new StringBuilder("SINGLE INSERT: ")).Append(paramString);
		  }
		  statement = paramConnection.createStatement();
		  if (logger.TraceEnabled)
		  {
			stringBuilder.Append("\n\tRow values:");
		  }
		  int i = statement.executeUpdate(paramString);
		  long = getLastInsertedId(paramConnection);
		  paramConnection.commit();
		  statement.close();
		}
		catch (SQLException sQLException)
		{
		  if (statement != null)
		  {
			statement.close();
		  }
		  throw new Exception(sQLException);
		}
		return long;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: System.Nullable<long> getLastInsertedId(java.sql.Connection paramConnection) throws java.sql.SQLException, Exception
	  internal virtual long? getLastInsertedId(Connection paramConnection)
	  {
		long? long;
		using (Statement null = paramConnection.createStatement())
		{
		  if (this.destDbms == ProjectDBUtil.HSQL_DBMS)
		  {
			using (ResultSet null = statement.executeQuery("CALL IDENTITY()"))
			{
			  resultSet.next();
			  long = Convert.ToInt64(resultSet.getLong(1));
			}
		  }
		  else if (this.destDbms == ProjectDBUtil.SQLSERVER_DBMS)
		  {
			using (ResultSet null = statement.executeQuery("SELECT @@IDENTITY"))
			{
			  resultSet.next();
			  long = Convert.ToInt64(resultSet.getLong(1));
			}
		  }
		  else
		  {
			throw new Exception("No suitable DBMS type");
		  }
		}
		logger.debug("INSERTED ID: " + long);
		return long;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: System.Nullable<long> executeInsertStatement(java.sql.Connection paramConnection, String paramString, Object[] paramArrayOfObject) throws Exception
	  internal virtual long? executeInsertStatement(Connection paramConnection, string paramString, object[] paramArrayOfObject)
	  {
		long? long = null;
		PreparedStatement preparedStatement = null;
		try
		{
		  StringBuilder stringBuilder = null;
		  if (logger.DebugEnabled)
		  {
			logger.debug("SINGLE INSERT:" + paramString);
		  }
		  preparedStatement = paramConnection.prepareStatement(paramString);
		  if (logger.TraceEnabled)
		  {
			stringBuilder = new StringBuilder("\n\tRow values:");
		  }
		  int i;
		  for (i = 0; i < paramArrayOfObject.Length; i++)
		  {
			if (logger.TraceEnabled)
			{
			  stringBuilder.Append("\n\t\t[").Append(i).Append("] => ");
			  if (paramArrayOfObject[i] == null)
			  {
				stringBuilder.Append("(null)");
			  }
			  else
			  {
				stringBuilder.Append(paramArrayOfObject[i] + " (" + paramArrayOfObject[i].GetType() + ")");
			  }
			}
			preparedStatement.setObject(i + 1, paramArrayOfObject[i]);
		  }
		  if (logger.TraceEnabled)
		  {
			stringBuilder.Append("\n\tEnd of Row values:");
			logger.debug(stringBuilder);
		  }
		  i = preparedStatement.executeUpdate();
		  long = getLastInsertedId(paramConnection);
		  paramConnection.commit();
		  preparedStatement.close();
		}
		catch (SQLException sQLException)
		{
		  if (preparedStatement != null)
		  {
			preparedStatement.close();
		  }
		  throw new Exception(sQLException);
		}
		return long;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void executeInsertStatement(java.sql.Connection paramConnection, String paramString, java.util.List<Object[]> paramList) throws Exception
	  internal virtual void executeInsertStatement(Connection paramConnection, string paramString, IList<object[]> paramList)
	  {
		if (paramList.Count == 0)
		{
		  return;
		}
		PreparedStatement preparedStatement = null;
		try
		{
		  StringBuilder stringBuilder = null;
		  if (logger.DebugEnabled)
		  {
			stringBuilder = (new StringBuilder("INSERT: ")).Append(paramString).Append("\n\tInserting ").Append(paramList.Count).Append(" rows");
		  }
		  preparedStatement = paramConnection.prepareStatement(paramString);
		  foreach (object[] arrayOfObject in paramList)
		  {
			if (logger.TraceEnabled)
			{
			  stringBuilder.Append("\n\tRow values:");
			}
			for (sbyte b = 0; b < arrayOfObject.Length; b++)
			{
			  object @object = convertValues(paramConnection, arrayOfObject[b]);
			  if (logger.TraceEnabled)
			  {
				stringBuilder.Append("\n\t\t[").Append(b).Append("] => ");
				if (@object == null)
				{
				  stringBuilder.Append("(null)");
				}
				else
				{
				  stringBuilder.Append(@object + " (" + @object.GetType() + ")");
				}
			  }
			  preparedStatement.setObject(b + 1, @object);
			}
			if (logger.TraceEnabled)
			{
			  stringBuilder.Append("\n\tEnd of Row values:");
			}
			preparedStatement.addBatch();
		  }
		  if (logger.DebugEnabled)
		  {
			logger.debug(stringBuilder);
		  }
		  preparedStatement.executeBatch();
		  paramConnection.commit();
		  preparedStatement.close();
		}
		catch (SQLException sQLException)
		{
		  if (preparedStatement != null)
		  {
			preparedStatement.close();
		  }
		  throw new Exception(sQLException);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private Object convertValues(java.sql.Connection paramConnection, Object paramObject) throws java.sql.SQLException, java.io.IOException
	  private object convertValues(Connection paramConnection, object paramObject)
	  {
		if (paramObject == null)
		{
		  return null;
		}
		if (this.destDbms == ProjectDBUtil.HSQL_DBMS)
		{
		  if (paramObject is Clob)
		  {
			logger.trace("Converting from Clob to String");
			return clobToString((Clob)paramObject);
		  }
		}
		else if (this.destDbms == ProjectDBUtil.SQLSERVER_DBMS && paramObject is Blob)
		{
		  logger.trace("Converting from Blob");
		  Blob blob = (Blob)paramObject;
		  sbyte[] arrayOfByte = blob.getBytes(1L, (int)blob.length());
		  blob.free();
		  return arrayOfByte;
		}
		return paramObject;
	  }

	  private string clobToString(Clob paramClob)
	  {
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
				using (StreamReader null = new StreamReader(paramClob.CharacterStream))
				{
			  while (null != (str = bufferedReader.readLine()))
			  {
				stringBuilder.Append(str);
			  }
				}
		}
		catch (Exception iOException) when (iOException is IOException || iOException is SQLException)
		{
		  iOException.printStackTrace();
		}
		return stringBuilder.ToString();
	  }

	  internal static void setProgress(UIProgress paramUIProgress, string paramString)
	  {
		if (logger.DebugEnabled)
		{
		  logger.debug(paramString);
		}
		paramUIProgress.Progress = paramString;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\datamove\BaseDBDataMover.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}