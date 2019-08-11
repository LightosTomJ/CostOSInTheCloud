using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.ces
{
    using XStream = Desktop.common.com.thoughtworks.xstream.XStream;
    using DummyProjectGroupCodesProviderFactory = Desktop.common.nomitech.ces.utils.DummyProjectGroupCodesProviderFactory;
    using DatabaseDBUtil = Desktop.common.nomitech.common.DatabaseDBUtil;
    using LocalDBUtil = Desktop.common.nomitech.common.LocalDBUtil;
    using ProjectDBProperties = Desktop.common.nomitech.common.ProjectDBProperties;
    using ProjectDBUtil = Desktop.common.nomitech.common.ProjectDBUtil;
    using ProjectSchemaUpdateUtil = Desktop.common.nomitech.common.ProjectSchemaUpdateUtil;
    using ProjectServerDBUtil = Desktop.common.nomitech.common.ProjectServerDBUtil;
    using ProjectSessionFactoryBuilder = Desktop.common.nomitech.common.ProjectSessionFactoryBuilder;
    using SchemaUpdateUtil = Desktop.common.nomitech.common.SchemaUpdateUtil;
    using SessionInterface = Desktop.common.nomitech.common.SessionInterface;
    using Principals = Desktop.common.nomitech.common.auth.Principals;
    using PrincipalsData = Desktop.common.nomitech.common.auth.PrincipalsData;
    using PrincipalsHome = Desktop.common.nomitech.common.auth.PrincipalsHome;
    using Roles = Desktop.common.nomitech.common.auth.Roles;
    using RolesData = Desktop.common.nomitech.common.auth.RolesData;
    using RolesHome = Desktop.common.nomitech.common.auth.RolesHome;
    using ProjectDbmsTable = Models.local.ProjectDbmsTable;
    using ProjectUrlTable = Models.local.ProjectUrlTable;
    using License = Desktop.common.nomitech.common.license.License;
    using LicenseManager = Desktop.common.nomitech.common.license.LicenseManager;
    using LicenseRowItem = Desktop.common.nomitech.common.license.LicenseRowItem;
    using LicenseFromGenerator = Desktop.common.nomitech.common.license.model.LicenseFromGenerator;
    using LicenseSerialNumberData = Desktop.common.nomitech.common.license.model.LicenseSerialNumberData;
    using LicenseSerialNumberDataV2 = Desktop.common.nomitech.common.license.model.LicenseSerialNumberDataV2;
    using LicenseV2 = Desktop.common.nomitech.common.license.model.LicenseV2;
    using ServiceMBeanSupport = Desktop.common.nomitech.common.management.ServiceMBeanSupport;
    using AddOnUtil = Desktop.common.nomitech.common.util.AddOnUtil;
    using CryptUtil = Desktop.common.nomitech.common.util.CryptUtil;
    using FileUtils = Desktop.common.nomitech.common.util.FileUtils;
    using NamingUtil = Desktop.common.nomitech.common.util.NamingUtil;
    using StringUtils = Desktop.common.nomitech.common.util.StringUtils;
    using HibernateException = Desktop.common.org.hibernate.HibernateException;
    using Session = Desktop.common.org.hibernate.Session;
    using SessionFactory = Desktop.common.org.hibernate.SessionFactory;
    using Configuration = Desktop.common.org.hibernate.cfg.Configuration;
    using Dialect = Desktop.common.org.hibernate.dialect.Dialect;
    using SessionFactoryImplementor = Desktop.common.org.hibernate.engine.SessionFactoryImplementor;
    using LongType = Desktop.common.org.hibernate.type.LongType;
    using StringType = Desktop.common.org.hibernate.type.StringType;

    public class CESServer : ServiceMBeanSupport, CESServerMBean
    {
        private const string ZDB_PROPERTIES_FILE = "zdb.properties";

        private const string CONCURRENT_LICENCE_FILE = "server.lic";

        private static readonly string SQL_QUERIES_STORED_DIR_PATH = NamingUtil.Instance.getSarPath("sql");

        private Context o_namingContext = null;

        private Properties properties;

        private string code;

        private string name;

        protected internal override void createService()
        {
            File file1 = new File(NamingUtil.Instance.getSarPath(""));
            File file2 = new File(NamingUtil.Instance.getSarPath("zdb.properties"));
            if (!file1.exists() || !file1.Directory)
            {
                throw new Exception("could not find path : " + file1);
            }
            DatabaseDBUtil.CurrentDBUtil = LocalDBUtil.getInstance(file1.AbsolutePath + "/", "zdb.properties");
            if (!file2.exists())
            {
                this.log.info("Initializing ZDB Properties:");
                setDBProperty("database.name", "CES Database");
                setDBProperty("database.description", "");
                setDBProperty("database.accessibility", "");
                setDBProperty("database.decimal.scale", "2");
                setDBProperty("database.divider.scale", "32");
                setDBProperty("database.rounding.mode", "4");
                setDBProperty("database.accessmode", "Local");
                setDBProperty("database.max.equipments", "1000");
                setDBProperty("database.max.materials", "1000");
                setDBProperty("database.max.labors", "1000");
                setDBProperty("database.max.suppliers", "1000");
                setDBProperty("database.max.consumables", "1000");
                setDBProperty("database.max.assemblys", "1000");
                setDBProperty("database.max.subcontractors", "1000");
                setDBProperty("database.max.gekcodes", "1000");
                setDBProperty("database.max.groupcodes", "1000");
                setDBProperty("database.max.projectinfos", "1000");
                setDBProperty("active.directory.on", "false");
                setDBProperty("lic.mode", "workstation");
                setDBProperty("use.log", "true");
                setDBProperty("use.log.item", "false");
                setDBProperty("database.schema.version", "6.2.20");
                DatabaseDBUtil.Properties.storeDBProperties();
            }
            else
            {
                this.log.info("Loading ZDB Properties");
                if (StringUtils.isNullOrBlank(getDBProperty("use.log")))
                {
                    setDBProperty("use.log", "true");
                }
                if (StringUtils.isNullOrBlank(getDBProperty("use.log.item")))
                {
                    setDBProperty("use.log.item", "false");
                }
                if (string.ReferenceEquals(getDBProperty("database.max.materials"), null))
                {
                    setDBProperty("database.name", "CES Database");
                    setDBProperty("database.description", "");
                    setDBProperty("database.accessibility", "");
                    setDBProperty("database.max.equipments", "1000");
                    setDBProperty("database.max.materials", "1000");
                    setDBProperty("database.max.labors", "1000");
                    setDBProperty("database.max.suppliers", "1000");
                    setDBProperty("database.max.consumables", "1000");
                    setDBProperty("database.max.assemblys", "1000");
                    setDBProperty("database.max.subcontractors", "1000");
                    setDBProperty("database.max.gekcodes", "1000");
                    setDBProperty("database.max.groupcodes", "1000");
                    setDBProperty("database.max.projectinfos", "1000");
                    setDBProperty("database.decimal.scale", "2");
                    setDBProperty("database.divider.scale", "32");
                    setDBProperty("database.rounding.mode", "4");
                    if (StringUtils.isNullOrBlank(getDBProperty("database.schema.version")))
                    {
                        setDBProperty("database.schema.version", "6.2.20");
                    }
                    if (StringUtils.isNullOrBlank(getDBProperty("active.directory.on")))
                    {
                        setDBProperty("active.directory.on", "false");
                    }
                    if (StringUtils.isNullOrBlank(getDBProperty("lic.mode")))
                    {
                        setDBProperty("lic.mode", "workstation");
                    }
                    DatabaseDBUtil.Properties.storeDBProperties();
                }
                if (string.ReferenceEquals(getDBProperty("database.decimal.scale"), null))
                {
                    setDBProperty("database.decimal.scale", "2");
                    setDBProperty("database.divider.scale", "32");
                    setDBProperty("database.rounding.mode", "4");
                    DatabaseDBUtil.Properties.storeDBProperties();
                }
                if (string.ReferenceEquals(getDBProperty("appserver.name"), null))
                {
                    if (NamingUtil.Instance.TomEE)
                    {
                        setDBProperty("appserver.name", "tomee");
                        setDBProperty("appserver.ejbPort", "8080");
                        setDBProperty("appserver.jmsPort", "61616");
                        setDBProperty("appserver.httpsOn", "false");
                    }
                    else if (NamingUtil.Instance.JBoss)
                    {
                        setDBProperty("appserver.name", "jboss");
                        setDBProperty("appserver.ejbPort", "1099");
                        setDBProperty("appserver.jmsPort", "1099");
                        setDBProperty("appserver.httpsOn", "false");
                    }
                }
            }
        }

        protected internal override void startService()
        {
            try
            {
                this.log.info("Starting SessionFactory for: " + getDBProperty("database.name"));
                MBeanServer mBeanServer = NamingUtil.Instance.locateMBeanServer();
                ObjectName objectName = new ObjectName(NamingUtil.Instance.getMBeanHarObjectName("Hibernate"));
                mBeanServer.invoke(objectName, "start", null, null);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                throw new Exception(exception.Message);
            }
            Timer timer = new Timer(false);
            timer.schedule(new TimerTaskAnonymousInnerClass(this, exception)
               , 40000L);
        }

        private class TimerTaskAnonymousInnerClass : TimerTask
        {
            private readonly CESServer outerInstance;

            private Exception exception;

            public TimerTaskAnonymousInnerClass(CESServer outerInstance, Exception exception)
            {
                this.outerInstance = outerInstance;
                this.exception = exception;
            }

            public void run()
            {
                try
                {
                    outerInstance.fixUserManagement();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                    Console.Write(exception.StackTrace);
                }
                try
                {
                    outerInstance.updateDatabaseSchema();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                    Console.Write(exception.StackTrace);
                }
                try
                {
                    outerInstance.storeLicenceFile2db();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                    Console.Write(exception.StackTrace);
                }
                try
                {
                    outerInstance.updateDBMSProjectsSchema();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                    Console.Write(exception.StackTrace);
                }
                try
                {
                    outerInstance.updateProjectsSchema();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                    Console.Write(exception.StackTrace);
                }
            }
        }

        private static void listContext(Context paramContext, string paramString)
        {
            try
            {
                NamingEnumeration namingEnumeration = paramContext.listBindings("");
                while (namingEnumeration.hasMore())
                {
                    Binding binding = (Binding)namingEnumeration.next();
                    string str1 = binding.ClassName;
                    string str2 = binding.Name;
                    Console.WriteLine(paramString + str1 + " " + str2);
                    object @object = binding.Object;
                    if (@object is Context)
                    {
                        listContext((Context)@object, paramString + " ");
                    }
                }
            }
            catch (NamingException namingException)
            {
                Console.WriteLine("JNDI failure: " + namingException.Message);
            }
        }

        protected internal override void stopService()
        {
            try
            {
                this.log.info("Stopping SessionFactory to: " + getDBProperty("database.name"));
                MBeanServer mBeanServer = NamingUtil.Instance.locateMBeanServer();
                ObjectName objectName = new ObjectName(NamingUtil.Instance.getMBeanHarObjectName("Hibernate"));
                mBeanServer.invoke(objectName, "stop", null, null);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                throw new Exception(exception.Message);
            }
        }

        protected internal override void destroyService()
        {
            this.o_namingContext = null;
            DatabaseDBUtil.Properties.storeDBProperties();
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public void setDBProperty(String paramString1, String paramString2) throws Exception
        public virtual void setDBProperty(string paramString1, string paramString2)
        {
            if (paramString1.Equals("database.author"))
            {
                throw new Exception("authors are CESWriters and can not be updated from here");
            }
            DatabaseDBUtil.Properties.setProperty(paramString1, paramString2);
        }

        public virtual void storeDBProperties()
        {
            getDBProperty("database.author");
            DatabaseDBUtil.Properties.storeDBProperties();
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @ManagedOperation public String getDBProperty(String paramString) throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        public virtual string getDBProperty(string paramString)
        {
            if (paramString.Equals("database.author"))
            {
                RolesHome rolesHome = (RolesHome)lookup("nomitech/ces/auth/RolesHome");
                try
                {
                    System.Collections.IEnumerator iterator = rolesHome.findByRole("CESProjectWriter").GetEnumerator();
                    string str;
                    for (str = ""; iterator.MoveNext(); str = str + roles.Data.PrincipalId + ",")
                    {
                        Roles roles = (Roles)iterator.Current;
                    }
                    if (str.Length > 0)
                    {
                        str = str.Substring(0, str.Length - 1);
                    }
                    DatabaseDBUtil.Properties.setProperty("database.author", str);
                    return str;
                }
                catch (FinderException)
                {
                    DatabaseDBUtil.Properties.setProperty("database.author", "");
                    return "";
                }
            }
            return DatabaseDBUtil.Properties.getProperty(paramString);
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public java.util.Properties getAllDBProperties(String paramString) throws Exception
        public virtual Properties getAllDBProperties(string paramString)
        {
            getDBProperty("database.author");
            Properties properties1 = new Properties((Properties)DatabaseDBUtil.Properties);
            RolesHome rolesHome = (RolesHome)lookup("nomitech/ces/auth/RolesHome");
            try
            {
                System.Collections.IEnumerator iterator = rolesHome.findByPrincipalId(paramString).GetEnumerator();
                string str;
                for (str = ""; iterator.MoveNext(); str = str + roles.Data.Role + ", ")
                {
                    Roles roles = (Roles)iterator.Current;
                }
                if (str.Length > 0)
                {
                    str = str.Substring(0, str.Length - 2);
                }
                properties1.setProperty("database.accessibility", str);
                System.Collections.IEnumerator enumeration = properties1.propertyNames();
                while (enumeration.MoveNext())
                {
                    string str1 = (string)enumeration.Current;
                    properties1.setProperty(str1, properties1.getProperty(str1));
                }
            }
            catch (FinderException)
            {
                properties1.setProperty("database.accessibility", "Unknown: Not found");
                return properties1;
            }
            return properties1;
        }

        public virtual ISet<object> DBPropertiesKeys
        {
            get
            {
                return ((Properties)DatabaseDBUtil.Properties).Keys;
            }
        }

        private void storeLicenceFile2db()
        {
            this.log.info("Looking for Licence Mode in properties");
            if (!StringUtils.isNullOrBlank(getDBProperty("lic.mode")) && getDBProperty("lic.mode").Equals("concurrent", StringComparison.OrdinalIgnoreCase))
            {
                this.log.info("Is concurernt mode");
                File file = new File(NamingUtil.Instance.getSarPath("server.lic"));
                if (file.exists() && !file.Directory)
                {
                    handleLicenseFile(file);
                }
                else
                {
                    this.log.warn("LIC file does not exists");
                }
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private void handleLicenseFile(java.io.File paramFile) throws java.io.IOException, Exception
        private void handleLicenseFile(File paramFile)
        {
            this.log.info("LIC File exists");
            XStream xStream = new XStream();
            string str = decryptFile(paramFile);
            if (xStream.fromXML(str) is LicenseV2)
            {
                openLicFileVer2(xStream, str);
            }
            else
            {
                openLicFileVersion2(xStream, str);
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private void openLicFileVersion2(com.thoughtworks.xstream.XStream paramXStream, String paramString) throws Exception
        private void openLicFileVersion2(XStream paramXStream, string paramString)
        {
            LicenseFromGenerator licenseFromGenerator = (LicenseFromGenerator)paramXStream.fromXML(paramString);
            session = (new LookupSessionInterface(this, null)).currentSession();
            session.beginTransaction();
            try
            {
                Number number = (Number)session.createQuery("select count(*) from ConcLicenseTable ").list().GetEnumerator().next();
                if (number.intValue() == 0)
                {
                    storeLisenceToDb(licenseFromGenerator, session);
                }
                else if (number.intValue() != 0)
                {
                    compareAndUpdateLicenseToDb(licenseFromGenerator, session);
                }
                if (session.Transaction.Active)
                {
                    session.Transaction.commit();
                    if (session.Open)
                    {
                        session.flush();
                        session.close();
                    }
                }
            }
            catch (HibernateException)
            {
                if (session.Transaction.Active)
                {
                    session.Transaction.commit();
                    if (session.Open)
                    {
                        session.flush();
                        session.close();
                    }
                }
            }
            finally
            {
                if (session.Open)
                {
                    session.flush();
                    session.close();
                }
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private void openLicFileVer2(com.thoughtworks.xstream.XStream paramXStream, String paramString) throws Exception
        private void openLicFileVer2(XStream paramXStream, string paramString)
        {
            LicenseV2 licenseV2 = (LicenseV2)paramXStream.fromXML(paramString);
            session = (new LookupSessionInterface(this, null)).currentSession();
            session.beginTransaction();
            try
            {
                Number number = (Number)session.createQuery("select count(*) from ConcLicenseTable ").list().GetEnumerator().next();
                if (number.intValue() == 0)
                {
                    storeLisenceToDbV2(licenseV2, session);
                }
                else if (number.intValue() != 0)
                {
                    compareAndUpdateLicenseToDbV2(licenseV2, session);
                }
                if (session.Transaction.Active)
                {
                    session.Transaction.commit();
                    if (session.Open)
                    {
                        session.flush();
                        session.close();
                    }
                }
            }
            catch (HibernateException)
            {
                if (session.Transaction.Active)
                {
                    session.Transaction.commit();
                    if (session.Open)
                    {
                        session.flush();
                        session.close();
                    }
                }
            }
            finally
            {
                if (session.Open)
                {
                    session.flush();
                    session.close();
                }
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private void compareAndUpdateLicenseToDbV2(nomitech.common.license.model.LicenseV2 paramLicenseV2, org.hibernate.Session paramSession) throws Exception
        private void compareAndUpdateLicenseToDbV2(LicenseV2 paramLicenseV2, Session paramSession)
        {
            License license = LicenseManager.loadFromTable(paramSession);
            bool @bool = false;
            if (license.RowItems.Count != 0)
            {
                foreach (LicenseRowItem licenseRowItem in license.RowItems)
                {
                    if (licenseRowItem == null || licenseRowItem.Version == 1)
                    {
                        @bool = true;
                    }
                }
            }
            if (license.RowItems.Count != paramLicenseV2.LicenseSerialNumberDatas.Count || @bool)
            {
                paramSession.createQuery("delete from ConcLicenseTable").executeUpdate();
                storeLisenceToDbV2(paramLicenseV2, paramSession);
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private void storeLisenceToDbV2(nomitech.common.license.model.LicenseV2 paramLicenseV2, org.hibernate.Session paramSession) throws Exception
        private void storeLisenceToDbV2(LicenseV2 paramLicenseV2, Session paramSession)
        {
            bool? @bool = Convert.ToBoolean(false);
            System.Collections.IEnumerator enumeration = NetworkInterface.NetworkInterfaces;
            List<object> arrayList = new List<object>();
            string str = "";
            foreach (NetworkInterface networkInterface in Collections.list(enumeration))
            {
                foreach (InetAddress inetAddress in Collections.list(networkInterface.InetAddresses))
                {
                    arrayList.Add(inetAddress);
                    str = inetAddress.HostAddress;
                    if (inetAddress.HostAddress.equalsIgnoreCase(paramLicenseV2.Ip))
                    {
                        @bool = Convert.ToBoolean(true);
                        InetAddress inetAddress1 = inetAddress;
                    }
                }
            }
            if (@bool.Value)
            {
                License license = new License();
                foreach (LicenseSerialNumberDataV2 licenseSerialNumberDataV2 in paramLicenseV2.LicenseSerialNumberDatas)
                {
                    LicenseRowItem licenseRowItem = new LicenseRowItem(licenseSerialNumberDataV2);
                    licenseRowItem.TrialDays = licenseSerialNumberDataV2.ExpirationDate;
                    licenseRowItem.CompanyName = paramLicenseV2.CompanyName;
                    licenseRowItem.ServerIP = paramLicenseV2.Ip;
                    licenseRowItem.ExpDate = "NULL";
                    licenseRowItem.IsTrial = licenseSerialNumberDataV2.Trial;
                    licenseRowItem.TrialDays = licenseSerialNumberDataV2.ExpirationDate;
                    licenseRowItem.Version = 2;
                    license.addRowItemToSet(licenseRowItem);
                }
                LicenseManager.storeToTable(paramSession, license);
            }
            else
            {
                throw new Exception("NOT A VALID LICENCE for this ip(" + str + ") .License file ip :" + paramLicenseV2.Ip);
            }
        }

        private void updateDBMSProjectsSchema()
        {
            Session session = (new LookupSessionInterface(this, null)).currentSession();
            System.Collections.IList list = session.createQuery("FROM ProjectDbmsTable WHERE databaseName IS NOT NULL").list();
            URL uRL = typeof(nomitech.common.ProjectSessionFactory).getResource("projectDB.xml");
            try
            {
                foreach (ProjectDbmsTable projectDbmsTable in list)
                {
                    string str1 = ProjectDBUtil.createJdbcUrl(projectDbmsTable.HostName, projectDbmsTable.DatabaseName, projectDbmsTable.HostPort, 3);
                    string str2 = CryptUtil.Instance.decryptHexString(projectDbmsTable.HostUsername);
                    string str3 = AddOnUtil.Instance.decryptHexString(projectDbmsTable.HostPassword);
                    int? integer = (int?)session.createSQLQuery("SELECT count(*) FROM " + projectDbmsTable.DatabaseName + ".INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'BOQITEM'").uniqueResult();
                    if (integer.Value != 0)
                    {
                        int i = ((Number)session.createQuery("select count(o.projectUrlId) from ProjectUrlTable o").uniqueResult()).intValue();
                        if (i == 0)
                        {
                            integer = Convert.ToInt32(0);
                        }
                    }
                    if (integer.Value == 0)
                    {
                        Configuration configuration = ProjectSessionFactoryBuilder.Instance.createConfiguration(uRL, ProjectServerDBUtil.SQLSERVER_DBMS, null, true, str1, str2, str3, "");
                        SessionFactory sessionFactory = configuration.buildSessionFactory();
                        sessionFactory.close();
                    }
                }
                if (session.Open)
                {
                    session.flush();
                    session.close();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
            }
        }

        private void updateProjectsSchema()
        {
            LookupSessionInterface lookupSessionInterface = null;
            try
            {
                Console.WriteLine("CESServer.updateProjectsSchema()");
                string str = getDBProperty("database.schema.version");
                lookupSessionInterface = new LookupSessionInterface(this, null);
                Session session = lookupSessionInterface.currentSession();
                System.Collections.IList list = null;
                try
                {
                    list = executeSqlQueryByName(lookupSessionInterface, "get_project_versions_and_names.sql", ProjectDBProperties.PROPERTIES_VERSION);
                }
                catch (Exception)
                {
                    this.log.info("Could not execute query to fetch projects ");
                }
                ProjectDBUtil.ProjectGroupCodesProviderFactory = new DummyProjectGroupCodesProviderFactory();
                if (list != null)
                {
                    HashSet<object> hashSet = new HashSet<object>(list.Count);
                    foreach (object[] arrayOfObject in list)
                    {
                        ProjectDBUtil projectDBUtil = null;
                        ProjectUrlTable projectUrlTable = null;
                        string str1 = "";
                        string str2 = "";
                        try
                        {
                            session = lookupSessionInterface.currentSession();
                            str2 = (string)arrayOfObject[0];
                            str1 = (string)arrayOfObject[1];
                            long? long = (long?)arrayOfObject[2];
                            projectUrlTable = (ProjectUrlTable)session.get(typeof(ProjectUrlTable), long);
                            if (projectUrlTable == null)
                            {
                                continue;
                            }
                            if (hashSet.Contains(str2))
                            {
                                ProjectSchemaUpdateUtil.updateManyProjectsDBSchema(session, str2, ProjectDBProperties.PROPERTIES_VERSION, long);
                                continue;
                            }
                            hashSet.Add(str2);
                            if (StringUtils.isOlderVersionFrom(str1, ProjectDBProperties.PROPERTIES_VERSION))
                            {
                                if (projectUrlTable != null)
                                {
                                    this.log.info("OPENING PROJECT DATABASE: " + projectUrlTable.DatabaseName + ", URL: " + projectUrlTable.ProjectUrlId);
                                    projectDBUtil = ProjectServerDBUtil.openProjectFromUrl(projectUrlTable, new DummyProjectGroupCodesProviderFactory());
                                    projectDBUtil.ProjectUrlId = long;
                                    this.log.info("SCHEMA UPDATE: " + projectUrlTable.DatabaseName + ", URL: " + projectUrlTable.ProjectUrlId + " HAVING VERSION: " + str1);
                                    projectDBUtil.Properties.PreviousVersion = str1;
                                    ProjectSchemaUpdateUtil.updateNewerSchema(projectDBUtil.Properties, projectDBUtil, lookupSessionInterface);
                                    session = lookupSessionInterface.currentSession();
                                    ProjectSchemaUpdateUtil.updateManyProjectsDBSchema(session, str2, ProjectDBProperties.PROPERTIES_VERSION, long);
                                    this.log.info("UPDATED SUCCESSFULLY: " + projectUrlTable.DatabaseName + " VERSION " + str1 + " to " + ProjectDBProperties.PROPERTIES_VERSION);
                                }
                                else
                                {
                                    this.log.error("CANNOT FIND PROJECT URL WITH ID " + long);
                                }
                                if (projectDBUtil != null)
                                {
                                    projectDBUtil.closeProject();
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            if (projectDBUtil != null)
                            {
                                projectDBUtil.closeProject();
                            }
                            if (projectUrlTable != null)
                            {
                                this.log.error("Could not update Project with database: " + projectUrlTable.DatabaseName + " and version " + str1 + " Exception is " + exception.Message);
                            }
                            else
                            {
                                this.log.error("Could not update Project Message is : " + exception.Message);
                            }
                            Console.WriteLine(exception.ToString());
                            Console.Write(exception.StackTrace);
                        }
                    }
                }
                else
                {
                    this.log.warn("get projects returned null ");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
            }
            if (lookupSessionInterface != null)
            {
                lookupSessionInterface.closeSession();
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public String decryptFile(java.io.File paramFile) throws java.io.IOException
        public virtual string decryptFile(File paramFile)
        {
            string str = StringUtils.readFileIntoString(paramFile);
            return CryptUtil.Instance.decryptHexString(str);
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private void compareAndUpdateLicenseToDb(nomitech.common.license.model.LicenseFromGenerator paramLicenseFromGenerator, org.hibernate.Session paramSession) throws Exception
        private void compareAndUpdateLicenseToDb(LicenseFromGenerator paramLicenseFromGenerator, Session paramSession)
        {
            License license = LicenseManager.loadFromTable(paramSession);
            if (license.RowItems.Count != paramLicenseFromGenerator.LicenseSerialNumberDatas.Count)
            {
                paramSession.createQuery("delete from ConcLicenseTable").executeUpdate();
                storeLisenceToDb(paramLicenseFromGenerator, paramSession);
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private void storeLisenceToDb(nomitech.common.license.model.LicenseFromGenerator paramLicenseFromGenerator, org.hibernate.Session paramSession) throws Exception
        private void storeLisenceToDb(LicenseFromGenerator paramLicenseFromGenerator, Session paramSession)
        {
            bool? @bool = Convert.ToBoolean(false);
            System.Collections.IEnumerator enumeration = NetworkInterface.NetworkInterfaces;
            List<object> arrayList = new List<object>();
            foreach (NetworkInterface networkInterface in Collections.list(enumeration))
            {
                foreach (InetAddress inetAddress in Collections.list(networkInterface.InetAddresses))
                {
                    arrayList.Add(inetAddress);
                    if (inetAddress.HostAddress.equalsIgnoreCase(paramLicenseFromGenerator.Ip))
                    {
                        @bool = Convert.ToBoolean(true);
                        InetAddress inetAddress1 = inetAddress;
                    }
                }
            }
            if (@bool.Value)
            {
                License license = new License();
                foreach (LicenseSerialNumberData licenseSerialNumberData in paramLicenseFromGenerator.LicenseSerialNumberDatas)
                {
                    LicenseRowItem licenseRowItem = new LicenseRowItem(licenseSerialNumberData);
                    licenseRowItem.ExpDate = licenseSerialNumberData.ExpirationDate;
                    licenseRowItem.CompanyName = paramLicenseFromGenerator.CompanyName;
                    licenseRowItem.ServerIP = paramLicenseFromGenerator.Ip;
                    licenseRowItem.IsTrial = false;
                    licenseRowItem.TrialDays = -1;
                    licenseRowItem.Version = 1;
                    license.addRowItemToSet(licenseRowItem);
                }
                LicenseManager.storeToTable(paramSession, license);
            }
            else
            {
                throw new Exception("NOT A VALID LICENCE for this ip .License file ip" + paramLicenseFromGenerator.Ip);
            }
        }

        public virtual void updateDatabaseSchema()
        {
            string str = getDBProperty("database.schema.version");
            if (string.ReferenceEquals(str, null))
            {
                str = "1.0.0";
            }
            this.log.info("Updating Country");
            SchemaUpdateUtil.updateCountryTable(new LookupSessionInterface(this, null));
            this.log.info("Creating Table For Column mapping ");
            SchemaUpdateUtil.updateOrCreateMetadataForBoqitem(new LookupSessionInterface(this, null));
            this.log.info("Updating Currency Table ");
            SchemaUpdateUtil.updateCurrencyTable(new LookupSessionInterface(this, null));
            this.log.info("Updating Database Schema From : " + str);
            LookupSessionInterface lookupSessionInterface = new LookupSessionInterface(this, null);
            SchemaUpdateUtil.updateSchema(DatabaseDBUtil.Properties, str, lookupSessionInterface);
            this.log.info("Installing SQL Queries: " + str);
            installSqlQueries(lookupSessionInterface);
            str = getDBProperty("database.schema.version");
            this.log.info("End Updating Database Schema To : " + str);
        }

        private void installSqlQueries(LookupSessionInterface paramLookupSessionInterface)
        {
            Session session = paramLookupSessionInterface.currentSession();
            try
            {
                string str = getDBProperty("database.schema.version");
                System.Collections.IList list = FileUtils.getFilesNotRecursiveSpecificExtentionOrder(SQL_QUERIES_STORED_DIR_PATH, "sql", true);
                List<object> arrayList = new List<object>(list.Count);
                installWithNumbers(session, list, arrayList);
                installTriggers(session, list, arrayList);
                disableAllTriggers(session, list, arrayList);
                cleanupExecutedFiles(str, arrayList);
            }
            catch (Exception exception)
            {
                this.log.info("failed to execute stored query  path dir is " + SQL_QUERIES_STORED_DIR_PATH);
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
            }
            paramLookupSessionInterface.closeSession();
        }

        private void cleanupExecutedFiles(string paramString, IList<File> paramList)
        {
            DateTime date = DateTime.Now;
            SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd-HH-mm-ss");
            string str = SQL_QUERIES_STORED_DIR_PATH + File.separator + string.Format("executed_{0}_{1}.zip", new object[] { paramString, simpleDateFormat.format(DateTime.Now) });
            if (paramList.Count > 0)
            {
                try
                {
                    FileUtils.moveFilesToZip(new File(str), paramList);
                }
                catch (IOException iOException)
                {
                    this.log.error("Could not move sql files to zip", iOException);
                }
            }
            File file = new File(SQL_QUERIES_STORED_DIR_PATH);
            File[] arrayOfFile = file.listFiles(new FileFilterAnonymousInnerClass(this));
            if (arrayOfFile.Length > 0)
            {
                str = SQL_QUERIES_STORED_DIR_PATH + File.separator + string.Format("archived_{0}_{1}.zip", new object[] { paramString, simpleDateFormat.format(DateTime.Now) });
                try
                {
                    FileUtils.moveFilesToZip(new File(str), arrayOfFile);
                }
                catch (IOException iOException)
                {
                    this.log.error("Could not move sql files to zip", iOException);
                }
            }
        }

        private class FileFilterAnonymousInnerClass : FileFilter
        {
            private readonly CESServer outerInstance;

            public FileFilterAnonymousInnerClass(CESServer outerInstance)
            {
                this.outerInstance = outerInstance;
            }

            public bool accept(File param1File)
            {
                return !param1File.File ? false : ((param1File.Name.StartsWith("executed_") && param1File.Name.EndsWith("sql")));
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private void installWithNumbers(org.hibernate.Session paramSession, java.util.List<java.io.File> paramList1, java.util.List<java.io.File> paramList2) throws java.io.IOException
        private void installWithNumbers(Session paramSession, IList<File> paramList1, IList<File> paramList2)
        {
            foreach (File file in paramList1)
            {
                if (StringUtils.startsWithNumber(file.Name))
                {
                    string str = FileUtils.getFileContents(file);
                    string[] arrayOfString = str.Split("GO--E_X_L", true);
                    try
                    {
                        foreach (string str1 in arrayOfString)
                        {
                            this.log.info("executing stored sql part " + file.Name);
                            paramSession.createSQLQuery(str1).executeUpdate();
                        }
                    }
                    catch (HibernateException hibernateException)
                    {
                        this.log.info("failed to execute stored query  path dir is " + SQL_QUERIES_STORED_DIR_PATH);
                        Console.WriteLine(hibernateException.ToString());
                        Console.Write(hibernateException.StackTrace);
                    }
                    paramList2.Add(file);
                }
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private void installTriggers(org.hibernate.Session paramSession, java.util.List<java.io.File> paramList1, java.util.List<java.io.File> paramList2) throws java.io.IOException
        private void installTriggers(Session paramSession, IList<File> paramList1, IList<File> paramList2)
        {
            foreach (File file in paramList1)
            {
                if (isTrigerDefinition(file))
                {
                    string str = FileUtils.getFileContents(file);
                    string[] arrayOfString = str.Split("GO--E_X_L", true);
                    try
                    {
                        foreach (string str1 in arrayOfString)
                        {
                            this.log.info("executing stored sql part " + file.Name);
                            paramSession.createSQLQuery(str1).executeUpdate();
                        }
                    }
                    catch (HibernateException hibernateException)
                    {
                        this.log.info("failed to execute stored query  path dir is " + SQL_QUERIES_STORED_DIR_PATH);
                        Console.WriteLine(hibernateException.ToString());
                        Console.Write(hibernateException.StackTrace);
                    }
                    this.log.info("Successfully installed " + file.Name);
                    paramList2.Add(file);
                }
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private void disableAllTriggers(org.hibernate.Session paramSession, java.util.List<java.io.File> paramList1, java.util.List<java.io.File> paramList2) throws java.io.IOException
        private void disableAllTriggers(Session paramSession, IList<File> paramList1, IList<File> paramList2)
        {
            foreach (File file in paramList1)
            {
                if (isTrigerDisableFile(file))
                {
                    string str = FileUtils.getFileContents(file);
                    try
                    {
                        this.log.info(" Trying to install " + file.Name);
                        paramSession.createSQLQuery(str).executeUpdate();
                        this.log.info("Successfully installed " + file.Name);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.ToString());
                        Console.Write(exception.StackTrace);
                    }
                    paramList2.Add(file);
                }
            }
        }

        private bool isTrigerDefinition(File paramFile)
        {
            return (paramFile.Name.StartsWith("tr_") && !paramFile.Name.ToLower().Contains("disable") && !paramFile.Name.ToLower().Contains("enable"));
        }

        private bool isTrigerDisableFile(File paramFile)
        {
            return (paramFile.Name.StartsWith("tr_") && paramFile.Name.contains("disable"));
        }

        private IList<object[]> executeSqlQueryByName(LookupSessionInterface paramLookupSessionInterface, string paramString1, string paramString2)
        {
            Session session = paramLookupSessionInterface.currentSession();
            try
            {
                System.Collections.IList list = FileUtils.getFilesNotRecursiveSpecificExtentionOrder(SQL_QUERIES_STORED_DIR_PATH, "sql", true);
                foreach (File file in list)
                {
                    if (file.Name.equalsIgnoreCase(paramString1))
                    {
                        string str = FileUtils.getFileContents(file);
                        str = str.replaceAll("PARAM_VERSION_NUMBER_LESS_THAN", paramString2);
                        try
                        {
                            this.log.info("executing stored sql part " + file.Name);
                            return file.Name.equalsIgnoreCase("get_project_versions_and_names.sql") ? session.createSQLQuery(str).addScalar("DBNAME", StringType.INSTANCE).addScalar("VER", StringType.INSTANCE).addScalar("PROJECTURLID", LongType.INSTANCE).list() : session.createSQLQuery(str).list();
                        }
                        catch (HibernateException)
                        {
                            this.log.info("failed to execute stored query  path dir is " + SQL_QUERIES_STORED_DIR_PATH);
                        }
                    }
                }
            }
            catch (Exception)
            {
                this.log.info("failed to execute stored query  path dir is " + SQL_QUERIES_STORED_DIR_PATH);
            }
            return null;
        }

        public virtual void fixLineItems()
        {
            string str = getDBProperty("database.schema.version");
            if (string.ReferenceEquals(str, null))
            {
                str = "1.0.0";
            }
            SchemaUpdateUtil.fixLineItems(DatabaseDBUtil.Properties, str, new LookupSessionInterface(this, null));
        }

        public virtual void fixUserManagement()
        {
            string str = getDBProperty("database.schema.version");
            if (string.ReferenceEquals(str, null))
            {
                str = "1.0.0";
            }
            if (NamingUtil.Instance.TomEE)
            {
                SchemaUpdateUtil.fixUserManagement(DatabaseDBUtil.Properties, str, (DataSource)lookup("openejb:Resource/DefaultDS"));
            }
            else
            {
                SchemaUpdateUtil.fixUserManagement(DatabaseDBUtil.Properties, str, (DataSource)lookup("java:/DefaultDS"));
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private javax.naming.Context getNamingContext() throws Exception
        private Context NamingContext
        {
            get
            {
                if (this.o_namingContext == null)
                {
                    this.o_namingContext = NamingUtil.Instance.createInitialContext(false);
                }
                return this.o_namingContext;
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private Object lookup(String paramString) throws Exception
        private object lookup(string paramString)
        {
            return NamingContext.lookup(paramString);
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public void createCMSAdmin(String paramString1, String paramString2, String paramString3) throws Exception
        public virtual void createCMSAdmin(string paramString1, string paramString2, string paramString3)
        {
            RolesHome rolesHome = (RolesHome)lookup("nomitech/ces/auth/RolesHome");
            PrincipalsHome principalsHome = (PrincipalsHome)lookup("nomitech/ces/auth/PrincipalsHome");
            Roles roles = rolesHome.create(paramString1);
            RolesData rolesData = roles.Data;
            rolesData.Role = paramString3;
            rolesData.RoleGroup = "Roles";
            roles.Data = rolesData;
            Principals principals = principalsHome.create(paramString1);
            PrincipalsData principalsData = principals.Data;
            principalsData.Password = paramString2;
            principals.Data = principalsData;
        }

        public virtual string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }


        public override string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }


        public virtual Properties Properties
        {
            get
            {
                return this.properties;
            }
            set
            {
                this.properties = value;
            }
        }


        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @PostConstruct public void postConstruct()
        public virtual void postConstruct()
        {
            string str1 = this.properties.getProperty("code");
            string str2 = this.properties.getProperty("name");
            if (string.ReferenceEquals(str1, null))
            {
                str1 = Code;
            }
            if (string.ReferenceEquals(str2, null))
            {
                str2 = Name;
            }
            requireNotNull(str1);
            requireNotNull(str2);
            try
            {
                createService();
                startService();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
            }
            try
            {
                MBeanServer mBeanServer = ManagementFactory.PlatformMBeanServer;
                ObjectName objectName = new ObjectName(str2);
                mBeanServer.registerMBean(this, objectName);
            }
            catch (MalformedObjectNameException malformedObjectNameException)
            {
                this.log.error("Malformed MBean name: " + str2);
                throw new MBeanRegistrationException(malformedObjectNameException);
            }
            catch (InstanceAlreadyExistsException instanceAlreadyExistsException)
            {
                this.log.error("Instance already exists: " + str2);
                throw new MBeanRegistrationException(instanceAlreadyExistsException);
            }
            catch (NotCompliantMBeanException notCompliantMBeanException)
            {
                this.log.error("Class is not a valid MBean: " + str1);
                throw new MBeanRegistrationException(notCompliantMBeanException);
            }
            catch (MBeanRegistrationException mBeanRegistrationException)
            {
                this.log.error("Error registering " + str2 + ", " + str1);
                throw new MBeanRegistrationException(mBeanRegistrationException);
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @PreDestroy public void preDestroy()
        public virtual void preDestroy()
        {
            string str = this.properties.getProperty("name");
            try
            {
                stopService();
                destroyService();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
            }
            try
            {
                MBeanServer mBeanServer = ManagementFactory.PlatformMBeanServer;
                ObjectName objectName = new ObjectName(str);
                mBeanServer.unregisterMBean(objectName);
            }
            catch (MalformedObjectNameException malformedObjectNameException)
            {
                this.log.error("Malformed MBean name: " + str);
                throw new MBeanRegistrationException(malformedObjectNameException);
            }
            catch (MBeanRegistrationException mBeanRegistrationException)
            {
                this.log.error("Error unregistering " + str);
                throw new MBeanRegistrationException(mBeanRegistrationException);
            }
            catch (InstanceNotFoundException instanceNotFoundException)
            {
                this.log.error("Error unregistering " + str);
                throw new MBeanRegistrationException(instanceNotFoundException);
            }
        }

        private void requireNotNull(string paramString)
        {
            if (string.ReferenceEquals(paramString, null))
            {
                throw new MBeanRegistrationException(new System.ArgumentException(), "code property not specified, stopping");
            }
        }

        private class LookupSessionInterface : SessionInterface
        {
            private readonly CESServer outerInstance;

            internal Session session = null;

            internal Dialect dialect = null;

            internal Connection connection = null;

            //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
            //ORIGINAL LINE: private LookupSessionInterface() throws Exception
            internal LookupSessionInterface(CESServer outerInstance)
            {
                this.outerInstance = outerInstance;
            }

            public virtual Session currentSession()
            {
                if (this.session != null && this.session.Open)
                {
                    return this.session;
                }
                try
                {
                    SessionFactory sessionFactory = (SessionFactory)outerInstance.lookup(NamingUtil.Instance.prefixName("hibernate/SessionFactory"));
                    this.session = sessionFactory.openSession();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                    Console.Write(exception.StackTrace);
                }
                return this.session;
            }

            public virtual Connection Connection
            {
                get
                {
                    if (this.connection != null)
                    {
                        return this.connection;
                    }
                    try
                    {
                        SessionFactory sessionFactory = (SessionFactory)outerInstance.lookup(NamingUtil.Instance.prefixName("hibernate/SessionFactory"));
                        this.connection = ((SessionFactoryImplementor)sessionFactory).ConnectionProvider.Connection;
                        return this.connection;
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.ToString());
                        Console.Write(exception.StackTrace);
                        return null;
                    }
                }
            }

            public virtual void closeSession()
            {
                if (this.session != null && this.session.Open)
                {
                    this.session.flush();
                    this.session.clear();
                    this.session.close();
                    this.session = null;
                }
                else
                {
                    this.session = null;
                }
            }

            public virtual Configuration Configuration
            {
                get
                {
                    try
                    {
                        return (Configuration)outerInstance.lookup(NamingUtil.Instance.prefixName("hibernate/Configuration"));
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.ToString());
                        Console.Write(exception.StackTrace);
                        return null;
                    }
                }
            }

            public virtual Dialect Dialect
            {
                get
                {
                    if (this.dialect != null)
                    {
                        return this.dialect;
                    }
                    try
                    {
                        SessionFactory sessionFactory = (SessionFactory)outerInstance.lookup(NamingUtil.Instance.prefixName("hibernate/SessionFactory"));
                        this.dialect = ((SessionFactoryImplementor)sessionFactory).Dialect;
                        return this.dialect;
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.ToString());
                        Console.Write(exception.StackTrace);
                        return null;
                    }
                }
            }
        }
    }


    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\ces\CESServer.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}