namespace Desktop.common.nomitech.common.expr.util
{
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using Unit1ToUnit2Util = nomitech.common.util.Unit1ToUnit2Util;
	using Expr = org.boris.expr.Expr;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprException = org.boris.expr.ExprException;
	using ExprVariable = org.boris.expr.ExprVariable;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class Unit1ToUnit2Div : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 1);
		string str = null;
		if (paramArrayOfExpr[0] is org.boris.expr.ExprString)
		{
		  str = paramArrayOfExpr[0].ToString();
		}
		else if (paramArrayOfExpr[0] is ExprVariable)
		{
		  ExprVariable exprVariable = (ExprVariable)paramArrayOfExpr[0];
		  Expr expr = paramIEvaluationContext.evaluateVariable(exprVariable);
		  if (!(expr is org.boris.expr.ExprString))
		  {
			throw new ExprException("Input " + paramArrayOfExpr[0].ToString() + " is not a String");
		  }
		  str = expr.ToString();
		}
		else
		{
		  throw new ExprException("Input " + paramArrayOfExpr[0].ToString() + " is not a String");
		}
		decimal bigDecimal = Unit1ToUnit2Util.Instance.getUnitDiv(str);
		if (bigDecimal == null)
		{
		  bigDecimal = BigDecimalMath.ZERO;
		}
		return new ExprDouble(bigDecimal.doubleValue());
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\exp\\util\Unit1ToUnit2Div.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}