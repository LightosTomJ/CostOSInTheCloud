using System;

namespace Desktop.common.nomitech.common.expr.util
{
	using Expr = org.boris.expr.Expr;
	using ExprException = org.boris.expr.ExprException;
	using ExprString = org.boris.expr.ExprString;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;
	using ExcelDate = org.boris.expr.util.ExcelDate;

	public class FormatDateToText : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 2);
		double d = asDouble(paramIEvaluationContext, paramArrayOfExpr[0], true);
		SimpleDateFormat simpleDateFormat = new SimpleDateFormat(asString(paramIEvaluationContext, paramArrayOfExpr[1], true));
		string str = simpleDateFormat.format(Convert.ToInt64(ExcelDate.toJavaDate(d)));
		return new ExprString(str);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\exp\\util\FormatDateToText.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}