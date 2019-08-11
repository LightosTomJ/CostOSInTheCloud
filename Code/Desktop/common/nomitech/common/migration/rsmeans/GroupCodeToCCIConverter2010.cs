using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.migration.rsmeans
{
	using StringUtils = nomitech.common.util.StringUtils;

	public class GroupCodeToCCIConverter2010
	{
	  private static GroupCodeToCCIConverter2010 s_instance = null;

	  private IDictionary<string, string> MfO4ToCCIMap = new Hashtable();

	  public static GroupCodeToCCIConverter2010 Instance
	  {
		  get
		  {
			if (s_instance == null)
			{
			  s_instance = new GroupCodeToCCIConverter2010();
			}
			return s_instance;
		  }
	  }

	  private GroupCodeToCCIConverter2010()
	  {
		  loadCCItoMF();
	  }

	  private void addToCCI(string paramString1, string paramString2)
	  {
		  this.MfO4ToCCIMap[paramString2] = paramString1;
	  }

	  private void loadCCItoMF()
	  {
		addToCCI("016", "015433");
		addToCCI("020", "0241");
		addToCCI("020", "31");
		addToCCI("020", "32");
		addToCCI("020", "33");
		addToCCI("020", "34");
		addToCCI("022", "3120");
		addToCCI("022", "3130");
		addToCCI("023", "3160");
		addToCCI("023", "3170");
		addToCCI("025", "3210");
		addToCCI("026", "3310");
		addToCCI("026", "3330");
		addToCCI("026", "3340");
		addToCCI("026", "3350");
		addToCCI("028", "3230");
		addToCCI("029", "3290");
		addToCCI("030", "03");
		addToCCI("031", "0310");
		addToCCI("032", "0320");
		addToCCI("033", "0330");
		addToCCI("034", "0340");
		addToCCI("040", "04");
		addToCCI("041", "0405");
		addToCCI("042", "0420");
		addToCCI("044", "0440");
		addToCCI("045", "0450");
		addToCCI("050", "05");
		addToCCI("051", "0510");
		addToCCI("052", "0520");
		addToCCI("052", "0530");
		addToCCI("055", "0550");
		addToCCI("060", "06");
		addToCCI("061", "0610");
		addToCCI("062", "0620");
		addToCCI("070", "07");
		addToCCI("071", "0710");
		addToCCI("072", "0720");
		addToCCI("072", "0780");
		addToCCI("075", "0740");
		addToCCI("075", "0750");
		addToCCI("076", "0760");
		addToCCI("080", "08");
		addToCCI("081", "0810");
		addToCCI("081", "0830");
		addToCCI("088", "0840");
		addToCCI("088", "0880");
		addToCCI("090", "09");
		addToCCI("092", "0920");
		addToCCI("093", "0930");
		addToCCI("093", "0966");
		addToCCI("095", "0950");
		addToCCI("095", "0980");
		addToCCI("096", "0960");
		addToCCI("099", "0970");
		addToCCI("099", "0990");
		addToCCI("100", "10");
		addToCCI("100", "11");
		addToCCI("100", "12");
		addToCCI("100", "13");
		addToCCI("100", "14");
		addToCCI("100", "25");
		addToCCI("100", "28");
		addToCCI("100", "41");
		addToCCI("100", "43");
		addToCCI("100", "44");
		addToCCI("150", "21");
		addToCCI("150", "22");
		addToCCI("150", "23");
		addToCCI("151", "2210");
		addToCCI("151", "2230");
		addToCCI("151", "2240");
		addToCCI("151", "2320");
		addToCCI("154", "2113");
		addToCCI("155", "2350");
		addToCCI("156", "2330");
		addToCCI("156", "2340");
		addToCCI("156", "2360");
		addToCCI("156", "2370");
		addToCCI("156", "2380");
		addToCCI("160", "26");
		addToCCI("160", "27");
		addToCCI("160", "3370");
	  }

	  public virtual string groupCodeToCCI(string paramString)
	  {
		if (StringUtils.isNullOrBlank(paramString) || paramString.Length < 6)
		{
		  return "998";
		}
		string str1 = paramString.Substring(0, 2);
		string str2 = paramString.Substring(0, 4);
		string str3 = paramString.Substring(0, 6);
		string str4 = (string)this.MfO4ToCCIMap[str3];
		if (string.ReferenceEquals(str4, null))
		{
		  str4 = (string)this.MfO4ToCCIMap[str2];
		}
		if (string.ReferenceEquals(str4, null))
		{
		  str4 = (string)this.MfO4ToCCIMap[str1];
		}
		if (string.ReferenceEquals(str4, null))
		{
		  str4 = "998";
		}
		return str4;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\rsmeans\GroupCodeToCCIConverter2010.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}