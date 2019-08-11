using System;

namespace Desktop.common.nomitech.common.bim.bimengine.impl
{
	using BIMExtensionPropertiesUtil = nomitech.common.bim.ifcengine.BIMExtensionPropertiesUtil;
	using IfcEnginePropertiesData = nomitech.common.ifc.IfcEnginePropertiesData;
	using IfcEngineQuantitiesData = nomitech.common.ifc.IfcEngineQuantitiesData;
	using BIMPropertySet = nomitech.ifcengine.props.BIMPropertySet;

	public class BEBIMColumn : BIMColumn
	{
	  public BEBIMColumn(object[] paramArrayOfObject, IfcEngineQuantitiesData paramIfcEngineQuantitiesData, IfcEnginePropertiesData paramIfcEnginePropertiesData)
	  {
		Id = (long?)paramArrayOfObject[0];
		GlobalId = (string)paramArrayOfObject[1];
		string str1 = (string)paramArrayOfObject[3];
		string str2 = (string)paramArrayOfObject[5];
		string str3 = (string)paramArrayOfObject[9];
		string str4 = (string)paramArrayOfObject[10];
		string str5 = (string)paramArrayOfObject[11];
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
		BottomArea = paramIfcEngineQuantitiesData.FootprintNetArea;
		BottomAreaQT = BIMQuantityType.QTY_SQUARE_METER;
		Height = paramIfcEngineQuantitiesData.Height;
		HeightQT = BIMQuantityType.QTY_MILLI_METER;
		double d1 = paramIfcEngineQuantitiesData.Length;
		double d2 = paramIfcEngineQuantitiesData.Width;
		double d3 = d1;
		if ((int)d1 >= (int)d2)
		{
		  d3 = d2;
		}
		Diameter = d3;
		DiameterQT = BIMQuantityType.QTY_MILLI_METER;
		CrossSectionHeight = d1;
		CrossSectionHeightQT = BIMQuantityType.QTY_MILLI_METER;
		CrossSectionWidth = d2;
		CrossSectionWidthQT = BIMQuantityType.QTY_MILLI_METER;
		System.Collections.IList list = paramIfcEnginePropertiesData.PropSetList;
		BIMPropertySet bIMPropertySet = BIMExtensionPropertiesUtil.createPropertySet("CalcQuantities");
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcFootprintArea", BottomAreaQT, BottomArea));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcVolume", VolumeQT, Volume));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcHeight", HeightQT, Height));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcCrossSectionHeight", CrossSectionHeightQT, CrossSectionHeight));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcCrossSectionWidth", CrossSectionWidthQT, CrossSectionWidth));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcPiece", 0, 1.0D));
		bool @bool = false;
		if ((int)CrossSectionHeight == (int)CrossSectionWidth)
		{
		  double d4 = CrossSectionHeight / 1000.0D * CrossSectionWidth / 1000.0D;
		  double d5 = 0.9D * BottomArea;
		  double d6 = 1.1D * BottomArea;
		  if (d4 > d5 && d4 < d6)
		  {
			@bool = true;
		  }
		}
		else
		{
		  @bool = true;
		}
		if (@bool)
		{
		  bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcFormworkArea", BottomAreaQT, (2.0D * CrossSectionHeight / 1000.0D + CrossSectionWidth / 1000.0D) * Height / 1000.0D));
		}
		else
		{
		  bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcFormworkArea", BottomAreaQT, Math.PI * Diameter / 1000.0D * Height / 1000.0D));
		  bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcDiameter", DiameterQT, Diameter));
		}
		list.Insert(0, bIMPropertySet);
		ExtensionProperties = list;
		Architecture = true;
		Structural = true;
		Landscaping = true;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\bimengine\impl\BEBIMColumn.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}