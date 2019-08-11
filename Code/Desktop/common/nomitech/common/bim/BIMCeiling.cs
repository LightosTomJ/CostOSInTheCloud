namespace Desktop.common.nomitech.common.bim
{
	public class BIMCeiling : BIMBuildingElement
	{
	  public const string CEILING = "ceiling";

	  private double area;

	  private int areaQT;

	  private double volume;

	  private int volumeQT;

	  private double thickness;

	  private int thicknessQT;

	  public BIMCeiling()
	  {
		  GroupType = "ceiling";
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


	  public virtual double Volume
	  {
		  get
		  {
			  return this.volume;
		  }
		  set
		  {
			  this.volume = value;
		  }
	  }


	  public virtual int VolumeQT
	  {
		  get
		  {
			  return this.volumeQT;
		  }
		  set
		  {
			  this.volumeQT = value;
		  }
	  }


	  public virtual double Thickness
	  {
		  get
		  {
			  return this.thickness;
		  }
		  set
		  {
			  this.thickness = value;
		  }
	  }


	  public virtual int ThicknessQT
	  {
		  get
		  {
			  return this.thicknessQT;
		  }
		  set
		  {
			  this.thicknessQT = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMCeiling.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}