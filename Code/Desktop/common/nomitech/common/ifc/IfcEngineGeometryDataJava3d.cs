using System;

namespace Desktop.common.nomitech.common.ifc
{
	using ElementMaterialGeomData = nomitech.bimengine.model.geom.ElementMaterialGeomData;
	using GeometryData = nomitech.bimengine.model.geom.GeometryData;

	public class IfcEngineGeometryDataJava3d : IfcEngineGeometryData
	{
	  private GeometryArray triangleGeometry;

	  private GeometryArray wireFrameGeometry;

	  private GeometryArray innerWireFrameGeometry;

	  private Color ambientColor = null;

	  private double? transparency = null;

	  private J3DBuffer colorBuffer;

	  private J3DBuffer selectedColorBuffer;

	  public IfcEngineGeometryDataJava3d(GeometryArray paramGeometryArray1, GeometryArray paramGeometryArray2, GeometryArray paramGeometryArray3, GeometryData paramGeometryData)
	  {
		this.triangleGeometry = paramGeometryArray1;
		this.wireFrameGeometry = paramGeometryArray2;
		this.innerWireFrameGeometry = paramGeometryArray3;
		if (paramGeometryArray1 != null && paramGeometryData != null)
		{
		  this.colorBuffer = paramGeometryArray1.ColorRefBuffer;
		}
		if (paramGeometryData != null && paramGeometryData.Materials.length > 0)
		{
		  foreach (ElementMaterialGeomData elementMaterialGeomData in paramGeometryData.Materials)
		  {
			if (this.ambientColor == null)
			{
			  this.ambientColor = new Color(elementMaterialGeomData.DiffuseColor[0], elementMaterialGeomData.DiffuseColor[1], elementMaterialGeomData.DiffuseColor[2], 1.0F);
			}
			if (elementMaterialGeomData.Transparency < 1.0F)
			{
			  this.transparency = Convert.ToDouble(1.0D - elementMaterialGeomData.Transparency);
			}
		  }
		}
	  }

	  public virtual J3DBuffer ColorBuffer
	  {
		  get
		  {
			  return this.colorBuffer;
		  }
	  }

	  public virtual GeometryArray TriangleGeometry
	  {
		  get
		  {
			  return this.triangleGeometry;
		  }
	  }

	  public virtual GeometryArray OuterWireFrameGeometry
	  {
		  get
		  {
			  return this.wireFrameGeometry;
		  }
	  }

	  public virtual GeometryArray InnerWireFrameGeometry
	  {
		  get
		  {
			  return this.innerWireFrameGeometry;
		  }
	  }

	  public override double? Transparency
	  {
		  get
		  {
			  return this.transparency;
		  }
	  }

	  public override Color AmbientColor
	  {
		  get
		  {
			  return this.ambientColor;
		  }
	  }

	  public virtual void clearWireFrameGeometry()
	  {
		this.wireFrameGeometry = null;
		this.innerWireFrameGeometry = null;
	  }

	  public virtual J3DBuffer getSelectedColorBuffer(Color paramColor)
	  {
		if (this.selectedColorBuffer == null)
		{
		  FloatBuffer floatBuffer1 = (FloatBuffer)ColorBuffer.Buffer;
		  float[] arrayOfFloat = new float[this.triangleGeometry.VertexCount * 4];
		  for (sbyte b = 0; b < this.triangleGeometry.VertexCount; b++)
		  {
			sbyte b1 = b * 4;
			arrayOfFloat[b1] = (paramColor.Red / 255);
			arrayOfFloat[b1 + 1] = (paramColor.Green / 255);
			arrayOfFloat[b1 + 2] = (paramColor.Blue / 255);
			arrayOfFloat[b1 + 3] = floatBuffer1.get(b1 + 3);
		  }
		  FloatBuffer floatBuffer2 = ByteBuffer.allocateDirect(32 * arrayOfFloat.Length).order(ByteOrder.nativeOrder()).asFloatBuffer();
		  floatBuffer2.put(arrayOfFloat, 0, arrayOfFloat.Length);
		  this.selectedColorBuffer = new J3DBuffer(floatBuffer2);
		}
		return this.selectedColorBuffer;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\ifc\IfcEngineGeometryDataJava3d.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}