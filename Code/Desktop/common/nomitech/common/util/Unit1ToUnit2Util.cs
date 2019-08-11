using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.util
{
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;

	public class Unit1ToUnit2Util
	{
	  private static Unit1ToUnit2Util s_instance = null;

	  private IDictionary<string, string> o_unit1ToUnit2 = new Hashtable();

	  private IDictionary<string, decimal> o_unit1ToUnit2ConverterMap = new Hashtable();

	  private Unit1ToUnit2Util()
	  {
		this.o_unit1ToUnit2["IN"] = "LCM";
		this.o_unit1ToUnit2["LI"] = "LCM";
		this.o_unit1ToUnit2["LCM"] = "IN";
		this.o_unit1ToUnit2["MM"] = "IN";
		this.o_unit1ToUnit2["LF"] = "LM";
		this.o_unit1ToUnit2["LM"] = "LF";
		this.o_unit1ToUnit2["SF"] = "M2";
		this.o_unit1ToUnit2["SY"] = "M2";
		this.o_unit1ToUnit2["M2"] = "SF";
		this.o_unit1ToUnit2["TON"] = "TN";
		this.o_unit1ToUnit2["TN"] = "TON";
		this.o_unit1ToUnit2["CI"] = "CM3";
		this.o_unit1ToUnit2["CM3"] = "CI";
		this.o_unit1ToUnit2["CF"] = "M3";
		this.o_unit1ToUnit2["CY"] = "M3";
		this.o_unit1ToUnit2["M3"] = "CY";
		this.o_unit1ToUnit2["GAL"] = "LT";
		this.o_unit1ToUnit2["LT"] = "GAL";
		this.o_unit1ToUnit2["LB"] = "KG";
		this.o_unit1ToUnit2["KG"] = "LB";
		this.o_unit1ToUnit2["SI"] = "CM2";
		this.o_unit1ToUnit2["CM2"] = "SI";
		this.o_unit1ToUnit2["KM"] = "MILE";
		this.o_unit1ToUnit2ConverterMap["KM"] = new BigDecimalFixed("1.609344");
		this.o_unit1ToUnit2ConverterMap["MILE"] = new BigDecimalFixed("0.621371192237334");
		this.o_unit1ToUnit2ConverterMap["IN"] = new BigDecimalFixed("0.3937008");
		this.o_unit1ToUnit2ConverterMap["LI"] = new BigDecimalFixed("0.3937008");
		this.o_unit1ToUnit2ConverterMap["LCM"] = new BigDecimalFixed("2.54");
		this.o_unit1ToUnit2ConverterMap["MM"] = new BigDecimalFixed("25.4");
		this.o_unit1ToUnit2ConverterMap["LF"] = new BigDecimalFixed("3.280839");
		this.o_unit1ToUnit2ConverterMap["LM"] = new BigDecimalFixed("0.3048");
		this.o_unit1ToUnit2ConverterMap["SF"] = new BigDecimalFixed("10.763910");
		this.o_unit1ToUnit2ConverterMap["SY"] = new BigDecimalFixed("1.19599005");
		this.o_unit1ToUnit2ConverterMap["M2"] = new BigDecimalFixed("0.09290304");
		this.o_unit1ToUnit2ConverterMap["TON"] = new BigDecimalFixed("0.9842065");
		this.o_unit1ToUnit2ConverterMap["TN"] = new BigDecimalFixed("1.016046937");
		this.o_unit1ToUnit2ConverterMap["CI"] = new BigDecimalFixed("0.000001");
		this.o_unit1ToUnit2ConverterMap["CM3"] = new BigDecimalFixed("1000000");
		this.o_unit1ToUnit2ConverterMap["CF"] = new BigDecimalFixed("35.3146667");
		this.o_unit1ToUnit2ConverterMap["M3"] = new BigDecimalFixed("0.764554858");
		this.o_unit1ToUnit2ConverterMap["CY"] = new BigDecimalFixed("1.30795062");
		this.o_unit1ToUnit2ConverterMap["GAL"] = new BigDecimalFixed("0.264172052");
		this.o_unit1ToUnit2ConverterMap["LT"] = new BigDecimalFixed("3.78541178");
		this.o_unit1ToUnit2ConverterMap["LB"] = new BigDecimalFixed("2.20462262");
		this.o_unit1ToUnit2ConverterMap["KG"] = new BigDecimalFixed("0.45359237");
		this.o_unit1ToUnit2ConverterMap["SI"] = new BigDecimalFixed("0.15500031");
		this.o_unit1ToUnit2ConverterMap["CM2"] = new BigDecimalFixed("6.4516");
	  }

	  public virtual string getUnit2(string paramString)
	  {
		string str = (string)this.o_unit1ToUnit2[paramString];
		return (string.ReferenceEquals(str, null)) ? paramString : str;
	  }

	  public virtual decimal getUnitDiv(string paramString)
	  {
		decimal bigDecimal = (decimal)this.o_unit1ToUnit2ConverterMap[paramString];
		return (bigDecimal == null) ? new BigDecimalFixed("1") : bigDecimal;
	  }

	  public static Unit1ToUnit2Util Instance
	  {
		  get
		  {
			if (s_instance == null)
			{
			  s_instance = new Unit1ToUnit2Util();
			}
			return s_instance;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\Unit1ToUnit2Util.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}