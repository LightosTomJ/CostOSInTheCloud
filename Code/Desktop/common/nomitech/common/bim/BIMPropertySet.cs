using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim
{

	public class BIMPropertySet
	{
	  private string name;

	  private IList<BIMProperty> properties;

	  public BIMPropertySet()
	  {
		  this.properties = new List<object>();
	  }

	  public BIMPropertySet(string paramString, IList<BIMProperty> paramList)
	  {
		this.name = paramString;
		this.properties = paramList;
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


	  public virtual IList<BIMProperty> Properties
	  {
		  get
		  {
			  return this.properties;
		  }
		  set
		  {
			  this.properties = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMPropertySet.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}