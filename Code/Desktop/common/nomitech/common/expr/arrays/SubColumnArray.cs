using System;

namespace Desktop.common.nomitech.common.expr.arrays
{
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprException = org.boris.expr.ExprException;
	using ExprInteger = org.boris.expr.ExprInteger;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class SubColumnArray : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertMinArgCount(paramArrayOfExpr, 2);
		ExprArray exprArray1 = asArray(paramIEvaluationContext, paramArrayOfExpr[0], true);
		int?[] arrayOfInteger = new int?[paramArrayOfExpr.Length - 1];
		for (sbyte b1 = 1; b1 < paramArrayOfExpr.Length; b1++)
		{
		  arrayOfInteger[b1 - true] = Convert.ToInt32(asInteger(paramIEvaluationContext, paramArrayOfExpr[b1], true));
		}
		ExprArray exprArray2 = new ExprArray(exprArray1.rows(), arrayOfInteger.Length);
		for (sbyte b2 = 0; b2 < arrayOfInteger.Length; b2++)
		{
		  for (sbyte b = 0; b < exprArray1.rows(); b++)
		  {
			int i = arrayOfInteger[b2].Value - 1;
			if (i < 0 || i >= exprArray1.columns())
			{
			  ExprInteger exprInteger = new ExprInteger(1);
			  exprArray2.set(b, b2, exprInteger);
			}
			else
			{
			  Expr expr = exprArray1.get(b, i);
			  exprArray2.set(b, b2, expr);
			}
		  }
		}
		return exprArray2;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\SubColumnArray.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}