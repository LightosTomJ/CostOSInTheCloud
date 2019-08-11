using System.Collections.Generic;

namespace Desktop.common.nomitech.costos.plugin.api
{
	using BoqItemTable = nomitech.common.db.project.BoqItemTable;

	public interface AddActionListener
	{
	  IList<long> additionPerformed(BoqItemTable[] paramArrayOfBoqItemTable);
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\plugin\api\AddActionListener.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}