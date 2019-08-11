using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.@base
{

	[Serializable]
	public abstract class ResourceWithAssignmentsTable : ResourceTable
	{
	  public abstract decimal Productivity {get;set;}


	  public abstract object deepCopy(bool paramBoolean1, bool paramBoolean2);

	  public abstract ISet<object> getResourceAssignments(string paramString);

	  public abstract System.Collections.IList ResourceAssignmentsList {get;}

	  public abstract System.Collections.IList OrderedResourceAssignmentsList {get;}

	  public virtual bool? ActivityBased
	  {
		  get
		  {
			  return false;
		  }
		  set
		  {
		  }
	  }


	  protected internal virtual System.Collections.ICollection orderedList(ISet<object> paramSet)
	  {
		ResourceToAssignmentTable[] arrayOfResourceToAssignmentTable = (ResourceToAssignmentTable[])paramSet.toArray(new ResourceToAssignmentTable[paramSet.Count]);
		Arrays.sort(arrayOfResourceToAssignmentTable, new ComparatorAnonymousInnerClass(this));
		return Arrays.asList(arrayOfResourceToAssignmentTable);
	  }

	  private class ComparatorAnonymousInnerClass : IComparer<ResourceToAssignmentTable>
	  {
		  private readonly ResourceWithAssignmentsTable outerInstance;

		  public ComparatorAnonymousInnerClass(ResourceWithAssignmentsTable outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public int compare(ResourceToAssignmentTable param1ResourceToAssignmentTable1, ResourceToAssignmentTable param1ResourceToAssignmentTable2)
		  {
			int i = param1ResourceToAssignmentTable1.AssignmentResourceTable.Title.CompareTo(param1ResourceToAssignmentTable2.AssignmentResourceTable.Title);
			if (i == 0)
			{
			  if (param1ResourceToAssignmentTable1.AssignmentResourceTable.Id == null || param1ResourceToAssignmentTable2.AssignmentResourceTable.Id == null)
			  {
				return param1ResourceToAssignmentTable1.AssignmentResourceTable.Notes.CompareTo(param1ResourceToAssignmentTable2.AssignmentResourceTable.Notes);
			  }
			  i = param1ResourceToAssignmentTable1.CompareTo(param1ResourceToAssignmentTable2);
			}
			return i;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\base\ResourceWithAssignmentsTable.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}