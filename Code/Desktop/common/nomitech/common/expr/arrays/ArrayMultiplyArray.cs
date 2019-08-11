namespace Desktop.common.nomitech.common.expr.arrays
{
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprException = org.boris.expr.ExprException;
	using ExprInteger = org.boris.expr.ExprInteger;
	using ExprNumber = org.boris.expr.ExprNumber;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ArrayMultiplyArray : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertMinArgCount(paramArrayOfExpr, 2);
		ExprArray exprArray = null;
		foreach (Expr expr in paramArrayOfExpr)
		{
		  ExprArray exprArray1 = asArray(paramIEvaluationContext, expr, true);
		  if (exprArray == null)
		  {
			exprArray = exprArray1;
		  }
		  else
		  {
			exprArray = calcArrays(exprArray, exprArray1);
		  }
		}
		return exprArray;
	  }

	  private ExprArray calcArrays(ExprArray paramExprArray1, ExprArray paramExprArray2)
	  {
		int i = paramExprArray1.rows();
		int j = paramExprArray1.columns();
		int k = paramExprArray2.rows();
		int m = paramExprArray2.columns();
		ExprArray exprArray = new ExprArray(i, j);
		for (sbyte b = 0; b < i; b++)
		{
		  for (sbyte b1 = 0; b1 < j; b1++)
		  {
			Expr expr = paramExprArray1.get(b, b1);
			if (!expr.evaluatable && expr is ExprNumber && b < k && b1 < m)
			{
			  Expr expr1 = paramExprArray2.get(b, b1);
			  if (!expr1.evaluatable && expr1 is ExprNumber)
			  {
				ExprNumber exprNumber1 = (ExprNumber)expr;
				ExprNumber exprNumber2 = (ExprNumber)expr1;
				if (exprNumber1 is ExprDouble)
				{
				  exprArray.set(b, b1, new ExprDouble(exprNumber1.doubleValue() * exprNumber2.doubleValue()));
				}
				else
				{
				  exprArray.set(b, b1, new ExprInteger(exprNumber1.intValue() * exprNumber2.intValue()));
				}
			  }
			}
			else
			{
			  exprArray.set(b, b1, expr);
			}
		  }
		}
		return exprArray;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\ArrayMultiplyArray.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}