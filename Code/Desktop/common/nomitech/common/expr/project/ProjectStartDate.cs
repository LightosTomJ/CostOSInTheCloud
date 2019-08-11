using System;

namespace Desktop.common.nomitech.common.expr.project
{
	using ProjectUrlTable = nomitech.common.db.local.ProjectUrlTable;
	using Expr = org.boris.expr.Expr;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprException = org.boris.expr.ExprException;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;
	using ExcelDate = org.boris.expr.util.ExcelDate;

	public class ProjectStartDate : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 0);
		DateTime date = null;
		try
		{
		  if (paramIEvaluationContext is ExprAbstractEvaluationContext)
		  {
			ProjectUrlTable projectUrlTable = ((ExprAbstractEvaluationContext)paramIEvaluationContext).ProjectUrlTable;
			if (projectUrlTable != null)
			{
			  date = projectUrlTable.ProjectInfoTable.SubmissionDate;
			}
			else if (date == null)
			{
			  date = ProjectDBUtil.currentProjectDBUtil().Properties.getDateProperty("project.submission.date");
			}
		  }
		  return (date == null) ? new ExprDouble(ExcelDate.toExcelDate((DateTime.Now).Ticks)) : new ExprDouble(ExcelDate.toExcelDate(date.Ticks));
		}
		catch (Exception)
		{
		  return new ExprDouble(ExcelDate.toExcelDate(date.Ticks));
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\project\ProjectStartDate.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}