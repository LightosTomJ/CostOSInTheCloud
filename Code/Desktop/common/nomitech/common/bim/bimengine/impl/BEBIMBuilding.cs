using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim.bimengine.impl
{
	using StringUtils = nomitech.bimengine.util.StringUtils;
	using BIMPropertySet = nomitech.ifcengine.props.BIMPropertySet;

	public class BEBIMBuilding : BIMBuilding
	{
	  public BEBIMBuilding(object[] paramArrayOfObject, IList<BIMPropertySet> paramList, BIMModel paramBIMModel)
	  {
		if (paramArrayOfObject != null)
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
		}
		else
		{
		  Id = Convert.ToInt64(DateTimeHelper.CurrentUnixTimeMillis());
		  GlobalId = Id.ToString();
		  Name = "Without a Building";
		  Virtual = true;
		}
		GrossArea = 0.0D;
		GrossAreaQT = 1;
		Volume = 0.0D;
		VolumeQT = 1;
		BimToolId = "";
		TopElevation = 0.0D;
		TopElevationQT = 1;
		BottomElevation = 0.0D;
		BottomElevationQT = 1;
		LastUpdate = DateTime.Now;
		Model = paramBIMModel;
		Storeys = new LinkedList();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\bimengine\impl\BEBIMBuilding.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}