using System;

namespace Desktop.common.nomitech.common.bim.ifcengine.impl
{
	using ElementTable  = Desktop.common.nomitech..bimengine.model.data.ElementTable;
	using BIMQTOType  = Desktop.common.nomitech..bimengine.types.BIMQTOType;
	using StringUtils  = Desktop.common.nomitech..bimengine.util.StringUtils;
	using IfcEngineQuantitiesData  = Desktop.common.nomitech..common.ifc.IfcEngineQuantitiesData;
	using IfcEnginePropertiesData  = Desktop.common.nomitech..ifcengine.loaders.IfcEnginePropertiesData;
	using BIMPropertySet  = Desktop.common.nomitech..ifcengine.props.BIMPropertySet;

	public class IEBIMObject : BIMObject
	{
	  public IEBIMObject(ElementTable paramElementTable, IfcEngineQuantitiesData paramIfcEngineQuantitiesData, IfcEnginePropertiesData paramIfcEnginePropertiesData)
	  {
		Id = paramElementTable.ElementId;
		GlobalId = paramElementTable.GlobalId;
		string str1 = paramElementTable.Name;
		if (StringUtils.isNullOrBlank(str1))
		{
		  Name = "Space";
		}
		else
		{
		  Name = str1;
		}
		string str2 = paramElementTable.TagId;
		string str3 = paramIfcEnginePropertiesData.Material;
		string str4 = paramIfcEnginePropertiesData.Type;
		string str5 = paramIfcEnginePropertiesData.Layer;
		paramIfcEnginePropertiesData.Material = str3;
		paramIfcEnginePropertiesData.Type = str4;
		paramIfcEnginePropertiesData.Layer = str5;
		Material = paramIfcEnginePropertiesData.Material;
		Type = paramIfcEnginePropertiesData.Type;
		Layer = paramIfcEnginePropertiesData.Layer;
		Name = str1;
		Label = str1;
		BimToolId = str2;
		TopElevation = paramIfcEngineQuantitiesData.TopElevation;
		TopElevationQT = BIMQuantityType.QTY_MILLI_METER;
		BottomElevation = paramIfcEngineQuantitiesData.BottomElevation;
		BottomElevationQT = BIMQuantityType.QTY_MILLI_METER;
		LastUpdate = DateTime.Now;
		Volume = paramIfcEngineQuantitiesData.NetVolume;
		VolumeQT = BIMQuantityType.QTY_CUBIC_METER;
		System.Collections.IList list = paramIfcEnginePropertiesData.PropSetList;
		BIMPropertySet bIMPropertySet = BIMExtensionPropertiesUtil.createPropertySet("CalcQuantities");
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcVolume", VolumeQT, Volume));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcPiece", 0, 1.0D));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcFootprintArea", BIMQuantityType.QTY_SQUARE_METER, paramIfcEngineQuantitiesData.getQuantity(BIMQTOType.FOOTPRINT_NET_AREA).doubleValue()));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcHeight", BIMQuantityType.QTY_MILLI_METER, paramIfcEngineQuantitiesData.getQuantity(BIMQTOType.HEIGHT).doubleValue()));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcWidth", BIMQuantityType.QTY_MILLI_METER, paramIfcEngineQuantitiesData.getQuantity(BIMQTOType.WIDTH).doubleValue()));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcLength", BIMQuantityType.QTY_MILLI_METER, paramIfcEngineQuantitiesData.getQuantity(BIMQTOType.LENGTH).doubleValue()));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcNetArea", BIMQuantityType.QTY_SQUARE_METER, paramIfcEngineQuantitiesData.getQuantity(BIMQTOType.SIDE_NET_AREA).doubleValue()));
		list.Insert(0, bIMPropertySet);
		ExtensionProperties = list;
		Architecture = true;
		Structural = true;
		Landscaping = true;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\ifcengine\impl\IEBIMObject.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}