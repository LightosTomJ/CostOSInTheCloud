using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.data.definition
{
	using BaseCache = nomitech.common.@base.BaseCache;
	using UILanguage = nomitech.common.ui.UILanguage;
	using ImageUtils = nomitech.common.util.ImageUtils;

	public abstract class GroupTableDefinition : DatabaseTableDefinition
	{
		public abstract string TableUserWriterRole {get;}
		public abstract java.awt.datatransfer.DataFlavor TableListDataFlavor {get;}
		public abstract java.awt.datatransfer.DataFlavor TableDataFlavor {get;}
		public abstract string LayoutType {get;}
		public abstract string TreeNodeTitle {get;}
		public abstract string PanelTitle {get;}
		public abstract ImageIcon WizardIcon {get;}
		public abstract ImageIcon getTableImageIcon(int paramInt);
		public abstract Image getTableImage(int paramInt);
		public abstract int DatabaseTableType {get;}
		public abstract string getTablePrefix(java.util.Properties paramProperties, int paramInt);
		public abstract bool isFieldEditable(string paramString);
		public abstract string[] Fields {get;}
	  private IDictionary<int, Image> o_glassImages = new Hashtable();

	  private IDictionary<int, ImageIcon> o_disabledImages = new Hashtable();

	  public static readonly string[] COLUMNS = new string[] {UILanguage.get("tab.groupcode.column.id"), UILanguage.get("tab.groupcode.column.groupcode"), UILanguage.get("tab.groupcode.column.title"), UILanguage.get("tab.groupcode.column.unit"), UILanguage.get("tab.groupcode.column.unitFactor"), UILanguage.get("tab.groupcode.column.editorId"), UILanguage.get("tab.groupcode.column.notes"), UILanguage.get("tab.groupcode.column.description"), UILanguage.get("tab.groupcode.column.lastUpdate")};

	  public static readonly Type[] CLASSES = new Type[] {typeof(Long), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(DateTime)};

	  private string[] editableFieldsNoDescription = null;

	  public abstract Type TableClass {get;}

	  public abstract string CodingStyle {get;}

	  public abstract string TableName {get;}

	  public abstract string TableFieldName {get;}

	  public abstract BaseCache GroupCache {get;}

	  public virtual string[] SearchableFields
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			for (sbyte b = 0; b < Fields.Length; b++)
			{
			  if (Classes[b].Equals(typeof(string)) && !Fields[b].EndsWith("formula", StringComparison.Ordinal) && !Fields[b].EndsWith("planningType", StringComparison.Ordinal) && !Fields[b].EndsWith("calculationType", StringComparison.Ordinal))
			  {
				arrayList.Add(Fields[b]);
			  }
			}
			return (string[])arrayList.ToArray(typeof(string));
		  }
	  }

	  public virtual Image getSeeThroughImage(int paramInt)
	  {
		Image image = (Image)this.o_glassImages[Convert.ToInt32(paramInt)];
		if (image == null)
		{
		  image = ImageUtils.createTransparentImage(getTableImage(paramInt), 0.5F);
		  this.o_glassImages[Convert.ToInt32(paramInt)] = image;
		}
		return image;
	  }

	  public virtual ImageIcon getDisabledImageIcon(int paramInt)
	  {
		ImageIcon imageIcon = (ImageIcon)this.o_disabledImages[Convert.ToInt32(paramInt)];
		if (imageIcon == null)
		{
		  imageIcon = ImageUtils.convertToGrayScale(getTableImage(paramInt));
		  this.o_disabledImages[Convert.ToInt32(paramInt)] = imageIcon;
		}
		return imageIcon;
	  }

	  public virtual Type[] Classes
	  {
		  get
		  {
			  return CLASSES;
		  }
	  }

	  public virtual string[] ColumnNames
	  {
		  get
		  {
			  return COLUMNS;
		  }
	  }

	  public virtual int ColumnCount
	  {
		  get
		  {
			  return ColumnNames.Length;
		  }
	  }

	  public virtual void reloadColumnNames()
	  {
	  }

	  public virtual bool supportsRenamingColumns()
	  {
		  return false;
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

	  public virtual bool isColumnRate(string paramString)
	  {
		for (sbyte b = 0; b < ColumnNames.Length; b++)
		{
		  if (ColumnNames[b].Equals(paramString))
		  {
			return Classes[b].Equals(typeof(decimal));
		  }
		}
		return false;
	  }

	  public virtual sbyte ReportType
	  {
		  get
		  {
			  return DatabaseReportUtil.GROUPCODE_REPORT;
		  }
	  }

	  public virtual bool hasFieldFillDown(string paramString)
	  {
		  return paramString.Equals("groupCode") ? false : isFieldEditable(paramString);
	  }

	  public virtual bool hasColumnSubtotal(string paramString)
	  {
		  return false;
	  }

	  public virtual bool hasFieldSubtotal(string paramString)
	  {
		  return false;
	  }

	  public virtual bool hasTableSubtotals()
	  {
		  return false;
	  }

	  public virtual bool isColumnIndexRolledUp(int paramInt)
	  {
		  return false;
	  }

	  public virtual bool supportsHeaderStyle()
	  {
		  return false;
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

	  public virtual int indexOfField(string paramString)
	  {
		for (sbyte b = 0; b < Fields.Length; b++)
		{
		  string str = Fields[b];
		  if (str.Equals(paramString))
		  {
			return b;
		  }
		}
		return -1;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\data\definition\GroupTableDefinition.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}