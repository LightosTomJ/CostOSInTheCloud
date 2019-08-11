namespace Desktop.common.org.boris.expr.function.excel
{

	public class N : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 1);
		Expr expr = evalArg(paramIEvaluationContext, paramArrayOfExpr[0]);
		if (expr is ExprArray)
		{
		  ExprArray exprArray = (ExprArray)expr;
		  if (exprArray.length() == 0)
		  {
			return ExprDouble.ZERO;
		  }
		  expr = exprArray.get(0);
		}
		return (expr is ExprNumber) ? new ExprDouble(((ExprNumber)expr).doubleValue()) : ExprDouble.ZERO;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\org\boris\expr\function\excel\N.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}