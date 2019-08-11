using System.Collections.Generic;

namespace Desktop.common.nomitech.common.ifc
{
	using BIMPropertySet = nomitech.ifcengine.props.BIMPropertySet;

	public class IfcEnginePropertiesData
	{
	  private IList<BIMPropertySet> propSetList;

	  private bool external;

	  private string material;

	  private string type;

	  private string systemZone;

	  private string layer;

	  private string entityName;

	  private string typeEntityClassName;

	  public virtual string EntityClassName
	  {
		  get
		  {
			  return this.entityName;
		  }
		  set
		  {
			  this.entityName = value;
		  }
	  }


	  public virtual string TypeEntityClassName
	  {
		  get
		  {
			  return this.typeEntityClassName;
		  }
		  set
		  {
			  this.typeEntityClassName = value;
		  }
	  }


	  public virtual IList<BIMPropertySet> PropSetList
	  {
		  get
		  {
			  return this.propSetList;
		  }
		  set
		  {
			  this.propSetList = value;
		  }
	  }


	  public virtual bool External
	  {
		  get
		  {
			  return this.external;
		  }
		  set
		  {
			  this.external = value;
		  }
	  }


	  public virtual string Material
	  {
		  get
		  {
			  return this.material;
		  }
		  set
		  {
			  this.material = value;
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


	  public virtual string SystemZone
	  {
		  get
		  {
			  return this.systemZone;
		  }
		  set
		  {
			  this.systemZone = value;
		  }
	  }


	  public virtual string Layer
	  {
		  get
		  {
			  return this.layer;
		  }
		  set
		  {
			  this.layer = value;
		  }
	  }


	  public virtual BIMPropertySet findProperySet(string paramString)
	  {
		foreach (BIMPropertySet bIMPropertySet in this.propSetList)
		{
		  if (bIMPropertySet.Name.Equals(paramString))
		  {
			return bIMPropertySet;
		  }
		}
		return null;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\ifc\IfcEnginePropertiesData.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}