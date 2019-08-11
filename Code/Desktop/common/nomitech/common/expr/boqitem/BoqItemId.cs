using System;

namespace Desktop.common.nomitech.common.expr.boqitem
{
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprException = org.boris.expr.ExprException;
	using ExprInteger = org.boris.expr.ExprInteger;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class BoqItemId : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 0);
		ExprArray exprArray = new ExprArray(1, 1);
		exprArray.set(0, 0, new ExprInteger(0));
		if (!(paramIEvaluationContext is ExprAbstractEvaluationContext))
		{
		  return exprArray;
		}
		System.Collections.IList list = ((ExprAbstractEvaluationContext)paramIEvaluationContext).SelectedBoqItemIds;
		try
		{
		  if (list.Count == 0)
		  {
			return exprArray;
		  }
		  ExprArray exprArray1 = new ExprArray(list.Count, 1);
		  list.Sort();
		  for (sbyte b = 0; b < list.Count; b++)
		  {
			exprArray1.set(b, 0, new ExprInteger(((long?)list[b]).Value));
		  }
		  return exprArray1;
		}
		catch (Exception)
		{
		  return exprArray;
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\boqitem\BoqItemId.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}