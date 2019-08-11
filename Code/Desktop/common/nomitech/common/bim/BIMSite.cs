using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim
{

	public class BIMSite : BIMProduct
	{
	  private GeometryArray geometryArray;

	  private Transform3D transform3D;

	  private long? id;

	  private DateTime lastUpdate;

	  private string name;

	  private double height;

	  private int heightQT;

	  private double area;

	  private int areaQT;

	  private BIMBuilding building;

	  private IDictionary<string, System.Collections.IList> groupedElements;

	  private Color color;

	  private IList<BIMElement> elements;

	  public virtual double Area
	  {
		  get
		  {
			  return this.area;
		  }
		  set
		  {
			  this.area = value;
		  }
	  }


	  public virtual int AreaQT
	  {
		  get
		  {
			  return this.areaQT;
		  }
		  set
		  {
			  this.areaQT = value;
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
		  set
		  {
			  this.groupedElements = value;
		  }
	  }

	  public override string ToString()
	  {
		  return Name;
	  }

	  public virtual GeometryArray GeometryArray
	  {
		  get
		  {
			  return this.geometryArray;
		  }
		  set
		  {
			  this.geometryArray = value;
		  }
	  }


	  public virtual Transform3D Transform3D
	  {
		  get
		  {
			  return this.transform3D;
		  }
		  set
		  {
			  this.transform3D = value;
		  }
	  }



	  public virtual Color Color
	  {
		  get
		  {
			  return this.color;
		  }
		  set
		  {
			  this.color = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMSite.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}