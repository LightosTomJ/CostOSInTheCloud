namespace Desktop.common.nomitech.common.data.descriptor
{
	using UILanguage = nomitech.common.ui.UILanguage;

	public class DynProjectsViewDescriptor : BaseViewDescriptor
	{
	  private static DynProjectsViewDescriptor s_instance = null;

	  private DataObjectDescriptor[] ALL_FIELDS = null;

	  public static DynProjectsViewDescriptor Instance
	  {
		  get
		  {
			if (s_instance == null)
			{
			  s_instance = new DynProjectsViewDescriptor();
			}
			return s_instance;
		  }
	  }

	  private DynProjectsViewDescriptor()
	  {
		  this.ALL_FIELDS = loadAllFileds();
	  }

	  private DataObjectDescriptor[] loadAllFileds()
	  {
		  return new DataObjectDescriptor[]
		  {
			  new DataObjectDescriptor("code", "CODE", "code", UILanguage.get("tab.pselect.column.code"), "Text"),
			  new DataObjectDescriptor("title", "TITLE", "title", UILanguage.get("tab.pselect.column.title"), "Text"),
			  new DataObjectDescriptor("projectType", "PRJTYPE", "projectType", UILanguage.get("tab.pselect.column.type"), "Text"),
			  new DataObjectDescriptor("client", "CLIENT", "client", UILanguage.get("tab.pselect.column.client"), "Text"),
			  new DataObjectDescriptor("location", "LOCATION", "location", UILanguage.get("tab.pselect.column.location"), "Text"),
			  new DataObjectDescriptor("stateProvince", "STATE", "stateProvince", UILanguage.get("tab.pselect.column.stateProvince"), "Text"),
			  new DataObjectDescriptor("country", "COUNTRY", "country", UILanguage.get("tab.pselect.column.country"), "Text"),
			  new DataObjectDescriptor("currency", "CURRENCY", "currency", UILanguage.get("tab.pselect.column.currency"), "Text"),
			  new DataObjectDescriptor("status", "STATUS", "status", UILanguage.get("tab.pselect.column.status"), "Text"),
			  new DataObjectDescriptor("submissionDate", "SUBDATE", "submissionDate", UILanguage.get("tab.pselect.column.submissionDate"), "Date"),
			  new DataObjectDescriptor("unitCost", "UNITCOST", "unitCost", UILanguage.get("tab.pselect.column.unitCost"), "Decimal"),
			  new DataObjectDescriptor("basementSize", "BASEMENT", "basementSize", UILanguage.get("tab.projectdetails.table.basementsqm"), "Decimal"),
			  new DataObjectDescriptor("superstructureSize", "MAINSITE", "superstructureSize", UILanguage.get("tab.projectdetails.table.mainsqm"), "Decimal"),
			  new DataObjectDescriptor("unit", "UNIT", "unit", UILanguage.get("tab.pselect.column.unit"), "Text"),
			  new DataObjectDescriptor("customCumRate1", "CUSCUMRATE1", "customCumRate1", UILanguage.get("tab.boqitem.column.customCumRate1"), "Decimal"),
			  new DataObjectDescriptor("customCumRate2", "CUSCUMRATE2", "customCumRate2", UILanguage.get("tab.boqitem.column.customCumRate2"), "Decimal"),
			  new DataObjectDescriptor("customCumRate3", "CUSCUMRATE3", "customCumRate3", UILanguage.get("tab.boqitem.column.customCumRate3"), "Decimal"),
			  new DataObjectDescriptor("customCumRate4", "CUSCUMRATE4", "customCumRate4", UILanguage.get("tab.boqitem.column.customCumRate4"), "Decimal"),
			  new DataObjectDescriptor("customCumRate5", "CUSCUMRATE5", "customCumRate5", UILanguage.get("tab.boqitem.column.customCumRate5"), "Decimal"),
			  new DataObjectDescriptor("customCumRate6", "CUSCUMRATE6", "customCumRate6", UILanguage.get("tab.boqitem.column.customCumRate6"), "Decimal"),
			  new DataObjectDescriptor("customCumRate7", "CUSCUMRATE7", "customCumRate7", UILanguage.get("tab.boqitem.column.customCumRate7"), "Decimal"),
			  new DataObjectDescriptor("customCumRate8", "CUSCUMRATE8", "customCumRate8", UILanguage.get("tab.boqitem.column.customCumRate8"), "Decimal"),
			  new DataObjectDescriptor("customCumRate9", "CUSCUMRATE9", "customCumRate9", UILanguage.get("tab.boqitem.column.customCumRate9"), "Decimal"),
			  new DataObjectDescriptor("customCumRate10", "CUSCUMRATE10", "customCumRate10", UILanguage.get("tab.boqitem.column.customCumRate10"), "Decimal"),
			  new DataObjectDescriptor("equipmentTotalCost", "EQUCOST", "equipmentTotalCost", UILanguage.get("tab.boqitem.column.equipmentTotalCost"), "Decimal"),
			  new DataObjectDescriptor("subcontractorTotalCost", "SUBCOST", "subcontractorTotalCost", UILanguage.get("tab.boqitem.column.subcontractorTotalCost"), "Decimal"),
			  new DataObjectDescriptor("laborTotalCost", "LABCOST", "laborTotalCost", UILanguage.get("tab.boqitem.column.laborTotalCost"), "Decimal"),
			  new DataObjectDescriptor("materialTotalCost", "MATCOST", "materialTotalCost", UILanguage.get("tab.boqitem.column.materialTotalCost"), "Decimal"),
			  new DataObjectDescriptor("consumableTotalCost", "CONCOST", "consumableTotalCost", UILanguage.get("tab.boqitem.column.consumableTotalCost"), "Decimal"),
			  new DataObjectDescriptor("laborManhours", "MANHOURS", "laborManhours", UILanguage.get("tab.boqitem.column.laborManhours"), "Decimal"),
			  new DataObjectDescriptor("equipmentHours", "EQUHOURS", "equipmentHours", UILanguage.get("tab.boqitem.column.equipmentHours"), "Decimal"),
			  new DataObjectDescriptor("totalCost", "TOTALCOST", "totalCost", UILanguage.get("tab.pselect.column.totalCost"), "Decimal"),
			  new DataObjectDescriptor("offeredPrice", "OFFEREDPRICE", "offeredPrice", UILanguage.get("tab.pselect.column.offeredPrice"), "Decimal"),
			  new DataObjectDescriptor("lastUpdate", "LASTUPDATE", "lastUpdate", UILanguage.get("tab.pselect.column.lastUpdate"), "Date")
		  };
	  }

	  public override DataObjectDescriptor[] All
	  {
		  get
		  {
			  return this.ALL_FIELDS;
		  }
	  }

	  public override string ViewName
	  {
		  get
		  {
			  return null;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\data\descriptor\DynProjectsViewDescriptor.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}