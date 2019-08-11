﻿using System;

namespace Desktop.common.nomitech.common.expr.arrays
{
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprException = org.boris.expr.ExprException;
	using ExprInteger = org.boris.expr.ExprInteger;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ArrayAbsArray : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertMinArgCount(paramArrayOfExpr, 1);
		assertMaxArgCount(paramArrayOfExpr, 1);
		ExprArray exprArray = asArray(paramIEvaluationContext, paramArrayOfExpr[0], true);
		int i = exprArray.rows();
		int j = exprArray.columns();
		for (sbyte b = 0; b < i; b++)
		{
		  for (sbyte b1 = 0; b1 < j; b1++)
		  {
			Expr expr = exprArray.get(b, b1);
			if (expr is ExprDouble)
			{
			  exprArray.set(b, b1, new ExprDouble(Math.Abs(((ExprDouble)expr).doubleValue())));
			}
			else if (expr is ExprInteger)
			{
			  exprArray.set(b, b1, new ExprInteger(Math.Abs(((ExprInteger)expr).intValue())));
			}
		  }
		}
		return exprArray;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\ArrayAbsArray.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}