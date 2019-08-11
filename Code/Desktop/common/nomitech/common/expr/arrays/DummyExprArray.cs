namespace Desktop.common.nomitech.common.expr.arrays
{
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprInteger = org.boris.expr.ExprInteger;

	public class DummyExprArray : ExprArray
	{
	  public DummyExprArray() : base(1, 1)
	  {
	  }

	  public virtual void set(int paramInt, Expr paramExpr)
	  {
	  }

	  public virtual void set(int paramInt1, int paramInt2, Expr paramExpr)
	  {
	  }

	  public virtual Expr get(int paramInt1, int paramInt2)
	  {
		  return new ExprInteger(1);
	  }

	  public virtual Expr get(int paramInt)
	  {
		  return new ExprInteger(1);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\DummyExprArray.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}