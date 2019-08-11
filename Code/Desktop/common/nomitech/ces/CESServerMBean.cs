using System.Collections.Generic;

namespace Desktop.common.nomitech.ces
{
    using ServiceMBean = Desktop.common.nomitech.common.management.ServiceMBean;

    public interface CESServerMBean : ServiceMBean
    {
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: String getDBProperty(String paramString) throws Exception;
        string getDBProperty(string paramString);

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: java.util.Properties getAllDBProperties(String paramString) throws Exception;
        Properties getAllDBProperties(string paramString);

        ISet<object> DBPropertiesKeys { get; }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: void storeDBProperties() throws Exception;
        void storeDBProperties();

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: void setDBProperty(String paramString1, String paramString2) throws Exception;
        void setDBProperty(string paramString1, string paramString2);

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: void updateDatabaseSchema() throws Exception;
        void updateDatabaseSchema();

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: void fixLineItems() throws Exception;
        void fixLineItems();

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: void createCMSAdmin(String paramString1, String paramString2, String paramString3) throws Exception;
        void createCMSAdmin(string paramString1, string paramString2, string paramString3);

        string Code { get; set; }


        string Name { get; set; }


        Properties Properties { get; set; }

    }

    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\ces\CESServerMBean.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}