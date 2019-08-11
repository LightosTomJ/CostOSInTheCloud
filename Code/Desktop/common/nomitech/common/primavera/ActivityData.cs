using System;

namespace Desktop.common.nomitech.common.primavera
{
	using BaseTable = nomitech.common.@base.BaseTable;

	[Serializable]
	public class ActivityData : BaseTable
	{
	  private string activityId;

	  private string activityName;

	  private string unit;

	  private string wbsCode;

	  private decimal quantity;

	  private decimal manhours;

	  private decimal duration;

	  private double? completion;

	  private int? durationStart;

	  private int? durationEnd;

	  private DateTime lastUpdate;

	  private decimal totalCost;

	  private decimal totalRate;

	  private decimal laborRate;

	  public virtual decimal LaborRate
	  {
		  get
		  {
			  return this.laborRate;
		  }
		  set
		  {
			  this.laborRate = value;
		  }
	  }


	  public virtual decimal TotalCost
	  {
		  get
		  {
			  return this.totalCost;
		  }
		  set
		  {
			  this.totalCost = value;
		  }
	  }


	  public virtual decimal TotalRate
	  {
		  get
		  {
			  return this.totalRate;
		  }
		  set
		  {
			  this.totalRate = value;
		  }
	  }


	  public virtual string ActivityId
	  {
		  get
		  {
			  return this.activityId;
		  }
		  set
		  {
			  this.activityId = value;
		  }
	  }


	  public virtual string ActivityName
	  {
		  get
		  {
			  return this.activityName;
		  }
		  set
		  {
			  this.activityName = value;
		  }
	  }


	  public virtual string Unit
	  {
		  get
		  {
			  return this.unit;
		  }
		  set
		  {
			  this.unit = value;
		  }
	  }


	  public virtual string WbsCode
	  {
		  get
		  {
			  return this.wbsCode;
		  }
		  set
		  {
			  this.wbsCode = value;
		  }
	  }


	  public virtual decimal Quantity
	  {
		  get
		  {
			  return this.quantity;
		  }
		  set
		  {
			  this.quantity = value;
		  }
	  }


	  public virtual decimal Manhours
	  {
		  get
		  {
			  return this.manhours;
		  }
		  set
		  {
			  this.manhours = value;
		  }
	  }


	  public virtual decimal Duration
	  {
		  get
		  {
			  return this.duration;
		  }
		  set
		  {
			  this.duration = value;
		  }
	  }


	  public virtual DateTime LastUpdate
	  {
		  get
		  {
			  return this.lastUpdate;
		  }
		  set
		  {
			  this.lastUpdate = value;
		  }
	  }


	  public virtual double? Completion
	  {
		  get
		  {
			  return this.completion;
		  }
		  set
		  {
			  this.completion = value;
		  }
	  }


	  public virtual int? DurationStart
	  {
		  get
		  {
			  return this.durationStart;
		  }
		  set
		  {
			  this.durationStart = value;
		  }
	  }


	  public virtual int? DurationEnd
	  {
		  get
		  {
			  return this.durationEnd;
		  }
		  set
		  {
			  this.durationEnd = value;
		  }
	  }


	  public virtual object clone()
	  {
		  return null;
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient public System.Nullable<long> getId()
	  public virtual long? Id
	  {
		  get
		  {
			  return null;
		  }
	  }

	  public virtual string Title
	  {
		  get
		  {
			  return ActivityName;
		  }
		  set
		  {
			  ActivityName = value;
		  }
	  }


	  public virtual decimal TableRate
	  {
		  get
		  {
			  return null;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\primavera\ActivityData.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}