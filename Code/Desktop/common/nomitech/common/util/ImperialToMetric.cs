using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.util
{
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;

	public class ImperialToMetric
	{
	  private static ImperialToMetric s_instance = null;

	  private IDictionary<string, string> o_imperialToMetric = new Hashtable();

	  private IDictionary<string, decimal> o_imperialToMetricConverterMap = new Hashtable();

	  private IDictionary<string, string> o_imperialSearchToMetricSearchMap = new Hashtable();

	  private ImperialToMetric()
	  {
		this.o_imperialSearchToMetricSearchMap["unit:LCM"] = "(unit:IN OR unit:LI)";
		this.o_imperialSearchToMetricSearchMap["unit:LM"] = "unit:LF";
		this.o_imperialSearchToMetricSearchMap["unit:HLM"] = "unit:HLF";
		this.o_imperialSearchToMetricSearchMap["unit:M2"] = "(unit:SF OR unit:SY)";
		this.o_imperialSearchToMetricSearchMap["unit:TN"] = "unit:TON";
		this.o_imperialSearchToMetricSearchMap["unit:CM3"] = "unit:CI";
		this.o_imperialSearchToMetricSearchMap["unit:M3"] = "(unit:CF OR unit:CY)";
		this.o_imperialSearchToMetricSearchMap["unit:LT"] = "unit:GAL";
		this.o_imperialSearchToMetricSearchMap["unit:KG"] = "unit:LB";
		this.o_imperialSearchToMetricSearchMap["unit:CM2"] = "unit:SI";
		this.o_imperialToMetric["IN"] = "LCM";
		this.o_imperialToMetric["LI"] = "LCM";
		this.o_imperialToMetric["LF"] = "LM";
		this.o_imperialToMetric["SF"] = "M2";
		this.o_imperialToMetric["SY"] = "M2";
		this.o_imperialToMetric["TON"] = "TN";
		this.o_imperialToMetric["CI"] = "CM3";
		this.o_imperialToMetric["CF"] = "M3";
		this.o_imperialToMetric["CY"] = "M3";
		this.o_imperialToMetric["GAL"] = "LT";
		this.o_imperialToMetric["LB"] = "KG";
		this.o_imperialToMetric["SI"] = "CM2";
		this.o_imperialToMetric["HLF"] = "HLM";
		this.o_imperialToMetricConverterMap["IN"] = new BigDecimalFixed("0.3937008");
		this.o_imperialToMetricConverterMap["LI"] = new BigDecimalFixed("0.3937008");
		this.o_imperialToMetricConverterMap["LF"] = new BigDecimalFixed("3.280839");
		this.o_imperialToMetricConverterMap["HLF"] = new BigDecimalFixed("3.280839");
		this.o_imperialToMetricConverterMap["SF"] = new BigDecimalFixed("10.763910");
		this.o_imperialToMetricConverterMap["SY"] = new BigDecimalFixed("1.19599005");
		this.o_imperialToMetricConverterMap["TON"] = new BigDecimalFixed("0.9842065");
		this.o_imperialToMetricConverterMap["CI"] = new BigDecimalFixed("0.000001");
		this.o_imperialToMetricConverterMap["CF"] = new BigDecimalFixed("35.3146667");
		this.o_imperialToMetricConverterMap["CY"] = new BigDecimalFixed("1.30795062");
		this.o_imperialToMetricConverterMap["GAL"] = new BigDecimalFixed("0.264172052");
		this.o_imperialToMetricConverterMap["LB"] = new BigDecimalFixed("2.20462262");
		this.o_imperialToMetricConverterMap["SI"] = new BigDecimalFixed("0.15500031");
	  }

	  private string _getUnit(string paramString)
	  {
		string str = (string)this.o_imperialToMetric[paramString];
		return (string.ReferenceEquals(str, null)) ? paramString : str;
	  }

	  private decimal _getRate(string paramString, decimal paramBigDecimal)
	  {
		decimal bigDecimal = (decimal)this.o_imperialToMetricConverterMap[paramString];
		return (bigDecimal == null) ? paramBigDecimal : paramBigDecimal * bigDecimal;
	  }

	  private string _getSearchKeyword(string paramString)
	  {
		if (paramString.IndexOf("unit:", StringComparison.Ordinal) == -1)
		{
		  return paramString;
		}
		foreach (string str in this.o_imperialSearchToMetricSearchMap.Keys)
		{
		  if (paramString.IndexOf(str, StringComparison.Ordinal) != -1)
		  {
			paramString = StringUtils.replaceAll(paramString, str, (string)this.o_imperialSearchToMetricSearchMap[str]);
		  }
		}
		return paramString;
	  }

	  private decimal _getInverseRate(string paramString, decimal paramBigDecimal)
	  {
		decimal bigDecimal1 = paramBigDecimal;
		decimal bigDecimal2 = (decimal)this.o_imperialToMetricConverterMap[paramString];
		if (bigDecimal2 != null)
		{
		  bigDecimal2 = BigDecimalMath.div(BigDecimalMath.ONE, bigDecimal2);
		  bigDecimal1 = BigDecimalMath.mult(bigDecimal2, paramBigDecimal);
		}
		return bigDecimal1;
	  }

	  private static ImperialToMetric Instance
	  {
		  get
		  {
			if (s_instance == null)
			{
			  s_instance = new ImperialToMetric();
			}
			return s_instance;
		  }
	  }

	  public static string getUnit(string paramString)
	  {
		  return Instance._getUnit(paramString);
	  }

	  public static string getSearchKeyword(string paramString)
	  {
		  return Instance._getSearchKeyword(paramString);
	  }

	  public static decimal getRate(string paramString, decimal paramBigDecimal)
	  {
		  return Instance._getRate(paramString, paramBigDecimal);
	  }

	  public static decimal getInverseRate(string paramString, decimal paramBigDecimal)
	  {
		  return Instance._getInverseRate(paramString, paramBigDecimal);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\ImperialToMetric.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}