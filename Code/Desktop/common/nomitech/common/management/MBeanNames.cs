namespace Desktop.common.nomitech.common.management
{
	using StringUtils = Desktop.common.nomitech.common.util.StringUtils;

	public sealed class MBeanNames
	{
	  public const string CES_QUERY = "jboss.CES:*";

	  public const string CES_DOMAIN = "jboss.ces";

	  public const string NAME_PROPERTY_KEY = "name";

	  public const string CONTEXT_PROPERTY_KEY = "context";

	  public const string DEFAULT_ORB_MANAGER_QUERY = "*:*,type=ORBManager";

	  public const string CES_TEMPLATE = "jboss.CES:name=XXX";

	  public const string PLACE_HOLDER = "XXX";

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static javax.management.ObjectName mapCESToJmxName(String paramString) throws javax.management.MalformedObjectNameException
	  public static ObjectName mapCESToJmxName(string paramString)
	  {
		  return new ObjectName(StringUtils.replace("jboss.CES:name=XXX", "XXX", paramString));
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\management\MBeanNames.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}