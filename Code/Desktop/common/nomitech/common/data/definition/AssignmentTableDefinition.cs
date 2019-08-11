using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.data.definition
{
	using FieldCustomizationTable = nomitech.common.db.local.FieldCustomizationTable;
	using FieldLookupUtil = nomitech.common.fields.FieldLookupUtil;

	public abstract class AssignmentTableDefinition
	{
	  protected internal string[] editableFields = null;

	  protected internal string[] editableFieldsNoDescription = null;

	  public abstract string[] Fields {get;}

	  public abstract Type[] Classes {get;}

	  public abstract string[] ColumnNames {get;}

	  public abstract bool isFieldEditable(string paramString);

	  public abstract ResourceTableDefinition ResourceTableDefinition {get;}

	  public abstract Type TableClass {get;}

	  public abstract int DialogAssignmentType {get;}

	  public abstract string[] DefaultColumnNames {get;}

	  public virtual bool fieldSupportsRename(string paramString)
	  {
		  return false;
	  }

	  public virtual string[] EditableFields
	  {
		  get
		  {
			if (this.editableFields != null)
			{
			  return this.editableFields;
			}
			List<object> arrayList = new List<object>();
			foreach (string str in Fields)
			{
			  if (isFieldEditable(str))
			  {
				arrayList.Add(str);
			  }
			}
			this.editableFields = (string[])arrayList.ToArray(typeof(string));
			return this.editableFields;
		  }
	  }

	  public virtual string[] EditableFieldsNoDescription
	  {
		  get
		  {
			if (this.editableFieldsNoDescription != null)
			{
			  return this.editableFieldsNoDescription;
			}
			List<object> arrayList = new List<object>();
			foreach (string str in Fields)
			{
			  if (isFieldEditable(str) && !str.Equals("description"))
			  {
				arrayList.Add(str);
			  }
			}
			this.editableFieldsNoDescription = (string[])arrayList.ToArray(typeof(string));
			return this.editableFieldsNoDescription;
		  }
	  }

	  public virtual string columnNameToFieldName(string paramString)
	  {
		for (sbyte b = 0; b < ColumnNames.Length; b++)
		{
		  if (ColumnNames[b].Equals(paramString))
		  {
			return Fields[b];
		  }
		}
		return null;
	  }

	  public virtual string fieldNameToColumnName(string paramString)
	  {
		for (sbyte b = 0; b < Fields.Length; b++)
		{
		  if (Fields[b].Equals(paramString))
		  {
			return ColumnNames[b];
		  }
		}
		return null;
	  }

	  public virtual Type fieldNameToClass(string paramString)
	  {
		for (sbyte b = 0; b < Fields.Length; b++)
		{
		  if (Fields[b].Equals(paramString))
		  {
			return Classes[b];
		  }
		}
		return null;
	  }

	  public virtual bool isFieldRate(string paramString)
	  {
		for (sbyte b = 0; b < Fields.Length; b++)
		{
		  if (Fields[b].Equals(paramString))
		  {
			return Classes[b].Equals(typeof(decimal));
		  }
		}
		return false;
	  }

	  public virtual int ColumnCount
	  {
		  get
		  {
			  return Fields.Length;
		  }
	  }

	  public virtual string getTablePrefix(Properties paramProperties, int paramInt)
	  {
		  return ResourceTableDefinition.getTablePrefix(paramProperties, paramInt);
	  }

	  public virtual string TableName
	  {
		  get
		  {
			  return ResourceTableDefinition.TableName;
		  }
	  }

	  public virtual string TreeNodeTitle
	  {
		  get
		  {
			  return ResourceTableDefinition.TreeNodeTitle;
		  }
	  }

	  public virtual ImageIcon getTableImageIcon(int paramInt)
	  {
		  return ResourceTableDefinition.getTableImageIcon(paramInt);
	  }

	  public virtual ImageIcon getTableImageDescIcon(int paramInt)
	  {
		  return ResourceTableDefinition.getTableImageDescIcon(paramInt);
	  }

	  public virtual string LayoutType
	  {
		  get
		  {
			  return ResourceTableDefinition.LayoutType;
		  }
	  }

	  public virtual int indexForField(string paramString)
	  {
		for (sbyte b = 0; b < Fields.Length; b++)
		{
		  if (paramString.Equals(Fields[b]))
		  {
			return b;
		  }
		}
		return -1;
	  }

	  public virtual void reloadColumnNames()
	  {
		foreach (string str in Fields)
		{
		  int i = indexForField(str);
		  FieldCustomizationTable fieldCustomizationTable = FieldLookupUtil.Instance.customizationForField(str, LayoutType);
		  if (fieldCustomizationTable != null)
		  {
			if (!string.ReferenceEquals(fieldCustomizationTable.DisplayName, null))
			{
			  ColumnNames[i] = fieldCustomizationTable.DisplayName;
			}
			else
			{
			  ColumnNames[i] = DefaultColumnNames[i];
			}
		  }
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\data\definition\AssignmentTableDefinition.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}