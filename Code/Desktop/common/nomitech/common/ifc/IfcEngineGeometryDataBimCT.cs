namespace Desktop.common.nomitech.common.ifc
{
	using GeometryData = nomitech.bimengine.model.geom.GeometryData;

	public class IfcEngineGeometryDataBimCT : IfcEngineGeometryData
	{
	  private GeometryData geomData;

	  public IfcEngineGeometryDataBimCT(GeometryData paramGeometryData)
	  {
		  this.geomData = paramGeometryData;
	  }

	  public virtual GeometryData GeometryData
	  {
		  get
		  {
			  return this.geomData;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\ifc\IfcEngineGeometryDataBimCT.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}