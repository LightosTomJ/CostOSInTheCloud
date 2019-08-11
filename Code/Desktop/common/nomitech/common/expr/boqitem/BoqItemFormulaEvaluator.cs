using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Desktop.common.nomitech.common.expr.boqitem
{
	using BoqItemTable = nomitech.common.db.project.BoqItemTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using Expr = org.boris.expr.Expr;
	using ExprBoolean = org.boris.expr.ExprBoolean;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprException = org.boris.expr.ExprException;
	using ExprString = org.boris.expr.ExprString;

	public class BoqItemFormulaEvaluator
	{
	  private static IDictionary<string, string> VARIABLE_ALIASES;

	  private static IDictionary<string, string> FIELD_ALIASES;

	  private static IDictionary<string, string> FieldAliasMap
	  {
		  get
		  {
			if (FIELD_ALIASES != null)
			{
			  return FIELD_ALIASES;
			}
			FIELD_ALIASES = new Hashtable();
			foreach (string str in VariableAliasMap.Keys)
			{
			  FIELD_ALIASES[VariableAliasMap[str]] = str;
			}
			return FIELD_ALIASES;
		  }
	  }

	  private static IDictionary<string, string> VariableAliasMap
	  {
		  get
		  {
			if (VARIABLE_ALIASES != null)
			{
			  return VARIABLE_ALIASES;
			}
			VARIABLE_ALIASES = new Hashtable();
			VARIABLE_ALIASES["measuredQuantity"] = "TAKEOFF_QUANTITY";
			VARIABLE_ALIASES["estimatedQuantity"] = "ESTIMATED_QUANTITY";
			VARIABLE_ALIASES["groupCode"] = "GROUP_CODE1";
			VARIABLE_ALIASES["gekCode"] = "GROUP_CODE2";
			VARIABLE_ALIASES["extraCode1"] = "GROUP_CODE3";
			VARIABLE_ALIASES["extraCode2"] = "GROUP_CODE4";
			VARIABLE_ALIASES["extraCode3"] = "GROUP_CODE5";
			VARIABLE_ALIASES["extraCode4"] = "GROUP_CODE6";
			VARIABLE_ALIASES["extraCode5"] = "GROUP_CODE7";
			VARIABLE_ALIASES["extraCode6"] = "GROUP_CODE8";
			VARIABLE_ALIASES["extraCode7"] = "GROUP_CODE9";
			VARIABLE_ALIASES["wbsCode"] = "WBS_CODE1";
			VARIABLE_ALIASES["wbs2Code"] = "WBS_CODE2";
			VARIABLE_ALIASES["adjustedProd"] = "ADJUSTED_PRODUCTIVITY";
			VARIABLE_ALIASES["prodFactor"] = "PRODUCTIVITY_FACTOR";
			VARIABLE_ALIASES["mhoursFactor"] = "MANHOURS_FACTOR";
			VARIABLE_ALIASES["puGroupCodeFactor"] = "GROUP_CODE1_PU_FACTOR";
			VARIABLE_ALIASES["puGekCodeFactor"] = "GROUP_CODE2_PU_FACTOR";
			VARIABLE_ALIASES["puExtraCode1Factor"] = "GROUP_CODE3_PU_FACTOR";
			VARIABLE_ALIASES["puExtraCode2Factor"] = "GROUP_CODE4_PU_FACTOR";
			VARIABLE_ALIASES["puExtraCode3Factor"] = "GROUP_CODE5_PU_FACTOR";
			VARIABLE_ALIASES["puExtraCode4Factor"] = "GROUP_CODE6_PU_FACTOR";
			VARIABLE_ALIASES["puExtraCode5Factor"] = "GROUP_CODE7_PU_FACTOR";
			VARIABLE_ALIASES["puExtraCode6Factor"] = "GROUP_CODE8_PU_FACTOR";
			VARIABLE_ALIASES["puExtraCode7Factor"] = "GROUP_CODE9_PU_FACTOR";
			VARIABLE_ALIASES["rate"] = "TOTAL_RATE";
			VARIABLE_ALIASES["customRate1"] = "CUSTOM_DECIMAL1";
			VARIABLE_ALIASES["customRate2"] = "CUSTOM_DECIMAL2";
			VARIABLE_ALIASES["customRate3"] = "CUSTOM_DECIMAL3";
			VARIABLE_ALIASES["customRate4"] = "CUSTOM_DECIMAL4";
			VARIABLE_ALIASES["customRate5"] = "CUSTOM_DECIMAL5";
			VARIABLE_ALIASES["customRate6"] = "CUSTOM_DECIMAL6";
			VARIABLE_ALIASES["customRate7"] = "CUSTOM_DECIMAL7";
			VARIABLE_ALIASES["customRate8"] = "CUSTOM_DECIMAL8";
			VARIABLE_ALIASES["customRate9"] = "CUSTOM_DECIMAL9";
			VARIABLE_ALIASES["customRate10"] = "CUSTOM_DECIMAL10";
			VARIABLE_ALIASES["customRate11"] = "CUSTOM_DECIMAL11";
			VARIABLE_ALIASES["customRate12"] = "CUSTOM_DECIMAL12";
			VARIABLE_ALIASES["customRate13"] = "CUSTOM_DECIMAL13";
			VARIABLE_ALIASES["customRate14"] = "CUSTOM_DECIMAL14";
			VARIABLE_ALIASES["customRate15"] = "CUSTOM_DECIMAL15";
			VARIABLE_ALIASES["customRate16"] = "CUSTOM_DECIMAL16";
			VARIABLE_ALIASES["customRate17"] = "CUSTOM_DECIMAL17";
			VARIABLE_ALIASES["customRate18"] = "CUSTOM_DECIMAL18";
			VARIABLE_ALIASES["customRate19"] = "CUSTOM_DECIMAL19";
			VARIABLE_ALIASES["customRate20"] = "CUSTOM_DECIMAL20";
			VARIABLE_ALIASES["customCumRate1"] = "CUSTOM_CUM_DECIMAL1";
			VARIABLE_ALIASES["customCumRate2"] = "CUSTOM_CUM_DECIMAL2";
			VARIABLE_ALIASES["customCumRate3"] = "CUSTOM_CUM_DECIMAL3";
			VARIABLE_ALIASES["customCumRate4"] = "CUSTOM_CUM_DECIMAL4";
			VARIABLE_ALIASES["customCumRate5"] = "CUSTOM_CUM_DECIMAL5";
			VARIABLE_ALIASES["customCumRate6"] = "CUSTOM_CUM_DECIMAL6";
			VARIABLE_ALIASES["customCumRate7"] = "CUSTOM_CUM_DECIMAL7";
			VARIABLE_ALIASES["customCumRate8"] = "CUSTOM_CUM_DECIMAL8";
			VARIABLE_ALIASES["customCumRate9"] = "CUSTOM_CUM_DECIMAL9";
			VARIABLE_ALIASES["customCumRate10"] = "CUSTOM_CUM_DECIMAL10";
			VARIABLE_ALIASES["customCumRate11"] = "CUSTOM_CUM_DECIMAL11";
			VARIABLE_ALIASES["customCumRate12"] = "CUSTOM_CUM_DECIMAL12";
			VARIABLE_ALIASES["customCumRate13"] = "CUSTOM_CUM_DECIMAL13";
			VARIABLE_ALIASES["customCumRate14"] = "CUSTOM_CUM_DECIMAL14";
			VARIABLE_ALIASES["customCumRate15"] = "CUSTOM_CUM_DECIMAL15";
			VARIABLE_ALIASES["customCumRate16"] = "CUSTOM_CUM_DECIMAL16";
			VARIABLE_ALIASES["customCumRate17"] = "CUSTOM_CUM_DECIMAL17";
			VARIABLE_ALIASES["customCumRate18"] = "CUSTOM_CUM_DECIMAL18";
			VARIABLE_ALIASES["customCumRate19"] = "CUSTOM_CUM_DECIMAL19";
			VARIABLE_ALIASES["customCumRate20"] = "CUSTOM_CUM_DECIMAL20";
			VARIABLE_ALIASES["customPercentRate1"] = "CUSTOM_PERCENTAGE1";
			VARIABLE_ALIASES["customPercentRate2"] = "CUSTOM_PERCENTAGE2";
			VARIABLE_ALIASES["customPercentRate3"] = "CUSTOM_PERCENTAGE3";
			VARIABLE_ALIASES["customPercentRate4"] = "CUSTOM_PERCENTAGE4";
			VARIABLE_ALIASES["customPercentRate5"] = "CUSTOM_PERCENTAGE5";
			VARIABLE_ALIASES["customPercentRate6"] = "CUSTOM_PERCENTAGE6";
			VARIABLE_ALIASES["customPercentRate7"] = "CUSTOM_PERCENTAGE7";
			VARIABLE_ALIASES["customPercentRate8"] = "CUSTOM_PERCENTAGE8";
			VARIABLE_ALIASES["customPercentRate9"] = "CUSTOM_PERCENTAGE9";
			VARIABLE_ALIASES["customPercentRate10"] = "CUSTOM_PERCENTAGE10";
			VARIABLE_ALIASES["customPercentRate11"] = "CUSTOM_PERCENTAGE11";
			VARIABLE_ALIASES["customPercentRate12"] = "CUSTOM_PERCENTAGE12";
			VARIABLE_ALIASES["customPercentRate13"] = "CUSTOM_PERCENTAGE13";
			VARIABLE_ALIASES["customPercentRate14"] = "CUSTOM_PERCENTAGE14";
			VARIABLE_ALIASES["customPercentRate15"] = "CUSTOM_PERCENTAGE15";
			VARIABLE_ALIASES["customPercentRate16"] = "CUSTOM_PERCENTAGE16";
			VARIABLE_ALIASES["customPercentRate17"] = "CUSTOM_PERCENTAGE17";
			VARIABLE_ALIASES["customPercentRate18"] = "CUSTOM_PERCENTAGE18";
			VARIABLE_ALIASES["customPercentRate19"] = "CUSTOM_PERCENTAGE19";
			VARIABLE_ALIASES["customPercentRate20"] = "CUSTOM_PERCENTAGE20";
			VARIABLE_ALIASES["assemblyRate"] = "LINE_ITEM_TOTAL_RATE";
			VARIABLE_ALIASES["assemblyTotalCost"] = "LINE_ITEM_TOTAL_COST";
			VARIABLE_ALIASES["laborRate"] = "LABOR_TOTAL_RATE";
			VARIABLE_ALIASES["subcontractorRate"] = "SUBCONTRACTOR_TOTAL_RATE";
			VARIABLE_ALIASES["materialRate"] = "MATERIAL_TOTAL_RATE";
			VARIABLE_ALIASES["equipmentRate"] = "EQUIPMENT_TOTAL_RATE";
			VARIABLE_ALIASES["consumableRate"] = "CONSUMABLE_TOTAL_RATE";
			VARIABLE_ALIASES["quotedSubcontractorRate"] = "SUBCONTRACTOR_QUOTED_RATE";
			VARIABLE_ALIASES["quotedMaterialRate"] = "MATERIAL_QUOTED_RATE";
			VARIABLE_ALIASES["laborManhours"] = "TOTAL_MANHOURS";
			VARIABLE_ALIASES["equipmentHours"] = "TOTAL_EQUIPMENT_HOURS";
			VARIABLE_ALIASES["unitManhours"] = "MANHOURS_PER_UNIT";
			VARIABLE_ALIASES["estimatorId"] = "ESTIMATOR";
			VARIABLE_ALIASES["paramItemId"] = "ASSEMBLY_ID";
			VARIABLE_ALIASES["paramItemCode"] = "ASSEMBLY_TITLE";
			foreach (string str in BoqItemTable.VIEWABLE_FIELDS)
			{
			  if (!VARIABLE_ALIASES.ContainsKey(str))
			  {
				string[] arrayOfString = str.Split("(?=[A-Z])", true);
				StringBuilder stringBuffer = new StringBuilder();
				for (sbyte b = 0; b < arrayOfString.Length; b++)
				{
				  stringBuffer.Append(arrayOfString[b].ToUpper());
				  if (b != arrayOfString.Length - 1)
				  {
					stringBuffer.Append("_");
				  }
				}
				VARIABLE_ALIASES[str] = stringBuffer.ToString();
			  }
			}
			return VariableAliasMap;
		  }
	  }

	  public static BoqItemEvaluationContext createEvaluationContext(BoqItemTable paramBoqItemTable)
	  {
		  return new BoqItemEvaluationContext(paramBoqItemTable, "");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static org.boris.expr.Expr evaluate(nomitech.common.db.project.BoqItemTable paramBoqItemTable, String paramString1, String paramString2) throws org.boris.expr.ExprException
	  public static Expr evaluate(BoqItemTable paramBoqItemTable, string paramString1, string paramString2)
	  {
		BoqItemEvaluationContext boqItemEvaluationContext = new BoqItemEvaluationContext(paramBoqItemTable, paramString1);
		return boqItemEvaluationContext.parseStatement(paramString2);
	  }

	  public static ExprWithDefinition[] definitionsForField(string paramString)
	  {
		List<object> arrayList = new List<object>();
		for (sbyte b = 0; b < BoqItemTable.VIEWABLE_FIELDS.Length; b++)
		{
		  string str1 = BoqItemTable.VIEWABLE_FIELDS[b];
		  string str2 = variableFromField(str1);
		  Type clazz = BoqItemTable.CLASSES[b];
		  if (!str1.Equals(paramString))
		  {
			string str = "text";
			if (clazz.Equals(typeof(decimal)) || clazz.Equals(typeof(Long)) || clazz.Equals(typeof(Integer)) || clazz.Equals(typeof(BigInteger)))
			{
			  str = "number";
			}
			else if (clazz.Equals(typeof(string)))
			{
			  str = "text";
			}
			else if (clazz.Equals(typeof(Boolean)))
			{
			  str = "boolean";
			}
			else if (clazz.Equals(typeof(DateTime)))
			{
			  str = "date";
			}
			ExprDefinition exprDefinition = new ExprDefinition(str2, str, "BOQ Table field with alias '" + str1 + "'");
			arrayList.Add(new ExprWithDefinition(exprDefinition));
		  }
		}
		return (ExprWithDefinition[])arrayList.ToArray(typeof(ExprWithDefinition));
	  }

	  public static string[] variablesForField(string paramString)
	  {
		List<object> arrayList = new List<object>();
		foreach (string str1 in BoqItemTable.VIEWABLE_FIELDS)
		{
		  string str2 = variableFromField(str1);
		  if (!str1.Equals(paramString))
		  {
			arrayList.Add(str2);
		  }
		}
		return (string[])arrayList.ToArray(typeof(string));
	  }

	  public static string variableFromField(string paramString)
	  {
		if (VariableAliasMap.ContainsKey(paramString))
		{
		  return (string)VariableAliasMap[paramString];
		}
		string[] arrayOfString = paramString.Split("(?=[A-Z])", true);
		StringBuilder stringBuffer = new StringBuilder();
		for (sbyte b = 0; b < arrayOfString.Length; b++)
		{
		  stringBuffer.Append(arrayOfString[b].ToUpper());
		  if (b != arrayOfString.Length - 1)
		  {
			stringBuffer.Append("_");
		  }
		}
		FIELD_ALIASES = null;
		VariableAliasMap[paramString] = stringBuffer.ToString();
		return stringBuffer.ToString();
	  }

	  public static string fieldFromVariable(string paramString)
	  {
		  return FieldAliasMap.ContainsKey(paramString) ? (string)FieldAliasMap[paramString] : null;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static org.boris.expr.Expr evaluate(BoqItemEvaluationContext paramBoqItemEvaluationContext, String paramString) throws org.boris.expr.ExprException
	  public static Expr evaluate(BoqItemEvaluationContext paramBoqItemEvaluationContext, string paramString)
	  {
		  return paramBoqItemEvaluationContext.parseStatement(paramString);
	  }

	  public static bool? evaluateBoolean(BoqItemEvaluationContext paramBoqItemEvaluationContext, string paramString)
	  {
		try
		{
		  Expr expr = paramBoqItemEvaluationContext.parseStatement(paramString);
		  if (expr is ExprBoolean)
		  {
			return Convert.ToBoolean(((ExprBoolean)expr).booleanValue());
		  }
		}
		catch (ExprException exprException)
		{
		  Console.WriteLine("Error when evaluating formula: " + paramString);
		  Console.WriteLine(exprException.ToString());
		  Console.Write(exprException.StackTrace);
		  return false;
		}
		return false;
	  }

	  public static decimal evaluateDecimal(BoqItemEvaluationContext paramBoqItemEvaluationContext, string paramString)
	  {
		try
		{
		  Expr expr = paramBoqItemEvaluationContext.parseStatement(paramString);
		  if (expr is ExprDouble)
		  {
			return new BigDecimalFixed("" + ((ExprDouble)expr).doubleValue());
		  }
		}
		catch (ExprException exprException)
		{
		  Console.WriteLine("Error when evaluating formula: " + paramString);
		  Console.WriteLine(exprException.ToString());
		  Console.Write(exprException.StackTrace);
		  return BigDecimalMath.ZERO;
		}
		return BigDecimalMath.ZERO;
	  }

	  public static string evaluateText(BoqItemEvaluationContext paramBoqItemEvaluationContext, string paramString)
	  {
		try
		{
		  Expr expr = paramBoqItemEvaluationContext.parseStatement(paramString);
		  if (expr is ExprString)
		  {
			return ((ExprString)expr).ToString();
		  }
		}
		catch (ExprException exprException)
		{
		  Console.WriteLine(exprException.ToString());
		  Console.Write(exprException.StackTrace);
		  return "";
		}
		return "";
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\boqitem\BoqItemFormulaEvaluator.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}