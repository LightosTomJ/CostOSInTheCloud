using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.migration.location
{
	using StringUtils = nomitech.common.util.StringUtils;

	public class LocationDataRetriever
	{
	  private static LocationDataRetriever s_instance;

	  private IDictionary<string, LocationData> o_stateDataMap = new Hashtable();

	  private USPSToTerritory o_uspsMap = new USPSToTerritory();

	  private const int MAX_POLY_POINTS = 50;

	  public virtual LocationData retrieveForNorthAmericaData(string paramString1, string paramString2, string paramString3, string paramString4)
	  {
		string str = paramString1 + paramString2 + paramString3 + paramString4;
		LocationData locationData = (LocationData)this.o_stateDataMap[str];
		if (locationData == null)
		{
		  try
		  {
			locationData = findNorthAmericaLocation(paramString1, paramString2, paramString3, paramString4);
			this.o_stateDataMap[str] = locationData;
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		}
		return locationData;
	  }

	  public virtual LocationData retrieveForWorldData(string paramString1, string paramString2, string paramString3, string paramString4, string paramString5)
	  {
		string str = paramString1 + paramString2 + paramString3 + paramString4;
		LocationData locationData = (LocationData)this.o_stateDataMap[str];
		if (locationData == null)
		{
		  try
		  {
			locationData = findWorldLocation(paramString1, paramString2, paramString3, paramString4, paramString5);
			this.o_stateDataMap[str] = locationData;
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		}
		return locationData;
	  }

	  private LocationData findWorldLocation(string paramString1, string paramString2, string paramString3, string paramString4, string paramString5)
	  {
		string str = "";
		if (!StringUtils.isNullOrBlank(paramString3))
		{
		  str = paramString3 + ", ";
		}
		if (!StringUtils.isNullOrBlank(paramString2))
		{
		  str = str + paramString2 + ", ";
		}
		if (!StringUtils.isNullOrBlank(paramString5))
		{
		  str = str + paramString5;
		}
		return findLocationDataByQuery(str, paramString2, paramString3, paramString1, paramString4);
	  }

	  private LocationData findNorthAmericaLocation(string paramString1, string paramString2, string paramString3, string paramString4)
	  {
		if (this.o_uspsMap.isUSPSCanada(paramString2))
		{
		  paramString4 = "CA";
		}
		paramString2 = this.o_uspsMap.getTerritory(paramString2);
		string str = correctQuery(paramString3 + ", " + paramString2);
		return findLocationDataByQuery(str, paramString2, paramString3, paramString1, paramString4);
	  }

	  public virtual LocationData findLocationDataByQuery(string paramString1, string paramString2, string paramString3, string paramString4, string paramString5)
	  {
		LocationSearchResult locationSearchResult = LocationSearchAPI.search(paramString1, true);
		LocationPlace locationPlace1 = null;
		LocationPlace locationPlace2 = null;
		string str1 = paramString2.ToLower();
		string str2 = paramString3.ToLower();
		if (str1.Equals("Hawaii", StringComparison.OrdinalIgnoreCase))
		{
		  str1 = "hawai";
		}
		else if (str1.Equals("quebec", StringComparison.OrdinalIgnoreCase))
		{
		  str1 = "bec";
		}
		foreach (LocationPlace locationPlace in locationSearchResult.PlaceList)
		{
		  if (string.ReferenceEquals(locationPlace.Country_code, null))
		  {
			locationPlace.Country_code = "us";
		  }
		  if (!locationPlace.Country_code.Equals(paramString5, StringComparison.OrdinalIgnoreCase))
		  {
			continue;
		  }
		  string str3 = locationPlace.RegionString;
		  if (string.ReferenceEquals(str3, null))
		  {
			continue;
		  }
		  str3 = str3.ToLower();
		  if (str3.IndexOf(str1, StringComparison.Ordinal) != -1)
		  {
			locationPlace2 = locationPlace;
		  }
		  else
		  {
			Console.WriteLine("STATE " + str1 + " NOT IN REGION " + str3);
			continue;
		  }
		  string str4 = locationPlace.CityString;
		  if (string.ReferenceEquals(str4, null))
		  {
			continue;
		  }
		  str4 = str4.ToLower();
		  if (str4.IndexOf(str2, StringComparison.Ordinal) != -1)
		  {
			locationPlace1 = locationPlace;
			break;
		  }
		}
		LocationData locationData = new LocationData();
		locationData.ZipCode = paramString4;
		if (locationPlace1 == null)
		{
		  locationPlace1 = locationPlace2;
		}
		if (locationPlace1 == null)
		{
		  locationData.City = paramString3.ToUpper();
		  locationData.State = paramString2.ToUpper();
		  locationData.Country = paramString5;
		  locationData.GeoPolygon = "";
		  Console.WriteLine("Could not find: " + paramString1);
		}
		else
		{
		  string str3 = locationPlace1.Suburb;
		  string str4 = locationPlace1.City;
		  string str5 = locationPlace1.State;
		  if (string.ReferenceEquals(str4, null))
		  {
			str4 = paramString3;
		  }
		  if (!string.ReferenceEquals(str3, null))
		  {
			str4 = str3;
		  }
		  if (string.ReferenceEquals(str5, null))
		  {
			str5 = paramString3;
		  }
		  locationData.City = str4.ToUpper();
		  locationData.State = paramString2.ToUpper();
		  locationData.Country = locationPlace1.Country_code.ToUpper();
		  locationData.GeoPolygon = locationPlace1.Boundingbox;
		}
		if (!paramString2.Equals(locationData.State, StringComparison.OrdinalIgnoreCase))
		{
		  Console.WriteLine("Warning for state query: " + paramString1 + " = " + locationData.City + ", " + locationData.State + ", " + locationData.Country);
		}
		if (!paramString3.Equals(locationData.City, StringComparison.OrdinalIgnoreCase))
		{
		  Console.WriteLine("Warning for city query: " + paramString1 + " = " + locationData.City + ", " + locationData.State + ", " + locationData.Country);
		}
		locationData.City = paramString3.ToUpper();
		locationData.State = paramString2.ToUpper();
		locationData.Country = paramString5;
		return locationData;
	  }

	  private string compressPolygon(LocationPlace paramLocationPlace)
	  {
		System.Collections.IList list = paramLocationPlace.PolygonPoints;
		if (list.Count > 50)
		{
		  paramLocationPlace.PolygonPoints = DouglasPeuckerReduction.reduce(list, 50.0D);
		}
		return paramLocationPlace.PolygonPointString;
	  }

	  public virtual string correctQuery(string paramString)
	  {
		if (paramString.Equals("CHARLESTON, New Hampshire"))
		{
		  paramString = "CHARLESTOWN, New Hampshire";
		}
		else if (paramString.Equals("WHITE RIVER JCT., Vermont"))
		{
		  paramString = "WHITE RIVER JUNCTION, Vermont";
		}
		else if (paramString.Equals("Titusville (KSC), Florida"))
		{
		  paramString = "Titusville, Florida";
		}
		else if (paramString.Equals("NEW YORK, New York"))
		{
		  paramString = "NEW YORK CITY, New York";
		}
		else if (paramString.Equals("WESTCHESTER, Pennsylvania"))
		{
		  paramString = "WEST CHESTER, Pennsylvania";
		}
		else if (!paramString.Equals("MADISON, Wisconsin") && !paramString.Equals("NORTH SUBURBAN, Illinois"))
		{
		  if (paramString.Equals("WAXAHACKIE, Texas"))
		  {
			paramString = "Waxahachie, Texas";
		  }
		  else if (paramString.Equals("YELLOWSTONE NAT'L PA, Wyoming"))
		  {
			paramString = "Yellowstone National Park, Wyoming";
		  }
		  else if (paramString.Equals("MESA/TEMPE, Arizona"))
		  {
			paramString = "MESA, Arizona";
		  }
		  else if (paramString.Equals("TRUTH/CONSEQUENCES, New Mexico"))
		  {
			paramString = "TRUTH OR CONSEQUENCES, NEW MEXICO";
		  }
		  else if (paramString.Equals("SANTA CRUZ, California"))
		  {
			paramString = "SANTA CRUZ COUNTY, California";
		  }
		  else if (paramString.Equals("STATES & POSS., GUAM, Hawaii"))
		  {
			paramString = "GUAM, United States of America";
		  }
		  else if (paramString.Equals("QUEBEC, Quebec"))
		  {
			paramString = "Quebec City";
		  }
		  else if (paramString.Equals("SUDBURY, Ontario"))
		  {
			paramString = "SUDBURY Airport, Ontario";
		  }
		}
		return paramString;
	  }

	  public virtual void clearCache()
	  {
		  this.o_stateDataMap.Clear();
	  }

	  public static LocationDataRetriever Instance
	  {
		  get
		  {
			if (s_instance == null)
			{
			  s_instance = new LocationDataRetriever();
			}
			return s_instance;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\location\LocationDataRetriever.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}