namespace Desktop.common.nomitech.costos.plugin.api
{
	using ConditionTable = nomitech.common.db.project.ConditionTable;

	public class ITakeoffRequest
	{
	  private string variableName;

	  private string variableLabel;

	  private string variableGroupName;

	  private string description;

	  private string unit;

	  private decimal quantity;

	  private ConditionTable[] takeoffs;

	  public virtual string VariableLabel
	  {
		  get
		  {
			  return this.variableLabel;
		  }
		  set
		  {
			  this.variableLabel = value;
		  }
	  }


	  public virtual string VariableGroupName
	  {
		  get
		  {
			  return this.variableGroupName;
		  }
		  set
		  {
			  this.variableGroupName = value;
		  }
	  }


	  public virtual string Description
	  {
		  get
		  {
			  return this.description;
		  }
		  set
		  {
			  this.description = value;
		  }
	  }


	  public virtual string VariableName
	  {
		  get
		  {
			  return this.variableName;
		  }
		  set
		  {
			  this.variableName = value;
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


	  public virtual ConditionTable[] Takeoffs
	  {
		  get
		  {
			  return this.takeoffs;
		  }
		  set
		  {
			  this.takeoffs = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\plugin\api\ITakeoffRequest.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}