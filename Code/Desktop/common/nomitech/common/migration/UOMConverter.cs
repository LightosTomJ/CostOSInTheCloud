using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.migration
{
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;

	public class UOMConverter
	{
	  public static bool CONVERT_TO_METRIC = false;

	  private static UOMConverter s_instance;

	  private IDictionary<string, string> o_imperialToMetricMap = new Hashtable();

	  private IDictionary<string, string> o_imperialToCostOSImperialMap = new Hashtable();

	  private IDictionary<string, decimal> o_imperialToMetricConverterMap = new Hashtable();

	  private UOMConverter()
	  {
		this.o_imperialToMetricMap["IN"] = "LCM";
		this.o_imperialToMetricMap["LF"] = "LM";
		this.o_imperialToMetricMap["SF"] = "M2";
		this.o_imperialToMetricMap["TON"] = "TN";
		this.o_imperialToMetricMap["CI"] = "CM3";
		this.o_imperialToMetricMap["CF"] = "M3";
		this.o_imperialToMetricMap["CY"] = "M3";
		this.o_imperialToMetricMap["DAY"] = "DAY";
		this.o_imperialToMetricMap["HOUR"] = "HOUR";
		this.o_imperialToMetricMap["WEEK"] = "WEEK";
		this.o_imperialToMetricMap["MONTH"] = "MONTH";
		this.o_imperialToMetricMap["DF"] = "LM";
		this.o_imperialToMetricMap["FT"] = "LM";
		this.o_imperialToMetricMap["CHR"] = "PERCHARACTER";
		this.o_imperialToMetricMap["GAL"] = "LT";
		this.o_imperialToMetricMap["HR"] = "HOUR";
		this.o_imperialToMetricMap["LB"] = "KG";
		this.o_imperialToMetricMap["LI"] = "LCM";
		this.o_imperialToMetricMap["MO"] = "MONTH";
		this.o_imperialToMetricMap["BAG"] = "BAG";
		this.o_imperialToMetricMap["EA"] = "EACH";
		this.o_imperialToMetricMap["PR"] = "PERREVOLUTION";
		this.o_imperialToMetricMap["SET"] = "SET";
		this.o_imperialToMetricMap["SI"] = "CM2";
		this.o_imperialToMetricMap["SMPL"] = "SAMPLE";
		this.o_imperialToMetricMap["SY"] = "M2";
		this.o_imperialToMetricMap["VF"] = "LM";
		this.o_imperialToMetricMap["WK"] = "WEEK";
		this.o_imperialToMetricMap["LD"] = "LOAD";
		this.o_imperialToCostOSImperialMap["IN"] = "IN";
		this.o_imperialToCostOSImperialMap["LF"] = "LF";
		this.o_imperialToCostOSImperialMap["SF"] = "SF";
		this.o_imperialToCostOSImperialMap["TON"] = "TON";
		this.o_imperialToCostOSImperialMap["CI"] = "CI";
		this.o_imperialToCostOSImperialMap["CF"] = "CF";
		this.o_imperialToCostOSImperialMap["CY"] = "CY";
		this.o_imperialToCostOSImperialMap["DAY"] = "DAY";
		this.o_imperialToCostOSImperialMap["HOUR"] = "HOUR";
		this.o_imperialToCostOSImperialMap["WEEK"] = "WEEK";
		this.o_imperialToCostOSImperialMap["MONTH"] = "MONTH";
		this.o_imperialToCostOSImperialMap["DF"] = "LF";
		this.o_imperialToCostOSImperialMap["FT"] = "LF";
		this.o_imperialToCostOSImperialMap["CHR"] = "PERCHARACTER";
		this.o_imperialToCostOSImperialMap["GAL"] = "GAL";
		this.o_imperialToCostOSImperialMap["HR"] = "HOUR";
		this.o_imperialToCostOSImperialMap["LB"] = "LB";
		this.o_imperialToCostOSImperialMap["LI"] = "LI";
		this.o_imperialToCostOSImperialMap["MO"] = "MONTH";
		this.o_imperialToCostOSImperialMap["BAG"] = "BAG";
		this.o_imperialToCostOSImperialMap["EA"] = "EACH";
		this.o_imperialToCostOSImperialMap["PR"] = "PERREVOLUTION";
		this.o_imperialToCostOSImperialMap["SET"] = "SET";
		this.o_imperialToCostOSImperialMap["SI"] = "SI";
		this.o_imperialToCostOSImperialMap["SMPL"] = "SAMPLE";
		this.o_imperialToCostOSImperialMap["SY"] = "SY";
		this.o_imperialToCostOSImperialMap["VF"] = "FT";
		this.o_imperialToCostOSImperialMap["WK"] = "WEEK";
		this.o_imperialToCostOSImperialMap["LD"] = "LOAD";
		this.o_imperialToMetricConverterMap["IN"] = new BigDecimalFixed("0.3937008");
		this.o_imperialToMetricConverterMap["LF"] = new BigDecimalFixed("3.280839");
		this.o_imperialToMetricConverterMap["SF"] = new BigDecimalFixed("10.763910");
		this.o_imperialToMetricConverterMap["TON"] = new BigDecimalFixed("0.9842065");
		this.o_imperialToMetricConverterMap["CI"] = new BigDecimalFixed("0.061023744");
		this.o_imperialToMetricConverterMap["CF"] = new BigDecimalFixed("35.31466671");
		this.o_imperialToMetricConverterMap["CY"] = new BigDecimalFixed("1.307950619");
		this.o_imperialToMetricConverterMap["DAY"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["HOUR"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["WEEK"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["MONTH"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["DF"] = new BigDecimalFixed("3.280839895");
		this.o_imperialToMetricConverterMap["FT"] = new BigDecimalFixed("3.280839895");
		this.o_imperialToMetricConverterMap["CHR"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["GAL"] = new BigDecimalFixed("0.264172052");
		this.o_imperialToMetricConverterMap["HR"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["LB"] = new BigDecimalFixed("2.204622622");
		this.o_imperialToMetricConverterMap["LI"] = new BigDecimalFixed("0.393700787");
		this.o_imperialToMetricConverterMap["MO"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["BAG"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["EA"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["PR"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["SET"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["SI"] = new BigDecimalFixed("0.15500031");
		this.o_imperialToMetricConverterMap["SMPL"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["SY"] = new BigDecimalFixed("1.195990046");
		this.o_imperialToMetricConverterMap["VF"] = new BigDecimalFixed("3.280839895");
		this.o_imperialToMetricConverterMap["WK"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["LD"] = new BigDecimalFixed("1");
	  }

	  private string imperialToCostOSImperialUnit(string paramString)
	  {
		while (paramString.IndexOf(" ", StringComparison.Ordinal) != -1)
		{
		  paramString = paramString.Replace(" ", "").ToUpper();
		}
		return (string)this.o_imperialToCostOSImperialMap[paramString];
	  }

	  private string imperialToMetricUnit(string paramString)
	  {
		while (paramString.IndexOf(" ", StringComparison.Ordinal) != -1)
		{
		  paramString = paramString.Replace(" ", "").ToUpper();
		}
		return (string)this.o_imperialToMetricMap[paramString];
	  }

	  private decimal imperialToMetricRate(string paramString, decimal paramBigDecimal)
	  {
		while (paramString.IndexOf(" ", StringComparison.Ordinal) != -1)
		{
		  paramString = paramString.Replace(" ", "").ToUpper();
		}
		return ((decimal)this.o_imperialToMetricConverterMap[paramString]) * paramBigDecimal.setScale(6, RoundingMode.HALF_UP);
	  }

	  private static UOMConverter Instance
	  {
		  get
		  {
			if (s_instance == null)
			{
			  s_instance = new UOMConverter();
			}
			return s_instance;
		  }
	  }

	  public static string convertImperialToMetricUnit(string paramString)
	  {
		  return CONVERT_TO_METRIC ? Instance.imperialToMetricUnit(paramString) : Instance.imperialToCostOSImperialUnit(paramString);
	  }

	  public static string convertImperialToCostOSImperialUnit(string paramString)
	  {
		  return Instance.imperialToCostOSImperialUnit(paramString);
	  }

	  public static decimal convertImperialToMetricRate(string paramString, decimal paramBigDecimal)
	  {
		  return CONVERT_TO_METRIC ? Instance.imperialToMetricRate(paramString, paramBigDecimal) : paramBigDecimal;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\UOMConverter.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}