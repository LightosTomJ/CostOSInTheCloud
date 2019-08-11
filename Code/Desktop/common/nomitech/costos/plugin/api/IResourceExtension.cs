using System.Collections.Generic;

namespace Desktop.common.nomitech.costos.plugin.api
{
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using BoqItemTable = nomitech.common.db.project.BoqItemTable;

	public abstract class IResourceExtension : IProjectExtension
	{
	  protected internal AssignResourcesActionListener assignActionListener;

	  protected internal AddActionListener addActionListener;

	  public virtual AssignResourcesActionListener AssignActionListener
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

	  public virtual void fireAssignment(ResourceTable[] paramArrayOfResourceTable)
	  {
		if (this.assignActionListener != null)
		{
		  this.assignActionListener.assignmentPerformed(paramArrayOfResourceTable);
		}
	  }

	  public virtual IList<long> fireAddition(BoqItemTable[] paramArrayOfBoqItemTable)
	  {
		  return (this.addActionListener != null) ? this.addActionListener.additionPerformed(paramArrayOfBoqItemTable) : Collections.EMPTY_LIST;
	  }

	  public abstract IRibbonMenuButton createAssignMenuButton();

	  public abstract IRibbonMenuButton createAdditionMenuButton();

	  public abstract IInfoActionButton createAssignInfoActionButton();

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
			  return "Undefined Resource Plug-In";
		  }
	  }

	  public override object callExtension(string paramString, long? paramLong)
	  {
		  return null;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\plugin\api\IResourceExtension.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}