namespace Desktop.common.nomitech.common.migration.datamove.metadata
{
	public class BimProject
	{
	  internal long? id;

	  internal string name;

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


	  public override string ToString()
	  {
		  return this.name;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\datamove\metadata\BimProject.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}