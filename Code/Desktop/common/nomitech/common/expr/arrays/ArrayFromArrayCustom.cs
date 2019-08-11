using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.expr.arrays
{
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprException = org.boris.expr.ExprException;
	using ExprString = org.boris.expr.ExprString;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ArrayFromArrayCustom : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 10);
		ExprArray exprArray1 = null;
		Expr expr1 = evalArg(paramIEvaluationContext, paramArrayOfExpr[0]);
		Expr expr2 = evalArg(paramIEvaluationContext, paramArrayOfExpr[1]);
		Expr expr3 = evalArg(paramIEvaluationContext, paramArrayOfExpr[2]);
		Expr expr4 = evalArg(paramIEvaluationContext, paramArrayOfExpr[3]);
		Expr expr5 = evalArg(paramIEvaluationContext, paramArrayOfExpr[4]);
		Expr expr6 = evalArg(paramIEvaluationContext, paramArrayOfExpr[5]);
		Expr expr7 = evalArg(paramIEvaluationContext, paramArrayOfExpr[6]);
		Expr expr8 = evalArg(paramIEvaluationContext, paramArrayOfExpr[7]);
		Expr expr9 = evalArg(paramIEvaluationContext, paramArrayOfExpr[8]);
		Expr expr10 = evalArg(paramIEvaluationContext, paramArrayOfExpr[9]);
		ExprArray exprArray2 = asArray(paramIEvaluationContext, expr1, false);
		string str = asString(paramIEvaluationContext, expr2, false);
		int i = asInteger(paramIEvaluationContext, expr3, false);
		double d1 = asDouble(paramIEvaluationContext, expr4, false);
		int j = asInteger(paramIEvaluationContext, expr5, false);
		int k = asInteger(paramIEvaluationContext, expr6, false);
		double d2 = asDouble(paramIEvaluationContext, expr7, false);
		int m = asInteger(paramIEvaluationContext, expr8, false);
		int n = asInteger(paramIEvaluationContext, expr9, false);
		int i1 = asInteger(paramIEvaluationContext, expr10, false);
		if (exprArray2 is DummyExprArray)
		{
		  return new ExprArray(0, 0);
		}
		if (i <= 0)
		{
		  throw new ExprException("Column to search text (3rd argument) cannot be less than or equal to zero.");
		}
		if (i > exprArray2.length())
		{
		  throw new ExprException("Column to search text (3rd argument) is greater than the array lenght.");
		}
		if (j <= 0)
		{
		  throw new ExprException("Begin column index in range 1 (5th argument) cannot be less than or equal to zero.");
		}
		if (j > exprArray2.length())
		{
		  throw new ExprException("Begin column index in range 1 (5th argument) is greater than the array lenght.");
		}
		if (k <= 0)
		{
		  throw new ExprException("End column index in range 1 (6th argument) cannot be less than or equal to zero.");
		}
		if (k > exprArray2.length())
		{
		  throw new ExprException("End column index in range 1 (6th argument) is greater than the array lenght.");
		}
		if (m < 0)
		{
		  throw new ExprException("Begin column index in range 2 (8th argument) cannot be less than zero.");
		}
		if (m > exprArray2.length())
		{
		  throw new ExprException("Begin column index in range 2 (8th argument) is greater than the array lenght.");
		}
		if (n < 0)
		{
		  throw new ExprException("End column index in range 2 (9th argument) cannot be less than zero.");
		}
		if (n > exprArray2.length())
		{
		  throw new ExprException("End column index in range 2 (9th argument) is greater than the array lenght.");
		}
		if (i1 <= 0)
		{
		  throw new ExprException("Column index to return values (10th argument) cannot be less than or equal to zero.");
		}
		if (i1 > exprArray2.length())
		{
		  throw new ExprException("Column index to return values (10th argument) is greater than the array lenght.");
		}
		List<object> arrayList = new List<object>();
		sbyte b;
		for (b = 0; b < exprArray2.rows(); b++)
		{
		  string str1 = asString(paramIEvaluationContext, exprArray2.get(b, i - 1), false);
		  double d3 = asDouble(paramIEvaluationContext, exprArray2.get(b, j - 1), false);
		  double d4 = asDouble(paramIEvaluationContext, exprArray2.get(b, k - 1), false);
		  if (m == 0 || n == 0)
		  {
			if (str.Equals(str1, StringComparison.OrdinalIgnoreCase) && d1 >= d3 && d1 <= d4)
			{
			  string str2 = asString(paramIEvaluationContext, exprArray2.get(b, i1 - 1), false);
			  arrayList.Add(str2);
			}
		  }
		  else if (m > 0 && n > 0)
		  {
			double d5 = asDouble(paramIEvaluationContext, exprArray2.get(b, m - 1), false);
			double d6 = asDouble(paramIEvaluationContext, exprArray2.get(b, n - 1), false);
			if (str.Equals(str1, StringComparison.OrdinalIgnoreCase) && d1 >= d3 && d1 <= d4 && d2 >= d5 && d2 <= d6)
			{
			  string str2 = asString(paramIEvaluationContext, exprArray2.get(b, i1 - 1), false);
			  arrayList.Add(str2);
			}
		  }
		}
		if (arrayList.Count == 0)
		{
		  exprArray1 = new ExprArray(0, 1);
		}
		else
		{
		  exprArray1 = new ExprArray(arrayList.Count, 1);
		  for (b = 0; b < arrayList.Count; b++)
		  {
			exprArray1.set(b, 0, new ExprString((string)arrayList[b]));
		  }
		}
		return exprArray1;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\ArrayFromArrayCustom.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}