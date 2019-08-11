using System.Collections.Generic;

namespace Desktop.common.nomitech.common.migration.mc2
{

	public class MC2Crew
	{
	  private string crewId;

	  private string crewDescription;

	  private string crewUom;

	  private IList<MC2ResourceItem> crewItems = new LinkedList();

	  public MC2Crew(string paramString1, string paramString2, string paramString3)
	  {
		this.crewId = paramString1;
		this.crewDescription = paramString2;
		this.crewUom = paramString3;
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


	  public virtual string CrewUom
	  {
		  get
		  {
			  return this.crewUom;
		  }
		  set
		  {
			  this.crewUom = value;
		  }
	  }


	  public virtual string CrewDescription
	  {
		  get
		  {
			  return this.crewDescription;
		  }
		  set
		  {
			  this.crewDescription = value;
		  }
	  }


	  public virtual IList<MC2ResourceItem> CrewItems
	  {
		  get
		  {
			  return this.crewItems;
		  }
		  set
		  {
			  this.crewItems = value;
		  }
	  }


	  public override bool Equals(object paramObject)
	  {
		  return !(paramObject is MC2Crew) ? false : ((MC2Crew)paramObject).crewId.Equals(this.crewId);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\mc2\MC2Crew.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}