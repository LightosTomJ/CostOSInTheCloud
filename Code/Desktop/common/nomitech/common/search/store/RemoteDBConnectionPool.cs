using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Desktop.common.nomitech.common.search.store
{

	public class RemoteDBConnectionPool
	{
	  private static ThreadLocal session = null;

	  private static Hashtable activeConnectionsMap = new Hashtable();

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

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.sql.Connection getLocalDBConnection(String paramString, java.util.Properties paramProperties) throws java.sql.SQLException
	  public static Connection getLocalDBConnection(string paramString, Properties paramProperties)
	  {
		Connection connection = (Connection)Session.get();
		if (connection == null || connection.Closed)
		{
		  connection = DriverManager.getConnection(paramString, paramProperties);
		  Session.set(connection);
		  activeConnectionsMap["" + Thread.CurrentThread.Id] = connection;
		}
		return new NonCloseableConnection(connection);
	  }

	  public static void emptyPool()
	  {
		foreach (Connection connection in activeConnectionsMap.Values)
		{
		  if (!connection.Closed)
		  {
			connection.close();
		  }
		}
		activeConnectionsMap.Clear();
	  }

	  private class NonCloseableConnection : Connection
	  {
		internal Connection connection;

		internal bool isClosed = false;

		public NonCloseableConnection(Connection param1Connection)
		{
			this.connection = param1Connection;
		}

		public virtual void clearWarnings()
		{
			this.connection.clearWarnings();
		}

		public virtual void close()
		{
			this.isClosed = true;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public boolean isClosed() throws java.sql.SQLException
		public virtual bool Closed
		{
			get
			{
				return this.isClosed;
			}
		}

		public virtual void commit()
		{
			this.connection.commit();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.Array createArrayOf(String param1String, Object[] param1ArrayOfObject) throws java.sql.SQLException
		public virtual Array createArrayOf(string param1String, object[] param1ArrayOfObject)
		{
			return this.connection.createArrayOf(param1String, param1ArrayOfObject);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.Blob createBlob() throws java.sql.SQLException
		public virtual Blob createBlob()
		{
			return this.connection.createBlob();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.Clob createClob() throws java.sql.SQLException
		public virtual Clob createClob()
		{
			return this.connection.createClob();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.NClob createNClob() throws java.sql.SQLException
		public virtual NClob createNClob()
		{
			return this.connection.createNClob();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.SQLXML createSQLXML() throws java.sql.SQLException
		public virtual SQLXML createSQLXML()
		{
			return this.connection.createSQLXML();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.Statement createStatement() throws java.sql.SQLException
		public virtual Statement createStatement()
		{
			return this.connection.createStatement();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.Statement createStatement(int param1Int1, int param1Int2) throws java.sql.SQLException
		public virtual Statement createStatement(int param1Int1, int param1Int2)
		{
			return this.connection.createStatement(param1Int1, param1Int2);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.Statement createStatement(int param1Int1, int param1Int2, int param1Int3) throws java.sql.SQLException
		public virtual Statement createStatement(int param1Int1, int param1Int2, int param1Int3)
		{
			return this.connection.createStatement(param1Int1, param1Int2, param1Int3);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.Struct createStruct(String param1String, Object[] param1ArrayOfObject) throws java.sql.SQLException
		public virtual Struct createStruct(string param1String, object[] param1ArrayOfObject)
		{
			return this.connection.createStruct(param1String, param1ArrayOfObject);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public boolean getAutoCommit() throws java.sql.SQLException
		public virtual bool AutoCommit
		{
			get
			{
				return this.connection.AutoCommit;
			}
			set
			{
				this.connection.AutoCommit = value;
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public String getCatalog() throws java.sql.SQLException
		public virtual string Catalog
		{
			get
			{
				return this.connection.Catalog;
			}
			set
			{
				this.connection.Catalog = value;
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.Properties getClientInfo() throws java.sql.SQLException
		public virtual Properties ClientInfo
		{
			get
			{
				return this.connection.ClientInfo;
			}
			set
			{
				this.connection.ClientInfo = value;
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public String getClientInfo(String param1String) throws java.sql.SQLException
		public virtual string getClientInfo(string param1String)
		{
			return this.connection.getClientInfo(param1String);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public int getHoldability() throws java.sql.SQLException
		public virtual int Holdability
		{
			get
			{
				return this.connection.Holdability;
			}
			set
			{
				this.connection.Holdability = value;
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.DatabaseMetaData getMetaData() throws java.sql.SQLException
		public virtual DatabaseMetaData MetaData
		{
			get
			{
				return this.connection.MetaData;
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public int getTransactionIsolation() throws java.sql.SQLException
		public virtual int TransactionIsolation
		{
			get
			{
				return this.connection.TransactionIsolation;
			}
			set
			{
				this.connection.TransactionIsolation = value;
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.Map<String, Class> getTypeMap() throws java.sql.SQLException
		public virtual IDictionary<string, Type> TypeMap
		{
			get
			{
				return this.connection.TypeMap;
			}
			set
			{
				this.connection.TypeMap = value;
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.SQLWarning getWarnings() throws java.sql.SQLException
		public virtual SQLWarning Warnings
		{
			get
			{
				return this.connection.Warnings;
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public boolean isReadOnly() throws java.sql.SQLException
		public virtual bool ReadOnly
		{
			get
			{
				return this.connection.ReadOnly;
			}
			set
			{
				this.connection.ReadOnly = value;
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public boolean isValid(int param1Int) throws java.sql.SQLException
		public virtual bool isValid(int param1Int)
		{
			return this.connection.isValid(param1Int);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public String nativeSQL(String param1String) throws java.sql.SQLException
		public virtual string nativeSQL(string param1String)
		{
			return this.connection.nativeSQL(param1String);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.CallableStatement prepareCall(String param1String) throws java.sql.SQLException
		public virtual CallableStatement prepareCall(string param1String)
		{
			return this.connection.prepareCall(param1String);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.CallableStatement prepareCall(String param1String, int param1Int1, int param1Int2) throws java.sql.SQLException
		public virtual CallableStatement prepareCall(string param1String, int param1Int1, int param1Int2)
		{
			return this.connection.prepareCall(param1String, param1Int1, param1Int2);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.CallableStatement prepareCall(String param1String, int param1Int1, int param1Int2, int param1Int3) throws java.sql.SQLException
		public virtual CallableStatement prepareCall(string param1String, int param1Int1, int param1Int2, int param1Int3)
		{
			return this.connection.prepareCall(param1String, param1Int1, param1Int2, param1Int3);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.PreparedStatement prepareStatement(String param1String) throws java.sql.SQLException
		public virtual PreparedStatement prepareStatement(string param1String)
		{
			return this.connection.prepareStatement(param1String);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.PreparedStatement prepareStatement(String param1String, int param1Int) throws java.sql.SQLException
		public virtual PreparedStatement prepareStatement(string param1String, int param1Int)
		{
			return this.connection.prepareStatement(param1String, param1Int);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.PreparedStatement prepareStatement(String param1String, int[] param1ArrayOfInt) throws java.sql.SQLException
		public virtual PreparedStatement prepareStatement(string param1String, int[] param1ArrayOfInt)
		{
			return this.connection.prepareStatement(param1String, param1ArrayOfInt);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.PreparedStatement prepareStatement(String param1String, String[] param1ArrayOfString) throws java.sql.SQLException
		public virtual PreparedStatement prepareStatement(string param1String, string[] param1ArrayOfString)
		{
			return this.connection.prepareStatement(param1String, param1ArrayOfString);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.PreparedStatement prepareStatement(String param1String, int param1Int1, int param1Int2) throws java.sql.SQLException
		public virtual PreparedStatement prepareStatement(string param1String, int param1Int1, int param1Int2)
		{
			return this.connection.prepareStatement(param1String, param1Int1, param1Int2);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.PreparedStatement prepareStatement(String param1String, int param1Int1, int param1Int2, int param1Int3) throws java.sql.SQLException
		public virtual PreparedStatement prepareStatement(string param1String, int param1Int1, int param1Int2, int param1Int3)
		{
			return this.connection.prepareStatement(param1String, param1Int1, param1Int2, param1Int3);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void releaseSavepoint(java.sql.Savepoint param1Savepoint) throws java.sql.SQLException
		public virtual void releaseSavepoint(Savepoint param1Savepoint)
		{
			this.connection.releaseSavepoint(param1Savepoint);
		}

		public virtual void rollback()
		{
			this.connection.rollback();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void rollback(java.sql.Savepoint param1Savepoint) throws java.sql.SQLException
		public virtual void rollback(Savepoint param1Savepoint)
		{
			this.connection.rollback(param1Savepoint);
		}




//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void setClientInfo(String param1String1, String param1String2) throws java.sql.SQLClientInfoException
		public virtual void setClientInfo(string param1String1, string param1String2)
		{
			this.connection.setClientInfo(param1String1, param1String2);
		}



//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.Savepoint setSavepoint() throws java.sql.SQLException
		public virtual Savepoint setSavepoint()
		{
			return this.connection.setSavepoint();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.sql.Savepoint setSavepoint(String param1String) throws java.sql.SQLException
		public virtual Savepoint setSavepoint(string param1String)
		{
			return this.connection.setSavepoint(param1String);
		}



//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public boolean isWrapperFor(Class param1Class) throws java.sql.SQLException
		public virtual bool isWrapperFor(Type param1Class)
		{
			return this.connection.isWrapperFor(param1Class);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public <T> T unwrap(Class<T> param1Class) throws java.sql.SQLException
		public virtual T unwrap<T>(Type param1Class)
		{
				param1Class = typeof(T);
			return (T)this.connection.unwrap(param1Class);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void setSchema(String param1String) throws java.sql.SQLException
		public virtual string Schema
		{
			set
			{
			}
			get
			{
				return null;
			}
		}


//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void abort(java.util.concurrent.Executor param1Executor) throws java.sql.SQLException
		public virtual void abort(Executor param1Executor)
		{
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void setNetworkTimeout(java.util.concurrent.Executor param1Executor, int param1Int) throws java.sql.SQLException
		public virtual void setNetworkTimeout(Executor param1Executor, int param1Int)
		{
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public int getNetworkTimeout() throws java.sql.SQLException
		public virtual int NetworkTimeout
		{
			get
			{
				return 0;
			}
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\search\store\RemoteDBConnectionPool.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}