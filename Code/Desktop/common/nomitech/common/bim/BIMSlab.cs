namespace Desktop.common.nomitech.common.bim
{
	public abstract class BIMSlab : BIMBuildingElement
	{
	  public const string SLAB = "slab";

	  private double area;

	  private int areaQT;

	  private double grossArea;

	  private int grossAreaQT;

	  private double areaOfOpenings;

	  private int areaOfOpeningsQT;

	  private double perimeter;

	  private int perimeterQT;

	  private double perimeterOfOpenings;

	  private int perimeterOfOpeningsQT;

	  private double thickness;

	  private int thicknessQT;

	  private double volume;

	  private int volumeQT;

	  public BIMSlab()
	  {
		  GroupType = "slab";
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


	  public virtual double PerimeterOfOpenings
	  {
		  get
		  {
			  return this.perimeterOfOpenings;
		  }
		  set
		  {
			  this.perimeterOfOpenings = value;
		  }
	  }


	  public virtual int PerimeterOfOpeningsQT
	  {
		  get
		  {
			  return this.perimeterOfOpeningsQT;
		  }
		  set
		  {
			  this.perimeterOfOpeningsQT = value;
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

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMSlab.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}