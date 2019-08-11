using System;

namespace Desktop.common.nomitech.common.expr.function
{
	using TimeZoneUtil = Desktop.common.nomitech.common.util.TimeZoneUtil;
	using Expr = Desktop.common.org.boris.expr.Expr;
	using ExprDouble = Desktop.common.org.boris.expr.ExprDouble;
	using ExprException = Desktop.common.org.boris.expr.ExprException;
	using IEvaluationContext = Desktop.common.org.boris.expr.IEvaluationContext;
	using AbstractFunction = Desktop.common.org.boris.expr.function.AbstractFunction;
	using ExcelDate = Desktop.common.org.boris.expr.util.ExcelDate;

	public class NowLocal : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 0);
		try
		{
		  if (paramIEvaluationContext is nomitech.common.expr.ExprAbstractEvaluationContext)
		  {
			return new ExprDouble(ExcelDate.toExcelDate(TimeZoneUtil.getDateInLocalTimeZone(DateTime.Now).Ticks));
		  }
		}
		catch (Exception exception)
		{
		  throw new ExprException(exception.Message);
		}
		return null;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\function\NowLocal.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}