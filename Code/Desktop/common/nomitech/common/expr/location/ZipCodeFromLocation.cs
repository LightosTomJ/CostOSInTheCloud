namespace Desktop.common.nomitech.common.expr.location
{
	using Expr = org.boris.expr.Expr;
	using ExprException = org.boris.expr.ExprException;
	using ExprString = org.boris.expr.ExprString;
	using ExprVariable = org.boris.expr.ExprVariable;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ZipCodeFromLocation : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 1);
		if (paramArrayOfExpr[0] is ExprVariable)
		{
		  paramArrayOfExpr[0] = paramIEvaluationContext.evaluateVariable((ExprVariable)paramArrayOfExpr[0]);
		}
		if (!(paramArrayOfExpr[0] is ExprLocation))
		{
		  throw new ExprException("Input " + paramArrayOfExpr[0].ToString() + " is not a Location.");
		}
		ExprLocation exprLocation = (ExprLocation)paramArrayOfExpr[0];
		return new ExprString(exprLocation.ZipCode);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\location\ZipCodeFromLocation.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}