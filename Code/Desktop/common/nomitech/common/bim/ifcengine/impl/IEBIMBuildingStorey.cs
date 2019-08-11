using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim.ifcengine.impl
{
	using Pointer = com.sun.jna.Pointer;
	using ElementTable  = Desktop.common.nomitech..bimengine.model.data.ElementTable;
	using IfcEngineUtils  = Desktop.common.nomitech..common.ifc.IfcEngineUtils;

	public class IEBIMBuildingStorey : BIMBuildingStorey
	{
	  public IEBIMBuildingStorey(Pointer paramPointer, IEBIMBuilding paramIEBIMBuilding)
	  {
		Id = Convert.ToInt64(-1L);
		string str1 = IfcEngineUtils.getStringAttributeBN(paramPointer, "GlobalId");
		string str2 = IfcEngineUtils.getStringAttributeBN(paramPointer, "Name");
		string str3 = IfcEngineUtils.getStringAttributeBN(paramPointer, "Description");
		Name = str2;
		GlobalId = str1;
		BimToolId = "";
		TopElevation = 0.0D;
		TopElevationQT = 1;
		BottomElevation = 0.0D;
		BottomElevationQT = 1;
		LastUpdate = DateTime.Now;
		Height = 0.0D;
		HeightQT = 0;
		Building = paramIEBIMBuilding;
		Elements = new List<object>();
	  }

	  public IEBIMBuildingStorey(string paramString, DateTime paramDate, BIMBuilding paramBIMBuilding)
	  {
		Id = Convert.ToInt64(-13123L);
		Name = paramString;
		GlobalId = paramString;
		BimToolId = "";
		TopElevation = 0.0D;
		TopElevationQT = 1;
		BottomElevation = 0.0D;
		BottomElevationQT = 1;
		LastUpdate = paramDate;
		Height = 0.0D;
		HeightQT = 0;
		Building = paramBIMBuilding;
		Elements = new List<object>();
	  }

	  public IEBIMBuildingStorey(ElementTable paramElementTable)
	  {
		Id = paramElementTable.ElementId;
		Name = paramElementTable.Name;
		GlobalId = paramElementTable.GlobalId;
		BimToolId = "";
		TopElevation = 0.0D;
		TopElevationQT = 1;
		BottomElevation = 0.0D;
		BottomElevationQT = 1;
		LastUpdate = DateTime.Now;
		Height = 0.0D;
		HeightQT = 0;
		Elements = new List<object>();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\ifcengine\impl\IEBIMBuildingStorey.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}