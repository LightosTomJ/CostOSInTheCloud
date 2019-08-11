namespace Desktop.common.nomitech.ces.database
{
    using UserAndRolesData = Desktop.common.nomitech.common.auth.UserAndRolesData;
    using LogUserEvent = Desktop.common.nomitech.common.@event.LogUserEvent;

    public interface DatabaseEventPublisher : EJBLocalObject
    {
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: void publishUserAddedEvent(nomitech.common.auth.UserAndRolesData paramUserAndRolesData) throws javax.jms.JMSException;
        void publishUserAddedEvent(UserAndRolesData paramUserAndRolesData);

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: void publishUserChangedEvent(nomitech.common.auth.UserAndRolesData paramUserAndRolesData) throws javax.jms.JMSException;
        void publishUserChangedEvent(UserAndRolesData paramUserAndRolesData);

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: void publishUserDeletedEvent(nomitech.common.auth.UserAndRolesData paramUserAndRolesData) throws javax.jms.JMSException;
        void publishUserDeletedEvent(UserAndRolesData paramUserAndRolesData);

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: void publishPingEvent() throws javax.jms.JMSException;
        void publishPingEvent();

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: void publishPongEvent(String paramString1, String paramString2, String paramString3, String paramString4) throws javax.jms.JMSException;
        void publishPongEvent(string paramString1, string paramString2, string paramString3, string paramString4);

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: void publishUserKickEvent(String paramString) throws javax.jms.JMSException;
        void publishUserKickEvent(string paramString);

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: void publishLogEvent(nomitech.common.event.LogUserEvent paramLogUserEvent) throws javax.jms.JMSException;
        void publishLogEvent(LogUserEvent paramLogUserEvent);

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: void publishRefreshLicenses() throws javax.jms.JMSException;
        void publishRefreshLicenses();
    }


    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\ces\database\DatabaseEventPublisher.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}