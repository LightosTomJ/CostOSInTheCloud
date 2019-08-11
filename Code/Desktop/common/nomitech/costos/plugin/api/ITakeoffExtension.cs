using System.Collections.Generic;

namespace Desktop.common.nomitech.costos.plugin.api
{
	using ProjectDBUtil = nomitech.common.ProjectDBUtil;
	using FunctionTable = nomitech.common.db.local.FunctionTable;
	using ParamItemTable = nomitech.common.db.local.ParamItemTable;
	using BoqItemTable = nomitech.common.db.project.BoqItemTable;
	using ConditionTable = nomitech.common.db.project.ConditionTable;
	using UIProgress = nomitech.common.ui.UIProgress;

	public abstract class ITakeoffExtension : IProjectExtension
	{
	  protected internal AssignActionListener assignActionListener;

	  protected internal AddActionListener addActionListener;

	  public virtual AssignActionListener AssignActionListener
	  {
		  set
		  {
			  this.assignActionListener = value;
		  }
	  }

	  public virtual AddActionListener AddActionListener
	  {
		  set
		  {
			  this.addActionListener = value;
		  }
	  }

	  public virtual bool fireAssignment(ConditionTable[] paramArrayOfConditionTable)
	  {
		  return (this.assignActionListener != null) ? this.assignActionListener.assignmentPerformed(paramArrayOfConditionTable) : 0;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void fireAssignmentAddition(java.util.List<ItemIdWithQuantities> paramList, nomitech.common.db.project.ConditionTable[] paramArrayOfConditionTable) throws Exception
	  public virtual void fireAssignmentAddition(IList<ItemIdWithQuantities> paramList, ConditionTable[] paramArrayOfConditionTable)
	  {
		if (this.assignActionListener != null)
		{
		  this.assignActionListener.assignmentAdditionPerformed(paramList, paramArrayOfConditionTable);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void fireAssignmentUpdate(java.util.List<ItemIdWithQuantities> paramList, nomitech.common.db.project.ConditionTable[] paramArrayOfConditionTable) throws Exception
	  public virtual void fireAssignmentUpdate(IList<ItemIdWithQuantities> paramList, ConditionTable[] paramArrayOfConditionTable)
	  {
		if (this.assignActionListener != null)
		{
		  this.assignActionListener.assignmentUpdatePerformed(paramList, paramArrayOfConditionTable);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void fireAssignmentDeletion(java.util.List<long> paramList, nomitech.common.db.project.ConditionTable[] paramArrayOfConditionTable) throws Exception
	  public virtual void fireAssignmentDeletion(IList<long> paramList, ConditionTable[] paramArrayOfConditionTable)
	  {
		if (this.assignActionListener != null)
		{
		  this.assignActionListener.assignmentDeletionPerformed(paramList, paramArrayOfConditionTable);
		}
	  }

	  public virtual IList<long> fireAddition(BoqItemTable[] paramArrayOfBoqItemTable)
	  {
		  return (this.addActionListener != null) ? this.addActionListener.additionPerformed(paramArrayOfBoqItemTable) : Collections.EMPTY_LIST;
	  }

	  public abstract IRibbonMenuButton createAssignMenuButton();

	  public abstract IRibbonMenuButton createAdditionMenuButton();

	  public abstract IRibbonMenuButton createModifyMenuButton();

	  public abstract IInfoActionButton createAssignInfoActionButton();

	  public virtual IInfoActionButton createTakeoffQuantityInfoActionButton(ITakeoffQuantityCallback paramITakeoffQuantityCallback)
	  {
		  return null;
	  }

	  public abstract bool DialogShowing {get;}

	  public abstract void hideDialog();

	  public virtual bool hasVisualizer()
	  {
		  return false;
	  }

	  public virtual string TakeoffTypeIdentifier
	  {
		  get
		  {
			  return Name;
		  }
	  }

	  public override string Name
	  {
		  get
		  {
			  return "Undefined Takeoff Plug-In";
		  }
	  }

	  public virtual string VisualizerTitle
	  {
		  get
		  {
			  return null;
		  }
	  }

	  public virtual ImageIcon VisualizerIcon
	  {
		  get
		  {
			  return null;
		  }
	  }

	  public virtual IList<JComponent> getVisualizerToolBarButtons(ProjectDBUtil paramProjectDBUtil)
	  {
		  return Collections.EMPTY_LIST;
	  }

	  public virtual Component getVisualizerPanel(ProjectDBUtil paramProjectDBUtil)
	  {
		  return null;
	  }

	  public virtual void selectVisualizerItems(IList<ItemRow> paramList)
	  {
	  }

	  public virtual void assignmentsCreatedInCostOS(UIProgress paramUIProgress, IList<ItemRow> paramList1, IList<ConditionTable> paramList2)
	  {
	  }

	  public virtual void assignmentsDeletedInCostOS(UIProgress paramUIProgress, IList<ItemRow> paramList1, IList<ConditionTable> paramList2)
	  {
	  }

	  public virtual void assemblyUpdatedInCostOS(UIProgress paramUIProgress, ParamItemTable paramParamItemTable, IList<ITakeoffRequest> paramList)
	  {
	  }

	  public virtual void functionUpdatedInCostOS(UIProgress paramUIProgress, FunctionTable paramFunctionTable, IList<ITakeoffRequest> paramList)
	  {
	  }

	  public virtual ImageIcon iconOfTakeoff(ConditionTable paramConditionTable)
	  {
		  return null;
	  }

	  public override bool supportsDataSync()
	  {
		  return false;
	  }

	  public virtual void synchronizeTakeoffs(IList<TakeoffItemSyncRowData> paramList, bool paramBoolean, ITakeoffSyncCallback paramITakeoffSyncCallback)
	  {
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\plugin\api\ITakeoffExtension.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}