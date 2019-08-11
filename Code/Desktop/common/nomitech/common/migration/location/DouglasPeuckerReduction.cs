using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.migration.location
{

	public class DouglasPeuckerReduction
	{
	  public static IList<LocationPolygonPoint> reduce(IList<LocationPolygonPoint> paramList, double paramDouble)
	  {
		  return douglasPeuckerReduction(paramList, Convert.ToDouble(paramDouble));
	  }

	  private static IList<LocationPolygonPoint> douglasPeuckerReduction(IList<LocationPolygonPoint> paramList, double? paramDouble)
	  {
		if (paramList == null || paramList.Count < 3)
		{
		  return paramList;
		}
		int? integer1;
		int? integer2 = (integer1 = Convert.ToInt32(0)).valueOf(paramList.Count - 1);
		List<object> arrayList1 = new List<object>();
		arrayList1.Add(integer1);
		arrayList1.Add(integer2);
		while (((LocationPolygonPoint)paramList[integer1.Value]).Equals(paramList[integer2.Value]))
		{
		  int? integer3;
		  int? integer4 = integer2 = (integer3 = integer2).valueOf(integer2.Value - 1);
		  integer3;
		}
		douglasPeuckerReduction(paramList, integer1, integer2, paramDouble, arrayList1);
		List<object> arrayList2 = new List<object>();
		int?[] arrayOfInteger = (int?[])arrayList1.ToArray(typeof(System.Nullable));
		Arrays.sort(arrayOfInteger);
		arrayList1.Clear();
		arrayList1.AddRange(Arrays.asList(arrayOfInteger));
		foreach (int? integer in arrayList1)
		{
		  arrayList2.Add(paramList[integer.Value]);
		}
		return arrayList2;
	  }

	  private static void douglasPeuckerReduction(IList<LocationPolygonPoint> paramList1, int? paramInteger1, int? paramInteger2, double? paramDouble, IList<int> paramList2)
	  {
		double? double = Convert.ToDouble(0.0D);
		int? integer1 = Convert.ToInt32(0);
		int? integer2 = paramInteger1;
		while (integer2.Value < paramInteger2.Value)
		{
		  double? double1 = perpendicularDistance((LocationPolygonPoint)paramList1[paramInteger1.Value], (LocationPolygonPoint)paramList1[paramInteger2.Value], (LocationPolygonPoint)paramList1[integer2.Value]);
		  if (double1.Value > double.Value)
		  {
			double = double1;
			integer1 = integer2;
		  }
		  int? integer3;
		  int? integer4 = integer2 = (integer3 = integer2).valueOf(integer2.Value + 1);
		  integer3;
		}
		if (double.Value > paramDouble.Value && integer1.Value != 0)
		{
		  paramList2.Add(integer1);
		  douglasPeuckerReduction(paramList1, paramInteger1, integer1, paramDouble, paramList2);
		  douglasPeuckerReduction(paramList1, integer1, paramInteger2, paramDouble, paramList2);
		}
	  }

	  private static double? perpendicularDistance(LocationPolygonPoint paramLocationPolygonPoint1, LocationPolygonPoint paramLocationPolygonPoint2, LocationPolygonPoint paramLocationPolygonPoint3)
	  {
		double? double1;
		double? double2;
		return (double2 = (double1 = Convert.ToDouble(Math.Abs(0.5D * (paramLocationPolygonPoint1.X * paramLocationPolygonPoint2.Y + paramLocationPolygonPoint2.X * paramLocationPolygonPoint3.Y + paramLocationPolygonPoint3.X * paramLocationPolygonPoint1.Y - paramLocationPolygonPoint2.X * paramLocationPolygonPoint1.Y - paramLocationPolygonPoint3.X * paramLocationPolygonPoint2.Y - paramLocationPolygonPoint1.X * paramLocationPolygonPoint3.Y)))).valueOf(Math.Sqrt(Math.Pow(paramLocationPolygonPoint1.X - paramLocationPolygonPoint2.X, 2.0D) + Math.Pow(paramLocationPolygonPoint1.Y - paramLocationPolygonPoint2.Y, 2.0D)))).valueOf(double1.Value / double2.Value * 2.0D);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\location\DouglasPeuckerReduction.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}