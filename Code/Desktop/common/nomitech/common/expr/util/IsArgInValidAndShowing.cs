namespace Desktop.common.nomitech.common.expr.util
{
	using Expr = org.boris.expr.Expr;
	using ExprBoolean = org.boris.expr.ExprBoolean;
	using ExprException = org.boris.expr.ExprException;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class IsArgInValidAndShowing : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 1);
		if (!(paramArrayOfExpr[0] is org.boris.expr.ExprString))
		{
		  throw new ExprException("Input " + paramArrayOfExpr[0].ToString() + " is not a String.");
		}
		if (paramIEvaluationContext is ExprAbstractEvaluationContext)
		{
		  ExprAbstractEvaluationContext exprAbstractEvaluationContext = (ExprAbstractEvaluationContext)paramIEvaluationContext;
		  return new ExprBoolean((exprAbstractEvaluationContext.isVariableShowing(paramArrayOfExpr[0].ToString()) && exprAbstractEvaluationContext.isVariableValid(paramArrayOfExpr[0].ToString())));
		}
		return new ExprBoolean(true);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\exp\\util\IsArgInValidAndShowing.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}