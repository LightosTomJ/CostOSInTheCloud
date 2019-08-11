using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop.common.nomitech.common.migration.location
{
	using StringUtils = nomitech.common.util.StringUtils;
	using GeoPosition = org.jdesktop.swingx.mapviewer.GeoPosition;

	public class LocationPlace
	{
	  private string place_id;

	  private string osm_type;

	  private string osm_id;

	  private string boundingbox;

	  private string lat;

	  private string lon;

	  private string display_name;

	  private string place_class;

	  private string type;

	  private string icon;

	  private string station;

	  private string road;

	  private string suburb;

	  private string village;

	  private string city;

	  private string postcode;

	  private string country;

	  private string country_code;

	  private string county;

	  private string state;

	  private string hamlet;

	  private string town;

	  private string residential;

	  private string house;

	  private string place;

	  private string elevation = "-";

	  private IList<LocationPolygonPoint> polygonPoints = new List<object>();

	  private IList<GeoPosition> boundingBox = new List<object>();

	  public LocationPlace()
	  {
	  }

	  public LocationPlace(string paramString1, string paramString2, string paramString3)
	  {
		this.lat = paramString1;
		this.lon = paramString2;
		this.elevation = paramString3;
	  }

	  public virtual IList<LocationPolygonPoint> PolygonPoints
	  {
		  get
		  {
			  return this.polygonPoints;
		  }
		  set
		  {
			  this.polygonPoints = value;
		  }
	  }


	  public virtual IList<GeoPosition> BoundingBox
	  {
		  get
		  {
			  return this.boundingBox;
		  }
	  }

	  public virtual void calculatePolygonPoints(string paramString)
	  {
		if (string.ReferenceEquals(paramString, null) || !paramString.StartsWith("[[", StringComparison.Ordinal) || !paramString.EndsWith("]]", StringComparison.Ordinal))
		{
		  return;
		}
		this.polygonPoints.Clear();
		paramString = paramString.Substring(2, (paramString.Length - 2) - 2);
		paramString = StringUtils.replaceAll(paramString, "],[", ";");
		string[] arrayOfString = paramString.Split(";", true);
		foreach (string str in arrayOfString)
		{
		  str = str.Substring(1, (str.Length - 1) - 1);
		  string[] arrayOfString1 = StringUtils.replaceAll(str, "\"", "").Split(",", true);
		  LocationPolygonPoint locationPolygonPoint = new LocationPolygonPoint((Convert.ToDouble(arrayOfString1[0])), (Convert.ToDouble(arrayOfString1[1])));
		  this.polygonPoints.Add(locationPolygonPoint);
		}
	  }

	  public virtual string PolygonPointString
	  {
		  get
		  {
			StringBuilder stringBuffer = new StringBuilder();
			System.Collections.IEnumerator iterator = this.polygonPoints.GetEnumerator();
			while (iterator.MoveNext())
			{
			  LocationPolygonPoint locationPolygonPoint = (LocationPolygonPoint)iterator.Current;
			  stringBuffer = stringBuffer.Append(locationPolygonPoint.Lat + "," + locationPolygonPoint.Lon);
	//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			  if (iterator.hasNext())
			  {
				stringBuffer = stringBuffer.Append(",");
			  }
			}
			return stringBuffer.ToString();
		  }
	  }

	  private void calculateBoundingBox(string paramString)
	  {
		string[] arrayOfString = paramString.Split(",", true);
		string str1 = arrayOfString[0];
		string str2 = arrayOfString[1];
		string str3 = arrayOfString[2];
		string str4 = arrayOfString[3];
		GeoPosition geoPosition1 = new GeoPosition((Convert.ToDouble(str1)), (Convert.ToDouble(str3)));
		GeoPosition geoPosition2 = new GeoPosition((Convert.ToDouble(str2)), (Convert.ToDouble(str4)));
		this.boundingBox.Clear();
		this.boundingBox.Add(geoPosition1);
		this.boundingBox.Add(geoPosition2);
	  }

	  public virtual string Place
	  {
		  get
		  {
			  return this.place;
		  }
		  set
		  {
			  this.place = value;
		  }
	  }


	  public virtual string House
	  {
		  get
		  {
			  return this.house;
		  }
		  set
		  {
			  this.house = value;
		  }
	  }


	  public virtual string County
	  {
		  get
		  {
			  return this.county;
		  }
		  set
		  {
			  this.county = value;
		  }
	  }


	  public virtual string State
	  {
		  get
		  {
			  return this.state;
		  }
		  set
		  {
			  this.state = value;
		  }
	  }


	  public virtual string Hamlet
	  {
		  get
		  {
			  return this.hamlet;
		  }
		  set
		  {
			  this.hamlet = value;
		  }
	  }


	  public virtual string Town
	  {
		  get
		  {
			  return this.town;
		  }
		  set
		  {
			  this.town = value;
		  }
	  }


	  public virtual string Residential
	  {
		  get
		  {
			  return this.residential;
		  }
		  set
		  {
			  this.residential = value;
		  }
	  }


	  public virtual string Station
	  {
		  get
		  {
			  return this.station;
		  }
		  set
		  {
			  this.station = value;
		  }
	  }


	  public virtual string Road
	  {
		  get
		  {
			  return this.road;
		  }
		  set
		  {
			  this.road = value;
		  }
	  }


	  public virtual string Suburb
	  {
		  get
		  {
			  return this.suburb;
		  }
		  set
		  {
			  this.suburb = value;
		  }
	  }


	  public virtual string Village
	  {
		  get
		  {
			  return this.village;
		  }
		  set
		  {
			  this.village = value;
		  }
	  }


	  public virtual string City
	  {
		  get
		  {
			  return this.city;
		  }
		  set
		  {
			  this.city = value;
		  }
	  }


	  public virtual string Postcode
	  {
		  get
		  {
			  return this.postcode;
		  }
		  set
		  {
			  this.postcode = value;
		  }
	  }


	  public virtual string Country
	  {
		  get
		  {
			  return this.country;
		  }
		  set
		  {
			  this.country = value;
		  }
	  }


	  public virtual string Country_code
	  {
		  get
		  {
			  return this.country_code;
		  }
		  set
		  {
			  this.country_code = value;
		  }
	  }


	  public virtual string Place_id
	  {
		  get
		  {
			  return this.place_id;
		  }
		  set
		  {
			  this.place_id = value;
		  }
	  }


	  public virtual string Elevation
	  {
		  get
		  {
			  return this.elevation;
		  }
		  set
		  {
			  this.elevation = value;
		  }
	  }


	  public virtual string Osm_type
	  {
		  get
		  {
			  return this.osm_type;
		  }
		  set
		  {
			  this.osm_type = value;
		  }
	  }


	  public virtual string Osm_id
	  {
		  get
		  {
			  return this.osm_id;
		  }
		  set
		  {
			  this.osm_id = value;
		  }
	  }


	  public virtual string Boundingbox
	  {
		  get
		  {
			  return this.boundingbox;
		  }
		  set
		  {
			this.boundingbox = value;
			calculateBoundingBox(value);
		  }
	  }


	  public virtual string Lat
	  {
		  get
		  {
			  return this.lat;
		  }
		  set
		  {
			  this.lat = value;
		  }
	  }


	  public virtual string Lon
	  {
		  get
		  {
			  return this.lon;
		  }
		  set
		  {
			  this.lon = value;
		  }
	  }


	  public virtual string Display_name
	  {
		  get
		  {
			  return this.display_name;
		  }
		  set
		  {
			  this.display_name = value;
		  }
	  }


	  public virtual string Place_class
	  {
		  get
		  {
			  return this.place_class;
		  }
		  set
		  {
			  this.place_class = value;
		  }
	  }


	  public virtual string Type
	  {
		  get
		  {
			  return this.type;
		  }
		  set
		  {
			  this.type = value;
		  }
	  }


	  public virtual string Icon
	  {
		  get
		  {
			  return this.icon;
		  }
		  set
		  {
			  this.icon = value;
		  }
	  }


	  public virtual GeoPosition GeoPosition
	  {
		  get
		  {
			  return new GeoPosition((Convert.ToDouble(Lat)), (Convert.ToDouble(Lon)));
		  }
	  }

	  public override string ToString()
	  {
		StringBuilder stringBuffer = new StringBuilder();
		stringBuffer.Append("place_id: " + this.place_id + ", ");
		stringBuffer.Append("osm_type: " + this.osm_type + ", ");
		stringBuffer.Append("osm_id: " + this.osm_id + ", ");
		stringBuffer.Append("lat: " + this.lat + ", ");
		stringBuffer.Append("lon: " + this.lon + ", ");
		stringBuffer.Append("display_name: " + this.display_name + "\n");
		stringBuffer.Append("place_class: " + this.place_class + "\n");
		stringBuffer.Append("type: " + this.type + "\n");
		stringBuffer.Append("icon: " + this.icon + "\n");
		stringBuffer.Append("elevation: " + this.elevation + "\n");
		stringBuffer.Append("station: " + this.station + "\n");
		stringBuffer.Append("road: " + this.road + "\n");
		stringBuffer.Append("village: " + this.village + "\n");
		stringBuffer.Append("suburb: " + this.suburb + "\n");
		stringBuffer.Append("city: " + this.city + "\n");
		stringBuffer.Append("postcode: " + this.postcode + "\n");
		stringBuffer.Append("country: " + this.country + "\n");
		stringBuffer.Append("country_code: " + this.country_code + "\n");
		stringBuffer.Append("county: " + this.county + "\n");
		stringBuffer.Append("state: " + this.state + "\n");
		stringBuffer.Append("hamlet: " + this.hamlet + "\n");
		stringBuffer.Append("town: " + this.town + "\n");
		stringBuffer.Append("residential: " + this.residential + "\n");
		stringBuffer.Append("house: " + this.house + "\n");
		return stringBuffer.ToString();
	  }

	  public virtual string RegionString
	  {
		  get
		  {
			StringBuilder stringBuffer = new StringBuilder();
			if (!string.ReferenceEquals(this.station, null))
			{
			  stringBuffer.Append(this.station);
			}
			if (!string.ReferenceEquals(this.residential, null))
			{
			  if (stringBuffer.Length != 0)
			  {
				stringBuffer.Append(", ");
			  }
			  stringBuffer.Append(this.residential);
			}
			if (!string.ReferenceEquals(this.county, null))
			{
			  if (stringBuffer.Length != 0)
			  {
				stringBuffer.Append(", ");
			  }
			  stringBuffer.Append(this.county);
			}
			if (!string.ReferenceEquals(this.state, null))
			{
			  if (stringBuffer.Length != 0)
			  {
				stringBuffer.Append(", ");
			  }
			  stringBuffer.Append(this.state);
			}
			if (!string.ReferenceEquals(this.place, null))
			{
			  if (stringBuffer.Length != 0)
			  {
				stringBuffer.Append(", ");
			  }
			  stringBuffer.Append(this.place);
			}
			return (stringBuffer.Length == 0) ? null : stringBuffer.ToString();
		  }
	  }

	  public virtual string CityString
	  {
		  get
		  {
			StringBuilder stringBuffer = new StringBuilder();
			if (!string.ReferenceEquals(this.village, null))
			{
			  if (stringBuffer.Length != 0)
			  {
				stringBuffer.Append(", ");
			  }
			  stringBuffer.Append(this.village);
			}
			if (!string.ReferenceEquals(this.hamlet, null))
			{
			  if (stringBuffer.Length != 0)
			  {
				stringBuffer.Append(", ");
			  }
			  stringBuffer.Append(this.hamlet);
			}
			if (!string.ReferenceEquals(this.suburb, null))
			{
			  if (stringBuffer.Length != 0)
			  {
				stringBuffer.Append(", ");
			  }
			  stringBuffer.Append(this.suburb);
			}
			if (!string.ReferenceEquals(this.city, null))
			{
			  if (stringBuffer.Length != 0)
			  {
				stringBuffer.Append(", ");
			  }
			  stringBuffer.Append(this.city);
			}
			if (!string.ReferenceEquals(this.town, null))
			{
			  if (stringBuffer.Length != 0)
			  {
				stringBuffer.Append(", ");
			  }
			  stringBuffer.Append(this.town);
			}
			string str = stringBuffer.ToString();
			return (str.Length == 0) ? null : str;
		  }
	  }

	  public virtual string AddressString
	  {
		  get
		  {
			StringBuilder stringBuffer = new StringBuilder();
			if (!string.ReferenceEquals(this.house, null))
			{
			  stringBuffer.Append(this.house);
			}
			if (!string.ReferenceEquals(this.road, null))
			{
			  if (stringBuffer.Length != 0)
			  {
				stringBuffer.Append(", ");
			  }
			  stringBuffer.Append(this.road);
			}
			if (!string.ReferenceEquals(this.postcode, null))
			{
			  if (stringBuffer.Length != 0)
			  {
				stringBuffer.Append(", ");
			  }
			  stringBuffer.Append(this.postcode);
			}
			string str = stringBuffer.ToString();
			return (str.Length == 0) ? null : str;
		  }
	  }

	  public virtual string LocationString
	  {
		  get
		  {
			StringBuilder stringBuffer = new StringBuilder();
			if (!string.ReferenceEquals(this.house, null))
			{
			  stringBuffer.Append(this.house);
			}
			if (!string.ReferenceEquals(this.road, null))
			{
			  if (stringBuffer.Length != 0)
			  {
				stringBuffer.Append(", ");
			  }
			  stringBuffer.Append(this.road);
			}
			if (!string.ReferenceEquals(this.postcode, null))
			{
			  if (stringBuffer.Length != 0)
			  {
				stringBuffer.Append(", ");
			  }
			  stringBuffer.Append(this.postcode);
			}
			if (!string.ReferenceEquals(this.village, null))
			{
			  if (stringBuffer.Length != 0)
			  {
				stringBuffer.Append(", ");
			  }
			  stringBuffer.Append(this.village);
			}
			if (!string.ReferenceEquals(this.hamlet, null))
			{
			  if (stringBuffer.Length != 0)
			  {
				stringBuffer.Append(", ");
			  }
			  stringBuffer.Append(this.hamlet);
			}
			if (!string.ReferenceEquals(this.city, null))
			{
			  if (stringBuffer.Length != 0)
			  {
				stringBuffer.Append(", ");
			  }
			  stringBuffer.Append(this.city);
			}
			if (!string.ReferenceEquals(this.town, null))
			{
			  if (stringBuffer.Length != 0)
			  {
				stringBuffer.Append(", ");
			  }
			  stringBuffer.Append(this.town);
			}
			string str = stringBuffer.ToString();
			return (str.Length == 0) ? null : str;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\location\LocationPlace.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}