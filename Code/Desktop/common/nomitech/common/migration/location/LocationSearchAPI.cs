using System.Collections.Generic;
using System.IO;

namespace Desktop.common.nomitech.common.migration.location
{
	using StringUtils = nomitech.common.util.StringUtils;
	using Document = org.dom4j.Document;
	using Element = org.dom4j.Element;
	using SAXReader = org.dom4j.io.SAXReader;
	using GeoPosition = org.jdesktop.swingx.mapviewer.GeoPosition;

	public class LocationSearchAPI
	{
	  private const string API_URL = "http://nominatim.openstreetmap.org/search?format=xml&q={A}&polygon={B}&addressdetails=1";

	  private const string REVERSE_API_URL = "http://nominatim.openstreetmap.org/reverse?format=xml&lat={A}&lon={B}&zoom={C}&addressdetails=1";

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static LocationSearchResult reverseSearch(org.jdesktop.swingx.mapviewer.GeoPosition paramGeoPosition, int paramInt1, int paramInt2) throws Exception
	  public static LocationSearchResult reverseSearch(GeoPosition paramGeoPosition, int paramInt1, int paramInt2)
	  {
		LocationSearchResult locationSearchResult = new LocationSearchResult();
		locationSearchResult.PlaceList = new List<object>();
		string str = StringUtils.replace("http://nominatim.openstreetmap.org/reverse?format=xml&lat={A}&lon={B}&zoom={C}&addressdetails=1", "{A}", "" + paramGeoPosition.Latitude);
		str = StringUtils.replace(str, "{B}", "" + paramGeoPosition.Longitude);
		double d = paramInt1 * 19.0D / paramInt2;
		paramInt1 = (int)(19.0D - d - 0.5D);
		if (paramInt1 == 0)
		{
		  paramInt1 = 1;
		}
		else if (paramInt1 >= 19)
		{
		  paramInt1 = 18;
		}
		str = StringUtils.replace(str, "{C}", "" + paramInt1);
		URL uRL = new URL(str);
		URLConnection uRLConnection = uRL.openConnection();
		uRLConnection.setRequestProperty("User-agent", "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.9) Gecko/20071025 Firefox/2.0.0.9");
		uRLConnection.ConnectTimeout = 4000;
		uRLConnection.ReadTimeout = 30000;
		Stream inputStream = uRLConnection.InputStream;
		SAXReader sAXReader = new SAXReader();
		Document document = sAXReader.read(inputStream);
		Element element = document.RootElement;
		locationSearchResult.Query_string = element.attributeValue("query_string");
		locationSearchResult.Polygon = (new bool?(element.attributeValue("polygon")));
		LocationPlace locationPlace = new LocationPlace();
		locationPlace.Lat = "" + paramGeoPosition.Latitude;
		locationPlace.Lon = "" + paramGeoPosition.Longitude;
		System.Collections.IEnumerator iterator = element.elementIterator();
		while (iterator.MoveNext())
		{
		  Element element1 = (Element)iterator.Current;
		  if (element1.Name.Equals("result"))
		  {
			locationPlace.Place_id = element1.attributeValue("place_id");
			locationPlace.Osm_type = element1.attributeValue("osm_type");
			locationPlace.Osm_id = element1.attributeValue("osm_type");
			locationPlace.Display_name = element1.StringValue;
			continue;
		  }
		  if (element1.Name.Equals("addressparts"))
		  {
			System.Collections.IEnumerator iterator1 = element1.elementIterator();
			while (iterator1.MoveNext())
			{
			  Element element2 = (Element)iterator1.Current;
			  if (element2.Name.Equals("station"))
			  {
				locationPlace.Station = element2.StringValue;
				continue;
			  }
			  if (element2.Name.Equals("road"))
			  {
				locationPlace.Road = element2.StringValue;
				continue;
			  }
			  if (element2.Name.Equals("suburb"))
			  {
				locationPlace.Suburb = element2.StringValue;
				continue;
			  }
			  if (element2.Name.Equals("village"))
			  {
				locationPlace.Village = element2.StringValue;
				continue;
			  }
			  if (element2.Name.Equals("city"))
			  {
				locationPlace.City = element2.StringValue;
				continue;
			  }
			  if (element2.Name.Equals("postcode"))
			  {
				locationPlace.Postcode = element2.StringValue;
				continue;
			  }
			  if (element2.Name.Equals("country"))
			  {
				locationPlace.Country = element2.StringValue;
				continue;
			  }
			  if (element2.Name.Equals("country_code"))
			  {
				locationPlace.Country_code = element2.StringValue;
				continue;
			  }
			  if (element2.Name.Equals("county"))
			  {
				locationPlace.County = element2.StringValue;
				continue;
			  }
			  if (element2.Name.Equals("state"))
			  {
				locationPlace.State = element2.StringValue;
				continue;
			  }
			  if (element2.Name.Equals("hamlet"))
			  {
				locationPlace.Hamlet = element2.StringValue;
				continue;
			  }
			  if (element2.Name.Equals("town"))
			  {
				locationPlace.Town = element2.StringValue;
				continue;
			  }
			  if (element2.Name.Equals("residential"))
			  {
				locationPlace.Residential = element2.StringValue;
				continue;
			  }
			  if (element2.Name.Equals("house"))
			  {
				locationPlace.House = element2.StringValue;
				continue;
			  }
			  if (element2.Name.Equals("place"))
			  {
				locationPlace.Place = element2.StringValue;
			  }
			}
		  }
		}
		locationSearchResult.PlaceList.Add(locationPlace);
		return locationSearchResult;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static LocationSearchResult search(String paramString) throws Exception
	  public static LocationSearchResult search(string paramString)
	  {
		  return search(paramString, false);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static LocationSearchResult search(String paramString, boolean paramBoolean) throws Exception
	  public static LocationSearchResult search(string paramString, bool paramBoolean)
	  {
		paramString = StringUtils.replaceAll(paramString, " ", "+");
		string str = StringUtils.replace("http://nominatim.openstreetmap.org/search?format=xml&q={A}&polygon={B}&addressdetails=1", "{A}", paramString);
		str = StringUtils.replace(str, "{B}", paramBoolean ? "1" : "0");
		URL uRL = new URL(str);
		URLConnection uRLConnection = uRL.openConnection();
		uRLConnection.setRequestProperty("User-agent", "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.9) Gecko/20071025 Firefox/2.0.0.9");
		uRLConnection.ConnectTimeout = 4000;
		uRLConnection.ReadTimeout = 30000;
		Stream inputStream = uRLConnection.InputStream;
		SAXReader sAXReader = new SAXReader();
		Document document = sAXReader.read(inputStream);
		LocationSearchResult locationSearchResult = new LocationSearchResult();
		Element element = document.RootElement;
		locationSearchResult.Query_string = element.attributeValue("query_string");
		locationSearchResult.Polygon = (new bool?(element.attributeValue("polygon")));
		locationSearchResult.Exclude_place_ids = element.attributeValue("exclude_place_ids");
		locationSearchResult.More_url = element.attributeValue("more_url");
		locationSearchResult.Attribution = element.attributeValue("attribution");
		locationSearchResult.PlaceList = new List<object>();
		System.Collections.IEnumerator iterator = element.elementIterator();
		while (iterator.MoveNext())
		{
		  Element element1 = (Element)iterator.Current;
		  LocationPlace locationPlace = new LocationPlace();
		  locationPlace.Place_id = element1.attributeValue("place_id");
		  locationPlace.Osm_type = element1.attributeValue("osm_type");
		  locationPlace.Osm_id = element1.attributeValue("osm_id");
		  locationPlace.Lat = element1.attributeValue("lat");
		  locationPlace.Lon = element1.attributeValue("lon");
		  locationPlace.Place_class = element1.attributeValue("class");
		  locationPlace.Type = element1.attributeValue("type");
		  locationPlace.Display_name = element1.attributeValue("display_name");
		  locationPlace.Icon = element1.attributeValue("icon");
		  locationPlace.Boundingbox = element1.attributeValue("boundingbox");
		  if (paramBoolean)
		  {
			locationPlace.calculatePolygonPoints(element1.attributeValue("polygonpoints"));
		  }
		  System.Collections.IEnumerator iterator1 = element1.elementIterator();
		  while (iterator1.MoveNext())
		  {
			Element element2 = (Element)iterator1.Current;
			if (element2.Name.Equals("station"))
			{
			  locationPlace.Station = element2.StringValue;
			  continue;
			}
			if (element2.Name.Equals("road"))
			{
			  locationPlace.Road = element2.StringValue;
			  continue;
			}
			if (element2.Name.Equals("suburb"))
			{
			  locationPlace.Suburb = element2.StringValue;
			  continue;
			}
			if (element2.Name.Equals("village"))
			{
			  locationPlace.Village = element2.StringValue;
			  continue;
			}
			if (element2.Name.Equals("city"))
			{
			  locationPlace.City = element2.StringValue;
			  continue;
			}
			if (element2.Name.Equals("postcode"))
			{
			  locationPlace.Postcode = element2.StringValue;
			  continue;
			}
			if (element2.Name.Equals("country"))
			{
			  locationPlace.Country = element2.StringValue;
			  continue;
			}
			if (element2.Name.Equals("country_code"))
			{
			  locationPlace.Country_code = element2.StringValue;
			  continue;
			}
			if (element2.Name.Equals("county"))
			{
			  locationPlace.County = element2.StringValue;
			  continue;
			}
			if (element2.Name.Equals("state"))
			{
			  locationPlace.State = element2.StringValue;
			  continue;
			}
			if (element2.Name.Equals("hamlet"))
			{
			  locationPlace.Hamlet = element2.StringValue;
			  continue;
			}
			if (element2.Name.Equals("town"))
			{
			  locationPlace.Town = element2.StringValue;
			  continue;
			}
			if (element2.Name.Equals("residential"))
			{
			  locationPlace.Residential = element2.StringValue;
			  continue;
			}
			if (element2.Name.Equals("house"))
			{
			  locationPlace.House = element2.StringValue;
			  continue;
			}
			if (element2.Name.Equals("place"))
			{
			  locationPlace.Place = element2.StringValue;
			}
		  }
		  locationSearchResult.PlaceList.Add(locationPlace);
		}
		return locationSearchResult;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\location\LocationSearchAPI.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}