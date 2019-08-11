using System.Collections.Generic;

namespace Desktop.common.nomitech.costos.plugin.api
{
	using UIProgress = nomitech.common.ui.UIProgress;

	public interface ITakeoffSyncCallback : UIProgress
	{
	  void boqItemsUpdated(IList<long> paramList);
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\plugin\api\ITakeoffSyncCallback.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}