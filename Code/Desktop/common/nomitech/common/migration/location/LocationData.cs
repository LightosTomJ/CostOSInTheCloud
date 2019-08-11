namespace Desktop.common.nomitech.common.migration.location
{
	public class LocationData
	{
	  private string country;

	  private string state;

	  private string city;

	  private string zipCode;

	  private string geoPolygon;

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


	  public virtual string ZipCode
	  {
		  get
		  {
			  return this.zipCode;
		  }
		  set
		  {
			  this.zipCode = value;
		  }
	  }


	  public virtual string GeoPolygon
	  {
		  get
		  {
			  return this.geoPolygon;
		  }
		  set
		  {
			  this.geoPolygon = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\location\LocationData.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}