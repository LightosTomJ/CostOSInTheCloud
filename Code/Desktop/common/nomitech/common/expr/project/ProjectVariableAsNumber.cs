using System;

namespace Desktop.common.nomitech.common.expr.project
{
	using UILanguage = nomitech.common.ui.UILanguage;
	using StringUtils = nomitech.common.util.StringUtils;
	using Expr = org.boris.expr.Expr;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprException = org.boris.expr.ExprException;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ProjectVariableAsNumber : AbstractFunction
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
			  try
			  {
				decimal bigDecimal = (new decimal((string)@object)).setScale(4, RoundingMode.UP);
				return new ExprDouble(bigDecimal.doubleValue());
			  }
			  catch (Exception)
			  {
				return new ExprDouble(0.0D);
			  }
			}
			if (@object is decimal)
			{
			  decimal bigDecimal = ((decimal)@object).setScale(4, RoundingMode.UP);
			  return new ExprDouble(bigDecimal.doubleValue());
			}
		  }
		  return new ExprDouble(0.0D);
		}
		catch (Exception)
		{
		  return new ExprDouble(0.0D);
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\project\ProjectVariableAsNumber.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}