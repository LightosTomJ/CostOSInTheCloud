namespace Desktop.common.nomitech.common.ifc
{
	using Callback = com.sun.jna.Callback;
	using Library = com.sun.jna.Library;
	using Native = com.sun.jna.Native;
	using Pointer = com.sun.jna.Pointer;
	using DoubleByReference = com.sun.jna.ptr.DoubleByReference;
	using IntByReference = com.sun.jna.ptr.IntByReference;
	using LongByReference = com.sun.jna.ptr.LongByReference;
	using PointerByReference = com.sun.jna.ptr.PointerByReference;

	public interface IfcEngineInterface : Library
	{

	  long SetFormat(Pointer paramPointer, long paramLong1, long paramLong2);

	  long SetFormat(long paramLong1, long paramLong2, long paramLong3);

	  long CreateInstance(long paramLong, Pointer paramPointer);

	  long CalculateInstance(Pointer paramPointer, LongByReference paramLongByReference1, LongByReference paramLongByReference2, LongByReference paramLongByReference3);

	  long CalculateInstance(long paramLong, LongByReference paramLongByReference1, LongByReference paramLongByReference2, LongByReference paramLongByReference3);

	  long UpdateInstanceVertexBuffer(Pointer paramPointer1, Pointer paramPointer2);

	  void SetVertexBufferOffset(long paramLong, double paramDouble1, double paramDouble2, double paramDouble3);

	  void ClearedInstanceExternalBuffers(long paramLong);

	  long UpdateInstanceVertexBuffer(long paramLong, Pointer paramPointer);

	  long UpdateInstanceIndexBuffer(Pointer paramPointer1, Pointer paramPointer2);

	  long UpdateInstanceIndexBuffer(long paramLong, Pointer paramPointer);

	  long getConceptualFaceCnt(Pointer paramPointer);

	  long GetConceptualFaceCnt(long paramLong);

	  long getConceptualFaceEx(Pointer paramPointer, long paramLong, LongByReference paramLongByReference1, LongByReference paramLongByReference2, LongByReference paramLongByReference3, LongByReference paramLongByReference4, LongByReference paramLongByReference5, LongByReference paramLongByReference6, LongByReference paramLongByReference7, LongByReference paramLongByReference8, LongByReference paramLongByReference9, LongByReference paramLongByReference10);

	  long GetConceptualFaceEx(long paramLong1, long paramLong2, LongByReference paramLongByReference1, LongByReference paramLongByReference2, LongByReference paramLongByReference3, LongByReference paramLongByReference4, LongByReference paramLongByReference5, LongByReference paramLongByReference6, LongByReference paramLongByReference7, LongByReference paramLongByReference8, LongByReference paramLongByReference9, LongByReference paramLongByReference10);

	  void sdaiGetADBValue(Pointer paramPointer, int paramInt, PointerByReference paramPointerByReference);

	  void sdaiGetADBValue(Pointer paramPointer, int paramInt, DoubleByReference paramDoubleByReference);

	  void sdaiGetADBTypePathx(Pointer paramPointer, int paramInt, PointerByReference paramPointerByReference);

	  int sdaiIsKindOf(Pointer paramPointer1, Pointer paramPointer2);

	  int engiGetEntityCount(Pointer paramPointer);

	  Pointer engiGetEntityParent(Pointer paramPointer);

	  void setFormat(Pointer paramPointer, int paramInt1, int paramInt2);

	  void setFilter(Pointer paramPointer, int paramInt1, int paramInt2);

	  void getInstanceTransformationMatrix(Pointer paramPointer1, Pointer paramPointer2, DoubleByReference paramDoubleByReference1, DoubleByReference paramDoubleByReference2, DoubleByReference paramDoubleByReference3, DoubleByReference paramDoubleByReference4, DoubleByReference paramDoubleByReference5, DoubleByReference paramDoubleByReference6, DoubleByReference paramDoubleByReference7, DoubleByReference paramDoubleByReference8, DoubleByReference paramDoubleByReference9, DoubleByReference paramDoubleByReference10, DoubleByReference paramDoubleByReference11, DoubleByReference paramDoubleByReference12, DoubleByReference paramDoubleByReference13, DoubleByReference paramDoubleByReference14, DoubleByReference paramDoubleByReference15, DoubleByReference paramDoubleByReference16);

	  Pointer xxxxOpenModelByStream(int paramInt, IfcEngineInterface_StreamCallback paramStreamCallback, string paramString);

	  Pointer GetSPFFHeaderItem(Pointer paramPointer, int paramInt1, int paramInt2, int paramInt3, PointerByReference paramPointerByReference);

	  int sdaiGetMemberCount(Pointer paramPointer);

	  void circleSegments(int paramInt1, int paramInt2);

	  void engiGetAggrElement(Pointer paramPointer, int paramInt1, int paramInt2, PointerByReference paramPointerByReference);

	  void engiGetAggrElement(Pointer paramPointer, int paramInt1, int paramInt2, DoubleByReference paramDoubleByReference);

	  void engiGetAggrElement(Pointer paramPointer, int paramInt1, int paramInt2, IntByReference paramIntByReference);

	  string engiGetInstanceClassInfo(Pointer paramPointer);

	  string engiGetInstanceClassInfoUC(Pointer paramPointer);

	  int engiGetInstanceLocalId(Pointer paramPointer);

	  int engiGetInstanceMetaInfo(Pointer paramPointer, IntByReference paramIntByReference, PointerByReference paramPointerByReference1, PointerByReference paramPointerByReference2);

	  void finalizeClashesByGuid(Pointer paramPointer1, Pointer paramPointer2, Pointer paramPointer3);

	  void finalizeClashesByEI(Pointer paramPointer1, Pointer paramPointer2, Pointer paramPointer3);

	  int initializeModellingInstance(Pointer paramPointer1, IntByReference paramIntByReference1, IntByReference paramIntByReference2, double paramDouble, Pointer paramPointer2);

	  void owlGetModel(Pointer paramPointer, LongByReference paramLongByReference);

	  void owlGetInstance(Pointer paramPointer1, Pointer paramPointer2, LongByReference paramLongByReference);

	  void owlGetMappedItem(Pointer paramPointer1, Pointer paramPointer2, LongByReference paramLongByReference, Pointer paramPointer3);

	  int initializeModelling(Pointer paramPointer, IntByReference paramIntByReference1, IntByReference paramIntByReference2, double paramDouble);

	  void initializeClashes(Pointer paramPointer, IntByReference paramIntByReference, double paramDouble);

	  void setPostProcessing(Pointer paramPointer, int paramInt);

	  int internalGetP21Line(Pointer paramPointer);

	  Pointer internalGetInstanceFromP21Line(Pointer paramPointer, int paramInt);

	  int initializeModellingInstanceEx(Pointer paramPointer1, IntByReference paramIntByReference1, IntByReference paramIntByReference2, double paramDouble, Pointer paramPointer2, Pointer paramPointer3);

	  int finalizeModelling(Pointer paramPointer1, Pointer paramPointer2, Pointer paramPointer3, int paramInt);

	  Pointer getInstanceInModelling(Pointer paramPointer1, Pointer paramPointer2, int paramInt, IntByReference paramIntByReference1, IntByReference paramIntByReference2, IntByReference paramIntByReference3);

	  double GetArea(Pointer paramPointer1, Pointer paramPointer2, Pointer paramPointer3);

	  double GetArea(long paramLong, Pointer paramPointer1, Pointer paramPointer2);

	  double GetVolume(Pointer paramPointer1, Pointer paramPointer2, Pointer paramPointer3);

	  double GetVolume(long paramLong, Pointer paramPointer1, Pointer paramPointer2);

	  double GetPerimeter(Pointer paramPointer);

	  double GetPerimeter(long paramLong);

	  int getTimeStamp(Pointer paramPointer);

	  string getChangedData(Pointer paramPointer, int paramInt);

	  void setChangedData(Pointer paramPointer, int paramInt, string paramString);

	  int setStringUnicode(bool paramBoolean);

	  Pointer internalGetBoundingBox(Pointer paramPointer1, Pointer paramPointer2);

	  Pointer internalGetCenter(Pointer paramPointer1, Pointer paramPointer2);

	  void internalSetLink(Pointer paramPointer, string paramString, int paramInt);

	  void internalAddAggrLink(int paramInt1, int paramInt2);

	  int getInstanceDerivedPropertiesInModelling(int paramInt, Pointer paramPointer, DoubleByReference paramDoubleByReference1, DoubleByReference paramDoubleByReference2, DoubleByReference paramDoubleByReference3);

	  int getInstanceDerivedBoundingBox(Pointer paramPointer1, Pointer paramPointer2, DoubleByReference paramDoubleByReference1, DoubleByReference paramDoubleByReference2, DoubleByReference paramDoubleByReference3, DoubleByReference paramDoubleByReference4, DoubleByReference paramDoubleByReference5, DoubleByReference paramDoubleByReference6);

	  int getInstanceDerivedTransformationMatrix(Pointer paramPointer1, Pointer paramPointer2, DoubleByReference paramDoubleByReference1, DoubleByReference paramDoubleByReference2, DoubleByReference paramDoubleByReference3, DoubleByReference paramDoubleByReference4, DoubleByReference paramDoubleByReference5, DoubleByReference paramDoubleByReference6, DoubleByReference paramDoubleByReference7, DoubleByReference paramDoubleByReference8, DoubleByReference paramDoubleByReference9, DoubleByReference paramDoubleByReference10, DoubleByReference paramDoubleByReference11, DoubleByReference paramDoubleByReference12, DoubleByReference paramDoubleByReference13, DoubleByReference paramDoubleByReference14, DoubleByReference paramDoubleByReference15, DoubleByReference paramDoubleByReference16);

	  int sdaiGetAggregationAttrBN(Pointer paramPointer, string paramString);

	  void sdaiGetAttrBN(Pointer paramPointer, string paramString, int paramInt, PointerByReference paramPointerByReference);

	  void sdaiGetAttrBN(Pointer paramPointer, string paramString, int paramInt, DoubleByReference paramDoubleByReference);

	  Pointer sdaiGetEntity(Pointer paramPointer, string paramString);

	  Pointer sdaiGetEntityExtentBN(Pointer paramPointer, string paramString);

	  int sdaiGetInstanceAttrBN(Pointer paramPointer, string paramString);

	  Pointer sdaiGetInstanceType(Pointer paramPointer);

	  string sdaiGetStringAttrBN(Pointer paramPointer, string paramString);

	  Pointer sdaiOpenModelBN(int paramInt, string paramString1, string paramString2);

	  int sdaiCreateModelBN(int paramInt, string paramString1, string paramString2);

	  void sdaiSaveModelBN(int paramInt, string paramString);

	  void sdaiSaveModelAsXmlBN(Pointer paramPointer, string paramString);

	  void sdaiCloseModel(Pointer paramPointer);

	  void sdaiAppend(int paramInt1, int paramInt2, IntByReference paramIntByReference);

	  void sdaiAppend(int paramInt1, int paramInt2, DoubleByReference paramDoubleByReference);

	  void sdaiAppend(int paramInt1, int paramInt2, string paramString);

	  void sdaiAppend(int paramInt1, int paramInt2, Pointer paramPointer);

	  void sdaiBeginning(int paramInt);

	  Pointer sdaiCreateADB(int paramInt, IntByReference paramIntByReference);

	  Pointer sdaiCreateADB(int paramInt, DoubleByReference paramDoubleByReference);

	  Pointer sdaiCreateADB(int paramInt, string paramString);

	  Pointer sdaiCreateADB(int paramInt, Pointer paramPointer);

	  Pointer sdaiCreateAggr(Pointer paramPointer, int paramInt);

	  Pointer sdaiCreateAggrBN(Pointer paramPointer, string paramString);

	  Pointer sdaiCreateInstance(Pointer paramPointer, int paramInt);

	  Pointer sdaiCreateInstanceBN(Pointer paramPointer, string paramString);

	  Pointer sdaiCreateInstanceBNEI(Pointer paramPointer, string paramString, int paramInt);

	  Pointer sdaiCreateIterator(Pointer paramPointer);

	  void sdaiDeleteInstance(Pointer paramPointer);

	  void sdaiDeleteIterator(Pointer paramPointer);

	  void sdaiEnd(Pointer paramPointer);

	  int sdaiErrorQuery();

	  void sdaiGetAggrByIterator(Pointer paramPointer, int paramInt, IntByReference paramIntByReference);

	  void sdaiGetAggrByIterator(Pointer paramPointer, int paramInt, DoubleByReference paramDoubleByReference);

	  void sdaiGetAggrByIterator(Pointer paramPointer, int paramInt, string paramString);

	  void sdaiGetAggrByIterator(Pointer paramPointer, int paramInt, PointerByReference paramPointerByReference);

	  void sdaiGetAttr(Pointer paramPointer, int paramInt1, int paramInt2, IntByReference paramIntByReference);

	  void sdaiGetAttr(Pointer paramPointer, int paramInt1, int paramInt2, DoubleByReference paramDoubleByReference);

	  void sdaiGetAttr(Pointer paramPointer, int paramInt1, int paramInt2, string paramString);

	  void sdaiGetAttr(Pointer paramPointer, int paramInt1, int paramInt2, PointerByReference paramPointerByReference);

	  Pointer sdaiGetAttrDefinition(Pointer paramPointer, string paramString);

	  Pointer xxxxGetEntityAndSubTypesExtentBN(Pointer paramPointer, string paramString);

	  void engiGetEntityName(Pointer paramPointer, int paramInt, PointerByReference paramPointerByReference);

	  long GetInstanceClass(long paramLong);

	  long GetClassByName(long paramLong, string paramString);

	  long GetPropertyByName(long paramLong, string paramString);

	  long GetInstanceType(long paramLong);

	  long SetDataTypeProperty(long paramLong1, long paramLong2, long[] paramArrayOfLong, long paramLong3);

	  long SetObjectTypeProperty(long paramLong1, long paramLong2, long[] paramArrayOfLong, long paramLong3);

	  void GetDataTypeProperty(long paramLong1, long paramLong2, PointerByReference paramPointerByReference, LongByReference paramLongByReference);

	  void GetObjectTypeProperty(long paramLong1, long paramLong2, PointerByReference paramPointerByReference, LongByReference paramLongByReference);

	  void PeelArray(PointerByReference paramPointerByReference1, PointerByReference paramPointerByReference2, long paramLong);
	}

	public static class IfcEngineInterface_Fields
	{
	  public static readonly IfcEngineInterface INSTANCE = (IfcEngineInterface)Native.loadLibrary("ifcengine", typeof(IfcEngineInterface));
	  public const int sdaiADB = 1;
	  public const int sdaiAGGR = 2;
	  public const int sdaiBINARY = 3;
	  public const int sdaiBOOLEAN = 4;
	  public const int sdaiENUM = 5;
	  public const int sdaiINSTANCE = 6;
	  public const int sdaiINTEGER = 7;
	  public const int sdaiLOGICAL = 8;
	  public const int sdaiREAL = 9;
	  public const int sdaiSTRING = 10;
	  public const int sdaiUNICODE = 11;
	  public const int sdaiEXPRESSSTRING = 12;
	  public const int engiGLOBALID = 13;
	}

	  public interface IfcEngineInterface_StreamCallback : Callback
	  {
	int invoke(Pointer param1Pointer);
	  }


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\ifc\IfcEngineInterface.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}