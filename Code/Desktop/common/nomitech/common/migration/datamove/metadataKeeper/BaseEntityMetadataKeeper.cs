using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Desktop.common.nomitech.common.migration.datamove.metadataKeeper
{
	using BaseSchemaHelper = nomitech.common.migration.datamove.schemaHelper.BaseSchemaHelper;
	using StringUtils = nomitech.common.util.StringUtils;
	using Column = org.hibernate.mapping.Column;
	using ForeignKey = org.hibernate.mapping.ForeignKey;
	using PersistentClass = org.hibernate.mapping.PersistentClass;
	using Table = org.hibernate.mapping.Table;

	public abstract class BaseEntityMetadataKeeper
	{
	  internal BaseSchemaHelper parentHelper;

	  internal PersistentClass persistentClass;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  internal bool hasForeignKeys_Conflict;

	  internal Table table;

	  internal readonly string REF_ID_COLUMN_NAME = "REF__ID";

	  internal int?[] foreignKeysIndexes = null;

	  internal int?[] dataIndexes = null;

	  internal ForeignKey[] foreignKeys = null;

	  internal IDictionary<string, int> foreignKeysIndexesMap;

	  internal IDictionary<string, int> dataIndexesMap;

	  internal string filterColumn;

	  internal IList<Column> columns;

	  internal IList<string> parentTableIgnoreUpdates = new List<object>();

	  public BaseEntityMetadataKeeper(BaseSchemaHelper paramBaseSchemaHelper, PersistentClass paramPersistentClass)
	  {
		this.parentHelper = paramBaseSchemaHelper;
		this.persistentClass = paramPersistentClass;
		buildInfo();
	  }

	  public virtual string FilterColumn
	  {
		  get
		  {
			  return this.filterColumn;
		  }
	  }

	  public virtual void addParenTableIgnoreUpdate(string paramString)
	  {
		  this.parentTableIgnoreUpdates.Add(paramString);
	  }

	  internal abstract string getFilterColumn(string paramString);

	  internal abstract long? FilterValue {get;}

	  internal virtual string getSelectWhereClose(string paramString)
	  {
		  return (FilterValue == null) ? (" WHERE " + this.filterColumn + " IS NULL ") : (" WHERE " + this.filterColumn + " = " + FilterValue + " ");
	  }

	  private void buildInfo()
	  {
		this.table = this.persistentClass.Table;
		this.filterColumn = getFilterColumn(this.table.Name);
		this.hasForeignKeys_Conflict = this.table.ForeignKeyIterator.hasNext();
		this.columns = Columns;
		ForeignKeyIndexes;
		DataKeyIndexes;
	  }

	  internal virtual IList<Column> Columns
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			this.table.ColumnIterator.forEachRemaining(paramObject => paramList.add((Column)paramObject));
			return arrayList;
		  }
	  }

	  public virtual string UpdateForeignKeysWithNullsStatement
	  {
		  get
		  {
			StringBuilder stringBuffer = new StringBuilder();
			System.Collections.IEnumerator iterator = this.table.ForeignKeyIterator;
			while (iterator.MoveNext())
			{
			  ForeignKey foreignKey = (ForeignKey)iterator.Current;
			  System.Collections.IEnumerator iterator1 = foreignKey.ColumnIterator;
			  while (iterator1.MoveNext())
			  {
				Column column = (Column)iterator1.Current;
				if (stringBuffer.Length != 0)
				{
				  stringBuffer.Append(", ");
				}
				stringBuffer.Append(column.Name + " = NULL");
			  }
			}
			return "UPDATE " + this.table.Name + " SET " + stringBuffer.ToString() + getSelectWhereClose(this.table.Name);
		  }
	  }

	  public virtual string DeleteStatement
	  {
		  get
		  {
			  return "DELETE " + this.table.Name + getSelectWhereClose(this.table.Name);
		  }
	  }

	  public virtual bool hasForeignKeys()
	  {
		  return this.hasForeignKeys_Conflict;
	  }

	  public virtual string getIdRefColumnIndexExistsStatement(int paramInt, bool paramBoolean)
	  {
		  return getIdRefColumnIndexExistsStatement(paramInt, null, paramBoolean);
	  }

	  public virtual string getIdRefColumnIndexExistsStatement(int paramInt, string paramString, bool paramBoolean)
	  {
		string str = null;
		if (paramInt == ProjectDBUtil.SQLSERVER_DBMS)
		{
		  str = "SELECT count(1) \r\nFROM \r\n     sys.indexes \r\nINNER JOIN \r\n     sys.index_columns ON  indexes.object_id = index_columns.object_id and indexes.index_id = index_columns.index_id \r\nINNER JOIN \r\n     sys.columns ON index_columns.object_id = columns.object_id and index_columns.column_id = columns.column_id \r\nINNER JOIN \r\n     sys.tables ON indexes.object_id = tables.object_id \r\nWHERE \r\n\ttables.name = '%s'\r\n\tand columns.name = '%s'\r\n\tand index_columns.key_ordinal = 1\r\n";
		  if (paramBoolean)
		  {
			str = str + "\tand indexes.is_unique = 1";
		  }
		}
		else if (paramInt == ProjectDBUtil.HSQL_DBMS)
		{
		  str = "select count(1) \r\nfrom INFORMATION_SCHEMA.SYSTEM_INDEXINFO\r\nWHERE UPPER(TABLE_NAME) = '%s' \r\n  AND UPPER(COLUMN_NAME) = '%s'\r\n  AND ORDINAL_POSITION = 1\r\n";
		  if (paramBoolean)
		  {
			str = str + "  AND NON_UNIQUE = false";
		  }
		}
		if (string.ReferenceEquals(str, null))
		{
		  throw new Exception("DBMS " + paramInt + " not supported");
		}
		return string.format(str, new object[] {this.table.Name.ToUpper(), "REF__ID"});
	  }

	  public virtual string getIdRefColumnIndexCreateStatement(int paramInt, bool paramBoolean)
	  {
		  return getIdRefColumnIndexCreateStatement(paramInt, null, paramBoolean);
	  }

	  public virtual string getIdRefColumnIndexCreateStatement(int paramInt, string paramString, bool paramBoolean)
	  {
		string str1 = getDestTableName(paramInt, paramString);
		string str2 = null;
		if (paramInt == ProjectDBUtil.SQLSERVER_DBMS || paramInt == ProjectDBUtil.HSQL_DBMS)
		{
		  str2 = "CREATE %3$sINDEX %1$s_%2$s_IDX ON %1$s (%2$s);";
		}
		if (string.ReferenceEquals(str2, null))
		{
		  throw new Exception("DBMS " + paramInt + " not supported");
		}
		return string.format(str2, new object[] {str1.ToUpper(), "REF__ID", paramBoolean ? "UNIQUE " : ""});
	  }

	  public virtual string getIdRefColumnExistsStatement(int paramInt)
	  {
		  return getIdRefColumnExistsStatement(paramInt, null);
	  }

	  public virtual string getIdRefColumnExistsStatement(int paramInt, string paramString)
	  {
		string str;
		return (str = getDestTableName(paramInt, paramString)).format("SELECT count(1) \r\nFROM INFORMATION_SCHEMA.COLUMNS\r\nWHERE UPPER(TABLE_NAME) = '%s' AND UPPER(COLUMN_NAME) = '%s'", new object[] {this.table.Name.ToUpper(), "REF__ID"});
	  }

	  public virtual string getAlterIdRefColumnStatement(int paramInt)
	  {
		  return getAlterIdRefColumnStatement(paramInt, null);
	  }

	  public virtual string getAlterIdRefColumnStatement(int paramInt, string paramString)
	  {
		string str = getDestTableName(paramInt, paramString);
		if (paramInt == ProjectDBUtil.SQLSERVER_DBMS)
		{
		  return "IF COL_LENGTH('" + str + "', '" + "REF__ID" + "') IS NULL BEGIN ALTER TABLE " + str + " ADD [" + "REF__ID" + "] BIGINT END";
		}
		if (paramInt == ProjectDBUtil.MYSQL_DBMS)
		{
		  return "ALTER TABLE " + str + " ADD COLUMN IF NOT EXISTS " + "REF__ID" + " BIGINT";
		}
		if (paramInt == ProjectDBUtil.HSQL_DBMS)
		{
			;
		}
		return "ALTER TABLE " + str + " ADD COLUMN " + "REF__ID" + " BIGINT";
	  }

	  public virtual string SelectEverythingStatement
	  {
		  get
		  {
	//JAVA TO C# CONVERTER TODO TASK: Most Java stream collectors are not converted by Java to C# Converter:
			string str1 = (string)getCommaSeperatedColumnsNoFilterColumn(false, true).collect(Collectors.joining(","));
			string str2 = PrimaryKeyColumn;
			if (!str1.Equals(""))
			{
			  str1 = str2 + "," + str1;
			}
			else
			{
			  str1 = str2;
			}
			return "SELECT " + str1 + " FROM " + this.table.Name + getSelectWhereClose(this.table.Name);
		  }
	  }

	  public virtual string CountStatement
	  {
		  get
		  {
			  return "SELECT COUNT(1) FROM " + this.table.Name + getSelectWhereClose(this.table.Name);
		  }
	  }

	  public virtual string getInsertDataStatement(int paramInt)
	  {
		  return getInsertDataStatement(paramInt, null);
	  }

	  public virtual string getInsertDataStatement(int paramInt, string paramString)
	  {
		string str = getDestTableName(paramInt, paramString);
		System.Collections.IList list = getCommaSeperatedColumnsNoFilterColumn(false, false);
		list.Insert(0, "REF__ID");
		if (!this.filterColumn.Equals(PrimaryKeyColumn))
		{
		  list.Add(this.filterColumn);
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java stream collectors are not converted by Java to C# Converter:
		return "INSERT INTO " + str + "(" + (string)list.collect(Collectors.joining(",")) + ") VALUES(" + StringUtils.questionMarks(list.Count) + ")";
	  }

	  public virtual string getInsertForeignKeysToMappingTableStatement(int? paramInteger)
	  {
		  return (paramInteger.Value == ProjectDBUtil.SQLSERVER_DBMS) ? ("INSERT INTO " + getMappingTable(paramInteger) + " (SOURCE_ENTITY, FKEYNAME, TABLEID, VAL) VALUES(?,?,?,?)") : ("INSERT INTO " + getMappingTable(paramInteger) + " (SOURCE_ENTITY, FKEYNAME, TABLEID, VAL) VALUES(?,?,?,?)");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public ExtractedData extractRow(System.Nullable<long> paramLong, java.sql.ResultSet paramResultSet) throws Exception
	  public virtual ExtractedData extractRow(long? paramLong, ResultSet paramResultSet)
	  {
		string str1 = PrimaryKeyColumn;
		string str2 = FilterColumn;
		bool @bool = str1.Equals(str2);
		int i = DataKeyIndexes.Length;
		if (!@bool)
		{
		  i++;
		}
		object[] arrayOfObject = new object[i];
		ExtractedData.ExtractedFKData[] arrayOfExtractedFKData = new ExtractedData.ExtractedFKData[ForeignKeyIndexes.Length];
		ForeignKey[] arrayOfForeignKey = ForeignKeys;
		sbyte b;
		for (b = 0; b < DataKeyIndexes.Length; b++)
		{
		  arrayOfObject[b] = paramResultSet.getObject(DataKeyIndexes[b].intValue());
		}
		if (!@bool)
		{
		  arrayOfObject[DataKeyIndexes.Length] = paramLong;
		}
		for (b = 0; b < arrayOfExtractedFKData.Length; b++)
		{
		  object[] arrayOfObject1 = new object[4];
		  arrayOfObject1[0] = this.table.Name;
		  arrayOfObject1[1] = arrayOfForeignKey[b].getColumn(0).Name;
		  arrayOfObject1[2] = arrayOfObject[0];
		  arrayOfObject1[3] = paramResultSet.getObject(ForeignKeyIndexes[b].intValue());
		  ExtractedData.ExtractedFKData extractedFKData = new ExtractedData.ExtractedFKData();
		  extractedFKData.DataValues = arrayOfObject1;
		  arrayOfExtractedFKData[b] = extractedFKData;
		}
		ExtractedData extractedData = new ExtractedData(this);
		extractedData.DataValues = arrayOfObject;
		extractedData.FkValues = arrayOfExtractedFKData;
		return extractedData;
	  }

	  public virtual string getUpdateBySelectForeignKeysMappingTableStatement(int? paramInteger, long? paramLong)
	  {
		  return getUpdateBySelectForeignKeysMappingTableStatement(paramInteger, null, paramLong);
	  }

	  public virtual string getUpdateBySelectForeignKeysMappingTableStatement(int? paramInteger, string paramString, long? paramLong)
	  {
		string str1 = getMappingTable(paramInteger);
		string str2 = getDestTableName(paramInteger.Value, paramString);
		System.Collections.IEnumerator iterator = this.table.ForeignKeyIterator;
		List<object> arrayList = new List<object>();
		while (iterator.MoveNext())
		{
		  ForeignKey foreignKey = (ForeignKey)iterator.Current;
		  Table table1 = foreignKey.ReferencedTable;
		  string str3 = table1.Name;
		  BaseEntityMetadataKeeper baseEntityMetadataKeeper = this.parentHelper.getEntity(str3);
		  if (baseEntityMetadataKeeper == null || this.parentTableIgnoreUpdates.Contains(str3))
		  {
			continue;
		  }
		  string str4 = table1.PrimaryKey.getColumn(0).Name;
		  string str5 = baseEntityMetadataKeeper.FilterColumn;
		  string str6 = (paramLong == null) ? (" AND a." + str5 + " IS NULL") : (" AND a." + str5 + "=" + paramLong);
		  if (str4.Equals(str5))
		  {
			str6 = "";
		  }
		  System.Collections.IEnumerator iterator1 = foreignKey.ColumnIterator;
		  while (iterator1.MoveNext())
		  {
			Column column = (Column)iterator1.Current;
			string str = column.Name + " = (SELECT a." + str4 + " FROM " + str1 + " AS o LEFT JOIN " + str3 + " AS a ON a." + "REF__ID" + " = o.VAL WHERE o.SOURCE_ENTITY = '" + this.table.Name + "' AND o.FKEYNAME = '" + column.Name + "' AND o.TABLEID=" + str2 + "." + "REF__ID" + " " + str6 + ")";
			arrayList.Add(str);
		  }
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java stream collectors are not converted by Java to C# Converter:
		return arrayList.Count == 0 ? null : ((paramLong != null) ? ("UPDATE " + str2 + " SET " + (string)arrayList.collect(Collectors.joining(", ")) + " WHERE " + this.filterColumn + " = " + paramLong) : ("UPDATE " + str2 + " SET " + (string)arrayList.collect(Collectors.joining(", ")) + " WHERE " + this.filterColumn + " IS NULL"));
	  }

	  internal virtual string getMappingTable(int? paramInteger)
	  {
		  return (paramInteger.Value == ProjectDBUtil.SQLSERVER_DBMS) ? "#FKMAPTABLE" : "FKMAPTABLE";
	  }

	  public virtual string getInsertIntoBySelectNoForeignKeysStatement(int? paramInteger, long? paramLong)
	  {
		  return getInsertIntoBySelectNoForeignKeysStatement(paramInteger, null, paramLong);
	  }

	  public virtual string getInsertIntoBySelectNoForeignKeysStatement(int? paramInteger, string paramString, long? paramLong)
	  {
		string str1 = getDestTableName(paramInteger.Value, paramString);
		string str2 = PrimaryKeyColumn;
//JAVA TO C# CONVERTER TODO TASK: Most Java stream collectors are not converted by Java to C# Converter:
		string str3 = (string)getCommaSeperatedColumnsNoFilterColumn(false, false).collect(Collectors.joining(","));
		if (!str3.Equals(""))
		{
		  str3 = str3 + ",";
		}
		return "INSERT INTO " + str1 + "(" + str3 + "REF__ID" + "," + this.filterColumn + ") SELECT " + str3 + str2 + "," + paramLong + " as NPID FROM " + this.table.Name + getSelectWhereClose(this.table.Name);
	  }

	  public virtual string getUpdateBySelectForeignKeysStatement(int? paramInteger, long? paramLong)
	  {
		  return getUpdateBySelectForeignKeysStatement(paramInteger, null, paramLong);
	  }

	  public virtual string getUpdateBySelectForeignKeysStatement(int? paramInteger, string paramString, long? paramLong)
	  {
		StringBuilder stringBuffer1 = new StringBuilder();
		StringBuilder stringBuffer2 = new StringBuilder();
		string str1 = getDestTableName(paramInteger.Value, paramString);
		sbyte b = 1;
		string str2 = (FilterValue == null) ? ("s." + this.filterColumn + " IS NULL AND") : ("s." + this.filterColumn + " = " + FilterValue + " AND");
		stringBuffer2.Append(" LEFT JOIN " + this.table.Name + " as s ON " + str2 + " o." + "REF__ID" + " = s." + PrimaryKeyColumn);
		System.Collections.IEnumerator iterator = this.table.ForeignKeyIterator;
		while (iterator.MoveNext())
		{
		  ForeignKey foreignKey = (ForeignKey)iterator.Current;
		  System.Collections.IEnumerator iterator1 = foreignKey.ColumnIterator;
		  Table table1 = foreignKey.ReferencedTable;
		  string str3 = table1.PrimaryKey.getColumn(0).Name;
		  string str4 = "_" + table1.Name.ToLower();
		  while (iterator1.MoveNext())
		  {
			string str5 = str4 + b++;
			Column column = (Column)iterator1.Current;
			if (stringBuffer1.Length != 0)
			{
			  stringBuffer1.Append(", ");
			}
			string str6 = getDestTableName(paramInteger.Value, paramString, table1.Name);
			stringBuffer1.Append("o." + column.Name + " = " + str5 + "." + str3);
			if (paramLong != null)
			{
			  stringBuffer2.Append(" LEFT JOIN " + str6 + " as " + str5 + " ON " + str5 + "." + this.filterColumn + " = " + paramLong + " AND s." + column.Name + " = " + str5 + "." + "REF__ID");
			  continue;
			}
			stringBuffer2.Append(" LEFT JOIN " + str6 + " as " + str5 + " ON " + str5 + "." + this.filterColumn + " IS NULL AND s." + column.Name + " = " + str5 + "." + "REF__ID");
		  }
		}
		return (paramLong != null && FilterValue != null) ? ("UPDATE o SET " + stringBuffer1.ToString() + " FROM " + str1 + " as o " + stringBuffer2 + " WHERE o." + this.filterColumn + " = " + paramLong + " AND s." + this.filterColumn + " = " + FilterValue + " ") : ((paramLong != null) ? ("UPDATE o SET " + stringBuffer1.ToString() + " FROM " + str1 + " as o " + stringBuffer2 + " WHERE o." + this.filterColumn + " = " + paramLong + " AND s." + this.filterColumn + " = IS NULL ") : ((FilterValue != null) ? ("UPDATE o SET " + stringBuffer1.ToString() + " FROM " + str1 + " as o " + stringBuffer2 + " WHERE o." + this.filterColumn + " IS NULL AND s." + this.filterColumn + " = " + FilterValue + " ") : ("UPDATE o SET " + stringBuffer1.ToString() + " FROM " + str1 + " as o " + stringBuffer2 + " WHERE o." + this.filterColumn + " IS NULL AND s." + this.filterColumn + " IS NULL ")));
	  }

	  internal virtual string getDestTableName(int paramInt, string paramString)
	  {
		  return getDestTableName(paramInt, paramString, this.table.Name);
	  }

	  internal virtual string getDestTableName(int paramInt, string paramString1, string paramString2)
	  {
		string str = paramString2;
		if (paramInt == ProjectDBUtil.SQLSERVER_DBMS && !string.ReferenceEquals(paramString1, null) && paramString1.Trim().Length > 0)
		{
		  str = paramString1 + ".dbo." + str;
		}
		return str;
	  }

	  internal virtual string PrimaryKeyColumn
	  {
		  get
		  {
			  return this.table.PrimaryKey.getColumn(0).Name;
		  }
	  }

	  public virtual ForeignKey findForeignKeyByColumnName(string paramString)
	  {
		HashSet<object> hashSet = new HashSet<object>();
		System.Collections.IEnumerator iterator = this.table.ForeignKeyIterator;
		while (iterator.MoveNext())
		{
		  ForeignKey foreignKey = (ForeignKey)iterator.Current;
		  System.Collections.IEnumerator iterator1 = foreignKey.ColumnIterator;
		  while (iterator1.MoveNext())
		  {
			Column column = (Column)iterator1.Current;
			if (column.Name.Equals(paramString))
			{
			  return foreignKey;
			}
		  }
		}
		return null;
	  }

	  internal virtual IList<string> getCommaSeperatedColumnsNoFilterColumn(bool paramBoolean1, bool paramBoolean2)
	  {
		List<object> arrayList = new List<object>();
		string str = PrimaryKeyColumn;
		ISet<object> set = ForeignKeyColumns;
		this.columns.ForEach(paramColumn =>
		{
		string str = paramColumn.Name;
		bool bool1 = str.Equals(this.filterColumn);
		bool bool2 = str.Equals(paramString);
		bool bool3 = paramSet.contains(str);
		if (bool1 && !bool2)
		{
			return;
		}
		if (!paramBoolean1 && bool2)
		{
			return;
		}
		if (!paramBoolean2 && bool3)
		{
			return;
		}
		paramList.add(str);
		});
		return arrayList;
	  }

	  internal virtual ISet<string> ForeignKeyColumns
	  {
		  get
		  {
			HashSet<object> hashSet = new HashSet<object>();
			System.Collections.IEnumerator iterator = this.table.ForeignKeyIterator;
			while (iterator.MoveNext())
			{
			  ForeignKey foreignKey = (ForeignKey)iterator.Current;
			  System.Collections.IEnumerator iterator1 = foreignKey.ColumnIterator;
			  while (iterator1.MoveNext())
			  {
				Column column = (Column)iterator1.Current;
				hashSet.Add(column.Name);
			  }
			}
			return hashSet;
		  }
	  }

	  internal virtual int?[] ForeignKeyIndexes
	  {
		  get
		  {
			if (this.foreignKeysIndexes != null)
			{
			  return this.foreignKeysIndexes;
			}
			List<object> arrayList = new List<object>();
			this.foreignKeysIndexesMap = new Hashtable();
			ISet<object> set = ForeignKeyColumns;
			sbyte b = 1;
			foreach (Column column in this.columns)
			{
			  string str = column.Name;
			  bool bool1 = str.Equals(this.filterColumn);
			  bool bool2 = set.Contains(str);
			  if (bool1)
			  {
				continue;
			  }
			  if (bool2)
			  {
				arrayList.Add(Convert.ToInt32(b));
				this.foreignKeysIndexesMap[column.Name] = Convert.ToInt32(b);
			  }
			  b++;
			}
			this.foreignKeysIndexes = (int?[])arrayList.ToArray(typeof(System.Nullable));
			return this.foreignKeysIndexes;
		  }
	  }

	  internal virtual int?[] DataKeyIndexes
	  {
		  get
		  {
			if (this.dataIndexes != null)
			{
			  return this.dataIndexes;
			}
			if (this.table.Name.Equals("BC_MODEL"))
			{
			  bool @bool = true;
			}
			string str = PrimaryKeyColumn;
			List<object> arrayList = new List<object>();
			this.dataIndexesMap = new Hashtable();
			ISet<object> set = ForeignKeyColumns;
			sbyte b = 1;
			foreach (Column column in this.columns)
			{
			  string str1 = column.Name;
			  bool bool1 = str1.Equals(this.filterColumn);
			  bool bool2 = str1.Equals(str);
			  bool bool3 = set.Contains(str1);
			  if (bool1 && !bool2)
			  {
				continue;
			  }
			  if (!bool3)
			  {
				arrayList.Add(Convert.ToInt32(b));
				this.dataIndexesMap[column.Name] = Convert.ToInt32(b);
			  }
			  b++;
			}
			this.dataIndexes = (int?[])arrayList.ToArray(typeof(System.Nullable));
			return this.dataIndexes;
		  }
	  }

	  internal virtual ForeignKey[] ForeignKeys
	  {
		  get
		  {
			if (this.foreignKeys != null)
			{
			  return this.foreignKeys;
			}
			List<object> arrayList = new List<object>();
			ISet<object> set = ForeignKeyColumns;
			this.columns.ForEach(paramColumn =>
			{
			string str = paramColumn.Name;
			bool bool1 = str.Equals(this.filterColumn);
			bool bool2 = paramSet.contains(str);
			if (bool1)
			{
				return;
			}
			if (bool2)
			{
				paramList.add(findForeignKeyByColumnName(paramColumn.Name));
			}
			});
			this.foreignKeys = (ForeignKey[])arrayList.ToArray(typeof(ForeignKey));
			return this.foreignKeys;
		  }
	  }

	  public virtual string TableName
	  {
		  get
		  {
			  return this.table.Name;
		  }
	  }

	  public virtual int? getColumnIndex(string paramString)
	  {
		  return this.dataIndexesMap.ContainsKey(paramString) ? (int?)this.dataIndexesMap[paramString] : (this.foreignKeysIndexesMap.ContainsKey(paramString) ? (int?)this.foreignKeysIndexesMap[paramString] : Convert.ToInt32(-1));
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\datamove\metadataKeeper\BaseEntityMetadataKeeper.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}