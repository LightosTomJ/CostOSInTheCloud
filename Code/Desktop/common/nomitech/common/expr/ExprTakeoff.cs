namespace Desktop.common.nomitech.common.expr
{
	using ConditionTable = nomitech.common.db.project.ConditionTable;
	using ExprDouble = org.boris.expr.ExprDouble;

	public class ExprTakeoff : ExprDouble
	{
	  private ConditionTable[] o_takeoffs;

	  public ExprTakeoff(double paramDouble, ConditionTable[] paramArrayOfConditionTable) : base(paramDouble)
	  {
		this.o_takeoffs = paramArrayOfConditionTable;
	  }

	  public virtual ConditionTable[] Takeoffs
	  {
		  get
		  {
			  return this.o_takeoffs;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\ExprTakeoff.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}