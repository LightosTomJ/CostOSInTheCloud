namespace Desktop.common.nomitech.common.migration.datamove.metadata
{
	public class BimModelMetadata
	{
	  internal long? originalId;

	  internal long? id;

	  internal string globalId;

	  internal string name;

	  internal BimProjectMetadata project;

	  public virtual long? OriginalId
	  {
		  get
		  {
			  return this.originalId;
		  }
		  set
		  {
			  this.originalId = value;
		  }
	  }


	  public virtual long? Id
	  {
		  get
		  {
			  return this.id;
		  }
		  set
		  {
			  this.id = value;
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


	  public virtual BimProjectMetadata Project
	  {
		  get
		  {
			  return this.project;
		  }
		  set
		  {
			  this.project = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\datamove\metadata\BimModelMetadata.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}