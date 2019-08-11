namespace Desktop.common.nomitech.common.bim
{
	public class BIMSpaceBoundary : BIMSpatialElement
	{
	  private const string SPACEBOUNDARY = "spaceboundary";

	  private double area;

	  private int areaQT;

	  public BIMSpaceBoundary()
	  {
		  GroupType = "spaceboundary";
	  }

	  public virtual double Area
	  {
		  get
		  {
			  return this.area;
		  }
		  set
		  {
			  this.area = value;
		  }
	  }


	  public virtual int AreaQT
	  {
		  get
		  {
			  return this.areaQT;
		  }
		  set
		  {
			  this.areaQT = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMSpaceBoundary.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}