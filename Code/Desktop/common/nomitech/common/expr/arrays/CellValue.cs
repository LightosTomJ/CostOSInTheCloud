namespace Desktop.common.nomitech.common.expr.arrays
{
	using Expr = org.boris.expr.Expr;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprException = org.boris.expr.ExprException;
	using ExprInteger = org.boris.expr.ExprInteger;
	using ExprString = org.boris.expr.ExprString;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class CellValue : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 1);
		int i = asInteger(paramIEvaluationContext, paramArrayOfExpr[0], true);
		if (paramIEvaluationContext is ExprAbstractEvaluationContext)
		{
		  ExprAbstractEvaluationContext exprAbstractEvaluationContext = (ExprAbstractEvaluationContext)paramIEvaluationContext;
		  object[] arrayOfObject = exprAbstractEvaluationContext.CurrentRow;
		  if (arrayOfObject != null)
		  {
			if (arrayOfObject.Length < i || i <= 0)
			{
			  throw new ExprException("The array has " + arrayOfObject.Length + " columns, invalid column index " + i + " for CellValue");
			}
			object @object = arrayOfObject[i - 1];
			return (@object is Number) ? new ExprDouble(((Number)@object).doubleValue()) : new ExprString(@object.ToString());
		  }
		}
		return new ExprInteger(1);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\CellValue.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}