namespace Desktop.common.nomitech.common.bim
{
	public class BIMDistributionElementWithLength : BIMBuildingElement
	{
	  private double volume;

	  private int volumeQT;

	  private double length;

	  private int lengthQT;

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


	  public BIMDistributionElementWithLength()
	  {
	  }

	  public BIMDistributionElementWithLength(string paramString)
	  {
		  GroupType = paramString;
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


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMDistributionElementWithLength.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}