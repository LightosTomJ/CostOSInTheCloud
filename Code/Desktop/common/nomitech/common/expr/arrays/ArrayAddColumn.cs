namespace Desktop.common.nomitech.common.expr.arrays
{
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprException = org.boris.expr.ExprException;
	using ExprInteger = org.boris.expr.ExprInteger;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ArrayAddColumn : AbstractFunction
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
			exprArray = addColumnToArray(exprArray, exprArray1);
		  }
		}
		return exprArray;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.boris.expr.ExprArray addColumnToArray(org.boris.expr.ExprArray paramExprArray1, org.boris.expr.ExprArray paramExprArray2) throws org.boris.expr.ExprException
	  private ExprArray addColumnToArray(ExprArray paramExprArray1, ExprArray paramExprArray2)
	  {
		int i = paramExprArray1.rows();
		int j = paramExprArray1.columns() + paramExprArray2.columns();
		ExprArray exprArray = new ExprArray(i, j);
		for (sbyte b = 0; b < i; b++)
		{
		  for (int k = 0; k < j; k++)
		  {
			ExprInteger exprInteger = null;
			if (k < paramExprArray1.columns())
			{
			  exprInteger = paramExprArray1.get(b, k);
			}
			else
			{
			  int m = k - paramExprArray1.columns();
			  if (b < paramExprArray2.rows() && m < paramExprArray2.columns())
			  {
				exprInteger = paramExprArray2.get(b, m);
			  }
			  else
			  {
				exprInteger = new ExprInteger(0);
			  }
			}
			exprArray.set(b, k, exprInteger);
		  }
		}
		return exprArray;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\ArrayAddColumn.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}