using System;

namespace Desktop.common.nomitech.common.expr.arrays
{
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprException = org.boris.expr.ExprException;
	using ExprString = org.boris.expr.ExprString;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ArrayFromAssemblyArrayPartial : AbstractFunction
	{
	  private readonly string FORMULA_SPLITTER = "\n_E_\n";

	  private readonly string ROW_SPLITTER = "\n";

	  private readonly string COL_SPLITTER = ";";

	  private readonly string EMPTY_CELL = "{#}";

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 5);
		ExprArray exprArray = null;
		paramArrayOfExpr[0] = evalArg(paramIEvaluationContext, paramArrayOfExpr[0]);
		paramArrayOfExpr[1] = evalArg(paramIEvaluationContext, paramArrayOfExpr[1]);
		paramArrayOfExpr[2] = evalArg(paramIEvaluationContext, paramArrayOfExpr[2]);
		paramArrayOfExpr[3] = evalArg(paramIEvaluationContext, paramArrayOfExpr[3]);
		paramArrayOfExpr[4] = evalArg(paramIEvaluationContext, paramArrayOfExpr[4]);
		int i = asInteger(null, paramArrayOfExpr[1], false);
		int j = asInteger(null, paramArrayOfExpr[2], false);
		if (i <= 0)
		{
		  throw new ExprException("Cannot have zero or negative start column index.");
		}
		if (j <= 0)
		{
		  throw new ExprException("Cannot have zero or negative number of columns to show.");
		}
		string str = asString(paramIEvaluationContext, paramArrayOfExpr[0], false);
		bool bool1 = asBoolean(paramIEvaluationContext, paramArrayOfExpr[3], false);
		bool bool2 = asBoolean(paramIEvaluationContext, paramArrayOfExpr[4], false);
		if (bool1)
		{
		  int n = str.IndexOf("\n_E_\n", StringComparison.Ordinal);
		  if (n != -1)
		  {
			str = StringHelper.SubstringSpecial(str, n + "\n_E_\n".Length, str.Length);
		  }
		}
		string[] arrayOfString = str.Split("\n", true);
		string[][] arrayOfString1 = new string[arrayOfString.Length][];
		int k;
		for (k = 0; k < arrayOfString.Length; k++)
		{
		  arrayOfString1[k] = arrayOfString[k].Split(";", true);
		}
		k = 0;
		if (arrayOfString1.Length > 0)
		{
		  k = arrayOfString1[0].Length;
		}
		if (i > k)
		{
		  throw new ExprException("Start column index is greater than the array lenght.");
		}
		int m = i + j - 1;
		if (m > k)
		{
		  throw new ExprException("Given the start column index, the number of columns to show is out of range.");
		}
		bool @bool = false;
		if (!bool2)
		{
		  @bool = true;
		  exprArray = new ExprArray(arrayOfString1.Length - 1, m);
		}
		else
		{
		  exprArray = new ExprArray(arrayOfString1.Length, m);
		}
		sbyte b1 = 0;
		sbyte b2 = 0;
		for (sbyte b3 = @bool; b3 < arrayOfString1.Length; b3++)
		{
		  b2 = 0;
		  for (int n = i - 1; n < m; n++)
		  {
			string str1 = arrayOfString1[b3][n];
			if (str1.Equals("{#}"))
			{
			  exprArray.set(b1, b2, new ExprString(""));
			}
			else
			{
			  exprArray.set(b1, b2, new ExprString(str1));
			}
			b2++;
		  }
		  b1++;
		}
		return exprArray;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\ArrayFromAssemblyArrayPartial.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}