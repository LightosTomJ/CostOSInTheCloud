using System;

namespace Desktop.common.nomitech.common.expr.arrays
{
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprException = org.boris.expr.ExprException;
	using ExprInteger = org.boris.expr.ExprInteger;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ArrayColumnIndex : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 2);
		ExprArray exprArray = asArray(paramIEvaluationContext, paramArrayOfExpr[0], true);
		string str = asString(paramIEvaluationContext, paramArrayOfExpr[1], true);
		sbyte b1 = 0;
		if (exprArray is ExprArrayWithHeader)
		{
		  ExprArrayWithHeader exprArrayWithHeader = (ExprArrayWithHeader)exprArray;
		  int j = exprArrayWithHeader.Columns.Length;
		  for (sbyte b = 0; b < j; b++)
		  {
			string str1 = exprArrayWithHeader.Columns[b];
			if (str1.Equals(str, StringComparison.OrdinalIgnoreCase))
			{
			  b1 = b + true;
			  break;
			}
		  }
		  return new ExprInteger(b1);
		}
		if (exprArray.rows() == 0)
		{
		  return new ExprInteger(b1);
		}
		int i = exprArray.columns();
		for (sbyte b2 = 0; b2 < i; b2++)
		{
		  string str1 = asString(paramIEvaluationContext, exprArray.get(0, b2), false);
		  if (str1.Equals(str, StringComparison.OrdinalIgnoreCase))
		  {
			b1 = b2 + 1;
			break;
		  }
		}
		return new ExprInteger(b1);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\ArrayColumnIndex.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}