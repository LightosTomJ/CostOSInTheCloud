namespace Desktop.common.nomitech.common.@base
{
	public interface ProjectGroupCodesProvider : GroupCodesProvider
	{

	  BaseCache Wbs1Cache {get;}

	  BaseCache Wbs2Cache {get;}

	  BaseCache ParamItemCache {get;}

	  BaseCache LocationCache {get;}

	  string Wbs1Separator {get;}

	  string Wbs2Separator {get;}

	  string LocationSeparator {get;}

	  string ParamItemSeparator {get;}

	  void initializeProjectCaches();

	  string getProjectProperty(string paramString);
	}

	public static class ProjectGroupCodesProvider_Fields
	{
	  public const short WBS1_TYPE = -1;
	  public const short WBS2_TYPE = -2;
	  public const short LOCATION_TYPE = -3;
	  public const short PARAMITEM_TYPE = -4;
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\base\ProjectGroupCodesProvider.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}