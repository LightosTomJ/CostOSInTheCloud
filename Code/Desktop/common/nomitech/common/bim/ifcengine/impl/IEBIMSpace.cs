using System;

namespace Desktop.common.nomitech.common.bim.ifcengine.impl
{
	using Pointer = com.sun.jna.Pointer;
	using ElementTable  = Desktop.common.nomitech..bimengine.model.data.ElementTable;
	using BIMQTOType  = Desktop.common.nomitech..bimengine.types.BIMQTOType;
	using IfcEngineGeometryData  = Desktop.common.nomitech..common.ifc.IfcEngineGeometryData;
	using IfcEngineQuantitiesData  = Desktop.common.nomitech..common.ifc.IfcEngineQuantitiesData;
	using IfcEngineUtils  = Desktop.common.nomitech..common.ifc.IfcEngineUtils;
	using IfcEnginePropertiesData  = Desktop.common.nomitech..ifcengine.loaders.IfcEnginePropertiesData;
	using BIMPropertySet  = Desktop.common.nomitech..ifcengine.props.BIMPropertySet;

	public class IEBIMSpace : BIMSpace
	{
	  public static readonly EnumSet<BIMQTOType> QUANTITIES = EnumSet.of(BIMQTOType.TOP_ELEVATION, new BIMQTOType[] {BIMQTOType.BOTTOM_ELEVATION, BIMQTOType.NET_VOLUME, BIMQTOType.FOOTPRINT_NET_AREA, BIMQTOType.HEIGHT, BIMQTOType.LENGTH, BIMQTOType.DOORS_AREA, BIMQTOType.WINDOWS_AREA, BIMQTOType.VOIDS_AREA, BIMQTOType.OPENINGS_AREA});

	  private static Color SPACE_COLOR = new Color(238, 232, 170);

	  public IEBIMSpace(Pointer paramPointer, BIMBuildingStorey paramBIMBuildingStorey, IfcEnginePropertiesData paramIfcEnginePropertiesData, IfcEngineGeometryData paramIfcEngineGeometryData, IfcEngineQuantitiesData paramIfcEngineQuantitiesData)
	  {
		Id = Convert.ToInt64(-1L);
		string str1 = IfcEngineUtils.getStringAttributeBN(paramPointer, "GlobalId");
		string str2 = IfcEngineUtils.getStringAttributeBN(paramPointer, "Name");
		if (paramIfcEngineGeometryData.AmbientColor == null)
		{
		  Color = SPACE_COLOR;
		}
		else
		{
		  Color = paramIfcEngineGeometryData.AmbientColor;
		}
		Transform3D = new Transform3D();
		BIMGeometry = new BIMGeometry(paramIfcEngineGeometryData);
		Label = str2;
		GlobalId = str1;
		BimToolId = str1;
		TopElevation = paramIfcEngineQuantitiesData.TopElevation;
		TopElevationQT = BIMQuantityType.QTY_MILLI_METER;
		BottomElevation = paramIfcEngineQuantitiesData.BottomElevation;
		BottomElevationQT = BIMQuantityType.QTY_MILLI_METER;
		LastUpdate = DateTime.Now;
		Volume = paramIfcEngineQuantitiesData.NetVolume;
		VolumeQT = BIMQuantityType.QTY_CUBIC_METER;
		Perimeter = paramIfcEngineQuantitiesData.Perimeter;
		PerimeterQT = BIMQuantityType.QTY_MILLI_METER;
		AreaOfWindows = paramIfcEngineQuantitiesData.AreaOfWindows;
		AreaOfWindowsQT = BIMQuantityType.QTY_SQUARE_METER;
		AreaOfDoors = paramIfcEngineQuantitiesData.AreaOfDoors;
		AreaOfDoorsQT = BIMQuantityType.QTY_SQUARE_METER;
		Height = paramIfcEngineQuantitiesData.Height;
		HeightQT = BIMQuantityType.QTY_MILLI_METER;
		Area = paramIfcEngineQuantitiesData.FootprintGrossArea;
		AreaQT = BIMQuantityType.QTY_SQUARE_METER;
		System.Collections.IList list = paramIfcEnginePropertiesData.PropSetList;
		BIMPropertySet bIMPropertySet = BIMExtensionPropertiesUtil.createPropertySet("CalcQuantities");
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcArea", AreaQT, Area));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcHeight", HeightQT, Height));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcVolume", VolumeQT, Volume));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcPerimeter", PerimeterQT, Perimeter));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcPiece", 0, 1.0D));
		list.Insert(0, bIMPropertySet);
		ExtensionProperties = paramIfcEnginePropertiesData.PropSetList;
		Storey = paramBIMBuildingStorey;
	  }

	  public IEBIMSpace(ElementTable paramElementTable, IfcEnginePropertiesData paramIfcEnginePropertiesData, IfcEngineQuantitiesData paramIfcEngineQuantitiesData)
	  {
		Id = paramElementTable.ElementId;
		Name = paramElementTable.Name;
		Label = paramElementTable.Name;
		GlobalId = paramElementTable.GlobalId;
		BimToolId = paramElementTable.TagId;
		TopElevation = paramIfcEngineQuantitiesData.TopElevation;
		TopElevationQT = BIMQuantityType.QTY_MILLI_METER;
		BottomElevation = paramIfcEngineQuantitiesData.BottomElevation;
		BottomElevationQT = BIMQuantityType.QTY_MILLI_METER;
		LastUpdate = DateTime.Now;
		Volume = paramIfcEngineQuantitiesData.NetVolume;
		VolumeQT = BIMQuantityType.QTY_CUBIC_METER;
		System.Collections.IList list = paramIfcEnginePropertiesData.PropSetList;
		BIMPropertySet bIMPropertySet = BIMExtensionPropertiesUtil.createPropertySet("CalcQuantities");
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcArea", AreaQT, Area));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcHeight", HeightQT, Height));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcVolume", VolumeQT, Volume));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcPerimeter", PerimeterQT, Perimeter));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcPiece", 0, 1.0D));
		list.Insert(0, bIMPropertySet);
		ExtensionProperties = paramIfcEnginePropertiesData.PropSetList;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\ifcengine\impl\IEBIMSpace.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}