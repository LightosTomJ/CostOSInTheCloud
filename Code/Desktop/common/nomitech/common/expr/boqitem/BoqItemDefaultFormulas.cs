using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.expr.boqitem
{

	public class BoqItemDefaultFormulas
	{
	  private static readonly BoqItemDefaultFormulas s_instance = new BoqItemDefaultFormulas();

	  private IDictionary<string, string> fieldToFormulaMap = new Hashtable();

	  private BoqItemDefaultFormulas()
	  {
		string str1 = BoqItemFormulaEvaluator.variableFromField("escalationCost");
		string str2 = BoqItemFormulaEvaluator.variableFromField("offeredPrice");
		string str3 = BoqItemFormulaEvaluator.variableFromField("totalCost");
		string str4 = BoqItemFormulaEvaluator.variableFromField("assemblyTotalCost");
		string str5 = BoqItemFormulaEvaluator.variableFromField("materialTotalCost");
		string str6 = BoqItemFormulaEvaluator.variableFromField("subcontractorTotalCost");
		string str7 = BoqItemFormulaEvaluator.variableFromField("equipmentTotalCost");
		string str8 = BoqItemFormulaEvaluator.variableFromField("laborTotalCost");
		string str9 = BoqItemFormulaEvaluator.variableFromField("consumableTotalCost");
		string str10 = BoqItemFormulaEvaluator.variableFromField("markup");
		string str11 = BoqItemFormulaEvaluator.variableFromField("productivity");
		string str12 = BoqItemFormulaEvaluator.variableFromField("prodFactor");
		string str13 = BoqItemFormulaEvaluator.variableFromField("mhoursFactor");
		string str14 = BoqItemFormulaEvaluator.variableFromField("adjustedProd");
		string str15 = BoqItemFormulaEvaluator.variableFromField("duration");
		string str16 = BoqItemFormulaEvaluator.variableFromField("unitManhours");
		string str17 = BoqItemFormulaEvaluator.variableFromField("laborManhours");
		string str18 = BoqItemFormulaEvaluator.variableFromField("rate");
		string str19 = BoqItemFormulaEvaluator.variableFromField("unit");
		string str20 = BoqItemFormulaEvaluator.variableFromField("secondRate");
		string str21 = BoqItemFormulaEvaluator.variableFromField("unitsDiv");
		string str22 = BoqItemFormulaEvaluator.variableFromField("quantity");
		string str23 = BoqItemFormulaEvaluator.variableFromField("secondQuantity");
		string str24 = BoqItemFormulaEvaluator.variableFromField("measuredQuantity");
		string str25 = BoqItemFormulaEvaluator.variableFromField("estimatedQuantity");
		string str26 = BoqItemFormulaEvaluator.variableFromField("assemblyRate");
		string str27 = BoqItemFormulaEvaluator.variableFromField("materialRate");
		string str28 = BoqItemFormulaEvaluator.variableFromField("subcontractorRate");
		string str29 = BoqItemFormulaEvaluator.variableFromField("equipmentRate");
		string str30 = BoqItemFormulaEvaluator.variableFromField("laborRate");
		string str31 = BoqItemFormulaEvaluator.variableFromField("consumableRate");
		string str32 = BoqItemFormulaEvaluator.variableFromField("fixedCost");
		this.fieldToFormulaMap["totalCost"] = "(" + str18 + "*" + str22 + ")+" + str32;
		this.fieldToFormulaMap["offeredPrice"] = str3 + "+" + str1 + "+" + str10;
		this.fieldToFormulaMap["quantityLoss"] = "IF(AND(" + str24 + "<>0," + str25 + "<>0),(ABS(" + str24 + "-" + str25 + ")),0)";
		this.fieldToFormulaMap["quantity"] = "IF(" + str24 + "<>0," + str24 + "," + str25 + ")";
		this.fieldToFormulaMap["rate"] = str29 + "+" + str28 + "+" + str27 + "+" + str30 + "+" + str31;
		this.fieldToFormulaMap["secondRate"] = str18 + "*" + str21;
		this.fieldToFormulaMap["secondQuantity"] = "IF(UNITS_DIV<>0," + str22 + "/" + str21 + ",0)";
		this.fieldToFormulaMap["secondUnit"] = "UNIT1_TO_UNIT2(" + str19 + ")";
		this.fieldToFormulaMap["unitsDiv"] = "UNIT1_TO_UNIT2_DIV(" + str19 + ")";
		this.fieldToFormulaMap["offeredRate"] = "IF(" + str22 + "<>0," + str2 + "/" + str22 + ",0)";
		this.fieldToFormulaMap["offeredSecondRate"] = "IF(" + str23 + "<>0," + str2 + "/" + str23 + ",0)";
		this.fieldToFormulaMap["productivity"] = "IF(" + str15 + "<>0,IF(" + str12 + "<>0,(" + str22 + "/" + str15 + ")/" + str12 + "," + str22 + "/" + str15 + "),0)";
		this.fieldToFormulaMap["duration"] = "IF(" + str14 + "<>0," + str22 + "/" + str14 + ",0)";
		this.fieldToFormulaMap["mhoursFactor"] = "IF(" + str12 + "<>0," + '\x0001' + "/" + str12 + ",0)";
		this.fieldToFormulaMap["prodFactor"] = "IF(" + str13 + "<>0," + '\x0001' + "/" + str13 + ",0)";
		this.fieldToFormulaMap["adjustedProd"] = "IF(" + str12 + "<>0," + str11 + "*" + str12 + "," + str11 + ")";
		this.fieldToFormulaMap["assemblyTotalCost"] = str26 + "*" + str22;
		this.fieldToFormulaMap["materialTotalCost"] = str27 + "*" + str22;
		this.fieldToFormulaMap["subcontractorTotalCost"] = str28 + "*" + str22;
		this.fieldToFormulaMap["equipmentTotalCost"] = str29 + "*" + str22;
		this.fieldToFormulaMap["laborTotalCost"] = str30 + "*" + str22;
		this.fieldToFormulaMap["consumableTotalCost"] = str31 + "*" + str22;
		this.fieldToFormulaMap["unitManhours"] = "IF(" + str22 + "<>0,IF(" + str12 + "<>0,(" + str17 + "/" + str22 + ")*" + str12 + "," + str17 + "/" + str22 + "),0)";
		this.fieldToFormulaMap["adjustedUnitManhours"] = "IF(" + str22 + "<>0," + str17 + "/" + str22 + ",0)";
	  }

	  public virtual string getDefaultFormulaForField(string paramString)
	  {
		  return (string)this.fieldToFormulaMap[paramString];
	  }

	  public static BoqItemDefaultFormulas Instance
	  {
		  get
		  {
			  return s_instance;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\boqitem\BoqItemDefaultFormulas.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}