using System.Collections.Generic;

namespace Desktop.common.nomitech.costos.plugin.api
{
	using ConditionTable = nomitech.common.db.project.ConditionTable;

	public interface AssignActionListener
	{
	  bool assignmentPerformed(ConditionTable[] paramArrayOfConditionTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void assignmentAdditionPerformed(java.util.List<ItemIdWithQuantities> paramList, nomitech.common.db.project.ConditionTable[] paramArrayOfConditionTable) throws Exception;
	  void assignmentAdditionPerformed(IList<ItemIdWithQuantities> paramList, ConditionTable[] paramArrayOfConditionTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void assignmentUpdatePerformed(java.util.List<ItemIdWithQuantities> paramList, nomitech.common.db.project.ConditionTable[] paramArrayOfConditionTable) throws Exception;
	  void assignmentUpdatePerformed(IList<ItemIdWithQuantities> paramList, ConditionTable[] paramArrayOfConditionTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void assignmentDeletionPerformed(java.util.List<long> paramList, nomitech.common.db.project.ConditionTable[] paramArrayOfConditionTable) throws Exception;
	  void assignmentDeletionPerformed(IList<long> paramList, ConditionTable[] paramArrayOfConditionTable);
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\plugin\api\AssignActionListener.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}