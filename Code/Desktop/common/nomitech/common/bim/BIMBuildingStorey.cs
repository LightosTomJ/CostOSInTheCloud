using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim
{

	public class BIMBuildingStorey : BIMProduct
	{
	  private long? id;

	  private DateTime lastUpdate;

	  private string name;

	  private double height;

	  private int heightQT;

	  private BIMBuilding building;

	  private IDictionary<string, System.Collections.IList> groupedElements;

	  private bool @virtual = false;

	  private IList<BIMElement> elements;

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


	  public virtual double Height
	  {
		  get
		  {
			  return this.height;
		  }
		  set
		  {
			  this.height = value;
		  }
	  }


	  public virtual int HeightQT
	  {
		  get
		  {
			  return this.heightQT;
		  }
		  set
		  {
			  this.heightQT = value;
		  }
	  }


	  public virtual BIMBuilding Building
	  {
		  get
		  {
			  return this.building;
		  }
		  set
		  {
			  this.building = value;
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


	  public virtual IList<BIMElement> Elements
	  {
		  get
		  {
			  return this.elements;
		  }
		  set
		  {
			  this.elements = value;
		  }
	  }


	  public virtual void constructGroupedElements()
	  {
		this.groupedElements = new SortedDictionary();
		foreach (BIMElement bIMElement in this.elements)
		{
		  System.Collections.IList list = (System.Collections.IList)this.groupedElements[bIMElement.GroupType];
		  if (list == null)
		  {
			list = new List<object>();
			this.groupedElements[bIMElement.GroupType] = list;
		  }
		  list.Add(bIMElement);
		}
	  }

	  public virtual IDictionary<string, System.Collections.IList> GroupedElements
	  {
		  get
		  {
			  return this.groupedElements;
		  }
	  }

	  public override string ToString()
	  {
		  return Name;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMBuildingStorey.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}