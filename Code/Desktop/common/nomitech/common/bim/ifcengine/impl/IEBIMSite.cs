using System;

namespace Desktop.common.nomitech.common.bim.ifcengine.impl
{
	using Pointer = com.sun.jna.Pointer;
	using ElementTable  = Desktop.common.nomitech..bimengine.model.data.ElementTable;
	using IfcEngineUtils  = Desktop.common.nomitech..ifcengine.util.IfcEngineUtils;

	public class IEBIMSite : BIMSite
	{
	  public IEBIMSite(Pointer paramPointer)
	  {
		string str1 = IfcEngineUtils.getStringAttributeBN(paramPointer, "GlobalId");
		string str2 = IfcEngineUtils.getStringAttributeBN(paramPointer, "Name");
		Id = Convert.ToInt64(-22222L);
		GlobalId = str1;
		Name = str2;
	  }

	  public IEBIMSite(ElementTable paramElementTable)
	  {
		Id = paramElementTable.ElementId;
		GlobalId = paramElementTable.GlobalId;
		Name = paramElementTable.Name;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\ifcengine\impl\IEBIMSite.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}