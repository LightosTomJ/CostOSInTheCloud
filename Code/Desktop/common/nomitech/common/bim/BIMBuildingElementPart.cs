namespace Desktop.common.nomitech.common.bim
{
	public class BIMBuildingElementPart : BIMBuildingElement
	{
	  public const string ELEMENTPART = "elementpart";

	  private double volume;

	  private int volumeQT;

	  public BIMBuildingElementPart()
	  {
		  GroupType = "elementpart";
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


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMBuildingElementPart.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}