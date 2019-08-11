namespace Desktop.common.nomitech.common.bim.ifcengine
{
	using BIMProperty = nomitech.ifcengine.props.BIMProperty;
	using BIMPropertySet = nomitech.ifcengine.props.BIMPropertySet;

	public class BIMExtensionPropertiesUtil
	{
	  public static BIMPropertySet createPropertySet(string paramString)
	  {
		BIMPropertySet bIMPropertySet = new BIMPropertySet();
		bIMPropertySet.Name = paramString;
		return bIMPropertySet;
	  }

	  public static BIMProperty createDoubleProperty(string paramString, int paramInt, double paramDouble)
	  {
		  return new BIMProperty(paramString, paramInt, true, "" + paramDouble, paramDouble);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\ifcengine\BIMExtensionPropertiesUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}