using System;
using System.Collections.Generic;
using System.IO;

namespace Desktop.common.nomitech.common.ifc
{
	using Pointer = Desktop.common.com.sun.jna.Pointer;
	using DoubleByReference = Desktop.common.com.sun.jna.ptr.DoubleByReference;
	using LongByReference = Desktop.common.com.sun.jna.ptr.LongByReference;
	using PointerByReference = Desktop.common.com.sun.jna.ptr.PointerByReference;
	using StringUtils = Desktop.common.nomitech.common.util.StringUtils;
	using BIMProperty = Desktop.common.nomitech.ifcengine.props.BIMProperty;
	using BIMPropertySet = Desktop.common.nomitech.ifcengine.props.BIMPropertySet;

	public class IfcEngineUtils
	{
	  public static ISet<string> loadAllIfcSpatialElementTypes(Pointer paramPointer, string paramString)
	  {
		HashSet<object> hashSet = new HashSet<object>();
		if (paramString.StartsWith("IFC2X3", StringComparison.Ordinal))
		{
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcSpace"));
		}
		else
		{
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcSpace"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcSpatialElement"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcExternalSpatialStructureElement"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcSpatialStructureElement"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcSpatialZone"));
		}
		return hashSet;
	  }

	  public static ISet<string> loadAllIfcBuildingElementTypes(Pointer paramPointer, string paramString)
	  {
		HashSet<object> hashSet = new HashSet<object>();
		if (paramString.StartsWith("IFC2X3", StringComparison.Ordinal))
		{
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcBuildingElementProxy"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcCovering"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcBeam"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcColumn"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcCurtainWall"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcDoor"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcMember"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcRamp"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcRailing"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcRampFlight"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcWall"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcWallStandardCase"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcSlab"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcStairFlight"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcWindow"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcStair"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcRoof"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcPile"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcFooting"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcBuildingElementComponent"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcBuildingElementPart"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcPlate"));
		}
		else
		{
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcBeam"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcBuildingElementProxy"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcChimney"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcColumn"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcCovering"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcCurtainWall"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcDoor"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcFooting"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcMember"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcPile"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcPlate"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcRailing"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcRamp"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcRampFlight"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcRoof"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcShadingDevice"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcSlab"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcStair"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcStairFlight"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcWall"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcWallStandardCase"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcWindow"));
		}
		return hashSet;
	  }

	  public static ISet<string> loadAllIfcDistributionElementTypes(Pointer paramPointer, string paramString)
	  {
		HashSet<object> hashSet = new HashSet<object>();
		if (paramString.StartsWith("IFC2X3", StringComparison.Ordinal))
		{
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcDistributionFlowElement"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcDistributionChamberElement"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcFlow"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcColumn"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcCurtainWall"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcDoor"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcMember"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcRamp"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcRailing"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcRampFlight"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcWall"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcWallStandardCase"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcSlab"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcStairFlight"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcWindow"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcStair"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcRoof"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcPile"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcFooting"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcBuildingElementComponent"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcBuildingElementPart"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcPlate"));
		}
		else
		{
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcBeam"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcBuildingElementProxy"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcChimney"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcColumn"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcCovering"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcCurtainWall"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcDoor"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcFooting"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcMember"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcPile"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcPlate"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcRailing"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcRamp"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcRampFlight"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcRoof"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcShadingDevice"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcSlab"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcStair"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcStairFlight"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcWall"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcWallStandardCase"));
		  hashSet.Add(getEntityTypeOf(paramPointer, "IfcWindow"));
		}
		return hashSet;
	  }

	  public static string getEntityTypeOf(Pointer paramPointer, string paramString)
	  {
		  return IfcEngineInterface_Fields.INSTANCE.sdaiGetEntity(paramPointer, paramString.ToUpper()).ToString();
	  }

	  public static string getTypeOfInstance(Pointer paramPointer)
	  {
		  return IfcEngineInterface_Fields.INSTANCE.sdaiGetInstanceType(paramPointer).ToString();
	  }

	  public static string getTypeNameOfInstance(Pointer paramPointer)
	  {
		Pointer pointer = IfcEngineInterface_Fields.INSTANCE.sdaiGetInstanceType(paramPointer);
		PointerByReference pointerByReference = new PointerByReference();
		IfcEngineInterface_Fields.INSTANCE.engiGetEntityName(pointer, 10, pointerByReference);
		return pointerByReference.Value.getString(0L);
	  }

	  public static long getOwlModel(Pointer paramPointer)
	  {
		LongByReference longByReference = new LongByReference();
		IfcEngineInterface_Fields.INSTANCE.owlGetModel(paramPointer, longByReference);
		return longByReference.Value;
	  }

	  public static long getOwlInstance(Pointer paramPointer1, Pointer paramPointer2)
	  {
		LongByReference longByReference = new LongByReference();
		IfcEngineInterface_Fields.INSTANCE.owlGetInstance(paramPointer1, paramPointer2, longByReference);
		return longByReference.Value;
	  }

	  public static bool checkEntityIsOfType(Pointer paramPointer, string paramString)
	  {
		  return getTypeOfInstance(paramPointer).Equals(paramString);
	  }

	  public static bool localIsKindOf(Pointer paramPointer1, Pointer paramPointer2, string paramString)
	  {
		Pointer pointer = IfcEngineInterface_Fields.INSTANCE.sdaiGetEntity(paramPointer1, paramString.ToUpper());
		return localIsKindOf(paramPointer2, pointer);
	  }

	  public static bool localIsKindOf(Pointer paramPointer1, Pointer paramPointer2)
	  {
		Pointer pointer = IfcEngineInterface_Fields.INSTANCE.sdaiGetInstanceType(paramPointer1);
		while (paramPointer2 != null && paramPointer2 != pointer)
		{
		  paramPointer2 = IfcEngineInterface_Fields.INSTANCE.engiGetEntityParent(paramPointer2);
		}
		return (paramPointer2 == pointer);
	  }

	  public static IList<Pointer> getEntities(Pointer paramPointer, string paramString)
	  {
		Pointer pointer = IfcEngineInterface_Fields.INSTANCE.sdaiGetEntityExtentBN(paramPointer, paramString);
		int i = IfcEngineInterface_Fields.INSTANCE.sdaiGetMemberCount(pointer);
		List<object> arrayList = new List<object>(i);
		if (i != 0)
		{
		  Pointer pointer1 = IfcEngineInterface_Fields.INSTANCE.sdaiGetEntity(paramPointer, "IFCBUILDING");
		  for (sbyte b = 0; b < i; b++)
		  {
			PointerByReference pointerByReference = new PointerByReference();
			IfcEngineInterface_Fields.INSTANCE.engiGetAggrElement(pointer, b, 6, pointerByReference);
			arrayList.Add(pointerByReference.Value);
		  }
		}
		return arrayList;
	  }

	  public static IList<Pointer> getContainedEntities(Pointer paramPointer1, Pointer paramPointer2)
	  {
		  return getContainedEntities(paramPointer1, paramPointer2, null);
	  }

	  public static IList<Pointer> getContainedEntities(Pointer paramPointer1, Pointer paramPointer2, string paramString)
	  {
		string str1 = IfcEngineInterface_Fields.INSTANCE.sdaiGetEntity(paramPointer1, "IFCRELCONTAINEDINSPATIALSTRUCTURE").ToString();
		string str2 = null;
		if (!string.ReferenceEquals(paramString, null))
		{
		  str2 = IfcEngineInterface_Fields.INSTANCE.sdaiGetEntity(paramPointer1, paramString).ToString();
		}
		LinkedList linkedList = new LinkedList();
		PointerByReference pointerByReference = new PointerByReference();
		int i = 0;
		IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(paramPointer2, "ContainsElements", 2, pointerByReference);
		if (pointerByReference.Value != null)
		{
		  i = IfcEngineInterface_Fields.INSTANCE.sdaiGetMemberCount(pointerByReference.Value);
		  if (i != 0)
		  {
			for (sbyte b = 0; b < i; b++)
			{
			  PointerByReference pointerByReference1 = new PointerByReference();
			  IfcEngineInterface_Fields.INSTANCE.engiGetAggrElement(pointerByReference.Value, b, 6, pointerByReference1);
			  if (IfcEngineInterface_Fields.INSTANCE.sdaiGetInstanceType(pointerByReference1.Value).ToString().Equals(str1))
			  {
				PointerByReference pointerByReference2 = new PointerByReference();
				int j = 0;
				IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(pointerByReference1.Value, "RelatedElements", 2, pointerByReference2);
				j = IfcEngineInterface_Fields.INSTANCE.sdaiGetMemberCount(pointerByReference2.Value);
				for (sbyte b1 = 0; b1 < j; b1++)
				{
				  PointerByReference pointerByReference3 = new PointerByReference();
				  IfcEngineInterface_Fields.INSTANCE.engiGetAggrElement(pointerByReference2.Value, b1, 6, pointerByReference3);
				  if (string.ReferenceEquals(str2, null))
				  {
					linkedList.AddLast(pointerByReference3.Value);
				  }
				  else if (IfcEngineInterface_Fields.INSTANCE.sdaiGetInstanceType(pointerByReference3.Value).ToString().Equals(str2))
				  {
					linkedList.AddLast(pointerByReference3.Value);
				  }
				}
			  }
			  else
			  {
				Console.Error.WriteLine("IFCWARN: getContainedElements found items not of " + pointerByReference + " type.");
			  }
			}
		  }
		}
		return linkedList;
	  }

	  public static IList<Pointer> getDecomposedByEntities(Pointer paramPointer1, Pointer paramPointer2)
	  {
		  return getDecomposedByEntities(paramPointer1, paramPointer2, null);
	  }

	  public static IList<Pointer> getDecomposedByEntities(Pointer paramPointer1, Pointer paramPointer2, string paramString)
	  {
		string str1 = IfcEngineInterface_Fields.INSTANCE.sdaiGetEntity(paramPointer1, "IFCRELAGGREGATES").ToString();
		string str2 = null;
		if (!string.ReferenceEquals(paramString, null))
		{
		  str2 = IfcEngineInterface_Fields.INSTANCE.sdaiGetEntity(paramPointer1, paramString).ToString();
		}
		LinkedList linkedList = new LinkedList();
		PointerByReference pointerByReference = new PointerByReference();
		int i = 0;
		IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(paramPointer2, "IsDecomposedBy", 2, pointerByReference);
		if (pointerByReference != null && pointerByReference.Value != null)
		{
		  i = IfcEngineInterface_Fields.INSTANCE.sdaiGetMemberCount(pointerByReference.Value);
		  for (sbyte b = 0; b < i; b++)
		  {
			PointerByReference pointerByReference1 = new PointerByReference();
			IfcEngineInterface_Fields.INSTANCE.engiGetAggrElement(pointerByReference.Value, b, 6, pointerByReference1);
			if (IfcEngineInterface_Fields.INSTANCE.sdaiGetInstanceType(pointerByReference1.Value).ToString().Equals(str1))
			{
			  PointerByReference pointerByReference2 = new PointerByReference();
			  IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(pointerByReference1.Value, "RelatedObjects", 2, pointerByReference2);
			  int j = IfcEngineInterface_Fields.INSTANCE.sdaiGetMemberCount(pointerByReference2.Value);
			  for (sbyte b1 = 0; b1 < j; b1++)
			  {
				PointerByReference pointerByReference3 = new PointerByReference();
				IfcEngineInterface_Fields.INSTANCE.engiGetAggrElement(pointerByReference2.Value, b1, 6, pointerByReference3);
				if (string.ReferenceEquals(str2, null))
				{
				  linkedList.AddLast(pointerByReference3.Value);
				}
				else if (IfcEngineInterface_Fields.INSTANCE.sdaiGetInstanceType(pointerByReference3.Value).ToString().Equals(str2))
				{
				  linkedList.AddLast(pointerByReference3.Value);
				}
			  }
			}
			else
			{
			  Console.Error.WriteLine("IFCWARN: getDecomposedByEntities found items not of " + str1 + " type.");
			}
		  }
		}
		return linkedList;
	  }

	  public static double? getDoubleAttributeBN(Pointer paramPointer, string paramString)
	  {
		DoubleByReference doubleByReference = new DoubleByReference();
		IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(paramPointer, paramString, 9, doubleByReference);
		return Convert.ToDouble(doubleByReference.Value);
	  }

	  public static string getPathViaADBAsFirstElementInAGGRAttributeBN(Pointer paramPointer, string paramString)
	  {
		PointerByReference pointerByReference = new PointerByReference();
		IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(paramPointer, paramString, 2, pointerByReference);
		if (pointerByReference.Value != null)
		{
		  int i = IfcEngineInterface_Fields.INSTANCE.sdaiGetMemberCount(pointerByReference.Value);
		  if (i > 0)
		  {
			PointerByReference pointerByReference1 = new PointerByReference();
			IfcEngineInterface_Fields.INSTANCE.engiGetAggrElement(pointerByReference.Value, 0, 1, pointerByReference1);
			PointerByReference pointerByReference2 = new PointerByReference();
			IfcEngineInterface_Fields.INSTANCE.sdaiGetADBTypePathx(pointerByReference1.Value, 10, pointerByReference2);
			return pointerByReference2.Value.getString(0L);
		  }
		}
		return null;
	  }

	  public static double? getDoubleViaADBAsFirstElementInAGGRAttributeBN(Pointer paramPointer, string paramString)
	  {
		PointerByReference pointerByReference = new PointerByReference();
		IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(paramPointer, paramString, 2, pointerByReference);
		if (pointerByReference.Value != null)
		{
		  int i = IfcEngineInterface_Fields.INSTANCE.sdaiGetMemberCount(pointerByReference.Value);
		  if (i > 0)
		  {
			PointerByReference pointerByReference1 = new PointerByReference();
			IfcEngineInterface_Fields.INSTANCE.engiGetAggrElement(pointerByReference.Value, 0, 1, pointerByReference1);
			DoubleByReference doubleByReference = new DoubleByReference();
			IfcEngineInterface_Fields.INSTANCE.sdaiGetADBValue(pointerByReference1.Value, 9, doubleByReference);
			return Convert.ToDouble(doubleByReference.Value);
		  }
		}
		return Convert.ToDouble(0.0D);
	  }

	  public static string getStringAttributeBN(Pointer paramPointer, string paramString)
	  {
		PointerByReference pointerByReference = new PointerByReference();
		IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(paramPointer, paramString, 10, pointerByReference);
		return (pointerByReference.Value == null) ? "" : pointerByReference.Value.getString(0L);
	  }

	  public static Pointer getADBAttributeBN(Pointer paramPointer, string paramString)
	  {
		PointerByReference pointerByReference = new PointerByReference();
		IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(paramPointer, paramString, 1, pointerByReference);
		return pointerByReference.Value;
	  }

	  public static double? getADBDoubleValue(Pointer paramPointer)
	  {
		DoubleByReference doubleByReference = new DoubleByReference();
		IfcEngineInterface_Fields.INSTANCE.sdaiGetADBValue(paramPointer, 9, doubleByReference);
		return Convert.ToDouble(doubleByReference.Value);
	  }

	  public static Pointer getInstanceAttributeBN(Pointer paramPointer, string paramString)
	  {
		PointerByReference pointerByReference = new PointerByReference();
		IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(paramPointer, paramString, 6, pointerByReference);
		return pointerByReference.Value;
	  }

	  public static IList<Pointer> getSetAttributeBN(Pointer paramPointer, string paramString)
	  {
		System.Collections.IList list = Collections.EMPTY_LIST;
		PointerByReference pointerByReference = new PointerByReference();
		IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(paramPointer, paramString, 2, pointerByReference);
		if (pointerByReference.Value != null)
		{
		  int i = IfcEngineInterface_Fields.INSTANCE.sdaiGetMemberCount(pointerByReference.Value);
		  list = new List<object>(i);
		  for (sbyte b = 0; b < i; b++)
		  {
			PointerByReference pointerByReference1 = new PointerByReference();
			IfcEngineInterface_Fields.INSTANCE.engiGetAggrElement(pointerByReference.Value, b, 6, pointerByReference1);
			if (pointerByReference1.Value != null)
			{
			  list.Add(pointerByReference1.Value);
			}
		  }
		}
		return list;
	  }

	  public static IList<Pointer> getSetAttributeOfADBBN(Pointer paramPointer, string paramString)
	  {
		System.Collections.IList list = Collections.EMPTY_LIST;
		PointerByReference pointerByReference = new PointerByReference();
		IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(paramPointer, paramString, 2, pointerByReference);
		if (pointerByReference.Value != null)
		{
		  int i = IfcEngineInterface_Fields.INSTANCE.sdaiGetMemberCount(pointerByReference.Value);
		  list = new List<object>(i);
		  for (sbyte b = 0; b < i; b++)
		  {
			PointerByReference pointerByReference1 = new PointerByReference();
			IfcEngineInterface_Fields.INSTANCE.engiGetAggrElement(pointerByReference.Value, b, 1, pointerByReference1);
			if (pointerByReference1.Value != null)
			{
			  list.Add(pointerByReference1.Value);
			}
		  }
		}
		return list;
	  }

	  public static string getFileSchemaFromSchemaName(string paramString)
	  {
		  return paramString.Equals("IFC2X3") ? Path.GetFullPath(".\\ifcschema\\IFC2X3_TC1.exp") : Path.GetFullPath(".\\ifcschema\\IFC4.exp");
	  }

	  public static string getDescriptionFromHeader(Pointer paramPointer)
	  {
		PointerByReference pointerByReference = new PointerByReference();
		IfcEngineInterface_Fields.INSTANCE.GetSPFFHeaderItem(paramPointer, 0, 0, 10, pointerByReference);
		return "" + pointerByReference.Value.getString(0L);
	  }

	  public static string getImplementationLevelFromHeader(Pointer paramPointer)
	  {
		PointerByReference pointerByReference = new PointerByReference();
		IfcEngineInterface_Fields.INSTANCE.GetSPFFHeaderItem(paramPointer, 1, 0, 10, pointerByReference);
		return "" + pointerByReference.Value.getString(0L);
	  }

	  public static string getNameFromHeader(Pointer paramPointer)
	  {
		PointerByReference pointerByReference = new PointerByReference();
		IfcEngineInterface_Fields.INSTANCE.GetSPFFHeaderItem(paramPointer, 2, 0, 10, pointerByReference);
		return "" + pointerByReference.Value.getString(0L);
	  }

	  public static string getTimestampFromHeader(Pointer paramPointer)
	  {
		PointerByReference pointerByReference = new PointerByReference();
		IfcEngineInterface_Fields.INSTANCE.GetSPFFHeaderItem(paramPointer, 3, 0, 10, pointerByReference);
		return "" + pointerByReference.Value.getString(0L);
	  }

	  public static string getAuthorFromHeader(Pointer paramPointer)
	  {
		PointerByReference pointerByReference = new PointerByReference();
		IfcEngineInterface_Fields.INSTANCE.GetSPFFHeaderItem(paramPointer, 4, 0, 10, pointerByReference);
		return "" + pointerByReference.Value.getString(0L);
	  }

	  public static string getOrganizationFromHeader(Pointer paramPointer)
	  {
		PointerByReference pointerByReference = new PointerByReference();
		IfcEngineInterface_Fields.INSTANCE.GetSPFFHeaderItem(paramPointer, 5, 0, 10, pointerByReference);
		return "" + pointerByReference.Value.getString(0L);
	  }

	  public static string getPreprocessorVersionFromHeader(Pointer paramPointer)
	  {
		PointerByReference pointerByReference = new PointerByReference();
		IfcEngineInterface_Fields.INSTANCE.GetSPFFHeaderItem(paramPointer, 6, 0, 10, pointerByReference);
		return "" + pointerByReference.Value.getString(0L);
	  }

	  public static string getOriginatingSystemFromHeader(Pointer paramPointer)
	  {
		PointerByReference pointerByReference = new PointerByReference();
		IfcEngineInterface_Fields.INSTANCE.GetSPFFHeaderItem(paramPointer, 7, 0, 10, pointerByReference);
		return "" + pointerByReference.Value.getString(0L);
	  }

	  public static string getAuthorizationFromHeader(Pointer paramPointer)
	  {
		PointerByReference pointerByReference = new PointerByReference();
		IfcEngineInterface_Fields.INSTANCE.GetSPFFHeaderItem(paramPointer, 8, 0, 10, pointerByReference);
		return "" + pointerByReference.Value.getString(0L);
	  }

	  public static string getFileSchemaFromHeader(Pointer paramPointer)
	  {
		PointerByReference pointerByReference = new PointerByReference();
		IfcEngineInterface_Fields.INSTANCE.GetSPFFHeaderItem(paramPointer, 9, 0, 10, pointerByReference);
		return "" + pointerByReference.Value.getString(0L);
	  }

	  private static void setUnitType(IfcEngineUnit paramIfcEngineUnit, string paramString)
	  {
		paramIfcEngineUnit.UnitType = paramString;
		if (paramString.Equals(".ABSORBEDDOSEUNIT."))
		{
		  paramIfcEngineUnit.Type = 101;
		}
		else if (paramString.Equals(".AREAUNIT."))
		{
		  paramIfcEngineUnit.Type = 102;
		}
		else if (paramString.Equals(".DOSEEQUIVALENTUNIT."))
		{
		  paramIfcEngineUnit.Type = 103;
		}
		else if (paramString.Equals(".ELECTRICCAPACITANCEUNIT."))
		{
		  paramIfcEngineUnit.Type = 104;
		}
		else if (paramString.Equals(".ELECTRICCHARGEUNIT."))
		{
		  paramIfcEngineUnit.Type = 105;
		}
		else if (paramString.Equals(".ELECTRICCONDUCTANCEUNIT."))
		{
		  paramIfcEngineUnit.Type = 106;
		}
		else if (paramString.Equals(".ELECTRICCURRENTUNIT."))
		{
		  paramIfcEngineUnit.Type = 107;
		}
		else if (paramString.Equals(".ELECTRICRESISTANCEUNIT."))
		{
		  paramIfcEngineUnit.Type = 108;
		}
		else if (paramString.Equals(".ELECTRICVOLTAGEUNIT."))
		{
		  paramIfcEngineUnit.Type = 109;
		}
		else if (paramString.Equals(".ENERGYUNIT."))
		{
		  paramIfcEngineUnit.Type = 110;
		}
		else if (paramString.Equals(".FORCEUNIT."))
		{
		  paramIfcEngineUnit.Type = 111;
		}
		else if (paramString.Equals(".FREQUENCYUNIT."))
		{
		  paramIfcEngineUnit.Type = 112;
		}
		else if (paramString.Equals(".ILLUMINANCEUNIT."))
		{
		  paramIfcEngineUnit.Type = 113;
		}
		else if (paramString.Equals(".INDUCTANCEUNIT."))
		{
		  paramIfcEngineUnit.Type = 114;
		}
		else if (paramString.Equals(".LENGTHUNIT."))
		{
		  paramIfcEngineUnit.Type = 115;
		}
		else if (paramString.Equals(".LUMINOUSFLUXUNIT."))
		{
		  paramIfcEngineUnit.Type = 116;
		}
		else if (paramString.Equals(".LUMINOUSINTENSITYUNIT."))
		{
		  paramIfcEngineUnit.Type = 117;
		}
		else if (paramString.Equals(".MAGNETICFLUXDENSITYUNIT."))
		{
		  paramIfcEngineUnit.Type = 118;
		}
		else if (paramString.Equals(".MAGNETICFLUXUNIT."))
		{
		  paramIfcEngineUnit.Type = 119;
		}
		else if (paramString.Equals(".MASSUNIT."))
		{
		  paramIfcEngineUnit.Type = 120;
		}
		else if (paramString.Equals(".PLANEANGLEUNIT."))
		{
		  paramIfcEngineUnit.Type = 121;
		}
		else if (paramString.Equals(".POWERUNIT."))
		{
		  paramIfcEngineUnit.Type = 122;
		}
		else if (paramString.Equals(".PRESSUREUNIT."))
		{
		  paramIfcEngineUnit.Type = 123;
		}
		else if (paramString.Equals(".RADIOACTIVITYUNIT."))
		{
		  paramIfcEngineUnit.Type = 124;
		}
		else if (paramString.Equals(".SOLIDANGLEUNIT."))
		{
		  paramIfcEngineUnit.Type = 125;
		}
		else if (paramString.Equals(".THERMODYNAMICTEMPERATUREUNIT."))
		{
		  paramIfcEngineUnit.Type = 126;
		}
		else if (paramString.Equals(".TIMEUNIT."))
		{
		  paramIfcEngineUnit.Type = 127;
		}
		else if (paramString.Equals(".RADIOACTIVITYUNIT."))
		{
		  paramIfcEngineUnit.Type = 124;
		}
		else if (paramString.Equals(".VOLUMEUNIT."))
		{
		  paramIfcEngineUnit.Type = 128;
		}
		else if (paramString.Equals(".USERDEFINED."))
		{
		  paramIfcEngineUnit.Type = 129;
		}
		else
		{
		  Console.Error.WriteLine("IFCWARN: Unit Type not listed: " + paramString);
		}
	  }

	  private static void setUnitPrefix(IfcEngineUnit paramIfcEngineUnit, string paramString)
	  {
		if (StringUtils.checkEquality(paramString, ""))
		{
		  paramIfcEngineUnit.setPrefix("", 1.0D);
		}
		else if (StringUtils.checkEquality(paramString, ".EXA."))
		{
		  paramIfcEngineUnit.setPrefix("Exa", 24.0D);
		}
		else if (StringUtils.checkEquality(paramString, ".PETA."))
		{
		  paramIfcEngineUnit.setPrefix("Peta", 5.0D);
		}
		else if (StringUtils.checkEquality(paramString, ".TERA."))
		{
		  paramIfcEngineUnit.setPrefix("Tera", 6.0D);
		}
		else if (StringUtils.checkEquality(paramString, ".GIGA."))
		{
		  paramIfcEngineUnit.setPrefix("Giga", 1.0E9D);
		}
		else if (StringUtils.checkEquality(paramString, ".MEGA."))
		{
		  paramIfcEngineUnit.setPrefix("Mega", 1000000.0D);
		}
		else if (StringUtils.checkEquality(paramString, ".KILO."))
		{
		  paramIfcEngineUnit.setPrefix("Kilo", 1000.0D);
		}
		else if (StringUtils.checkEquality(paramString, ".HECTO."))
		{
		  paramIfcEngineUnit.setPrefix("Hecto", 10.0D);
		}
		else if (StringUtils.checkEquality(paramString, ".DECA."))
		{
		  paramIfcEngineUnit.setPrefix("Deca", 10.0D);
		}
		else if (StringUtils.checkEquality(paramString, ".DECI."))
		{
		  paramIfcEngineUnit.setPrefix("Deci", 0.1D);
		}
		else if (StringUtils.checkEquality(paramString, ".CENTI."))
		{
		  paramIfcEngineUnit.setPrefix("Centi", 0.01D);
		}
		else if (StringUtils.checkEquality(paramString, ".MILLI."))
		{
		  paramIfcEngineUnit.setPrefix("Milli", 0.001D);
		}
		else if (StringUtils.checkEquality(paramString, ".MICRO."))
		{
		  paramIfcEngineUnit.setPrefix("Micro", 1.0E-6D);
		}
		else if (StringUtils.checkEquality(paramString, ".NANO."))
		{
		  paramIfcEngineUnit.setPrefix("Nano", 1.0E-9D);
		}
		else if (StringUtils.checkEquality(paramString, ".PICO."))
		{
		  paramIfcEngineUnit.setPrefix("Pico", 1.0E-12D);
		}
		else if (StringUtils.checkEquality(paramString, ".FEMTO."))
		{
		  paramIfcEngineUnit.setPrefix("Femto", 1.0E-15D);
		}
		else if (StringUtils.checkEquality(paramString, ".ATTO."))
		{
		  paramIfcEngineUnit.setPrefix("Atto", 1.0E-18D);
		}
		else
		{
		  paramIfcEngineUnit.setPrefix(paramString, 1.0D);
		  Console.Error.WriteLine("IFCWARN: Unit Prefix not listed: " + paramString);
		}
	  }

	  private static void setUnitName(IfcEngineUnit paramIfcEngineUnit, string paramString)
	  {
		paramIfcEngineUnit.Name = paramString;
		if (StringUtils.checkEquality(paramString, ".AMPERE."))
		{
		  paramIfcEngineUnit.Name = "Ampere";
		}
		else if (StringUtils.checkEquality(paramString, ".BECQUEREL."))
		{
		  paramIfcEngineUnit.Name = "Becquere";
		}
		else if (StringUtils.checkEquality(paramString, ".CANDELA."))
		{
		  paramIfcEngineUnit.Name = "Candela";
		}
		else if (StringUtils.checkEquality(paramString, ".COULOMB."))
		{
		  paramIfcEngineUnit.Name = "Coulomb";
		}
		else if (StringUtils.checkEquality(paramString, ".CUBIC_METRE."))
		{
		  paramIfcEngineUnit.Name = "Cubic Metre";
		}
		else if (StringUtils.checkEquality(paramString, ".DEGREE_CELSIUS."))
		{
		  paramIfcEngineUnit.Name = "Degree Celcius";
		}
		else if (StringUtils.checkEquality(paramString, ".FARAD."))
		{
		  paramIfcEngineUnit.Name = "Farad";
		}
		else if (StringUtils.checkEquality(paramString, ".GRAM."))
		{
		  paramIfcEngineUnit.Name = "Gram";
		}
		else if (StringUtils.checkEquality(paramString, ".GRAY."))
		{
		  paramIfcEngineUnit.Name = "Gray";
		}
		else if (StringUtils.checkEquality(paramString, ".HENRY."))
		{
		  paramIfcEngineUnit.Name = "Henry";
		}
		else if (StringUtils.checkEquality(paramString, ".HERTZ."))
		{
		  paramIfcEngineUnit.Name = "Hertz";
		}
		else if (StringUtils.checkEquality(paramString, ".JOULE."))
		{
		  paramIfcEngineUnit.Name = "Joule";
		}
		else if (StringUtils.checkEquality(paramString, ".KELVIN."))
		{
		  paramIfcEngineUnit.Name = "Kelvin";
		}
		else if (StringUtils.checkEquality(paramString, ".LUMEN."))
		{
		  paramIfcEngineUnit.Name = "Lumen";
		}
		else if (StringUtils.checkEquality(paramString, ".LUX."))
		{
		  paramIfcEngineUnit.Name = "Lux";
		}
		else if (StringUtils.checkEquality(paramString, ".METRE."))
		{
		  paramIfcEngineUnit.Name = "Metre";
		}
		else if (StringUtils.checkEquality(paramString, ".MOLE."))
		{
		  paramIfcEngineUnit.Name = "Mole";
		}
		else if (StringUtils.checkEquality(paramString, ".NEWTON."))
		{
		  paramIfcEngineUnit.Name = "Newton";
		}
		else if (StringUtils.checkEquality(paramString, ".OHM."))
		{
		  paramIfcEngineUnit.Name = "Ohm";
		}
		else if (StringUtils.checkEquality(paramString, ".PASCAL."))
		{
		  paramIfcEngineUnit.Name = "Pasca";
		}
		else if (StringUtils.checkEquality(paramString, ".RADIAN."))
		{
		  paramIfcEngineUnit.Name = "Radian";
		}
		else if (StringUtils.checkEquality(paramString, ".SECOND."))
		{
		  paramIfcEngineUnit.Name = "Second";
		}
		else if (StringUtils.checkEquality(paramString, ".SIEMENS."))
		{
		  paramIfcEngineUnit.Name = "Siemens";
		}
		else if (StringUtils.checkEquality(paramString, ".SIEVERT."))
		{
		  paramIfcEngineUnit.Name = "Sievert";
		}
		else if (StringUtils.checkEquality(paramString, ".SQUARE_METRE."))
		{
		  paramIfcEngineUnit.Name = "Square Metre";
		}
		else if (StringUtils.checkEquality(paramString, ".STERADIAN."))
		{
		  paramIfcEngineUnit.Name = "Steradian";
		}
		else if (StringUtils.checkEquality(paramString, ".TESLA."))
		{
		  paramIfcEngineUnit.Name = "Tesla";
		}
		else if (StringUtils.checkEquality(paramString, ".VOLT."))
		{
		  paramIfcEngineUnit.Name = "Volt";
		}
		else if (StringUtils.checkEquality(paramString, ".WATT."))
		{
		  paramIfcEngineUnit.Name = "Watt";
		}
		else if (StringUtils.checkEquality(paramString, ".WEBER."))
		{
		  paramIfcEngineUnit.Name = "Weber";
		}
		else
		{
		  paramIfcEngineUnit.Name = paramString;
		  Console.Error.WriteLine("IFCWARN: Unit name not listed: " + paramString);
		}
	  }

	  public static IList<IfcEngineUnit> loadIfcEngineUnits(Pointer paramPointer1, Pointer paramPointer2)
	  {
		LinkedList linkedList = new LinkedList();
		PointerByReference pointerByReference1 = new PointerByReference();
		int i = IfcEngineInterface_Fields.INSTANCE.internalGetP21Line(paramPointer2);
		IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(paramPointer2, "UnitsInContext", 6, pointerByReference1);
		Pointer pointer1 = IfcEngineInterface_Fields.INSTANCE.sdaiGetEntity(paramPointer1, "IFCCONVERSIONBASEDUNIT");
		Pointer pointer2 = IfcEngineInterface_Fields.INSTANCE.sdaiGetEntity(paramPointer1, "IFCSIUNIT");
		PointerByReference pointerByReference2 = new PointerByReference();
		int j = 0;
		IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(pointerByReference1.Value, "Units", 2, pointerByReference2);
		j = IfcEngineInterface_Fields.INSTANCE.sdaiGetMemberCount(pointerByReference2.Value);
		for (sbyte b = 0; b < j; b++)
		{
		  PointerByReference pointerByReference = new PointerByReference();
		  IfcEngineInterface_Fields.INSTANCE.engiGetAggrElement(pointerByReference2.Value, b, 6, pointerByReference);
		  if (IfcEngineInterface_Fields.INSTANCE.sdaiGetInstanceType(pointerByReference.Value).ToString().Equals(pointer1.ToString()))
		  {
			IfcEngineUnit ifcEngineUnit = new IfcEngineUnit();
			PointerByReference pointerByReference3 = new PointerByReference();
			IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(pointerByReference.Value, "ConversionFactor", 6, pointerByReference3);
			if (pointerByReference3.Value != null)
			{
			  PointerByReference pointerByReference4 = new PointerByReference();
			  PointerByReference pointerByReference5 = new PointerByReference();
			  IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(pointerByReference3.Value, "ValueComponent", 1, pointerByReference5);
			  DoubleByReference doubleByReference = new DoubleByReference();
			  IfcEngineInterface_Fields.INSTANCE.sdaiGetADBValue(pointerByReference5.Value, 9, doubleByReference);
			  double d = doubleByReference.Value;
			  IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(pointerByReference3.Value, "UnitComponent", 6, pointerByReference4);
			  if (IfcEngineInterface_Fields.INSTANCE.sdaiGetInstanceType(pointerByReference4.Value).ToString().Equals(pointer2.ToString()))
			  {
				PointerByReference pointerByReference6 = new PointerByReference();
				PointerByReference pointerByReference7 = new PointerByReference();
				PointerByReference pointerByReference8 = new PointerByReference();
				IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(pointerByReference4.Value, "UnitType", 10, pointerByReference6);
				IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(pointerByReference4.Value, "Prefix", 10, pointerByReference7);
				IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(pointerByReference4.Value, "Name", 10, pointerByReference8);
				string str1 = (pointerByReference6 != null && pointerByReference6.Value != null) ? pointerByReference6.Value.getString(0L) : "";
				string str2 = (pointerByReference7 != null && pointerByReference7.Value != null) ? pointerByReference7.Value.getString(0L) : "";
				string str3 = (pointerByReference8 != null && pointerByReference8.Value != null) ? pointerByReference8.Value.getString(0L) : "";
				setUnitType(ifcEngineUnit, str1);
				setUnitPrefix(ifcEngineUnit, str2);
				setUnitName(ifcEngineUnit, str3);
				ifcEngineUnit.ConversionFactor = ifcEngineUnit.ConversionFactor * d;
				linkedList.AddLast(ifcEngineUnit);
			  }
			  else
			  {
				Console.Error.WriteLine("IFCERROR: Load Units 1");
			  }
			}
			else
			{
			  Console.Error.WriteLine("IFCERROR: Load Units 2");
			}
		  }
		  else if (IfcEngineInterface_Fields.INSTANCE.sdaiGetInstanceType(pointerByReference.Value).ToString().Equals(pointer2.ToString()))
		  {
			IfcEngineUnit ifcEngineUnit = new IfcEngineUnit();
			PointerByReference pointerByReference3 = new PointerByReference();
			PointerByReference pointerByReference4 = new PointerByReference();
			PointerByReference pointerByReference5 = new PointerByReference();
			IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(pointerByReference.Value, "UnitType", 10, pointerByReference3);
			IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(pointerByReference.Value, "Prefix", 10, pointerByReference4);
			IfcEngineInterface_Fields.INSTANCE.sdaiGetAttrBN(pointerByReference.Value, "Name", 10, pointerByReference5);
			string str1 = (pointerByReference3 != null && pointerByReference3.Value != null) ? pointerByReference3.Value.getString(0L) : "";
			string str2 = (pointerByReference4 != null && pointerByReference4.Value != null) ? pointerByReference4.Value.getString(0L) : "";
			string str3 = (pointerByReference5 != null && pointerByReference5.Value != null) ? pointerByReference5.Value.getString(0L) : "";
			setUnitType(ifcEngineUnit, str1);
			setUnitPrefix(ifcEngineUnit, str2);
			setUnitName(ifcEngineUnit, str3);
			linkedList.AddLast(ifcEngineUnit);
		  }
		  else
		  {
			Console.Error.WriteLine("IFCERROR: Load Units 3");
		  }
		}
		return linkedList;
	  }

	  public static double getVolume(Pointer paramPointer)
	  {
		  return IfcEngineInterface_Fields.INSTANCE.GetVolume(paramPointer, null, null);
	  }

	  public static double getArea(Pointer paramPointer)
	  {
		  return IfcEngineInterface_Fields.INSTANCE.GetArea(paramPointer, null, null);
	  }

	  public static double getPerimeter(Pointer paramPointer)
	  {
		  return IfcEngineInterface_Fields.INSTANCE.GetPerimeter(paramPointer);
	  }

	  public static bool findBooleanProperty(IList<BIMPropertySet> paramList, string paramString)
	  {
		foreach (BIMPropertySet bIMPropertySet in paramList)
		{
		  foreach (BIMProperty bIMProperty in bIMPropertySet.Properties)
		  {
			if (!bIMProperty.Number && bIMProperty.Name.Equals(paramString))
			{
			  return Boolean.getBoolean(bIMProperty.Value);
			}
		  }
		}
		return false;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\ifc\IfcEngineUtils.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}