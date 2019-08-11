namespace Desktop.common.nomitech.common.auth
{

	public interface UserManagementHome : EJBLocalHome
	{

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: UserManagement create() throws javax.ejb.CreateException, java.rmi.RemoteException;
	  UserManagement create();
	}

	public static class UserManagementHome_Fields
	{
	  public const string COMP_NAME = "java:comp/env/ejb/UserManagement";
	  public const string JNDI_NAME = "nomitech/ces/auth/UserManagementHome";
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\auth\UserManagementHome.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}