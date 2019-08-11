namespace Desktop.common.nomitech.ces.database
{

    public interface DatabaseEventPublisherHome : EJBLocalHome
    {

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: DatabaseEventPublisher create() throws javax.ejb.CreateException;
        DatabaseEventPublisher create();
    }

    public static class DatabaseEventPublisherHome_Fields
    {
        public const string COMP_NAME = "java:comp/env/ejb/DatabaseEventPublisherHome";
        public const string JNDI_NAME = "nomitech/ces/database/DatabaseEventPublisherHome";
    }


    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\ces\database\DatabaseEventPublisherHome.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}