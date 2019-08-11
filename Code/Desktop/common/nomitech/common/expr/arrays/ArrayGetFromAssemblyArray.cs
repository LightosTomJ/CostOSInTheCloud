using System;

namespace Desktop.common.nomitech.common.expr.arrays
{
	using Expr = org.boris.expr.Expr;
	using ExprException = org.boris.expr.ExprException;
	using ExprString = org.boris.expr.ExprString;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ArrayGetFromAssemblyArray : AbstractFunction
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
		paramArrayOfExpr[0] = evalArg(paramIEvaluationContext, paramArrayOfExpr[0]);
		paramArrayOfExpr[1] = evalArg(paramIEvaluationContext, paramArrayOfExpr[1]);
		paramArrayOfExpr[2] = evalArg(paramIEvaluationContext, paramArrayOfExpr[2]);
		paramArrayOfExpr[3] = evalArg(paramIEvaluationContext, paramArrayOfExpr[3]);
		paramArrayOfExpr[4] = evalArg(paramIEvaluationContext, paramArrayOfExpr[4]);
		int i = asInteger(null, paramArrayOfExpr[1], false);
		int j = asInteger(null, paramArrayOfExpr[2], false);
		if (i <= 0)
		{
		  throw new ExprException("Cannot have zero or negative row index.");
		}
		if (j <= 0)
		{
		  throw new ExprException("Cannot have zero or negative column index");
		}
		string str1 = asString(paramIEvaluationContext, paramArrayOfExpr[0], false);
		bool bool1 = asBoolean(paramIEvaluationContext, paramArrayOfExpr[3], false);
		bool bool2 = asBoolean(paramIEvaluationContext, paramArrayOfExpr[4], false);
		if (bool1)
		{
		  int m = str1.IndexOf("\n_E_\n", StringComparison.Ordinal);
		  if (m != -1)
		  {
			str1 = StringHelper.SubstringSpecial(str1, m + "\n_E_\n".Length, str1.Length);
		  }
		}
		string[] arrayOfString = str1.Split("\n", true);
		if (i > arrayOfString.Length)
		{
		  throw new ExprException("Row index is greater than the array rows. *[If this array has formulas make sure you have passed TRUE() in the 5th argument!!]");
		}
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
		if (j > k)
		{
		  throw new ExprException("Column index is greater than the array columns. *[If this array has formulas make sure you have passed TRUE() in the 5th argument!!]");
		}
		if (bool2)
		{
		  string str = arrayOfString1[i - 1][j - 1];
		  return str.Equals("{#}") ? new ExprString("") : new ExprString(str);
		}
		string str2 = arrayOfString1[i][j - 1];
		return str2.Equals("{#}") ? new ExprString("") : new ExprString(str2);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\ArrayGetFromAssemblyArray.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}