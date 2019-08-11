namespace Desktop.common.nomitech.common.bim
{
	public class BIMColumn : BIMBuildingElement
	{
	  public const string COLUMN = "column";

	  private double height;

	  private int heightQT;

	  private double crossSectionWidth;

	  private int widthQT;

	  private double crossSectionHeight;

	  private int crossSectionHeightQT;

	  private double bottomArea;

	  private int bottomAreaQT;

	  private double volume;

	  private int volumeQT;

	  private double diameter;

	  private int diameterQT;

	  private double skinArea;

	  private int skinAreaQT;

	  public BIMColumn()
	  {
		  GroupType = "column";
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


	  public virtual double CrossSectionWidth
	  {
		  get
		  {
			  return this.crossSectionWidth;
		  }
		  set
		  {
			  this.crossSectionWidth = value;
		  }
	  }


	  public virtual int CrossSectionWidthQT
	  {
		  get
		  {
			  return this.widthQT;
		  }
		  set
		  {
			  this.widthQT = value;
		  }
	  }


	  public virtual double CrossSectionHeight
	  {
		  get
		  {
			  return this.crossSectionHeight;
		  }
		  set
		  {
			  this.crossSectionHeight = value;
		  }
	  }


	  public virtual int CrossSectionHeightQT
	  {
		  get
		  {
			  return this.crossSectionHeightQT;
		  }
		  set
		  {
			  this.crossSectionHeightQT = value;
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


	  public virtual double Diameter
	  {
		  get
		  {
			  return this.diameter;
		  }
		  set
		  {
			  this.diameter = value;
		  }
	  }


	  public virtual int DiameterQT
	  {
		  get
		  {
			  return this.diameterQT;
		  }
		  set
		  {
			  this.diameterQT = value;
		  }
	  }


	  public virtual double SkinArea
	  {
		  get
		  {
			  return this.skinArea;
		  }
		  set
		  {
			  this.skinArea = value;
		  }
	  }


	  public virtual int SkinAreaQT
	  {
		  get
		  {
			  return this.skinAreaQT;
		  }
		  set
		  {
			  this.skinAreaQT = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMColumn.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}