using System;

namespace Desktop.common.nomitech.common.@base
{

	[Serializable]
	public abstract class ResourceToResourceTable : ResourceTable
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @XmlTransient public abstract String getParentResourceTitle();
	  public abstract string ParentResourceTitle {get;set;}


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @XmlTransient public abstract ResourceWithAssignmentsTable getParentResourceTable();
	  public abstract ResourceWithAssignmentsTable ParentResourceTable {get;set;}


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient public abstract ResourceToResourceTable copyWithParent();
	  public abstract ResourceToResourceTable copyWithParent();
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\base\ResourceToResourceTable.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}