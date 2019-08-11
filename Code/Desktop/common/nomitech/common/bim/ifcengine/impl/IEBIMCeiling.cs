using System;

namespace Desktop.common.nomitech.common.bim.ifcengine.impl
{
	using Pointer = com.sun.jna.Pointer;
	using BIMQTOType  = Desktop.common.nomitech..bimengine.types.BIMQTOType;
	using IfcEngineGeometryData  = Desktop.common.nomitech..common.ifc.IfcEngineGeometryData;
	using IfcEnginePropertiesData  = Desktop.common.nomitech..common.ifc.IfcEnginePropertiesData;
	using IfcEngineQuantitiesData  = Desktop.common.nomitech..common.ifc.IfcEngineQuantitiesData;
	using IfcEngineUtils  = Desktop.common.nomitech..common.ifc.IfcEngineUtils;
	using BIMPropertySet  = Desktop.common.nomitech..ifcengine.props.BIMPropertySet;

	public class IEBIMCeiling : BIMCeiling
	{
	  public static readonly EnumSet<BIMQTOType> QUANTITIES = EnumSet.of(BIMQTOType.TOP_ELEVATION, new BIMQTOType[] {BIMQTOType.BOTTOM_ELEVATION, BIMQTOType.NET_VOLUME, BIMQTOType.FOOTPRINT_NET_AREA, BIMQTOType.HEIGHT, BIMQTOType.LENGTH, BIMQTOType.WIDTH});

	  private static Color CEILING_COLOR = new Color(155, 140, 145);

	  public IEBIMCeiling(Pointer paramPointer, BIMBuildingStorey paramBIMBuildingStorey, IfcEnginePropertiesData paramIfcEnginePropertiesData, IfcEngineGeometryData paramIfcEngineGeometryData, IfcEngineQuantitiesData paramIfcEngineQuantitiesData)
	  {
		Id = Convert.ToInt64(-1L);
		string str1 = IfcEngineUtils.getStringAttributeBN(paramPointer, "GlobalId");
		string str2 = IfcEngineUtils.getStringAttributeBN(paramPointer, "Name");
		Color color = paramIfcEngineGeometryData.AmbientColor;
		if (color != null)
		{
		  Color = color;
		}
		else
		{
		  Color = CEILING_COLOR;
		}
		Storey = paramBIMBuildingStorey;
		if (paramIfcEngineGeometryData.Transparency != null)
		{
		  Transparency = paramIfcEngineGeometryData.Transparency.Value;
		}
		Transform3D = new Transform3D();
		BIMGeometry = new BIMGeometry(paramIfcEngineGeometryData);
		Material = paramIfcEnginePropertiesData.Material;
		Type = paramIfcEnginePropertiesData.Type;
		Layer = paramIfcEnginePropertiesData.Layer;
		Name = str2;
		Label = str2;
		GlobalId = str1;
		BimToolId = str1;
		TopElevation = paramIfcEngineQuantitiesData.TopElevation;
		TopElevationQT = BIMQuantityType.QTY_MILLI_METER;
		BottomElevation = paramIfcEngineQuantitiesData.BottomElevation;
		BottomElevationQT = BIMQuantityType.QTY_MILLI_METER;
		LastUpdate = DateTime.Now;
		Area = paramIfcEngineQuantitiesData.FootprintNetArea;
		AreaQT = BIMQuantityType.QTY_SQUARE_METER;
		Volume = paramIfcEngineQuantitiesData.NetVolume;
		VolumeQT = BIMQuantityType.QTY_CUBIC_METER;
		double d1 = paramIfcEngineQuantitiesData.Width;
		double d2 = paramIfcEngineQuantitiesData.Length;
		if (d1 < d2)
		{
		  Thickness = d1;
		}
		else
		{
		  Thickness = d2;
		}
		ThicknessQT = BIMQuantityType.QTY_MILLI_METER;
		System.Collections.IList list = paramIfcEnginePropertiesData.PropSetList;
		BIMPropertySet bIMPropertySet = BIMExtensionPropertiesUtil.createPropertySet("CalcQuantities");
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcNetArea", AreaQT, Area));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcVolume", VolumeQT, Volume));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcThickness", ThicknessQT, Thickness));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcPiece", 0, 1.0D));
		list.Insert(0, bIMPropertySet);
		ExtensionProperties = list;
		Architecture = true;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\ifcengine\impl\IEBIMCeiling.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}