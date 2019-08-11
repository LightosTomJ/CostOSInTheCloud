using System;

namespace Desktop.common.nomitech.common.expr.function
{
	using Expr = Desktop.common.org.boris.expr.Expr;
	using ExprDouble = Desktop.common.org.boris.expr.ExprDouble;
	using ExprError = Desktop.common.org.boris.expr.ExprError;
	using ExprException = Desktop.common.org.boris.expr.ExprException;
	using ExprNumber = Desktop.common.org.boris.expr.ExprNumber;
	using IEvaluationContext = Desktop.common.org.boris.expr.IEvaluationContext;
	using AbstractFunction = Desktop.common.org.boris.expr.function.AbstractFunction;
	using ExcelDate = Desktop.common.org.boris.expr.util.ExcelDate;

	public class DATE : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 3);
		Expr expr1 = evalArg(paramIEvaluationContext, paramArrayOfExpr[0]);
		if (!isNumber(expr1))
		{
		  return ExprError.VALUE;
		}
		double d1 = ((ExprNumber)expr1).doubleValue();
		Expr expr2 = evalArg(paramIEvaluationContext, paramArrayOfExpr[1]);
		if (!isNumber(expr2))
		{
		  return ExprError.VALUE;
		}
		double d2 = ((ExprNumber)expr2).doubleValue();
		Expr expr3 = evalArg(paramIEvaluationContext, paramArrayOfExpr[1]);
		if (!isNumber(expr3))
		{
		  return ExprError.VALUE;
		}
		double d3 = ((ExprNumber)expr3).doubleValue();
		double d4 = ExcelDate.date(d1, d2, d3);
		Console.WriteLine("Excel Date is: " + d1 + ", " + d2 + ", " + d3);
		Console.WriteLine("Excel Date is= " + d4);
		return (d4 < 0.0D) ? ExprError.NUM : new ExprDouble(d4);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\function\DATE.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}