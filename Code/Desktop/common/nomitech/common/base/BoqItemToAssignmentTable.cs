using System;

namespace Desktop.common.nomitech.common.@base
{
	using ParamItemTable = nomitech.common.db.local.ParamItemTable;
	using BoqItemTable = nomitech.common.db.project.BoqItemTable;

	[Serializable]
	public abstract class BoqItemToAssignmentTable : ResourceToAssignmentTable
	{
	  public virtual BoqItemTable BoqItemTable
	  {
		  get
		  {
			  return (BoqItemTable)ResourceTable;
		  }
	  }

	  public virtual decimal TotalUnits
	  {
		  get
		  {
			  return null;
		  }
		  set
		  {
		  }
	  }


	  public abstract long? ParamItemId {get;set;}


	  public abstract ParamItemTable ParamItemTable {get;set;}

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\base\BoqItemToAssignmentTable.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}