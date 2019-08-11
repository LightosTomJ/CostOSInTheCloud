using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim.ifcengine.impl
{
	using Pointer = com.sun.jna.Pointer;
	using GroupTable  = Desktop.common.nomitech..bimengine.model.data.GroupTable;
	using IfcEngineUtils  = Desktop.common.nomitech..ifcengine.util.IfcEngineUtils;

	public class IEBIMGroup : BIMGroup
	{
	  public IEBIMGroup(Pointer paramPointer)
	  {
		string str1 = IfcEngineUtils.getStringAttributeBN(paramPointer, "GlobalId");
		string str2 = IfcEngineUtils.getStringAttributeBN(paramPointer, "Name");
		string str3 = IfcEngineUtils.getStringAttributeBN(paramPointer, "Description");
		Id = Convert.ToInt64(-111L);
		Name = str2;
		GlobalId = str1;
		Type = "system";
		Children = new LinkedList();
		Elements = new LinkedList();
	  }

	  public IEBIMGroup(GroupTable paramGroupTable)
	  {
		Id = Convert.ToInt64(-111L);
		Name = paramGroupTable.Name;
		GlobalId = paramGroupTable.GlobalId;
		if (paramGroupTable.Type.Equals("Zone"))
		{
		  Type = "zone";
		}
		else
		{
		  Type = "system";
		}
		Children = new LinkedList();
		Elements = new LinkedList();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\ifcengine\impl\IEBIMGroup.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}