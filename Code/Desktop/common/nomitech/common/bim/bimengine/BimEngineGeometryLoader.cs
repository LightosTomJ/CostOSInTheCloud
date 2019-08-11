using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim.bimengine
{
	using GeometryFileTable = nomitech.bimengine.model.data.GeometryFileTable;
	using ElementMaterialGeomData = nomitech.bimengine.model.geom.ElementMaterialGeomData;
	using GeomGroupData = nomitech.bimengine.model.geom.GeomGroupData;
	using GeometryData = nomitech.bimengine.model.geom.GeometryData;
	using SerializationUtil = nomitech.bimengine.util.SerializationUtil;
	using IfcEngineGeometryData = nomitech.common.ifc.IfcEngineGeometryData;
	using IfcEngineGeometryDataBimCT = nomitech.common.ifc.IfcEngineGeometryDataBimCT;
	using IfcEngineGeometryDataJava3d = nomitech.common.ifc.IfcEngineGeometryDataJava3d;
	using UIProgress = nomitech.common.ui.UIProgress;
	using Session = org.hibernate.Session;
	using LongType = org.hibernate.type.LongType;

	public class BimEngineGeometryLoader
	{
	  private long? modelId;

	  private UIProgress progress;

	  private IDictionary<long, GeometryData> geomDataMap;

	  private GeometryArray minimalGeometry;

	  private BIMModel o_model;

	  private BIMModelOffset o_modelOffset;

	  private int o_rendererType;

	  private string geomFileSQL = "SELECT f.ID as fileId, g.ID geomId, e.ID elementId FROM BC_GEOMETRY g LEFT JOIN BC_GEOMFILE f ON g.GEOMFILE_ID = f.ID LEFT JOIN BC_ELEMENT e ON e.ID = g.ELEMENT_ID WHERE f.MODEL_ID = :modelId AND e.TYPE = :type AND e.TYPEDESC = :typeDesc";

	  public BimEngineGeometryLoader(BIMModelOffset paramBIMModelOffset, long? paramLong, int paramInt, UIProgress paramUIProgress)
	  {
		this.o_rendererType = paramInt;
		this.modelId = paramLong;
		this.progress = paramUIProgress;
		this.o_modelOffset = paramBIMModelOffset;
	  }

	  public virtual BIMModel Model
	  {
		  set
		  {
			  this.o_model = value;
		  }
	  }

	  public virtual void clearCache()
	  {
		  this.geomDataMap = null;
	  }

	  public virtual void cacheGeometries(Session paramSession, int paramInt1, string paramString, int paramInt2)
	  {
		System.Collections.IList list = paramSession.createSQLQuery(this.geomFileSQL).addScalar("fileId", LongType.INSTANCE).addScalar("geomId", LongType.INSTANCE).addScalar("elementId", LongType.INSTANCE).setLong("modelId", this.modelId.Value).setInteger("type", paramInt1).setString("typeDesc", paramString).list();
		HashSet<object> hashSet = new HashSet<object>(paramInt2);
		Hashtable hashMap = new Hashtable(paramInt2);
		foreach (object[] arrayOfObject in list)
		{
		  long? long1 = (long?)arrayOfObject[0];
		  long? long2 = (long?)arrayOfObject[1];
		  long? long3 = (long?)arrayOfObject[2];
		  hashMap[long2] = long3;
		  hashSet.Add(long1);
		}
		this.geomDataMap = new Hashtable(paramInt2);
		foreach (long? long in hashSet)
		{
		  GeometryFileTable geometryFileTable = (GeometryFileTable)paramSession.load(typeof(GeometryFileTable), long);
		  try
		  {
			GeomGroupData geomGroupData = SerializationUtil.deserializeGeomGroupDataCryoV1(geometryFileTable.FileData, geometryFileTable.SerializationType);
			foreach (GeometryData geometryData in geomGroupData.ElementGeomData)
			{
			  long? long1 = (long?)hashMap[Convert.ToInt64(geometryData.GeometryID)];
			  this.o_modelOffset.updateGeometryData(this.o_model, geometryData);
			  this.geomDataMap[long1] = geometryData;
			}
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  this.progress.incrementProgress(1);
		}
	  }

	  private GeometryArray MinimalGeometry
	  {
		  get
		  {
			if (this.minimalGeometry == null)
			{
			  this.minimalGeometry = new LineArray(2, 1);
			  this.minimalGeometry.setCoordinate(0, new Point3d(0.0D, 0.0D, 0.0D));
			  this.minimalGeometry.setCoordinate(1, new Point3d(1.0D, 0.0D, 0.0D));
			}
			return this.minimalGeometry;
		  }
	  }

	  public virtual IfcEngineGeometryData createGeometry(long? paramLong)
	  {
		GeometryData geometryData = (GeometryData)this.geomDataMap[paramLong];
		return (geometryData == null) ? null : createGeometry(geometryData);
	  }

	  public virtual IfcEngineGeometryData createGeometry(GeometryData paramGeometryData)
	  {
		if (this.o_rendererType != 0)
		{
		  return new IfcEngineGeometryDataBimCT(paramGeometryData);
		}
		IndexedTriangleArray indexedTriangleArray = null;
		IndexedLineArray indexedLineArray = null;
		bool @bool = false;
		try
		{
		  float[] arrayOfFloat1 = paramGeometryData.VertexBuffer;
		  long l1 = arrayOfFloat1.Length;
		  long l2 = l1 * 4L;
		  int[] arrayOfInt = paramGeometryData.IndicesForFaces;
		  long l3 = arrayOfInt.Length;
		  long l4 = l3 * 4L;
		  long l5 = l1 * 4L;
		  float[] arrayOfFloat2 = new float[arrayOfFloat1.Length / 2];
		  float[] arrayOfFloat3 = new float[arrayOfFloat1.Length / 2];
		  float[] arrayOfFloat4 = null;
		  if (paramGeometryData.Materials.length > 1)
		  {
			arrayOfFloat4 = new float[(int)l5];
		  }
		  sbyte b1 = 0;
		  sbyte b2 = 0;
		  for (bool bool1 = false; bool1 < arrayOfFloat1.Length; bool1 += true)
		  {
			if (arrayOfFloat4 != null)
			{
			  arrayOfFloat4[b2] = 0.0F;
			  arrayOfFloat4[b2++] = 0.0F;
			  arrayOfFloat4[b2++] = 0.0F;
			  arrayOfFloat4[b2++] = 1.0F;
			}
			arrayOfFloat2[b1] = arrayOfFloat1[bool1];
			arrayOfFloat3[b1++] = -arrayOfFloat1[bool1 + 3];
			arrayOfFloat2[b1] = arrayOfFloat1[bool1 + true];
			arrayOfFloat3[b1++] = -arrayOfFloat1[bool1 + 4];
			arrayOfFloat2[b1] = arrayOfFloat1[bool1 + 2];
			arrayOfFloat3[b1++] = -arrayOfFloat1[bool1 + 5];
		  }
		  J3DBuffer j3DBuffer1 = createNioFloatBuffer(arrayOfFloat2, l2 / 2L);
		  J3DBuffer j3DBuffer2 = createNioFloatBuffer(arrayOfFloat3, l2 / 2L);
		  if (paramGeometryData.Materials.length > 1)
		  {
			indexedTriangleArray = new IndexedTriangleArray(arrayOfFloat2.Length / 3, 10895, arrayOfInt.Length);
		  }
		  else
		  {
			indexedTriangleArray = new IndexedTriangleArray(arrayOfFloat2.Length / 3, 10883, arrayOfInt.Length);
		  }
		  indexedTriangleArray.NormalRefBuffer = j3DBuffer2;
		  indexedTriangleArray.CoordRefBuffer = j3DBuffer1;
		  indexedTriangleArray.Capability = 21;
		  indexedTriangleArray.Capability = 19;
		  if (arrayOfFloat4 != null)
		  {
			for (bool bool2 = false; bool2 < arrayOfInt.Length; bool2 += true)
			{
			  int i = arrayOfInt[bool2];
			  int j = arrayOfInt[bool2 + true];
			  int k = arrayOfInt[bool2 + 2];
			  float[] arrayOfFloat = getColorOfIndex(paramGeometryData, arrayOfInt, j);
			  if (arrayOfFloat4 != null)
			  {
				arrayOfFloat4[4 * i + 0] = arrayOfFloat[0];
				arrayOfFloat4[4 * i + 1] = arrayOfFloat[1];
				arrayOfFloat4[4 * i + 2] = arrayOfFloat[2];
				arrayOfFloat4[4 * i + 3] = arrayOfFloat[3];
				arrayOfFloat4[4 * j + 0] = arrayOfFloat[0];
				arrayOfFloat4[4 * j + 1] = arrayOfFloat[1];
				arrayOfFloat4[4 * j + 2] = arrayOfFloat[2];
				arrayOfFloat4[4 * j + 3] = arrayOfFloat[3];
				arrayOfFloat4[4 * k + 0] = arrayOfFloat[0];
				arrayOfFloat4[4 * k + 1] = arrayOfFloat[1];
				arrayOfFloat4[4 * k + 2] = arrayOfFloat[2];
				arrayOfFloat4[4 * k + 3] = arrayOfFloat[3];
			  }
			}
			J3DBuffer j3DBuffer = createNioFloatBuffer(arrayOfFloat4, (32 * arrayOfFloat4.Length));
			indexedTriangleArray.ColorRefBuffer = j3DBuffer;
		  }
		  ((IndexedTriangleArray)indexedTriangleArray).CoordIndicesRef = arrayOfInt;
		  if (paramGeometryData.IndicesForLines.length > 0)
		  {
			indexedLineArray = new IndexedLineArray(arrayOfFloat2.Length / 3, 10881, paramGeometryData.IndicesForLines.length);
			indexedLineArray.CoordRefBuffer = j3DBuffer1;
			((IndexedLineArray)indexedLineArray).CoordIndicesRef = paramGeometryData.IndicesForLines;
		  }
		  else
		  {
			indexedLineArray = null;
		  }
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw new System.ArgumentException(exception);
		}
		return new IfcEngineGeometryDataJava3d(indexedTriangleArray, indexedLineArray, null, paramGeometryData);
	  }

	  private float[] getColorOfIndex(GeometryData paramGeometryData, int[] paramArrayOfInt, long paramLong)
	  {
		foreach (ElementMaterialGeomData elementMaterialGeomData in paramGeometryData.Materials)
		{
		  if (elementMaterialGeomData.MaterialVBOffset < paramArrayOfInt.Length && elementMaterialGeomData.MaterialVBOffset >= 0L)
		  {
			long l1 = paramArrayOfInt[(int)elementMaterialGeomData.MaterialVBOffset];
			long l2 = l1 + elementMaterialGeomData.MaterialIndexCount;
			if (l1 <= paramLong && l2 > paramLong)
			{
			  return getColorsFloat(elementMaterialGeomData);
			}
		  }
		}
		return (paramGeometryData.Materials.length == 0) ? new float[] {0.1F, 0.1F, 0.1F, 0.0F} : getColorsFloat(paramGeometryData.Materials[0]);
	  }

	  public virtual float[] getColorsFloat(ElementMaterialGeomData paramElementMaterialGeomData)
	  {
		float[] arrayOfFloat = new float[4];
		arrayOfFloat[0] = paramElementMaterialGeomData.DiffuseColor[0];
		arrayOfFloat[1] = paramElementMaterialGeomData.DiffuseColor[1];
		arrayOfFloat[2] = paramElementMaterialGeomData.DiffuseColor[2];
		arrayOfFloat[3] = paramElementMaterialGeomData.Transparency;
		return arrayOfFloat;
	  }

	  private J3DBuffer createNioFloatBuffer(float[] paramArrayOfFloat, long paramLong)
	  {
		FloatBuffer floatBuffer = ByteBuffer.allocateDirect((int)paramLong).order(ByteOrder.nativeOrder()).asFloatBuffer();
		floatBuffer.put(paramArrayOfFloat, 0, paramArrayOfFloat.Length);
		return new J3DBuffer(floatBuffer);
	  }

	  private J3DBuffer createNioIntBuffer(int[] paramArrayOfInt, long paramLong)
	  {
		IntBuffer intBuffer = ByteBuffer.allocateDirect((int)paramLong).order(ByteOrder.nativeOrder()).asIntBuffer();
		intBuffer.put(paramArrayOfInt, 0, paramArrayOfInt.Length);
		return new J3DBuffer(intBuffer);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\bimengine\BimEngineGeometryLoader.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}