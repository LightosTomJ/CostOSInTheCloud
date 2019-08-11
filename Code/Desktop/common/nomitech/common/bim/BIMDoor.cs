namespace Desktop.common.nomitech.common.bim
{
	public class BIMDoor : BIMBuildingElement
	{
	  public const string DOOR = "door";

	  private double width;

	  private int widthQT;

	  private double height;

	  private int heightQT;

	  private double area;

	  private int areaQT;

	  private double perimeter;

	  private int perimeterQT;

	  public BIMDoor()
	  {
		  GroupType = "door";
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


	  public virtual double Width
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


	  public virtual int WidthQT
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

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMDoor.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}