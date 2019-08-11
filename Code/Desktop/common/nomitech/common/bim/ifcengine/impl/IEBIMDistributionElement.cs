using System;

namespace Desktop.common.nomitech.common.bim.ifcengine.impl
{
	using ElementTable  = Desktop.common.nomitech..bimengine.model.data.ElementTable;
	using StringUtils  = Desktop.common.nomitech..bimengine.util.StringUtils;
	using IfcEngineQuantitiesData  = Desktop.common.nomitech..common.ifc.IfcEngineQuantitiesData;
	using IfcEnginePropertiesData  = Desktop.common.nomitech..ifcengine.loaders.IfcEnginePropertiesData;
	using BIMPropertySet  = Desktop.common.nomitech..ifcengine.props.BIMPropertySet;

	public class IEBIMDistributionElement : BIMDistributionElement
	{
	  public IEBIMDistributionElement(ElementTable paramElementTable, IfcEngineQuantitiesData paramIfcEngineQuantitiesData, IfcEnginePropertiesData paramIfcEnginePropertiesData) : base(StringUtils.replaceAll(paramElementTable.TypeDescription, " ", ""))
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
		Material = paramIfcEnginePropertiesData.Material;
		Type = paramIfcEnginePropertiesData.Type;
		TopElevation = paramIfcEngineQuantitiesData.TopElevation;
		TopElevationQT = BIMQuantityType.QTY_MILLI_METER;
		BottomElevation = paramIfcEngineQuantitiesData.BottomElevation;
		BottomElevationQT = BIMQuantityType.QTY_MILLI_METER;
		LastUpdate = DateTime.Now;
		Volume = paramIfcEngineQuantitiesData.NetVolume;
		VolumeQT = BIMQuantityType.QTY_CUBIC_METER;
		Volume = paramIfcEngineQuantitiesData.NetVolume;
		VolumeQT = BIMQuantityType.QTY_CUBIC_METER;
		Layer = paramIfcEnginePropertiesData.Layer;
		System.Collections.IList list = paramIfcEnginePropertiesData.PropSetList;
		BIMPropertySet bIMPropertySet = BIMExtensionPropertiesUtil.createPropertySet("CalcQuantities");
		double d1 = paramIfcEngineQuantitiesData.Length;
		double d2 = paramIfcEngineQuantitiesData.Height;
		double d3 = paramIfcEngineQuantitiesData.Width;
		if (d1 < d2)
		{
		  double d = d1;
		  d1 = d2;
		  d2 = d1;
		}
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
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcLength", BIMQuantityType.QTY_MILLI_METER, d1));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcVolume", VolumeQT, Volume));
		bool @bool = false;
		if ((int)d3 == (int)d2)
		{
		  bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcDiameter", BIMQuantityType.QTY_MILLI_METER, d3));
		}
		else
		{
		  bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcArea", BIMQuantityType.QTY_SQUARE_METER, paramIfcEngineQuantitiesData.FootprintNetArea));
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
		Architecture = false;
		Structural = false;
		Landscaping = false;
		Airconditioning = true;
		Heating = true;
		Ventilation = true;
		Electrical = true;
		Sprinkler = true;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\ifcengine\impl\IEBIMDistributionElement.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}