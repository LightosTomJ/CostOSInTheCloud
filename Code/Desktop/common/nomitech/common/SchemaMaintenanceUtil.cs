using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common
{
	using Logger = org.apache.log4j.Logger;
	using SQLQuery = org.hibernate.SQLQuery;
	using Session = org.hibernate.Session;

	public class SchemaMaintenanceUtil
	{
	  private static readonly Logger l = Logger.getLogger(typeof(SchemaMaintenanceUtil));

	  private const string SQL_SERVER_INDEX_FRAGMENTATION = "WITH k AS ( SELECT *      FROM sys.dm_db_index_physical_stats      (DB_ID( N'%s' ), OBJECT_ID( N'%s' ), NULL, NULL, NULL) ) SELECT QUOTENAME( s.name ) as indexName,        k.avg_fragmentation_in_percent as fragmentation FROM k LEFT JOIN sys.indexes AS s ON k.index_id=s.index_id    AND s.object_id=k.object_id;";

	  public const string SQL_SERVER_LIST_TABLES = "SELECT QUOTENAME( TABLE_SCHEMA )+'.'+QUOTENAME( TABLE_NAME ) AS tableName FROM INFORMATION_SCHEMA.tables WHERE TABLE_CATALOG='%s';";

	  public virtual void performIndexMaintance(Session paramSession, int paramInt, string paramString)
	  {
		System.Collections.IList list = getTables(paramSession, paramInt, paramString);
		foreach (string str in list)
		{
		  System.Collections.IDictionary map = getIndexOperations(paramSession, paramInt, paramString, str);
		  foreach (DictionaryEntry entry in map.SetOfKeyValuePairs())
		  {
			string str1 = (string)entry.Key;
			IndexOperation indexOperation = (IndexOperation)entry.Value;
			indexOperation.execute(paramSession, str, str1);
		  }
		}
	  }

	  private IList<string> getTables(Session paramSession, int paramInt, string paramString)
	  {
		List<object> arrayList = new List<object>();
		if (paramInt == ProjectServerDBUtil.SQLSERVER_DBMS)
		{
		  string str = string.Format("SELECT QUOTENAME( TABLE_SCHEMA )+'.'+QUOTENAME( TABLE_NAME ) AS tableName FROM INFORMATION_SCHEMA.tables WHERE TABLE_CATALOG='{0}';", new object[] {paramString});
		  SQLQuery sQLQuery = paramSession.createSQLQuery(str);
		  System.Collections.IList list = sQLQuery.list();
		  foreach (string str1 in list)
		  {
			arrayList.Add(str1);
		  }
		}
		return arrayList;
	  }

	  private IDictionary<string, IndexOperation> getIndexOperations(Session paramSession, int paramInt, string paramString1, string paramString2)
	  {
		Hashtable hashMap = new Hashtable();
		if (paramInt == ProjectServerDBUtil.SQLSERVER_DBMS)
		{
		  string str = string.Format("WITH k AS ( SELECT *      FROM sys.dm_db_index_physical_stats      (DB_ID( N'{0}' ), OBJECT_ID( N'{1}' ), NULL, NULL, NULL) ) SELECT QUOTENAME( s.name ) as indexName,        k.avg_fragmentation_in_percent as fragmentation FROM k LEFT JOIN sys.indexes AS s ON k.index_id=s.index_id    AND s.object_id=k.object_id;", new object[] {paramString1, paramString2});
		  SQLQuery sQLQuery = paramSession.createSQLQuery(str);
		  System.Collections.IList list = sQLQuery.list();
		  foreach (object[] arrayOfObject in list)
		  {
			string str1 = (string)arrayOfObject[0];
			Number number = (Number)arrayOfObject[1];
			if (number.intValue() > 30)
			{
			  l.info(string.Format("Index {0} on table {1} has a fragmentation value of {2:D}. It will Rebuilded", new object[] {str1, paramString2, Convert.ToInt32(number.intValue())}));
			  hashMap[str1] = new SqlServerRebuildIndexOperation();
			  continue;
			}
			if (number.intValue() > 5)
			{
			  l.info(string.Format("Index {0} on table {1} has a fragmentation value of {2:D}. It will Reorganized", new object[] {str1, paramString2, Convert.ToInt32(number.intValue())}));
			  hashMap[str1] = new SqlServerReorganizeIndexOperation();
			}
		  }
		}
		return hashMap;
	  }

	  public class SqlServerReorganizeIndexOperation : IndexOperation
	  {
		public virtual void execute(Session param1Session, string param1String1, string param1String2)
		{
		  l.info("Reorganizing index " + param1String2 + " on table " + param1String1);
		  try
		  {
			SQLQuery sQLQuery = param1Session.createSQLQuery("ALTER INDEX " + param1String2 + " ON " + param1String1 + " REORGANIZE ");
			sQLQuery.executeUpdate();
		  }
		  catch (Exception exception)
		  {
			l.error("Could not reorganize index", exception);
		  }
		}
	  }

	  public class SqlServerRebuildIndexOperation : IndexOperation
	  {
		public virtual void execute(Session param1Session, string param1String1, string param1String2)
		{
		  l.info("Rebuilding index " + param1String2 + " on table " + param1String1);
		  try
		  {
			SQLQuery sQLQuery = param1Session.createSQLQuery("ALTER INDEX " + param1String2 + " ON " + param1String1 + " REBUILD");
			sQLQuery.executeUpdate();
		  }
		  catch (Exception exception)
		  {
			l.error("Could not rebuild index", exception);
		  }
		}
	  }

	  public interface IndexOperation
	  {
		void execute(Session param1Session, string param1String1, string param1String2);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\SchemaMaintenanceUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}