using System;

namespace Desktop.common.nomitech.common.expr.project.variables
{
	using Expr = org.boris.expr.Expr;
	using ExprException = org.boris.expr.ExprException;
	using ExprString = org.boris.expr.ExprString;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class SheetValueAt : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 4);
		paramArrayOfExpr[0] = evalArg(paramIEvaluationContext, paramArrayOfExpr[0]);
		paramArrayOfExpr[1] = evalArg(paramIEvaluationContext, paramArrayOfExpr[1]);
		paramArrayOfExpr[2] = evalArg(paramIEvaluationContext, paramArrayOfExpr[2]);
		paramArrayOfExpr[3] = evalArg(paramIEvaluationContext, paramArrayOfExpr[3]);
		string str1 = asString(paramIEvaluationContext, paramArrayOfExpr[0], false);
		int i = asInteger(paramIEvaluationContext, paramArrayOfExpr[1], false);
		int j = asInteger(paramIEvaluationContext, paramArrayOfExpr[2], false);
		string str2 = asString(paramIEvaluationContext, paramArrayOfExpr[3], false);
		try
		{
		  return (paramIEvaluationContext is ExprAbstractEvaluationContext) ? new ExprString(((ExprAbstractEvaluationContext)paramIEvaluationContext).sheetValueAt(str1, i, j, str2)) : new ExprString(str2);
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  return new ExprString(str2);
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\project\variables\SheetValueAt.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}