using System.Collections.Generic;

namespace Desktop.common.nomitech.costos.plugin.api
{
	using FunctionTable = nomitech.common.db.local.FunctionTable;
	using ParamItemTable = nomitech.common.db.local.ParamItemTable;
	using ConditionTable = nomitech.common.db.project.ConditionTable;

	public interface ITakeoffQuantityCallback
	{
	  ParamItemTable ParamItemTable {get;}

	  FunctionTable FunctionTable {get;}

	  ITakeoffRequest TakeoffRequest {get;}

	  ITakeoffRequest[] TakeoffRequests {get;}

	  void prepareTakeoffs();

	  ConditionTable[] Takeoffs {set;}

	  IDictionary<string, ConditionTable[]> Takeoffs {set;}
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\plugin\api\ITakeoffQuantityCallback.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}