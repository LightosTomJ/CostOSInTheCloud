using System.Text;

namespace Desktop.common.nomitech.common.bim.ifcengine
{
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using DBFieldFormatUtil = nomitech.common.util.DBFieldFormatUtil;
	using Unit1ToUnit2Util = nomitech.common.util.Unit1ToUnit2Util;
	using BIMProperty = nomitech.ifcengine.props.BIMProperty;
	using BIMPropertySet = nomitech.ifcengine.props.BIMPropertySet;

	public class BIMViewerUtil
	{
	  public static SBIMViewerIntf s_intf;

	  public static void constructWallExtraValues(BIMWall paramBIMWall, bool paramBoolean)
	  {
		paramBIMWall.Title = constructTitle(paramBIMWall);
		paramBIMWall.Description = getExtensionPropertiesAsString(paramBIMWall, paramBoolean);
		paramBIMWall.Qty1 = paramBIMWall.Area;
		paramBIMWall.Uom1 = "M2";
		paramBIMWall.QtyName1 = "CalcNetArea";
		paramBIMWall.Qty2 = paramBIMWall.Volume;
		paramBIMWall.Uom2 = "M3";
		paramBIMWall.QtyName2 = "CalcVolume";
		paramBIMWall.Qty3 = paramBIMWall.Length / 1000.0D;
		paramBIMWall.Uom3 = "LM";
		paramBIMWall.QtyName3 = "CalcLength";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMWall);
		}
	  }

	  public static void constructDoorExtraValues(BIMDoor paramBIMDoor, bool paramBoolean)
	  {
		paramBIMDoor.Title = constructTitle(paramBIMDoor);
		paramBIMDoor.Description = getExtensionPropertiesAsString(paramBIMDoor, paramBoolean);
		paramBIMDoor.Qty1 = paramBIMDoor.Area;
		paramBIMDoor.Uom1 = "M2";
		paramBIMDoor.QtyName1 = "CalcArea";
		paramBIMDoor.Qty2 = 1.0D;
		paramBIMDoor.Uom2 = "EACH";
		paramBIMDoor.QtyName2 = "CalcPiece";
		paramBIMDoor.Qty3 = paramBIMDoor.Perimeter / 1000.0D;
		paramBIMDoor.Uom3 = "LM";
		paramBIMDoor.QtyName3 = "CalcPerimeter";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMDoor);
		}
	  }

	  public static void constructWindowExtraValues(BIMWindow paramBIMWindow, bool paramBoolean)
	  {
		paramBIMWindow.Title = constructTitle(paramBIMWindow);
		paramBIMWindow.Description = getExtensionPropertiesAsString(paramBIMWindow, paramBoolean);
		paramBIMWindow.Qty1 = paramBIMWindow.Area;
		paramBIMWindow.Uom1 = "M2";
		paramBIMWindow.QtyName1 = "CalcArea";
		paramBIMWindow.Qty2 = 1.0D;
		paramBIMWindow.Uom2 = "EACH";
		paramBIMWindow.QtyName2 = "CalcPiece";
		paramBIMWindow.Qty3 = paramBIMWindow.Perimeter / 1000.0D;
		paramBIMWindow.Uom3 = "LM";
		paramBIMWindow.QtyName3 = "CalcPerimeter";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMWindow);
		}
	  }

	  public static void constructSlabExtraValues(BIMSlab paramBIMSlab, bool paramBoolean)
	  {
		paramBIMSlab.Title = constructTitle(paramBIMSlab);
		paramBIMSlab.Description = getExtensionPropertiesAsString(paramBIMSlab, paramBoolean);
		paramBIMSlab.Qty1 = paramBIMSlab.Area;
		paramBIMSlab.Uom1 = "M2";
		paramBIMSlab.QtyName1 = "CalcArea";
		paramBIMSlab.Qty2 = paramBIMSlab.Volume;
		paramBIMSlab.Uom2 = "M3";
		paramBIMSlab.QtyName2 = "CalcVolume";
		paramBIMSlab.Qty3 = paramBIMSlab.Perimeter / 1000.0D;
		paramBIMSlab.Uom3 = "LM";
		paramBIMSlab.QtyName3 = "CalcPerimeter";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMSlab);
		}
	  }

	  public static void constructRoofExtraValues(BIMRoof paramBIMRoof, bool paramBoolean)
	  {
		paramBIMRoof.Title = constructTitle(paramBIMRoof);
		paramBIMRoof.Description = getExtensionPropertiesAsString(paramBIMRoof, paramBoolean);
		paramBIMRoof.Qty1 = paramBIMRoof.Area;
		paramBIMRoof.Uom1 = "M2";
		paramBIMRoof.QtyName1 = "CalcNetArea";
		paramBIMRoof.Qty2 = paramBIMRoof.Volume;
		paramBIMRoof.Uom2 = "M3";
		paramBIMRoof.QtyName2 = "CalcVolume";
		paramBIMRoof.Qty3 = paramBIMRoof.Perimeter / 1000.0D;
		paramBIMRoof.Uom3 = "LM";
		paramBIMRoof.QtyName3 = "CalcPerimeter";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMRoof);
		}
	  }

	  public static void constructRailingExtraValues(BIMRailing paramBIMRailing, bool paramBoolean)
	  {
		paramBIMRailing.Title = constructTitle(paramBIMRailing);
		paramBIMRailing.Description = getExtensionPropertiesAsString(paramBIMRailing, paramBoolean);
		paramBIMRailing.Qty1 = paramBIMRailing.BottomArea;
		paramBIMRailing.Uom1 = "M2";
		paramBIMRailing.QtyName1 = "CalcFootprintArea";
		paramBIMRailing.Qty2 = 1.0D;
		paramBIMRailing.Uom2 = "EACH";
		paramBIMRailing.QtyName2 = "CalcPiece";
		paramBIMRailing.Qty3 = paramBIMRailing.Height / 1000.0D;
		paramBIMRailing.Uom3 = "LM";
		paramBIMRailing.QtyName3 = "CalcHeight";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMRailing);
		}
	  }

	  public static void constructBeamExtraValues(BIMBeam paramBIMBeam, bool paramBoolean)
	  {
		paramBIMBeam.Title = constructTitle(paramBIMBeam);
		paramBIMBeam.Description = getExtensionPropertiesAsString(paramBIMBeam, paramBoolean);
		paramBIMBeam.Qty1 = paramBIMBeam.Length / 1000.0D;
		paramBIMBeam.Uom1 = "LM";
		paramBIMBeam.QtyName1 = "CalcLength";
		paramBIMBeam.Qty2 = paramBIMBeam.Volume;
		paramBIMBeam.Uom2 = "M3";
		paramBIMBeam.QtyName2 = "CalcVolume";
		paramBIMBeam.Qty3 = paramBIMBeam.BottomArea;
		paramBIMBeam.Uom3 = "M2";
		paramBIMBeam.QtyName3 = "CalcFootprintArea";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMBeam);
		}
	  }

	  public static void constructSpaceExtraValues(BIMSpace paramBIMSpace, bool paramBoolean)
	  {
		string str = paramBIMSpace.Name;
		paramBIMSpace.Title = str;
		paramBIMSpace.Description = getExtensionPropertiesAsString(paramBIMSpace, paramBoolean);
		paramBIMSpace.Qty1 = paramBIMSpace.Area;
		paramBIMSpace.Uom1 = "M2";
		paramBIMSpace.QtyName1 = "CalcArea";
		paramBIMSpace.Qty2 = paramBIMSpace.Volume;
		paramBIMSpace.Uom2 = "M3";
		paramBIMSpace.QtyName2 = "CalcVolume";
		paramBIMSpace.Qty3 = paramBIMSpace.Height / 1000.0D;
		paramBIMSpace.Uom3 = "LM";
		paramBIMSpace.QtyName3 = "CalcHeight";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMSpace);
		}
	  }

	  public static void constructSpaceBoundaryExtraValues(BIMSpaceBoundary paramBIMSpaceBoundary, bool paramBoolean)
	  {
		string str = paramBIMSpaceBoundary.Name;
		paramBIMSpaceBoundary.Title = str;
		paramBIMSpaceBoundary.Description = getExtensionPropertiesAsString(paramBIMSpaceBoundary, paramBoolean);
		paramBIMSpaceBoundary.Qty1 = paramBIMSpaceBoundary.Area;
		paramBIMSpaceBoundary.Uom1 = "M2";
		paramBIMSpaceBoundary.QtyName1 = "CalcArea";
		paramBIMSpaceBoundary.Qty2 = 1.0D;
		paramBIMSpaceBoundary.Uom2 = "EACH";
		paramBIMSpaceBoundary.QtyName2 = "CalcPiece";
		paramBIMSpaceBoundary.Qty3 = 0.0D;
		paramBIMSpaceBoundary.Uom3 = "";
		paramBIMSpaceBoundary.QtyName3 = "";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMSpaceBoundary);
		}
	  }

	  public static void constructGrossAreaCompartmentExtraValues(BIMGrossAreaCompartment paramBIMGrossAreaCompartment, bool paramBoolean)
	  {
		string str = paramBIMGrossAreaCompartment.Name;
		paramBIMGrossAreaCompartment.Title = str;
		paramBIMGrossAreaCompartment.Description = getExtensionPropertiesAsString(paramBIMGrossAreaCompartment, paramBoolean);
		paramBIMGrossAreaCompartment.Qty1 = paramBIMGrossAreaCompartment.Area;
		paramBIMGrossAreaCompartment.Uom1 = "M2";
		paramBIMGrossAreaCompartment.QtyName1 = "CalcArea";
		paramBIMGrossAreaCompartment.Qty2 = paramBIMGrossAreaCompartment.Volume;
		paramBIMGrossAreaCompartment.Uom2 = "M3";
		paramBIMGrossAreaCompartment.QtyName2 = "CalcVolume";
		paramBIMGrossAreaCompartment.Qty3 = paramBIMGrossAreaCompartment.Height / 1000.0D;
		paramBIMGrossAreaCompartment.Uom3 = "LM";
		paramBIMGrossAreaCompartment.QtyName3 = "CalcHeight";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMGrossAreaCompartment);
		}
	  }

	  public static void constructFireCompartmentExtraValues(BIMFireCompartment paramBIMFireCompartment, bool paramBoolean)
	  {
		string str = paramBIMFireCompartment.Name;
		paramBIMFireCompartment.Title = str;
		paramBIMFireCompartment.Description = getExtensionPropertiesAsString(paramBIMFireCompartment, paramBoolean);
		paramBIMFireCompartment.Qty1 = paramBIMFireCompartment.Area;
		paramBIMFireCompartment.Uom1 = "M2";
		paramBIMFireCompartment.QtyName1 = "CalcArea";
		paramBIMFireCompartment.Qty2 = paramBIMFireCompartment.Volume;
		paramBIMFireCompartment.Uom2 = "M3";
		paramBIMFireCompartment.QtyName2 = "CalcVolume";
		paramBIMFireCompartment.Qty3 = paramBIMFireCompartment.Height / 1000.0D;
		paramBIMFireCompartment.Uom3 = "LM";
		paramBIMFireCompartment.QtyName3 = "CalcHeight";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMFireCompartment);
		}
	  }

	  public static void constructSecureCompartmentExtraValues(BIMSecureCompartment paramBIMSecureCompartment, bool paramBoolean)
	  {
		string str = paramBIMSecureCompartment.Name;
		paramBIMSecureCompartment.Title = str;
		paramBIMSecureCompartment.Description = getExtensionPropertiesAsString(paramBIMSecureCompartment, paramBoolean);
		paramBIMSecureCompartment.Qty1 = paramBIMSecureCompartment.Area;
		paramBIMSecureCompartment.Uom1 = "M2";
		paramBIMSecureCompartment.QtyName1 = "CalcArea";
		paramBIMSecureCompartment.Qty2 = paramBIMSecureCompartment.Volume;
		paramBIMSecureCompartment.Uom2 = "M3";
		paramBIMSecureCompartment.QtyName2 = "CalcVolume";
		paramBIMSecureCompartment.Qty3 = paramBIMSecureCompartment.Height / 1000.0D;
		paramBIMSecureCompartment.Uom3 = "LM";
		paramBIMSecureCompartment.QtyName3 = "CalcHeight";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMSecureCompartment);
		}
	  }

	  public static void constructStairExtraValues(BIMStair paramBIMStair, bool paramBoolean)
	  {
		paramBIMStair.Title = constructTitle(paramBIMStair);
		paramBIMStair.Description = getExtensionPropertiesAsString(paramBIMStair, paramBoolean);
		paramBIMStair.Qty1 = paramBIMStair.BottomArea;
		paramBIMStair.Uom1 = "M2";
		paramBIMStair.QtyName1 = "CalcFootprintArea";
		paramBIMStair.Qty2 = paramBIMStair.Volume;
		paramBIMStair.Uom2 = "M3";
		paramBIMStair.QtyName2 = "CalcVolume";
		paramBIMStair.Qty3 = paramBIMStair.Height / 1000.0D;
		paramBIMStair.Uom3 = "LM";
		paramBIMStair.QtyName3 = "CalcHeight";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMStair);
		}
	  }

	  public static void constructRampExtraValues(BIMRamp paramBIMRamp, bool paramBoolean)
	  {
		paramBIMRamp.Title = constructTitle(paramBIMRamp);
		paramBIMRamp.Description = getExtensionPropertiesAsString(paramBIMRamp, paramBoolean);
		paramBIMRamp.Qty1 = paramBIMRamp.BottomArea;
		paramBIMRamp.Uom1 = "M2";
		paramBIMRamp.QtyName1 = "CalcFootprintArea";
		paramBIMRamp.Qty2 = paramBIMRamp.Volume;
		paramBIMRamp.Uom2 = "M3";
		paramBIMRamp.QtyName2 = "CalcVolume";
		paramBIMRamp.Qty3 = paramBIMRamp.Height / 1000.0D;
		paramBIMRamp.Uom3 = "LM";
		paramBIMRamp.QtyName3 = "CalcHeight";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMRamp);
		}
	  }

	  public static void constructColumnExtraValues(BIMColumn paramBIMColumn, bool paramBoolean)
	  {
		paramBIMColumn.Title = constructTitle(paramBIMColumn);
		paramBIMColumn.Description = getExtensionPropertiesAsString(paramBIMColumn, paramBoolean);
		paramBIMColumn.Qty1 = paramBIMColumn.BottomArea;
		paramBIMColumn.Uom1 = "M2";
		paramBIMColumn.QtyName1 = "CalcFootprintArea";
		paramBIMColumn.Qty2 = paramBIMColumn.Volume;
		paramBIMColumn.Uom2 = "M3";
		paramBIMColumn.QtyName2 = "CalcVolume";
		paramBIMColumn.Qty3 = paramBIMColumn.Height / 1000.0D;
		paramBIMColumn.Uom3 = "LM";
		paramBIMColumn.QtyName3 = "CalcHeight";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMColumn);
		}
	  }

	  public static void constructObjectExtraValues(BIMObject paramBIMObject, bool paramBoolean)
	  {
		paramBIMObject.Title = constructTitle(paramBIMObject);
		paramBIMObject.Description = getExtensionPropertiesAsString(paramBIMObject, paramBoolean);
		paramBIMObject.Qty1 = paramBIMObject.Volume;
		paramBIMObject.Uom1 = "M3";
		paramBIMObject.QtyName1 = "CalcVolume";
		paramBIMObject.Qty2 = 1.0D;
		paramBIMObject.Uom2 = "EACH";
		paramBIMObject.QtyName2 = "CalcPiece";
		paramBIMObject.Qty3 = paramBIMObject.Height / 1000.0D;
		paramBIMObject.Uom3 = "LM";
		paramBIMObject.QtyName3 = "CalcHeight";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMObject);
		}
	  }

	  public static void constructFurnitureExtraValues(BIMFurniture paramBIMFurniture, bool paramBoolean)
	  {
		paramBIMFurniture.Title = constructTitle(paramBIMFurniture);
		paramBIMFurniture.Description = getExtensionPropertiesAsString(paramBIMFurniture, paramBoolean);
		paramBIMFurniture.Qty1 = paramBIMFurniture.Volume;
		paramBIMFurniture.Uom1 = "M3";
		paramBIMFurniture.QtyName1 = "CalcVolume";
		paramBIMFurniture.Qty2 = 1.0D;
		paramBIMFurniture.Uom2 = "EACH";
		paramBIMFurniture.QtyName2 = "CalcPiece";
		paramBIMFurniture.Qty3 = paramBIMFurniture.Height / 1000.0D;
		paramBIMFurniture.Uom3 = "LM";
		paramBIMFurniture.QtyName3 = "CalcHeight";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMFurniture);
		}
	  }

	  public static void constructCoveringExtraValues(BIMCovering paramBIMCovering, bool paramBoolean)
	  {
		paramBIMCovering.Title = constructTitle(paramBIMCovering);
		paramBIMCovering.Description = getExtensionPropertiesAsString(paramBIMCovering, paramBoolean);
		paramBIMCovering.Qty1 = paramBIMCovering.Area;
		paramBIMCovering.Uom1 = "M2";
		paramBIMCovering.QtyName1 = "CalcNetArea";
		paramBIMCovering.Qty2 = paramBIMCovering.Volume;
		paramBIMCovering.Uom2 = "M3";
		paramBIMCovering.QtyName2 = "CalcVolume";
		paramBIMCovering.Qty3 = paramBIMCovering.Thickness / 1000.0D;
		paramBIMCovering.Uom3 = "LM";
		paramBIMCovering.QtyName3 = "CalcThickness";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMCovering);
		}
	  }

	  public static void constructFootingExtraValues(BIMFooting paramBIMFooting, bool paramBoolean)
	  {
		paramBIMFooting.Title = constructTitle(paramBIMFooting);
		paramBIMFooting.Description = getExtensionPropertiesAsString(paramBIMFooting, paramBoolean);
		paramBIMFooting.Qty1 = paramBIMFooting.BottomArea;
		paramBIMFooting.Uom1 = "M2";
		paramBIMFooting.QtyName1 = "CalcFootprintArea";
		paramBIMFooting.Qty2 = paramBIMFooting.Volume;
		paramBIMFooting.Uom2 = "M3";
		paramBIMFooting.QtyName2 = "CalcVolume";
		paramBIMFooting.Qty3 = paramBIMFooting.ProfHeight / 1000.0D;
		paramBIMFooting.Uom3 = "LM";
		paramBIMFooting.QtyName3 = "CalcCrossSectionHeight";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMFooting);
		}
	  }

	  public static void constructCeilingExtraValues(BIMCeiling paramBIMCeiling, bool paramBoolean)
	  {
		paramBIMCeiling.Title = constructTitle(paramBIMCeiling);
		paramBIMCeiling.Description = getExtensionPropertiesAsString(paramBIMCeiling, paramBoolean);
		paramBIMCeiling.Qty1 = paramBIMCeiling.Area;
		paramBIMCeiling.Uom1 = "M2";
		paramBIMCeiling.QtyName1 = "CalcNetArea";
		paramBIMCeiling.Qty2 = paramBIMCeiling.Volume;
		paramBIMCeiling.Uom2 = "M3";
		paramBIMCeiling.QtyName2 = "CalcVolume";
		paramBIMCeiling.Qty3 = paramBIMCeiling.Thickness / 1000.0D;
		paramBIMCeiling.Uom3 = "LM";
		paramBIMCeiling.QtyName3 = "CalcThickness";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMCeiling);
		}
	  }

	  public static void constructPileExtraValues(BIMPile paramBIMPile, bool paramBoolean)
	  {
		paramBIMPile.Title = constructTitle(paramBIMPile);
		paramBIMPile.Description = getExtensionPropertiesAsString(paramBIMPile, paramBoolean);
		paramBIMPile.Qty1 = paramBIMPile.BottomArea;
		paramBIMPile.Uom1 = "M2";
		paramBIMPile.QtyName1 = "CalcFootprintArea";
		paramBIMPile.Qty2 = paramBIMPile.Volume;
		paramBIMPile.Uom2 = "M3";
		paramBIMPile.QtyName2 = "CalcVolume";
		paramBIMPile.Qty3 = paramBIMPile.Length / 1000.0D;
		paramBIMPile.Uom3 = "LM";
		paramBIMPile.QtyName3 = "CalcLength";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMPile);
		}
	  }

	  public static void constructPlateExtraValues(BIMPlate paramBIMPlate, bool paramBoolean)
	  {
		paramBIMPlate.Title = constructTitle(paramBIMPlate);
		paramBIMPlate.Description = getExtensionPropertiesAsString(paramBIMPlate, paramBoolean);
		paramBIMPlate.Qty1 = paramBIMPlate.Volume;
		paramBIMPlate.Uom1 = "M3";
		paramBIMPlate.QtyName1 = "CalcVolume";
		paramBIMPlate.Qty2 = 1.0D;
		paramBIMPlate.Uom2 = "EACH";
		paramBIMPlate.QtyName2 = "CalcPiece";
		paramBIMPlate.Qty3 = paramBIMPlate.Area;
		paramBIMPlate.Uom3 = "M2";
		paramBIMPlate.QtyName3 = "CalcFootprintArea";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMPlate);
		}
	  }

	  public static void constructBuildingElementPartExtraValues(BIMBuildingElementPart paramBIMBuildingElementPart, bool paramBoolean)
	  {
		paramBIMBuildingElementPart.Title = constructTitle(paramBIMBuildingElementPart);
		paramBIMBuildingElementPart.Description = getExtensionPropertiesAsString(paramBIMBuildingElementPart, paramBoolean);
		paramBIMBuildingElementPart.Qty1 = paramBIMBuildingElementPart.Volume;
		paramBIMBuildingElementPart.Uom1 = "M3";
		paramBIMBuildingElementPart.QtyName1 = "CalcVolume";
		paramBIMBuildingElementPart.Qty2 = 1.0D;
		paramBIMBuildingElementPart.Uom2 = "EACH";
		paramBIMBuildingElementPart.QtyName2 = "CalcPiece";
		paramBIMBuildingElementPart.Qty3 = 0.0D;
		paramBIMBuildingElementPart.Uom3 = "";
		paramBIMBuildingElementPart.QtyName3 = "";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMBuildingElementPart);
		}
	  }

	  public static void constructDistributionElementExtraValues(BIMDistributionElement paramBIMDistributionElement, bool paramBoolean)
	  {
		paramBIMDistributionElement.Title = constructTitle(paramBIMDistributionElement);
		paramBIMDistributionElement.Description = getExtensionPropertiesAsString(paramBIMDistributionElement, paramBoolean);
		paramBIMDistributionElement.Qty1 = paramBIMDistributionElement.Volume;
		paramBIMDistributionElement.Uom1 = "M3";
		paramBIMDistributionElement.QtyName1 = "CalcVolume";
		paramBIMDistributionElement.Qty2 = 1.0D;
		paramBIMDistributionElement.Uom2 = "EACH";
		paramBIMDistributionElement.QtyName2 = "CalcPiece";
		paramBIMDistributionElement.Qty3 = 0.0D;
		paramBIMDistributionElement.Uom3 = "";
		paramBIMDistributionElement.QtyName3 = "";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMDistributionElement);
		}
	  }

	  public static void constructMemberExtraValues(BIMMember paramBIMMember, bool paramBoolean)
	  {
		paramBIMMember.Title = constructTitle(paramBIMMember);
		paramBIMMember.Description = getExtensionPropertiesAsString(paramBIMMember, paramBoolean);
		paramBIMMember.Qty1 = 1.0D;
		paramBIMMember.Uom1 = "EACH";
		paramBIMMember.QtyName1 = "CalcPiece";
		paramBIMMember.Qty2 = paramBIMMember.Area;
		paramBIMMember.Uom2 = "M2";
		paramBIMMember.QtyName2 = "CalcArea";
		paramBIMMember.Qty3 = paramBIMMember.Length / 1000.0D;
		paramBIMMember.Uom3 = "LM";
		paramBIMMember.QtyName3 = "CalcLength";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMMember);
		}
	  }

	  public static void constructDistributionElementWithLengthExtraValues(BIMDistributionElementWithLength paramBIMDistributionElementWithLength, bool paramBoolean)
	  {
		paramBIMDistributionElementWithLength.Title = constructTitle(paramBIMDistributionElementWithLength);
		paramBIMDistributionElementWithLength.Description = getExtensionPropertiesAsString(paramBIMDistributionElementWithLength, paramBoolean);
		paramBIMDistributionElementWithLength.Qty1 = paramBIMDistributionElementWithLength.Volume;
		paramBIMDistributionElementWithLength.Uom1 = "M3";
		paramBIMDistributionElementWithLength.QtyName1 = "CalcVolume";
		paramBIMDistributionElementWithLength.Qty2 = 1.0D;
		paramBIMDistributionElementWithLength.Uom2 = "EACH";
		paramBIMDistributionElementWithLength.QtyName2 = "CalcPiece";
		paramBIMDistributionElementWithLength.Qty3 = paramBIMDistributionElementWithLength.Length / 1000.0D;
		paramBIMDistributionElementWithLength.Uom3 = "LM";
		paramBIMDistributionElementWithLength.QtyName3 = "CalcLength";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMDistributionElementWithLength);
		}
	  }

	  public static void constructLightFixtureExtraValues(BIMLightFixture paramBIMLightFixture, bool paramBoolean)
	  {
		paramBIMLightFixture.Title = constructTitle(paramBIMLightFixture);
		paramBIMLightFixture.Description = getExtensionPropertiesAsString(paramBIMLightFixture, paramBoolean);
		paramBIMLightFixture.Qty1 = paramBIMLightFixture.Volume;
		paramBIMLightFixture.Uom1 = "M3";
		paramBIMLightFixture.QtyName1 = "CalcVolume";
		paramBIMLightFixture.Qty2 = 1.0D;
		paramBIMLightFixture.Uom2 = "EACH";
		paramBIMLightFixture.QtyName2 = "CalcPiece";
		paramBIMLightFixture.Qty3 = 0.0D;
		paramBIMLightFixture.Uom3 = "";
		paramBIMLightFixture.QtyName3 = "";
		if (paramBoolean)
		{
		  inverseUOM(paramBIMLightFixture);
		}
	  }

	  private static BIMElement inverseUOM(BIMElement paramBIMElement)
	  {
		double d = Unit1ToUnit2Util.Instance.getUnitDiv(paramBIMElement.Uom1).doubleValue();
		paramBIMElement.Qty1 = paramBIMElement.Qty1 / d;
		paramBIMElement.Uom1 = Unit1ToUnit2Util.Instance.getUnit2(paramBIMElement.Uom1);
		d = Unit1ToUnit2Util.Instance.getUnitDiv(paramBIMElement.Uom2).doubleValue();
		paramBIMElement.Qty2 = paramBIMElement.Qty2 / d;
		paramBIMElement.Uom2 = Unit1ToUnit2Util.Instance.getUnit2(paramBIMElement.Uom2);
		d = Unit1ToUnit2Util.Instance.getUnitDiv(paramBIMElement.Uom3).doubleValue();
		paramBIMElement.Qty3 = paramBIMElement.Qty3 / d;
		paramBIMElement.Uom3 = Unit1ToUnit2Util.Instance.getUnit2(paramBIMElement.Uom3);
		return paramBIMElement;
	  }

	  private static string getExtensionPropertiesAsString(BIMElement paramBIMElement, bool paramBoolean)
	  {
		System.Collections.IEnumerator iterator = paramBIMElement.ExtensionProperties.GetEnumerator();
		StringBuilder stringBuffer = new StringBuilder();
		stringBuffer.Append("\n");
		while (iterator.MoveNext())
		{
		  BIMPropertySet bIMPropertySet = (BIMPropertySet)iterator.Current;
		  string str = bIMPropertySet.Name;
		  stringBuffer.Append("\n" + str + ":\n");
		  System.Collections.IEnumerator iterator1 = bIMPropertySet.Properties.GetEnumerator();
		  while (iterator1.MoveNext())
		  {
			BIMProperty bIMProperty = (BIMProperty)iterator1.Current;
			if (bIMProperty.Number)
			{
			  continue;
			}
			stringBuffer.Append(bIMProperty.Name + ": " + bIMProperty.Value);
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			if (iterator1.hasNext())
			{
			  stringBuffer.Append(", ");
			}
		  }
		}
		return stringBuffer.ToString();
	  }

	  public static string getNumWithQT(double paramDouble, int paramInt, bool paramBoolean)
	  {
		string str1 = BIMQuantityType.getMetricQty(paramInt);
		if (!paramBoolean && str1.Equals("mm") && paramDouble >= 1000.0D)
		{
		  paramDouble /= 1000.0D;
		  str1 = "m";
		}
		if (paramBoolean)
		{
		  string str = BIMQuantityType.getCostosUom(str1);
		  double d = Unit1ToUnit2Util.Instance.getUnitDiv(str).doubleValue();
		  paramDouble /= d;
		  str1 = Unit1ToUnit2Util.Instance.getUnit2(str).ToLower();
		}
		string str2 = DBFieldFormatUtil.scaleAndFormatRate(new BigDecimalFixed(paramDouble)).ToString();
		return str2 + " " + str1;
	  }

	  public static void constructExtraValues(BIMElement paramBIMElement, bool paramBoolean)
	  {
		if (paramBIMElement is BIMWall)
		{
		  constructWallExtraValues((BIMWall)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMDoor)
		{
		  constructDoorExtraValues((BIMDoor)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMWindow)
		{
		  constructWindowExtraValues((BIMWindow)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMSlab)
		{
		  constructSlabExtraValues((BIMSlab)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMRoof)
		{
		  constructRoofExtraValues((BIMRoof)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMRailing)
		{
		  constructRailingExtraValues((BIMRailing)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMBeam)
		{
		  constructBeamExtraValues((BIMBeam)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMStair)
		{
		  constructStairExtraValues((BIMStair)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMRamp)
		{
		  constructRampExtraValues((BIMRamp)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMColumn)
		{
		  constructColumnExtraValues((BIMColumn)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMObject)
		{
		  constructObjectExtraValues((BIMObject)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMFurniture)
		{
		  constructFurnitureExtraValues((BIMFurniture)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMLightFixture)
		{
		  constructLightFixtureExtraValues((BIMLightFixture)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMBuildingElementPart)
		{
		  constructBuildingElementPartExtraValues((BIMBuildingElementPart)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMPlate)
		{
		  constructPlateExtraValues((BIMPlate)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMPile)
		{
		  constructPileExtraValues((BIMPile)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMCovering)
		{
		  constructCoveringExtraValues((BIMCovering)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMCeiling)
		{
		  constructCeilingExtraValues((BIMCeiling)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMFooting)
		{
		  constructFootingExtraValues((BIMFooting)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMDistributionElementWithLength)
		{
		  constructDistributionElementWithLengthExtraValues((BIMDistributionElementWithLength)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMDistributionElement)
		{
		  constructDistributionElementExtraValues((BIMDistributionElement)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMMember)
		{
		  constructMemberExtraValues((BIMMember)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMSpace)
		{
		  constructSpaceExtraValues((BIMSpace)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMSpaceBoundary)
		{
		  constructSpaceBoundaryExtraValues((BIMSpaceBoundary)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMGrossAreaCompartment)
		{
		  constructGrossAreaCompartmentExtraValues((BIMGrossAreaCompartment)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMFireCompartment)
		{
		  constructFireCompartmentExtraValues((BIMFireCompartment)paramBIMElement, paramBoolean);
		}
		else if (paramBIMElement is BIMSecureCompartment)
		{
		  constructSecureCompartmentExtraValues((BIMSecureCompartment)paramBIMElement, paramBoolean);
		}
	  }

	  public static int defaultQuantityForClass(BIMElement paramBIMElement)
	  {
		  return (paramBIMElement is BIMWall) ? 1 : ((paramBIMElement is BIMDoor) ? 2 : ((paramBIMElement is BIMWindow) ? 2 : ((paramBIMElement is BIMSlab) ? 2 : ((paramBIMElement is BIMRoof) ? 1 : ((paramBIMElement is BIMRailing) ? 1 : ((paramBIMElement is BIMBeam) ? 2 : ((paramBIMElement is BIMStair) ? 3 : ((paramBIMElement is BIMRamp) ? 3 : ((paramBIMElement is BIMColumn) ? 2 : ((paramBIMElement is BIMObject) ? 2 : ((paramBIMElement is BIMFurniture) ? 2 : ((paramBIMElement is BIMLightFixture) ? 2 : ((paramBIMElement is BIMBuildingElementPart) ? 2 : ((paramBIMElement is BIMPlate) ? 2 : ((paramBIMElement is BIMPile) ? 1 : ((paramBIMElement is BIMCovering) ? 1 : ((paramBIMElement is BIMCeiling) ? 1 : ((paramBIMElement is BIMFooting) ? 2 : ((paramBIMElement is BIMDistributionElementWithLength) ? 3 : ((paramBIMElement is BIMDistributionElement) ? 2 : ((paramBIMElement is BIMMember) ? 1 : ((paramBIMElement is BIMSpace) ? 1 : ((paramBIMElement is BIMSpaceBoundary) ? 2 : ((paramBIMElement is BIMGrossAreaCompartment) ? 1 : ((paramBIMElement is BIMFireCompartment) ? 1 : ((paramBIMElement is BIMSecureCompartment) ? 1 : 0))))))))))))))))))))))))));
	  }

	  private static string constructTitle(BIMBuildingElement paramBIMBuildingElement)
	  {
		string str1 = paramBIMBuildingElement.Name;
		string str2 = paramBIMBuildingElement.MaterialAndTypeConcat;
		if (!string.ReferenceEquals(str2, null) && !str2.Equals(""))
		{
		  str1 = str1 + ", " + str2;
		}
		return str1;
	  }

	  public interface SBIMViewerIntf
	  {
		string getLangText(string param1String);

		int getDefaultPropery(string param1String);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\ifcengine\BIMViewerUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}