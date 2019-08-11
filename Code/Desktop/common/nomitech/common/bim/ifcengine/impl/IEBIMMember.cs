using System;

namespace Desktop.common.nomitech.common.bim.ifcengine.impl
{
	using ElementTable  = Desktop.common.nomitech..bimengine.model.data.ElementTable;
	using IfcEngineQuantitiesData  = Desktop.common.nomitech..common.ifc.IfcEngineQuantitiesData;
	using IfcEnginePropertiesData  = Desktop.common.nomitech..ifcengine.loaders.IfcEnginePropertiesData;
	using BIMPropertySet  = Desktop.common.nomitech..ifcengine.props.BIMPropertySet;

	public class IEBIMMember : BIMMember
	{
	  public IEBIMMember(ElementTable paramElementTable, IfcEnginePropertiesData paramIfcEnginePropertiesData, IfcEngineQuantitiesData paramIfcEngineQuantitiesData)
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


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\ifcengine\impl\IEBIMMember.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}