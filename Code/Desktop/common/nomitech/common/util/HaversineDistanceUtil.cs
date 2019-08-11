using System;

namespace Desktop.common.nomitech.common.util
{
	public class HaversineDistanceUtil
	{
	  public const int MILE_DISTANCE = 1;

	  public const int KM_DISTANCE = 0;

	  public static double distance(int paramInt, double[] paramArrayOfDouble1, double[] paramArrayOfDouble2)
	  {
		double d1 = paramArrayOfDouble2[0];
		double d2 = paramArrayOfDouble1[0];
		double d3 = paramArrayOfDouble2[1];
		double d4 = paramArrayOfDouble1[1];
		double d5 = (paramInt == 1) ? 3960.0D : 6371.0D;
		double d6 = toRadian(d1 - d2);
		double d7 = toRadian(d3 - d4);
		double d8 = Math.Sin(d6 / 2.0D) * Math.Sin(d6 / 2.0D) + Math.Cos(toRadian(d2)) * Math.Cos(toRadian(d1)) * Math.Sin(d7 / 2.0D) * Math.Sin(d7 / 2.0D);
		double d9 = 2.0D * Math.Asin(Math.Min(1.0D, Math.Sqrt(d8)));
		return d5 * d9;
	  }

	  private static double toRadian(double paramDouble)
	  {
		  return 0.017453292519943295D * paramDouble;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\HaversineDistanceUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}