using System;

namespace Desktop.common.nomitech.common.expr.arrays
{
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprException = org.boris.expr.ExprException;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ArrayGet : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 3);
		ExprArray exprArray = asArray(paramIEvaluationContext, paramArrayOfExpr[0], true);
		double? double1;
		double? double2 = (double1 = Convert.ToDouble(asDouble(paramIEvaluationContext, paramArrayOfExpr[1], true) - 1.0D)).valueOf(asDouble(paramIEvaluationContext, paramArrayOfExpr[2], true) - 1.0D);
		return (double2.Value < 0.0D || double2.Value >= exprArray.rows()) ? new ExprDouble(1.0D) : ((double1.Value < 0.0D || double1.Value >= exprArray.columns()) ? new ExprDouble(1.0D) : exprArray.get(double2.Value, double1.Value));
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\ArrayGet.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}