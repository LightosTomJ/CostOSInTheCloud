using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim
{

	public class BIMBuilding : BIMProduct
	{
	  private long? id;

	  private DateTime lastUpdate;

	  private double grossArea;

	  private int grossAreaQT;

	  private string name;

	  private double volume;

	  private int volumeQT;

	  private bool @virtual = false;

	  private BIMSite site;

	  private BIMModel model;

	  private IList<BIMBuildingStorey> storeys;

	  public virtual bool Virtual
	  {
		  get
		  {
			  return this.@virtual;
		  }
		  set
		  {
			  this.@virtual = value;
		  }
	  }


	  public virtual double GrossArea
	  {
		  get
		  {
			  return this.grossArea;
		  }
		  set
		  {
			  this.grossArea = value;
		  }
	  }


	  public virtual int GrossAreaQT
	  {
		  get
		  {
			  return this.grossAreaQT;
		  }
		  set
		  {
			  this.grossAreaQT = value;
		  }
	  }


	  public virtual string Name
	  {
		  get
		  {
			  return this.name;
		  }
		  set
		  {
			  this.name = value;
		  }
	  }


	  public virtual double Volume
	  {
		  get
		  {
			  return this.volume;
		  }
		  set
		  {
			  this.volume = value;
		  }
	  }


	  public virtual int VolumeQT
	  {
		  get
		  {
			  return this.volumeQT;
		  }
		  set
		  {
			  this.volumeQT = value;
		  }
	  }


	  public virtual IList<BIMBuildingStorey> Storeys
	  {
		  get
		  {
			  return this.storeys;
		  }
		  set
		  {
			  this.storeys = value;
		  }
	  }


	  public virtual BIMModel Model
	  {
		  get
		  {
			  return this.model;
		  }
		  set
		  {
			  this.model = value;
		  }
	  }


	  public virtual long? Id
	  {
		  get
		  {
			  return this.id;
		  }
		  set
		  {
			  this.id = value;
		  }
	  }


	  public virtual DateTime LastUpdate
	  {
		  get
		  {
			  return this.lastUpdate;
		  }
		  set
		  {
			  this.lastUpdate = value;
		  }
	  }


	  public virtual BIMSite Site
	  {
		  get
		  {
			  return this.site;
		  }
		  set
		  {
			  this.site = value;
		  }
	  }


	  public override string ToString()
	  {
		  return Name;
	  }

	  public virtual void sortStoreys()
	  {
		BIMBuildingStorey[] arrayOfBIMBuildingStorey = (BIMBuildingStorey[])Storeys.ToArray();
		Arrays.sort(arrayOfBIMBuildingStorey, new ComparatorAnonymousInnerClass(this));
		Storeys.Clear();
		foreach (BIMBuildingStorey bIMBuildingStorey in arrayOfBIMBuildingStorey)
		{
		  Storeys.Add(bIMBuildingStorey);
		}
	  }

	  private class ComparatorAnonymousInnerClass : IComparer<BIMBuildingStorey>
	  {
		  private readonly BIMBuilding outerInstance;

		  public ComparatorAnonymousInnerClass(BIMBuilding outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public int compare(BIMBuildingStorey param1BIMBuildingStorey1, BIMBuildingStorey param1BIMBuildingStorey2)
		  {
			  return param1BIMBuildingStorey1.Name.CompareTo(param1BIMBuildingStorey2.Name);
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMBuilding.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}