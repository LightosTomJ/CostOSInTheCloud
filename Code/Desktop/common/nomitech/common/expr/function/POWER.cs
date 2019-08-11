using System;

namespace Desktop.common.nomitech.common.expr.function
{
	using Expr = Desktop.common.org.boris.expr.Expr;
	using ExprDouble = Desktop.common.org.boris.expr.ExprDouble;
	using ExprException = Desktop.common.org.boris.expr.ExprException;
	using IEvaluationContext = Desktop.common.org.boris.expr.IEvaluationContext;
	using AbstractFunction = Desktop.common.org.boris.expr.function.AbstractFunction;

	public class POWER : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 2);
		double d1 = asDouble(paramIEvaluationContext, paramArrayOfExpr[0], true);
		double d2 = asDouble(paramIEvaluationContext, paramArrayOfExpr[1], true);
		return new ExprDouble(pow(d1, d2));
	  }

	  public static double pow(double paramDouble1, double paramDouble2)
	  {
		  return (paramDouble1 < 0.0D) ? Math.Pow(Math.Abs(paramDouble1), paramDouble2) : Math.Pow(paramDouble1, paramDouble2);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\function\POWER.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}