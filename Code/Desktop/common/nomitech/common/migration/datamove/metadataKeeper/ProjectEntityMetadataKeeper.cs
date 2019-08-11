using System.Collections.Generic;
using System.Text;

namespace Desktop.common.nomitech.common.migration.datamove.metadataKeeper
{
	using ProjectUrlTable = nomitech.common.db.local.ProjectUrlTable;
	using ProjectDBSchemaHelper = nomitech.common.migration.datamove.schemaHelper.ProjectDBSchemaHelper;
	using StringUtils = nomitech.common.util.StringUtils;
	using Column = org.hibernate.mapping.Column;
	using PersistentClass = org.hibernate.mapping.PersistentClass;

	public class ProjectEntityMetadataKeeper : BaseEntityMetadataKeeper
	{
	  internal ProjectUrlTable projectUrlTable;

	  public ProjectEntityMetadataKeeper(ProjectDBSchemaHelper paramProjectDBSchemaHelper, ProjectUrlTable paramProjectUrlTable, PersistentClass paramPersistentClass) : base(paramProjectDBSchemaHelper, paramPersistentClass)
	  {
		this.projectUrlTable = paramProjectUrlTable;
	  }

	  internal override string getFilterColumn(string paramString)
	  {
		  return "PRJID";
	  }

	  internal override long? FilterValue
	  {
		  get
		  {
			  return this.projectUrlTable.ProjectUrlId;
		  }
	  }

	  public virtual string getAlterIdRefColumnStatement(ProjectUrlTable paramProjectUrlTable)
	  {
		  return getAlterIdRefColumnStatement(paramProjectUrlTable.Dbms.Value, paramProjectUrlTable.DatabaseName);
	  }

	  public virtual string SelectEverythingStatementAppendProjects
	  {
		  get
		  {
			string str1 = getCommaSeperatedColumnsNoProjectIdAppendProjects(false, true);
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

	  public virtual string getInsertDataStatement(ProjectUrlTable paramProjectUrlTable)
	  {
		  return getInsertDataStatement(paramProjectUrlTable.Dbms.Value, paramProjectUrlTable.DatabaseName);
	  }

	  public virtual string getInsertDataStatementAppendProjects(ProjectUrlTable paramProjectUrlTable)
	  {
		  return getInsertDataStatementAppendProjects(paramProjectUrlTable.Dbms.Value, paramProjectUrlTable.DatabaseName);
	  }

	  public virtual string getInsertDataStatementAppendProjects(int paramInt)
	  {
		  return getInsertDataStatementAppendProjects(paramInt, null);
	  }

	  public virtual string getInsertDataStatementAppendProjects(int paramInt, string paramString)
	  {
		string str1 = getDestTableName(paramInt, paramString);
		string str2 = PrimaryKeyColumn;
		string str3 = getCommaSeperatedColumnsNoProjectIdAppendProjects(false, false);
		if (!str3.Equals(""))
		{
		  str3 = "REF__ID," + str3;
		}
		else
		{
		  str3 = "REF__ID";
		}
		return "INSERT INTO " + str1 + "(" + str3 + "," + this.filterColumn + ") VALUES(" + StringUtils.questionMarks(DataKeyIndexes.Length + 1) + ")";
	  }

	  public virtual string getInsertIntoBySelectNoForeignKeysStatementAppendProjects(int? paramInteger, long? paramLong)
	  {
		  return getInsertIntoBySelectNoForeignKeysStatementAppendProjects(paramInteger, null, paramLong);
	  }

	  public virtual string getInsertIntoBySelectNoForeignKeysStatementAppendProjects(int? paramInteger, string paramString, long? paramLong)
	  {
		string str1 = getDestTableName(paramInteger.Value, paramString);
		string str2 = PrimaryKeyColumn;
		string str3 = getCommaSeperatedColumnsNoProjectIdAppendProjects(false, false);
		if (!str3.Equals(""))
		{
		  str3 = str3 + ",";
		}
		return "INSERT INTO " + str1 + "(" + str3 + "REF__ID" + "," + this.filterColumn + ") SELECT " + str3 + str2 + "," + paramLong + " as NPID FROM " + this.table.Name + getSelectWhereClose(this.table.Name);
	  }

	  public virtual string getInsertForeignKeysToMappingTableStatement(ProjectUrlTable paramProjectUrlTable)
	  {
		  return getInsertForeignKeysToMappingTableStatement(paramProjectUrlTable.Dbms);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public ExtractedData extractRow(nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable, java.sql.ResultSet paramResultSet) throws Exception
	  public virtual ExtractedData extractRow(ProjectUrlTable paramProjectUrlTable, ResultSet paramResultSet)
	  {
		  return extractRow(paramProjectUrlTable.ProjectUrlId, paramResultSet);
	  }

	  public virtual string getUpdateBySelectForeignKeysMappingTableStatement(ProjectUrlTable paramProjectUrlTable)
	  {
		  return getUpdateBySelectForeignKeysMappingTableStatement(paramProjectUrlTable.Dbms, paramProjectUrlTable.DatabaseName, paramProjectUrlTable.ProjectUrlId);
	  }

	  public virtual string getInsertIntoBySelectNoForeignKeysStatement(ProjectUrlTable paramProjectUrlTable)
	  {
		  return getInsertIntoBySelectNoForeignKeysStatement(paramProjectUrlTable.Dbms, paramProjectUrlTable.DatabaseName, paramProjectUrlTable.ProjectUrlId);
	  }

	  public virtual string getInsertIntoBySelectNoForeignKeysStatementAppendProjects(ProjectUrlTable paramProjectUrlTable)
	  {
		  return getInsertIntoBySelectNoForeignKeysStatementAppendProjects(paramProjectUrlTable.Dbms, paramProjectUrlTable.DatabaseName, paramProjectUrlTable.ProjectUrlId);
	  }

	  public virtual string getUpdateBySelectForeignKeysStatement(ProjectUrlTable paramProjectUrlTable)
	  {
		  return getUpdateBySelectForeignKeysStatement(paramProjectUrlTable.Dbms, paramProjectUrlTable.DatabaseName, paramProjectUrlTable.ProjectUrlId);
	  }

	  internal virtual string getCommaSeperatedColumnsNoProjectIdAppendProjects(bool paramBoolean1, bool paramBoolean2)
	  {
		StringBuilder stringBuffer = new StringBuilder();
		string str = PrimaryKeyColumn;
		ISet<object> set = ForeignKeyColumns;
		this.columns.ForEach(paramColumn =>
		{
		if (paramColumn.Name.Equals(this.filterColumn))
		{
			return;
		}
		if (this.table.Name.Equals("BOQITEM") && (paramColumn.Name.Equals("WBSCODE") || paramColumn.Name.Equals("WBS2CODE")))
		{
			return;
		}
		if (!paramBoolean1 && paramColumn.Name.Equals(paramString))
		{
			return;
		}
		if (!paramBoolean2 && paramSet.contains(paramColumn.Name))
		{
			return;
		}
		if (paramStringBuffer.length() != 0)
		{
			paramStringBuffer.append(",");
		}
		paramStringBuffer.append(paramColumn.Name);
		});
		return stringBuffer.ToString();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\datamove\metadataKeeper\ProjectEntityMetadataKeeper.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}