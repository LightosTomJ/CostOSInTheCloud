using System;

namespace Desktop.common.nomitech.common.bim.ifcengine.impl
{
	using ElementTable  = Desktop.common.nomitech..bimengine.model.data.ElementTable;
	using BIMQTOType  = Desktop.common.nomitech..bimengine.types.BIMQTOType;
	using IfcEngineQuantitiesData  = Desktop.common.nomitech..common.ifc.IfcEngineQuantitiesData;
	using IfcEnginePropertiesData  = Desktop.common.nomitech..ifcengine.loaders.IfcEnginePropertiesData;
	using BIMPropertySet  = Desktop.common.nomitech..ifcengine.props.BIMPropertySet;

	public class IEBIMSlab : BIMSlab
	{
	  public IEBIMSlab(ElementTable paramElementTable, IfcEnginePropertiesData paramIfcEnginePropertiesData, IfcEngineQuantitiesData paramIfcEngineQuantitiesData)
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
		Area = paramIfcEngineQuantitiesData.FootprintNetArea;
		AreaQT = BIMQuantityType.QTY_SQUARE_METER;
		GrossArea = paramIfcEngineQuantitiesData.FootprintGrossArea;
		GrossAreaQT = BIMQuantityType.QTY_SQUARE_METER;
		AreaOfOpenings = paramIfcEngineQuantitiesData.AreaOfOpenings;
		AreaOfOpeningsQT = BIMQuantityType.QTY_SQUARE_METER;
		Perimeter = paramIfcEngineQuantitiesData.Perimeter;
		PerimeterQT = BIMQuantityType.QTY_MILLI_METER;
		PerimeterOfOpenings = paramIfcEngineQuantitiesData.PerimeterOfOpenings;
		PerimeterOfOpeningsQT = BIMQuantityType.QTY_MILLI_METER;
		Thickness = paramIfcEngineQuantitiesData.Height;
		ThicknessQT = BIMQuantityType.QTY_MILLI_METER;
		Volume = paramIfcEngineQuantitiesData.NetVolume;
		VolumeQT = BIMQuantityType.QTY_CUBIC_METER;
		Layer = paramIfcEnginePropertiesData.Layer;
		System.Collections.IList list = paramIfcEnginePropertiesData.PropSetList;
		BIMPropertySet bIMPropertySet = BIMExtensionPropertiesUtil.createPropertySet("CalcQuantities");
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcArea", AreaQT, Area));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcGrossArea", GrossAreaQT, GrossArea));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcAreaOfOpenings", AreaOfOpeningsQT, AreaOfOpenings));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcVolume", VolumeQT, Volume));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcGrossVolume", VolumeQT, paramIfcEngineQuantitiesData.getQuantity(BIMQTOType.GROSS_VOLUME).doubleValue()));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcPerimeter", PerimeterQT, Perimeter));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcThickness", ThicknessQT, Thickness));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcPerimeterOfOpenings", PerimeterOfOpeningsQT, PerimeterOfOpenings));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcFormworkVerticalArea", AreaQT, (Perimeter + PerimeterOfOpenings) / 1000.0D * Thickness / 1000.0D));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcPiece", 0, 1.0D));
		list.Insert(0, bIMPropertySet);
		ExtensionProperties = list;
		Architecture = true;
		Structural = true;
		Landscaping = true;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\ifcengine\impl\IEBIMSlab.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}