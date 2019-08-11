using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.data.definition
{
	using ResourceHistoryTable = nomitech.common.@base.ResourceHistoryTable;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using ImageUtils = nomitech.common.util.ImageUtils;

	public abstract class ResourceTableDefinition : DatabaseTableDefinition
	{
		public abstract string TableUserWriterRole {get;}
		public abstract java.awt.datatransfer.DataFlavor TableListDataFlavor {get;}
		public abstract java.awt.datatransfer.DataFlavor TableDataFlavor {get;}
		public abstract sbyte ReportType {get;}
		public abstract string LayoutType {get;}
		public abstract string TreeNodeTitle {get;}
		public abstract string PanelTitle {get;}
		public abstract ImageIcon WizardIcon {get;}
		public abstract ImageIcon getTableImageIcon(int paramInt);
		public abstract Image getTableImage(int paramInt);
		public abstract string getTablePrefix(Properties paramProperties, int paramInt);
		public abstract bool hasFieldFillDown(string paramString);
		public abstract bool isFieldEditable(string paramString);
		public abstract string[] ColumnNames {get;}
		public abstract Type[] Classes {get;}
		public abstract string[] Fields {get;}
	  private IDictionary<int, Image> o_glassImages = new Hashtable();

	  private IDictionary<int, ImageIcon> o_disabledImages = new Hashtable();

	  protected internal string[] editableFields = null;

	  protected internal string[] editableFieldsNoDescription = null;

	  private IDictionary<string, int> fieldNameIndicesMap = null;

	  protected internal IDictionary<string, int> columnNameIndicesMap = null;

	  public abstract string SelectPanelTitle {get;}

	  public abstract ImageIcon getTableImageDescIcon(int paramInt);

	  public abstract Type TableClass {get;}

	  public abstract string TableName {get;}

	  public abstract bool TimedResource {get;}

	  public abstract bool MaterialTypeResource {get;}

	  public abstract string TableIdFieldName {get;}

	  public virtual string[] SearchableFields
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			for (sbyte b = 0; b < Fields.Length; b++)
			{
			  if (Classes[b].Equals(typeof(string)) && !Fields[b].EndsWith("ormula", StringComparison.Ordinal) && !Fields[b].EndsWith("planningType", StringComparison.Ordinal) && !Fields[b].EndsWith("calculationType", StringComparison.Ordinal))
			  {
				arrayList.Add(Fields[b]);
			  }
			}
			return (string[])arrayList.ToArray(typeof(string));
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

	  public virtual bool isColumnIndexRolledUp(int paramInt)
	  {
		  return false;
	  }

	  public virtual bool supportsRenamingColumns()
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
		int? integer = (int?)ColumnNameIndices[paramString];
		return (integer == null) ? null : Fields[integer.Value];
	  }

	  public virtual string fieldNameToColumnName(string paramString)
	  {
		int? integer = (int?)FieldNameIndices[paramString];
		return (integer == null) ? null : ColumnNames[integer.Value];
	  }

	  public virtual Type fieldNameToClass(string paramString)
	  {
		int? integer = (int?)FieldNameIndices[paramString];
		return (integer == null) ? null : Classes[integer.Value];
	  }

	  public virtual bool isFieldRate(string paramString)
	  {
		int? integer = (int?)FieldNameIndices[paramString];
		return (integer == null) ? false : Classes[integer.Value].Equals(typeof(decimal));
	  }

	  public virtual int indexForField(string paramString)
	  {
		int? integer = (int?)FieldNameIndices[paramString];
		return (integer == null) ? -1 : integer.Value;
	  }

	  public virtual int indexForEditableField(string paramString)
	  {
		string[] arrayOfString = EditableFields;
		for (sbyte b = 0; b < arrayOfString.Length; b++)
		{
		  if (paramString.Equals(arrayOfString[b]))
		  {
			return b;
		  }
		}
		Console.WriteLine("COULD NOT FIND INDEX FOR EDITABLE: " + paramString);
		return -1;
	  }

	  public virtual int DatabaseTableType
	  {
		  get
		  {
			  return 0;
		  }
	  }

	  public virtual bool isColumnRate(string paramString)
	  {
		int? integer = (int?)ColumnNameIndices[paramString];
		return (integer == null) ? false : Classes[integer.Value].Equals(typeof(decimal));
	  }

	  protected internal virtual void initializeTableProperties(Properties paramProperties, string paramString1, string paramString2)
	  {
		if (paramProperties.getProperty(paramString2 + ".column.preference") != null)
		{
		  return;
		}
		string str = paramProperties.getProperty(paramString1 + ".layout");
		if (!string.ReferenceEquals(str, null))
		{
		  paramProperties.setProperty(paramString2 + ".layout", str);
		}
		str = paramProperties.getProperty(paramString1 + ".column.preference");
		if (!string.ReferenceEquals(str, null))
		{
		  paramProperties.setProperty(paramString2 + ".column.preference", str);
		}
		str = paramProperties.getProperty(paramString1 + ".sorting.preference");
		if (!string.ReferenceEquals(str, null))
		{
		  paramProperties.setProperty(paramString2 + ".sorting.preference", str);
		}
		str = paramProperties.getProperty(paramString1 + ".row.resize");
		if (!string.ReferenceEquals(str, null))
		{
		  paramProperties.setProperty(paramString2 + ".row.resize", str);
		}
		str = paramProperties.getProperty(paramString1 + ".column.filters");
		if (!string.ReferenceEquals(str, null))
		{
		  paramProperties.setProperty(paramString2 + ".column.filters", str);
		}
		str = paramProperties.getProperty(paramString1 + ".header.rowheight");
		if (!string.ReferenceEquals(str, null))
		{
		  paramProperties.setProperty(paramString2 + ".header.rowheight", str);
		}
		str = paramProperties.getProperty(paramString1 + ".category.type");
		if (!string.ReferenceEquals(str, null))
		{
		  paramProperties.setProperty(paramString2 + ".category.type", str);
		}
		str = paramProperties.getProperty(paramString1 + ".column.locked");
		if (!string.ReferenceEquals(str, null))
		{
		  paramProperties.setProperty(paramString2 + ".column.locked", str);
		}
		str = paramProperties.getProperty(paramString1 + ".assignment.show");
		if (!string.ReferenceEquals(str, null))
		{
		  paramProperties.setProperty(paramString2 + ".assignment.show", str);
		}
		str = paramProperties.getProperty(paramString1 + ".visualizer.show");
		if (!string.ReferenceEquals(str, null))
		{
		  paramProperties.setProperty(paramString2 + ".visualizer.show", str);
		}
		str = paramProperties.getProperty(paramString1 + ".sidebar.show");
		if (!string.ReferenceEquals(str, null))
		{
		  paramProperties.setProperty(paramString2 + ".sidebar.show", str);
		}
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

	  public virtual AssignmentTableDefinition AssignmentTableDefinition
	  {
		  get
		  {
			  return null;
		  }
	  }

	  public virtual AssignmentTableDefinition BoqItemAssignmentTableDefinition
	  {
		  get
		  {
			  return null;
		  }
	  }

	  public virtual Type findResourceHistoryClassOfInstance(ResourceHistoryTable paramResourceHistoryTable)
	  {
		  return (paramResourceHistoryTable is nomitech.common.db.project.AssemblyHistoryTable) ? typeof(nomitech.common.db.project.AssemblyHistoryTable) : ((paramResourceHistoryTable is nomitech.common.db.project.EquipmentHistoryTable) ? typeof(nomitech.common.db.project.EquipmentHistoryTable) : ((paramResourceHistoryTable is nomitech.common.db.project.SubcontractorHistoryTable) ? typeof(nomitech.common.db.project.SubcontractorHistoryTable) : ((paramResourceHistoryTable is nomitech.common.db.project.LaborHistoryTable) ? typeof(nomitech.common.db.project.LaborHistoryTable) : ((paramResourceHistoryTable is nomitech.common.db.project.MaterialHistoryTable) ? typeof(nomitech.common.db.project.MaterialHistoryTable) : ((paramResourceHistoryTable is nomitech.common.db.project.ConsumableHistoryTable) ? typeof(nomitech.common.db.project.ConsumableHistoryTable) : null)))));
	  }

	  public virtual string findResourceNameOfInstance(ResourceTable paramResourceTable)
	  {
		  return (paramResourceTable is nomitech.common.db.project.BoqItemTable) ? "boqitem" : ((paramResourceTable is nomitech.common.db.local.AssemblyTable) ? "assembly" : ((paramResourceTable is nomitech.common.db.local.ParamItemTable) ? "paramitem" : ((paramResourceTable is nomitech.common.db.local.EquipmentTable) ? "equipment" : ((paramResourceTable is nomitech.common.db.local.SubcontractorTable) ? "subcontractor" : ((paramResourceTable is nomitech.common.db.local.LaborTable) ? "labor" : ((paramResourceTable is nomitech.common.db.local.MaterialTable) ? "material" : ((paramResourceTable is nomitech.common.db.local.ConsumableTable) ? "consumable" : ((paramResourceTable is nomitech.common.db.local.SupplierTable) ? "supplier" : null))))))));
	  }

	  public virtual Type findResourceClassOfInstance(ResourceTable paramResourceTable)
	  {
		  return (paramResourceTable is nomitech.common.db.project.BoqItemTable) ? typeof(nomitech.common.db.project.BoqItemTable) : ((paramResourceTable is nomitech.common.db.local.AssemblyTable) ? typeof(nomitech.common.db.local.AssemblyTable) : ((paramResourceTable is nomitech.common.db.local.ParamItemTable) ? typeof(nomitech.common.db.local.ParamItemTable) : ((paramResourceTable is nomitech.common.db.local.EquipmentTable) ? typeof(nomitech.common.db.local.EquipmentTable) : ((paramResourceTable is nomitech.common.db.local.SubcontractorTable) ? typeof(nomitech.common.db.local.SubcontractorTable) : ((paramResourceTable is nomitech.common.db.local.LaborTable) ? typeof(nomitech.common.db.local.LaborTable) : ((paramResourceTable is nomitech.common.db.local.MaterialTable) ? typeof(nomitech.common.db.local.MaterialTable) : ((paramResourceTable is nomitech.common.db.local.ConsumableTable) ? typeof(nomitech.common.db.local.ConsumableTable) : ((paramResourceTable is nomitech.common.db.local.SupplierTable) ? typeof(nomitech.common.db.local.SupplierTable) : null))))))));
	  }

	  public virtual bool resourceSupportsTrends()
	  {
		  return true;
	  }

	  public virtual bool resourceSupportsExplode()
	  {
		  return false;
	  }

	  public virtual bool supportsHeaderStyle()
	  {
		  return false;
	  }

	  public virtual int indexOfField(string paramString)
	  {
		  return indexForField(paramString);
	  }

	  public virtual bool isFieldNullable(string paramString)
	  {
		  return false;
	  }

	  public virtual IDictionary<string, string> FieldToColumnNameMap
	  {
		  get
		  {
			Hashtable hashMap = new Hashtable();
			foreach (string str in Fields)
			{
			  hashMap[str] = columnNameToFieldName(str);
			}
			return hashMap;
		  }
	  }

	  protected internal virtual IDictionary<string, int> ColumnNameIndices
	  {
		  get
		  {
			if (this.columnNameIndicesMap == null)
			{
			  this.columnNameIndicesMap = new Hashtable(ColumnNames.Length);
			  for (sbyte b = 0; b < ColumnNames.Length; b++)
			  {
				this.columnNameIndicesMap[ColumnNames[b]] = Convert.ToInt32(b);
			  }
			}
			return this.columnNameIndicesMap;
		  }
	  }

	  protected internal virtual IDictionary<string, int> FieldNameIndices
	  {
		  get
		  {
			if (this.fieldNameIndicesMap == null)
			{
			  this.fieldNameIndicesMap = new Hashtable(Fields.Length);
			  for (sbyte b = 0; b < Fields.Length; b++)
			  {
				this.fieldNameIndicesMap[Fields[b]] = Convert.ToInt32(b);
			  }
			}
			return this.fieldNameIndicesMap;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\data\definition\ResourceTableDefinition.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}