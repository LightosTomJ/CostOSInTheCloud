namespace Desktop.common.nomitech.common.migration.rsmeans
{
	public class RSMeansCrewItem
	{
	  private string key;

	  private double quantity;

	  private string description;

	  private string code;

	  public RSMeansCrewItem(string paramString1, double paramDouble, string paramString2, string paramString3)
	  {
		this.key = paramString1;
		this.quantity = paramDouble;
		this.description = paramString2;
		this.code = paramString3;
	  }

	  public virtual string Key
	  {
		  get
		  {
			  return this.key;
		  }
		  set
		  {
			  this.key = value;
		  }
	  }


	  public virtual double Quantity
	  {
		  get
		  {
			  return this.quantity;
		  }
		  set
		  {
			  this.quantity = value;
		  }
	  }


	  public virtual string Description
	  {
		  get
		  {
			  return this.description;
		  }
		  set
		  {
			  this.description = value;
		  }
	  }


	  public virtual string Code
	  {
		  get
		  {
			  return this.code;
		  }
		  set
		  {
			  this.code = value;
		  }
	  }


	  public virtual bool Labor
	  {
		  get
		  {
			  return !(this.code.Length == 12);
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\rsmeans\RSMeansCrewItem.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}