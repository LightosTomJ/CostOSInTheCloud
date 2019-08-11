using System;

namespace Desktop.common.nomitech.common.expr.arrays
{
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprException = org.boris.expr.ExprException;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ArrayTitle : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertMinArgCount(paramArrayOfExpr, 2);
		ExprArray exprArray1 = asArray(paramIEvaluationContext, paramArrayOfExpr[0], true);
		int? integer1;
		int? integer2 = (integer2 = (integer1 = Convert.ToInt32(paramArrayOfExpr.Length - 1)).valueOf(exprArray1.rows() * exprArray1.columns() / integer1.Value)).valueOf(integer2.Value + 1);
		ExprArray exprArray2 = new ExprArray(integer2.Value, integer1.Value);
		try
		{
		  sbyte b;
		  for (b = 0; b < integer1.Value; b++)
		  {
			exprArray2.set(0, b, paramArrayOfExpr[b + true]);
		  }
		  for (b = 1; b < integer2.Value; b++)
		  {
			for (sbyte b1 = 0; b1 < integer1.Value; b1++)
			{
			  if (b - 1 < exprArray1.rows() && b1 < exprArray1.columns())
			  {
				Expr expr = exprArray1.get(b - 1, b1);
				exprArray2.set(b, b1, expr);
			  }
			}
		  }
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		return exprArray2;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\ArrayTitle.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}