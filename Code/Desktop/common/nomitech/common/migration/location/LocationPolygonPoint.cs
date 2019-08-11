using System;

namespace Desktop.common.nomitech.common.migration.location
{
	public class LocationPolygonPoint
	{
	  private double lon;

	  private double lat;

	  private double x;

	  private double y;

	  public LocationPolygonPoint(double paramDouble1, double paramDouble2)
	  {
		this.lon = paramDouble1;
		this.lat = paramDouble2;
		this.x = 6378137.0D * Math.Cos(Math.toRadians(paramDouble2)) * Math.Cos(Math.toRadians(paramDouble1));
		this.y = 6378137.0D * Math.Cos(Math.toRadians(paramDouble2)) * Math.Sin(Math.toRadians(paramDouble1));
	  }

	  public virtual double Lon
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


	  public virtual double Lat
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


	  public virtual double X
	  {
		  get
		  {
			  return this.x;
		  }
		  set
		  {
			  this.x = value;
		  }
	  }


	  public virtual double Y
	  {
		  get
		  {
			  return this.y;
		  }
		  set
		  {
			  this.y = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\location\LocationPolygonPoint.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}