namespace Desktop.common.nomitech.common.bim
{
	public class BIMRoof : BIMBuildingElement
	{
	  public const string ROOF = "roof";

	  private double area;

	  private int areaQT;

	  private double grossArea;

	  private int grossAreaQT;

	  private double perimeter;

	  private int perimeterQT;

	  private double thickness;

	  private int thicknessQT;

	  private double volume;

	  private int volumeQT;

	  private double angle;

	  private int angleQT;

	  public BIMRoof()
	  {
		  GroupType = "roof";
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


	  public virtual double Angle
	  {
		  get
		  {
			  return this.angle;
		  }
		  set
		  {
			  this.angle = value;
		  }
	  }


	  public virtual int AngleQT
	  {
		  get
		  {
			  return this.angleQT;
		  }
		  set
		  {
			  this.angleQT = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMRoof.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}