namespace Desktop.common.nomitech.common.bim
{
	public class BIMFooting : BIMBuildingElement
	{
	  public const string FOOTING = "footing";

	  private double bottomArea;

	  private int bottomAreaQT;

	  private double volume;

	  private int volumeQT;

	  private double profHeight;

	  private int profHeightQT;

	  private double profWidth;

	  private int profWidthQT;

	  public BIMFooting()
	  {
		  GroupType = "footing";
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


	  public virtual double ProfHeight
	  {
		  get
		  {
			  return this.profHeight;
		  }
		  set
		  {
			  this.profHeight = value;
		  }
	  }


	  public virtual int ProfHeightQT
	  {
		  get
		  {
			  return this.profHeightQT;
		  }
		  set
		  {
			  this.profHeightQT = value;
		  }
	  }


	  public virtual double ProfWidth
	  {
		  get
		  {
			  return this.profWidth;
		  }
		  set
		  {
			  this.profWidth = value;
		  }
	  }


	  public virtual int ProfWidthQT
	  {
		  get
		  {
			  return this.profWidthQT;
		  }
		  set
		  {
			  this.profWidthQT = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMFooting.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}