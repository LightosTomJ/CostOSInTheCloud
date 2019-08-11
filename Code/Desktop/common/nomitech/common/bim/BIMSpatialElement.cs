using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim
{

	public abstract class BIMSpatialElement : BIMElement
	{
	  private IList<BIMSpatialElement> children = new List<object>();

	  private IList<BIMBuildingElement> buildingElements = new List<object>();

	  private string type;

	  private BIMSpatialElement parent;

	  public virtual BIMSpatialElement Parent
	  {
		  get
		  {
			  return this.parent;
		  }
		  set
		  {
			  this.parent = value;
		  }
	  }


	  public BIMSpatialElement()
	  {
		  Transparency = 0.6000000238418579D;
	  }

	  public virtual IList<BIMSpatialElement> Children
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


	  public virtual IList<BIMBuildingElement> BuildingElements
	  {
		  get
		  {
			  return this.buildingElements;
		  }
		  set
		  {
			  this.buildingElements = value;
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

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMSpatialElement.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}