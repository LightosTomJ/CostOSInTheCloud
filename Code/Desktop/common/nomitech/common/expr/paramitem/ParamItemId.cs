using System;

namespace Desktop.common.nomitech.common.expr.paramitem
{
	using Expr = org.boris.expr.Expr;
	using ExprException = org.boris.expr.ExprException;
	using ExprInteger = org.boris.expr.ExprInteger;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ParamItemId : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 0);
		if (!(paramIEvaluationContext is ExprAbstractEvaluationContext))
		{
		  return ExprInteger.ZERO;
		}
		ExprAbstractEvaluationContext exprAbstractEvaluationContext = (ExprAbstractEvaluationContext)paramIEvaluationContext;
		if (exprAbstractEvaluationContext.UserObject == null || !(exprAbstractEvaluationContext.UserObject is Number))
		{
		  return ExprInteger.ZERO;
		}
		try
		{
		  long? long = exprAbstractEvaluationContext.UserObject;
		  return (long == null) ? ExprInteger.ZERO : new ExprInteger(long.Value);
		}
		catch (Exception)
		{
		  return ExprInteger.ZERO;
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\paramitem\ParamItemId.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}