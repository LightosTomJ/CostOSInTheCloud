namespace Desktop.common.nomitech.common.bim
{
	public class BIMGeometry
	{
	  private object geometryData;

	  public BIMGeometry(object paramObject)
	  {
		  this.geometryData = paramObject;
	  }

	  public virtual object GeometryData
	  {
		  get
		  {
			  return this.geometryData;
		  }
		  set
		  {
			  this.geometryData = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMGeometry.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}