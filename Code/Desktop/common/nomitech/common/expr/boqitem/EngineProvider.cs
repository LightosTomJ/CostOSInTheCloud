namespace Desktop.common.nomitech.common.expr.boqitem
{
	using Expr = org.boris.expr.Expr;
	using ExprException = org.boris.expr.ExprException;
	using ExprFunction = org.boris.expr.ExprFunction;
	using ExprVariable = org.boris.expr.ExprVariable;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;

	public interface EngineProvider
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void validate(org.boris.expr.ExprVariable paramExprVariable) throws org.boris.expr.ExprException;
	  void validate(ExprVariable paramExprVariable);

	  void inputChanged(Range paramRange, Expr paramExpr);

	  void valueChanged(Range paramRange, Expr paramExpr);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: org.boris.expr.Expr evaluateFunction(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.ExprFunction paramExprFunction) throws org.boris.expr.ExprException;
	  Expr evaluateFunction(IEvaluationContext paramIEvaluationContext, ExprFunction paramExprFunction);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: org.boris.expr.Expr evaluateVariable(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.ExprVariable paramExprVariable) throws org.boris.expr.ExprException;
	  Expr evaluateVariable(IEvaluationContext paramIEvaluationContext, ExprVariable paramExprVariable);
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\boqitem\EngineProvider.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}