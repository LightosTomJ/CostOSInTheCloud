namespace Desktop.common.nomitech.common.expr.boqitem
{
	using ExprException = org.boris.expr.ExprException;
	using Reflect = org.boris.expr.util.Reflect;

	public class Range
	{
	  private string dim1Name;

	  public Range(string paramString)
	  {
		  this.dim1Name = paramString;
	  }

	  public virtual bool Array
	  {
		  get
		  {
			  return false;
		  }
	  }

	  public virtual string Dimension1Name
	  {
		  get
		  {
			  return this.dim1Name;
		  }
	  }

	  public override int GetHashCode()
	  {
		  return this.dim1Name.GetHashCode();
	  }

	  public override bool Equals(object paramObject)
	  {
		if (!(paramObject is Range))
		{
		  return false;
		}
		Range range = (Range)paramObject;
		return !!Reflect.Equals(range.dim1Name, this.dim1Name);
	  }

	  public override string ToString()
	  {
		  return this.dim1Name;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static Range valueOf(String paramString) throws org.boris.expr.ExprException
	  public static Range valueOf(string paramString)
	  {
		  return new Range(paramString);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\boqitem\Range.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}