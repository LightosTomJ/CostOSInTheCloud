namespace Desktop.common.nomitech.common.expr.arrays
{
	using ExprArray = org.boris.expr.ExprArray;

	public class ExprArrayWithHeader : ExprArray
	{
	  private string[] columnNames;

	  public ExprArrayWithHeader(string[] paramArrayOfString, int paramInt1, int paramInt2) : base(paramInt1, paramInt2)
	  {
		this.columnNames = paramArrayOfString;
	  }

	  public virtual string[] Columns
	  {
		  get
		  {
			  return this.columnNames;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\ExprArrayWithHeader.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}