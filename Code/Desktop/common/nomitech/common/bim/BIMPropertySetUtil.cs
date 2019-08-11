using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim
{
	using BIMProperty = nomitech.ifcengine.props.BIMProperty;
	using BIMPropertySet = nomitech.ifcengine.props.BIMPropertySet;

	public class BIMPropertySetUtil
	{
	  public static BIMProperty findBIMPropertyInSets(IList<BIMPropertySet> paramList, string paramString)
	  {
		foreach (BIMPropertySet bIMPropertySet in paramList)
		{
		  foreach (BIMProperty bIMProperty in bIMPropertySet.Properties)
		  {
			if (bIMProperty.Name.Equals(paramString))
			{
			  return bIMProperty;
			}
		  }
		}
		return null;
	  }

	  public static int? findIntegerInBIMPropertyInSets(IList<BIMPropertySet> paramList, string paramString)
	  {
		BIMProperty bIMProperty = findBIMPropertyInSets(paramList, paramString);
		return (bIMProperty == null) ? Convert.ToInt32(0) : bIMProperty.IntegerValue;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMPropertySetUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}