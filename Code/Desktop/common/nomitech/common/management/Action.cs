using System.Collections;

namespace Desktop.common.nomitech.common.management
{

	public abstract class Action
	{
	  public abstract Action Metadata {get;}

	  public abstract Hashtable executeDO(Hashtable paramHashMap);

	  public abstract Hashtable executeUNDO(Hashtable paramHashMap);
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\management\Action.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}