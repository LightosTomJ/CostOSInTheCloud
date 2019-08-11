namespace Desktop.common.nomitech.ces.database
{

    public interface DatabaseManagementHome : EJBLocalHome
    {

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: DatabaseManagement create() throws javax.ejb.CreateException, java.rmi.RemoteException;
        DatabaseManagement create();
    }

    public static class DatabaseManagementHome_Fields
    {
        public const string COMP_NAME = "java:comp/env/ejb/DatabaseManagement";
        public const string JNDI_NAME = "nomitech/ces/database/DatabaseManagementHome";
    }


    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\ces\database\DatabaseManagementHome.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}