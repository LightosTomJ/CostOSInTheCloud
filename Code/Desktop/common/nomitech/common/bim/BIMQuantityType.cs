namespace Desktop.common.nomitech.common.bim
{
	public class BIMQuantityType
	{
	  public static int QTY_MILLI_METER = 1;

	  public static int QTY_SQUARE_METER = 2;

	  public static int QTY_CUBIC_METER = 3;

	  public static string getMetricQty(int paramInt)
	  {
		  return (paramInt == QTY_SQUARE_METER) ? "m2" : ((paramInt == QTY_MILLI_METER) ? "mm" : ((paramInt == QTY_CUBIC_METER) ? "m3" : ""));
	  }

	  public static string getCostosUom(string paramString)
	  {
		  return paramString.Equals("m2") ? "M2" : (paramString.Equals("mm") ? "MM" : (paramString.Equals("m") ? "LM" : (paramString.Equals("m3") ? "M3" : paramString)));
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMQuantityType.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}