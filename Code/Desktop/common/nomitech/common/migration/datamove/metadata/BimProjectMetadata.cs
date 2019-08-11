namespace Desktop.common.nomitech.common.migration.datamove.metadata
{
	public class BimProjectMetadata
	{
	  internal string name;

	  internal string globalId;

	  internal BimProjectMetadata parent;

	  public virtual string Name
	  {
		  get
		  {
			  return this.name;
		  }
		  set
		  {
			  this.name = value;
		  }
	  }


	  public virtual string GlobalId
	  {
		  get
		  {
			  return this.globalId;
		  }
		  set
		  {
			  this.globalId = value;
		  }
	  }


	  public virtual BimProjectMetadata Parent
	  {
		  get
		  {
			  return this.parent;
		  }
		  set
		  {
			  this.parent = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\datamove\metadata\BimProjectMetadata.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}