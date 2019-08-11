namespace Desktop.common.nomitech.common.migration.rsmeans
{
	using LaborTable = nomitech.common.db.local.LaborTable;

	public class RSMeansLaborItem
	{
	  private string key;

	  private string description;

	  private double bareCost;

	  private double opCost;

	  private LaborTable laborTable;

	  public RSMeansLaborItem(string paramString1, string paramString2, double paramDouble1, double paramDouble2, LaborTable paramLaborTable)
	  {
		this.key = paramString1;
		this.description = paramString2;
		this.bareCost = paramDouble1;
		this.opCost = paramDouble2;
		this.laborTable = paramLaborTable;
	  }

	  public virtual string Key
	  {
		  get
		  {
			  return this.key;
		  }
		  set
		  {
			  this.key = value;
		  }
	  }


	  public virtual string Description
	  {
		  get
		  {
			  return this.description;
		  }
		  set
		  {
			  this.description = value;
		  }
	  }


	  public virtual double BareCost
	  {
		  get
		  {
			  return this.bareCost;
		  }
		  set
		  {
			  this.bareCost = value;
		  }
	  }


	  public virtual double OpCost
	  {
		  get
		  {
			  return this.opCost;
		  }
		  set
		  {
			  this.opCost = value;
		  }
	  }


	  public virtual double DifferceCost
	  {
		  get
		  {
			  return this.opCost - this.bareCost;
		  }
	  }

	  public virtual LaborTable LaborTable
	  {
		  get
		  {
			  return this.laborTable;
		  }
	  }

	  public virtual void getLaborTable(LaborTable paramLaborTable)
	  {
		  this.laborTable = paramLaborTable;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\rsmeans\RSMeansLaborItem.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}