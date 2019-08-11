namespace Desktop.common.nomitech.common.expr.project
{
	using Expr = org.boris.expr.Expr;
	using ExprException = org.boris.expr.ExprException;
	using ExprString = org.boris.expr.ExprString;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ProjectStringProperty : AbstractFunction
	{
	  private string key;

	  private string defValue;

	  public ProjectStringProperty(string paramString1, string paramString2)
	  {
		this.key = paramString1;
		this.defValue = paramString2;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 0);
		string str = this.defValue;
		if (ProjectDBUtil.currentProjectDBUtil() != null)
		{
		  str = ProjectDBUtil.currentProjectDBUtil().Properties.getProperty(this.key);
		}
		return new ExprString(str);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\project\ProjectStringProperty.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}