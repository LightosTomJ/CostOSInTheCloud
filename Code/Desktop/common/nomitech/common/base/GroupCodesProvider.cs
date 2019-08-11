namespace Desktop.common.nomitech.common.@base
{
	public interface GroupCodesProvider
	{

	  BaseCache EpsCache {get;}

	  BaseCache GroupCode1Cache {get;}

	  BaseCache GroupCode2Cache {get;}

	  BaseCache GroupCode3Cache {get;}

	  BaseCache GroupCode4Cache {get;}

	  BaseCache GroupCode5Cache {get;}

	  BaseCache GroupCode6Cache {get;}

	  BaseCache GroupCode7Cache {get;}

	  BaseCache GroupCode8Cache {get;}

	  BaseCache GroupCode9Cache {get;}

	  string EpsCodeStyle {get;}

	  string GroupCode1CodeStyle {get;}

	  string GroupCode2CodeStyle {get;}

	  string GroupCode3CodeStyle {get;}

	  string GroupCode4CodeStyle {get;}

	  string GroupCode5CodeStyle {get;}

	  string GroupCode6CodeStyle {get;}

	  string GroupCode7CodeStyle {get;}

	  string GroupCode8CodeStyle {get;}

	  string GroupCode9CodeStyle {get;}

	  string EpsCodeSeparator {get;}

	  string GroupCode1Separator {get;}

	  string GroupCode2Separator {get;}

	  string GroupCode3Separator {get;}

	  string GroupCode4Separator {get;}

	  string GroupCode5Separator {get;}

	  string GroupCode6Separator {get;}

	  string GroupCode7Separator {get;}

	  string GroupCode8Separator {get;}

	  string GroupCode9Separator {get;}

	  string getUnitAlias(string paramString);

	  string getGroupCodeStyle(short paramShort);

	  string getGroupCodeSeparator(short paramShort);

	  BaseCache getGroupCodeCache(short paramShort);
	}

	public static class GroupCodesProvider_Fields
	{
	  public const short CODE1_TYPE = 1;
	  public const short CODE2_TYPE = 2;
	  public const short CODE3_TYPE = 3;
	  public const short CODE4_TYPE = 4;
	  public const short CODE5_TYPE = 5;
	  public const short CODE6_TYPE = 6;
	  public const short CODE7_TYPE = 7;
	  public const short CODE8_TYPE = 8;
	  public const short CODE9_TYPE = 9;
	  public const short EPS_TYPE = 10;
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\base\GroupCodesProvider.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}