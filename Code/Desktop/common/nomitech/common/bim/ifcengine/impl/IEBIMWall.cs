using System;

namespace Desktop.common.nomitech.common.bim.ifcengine.impl
{
	using ElementTable  = Desktop.common.nomitech..bimengine.model.data.ElementTable;
	using BIMQTOType  = Desktop.common.nomitech..bimengine.types.BIMQTOType;
	using IfcEngineQuantitiesData  = Desktop.common.nomitech..common.ifc.IfcEngineQuantitiesData;
	using IfcEnginePropertiesData  = Desktop.common.nomitech..ifcengine.loaders.IfcEnginePropertiesData;
	using BIMPropertySet  = Desktop.common.nomitech..ifcengine.props.BIMPropertySet;

	public class IEBIMWall : BIMWall
	{
	  public IEBIMWall(ElementTable paramElementTable, IfcEnginePropertiesData paramIfcEnginePropertiesData, IfcEngineQuantitiesData paramIfcEngineQuantitiesData)
	  {
		Id = paramElementTable.ElementId;
		Material = paramElementTable.ElementInfo.Material;
		Type = paramElementTable.ElementInfo.Type;
		Layer = paramIfcEnginePropertiesData.Layer;
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
		Thickness = paramIfcEngineQuantitiesData.Width;
		ThicknessQT = BIMQuantityType.QTY_MILLI_METER;
		AreaOfWindows = paramIfcEngineQuantitiesData.AreaOfWindows;
		AreaOfWindowsQT = BIMQuantityType.QTY_SQUARE_METER;
		AreaOfDoors = paramIfcEngineQuantitiesData.AreaOfDoors;
		AreaOfDoorsQT = BIMQuantityType.QTY_SQUARE_METER;
		AreaOfOpenings = paramIfcEngineQuantitiesData.AreaOfVoids;
		AreaOfOpeningsQT = BIMQuantityType.QTY_SQUARE_METER;
		BottomArea = paramIfcEngineQuantitiesData.FootprintNetArea;
		BottomAreaQT = BIMQuantityType.QTY_SQUARE_METER;
		Height = paramIfcEngineQuantitiesData.Height;
		HeightQT = BIMQuantityType.QTY_MILLI_METER;
		Length = paramIfcEngineQuantitiesData.Length;
		LengthQT = BIMQuantityType.QTY_MILLI_METER;
		Area = paramIfcEngineQuantitiesData.getQuantity(BIMQTOType.SIDE_NET_AREA).doubleValue();
		AreaQT = BIMQuantityType.QTY_SQUARE_METER;
		GrossArea = paramIfcEngineQuantitiesData.getQuantity(BIMQTOType.SIDE_GROSS_AREA).doubleValue();
		GrossAreaQT = BIMQuantityType.QTY_SQUARE_METER;
		External = paramIfcEnginePropertiesData.External;
		System.Collections.IList list = paramIfcEnginePropertiesData.PropSetList;
		BIMPropertySet bIMPropertySet = BIMExtensionPropertiesUtil.createPropertySet("CalcQuantities");
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcNetArea", AreaQT, Area));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcGrossArea", GrossAreaQT, GrossArea));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcFootprintArea", BottomAreaQT, BottomArea));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcFootprintGrossArea", BottomAreaQT, paramIfcEngineQuantitiesData.getQuantity(BIMQTOType.FOOTPRINT_GROSS_AREA).doubleValue()));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcAreaOfDoors", AreaOfDoorsQT, AreaOfDoors));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcAreaOfWindows", AreaOfWindowsQT, AreaOfWindows));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcAreaOfOpenings", AreaOfOpeningsQT, AreaOfOpenings));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcVolume", VolumeQT, Volume));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcGrossVolume", VolumeQT, paramIfcEngineQuantitiesData.getQuantity(BIMQTOType.GROSS_VOLUME).doubleValue()));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcHeight", HeightQT, Height));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcLength", LengthQT, Length));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcThickness", ThicknessQT, Thickness));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcPiece", 0, 1.0D));
		list.Insert(0, bIMPropertySet);
		ExtensionProperties = list;
		Architecture = true;
		Structural = true;
		Landscaping = true;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\ifcengine\impl\IEBIMWall.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}