namespace Desktop.common.nomitech.common.bim.bimengine.impl
{

	public class BEBIMGroup : BIMGroup
	{
	  public BEBIMGroup(object[] paramArrayOfObject)
	  {
		Id = (long?)paramArrayOfObject[0];
		Name = (string)paramArrayOfObject[1];
		GlobalId = (string)paramArrayOfObject[2];
		string str = (string)paramArrayOfObject[3];
		if (str.Equals("System"))
		{
		  Type = "system";
		}
		else if (str.Equals("Zone"))
		{
		  Type = "zone";
		}
		else
		{
		  Type = str;
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\bimengine\impl\BEBIMGroup.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}