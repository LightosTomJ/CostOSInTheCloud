namespace Desktop.common.nomitech.common.auth
{

	public class RolesUtil
	{
	  public static bool isUserInRole(UserAndRolesData paramUserAndRolesData, string paramString)
	  {
		  return (DatabaseDBUtil.CurrentDBUtil != null && !DatabaseDBUtil.Enterprise) ? true : paramUserAndRolesData.isUserInRoleSSSS(paramString);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\auth\RolesUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}