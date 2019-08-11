namespace Desktop.common.nomitech.common.bim
{
	public abstract class BIMWall : BIMBuildingElement
	{
	  public const string WALL = "wall";

	  private double area;

	  private int areaQT;

	  private double grossArea;

	  private int grossAreaQT;

	  private double areaOfDoors;

	  private int areaOfDoorsQT;

	  private double areaOfOpenings;

	  private int areaOfOpeningsQT;

	  private double areaOfWindows;

	  private int areaOfWindowsQT;

	  private double bottomArea;

	  private int bottomAreaQT;

	  private double height;

	  private int heightQT;

	  private double length;

	  private int lengthQT;

	  private double thickness;

	  private int thicknessQT;

	  private double volume;

	  private int volumeQT;

	  private bool external = false;

	  public BIMWall()
	  {
		  GroupType = "wall";
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


	  public virtual double GrossArea
	  {
		  get
		  {
			  return this.grossArea;
		  }
		  set
		  {
			  this.grossArea = value;
		  }
	  }


	  public virtual int GrossAreaQT
	  {
		  get
		  {
			  return this.grossAreaQT;
		  }
		  set
		  {
			  this.grossAreaQT = value;
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


	  public virtual double AreaOfOpenings
	  {
		  get
		  {
			  return this.areaOfOpenings;
		  }
		  set
		  {
			  this.areaOfOpenings = value;
		  }
	  }


	  public virtual int AreaOfOpeningsQT
	  {
		  get
		  {
			  return this.areaOfOpeningsQT;
		  }
		  set
		  {
			  this.areaOfOpeningsQT = value;
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


	  public virtual double BottomArea
	  {
		  get
		  {
			  return this.bottomArea;
		  }
		  set
		  {
			  this.bottomArea = value;
		  }
	  }


	  public virtual int BottomAreaQT
	  {
		  get
		  {
			  return this.bottomAreaQT;
		  }
		  set
		  {
			  this.bottomAreaQT = value;
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


	  public virtual bool External
	  {
		  get
		  {
			  return this.external;
		  }
		  set
		  {
			  this.external = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMWall.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}