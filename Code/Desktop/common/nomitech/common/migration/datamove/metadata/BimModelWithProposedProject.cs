namespace Desktop.common.nomitech.common.migration.datamove.metadata
{
	public class BimModelWithProposedProject
	{
	  internal long? modelId;

	  internal string modelName;

	  internal long? proposedProjectId;

	  public virtual long? ModelId
	  {
		  get
		  {
			  return this.modelId;
		  }
		  set
		  {
			  this.modelId = value;
		  }
	  }


	  public virtual string ModelName
	  {
		  get
		  {
			  return this.modelName;
		  }
		  set
		  {
			  this.modelName = value;
		  }
	  }


	  public virtual long? ProposedProjectId
	  {
		  get
		  {
			  return this.proposedProjectId;
		  }
		  set
		  {
			  this.proposedProjectId = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\datamove\metadata\BimModelWithProposedProject.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}