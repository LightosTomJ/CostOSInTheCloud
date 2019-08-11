using System;
using System.Text;

namespace Desktop.common.nomitech.common.expr.function
{
	using StringUtils = Desktop.common.nomitech.common.util.StringUtils;
	using Expr = Desktop.common.org.boris.expr.Expr;
	using ExprException = Desktop.common.org.boris.expr.ExprException;
	using ExprString = Desktop.common.org.boris.expr.ExprString;
	using IEvaluationContext = Desktop.common.org.boris.expr.IEvaluationContext;
	using AbstractFunction = Desktop.common.org.boris.expr.function.AbstractFunction;

	public class SUBSTITUTE : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertMinArgCount(paramArrayOfExpr, 3);
		assertMaxArgCount(paramArrayOfExpr, 4);
		string str1 = asString(paramIEvaluationContext, paramArrayOfExpr[0], false);
		string str2 = asString(paramIEvaluationContext, paramArrayOfExpr[1], false);
		string str3 = asString(paramIEvaluationContext, paramArrayOfExpr[2], false);
		int i = -1;
		if (paramArrayOfExpr.Length == 4)
		{
		  i = asInteger(paramIEvaluationContext, paramArrayOfExpr[3], true);
		}
		if (i == -1)
		{
		  return new ExprString(StringUtils.replaceAll(str1, str2, str3));
		}
		int j = str1.IndexOf(str2, StringComparison.Ordinal);
		for (sbyte b = 1; b < i && j != -1; b++)
		{
		  j = str1.IndexOf(str2, j + 1, StringComparison.Ordinal);
		}
		if (j != -1)
		{
		  StringBuilder stringBuilder = new StringBuilder();
		  if (j > 0)
		  {
			stringBuilder.Append(str1.Substring(0, j));
		  }
		  stringBuilder.Append(str3);
		  stringBuilder.Append(str1.Substring(j + str2.Length));
		}
		return new ExprString(str1);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\function\SUBSTITUTE.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}