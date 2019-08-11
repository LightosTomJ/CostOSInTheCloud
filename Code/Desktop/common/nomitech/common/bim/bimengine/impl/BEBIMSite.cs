namespace Desktop.common.nomitech.common.bim.bimengine.impl
{

	public class BEBIMSite : BIMSite
	{
	  public BEBIMSite(object[] paramArrayOfObject)
	  {
		Id = (long?)paramArrayOfObject[0];
		GlobalId = (string)paramArrayOfObject[1];
		Name = (string)paramArrayOfObject[3];
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\bimengine\impl\BEBIMSite.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}