using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.@base
{
	using ParamItemQueryResourceTable = nomitech.common.db.local.ParamItemQueryResourceTable;
	using Session = org.hibernate.Session;

	public class BaseTableItem : object, IComparable<BaseTableItem>
	{
	  private BaseTable baseTable;

	  private bool online = false;

	  private string resourceType;

	  private double? factor = new double?(1.0D);

	  private BaseTableItem()
	  {
	  }

	  public BaseTableItem(BaseTable paramBaseTable, bool paramBoolean)
	  {
		this.baseTable = paramBaseTable;
		this.online = paramBoolean;
		if (paramBaseTable is ParamItemQueryResourceTable)
		{
		  this.resourceType = "Q";
		}
		else if (paramBaseTable is nomitech.common.db.local.ParamItemConceptualResourceTable)
		{
		  this.resourceType = "P";
		}
		else if (paramBaseTable is nomitech.common.db.local.AssemblyTable)
		{
		  this.resourceType = "A";
		}
		else if (paramBaseTable is nomitech.common.db.local.MaterialTable)
		{
		  this.resourceType = "M";
		}
		else if (paramBaseTable is nomitech.common.db.local.EquipmentTable)
		{
		  this.resourceType = "E";
		}
		else if (paramBaseTable is nomitech.common.db.local.SubcontractorTable)
		{
		  this.resourceType = "S";
		}
		else if (paramBaseTable is nomitech.common.db.local.LaborTable)
		{
		  this.resourceType = "L";
		}
		else if (paramBaseTable is nomitech.common.db.local.ConsumableTable)
		{
		  this.resourceType = "C";
		}
	  }

	  public virtual bool Online
	  {
		  get
		  {
			  return this.online;
		  }
	  }

	  public virtual BaseTable BaseTable
	  {
		  get
		  {
			  return this.baseTable;
		  }
	  }

	  public virtual double? Factor
	  {
		  get
		  {
			  return this.factor;
		  }
		  set
		  {
			  this.factor = value;
		  }
	  }


	  public override bool Equals(object paramObject)
	  {
		if (paramObject is BaseTableItem)
		{
		  BaseTableItem baseTableItem = (BaseTableItem)paramObject;
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		  return !baseTableItem.baseTable.GetType().FullName.Equals(this.baseTable.GetType().FullName) ? false : ((baseTableItem.baseTable.Id != null && this.baseTable.Id != null) ? baseTableItem.baseTable.Id.Equals(this.baseTable.Id) : baseTableItem.baseTable.Title.Equals(this.baseTable.Title));
		}
		return false;
	  }

	  public virtual int CompareTo(BaseTableItem paramBaseTableItem)
	  {
		  return (paramBaseTableItem.baseTable.Id != null && this.baseTable.Id != null) ? -paramBaseTableItem.baseTable.Id.compareTo(this.baseTable.Id) : ((paramBaseTableItem.baseTable.Id == null && this.baseTable.Id == null) ? -paramBaseTableItem.baseTable.Title.CompareTo(this.baseTable.Title) : ((paramBaseTableItem.baseTable.Id == null) ? -1 : 1));
	  }

	  public override string ToString()
	  {
		  return this.resourceType + (this.online ? "O" : "L") + this.baseTable.Id;
	  }

	  public static IList<BaseTableItem> loadItems(Session paramSession, string[] paramArrayOfString)
	  {
		  return loadItems(paramSession, paramArrayOfString, false);
	  }

	  public static IList<BaseTableItem> loadItems(Session paramSession, string[] paramArrayOfString, bool paramBoolean)
	  {
		List<object> arrayList = new List<object>();
		foreach (string str1 in paramArrayOfString)
		{
		  string str2 = "" + str1[0];
		  string str3 = "" + str1[1];
		  long? long = Convert.ToInt64(long.Parse(str1.Substring(2, str1.Length - 2)));
		  BaseTable baseTable1 = null;
		  if (str2.Equals("Q"))
		  {
			baseTable1 = (BaseTable)paramSession.load(typeof(ParamItemQueryResourceTable), long);
		  }
		  else if (str2.Equals("P"))
		  {
			baseTable1 = (BaseTable)paramSession.load(typeof(nomitech.common.db.local.ParamItemConceptualResourceTable), long);
		  }
		  else if (str2.Equals("A"))
		  {
			baseTable1 = (BaseTable)paramSession.load(typeof(nomitech.common.db.local.AssemblyTable), long);
		  }
		  else if (str2.Equals("E"))
		  {
			baseTable1 = (BaseTable)paramSession.load(typeof(nomitech.common.db.local.EquipmentTable), long);
		  }
		  else if (str2.Equals("S"))
		  {
			baseTable1 = (BaseTable)paramSession.load(typeof(nomitech.common.db.local.SubcontractorTable), long);
		  }
		  else if (str2.Equals("L"))
		  {
			baseTable1 = (BaseTable)paramSession.load(typeof(nomitech.common.db.local.LaborTable), long);
		  }
		  else if (str2.Equals("M"))
		  {
			baseTable1 = (BaseTable)paramSession.load(typeof(nomitech.common.db.local.MaterialTable), long);
		  }
		  else if (str2.Equals("C"))
		  {
			baseTable1 = (BaseTable)paramSession.load(typeof(nomitech.common.db.local.ConsumableTable), long);
		  }
		  arrayList.Add(new BaseTableItem(baseTable1, paramBoolean));
		}
		return arrayList;
	  }

	  public virtual BaseTableItem clone()
	  {
		BaseTableItem baseTableItem = new BaseTableItem();
		if (Query)
		{
		  baseTableItem.baseTable = ((ParamItemQueryResourceTable)this.baseTable).copy();
		}
		else
		{
		  baseTableItem.baseTable = (BaseTable)this.baseTable.Clone();
		}
		baseTableItem.online = this.online;
		baseTableItem.resourceType = this.resourceType;
		return baseTableItem;
	  }

	  public virtual bool Conceptual
	  {
		  get
		  {
			  return this.baseTable is nomitech.common.db.local.ParamItemConceptualResourceTable;
		  }
	  }

	  public virtual bool Query
	  {
		  get
		  {
			  return this.baseTable is ParamItemQueryResourceTable;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\base\BaseTableItem.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}