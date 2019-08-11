using System;

namespace Desktop.common.nomitech.common.expr.util
{
	using Expr = org.boris.expr.Expr;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprException = org.boris.expr.ExprException;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;
	using ExcelDate = org.boris.expr.util.ExcelDate;

	public class FormatTextToDate : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 2);
		Expr expr1 = evalArg(paramIEvaluationContext, paramArrayOfExpr[0]);
		Expr expr2 = evalArg(paramIEvaluationContext, paramArrayOfExpr[1]);
		SimpleDateFormat simpleDateFormat = new SimpleDateFormat(asString(paramIEvaluationContext, expr2, true));
		try
		{
		  DateTime date = simpleDateFormat.parse(asString(paramIEvaluationContext, expr1, true));
		  return new ExprDouble(ExcelDate.toExcelDate(date.Ticks));
		}
		catch (ParseException parseException)
		{
		  Console.WriteLine(parseException.ToString());
		  Console.Write(parseException.StackTrace);
		  return new ExprDouble(-1.0D);
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\exp\\util\FormatTextToDate.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}