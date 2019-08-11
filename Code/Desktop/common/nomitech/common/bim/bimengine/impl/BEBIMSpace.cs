using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim.bimengine.impl
{
	using StringUtils = nomitech.bimengine.util.StringUtils;
	using BIMExtensionPropertiesUtil = nomitech.common.bim.ifcengine.BIMExtensionPropertiesUtil;
	using IfcEnginePropertiesData = nomitech.common.ifc.IfcEnginePropertiesData;
	using IfcEngineQuantitiesData = nomitech.common.ifc.IfcEngineQuantitiesData;
	using BIMPropertySet = nomitech.ifcengine.props.BIMPropertySet;

	public class BEBIMSpace : BIMSpace
	{
	  public BEBIMSpace(object[] paramArrayOfObject, IfcEngineQuantitiesData paramIfcEngineQuantitiesData, IfcEnginePropertiesData paramIfcEnginePropertiesData)
	  {
		Id = (long?)paramArrayOfObject[0];
		GlobalId = (string)paramArrayOfObject[1];
		string str = (string)paramArrayOfObject[3];
		if (StringUtils.isNullOrBlank(str))
		{
		  Name = "Space";
		}
		else
		{
		  Name = str;
		}
		Label = Name;
		BimToolId = "";
		TopElevation = 0.0D;
		TopElevationQT = 1;
		BottomElevation = 0.0D;
		BottomElevationQT = 1;
		LastUpdate = DateTime.Now;
		Height = 0.0D;
		HeightQT = 0;
		BimToolId = (string)paramArrayOfObject[4];
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
		BuildingElements = new LinkedList();
		Children = new LinkedList();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\bimengine\impl\BEBIMSpace.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}