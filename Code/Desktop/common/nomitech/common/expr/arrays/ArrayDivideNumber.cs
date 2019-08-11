using System;

namespace Desktop.common.nomitech.common.expr.arrays
{
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprException = org.boris.expr.ExprException;
	using ExprInteger = org.boris.expr.ExprInteger;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ArrayDivideNumber : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertMinArgCount(paramArrayOfExpr, 2);
		assertMaxArgCount(paramArrayOfExpr, 2);
		ExprArray exprArray = asArray(paramIEvaluationContext, paramArrayOfExpr[0], true);
		double d = asDouble(paramIEvaluationContext, paramArrayOfExpr[1], true);
		int i = asInteger(paramIEvaluationContext, paramArrayOfExpr[1], true);
		if (d == 0.0D || i == 0)
		{
		  return exprArray;
		}
		int j = exprArray.rows();
		int k = exprArray.columns();
		for (sbyte b = 0; b < j; b++)
		{
		  for (sbyte b1 = 0; b1 < k; b1++)
		  {
			Expr expr = exprArray.get(b, b1);
			if (expr is ExprDouble)
			{
			  exprArray.set(b, b1, new ExprDouble(Math.Abs(((ExprDouble)expr).doubleValue()) / d));
			}
			else if (expr is ExprInteger)
			{
			  exprArray.set(b, b1, new ExprInteger(Math.Abs(((ExprInteger)expr).intValue()) / i));
			}
		  }
		}
		return exprArray;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\ArrayDivideNumber.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}