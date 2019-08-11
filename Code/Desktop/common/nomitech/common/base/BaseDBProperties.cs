namespace Desktop.common.nomitech.common.@base
{
	using UserAndRolesData = nomitech.common.auth.UserAndRolesData;

	public interface BaseDBProperties
	{
	  string getProperty(string paramString);

	  object setProperty(string paramString1, string paramString2);

	  UserAndRolesData UserAndRolesData {get;set;}


	  string UserId {get;}

	  void createDBProperties();

	  void storeDBProperties();

	  void makeLocalUserAndRolesData();

	  void setIntProperty(string paramString, int paramInt);

	  int getIntProperty(string paramString);

	  void setLongProperty(string paramString, long paramLong);

	  long getLongProperty(string paramString);

	  void setEncProperty(string paramString1, string paramString2);

	  string getEncProperty(string paramString);

	  void setStringArrayProperty(string paramString, string[] paramArrayOfString);

	  string[] getStringArrayProperty(string paramString);

	  string ConnectionHost {get;}

	  void refreshUserId(string paramString, UserAndRolesData paramUserAndRolesData);

	  UserAndRolesData getUserAndRolesById(string paramString);

	  Color getUserColorById(string paramString);
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\base\BaseDBProperties.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}