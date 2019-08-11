using System;

namespace Desktop.common.nomitech.common.bim.ifcengine.impl
{
	using ElementTable  = Desktop.common.nomitech..bimengine.model.data.ElementTable;
	using IfcEngineQuantitiesData  = Desktop.common.nomitech..common.ifc.IfcEngineQuantitiesData;
	using IfcEnginePropertiesData  = Desktop.common.nomitech..ifcengine.loaders.IfcEnginePropertiesData;
	using BIMPropertySet  = Desktop.common.nomitech..ifcengine.props.BIMPropertySet;

	public class IEBIMDoor : BIMDoor
	{
	  public IEBIMDoor(ElementTable paramElementTable, IfcEnginePropertiesData paramIfcEnginePropertiesData, IfcEngineQuantitiesData paramIfcEngineQuantitiesData)
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
		Height = paramIfcEngineQuantitiesData.Height;
		HeightQT = BIMQuantityType.QTY_MILLI_METER;
		Width = paramIfcEngineQuantitiesData.Length;
		WidthQT = BIMQuantityType.QTY_MILLI_METER;
		Area = Height / 1000.0D * Width / 1000.0D;
		AreaQT = BIMQuantityType.QTY_SQUARE_METER;
		Perimeter = (Height + Width) * 2.0D;
		PerimeterQT = HeightQT;
		Layer = paramIfcEnginePropertiesData.Layer;
		System.Collections.IList list = paramIfcEnginePropertiesData.PropSetList;
		BIMPropertySet bIMPropertySet = BIMExtensionPropertiesUtil.createPropertySet("CalcQuantities");
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcArea", AreaQT, Area));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcHeight", HeightQT, Height));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcWidth", WidthQT, Width));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcPerimeter", PerimeterQT, Perimeter));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcPiece", 0, 1.0D));
		list.Insert(0, bIMPropertySet);
		ExtensionProperties = list;
		Architecture = true;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\ifcengine\impl\IEBIMDoor.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}