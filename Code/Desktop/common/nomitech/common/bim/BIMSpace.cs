namespace Desktop.common.nomitech.common.bim
{
	public abstract class BIMSpace : BIMSpatialElement
	{
	  public const string SPACE = "space";

	  private double area;

	  private int areaQT;

	  private double areaOfDoors;

	  private int areaOfDoorsQT;

	  private double areaOfWindows;

	  private int areaOfWindowsQT;

	  private double height;

	  private int heightQT;

	  private double perimeter;

	  private int perimeterQT;

	  private double volume;

	  private int volumeQT;

	  public BIMSpace()
	  {
		  GroupType = "space";
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


	  public virtual double AreaOfDoors
	  {
		  get
		  {
			  return this.areaOfDoors;
		  }
		  set
		  {
			  this.areaOfDoors = value;
		  }
	  }


	  public virtual int AreaOfDoorsQT
	  {
		  get
		  {
			  return this.areaOfDoorsQT;
		  }
		  set
		  {
			  this.areaOfDoorsQT = value;
		  }
	  }


	  public virtual double AreaOfWindows
	  {
		  get
		  {
			  return this.areaOfWindows;
		  }
		  set
		  {
			  this.areaOfWindows = value;
		  }
	  }


	  public virtual int AreaOfWindowsQT
	  {
		  get
		  {
			  return this.areaOfWindowsQT;
		  }
		  set
		  {
			  this.areaOfWindowsQT = value;
		  }
	  }


	  public virtual double Height
	  {
		  get
		  {
			  return this.height;
		  }
		  set
		  {
			  this.height = value;
		  }
	  }


	  public virtual int HeightQT
	  {
		  get
		  {
			  return this.heightQT;
		  }
		  set
		  {
			  this.heightQT = value;
		  }
	  }


	  public virtual double Perimeter
	  {
		  get
		  {
			  return this.perimeter;
		  }
		  set
		  {
			  this.perimeter = value;
		  }
	  }


	  public virtual int PerimeterQT
	  {
		  get
		  {
			  return this.perimeterQT;
		  }
		  set
		  {
			  this.perimeterQT = value;
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

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMSpace.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}