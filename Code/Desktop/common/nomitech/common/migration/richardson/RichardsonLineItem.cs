using System;

namespace Desktop.common.nomitech.common.migration.richardson
{
	using BaseTable = nomitech.common.@base.BaseTable;

	public class RichardsonLineItem
	{
	  private string resourceType;

	  private string paramItemId;

	  private string title;

	  private string acct;

	  private bool online;

	  private DateTime lastUpdate;

	  public RichardsonLineItem()
	  {
	  }

	  public RichardsonLineItem(BaseTable paramBaseTable, string paramString, bool paramBoolean)
	  {
		  init(paramBaseTable, paramString, paramBoolean);
	  }

	  public virtual void init(BaseTable paramBaseTable, string paramString, bool paramBoolean)
	  {
		this.acct = paramString;
		this.online = paramBoolean;
		this.title = paramBaseTable.Title;
		this.lastUpdate = paramBaseTable.LastUpdate;
		this.paramItemId = "" + paramBaseTable.Id;
		if (paramBaseTable is nomitech.common.db.local.AssemblyTable)
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

	  public virtual string Title
	  {
		  get
		  {
			  return this.title;
		  }
	  }

	  public virtual string Acct
	  {
		  get
		  {
			  return this.acct;
		  }
	  }

	  public override string ToString()
	  {
		  return this.resourceType + (this.online ? "O" : "L") + this.paramItemId;
	  }

	  public virtual DateTime LastUpdate
	  {
		  get
		  {
			  return this.lastUpdate;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\richardson\RichardsonLineItem.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}