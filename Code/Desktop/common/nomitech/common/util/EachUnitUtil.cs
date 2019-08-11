using System.Collections.Generic;

namespace Desktop.common.nomitech.common.util
{

	public class EachUnitUtil
	{
	  private static EachUnitUtil s_instance = null;

	  private List<string> o_eachUnitVector = new List<object>();

	  private EachUnitUtil()
	  {
		this.o_eachUnitVector.Add("EA.");
		this.o_eachUnitVector.Add("SET");
		this.o_eachUnitVector.Add("PROJECT");
		this.o_eachUnitVector.Add("TOTAL");
		this.o_eachUnitVector.Add("PAIR");
		this.o_eachUnitVector.Add("MOVE");
		this.o_eachUnitVector.Add("HUNDRED");
		this.o_eachUnitVector.Add("COURT");
		this.o_eachUnitVector.Add("SIGNAL");
		this.o_eachUnitVector.Add("BAG");
		this.o_eachUnitVector.Add("RISER");
		this.o_eachUnitVector.Add("FLIGHT");
		this.o_eachUnitVector.Add("JOB");
		this.o_eachUnitVector.Add("THOUSAND");
		this.o_eachUnitVector.Add("DRUM");
		this.o_eachUnitVector.Add("SQUARE");
		this.o_eachUnitVector.Add("HPR");
		this.o_eachUnitVector.Add("LEAF");
		this.o_eachUnitVector.Add("FLOOR");
		this.o_eachUnitVector.Add("STATION");
		this.o_eachUnitVector.Add("SEAT");
		this.o_eachUnitVector.Add("POINT");
		this.o_eachUnitVector.Add("SYSTEM");
		this.o_eachUnitVector.Add("HOOD");
		this.o_eachUnitVector.Add("PERSON");
		this.o_eachUnitVector.Add("SHADE");
		this.o_eachUnitVector.Add("SECTION");
		this.o_eachUnitVector.Add("ROOM");
		this.o_eachUnitVector.Add("STUDENT");
		this.o_eachUnitVector.Add("FIXTURE");
		this.o_eachUnitVector.Add("PLANE");
		this.o_eachUnitVector.Add("STOP");
		this.o_eachUnitVector.Add("OUTLET");
		this.o_eachUnitVector.Add("SPEAKER");
		this.o_eachUnitVector.Add("NAME");
		this.o_eachUnitVector.Add("ROLLERS");
		this.o_eachUnitVector.Add("JACK");
		this.o_eachUnitVector.Add("STALL");
		this.o_eachUnitVector.Add("9 HOLES");
		this.o_eachUnitVector.Add("MVAR");
		this.o_eachUnitVector.Add("KAH");
		this.o_eachUnitVector.Add("MVA");
		this.o_eachUnitVector.Add("SLIP");
		this.o_eachUnitVector.Add("JOINT");
		this.o_eachUnitVector.Add("UNIT");
		this.o_eachUnitVector.Add("COIL");
		this.o_eachUnitVector.Add("CARTON");
		this.o_eachUnitVector.Add("RAW");
		this.o_eachUnitVector.Add("LS");
		this.o_eachUnitVector.Add("NUM");
		this.o_eachUnitVector.Add("PCS");
	  }

	  public static bool isUnitEach(string paramString)
	  {
		if (s_instance == null)
		{
		  s_instance = new EachUnitUtil();
		}
		return s_instance.o_eachUnitVector.Contains(paramString);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\EachUnitUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}