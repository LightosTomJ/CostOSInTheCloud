namespace Desktop.common.nomitech.common.expr.arrays
{
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprException = org.boris.expr.ExprException;
	using ExprString = org.boris.expr.ExprString;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ArrayFromText : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertMinArgCount(paramArrayOfExpr, 2);
		assertMaxArgCount(paramArrayOfExpr, 2);
		if ((paramArrayOfExpr[0]).evaluatable)
		{
		  paramArrayOfExpr[0] = evalArg(paramIEvaluationContext, paramArrayOfExpr[0]);
		}
		if ((paramArrayOfExpr[1]).evaluatable)
		{
		  paramArrayOfExpr[1] = evalArg(paramIEvaluationContext, paramArrayOfExpr[1]);
		}
		string str1 = asString(paramIEvaluationContext, paramArrayOfExpr[0], false);
		string str2 = asString(paramIEvaluationContext, paramArrayOfExpr[1], false);
		string[] arrayOfString = str1.Split(str2, true);
		ExprArray exprArray = new ExprArray(arrayOfString.Length, 1);
		sbyte b = 0;
		foreach (string str in arrayOfString)
		{
		  exprArray.set(b++, new ExprString(str));
		}
		return exprArray;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\ArrayFromText.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}