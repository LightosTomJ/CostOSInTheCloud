namespace Desktop.common.nomitech.common.migration.richardson
{
	public class RichardsonCrew
	{
	  private string crewId;

	  private double percentange;

	  private string craftId;

	  public RichardsonCrew(string paramString1, double paramDouble, string paramString2)
	  {
		this.crewId = paramString1;
		this.percentange = paramDouble;
		this.craftId = paramString2;
	  }

	  public virtual string CrewId
	  {
		  get
		  {
			  return this.crewId;
		  }
		  set
		  {
			  this.crewId = value;
		  }
	  }


	  public virtual double Percentange
	  {
		  get
		  {
			  return this.percentange;
		  }
		  set
		  {
			  this.percentange = value;
		  }
	  }


	  public virtual string CraftId
	  {
		  get
		  {
			  return this.craftId;
		  }
		  set
		  {
			  this.craftId = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\richardson\RichardsonCrew.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}