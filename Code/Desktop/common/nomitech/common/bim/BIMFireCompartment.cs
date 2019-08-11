namespace Desktop.common.nomitech.common.bim
{
	public abstract class BIMFireCompartment : BIMSpatialElement
	{
	  private const string FIRECOMPARTMENT = "firecompartment";

	  private double area;

	  private int areaQT;

	  private double height;

	  private int heightQT;

	  private double volume;

	  private int volumeQT;

	  private bool sprinklered;

	  private string useClass;

	  public virtual bool Sprinklered
	  {
		  get
		  {
			  return this.sprinklered;
		  }
		  set
		  {
			  this.sprinklered = value;
		  }
	  }


	  public virtual string UseClass
	  {
		  get
		  {
			  return this.useClass;
		  }
		  set
		  {
			  this.useClass = value;
		  }
	  }


	  public BIMFireCompartment()
	  {
		  GroupType = "firecompartment";
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


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMFireCompartment.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}