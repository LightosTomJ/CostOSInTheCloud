using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.expr.arrays
{
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprEvaluatable = org.boris.expr.ExprEvaluatable;
	using ExprException = org.boris.expr.ExprException;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ArrayCreate : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertMinArgCount(paramArrayOfExpr, 1);
		int? integer1 = Convert.ToInt32(asInteger(paramIEvaluationContext, paramArrayOfExpr[0], true));
		paramArrayOfExpr = extractArgs(paramIEvaluationContext, (Expr[])Arrays.copyOfRange(paramArrayOfExpr, 1, paramArrayOfExpr.Length));
		int? integer2 = Convert.ToInt32(paramArrayOfExpr.Length / integer1.Value);
		ExprArray exprArray = new ExprArray(integer2.Value, integer1.Value);
		sbyte b1 = 0;
		for (sbyte b2 = 0; b2 < integer2.Value; b2++)
		{
		  for (sbyte b = 0; b < integer1.Value; b++)
		  {
			exprArray.set(b2, b, paramArrayOfExpr[b1++]);
		  }
		}
		return exprArray;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.boris.expr.Expr[] extractArgs(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  private Expr[] extractArgs(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		List<object> arrayList = new List<object>();
		foreach (Expr expr in paramArrayOfExpr)
		{
		  if (expr is ExprEvaluatable)
		  {
			expr = ((ExprEvaluatable)expr).evaluate(paramIEvaluationContext);
		  }
		  if (expr is ExprArray)
		  {
			Expr[] arrayOfExpr = extractArgs(paramIEvaluationContext, ((ExprArray)expr).InternalArray);
			arrayList.AddRange(Arrays.asList(arrayOfExpr));
		  }
		  else
		  {
			arrayList.Add(expr);
		  }
		}
		return (Expr[])arrayList.ToArray(typeof(Expr));
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\ArrayCreate.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}