namespace Desktop.common.nomitech.common.parsing
{
	public class BaseOperator
	{
	  private readonly string symbol;

	  private readonly bool rightAssociative;

	  private readonly int precedence;

	  public BaseOperator(string paramString, bool paramBoolean, int paramInt)
	  {
		this.symbol = paramString;
		this.rightAssociative = paramBoolean;
		this.precedence = paramInt;
	  }

	  public virtual bool RightAssociative
	  {
		  get
		  {
			  return this.rightAssociative;
		  }
	  }

	  public virtual int comparePrecedence(BaseOperator paramBaseOperator)
	  {
		if (paramBaseOperator is BaseOperator)
		{
		  BaseOperator baseOperator = paramBaseOperator;
		  return (this.precedence > baseOperator.precedence) ? 1 : ((baseOperator.precedence == this.precedence) ? 0 : -1);
		}
		return -paramBaseOperator.comparePrecedence(this);
	  }

	  public virtual string Symbol
	  {
		  get
		  {
			  return this.symbol;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\parsing\BaseOperator.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}