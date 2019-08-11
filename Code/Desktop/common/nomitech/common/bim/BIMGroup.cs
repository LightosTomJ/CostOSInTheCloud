using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim
{

	public class BIMGroup : BIMProduct
	{
	  public const string SYSTEM_GROUP = "system";

	  public const string ZONE_GROUP = "zone";

	  private long? id;

	  private DateTime lastUpdate;

	  private BIMModel model;

	  private string name;

	  private string type;

	  private BIMGroup parentGroup;

	  private LinkedList<BIMGroup> children;

	  private IList<BIMBuildingElement> elements;

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


	  public virtual IList<BIMBuildingElement> Elements
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


	  public virtual BIMGroup Parent
	  {
		  get
		  {
			  return this.parentGroup;
		  }
		  set
		  {
			  this.parentGroup = value;
		  }
	  }


	  public virtual LinkedList<BIMGroup> Children
	  {
		  get
		  {
			  return this.children;
		  }
		  set
		  {
			  this.children = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMGroup.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}