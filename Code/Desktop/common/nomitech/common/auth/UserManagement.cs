namespace Desktop.common.nomitech.common.auth
{

	public interface UserManagement : EJBLocalObject
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: boolean checkUserExists(String paramString) throws javax.ejb.EJBException;
	  bool checkUserExists(string paramString);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: UserAndRolesData getUserAndRoleData(String paramString) throws javax.ejb.EJBException;
	  UserAndRolesData getUserAndRoleData(string paramString);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.util.Collection getAllUserAndRoleData() throws javax.ejb.EJBException;
	  System.Collections.ICollection AllUserAndRoleData {get;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.util.Collection filterUserAndRoleDataByRole(String paramString) throws javax.ejb.EJBException;
	  System.Collections.ICollection filterUserAndRoleDataByRole(string paramString);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void addUserAndRoleData(UserAndRolesData paramUserAndRolesData) throws javax.ejb.EJBException, UserManagementException;
	  void addUserAndRoleData(UserAndRolesData paramUserAndRolesData);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void removeUserAndRoleData(UserAndRolesData paramUserAndRolesData) throws javax.ejb.EJBException, UserManagementException;
	  void removeUserAndRoleData(UserAndRolesData paramUserAndRolesData);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void updateUserAndRoleData(UserAndRolesData paramUserAndRolesData) throws javax.ejb.EJBException, UserManagementException;
	  void updateUserAndRoleData(UserAndRolesData paramUserAndRolesData);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: boolean checkInTheSameTeam(String paramString1, String paramString2) throws javax.ejb.EJBException;
	  bool checkInTheSameTeam(string paramString1, string paramString2);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.util.Collection findUserAndRoleDataByQuery(String paramString) throws javax.ejb.EJBException;
	  System.Collections.ICollection findUserAndRoleDataByQuery(string paramString);
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\auth\UserManagement.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}