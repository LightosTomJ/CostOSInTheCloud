using System;

namespace Desktop.common.nomitech.common.expr.project
{
	using UILanguage = nomitech.common.ui.UILanguage;
	using StringUtils = nomitech.common.util.StringUtils;
	using Expr = org.boris.expr.Expr;
	using ExprException = org.boris.expr.ExprException;
	using ExprString = org.boris.expr.ExprString;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ProjectVariable : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 1);
		paramArrayOfExpr[0] = evalArg(paramIEvaluationContext, paramArrayOfExpr[0]);
		string str = asString(paramIEvaluationContext, paramArrayOfExpr[0], false);
		if (StringUtils.isNullOrBlank(str))
		{
		  throw new ExprException(UILanguage.get("databasetableformulabar.msg.var"));
		}
		object @object = null;
		try
		{
		  if (paramIEvaluationContext is ExprAbstractEvaluationContext)
		  {
			((ExprAbstractEvaluationContext)paramIEvaluationContext).addVariable(str);
			@object = ((ExprAbstractEvaluationContext)paramIEvaluationContext).getProjectVariableValue(str);
			if (@object is string)
			{
			  ((ExprAbstractEvaluationContext)paramIEvaluationContext).addVariable(str);
			  return new ExprString((string)@object);
			}
			if (@object is decimal)
			{
			  ((ExprAbstractEvaluationContext)paramIEvaluationContext).addVariable(str);
			  decimal bigDecimal = ((decimal)@object).setScale(4, RoundingMode.UP);
			  return new ExprString(bigDecimal.ToString());
			}
		  }
		  return new ExprString("-");
		}
		catch (Exception)
		{
		  return new ExprString("-");
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\project\ProjectVariable.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}