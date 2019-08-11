using System;

namespace Desktop.common.nomitech.common.bim.bimengine.impl
{
	using BIMExtensionPropertiesUtil = nomitech.common.bim.ifcengine.BIMExtensionPropertiesUtil;
	using IfcEnginePropertiesData = nomitech.common.ifc.IfcEnginePropertiesData;
	using IfcEngineQuantitiesData = nomitech.common.ifc.IfcEngineQuantitiesData;
	using BIMPropertySet = nomitech.ifcengine.props.BIMPropertySet;

	public class BEBIMMember : BIMMember
	{
	  public BEBIMMember(object[] paramArrayOfObject, IfcEngineQuantitiesData paramIfcEngineQuantitiesData, IfcEnginePropertiesData paramIfcEnginePropertiesData)
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
		double d1 = paramIfcEngineQuantitiesData.Length;
		double d2 = paramIfcEngineQuantitiesData.Height;
		double d3 = paramIfcEngineQuantitiesData.Width;
		double d4 = paramIfcEngineQuantitiesData.FootprintNetArea;
		if (d1 < d2)
		{
		  double d = d1;
		  d1 = d2;
		  d2 = d;
		}
		if (d1 < d3)
		{
		  double d = d1;
		  d1 = d3;
		  d3 = d;
		}
		Area = d4;
		AreaQT = BIMQuantityType.QTY_SQUARE_METER;
		Length = d1;
		LengthQT = BIMQuantityType.QTY_MILLI_METER;
		Area = paramIfcEngineQuantitiesData.FootprintNetArea;
		AreaQT = BIMQuantityType.QTY_SQUARE_METER;
		System.Collections.IList list = paramIfcEnginePropertiesData.PropSetList;
		BIMPropertySet bIMPropertySet = BIMExtensionPropertiesUtil.createPropertySet("CalcQuantities");
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcFootprintArea", AreaQT, Area));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcVolume", BIMQuantityType.QTY_CUBIC_METER, paramIfcEngineQuantitiesData.NetVolume));
		if ((int)d3 == (int)d2)
		{
		  bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcDiameter", BIMQuantityType.QTY_MILLI_METER, d3));
		}
		else
		{
		  bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcArea", BIMQuantityType.QTY_SQUARE_METER, d4));
		  if (d1 != d2)
		  {
			bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcCrossSectionWidth", BIMQuantityType.QTY_MILLI_METER, d2));
		  }
		  if (d1 != d3)
		  {
			bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcCrossSectionHeight", BIMQuantityType.QTY_MILLI_METER, d3));
		  }
		}
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcPiece", 0, 1.0D));
		list.Insert(0, bIMPropertySet);
		ExtensionProperties = list;
		Structural = true;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\bimengine\impl\BEBIMMember.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}