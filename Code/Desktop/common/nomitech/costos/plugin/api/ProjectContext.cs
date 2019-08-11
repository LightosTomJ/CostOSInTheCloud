using System.Collections.Generic;

namespace Desktop.common.nomitech.costos.plugin.api
{
	using Row = com.jidesoft.grid.Row;
	using ProjectDBProperties = nomitech.common.ProjectDBProperties;
	using ProjectDBUtil = nomitech.common.ProjectDBUtil;
	using BoqItemTable = nomitech.common.db.project.BoqItemTable;

	public interface ProjectContext
	{
	  IList<ProjectDBUtil> AllProjectDBUtils {get;}

	  Row RootRow {get;}

	  ProjectDBUtil currentProjectDBUtil();

	  ProjectDBProperties currentProjectDBProperties();

	  IList<ItemRow> VisibleItems {get;}

	  IList<ItemRow> SelectedItems {get;}

	  string SelectedGroupCode {get;}

	  string SelectedGroupCodeName {get;}

	  bool isUserInRole(int paramInt);

	  BoqItemTable createEmptyBoqItem();

	  IList<long> SelectedBoqItemsByIds {set;}
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\plugin\api\ProjectContext.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}