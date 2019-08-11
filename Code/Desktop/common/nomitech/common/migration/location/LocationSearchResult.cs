using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop.common.nomitech.common.migration.location
{

	[Serializable]
	public class LocationSearchResult
	{
	  private DateTime timestamp;

	  private string attribution;

	  private string query_string;

	  private bool polygon;

	  private string exclude_place_ids;

	  private string more_url;

	  private IList<LocationPlace> placeList;

	  public virtual IList<LocationPlace> PlaceList
	  {
		  get
		  {
			  return this.placeList;
		  }
		  set
		  {
			  this.placeList = value;
		  }
	  }


	  public virtual DateTime Timestamp
	  {
		  get
		  {
			  return this.timestamp;
		  }
		  set
		  {
			  this.timestamp = value;
		  }
	  }


	  public virtual string Attribution
	  {
		  get
		  {
			  return this.attribution;
		  }
		  set
		  {
			  this.attribution = value;
		  }
	  }


	  public virtual string Query_string
	  {
		  get
		  {
			  return this.query_string;
		  }
		  set
		  {
			  this.query_string = value;
		  }
	  }


	  public virtual bool Polygon
	  {
		  get
		  {
			  return this.polygon;
		  }
		  set
		  {
			  this.polygon = value;
		  }
	  }


	  public virtual string Exclude_place_ids
	  {
		  get
		  {
			  return this.exclude_place_ids;
		  }
		  set
		  {
			  this.exclude_place_ids = value;
		  }
	  }


	  public virtual string More_url
	  {
		  get
		  {
			  return this.more_url;
		  }
		  set
		  {
			  this.more_url = value;
		  }
	  }


	  public override string ToString()
	  {
		StringBuilder stringBuffer = new StringBuilder();
		stringBuffer.Append("attribution: " + this.attribution + ", ");
		stringBuffer.Append("query_string: " + this.query_string + ", ");
		stringBuffer.Append("polygon: " + this.polygon + ", ");
		stringBuffer.Append("exclude_place_ids: " + this.exclude_place_ids + ", ");
		stringBuffer.Append("more_url: " + this.more_url + "\n");
		foreach (LocationPlace locationPlace in this.placeList)
		{
		  stringBuffer.Append("--PLACE: " + locationPlace.Place_id + "--");
		  stringBuffer.Append(locationPlace.ToString());
		}
		return stringBuffer.ToString();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\location\LocationSearchResult.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}