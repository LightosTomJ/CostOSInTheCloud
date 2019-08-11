namespace Desktop.common.nomitech.ces.database
{
    using BaseTable = Desktop.common.nomitech.common.@base.BaseTable;
    using JFreeChart = Desktop.common.org.jfree.chart.JFreeChart;

    public interface DatabaseManagement : EJBLocalObject
    {
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: String getProperty(String paramString) throws java.rmi.RemoteException;
        string getProperty(string paramString);

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: void setProperty(String paramString1, String paramString2) throws java.rmi.RemoteException;
        void setProperty(string paramString1, string paramString2);

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: java.util.Properties getAllProperties(String paramString) throws java.rmi.RemoteException;
        Properties getAllProperties(string paramString);

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: String getDatabaseName() throws java.rmi.RemoteException;
        string DatabaseName { get; set; }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: void setDatabaseName(String paramString) throws java.rmi.RemoteException;

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: String getDatabaseStateString() throws java.rmi.RemoteException;
        string DatabaseStateString { get; }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: String getDatabaseCreationDate() throws java.rmi.RemoteException;
        string DatabaseCreationDate { get; }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: String getDatabaseLastAccessDate() throws java.rmi.RemoteException;
        string DatabaseLastAccessDate { get; }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: void notifyDatabaseAccessed() throws java.rmi.RemoteException;
        void notifyDatabaseAccessed();

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: String getDatabaseEditors() throws java.rmi.RemoteException;
        string DatabaseEditors { get; }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: org.jfree.chart.JFreeChart createDatabaseSnapshotPie() throws java.rmi.RemoteException, DatabaseManagementException;
        JFreeChart createDatabaseSnapshotPie();

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: void exportToZDB(String paramString1, String paramString2) throws java.rmi.RemoteException;
        void exportToZDB(string paramString1, string paramString2);

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: void notifyDataUpdate(String paramString, nomitech.common.base.BaseTable paramBaseTable, java.io.Serializable paramSerializable) throws java.rmi.RemoteException, DatabaseManagementException;
        void notifyDataUpdate(string paramString, BaseTable paramBaseTable, Serializable paramSerializable);
    }


    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\ces\database\DatabaseManagement.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}