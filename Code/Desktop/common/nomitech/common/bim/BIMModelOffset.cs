using System;

namespace Desktop.common.nomitech.common.bim
{
	using GeometryData = nomitech.bimengine.model.geom.GeometryData;

	public class BIMModelOffset
	{
	  private BIMModel offsetToModel = null;

	  public virtual void updateOffset(BIMModel paramBIMModel)
	  {
		if (this.offsetToModel == null)
		{
		  this.offsetToModel = paramBIMModel;
		}
		else if (isVeryFarFromCurrentOffset(paramBIMModel))
		{
		  this.offsetToModel = paramBIMModel;
		}
	  }

	  public virtual double distanceTo(BIMModel paramBIMModel)
	  {
		double d1 = this.offsetToModel.OffsetX.Value * this.offsetToModel.VertexConversionFactor.Value;
		double d2 = this.offsetToModel.OffsetY.Value * this.offsetToModel.VertexConversionFactor.Value;
		double d3 = this.offsetToModel.OffsetZ.Value * this.offsetToModel.VertexConversionFactor.Value;
		double d4 = paramBIMModel.OffsetX.Value * paramBIMModel.VertexConversionFactor.Value;
		double d5 = paramBIMModel.OffsetY.Value * paramBIMModel.VertexConversionFactor.Value;
		double d6 = paramBIMModel.OffsetZ.Value * paramBIMModel.VertexConversionFactor.Value;
		return Math.Sqrt(Math.Pow(d1 - d4, 2.0D) + Math.Pow(d2 - d5, 2.0D) + Math.Pow(d3 - d6, 2.0D));
	  }

	  private bool isVeryFarFromCurrentOffset(BIMModel paramBIMModel)
	  {
		  return (Math.Abs(distanceTo(paramBIMModel)) > 1000000.0D);
	  }

	  public virtual void removeOffset()
	  {
		  this.offsetToModel = null;
	  }

	  public virtual GeometryData updateGeometryData(BIMModel paramBIMModel, GeometryData paramGeometryData)
	  {
		sbyte b = paramGeometryData.NormalsInterleaved ? 6 : 3;
		if (this.offsetToModel != null && paramBIMModel != this.offsetToModel)
		{
		  double d1 = -paramBIMModel.OffsetX.Value + this.offsetToModel.OffsetX.Value;
		  double d2 = -paramBIMModel.OffsetY.Value + this.offsetToModel.OffsetY.Value;
		  double d3 = -paramBIMModel.OffsetZ.Value + this.offsetToModel.OffsetZ.Value;
		  paramGeometryData.applyConversions(d1, d2, d3, paramBIMModel.VertexConversionFactor.Value);
		}
		else if (paramBIMModel.VertexConversionFactor.Value != 1.0D)
		{
		  paramGeometryData.applyConversions(0.0D, 0.0D, 0.0D, paramBIMModel.VertexConversionFactor.Value);
		}
		return paramGeometryData;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMModelOffset.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}