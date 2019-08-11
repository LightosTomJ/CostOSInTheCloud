using System;

namespace Desktop.common.nomitech.common.data.definition
{
	public class ResourceToResourceTableDefinitionWrapper : AssignmentTableDefinition
	{
	  private ResourceTableDefinition o_definition;

	  private ResourceTableDefinition o_parent;

	  public ResourceToResourceTableDefinitionWrapper(ResourceTableDefinition paramResourceTableDefinition1, ResourceTableDefinition paramResourceTableDefinition2)
	  {
		this.o_definition = paramResourceTableDefinition1;
		this.o_parent = paramResourceTableDefinition2;
	  }

	  public override string[] Fields
	  {
		  get
		  {
			  return this.o_definition.Fields;
		  }
	  }

	  public override string[] ColumnNames
	  {
		  get
		  {
			  return this.o_definition.ColumnNames;
		  }
	  }

	  public override Type[] Classes
	  {
		  get
		  {
			  return this.o_definition.Classes;
		  }
	  }

	  public override bool isFieldEditable(string paramString)
	  {
		  return (paramString.Equals("supplierName") || paramString.Equals("subcontractorName")) ? false : this.o_definition.isFieldEditable(paramString);
	  }

	  public override ResourceTableDefinition ResourceTableDefinition
	  {
		  get
		  {
			  return this.o_definition;
		  }
	  }

	  public virtual ResourceTableDefinition ParentResourceTableDefinition
	  {
		  get
		  {
			  return this.o_parent;
		  }
	  }

	  public override string[] DefaultColumnNames
	  {
		  get
		  {
			  return ColumnNames;
		  }
	  }

	  public override Type TableClass
	  {
		  get
		  {
			  return this.o_definition.TableClass;
		  }
	  }

	  public override int DialogAssignmentType
	  {
		  get
		  {
			  return 0;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\data\definition\ResourceToResourceTableDefinitionWrapper.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}