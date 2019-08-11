namespace Desktop.common.nomitech.common.expr.boqitem
{
	using BoqItemTable = nomitech.common.db.project.BoqItemTable;
	using Expr = org.boris.expr.Expr;
	using ExprException = org.boris.expr.ExprException;
	using ExprFunction = org.boris.expr.ExprFunction;
	using ExprVariable = org.boris.expr.ExprVariable;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;

	public class BoqItemEngineProvider : EngineProvider
	{
	  protected internal ExprExcelFunctionProvider exfp = new ExprExcelFunctionProvider();

	  protected internal ExprDBFunctionProvider dbfp = ExprDBFunctionProvider.getInstance(false);

	  protected internal BoqItemTable table;

	  public BoqItemEngineProvider(BoqItemTable paramBoqItemTable)
	  {
		  this.table = paramBoqItemTable;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluateFunction(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.ExprFunction paramExprFunction) throws org.boris.expr.ExprException
	  public virtual Expr evaluateFunction(IEvaluationContext paramIEvaluationContext, ExprFunction paramExprFunction)
	  {
		if (this.exfp.hasFunction(paramExprFunction))
		{
		  return this.exfp.evaluate(paramIEvaluationContext, paramExprFunction);
		}
		if (this.dbfp.hasFunction(paramExprFunction))
		{
		  return this.dbfp.evaluate(paramIEvaluationContext, paramExprFunction);
		}
		throw new ExprException("Function " + paramExprFunction + " not supported");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluateVariable(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.ExprVariable paramExprVariable) throws org.boris.expr.ExprException
	  public virtual Expr evaluateVariable(IEvaluationContext paramIEvaluationContext, ExprVariable paramExprVariable)
	  {
		  return paramExprVariable.evaluate(paramIEvaluationContext);
	  }

	  public virtual void inputChanged(Range paramRange, Expr paramExpr)
	  {
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void validate(org.boris.expr.ExprVariable paramExprVariable) throws org.boris.expr.ExprException
	  public virtual void validate(ExprVariable paramExprVariable)
	  {
	  }

	  public virtual void valueChanged(Range paramRange, Expr paramExpr)
	  {
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\boqitem\BoqItemEngineProvider.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}