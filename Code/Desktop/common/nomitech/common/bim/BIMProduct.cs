namespace Desktop.common.nomitech.common.bim
{
	public class BIMProduct
	{
	  private int bottomElevationQT;

	  private int topElevationQT;

	  private string bimToolId;

	  private double bottomElevation;

	  private double topElevation;

	  private string globalId;

	  public virtual string BimToolId
	  {
		  get
		  {
			  return this.bimToolId;
		  }
		  set
		  {
			  this.bimToolId = value;
		  }
	  }


	  public virtual double BottomElevation
	  {
		  get
		  {
			  return this.bottomElevation;
		  }
		  set
		  {
			  this.bottomElevation = value;
		  }
	  }


	  public virtual double TopElevation
	  {
		  get
		  {
			  return this.topElevation;
		  }
		  set
		  {
			  this.topElevation = value;
		  }
	  }


	  public virtual string GlobalId
	  {
		  get
		  {
			  return this.globalId;
		  }
		  set
		  {
			  this.globalId = value;
		  }
	  }


	  public virtual int BottomElevationQT
	  {
		  get
		  {
			  return this.bottomElevationQT;
		  }
		  set
		  {
			  this.bottomElevationQT = value;
		  }
	  }


	  public virtual int TopElevationQT
	  {
		  get
		  {
			  return this.topElevationQT;
		  }
		  set
		  {
			  this.topElevationQT = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMProduct.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}