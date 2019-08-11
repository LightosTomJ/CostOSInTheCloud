using System.Collections.Generic;

namespace Desktop.common.nomitech.costos.plugin.api
{

	public interface ResourceContext
	{
	  IList<ItemRow> getSelectedItems(string paramString);

	  bool isResourcePanelShowing(string paramString);

	  string SelectedResourcePanelName {get;}
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\plugin\api\ResourceContext.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}