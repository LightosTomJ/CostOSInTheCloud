using System;

namespace Desktop.common.nomitech.common.expr.function
{
	using Expr = Desktop.common.org.boris.expr.Expr;
	using ExprError = Desktop.common.org.boris.expr.ExprError;
	using ExprException = Desktop.common.org.boris.expr.ExprException;
	using ExprNumber = Desktop.common.org.boris.expr.ExprNumber;
	using ExprString = Desktop.common.org.boris.expr.ExprString;
	using IEvaluationContext = Desktop.common.org.boris.expr.IEvaluationContext;
	using AbstractFunction = Desktop.common.org.boris.expr.function.AbstractFunction;

	public class TEXT : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 2);
		Expr expr1 = evalArg(paramIEvaluationContext, paramArrayOfExpr[0]);
		if (expr1 is ExprError)
		{
		  return expr1;
		}
		if (!isNumber(expr1))
		{
		  return ExprError.VALUE;
		}
		double d = ((ExprNumber)expr1).doubleValue();
		Expr expr2 = evalArg(paramIEvaluationContext, paramArrayOfExpr[1]);
		if (expr2 is ExprError)
		{
		  return expr2;
		}
		string str1 = asString(paramIEvaluationContext, expr2, false);
		string str2 = format(d, str1);
		return (!string.ReferenceEquals(str2, null)) ? new ExprString(str2) : ExprError.VALUE;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static String format(double paramDouble, String paramString) throws org.boris.expr.ExprException
	  public static string format(double paramDouble, string paramString)
	  {
		try
		{
		  DecimalFormat decimalFormat = new DecimalFormat(paramString);
		  return decimalFormat.format(paramDouble);
		}
		catch (Exception exception)
		{
		  throw new ExprException(exception.Message);
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\function\TEXT.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}