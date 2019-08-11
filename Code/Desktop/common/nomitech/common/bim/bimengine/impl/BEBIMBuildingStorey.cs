using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim.bimengine.impl
{
	using StringUtils = nomitech.bimengine.util.StringUtils;

	public class BEBIMBuildingStorey : BIMBuildingStorey
	{
	  public BEBIMBuildingStorey(object[] paramArrayOfObject, BEBIMBuilding paramBEBIMBuilding)
	  {
		Id = (long?)paramArrayOfObject[0];
		GlobalId = (string)paramArrayOfObject[1];
		string str = (string)paramArrayOfObject[3];
		if (StringUtils.isNullOrBlank(str))
		{
		  Name = "Building [Default]";
		}
		else
		{
		  Name = str;
		}
		BimToolId = "";
		TopElevation = 0.0D;
		TopElevationQT = 1;
		BottomElevation = 0.0D;
		BottomElevationQT = 1;
		LastUpdate = DateTime.Now;
		Height = 0.0D;
		HeightQT = 0;
		Building = paramBEBIMBuilding;
		Elements = new LinkedList();
	  }

	  public BEBIMBuildingStorey(string paramString, DateTime paramDate, BIMBuilding paramBIMBuilding)
	  {
		Id = Convert.ToInt64(DateTimeHelper.CurrentUnixTimeMillis() + 1L);
		Name = paramString;
		GlobalId = paramString;
		BimToolId = "";
		TopElevation = 0.0D;
		TopElevationQT = 1;
		BottomElevation = 0.0D;
		BottomElevationQT = 1;
		LastUpdate = paramDate;
		Height = 0.0D;
		HeightQT = 0;
		Building = paramBIMBuilding;
		Elements = new LinkedList();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\bimengine\impl\BEBIMBuildingStorey.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}