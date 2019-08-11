using System;

namespace Desktop.common.nomitech.common.expr.project
{
	using ProjectUrlTable = nomitech.common.db.local.ProjectUrlTable;
	using Expr = org.boris.expr.Expr;
	using ExprException = org.boris.expr.ExprException;
	using ExprString = org.boris.expr.ExprString;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ProjectDatabaseName : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 0);
		try
		{
		  string str = null;
		  if (paramIEvaluationContext is ExprAbstractEvaluationContext)
		  {
			ProjectUrlTable projectUrlTable = ((ExprAbstractEvaluationContext)paramIEvaluationContext).ProjectUrlTable;
			if (projectUrlTable != null)
			{
			  str = projectUrlTable.DatabaseName;
			}
			else if (string.ReferenceEquals(str, null))
			{
			  str = ((ProjectServerDBUtil)ProjectDBUtil.currentProjectDBUtil()).ProjectUrl.DatabaseName;
			}
		  }
		  return (string.ReferenceEquals(str, null)) ? new ExprString("") : new ExprString(str);
		}
		catch (Exception)
		{
		  return new ExprString("-");
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\project\ProjectDatabaseName.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}