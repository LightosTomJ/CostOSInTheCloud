using System.Collections.Generic;

namespace Desktop.common.nomitech.common.expr.takeoff
{
	using ConditionTable = nomitech.common.db.project.ConditionTable;
	using Expr = org.boris.expr.Expr;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprException = org.boris.expr.ExprException;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class QuantityTakeoffAdd : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 2);
		paramArrayOfExpr[0] = evalArg(paramIEvaluationContext, paramArrayOfExpr[0]);
		paramArrayOfExpr[1] = evalArg(paramIEvaluationContext, paramArrayOfExpr[1]);
		if (paramArrayOfExpr[0] is ExprTakeoff && paramArrayOfExpr[1] is ExprTakeoff)
		{
		  ExprTakeoff exprTakeoff1 = (ExprTakeoff)paramArrayOfExpr[0];
		  ExprTakeoff exprTakeoff2 = (ExprTakeoff)paramArrayOfExpr[1];
		  if (exprTakeoff1.Takeoffs == null)
		  {
			exprTakeoff1 = new ExprTakeoff(exprTakeoff1.value, new ConditionTable[0]);
		  }
		  if (exprTakeoff2.Takeoffs == null)
		  {
			exprTakeoff2 = new ExprTakeoff(exprTakeoff2.value, new ConditionTable[0]);
		  }
		  List<object> arrayList = new List<object>(exprTakeoff1.Takeoffs.Length + exprTakeoff2.Takeoffs.Length);
		  arrayList.AddRange(Arrays.asList(exprTakeoff1.Takeoffs));
		  arrayList.AddRange(Arrays.asList(exprTakeoff2.Takeoffs));
		  return new ExprTakeoff(exprTakeoff1.doubleValue() + exprTakeoff2.doubleValue(), (ConditionTable[])arrayList.ToArray(typeof(ConditionTable)));
		}
		return (paramArrayOfExpr[0] is org.boris.expr.ExprNumber && paramArrayOfExpr[1] is org.boris.expr.ExprNumber) ? new ExprDouble(asDouble(paramIEvaluationContext, paramArrayOfExpr[0], true) + asDouble(paramIEvaluationContext, paramArrayOfExpr[1], true)) : new ExprDouble(0.0D);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\takeoff\QuantityTakeoffAdd.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}