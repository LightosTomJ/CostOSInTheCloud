using System;

namespace Desktop.common.nomitech.common
{

	public sealed class DataFlavors
	{
	  public static readonly DataFlavor rtfDataFlavor = new MimeTypeDataFlavor("text/rtf", "java.lang.String", "Rich Text Format");

	  public static readonly DataFlavor htmlDataFlavor = new MimeTypeDataFlavor("text/html", "java.lang.String", "HTML Format");

	  public static readonly DataFlavor htmlInputStreamDataFlavor = new MimeTypeDataFlavor("text/html", "java.io.InputStream", "HTML Input Stream Format");

	  public static readonly ComparableDataFlavor paramItemInputDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ParamItemInputTableList), "ParamItemInputTableList");

	  public static readonly ComparableDataFlavor paramItemOutputDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ParamItemOutputTableList), "ParamItemOutputTableList");

	  public static readonly ComparableDataFlavor exprWithDefinitionDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.expr.ExprWithDefinition), "ExprWithDefinition");

	  public static readonly ComparableDataFlavor paramItemDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ParamItemTable), "ParamItem");

	  public static readonly ComparableDataFlavor paramItemListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ParamItemTable), "ParamItemList");

	  public static readonly ComparableDataFlavor laborDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.LaborTable), "Labor");

	  public static readonly ComparableDataFlavor laborListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.LaborTableList), "LaborList");

	  public static readonly ComparableDataFlavor equipmentDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.EquipmentTable), "Equipment");

	  public static readonly ComparableDataFlavor equipmentListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.EquipmentTableList), "EquipmentList");

	  public static readonly ComparableDataFlavor materialDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.MaterialTable), "Material");

	  public static readonly ComparableDataFlavor materialListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.MaterialTableList), "MaterialList");

	  public static readonly ComparableDataFlavor subcontractorDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.SubcontractorTable), "Subcontractor");

	  public static readonly ComparableDataFlavor subcontractorListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.SubcontractorTableList), "SubcontractorList");

	  public static readonly ComparableDataFlavor supplierDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.SupplierTable), "Supplier");

	  public static readonly ComparableDataFlavor supplierListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.SupplierTableList), "SupplierList");

	  public static readonly ComparableDataFlavor functionDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.FunctionTable), "Function");

	  public static readonly ComparableDataFlavor functionListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.FunctionTableList), "FuncyionList");

	  public static readonly ComparableDataFlavor assemblyDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.AssemblyTable), "Assembly");

	  public static readonly ComparableDataFlavor assemblyListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.AssemblyTableList), "AssemblyList");

	  public static readonly ComparableDataFlavor consumableDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ConsumableTable), "Consumable");

	  public static readonly ComparableDataFlavor consumableListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ConsumableTableList), "ConsumableList");

	  public static readonly ComparableDataFlavor boqitemDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.project.BoqItemTable), "BoqItem");

	  public static readonly ComparableDataFlavor boqitemListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.project.BoqItemTableList), "BoqItemList");

	  public static readonly ComparableDataFlavor boqitemWithGroupCodeListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.project.BoqItemWithGroupCodeTableList), "BoqItemWithGroupCodeList");

	  public static readonly ComparableDataFlavor conditionListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.project.ConditionTableList), "ConditionList");

	  public static readonly ComparableDataFlavor groupCodeDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.GroupCodeTable), "GroupCode");

	  public static readonly ComparableDataFlavor groupCodeListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.GroupCodeTableList), "GroupCodeList");

	  public static readonly ComparableDataFlavor gekCodeDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.GekCodeTable), "GekCode");

	  public static readonly ComparableDataFlavor gekCodeListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.GekCodeTableList), "GekCodeList");

	  public static readonly ComparableDataFlavor projectInfoListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ProjectInfoTableList), "ProjectInfoList");

	  public static readonly ComparableDataFlavor projectInfoDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ProjectInfoTable), "ProjectInfo");

	  public static readonly ComparableDataFlavor projectWBSDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ProjectWBSTable), "ProjectWBS");

	  public static readonly ComparableDataFlavor projectWBS2DataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ProjectWBS2Table), "ProjectWBS2");

	  public static readonly ComparableDataFlavor salaryDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.project.SalaryTable), "Salary");

	  public static readonly ComparableDataFlavor salaryListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.project.SalaryTableList), "SalaryList");

	  public static readonly ComparableDataFlavor expenseDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.project.ExpenseTable), "Expense");

	  public static readonly ComparableDataFlavor expenseListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.project.ExpenseTableList), "ExpenseList");

	  public static readonly ComparableDataFlavor extraCode1DataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode1Table), "ExtraCode1");

	  public static readonly ComparableDataFlavor extraCode1ListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode1TableList), "ExtraCode1List");

	  public static readonly ComparableDataFlavor extraCode2DataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode2Table), "ExtraCode2");

	  public static readonly ComparableDataFlavor extraCode2ListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode2TableList), "ExtraCode2List");

	  public static readonly ComparableDataFlavor extraCode3DataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode3Table), "ExtraCode3");

	  public static readonly ComparableDataFlavor extraCode3ListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode3TableList), "ExtraCode3List");

	  public static readonly ComparableDataFlavor extraCode4DataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode4Table), "ExtraCode4");

	  public static readonly ComparableDataFlavor extraCode4ListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode4TableList), "ExtraCode4List");

	  public static readonly ComparableDataFlavor extraCode5DataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode5Table), "ExtraCode5");

	  public static readonly ComparableDataFlavor extraCode5ListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode5TableList), "ExtraCode5List");

	  public static readonly ComparableDataFlavor extraCode6DataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode6Table), "ExtraCode6");

	  public static readonly ComparableDataFlavor extraCode6ListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode6TableList), "ExtraCode6List");

	  public static readonly ComparableDataFlavor extraCode7DataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode7Table), "ExtraCode7");

	  public static readonly ComparableDataFlavor extraCode7ListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode7TableList), "ExtraCode7List");

	  public static readonly ComparableDataFlavor extraCode8DataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode8Table), "ExtraCode8");

	  public static readonly ComparableDataFlavor extraCode8ListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode8TableList), "ExtraCode8List");

	  public static readonly ComparableDataFlavor extraCode9DataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode9Table), "ExtraCode9");

	  public static readonly ComparableDataFlavor extraCode9ListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode9TableList), "ExtraCode9List");

	  public static readonly ComparableDataFlavor extraCode10DataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode10Table), "ExtraCode10");

	  public static readonly ComparableDataFlavor extraCode10ListDataFlavor = new ComparableDataFlavor(typeof(Desktop.common.nomitech.common.db.local.ExtraCode10TableList), "ExtraCode10List");

	  public class MimeTypeDataFlavor : DataFlavor
	  {
		internal string mime;

		public MimeTypeDataFlavor(string param1String1, string param1String2, string param1String3) : base(param1String1 + ";class=" + param1String2, param1String3)
		{
		  this.mime = param1String1.ToLower();
		}

		public override bool Equals(object param1Object)
		{
		  if (param1Object is MimeTypeDataFlavor)
		  {
			return base.Equals(param1Object);
		  }
		  if (param1Object is DataFlavor)
		  {
			DataFlavor dataFlavor = (DataFlavor)param1Object;
			return (dataFlavor.MimeType.ToLower().IndexOf(this.mime, StringComparison.Ordinal) != -1);
		  }
		  return base.Equals(param1Object);
		}
	  }

	  public class ComparableDataFlavor : DataFlavor
	  {
		internal const long serialVersionUID = 1L;

		public ComparableDataFlavor(Type param1Class, string param1String) : base(param1Class, param1String)
		{
		}

		public override bool Equals(object param1Object)
		{
		  if (!(param1Object is ComparableDataFlavor))
		  {
			return false;
		  }
		  Type clazz1 = ((ComparableDataFlavor)param1Object).RepresentationClass;
		  Type clazz2 = RepresentationClass;
		  return clazz1.ToString().Equals(clazz2.ToString());
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\DataFlavors.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}