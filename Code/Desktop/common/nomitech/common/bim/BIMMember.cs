namespace Desktop.common.nomitech.common.bim
{
	public class BIMMember : BIMBuildingElement
	{
	  public const string MEMBER = "member";

	  private double area;

	  private int areaQT;

	  private double length;

	  private int lengthQT;

	  public BIMMember()
	  {
		  GroupType = "member";
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


	  public virtual double Length
	  {
		  get
		  {
			  return this.length;
		  }
		  set
		  {
			  this.length = value;
		  }
	  }


	  public virtual int LengthQT
	  {
		  get
		  {
			  return this.lengthQT;
		  }
		  set
		  {
			  this.lengthQT = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMMember.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}