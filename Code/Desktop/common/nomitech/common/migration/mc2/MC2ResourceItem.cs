namespace Desktop.common.nomitech.common.migration.mc2
{

	public class MC2ResourceItem
	{
	  private string resourceCode;

	  private string resourceUom;

	  private decimal resourceFactor;

	  public MC2ResourceItem(string paramString1, string paramString2, decimal paramBigDecimal)
	  {
		this.resourceCode = paramString1;
		this.resourceUom = paramString2;
		this.resourceFactor = paramBigDecimal;
	  }

	  public virtual string ResourceCode
	  {
		  get
		  {
			  return this.resourceCode;
		  }
		  set
		  {
			  this.resourceCode = value;
		  }
	  }


	  public virtual string ResourceUom
	  {
		  get
		  {
			  return this.resourceUom;
		  }
		  set
		  {
			  this.resourceUom = value;
		  }
	  }


	  public virtual decimal ResourceFactor
	  {
		  get
		  {
			  return this.resourceFactor;
		  }
		  set
		  {
			  this.resourceFactor = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\mc2\MC2ResourceItem.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}