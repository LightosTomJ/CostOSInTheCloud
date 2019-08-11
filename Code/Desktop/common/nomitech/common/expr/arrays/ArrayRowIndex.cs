using System;

namespace Desktop.common.nomitech.common.expr.arrays
{
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprException = org.boris.expr.ExprException;
	using ExprInteger = org.boris.expr.ExprInteger;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ArrayRowIndex : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 3);
		ExprArray exprArray = asArray(paramIEvaluationContext, paramArrayOfExpr[0], true);
		string str = asString(paramIEvaluationContext, paramArrayOfExpr[1], true);
		int? integer = (integer = Convert.ToInt32(asInteger(paramIEvaluationContext, paramArrayOfExpr[2], true))).valueOf(integer.Value - 1);
		if (integer.Value >= exprArray.columns() || integer.Value < 0)
		{
		  integer = Convert.ToInt32(0);
		}
		if (exprArray.columns() == 0)
		{
		  return new ExprInteger(0);
		}
		sbyte b1 = 0;
		int i = exprArray.rows();
		for (sbyte b2 = 0; b2 < i; b2++)
		{
		  string str1 = asString(paramIEvaluationContext, exprArray.get(b2, integer.Value), false);
		  if (str1.Equals(str, StringComparison.OrdinalIgnoreCase))
		  {
			b1 = b2 + 1;
			break;
		  }
		}
		return new ExprInteger(b1);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\ArrayRowIndex.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}