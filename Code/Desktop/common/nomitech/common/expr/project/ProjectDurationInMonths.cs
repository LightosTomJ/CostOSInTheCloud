using System;

namespace Desktop.common.nomitech.common.expr.project
{
	using ProjectUrlTable = nomitech.common.db.local.ProjectUrlTable;
	using Expr = org.boris.expr.Expr;
	using ExprException = org.boris.expr.ExprException;
	using ExprInteger = org.boris.expr.ExprInteger;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ProjectDurationInMonths : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 0);
		try
		{
		  int? integer = null;
		  if (paramIEvaluationContext is ExprAbstractEvaluationContext)
		  {
			ProjectUrlTable projectUrlTable = ((ExprAbstractEvaluationContext)paramIEvaluationContext).ProjectUrlTable;
			if (projectUrlTable != null)
			{
			  integer = projectUrlTable.ProjectInfoTable.PaymentDuration;
			}
			else if (integer == null)
			{
			  integer = Convert.ToInt32(ProjectDBUtil.currentProjectDBUtil().Properties.getIntProperty("project.constructionduration"));
			}
		  }
		  return (integer == null) ? new ExprInteger(1) : new ExprInteger(integer.Value);
		}
		catch (Exception)
		{
		  return new ExprInteger(1);
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\project\ProjectDurationInMonths.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}