using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.migration.location
{

	public class USPSToTerritory
	{
	  private IDictionary<string, string> s_uspsToTerritorry = new Hashtable();

	  public virtual string getTerritory(string paramString)
	  {
		  return (string)this.s_uspsToTerritorry[paramString];
	  }

	  public USPSToTerritory()
	  {
		this.s_uspsToTerritorry["AL"] = "Alabama";
		this.s_uspsToTerritorry["AK"] = "Alaska";
		this.s_uspsToTerritorry["AZ"] = "Arizona";
		this.s_uspsToTerritorry["AR"] = "Arkansas";
		this.s_uspsToTerritorry["CA"] = "California";
		this.s_uspsToTerritorry["CO"] = "Colorado";
		this.s_uspsToTerritorry["CT"] = "Connecticut";
		this.s_uspsToTerritorry["DE"] = "Delaware";
		this.s_uspsToTerritorry["DC"] = "District of Columbia";
		this.s_uspsToTerritorry["FL"] = "Florida";
		this.s_uspsToTerritorry["GA"] = "Georgia";
		this.s_uspsToTerritorry["HI"] = "Hawaii";
		this.s_uspsToTerritorry["ID"] = "Idaho";
		this.s_uspsToTerritorry["IL"] = "Illinois";
		this.s_uspsToTerritorry["IN"] = "Indiana";
		this.s_uspsToTerritorry["IA"] = "Iowa";
		this.s_uspsToTerritorry["KS"] = "Kansas";
		this.s_uspsToTerritorry["KY"] = "Kentucky";
		this.s_uspsToTerritorry["LA"] = "Louisiana";
		this.s_uspsToTerritorry["ME"] = "Maine";
		this.s_uspsToTerritorry["MD"] = "Maryland";
		this.s_uspsToTerritorry["MA"] = "Massachusetts";
		this.s_uspsToTerritorry["MI"] = "Michigan";
		this.s_uspsToTerritorry["MN"] = "Minnesota";
		this.s_uspsToTerritorry["MS"] = "Mississippi";
		this.s_uspsToTerritorry["MO"] = "Missouri";
		this.s_uspsToTerritorry["MT"] = "Montana";
		this.s_uspsToTerritorry["NE"] = "Nebraska";
		this.s_uspsToTerritorry["NV"] = "Nevada";
		this.s_uspsToTerritorry["NH"] = "New Hampshire";
		this.s_uspsToTerritorry["NJ"] = "New Jersey";
		this.s_uspsToTerritorry["NM"] = "New Mexico";
		this.s_uspsToTerritorry["NY"] = "New York";
		this.s_uspsToTerritorry["NC"] = "North Carolina";
		this.s_uspsToTerritorry["ND"] = "North Dakota";
		this.s_uspsToTerritorry["OH"] = "Ohio";
		this.s_uspsToTerritorry["OK"] = "Oklahoma";
		this.s_uspsToTerritorry["OR"] = "Oregon";
		this.s_uspsToTerritorry["PA"] = "Pennsylvania";
		this.s_uspsToTerritorry["RI"] = "Rhode Island";
		this.s_uspsToTerritorry["SC"] = "South Carolina";
		this.s_uspsToTerritorry["SD"] = "South Dakota";
		this.s_uspsToTerritorry["TN"] = "Tennessee";
		this.s_uspsToTerritorry["TX"] = "Texas";
		this.s_uspsToTerritorry["UT"] = "Utah";
		this.s_uspsToTerritorry["VT"] = "Vermont";
		this.s_uspsToTerritorry["VA"] = "Virginia";
		this.s_uspsToTerritorry["WA"] = "Washington";
		this.s_uspsToTerritorry["WV"] = "West Virginia";
		this.s_uspsToTerritorry["WI"] = "Wisconsin";
		this.s_uspsToTerritorry["WY"] = "Wyoming";
		this.s_uspsToTerritorry["AS"] = "American Samoa";
		this.s_uspsToTerritorry["GU"] = "Guam";
		this.s_uspsToTerritorry["MP"] = "Northern Mariana Islands";
		this.s_uspsToTerritorry["PR"] = "Puerto Rico";
		this.s_uspsToTerritorry["VI"] = "Virgin Islands U.S. Minor Outlying Islands";
		this.s_uspsToTerritorry["FM"] = "Federated States of Micronesia";
		this.s_uspsToTerritorry["MH"] = "Marshall Islands";
		this.s_uspsToTerritorry["PW"] = "Palau";
		this.s_uspsToTerritorry["AA"] = "Armed Forces Americas";
		this.s_uspsToTerritorry["AE"] = "Armed Forces - Europe - Canada - Middle East - Africa";
		this.s_uspsToTerritorry["AP"] = "Armed Forces Pacific";
		this.s_uspsToTerritorry["CZ"] = "Canal Zone";
		this.s_uspsToTerritorry["PI"] = "Philippine Islands";
		this.s_uspsToTerritorry["TT"] = "Trust Territory of the Pacific Islands";
		this.s_uspsToTerritorry["CM"] = "Commonwealth of the Northern Mariana Islands";
		this.s_uspsToTerritorry["AB"] = "Alberta";
		this.s_uspsToTerritorry["BC"] = "British Columbia";
		this.s_uspsToTerritorry["MB"] = "Manitoba";
		this.s_uspsToTerritorry["NB"] = "New Brunswick";
		this.s_uspsToTerritorry["NF"] = "New Foundland and Labrador";
		this.s_uspsToTerritorry["NS"] = "Nova Scotia";
		this.s_uspsToTerritorry["NT"] = "Northwest Territories";
		this.s_uspsToTerritorry["ON"] = "Ontario";
		this.s_uspsToTerritorry["PE"] = "Prince Edward Island";
		this.s_uspsToTerritorry["PQ"] = "Quebec";
		this.s_uspsToTerritorry["SK"] = "Saskatchewan";
		this.s_uspsToTerritorry["YT"] = "Yukon";
	  }

	  public virtual bool isUSPSCanada(string paramString)
	  {
		  return (paramString.Equals("AB") || paramString.Equals("BC") || paramString.Equals("MB") || paramString.Equals("NB") || paramString.Equals("NF") || paramString.Equals("NS") || paramString.Equals("NT") || paramString.Equals("ON") || paramString.Equals("PE") || paramString.Equals("PQ") || paramString.Equals("SK") || paramString.Equals("YT"));
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\location\USPSToTerritory.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}