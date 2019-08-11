namespace Desktop.common.nomitech.common.bim
{
	public class BIMBeam : BIMBuildingElement
	{
	  public const string BEAM = "beam";

	  private double length;

	  private int lengthQT;

	  private double width;

	  private int widthQT;

	  private double height;

	  private int heightQT;

	  private double bottomArea;

	  private int bottomAreaQT;

	  private double volume;

	  private int volumeQT;

	  public BIMBeam()
	  {
		  GroupType = "beam";
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


	  public virtual double CrossSectionWidth
	  {
		  get
		  {
			  return this.width;
		  }
		  set
		  {
			  this.width = value;
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
			  return this.height;
		  }
		  set
		  {
			  this.height = value;
		  }
	  }


	  public virtual int CrossSectionHeightQT
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


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMBeam.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}