using System;

namespace Desktop.common.nomitech.costos.plugin.api.
{

	public class TakeoffItemSyncRowData
	{
	  private long? conditionId;

	  private string conditionTitle;

	  private string conditionGlobalId;

	  private string conditionUnit;

	  private decimal conditionQuantity;

	  private long? boqId;

	  private string boqTitle;

	  private string boqItemCode;

	  private string boqUnit;

	  private decimal boqConditionQuantity;

	  private DateTime boqLastUpdate;

	  private string boqEditorId;

	  public virtual long? ConditionId
	  {
		  get
		  {
			  return this.conditionId;
		  }
		  set
		  {
			  this.conditionId = value;
		  }
	  }


	  public virtual string ConditionTitle
	  {
		  get
		  {
			  return this.conditionTitle;
		  }
		  set
		  {
			  this.conditionTitle = value;
		  }
	  }


	  public virtual string ConditionGlobalId
	  {
		  get
		  {
			  return this.conditionGlobalId;
		  }
		  set
		  {
			  this.conditionGlobalId = value;
		  }
	  }


	  public virtual string ConditionUnit
	  {
		  get
		  {
			  return this.conditionUnit;
		  }
		  set
		  {
			  this.conditionUnit = value;
		  }
	  }


	  public virtual decimal ConditionQuantity
	  {
		  get
		  {
			  return this.conditionQuantity;
		  }
		  set
		  {
			  this.conditionQuantity = value;
		  }
	  }


	  public virtual long? BoqId
	  {
		  get
		  {
			  return this.boqId;
		  }
		  set
		  {
			  this.boqId = value;
		  }
	  }


	  public virtual string BoqTitle
	  {
		  get
		  {
			  return this.boqTitle;
		  }
		  set
		  {
			  this.boqTitle = value;
		  }
	  }


	  public virtual string BoqItemCode
	  {
		  get
		  {
			  return this.boqItemCode;
		  }
		  set
		  {
			  this.boqItemCode = value;
		  }
	  }


	  public virtual string BoqUnit
	  {
		  get
		  {
			  return this.boqUnit;
		  }
		  set
		  {
			  this.boqUnit = value;
		  }
	  }


	  public virtual decimal BoqConditionQuantity
	  {
		  get
		  {
			  return this.boqConditionQuantity;
		  }
		  set
		  {
			  this.boqConditionQuantity = value;
		  }
	  }


	  public virtual DateTime BoqLastUpdate
	  {
		  get
		  {
			  return this.boqLastUpdate;
		  }
		  set
		  {
			  this.boqLastUpdate = value;
		  }
	  }


	  public virtual string BoqEditorId
	  {
		  get
		  {
			  return this.boqEditorId;
		  }
		  set
		  {
			  this.boqEditorId = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\plugin\api\TakeoffItemSyncRowData.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}