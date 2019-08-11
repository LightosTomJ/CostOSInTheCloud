namespace Desktop.common.nomitech.common.migration.rsmeans
{
	using EquipmentTable = nomitech.common.db.local.EquipmentTable;

	public class RSMeansEquipmentCrewItem
	{
	  private string masterFormat04;

	  private string description;

	  private double bareCost;

	  private EquipmentTable equipmentTable;

	  public RSMeansEquipmentCrewItem(string paramString1, string paramString2, double paramDouble, EquipmentTable paramEquipmentTable)
	  {
		this.masterFormat04 = paramString1;
		this.description = paramString2;
		this.bareCost = paramDouble;
		this.equipmentTable = paramEquipmentTable;
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


	  public virtual string MasterFormat04
	  {
		  get
		  {
			  return this.masterFormat04;
		  }
		  set
		  {
			  this.masterFormat04 = value;
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


	  public virtual EquipmentTable EquipmentTable
	  {
		  get
		  {
			  return this.equipmentTable;
		  }
		  set
		  {
			  this.equipmentTable = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\rsmeans\RSMeansEquipmentCrewItem.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}