using System;

namespace Desktop.common.nomitech.common.ui
{

	[Serializable]
	public class TriggerNamesListModelData
	{
	  internal string table_name;

	  internal string trigger_name;

	  internal string trigger_owner;

	  internal bool? isupdate;

	  internal bool? isdelete;

	  internal bool? isinsert;

	  internal bool? isafter;

	  internal bool? isinsteadof;

	  internal string status;

	  public virtual string Table_name
	  {
		  get
		  {
			  return this.table_name;
		  }
		  set
		  {
			  this.table_name = value;
		  }
	  }


	  public virtual string Trigger_name
	  {
		  get
		  {
			  return this.trigger_name;
		  }
		  set
		  {
			  this.trigger_name = value;
		  }
	  }


	  public virtual string Trigger_owner
	  {
		  get
		  {
			  return this.trigger_owner;
		  }
		  set
		  {
			  this.trigger_owner = value;
		  }
	  }


	  public virtual bool? Isupdate
	  {
		  get
		  {
			  return this.isupdate;
		  }
		  set
		  {
			  this.isupdate = value;
		  }
	  }


	  public virtual bool? Isdelete
	  {
		  get
		  {
			  return this.isdelete;
		  }
		  set
		  {
			  this.isdelete = value;
		  }
	  }


	  public virtual bool? Isinsert
	  {
		  get
		  {
			  return this.isinsert;
		  }
		  set
		  {
			  this.isinsert = value;
		  }
	  }


	  public virtual bool? Isafter
	  {
		  get
		  {
			  return this.isafter;
		  }
		  set
		  {
			  this.isafter = value;
		  }
	  }


	  public virtual bool? Isinsteadof
	  {
		  get
		  {
			  return this.isinsteadof;
		  }
		  set
		  {
			  this.isinsteadof = value;
		  }
	  }


	  public virtual string Status
	  {
		  get
		  {
			  return this.status;
		  }
		  set
		  {
			  this.status = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\ui\TriggerNamesListModelData.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}