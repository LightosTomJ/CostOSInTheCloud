namespace Desktop.common.nomitech.common.bim
{
	public class BIMLightFixture : BIMBuildingElement
	{
	  public const string LIGHTFIXTURE = "lightfixture";

	  private double volume;

	  private int volumeQT;

	  public BIMLightFixture()
	  {
		  GroupType = "lightfixture";
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


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMLightFixture.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}