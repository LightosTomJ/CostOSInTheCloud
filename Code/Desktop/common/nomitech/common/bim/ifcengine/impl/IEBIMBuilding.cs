using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim.ifcengine.impl
{
	using Pointer = com.sun.jna.Pointer;
	using ElementTable  = Desktop.common.nomitech..bimengine.model.data.ElementTable;
	using IfcEngineUtils  = Desktop.common.nomitech..common.ifc.IfcEngineUtils;
	using BIMPropertySet  = Desktop.common.nomitech..ifcengine.props.BIMPropertySet;

	public class IEBIMBuilding : BIMBuilding
	{
	  public IEBIMBuilding(Pointer paramPointer, IList<BIMPropertySet> paramList, BIMModel paramBIMModel)
	  {
		if (paramPointer == null)
		{
		  Id = Convert.ToInt64(9223372036854775805L);
		  GlobalId = "" + DateTimeHelper.CurrentUnixTimeMillis();
		  Name = "Building [Missing]";
		  GrossArea = 0.0D;
		  GrossAreaQT = 1;
		  Volume = 0.0D;
		  VolumeQT = 1;
		  BimToolId = "";
		  TopElevation = 0.0D;
		  TopElevationQT = 1;
		  BottomElevation = 0.0D;
		  BottomElevationQT = 1;
		  LastUpdate = DateTime.Now;
		}
		else
		{
		  int? integer = BIMPropertySetUtil.findIntegerInBIMPropertyInSets(paramList, "BuildingID");
		  if (integer == null)
		  {
			integer = Convert.ToInt32(-1);
		  }
		  Id = Convert.ToInt64(integer.Value);
		  GlobalId = IfcEngineUtils.getStringAttributeBN(paramPointer, "GlobalId");
		  Name = IfcEngineUtils.getStringAttributeBN(paramPointer, "Name");
		  GrossArea = 0.0D;
		  GrossAreaQT = 1;
		  Volume = 0.0D;
		  VolumeQT = 1;
		  BimToolId = "";
		  TopElevation = 0.0D;
		  TopElevationQT = 1;
		  BottomElevation = 0.0D;
		  BottomElevationQT = 1;
		  LastUpdate = DateTime.Now;
		}
		Model = paramBIMModel;
		Storeys = new List<object>();
	  }

	  public IEBIMBuilding(ElementTable paramElementTable)
	  {
		Id = paramElementTable.ElementId;
		GlobalId = paramElementTable.GlobalId;
		Name = paramElementTable.Name;
		GrossArea = 0.0D;
		GrossAreaQT = 1;
		Volume = 0.0D;
		VolumeQT = 1;
		BimToolId = "";
		TopElevation = 0.0D;
		TopElevationQT = 1;
		BottomElevation = 0.0D;
		BottomElevationQT = 1;
		LastUpdate = DateTime.Now;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\ifcengine\impl\IEBIMBuilding.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}