using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;

namespace Desktop.common.nomitech.common
{
    using BaseCache = Desktop.common.nomitech.common.@base.BaseCache;
    using ProjectGroupCodesProvider = Desktop.common.nomitech.common.@base.ProjectGroupCodesProvider;
    using ProjectGroupCodesProviderFactory = Desktop.common.nomitech.common.@base.ProjectGroupCodesProviderFactory;
    using LocationCache = Models.cache.LocationCache;
    using ParamItemCache = Models.cache.ParamItemCache;
    using ProjectVariableCache = Models.cache.ProjectVariableCache;
    using WBS2Cache = Models.cache.WBS2Cache;
    using WBSCache = Models.cache.WBSCache;
    using ProjectInfoTable = Models.local.ProjectInfoTable;
    using ProjectUrlTable = Models.local.ProjectUrlTable;
    using ProjectTemplateTable = Models.proj.ProjectTemplateTable;
    using AddOnUtil = Desktop.common.nomitech.common.util.AddOnUtil;
    using CryptUtil = Desktop.common.nomitech.common.util.CryptUtil;
    using MappingException = org.hibernate.MappingException;
    using Query = org.hibernate.Query;
    using Session = org.hibernate.Session;
    using SessionFactory = org.hibernate.SessionFactory;
    using Configuration = org.hibernate.cfg.Configuration;
    using Column = org.hibernate.mapping.Column;
    using PersistentClass = org.hibernate.mapping.PersistentClass;
    using Property = org.hibernate.mapping.Property;
    using LongType = org.hibernate.type.LongType;
    using Type = org.hibernate.type.Type;

    public abstract class ProjectDBUtil
    {
        private bool InstanceFieldsInitialized = false;

        public ProjectDBUtil()
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
        }

        private void InitializeInstanceFields()
        {
            prjDBInterceptor = new ProjectDBInterceptor(this);
        }

        protected internal ProjectDBInterceptor prjDBInterceptor;

        public const string SERVER_DATABASE_NAME = "CostOS";

        public static int CEP_FILE = 0;

        public static int HSQL_DBMS = 1;

        public static int MYSQL_DBMS = 2;

        public static int SQLSERVER_DBMS = 3;

        public static int ORACLE_DBMS = 4;

        protected internal static bool hsqlInitialized = false;

        protected internal static bool mySqlInitialized = false;

        protected internal static bool sqlServerInitialized = false;

        protected internal static bool oracleInitialized = false;

        protected internal static bool syncToEventDispatch = false;

        protected internal static System.Collections.IDictionary s_utilInstanceMap = new ConcurrentDictionary();

        private long? projectUrlId;

        private static ProjectDBUtil s_currentProjectDBUtil = null;

        protected internal static ProjectGroupCodesProviderFactory s_providerFactory = null;

        protected internal ProjectGroupCodesProviderFactory o_overridenFactory = null;

        internal File projectFolder = null;

        private ProjectGroupCodesProvider projectGroupCodesProvider = null;

        private static IDictionary<long, ProjectTemplateTable> s_projectTemplateMap = null;

        private WBSCache wbs1Cache = null;

        private WBS2Cache wbs2Cache = null;

        private ParamItemCache paramItemCache = null;

        private LocationCache locationCache = null;

        private ProjectVariableCache projectVariableCache = null;

        public abstract ProjectDBProperties Properties { get; }

        public abstract void loadDB();

        public abstract void unloadDB();

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public abstract void saveDB(java.io.File paramFile) throws Exception;
        public abstract void saveDB(File paramFile);

        public abstract bool hasOpenedSession();

        public abstract Session currentSession();

        public abstract void closeSession();

        public abstract void closeSession(Session paramSession);

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public abstract java.util.List loadBulk(Class paramClass, System.Nullable<long>[] paramArrayOfLong) throws Exception;
        public abstract System.Collections.IList loadBulk(Type paramClass, long?[] paramArrayOfLong);

        public abstract bool DBLoaded { get; }

        public abstract string UniqueId { get; }

        public abstract void closeProject();

        public abstract SessionFactory SessionFactory { get; }

        public abstract Configuration Configuration { get; }

        public abstract bool CollaborationMode { get; }

        public virtual void flushCache()
        {
            if (!DBLoaded)
            {
                return;
            }
            SessionFactory.Cache.evictEntityRegions();
            SessionFactory.Cache.evictCollectionRegions();
            SessionFactory.Cache.evictDefaultQueryRegion();
            try
            {
                SessionFactory.Cache.evictQueryRegions();
            }
            catch (Exception)
            {
            }
        }

        public static bool SyncToEventDispatch
        {
            set
            {
                syncToEventDispatch = value;
            }
        }

        protected internal virtual void updateNewerDatabase()
        {
            ProjectSchemaUpdateUtil.updateNewerSchema(Properties, this);
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static void closeProject(ProjectDBUtil paramProjectDBUtil) throws Exception
        public static void closeProject(ProjectDBUtil paramProjectDBUtil)
        {
            paramProjectDBUtil.closeProject();
            s_utilInstanceMap.Remove(paramProjectDBUtil.UniqueId);
        }

        public static void closeAllProjects()
        {
            System.Collections.IEnumerator iterator = s_utilInstanceMap.Keys.GetEnumerator();
            while (iterator.MoveNext())
            {
                ProjectDBUtil projectDBUtil = (ProjectDBUtil)s_utilInstanceMap[iterator.Current];
                projectDBUtil.closeProject();
            }
            s_utilInstanceMap.Clear();
        }

        public static ProjectDBUtil currentProjectDBUtil()
        {
            return s_currentProjectDBUtil;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static void setCurrentProjectDBUtil(ProjectDBUtil paramProjectDBUtil) throws Exception
        public static ProjectDBUtil CurrentProjectDBUtil
        {
            set
            {
                s_currentProjectDBUtil = value;
            }
        }

        public static void closeAllProjectsExcept(IList<ProjectDBUtil> paramList)
        {
            System.Collections.IList list = Arrays.asList(s_utilInstanceMap.Values.toArray(new ProjectDBUtil[s_utilInstanceMap.Count]));
            foreach (object @object in list)
            {
                if (!paramList.Contains(@object))
                {
                    try
                    {
                        ((ProjectDBUtil)@object).closeProject();
                        s_utilInstanceMap.Remove(((ProjectDBUtil)@object).UniqueId);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.ToString());
                        Console.Write(exception.StackTrace);
                    }
                }
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static void initDriver(int paramInt) throws Exception
        public static void initDriver(int paramInt)
        {
            if (paramInt == HSQL_DBMS && !hsqlInitialized)
            {
                Type.GetType("org.hsqldb.jdbcDriver");
            }
            else if (paramInt == MYSQL_DBMS && !mySqlInitialized)
            {
                Type.GetType("org.mariadb.jdbc.Driver");
            }
            else if (paramInt == SQLSERVER_DBMS && !sqlServerInitialized)
            {
                Type.GetType("net.sourceforge.jtds.jdbc.Driver");
            }
            else if (paramInt == ORACLE_DBMS && !oracleInitialized)
            {
                Type.GetType("oracle.jdbc.driver.OracleDriver");
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static String createJdbcUrl(String paramString1, String paramString2, String paramString3, int paramInt) throws Exception
        public static string createJdbcUrl(string paramString1, string paramString2, string paramString3, int paramInt)
        {
            if (paramInt == HSQL_DBMS)
            {
                return "jdbc:hsqldb:hsql://" + paramString1 + ":" + paramString3 + "/" + paramString2;
            }
            if (paramInt == MYSQL_DBMS)
            {
                return "jdbc:mysql://" + paramString1 + ":" + paramString3 + "/" + paramString2;
            }
            if (paramInt == SQLSERVER_DBMS)
            {
                return "jdbc:jtds:sqlserver://" + paramString1 + ":" + paramString3 + ";databaseName=" + paramString2;
            }
            if (paramInt == ORACLE_DBMS)
            {
                return "jdbc:oracle:thin:@" + paramString1 + ":" + paramString3 + ":" + paramString2;
            }
            throw new Exception("DBMS not supported: " + paramInt);
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static ProjectFileDBUtil createNewFileProject(Desktop.common.nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable) throws Exception
        public static ProjectFileDBUtil createNewFileProject(ProjectUrlTable paramProjectUrlTable)
        {
            ProjectFileDBUtil projectFileDBUtil = new ProjectFileDBUtil(paramProjectUrlTable);
            s_utilInstanceMap[projectFileDBUtil.UniqueId] = projectFileDBUtil;
            return projectFileDBUtil;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static ProjectFileDBUtil createNewFileProject() throws Exception
        public static ProjectFileDBUtil createNewFileProject()
        {
            ProjectFileDBUtil projectFileDBUtil = new ProjectFileDBUtil();
            s_utilInstanceMap[projectFileDBUtil.UniqueId] = projectFileDBUtil;
            return projectFileDBUtil;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static ProjectFileDBUtil openProjectFromFile(java.io.File paramFile, Desktop.common.nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable, Desktop.common.nomitech.common.base.ProjectGroupCodesProviderFactory paramProjectGroupCodesProviderFactory) throws Exception
        public static ProjectFileDBUtil openProjectFromFile(File paramFile, ProjectUrlTable paramProjectUrlTable, ProjectGroupCodesProviderFactory paramProjectGroupCodesProviderFactory)
        {
            ProjectFileDBUtil projectFileDBUtil = (ProjectFileDBUtil)s_utilInstanceMap[paramFile.AbsoluteFile + ";" + paramProjectUrlTable.Id];
            if (projectFileDBUtil == null)
            {
                projectFileDBUtil = new ProjectFileDBUtil(paramFile, paramProjectUrlTable, paramProjectGroupCodesProviderFactory);
                s_utilInstanceMap[projectFileDBUtil.UniqueId] = projectFileDBUtil;
                return projectFileDBUtil;
            }
            throw new ProjectDBException();
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static ProjectDBUtil getOpenedProjectInstance(Desktop.common.nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable) throws Exception
        public static ProjectDBUtil getOpenedProjectInstance(ProjectUrlTable paramProjectUrlTable)
        {
            string str = paramProjectUrlTable.Url + ";" + paramProjectUrlTable.Id;
            Console.WriteLine("Getting project instance: " + str);
            return (ProjectDBUtil)s_utilInstanceMap[str];
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static ProjectDBUtil openProjectFromUrl(Desktop.common.nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable, Desktop.common.nomitech.common.base.ProjectGroupCodesProviderFactory paramProjectGroupCodesProviderFactory) throws Exception
        public static ProjectDBUtil openProjectFromUrl(ProjectUrlTable paramProjectUrlTable, ProjectGroupCodesProviderFactory paramProjectGroupCodesProviderFactory)
        {
            if (paramProjectUrlTable.Dbms.Equals(Convert.ToInt32(CEP_FILE)))
            {
                return openProjectFromFile(new File(paramProjectUrlTable.Url), paramProjectUrlTable, paramProjectGroupCodesProviderFactory);
            }
            ProjectServerDBUtil projectServerDBUtil = (ProjectServerDBUtil)s_utilInstanceMap[paramProjectUrlTable.Url + ";" + paramProjectUrlTable.Id];
            if (projectServerDBUtil == null || !projectServerDBUtil.DBLoaded)
            {
                projectServerDBUtil = new ProjectServerDBUtil(paramProjectUrlTable, paramProjectGroupCodesProviderFactory);
                s_utilInstanceMap[projectServerDBUtil.UniqueId] = projectServerDBUtil;
                return projectServerDBUtil;
            }
            throw new ProjectDBException();
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static ProjectServerDBUtil createNewProject(Desktop.common.nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable, java.util.Properties paramProperties) throws Exception
        public static ProjectServerDBUtil createNewProject(ProjectUrlTable paramProjectUrlTable, Properties paramProperties)
        {
            ProjectServerDBUtil projectServerDBUtil = new ProjectServerDBUtil(paramProjectUrlTable, paramProperties);
            s_utilInstanceMap[projectServerDBUtil.UniqueId] = projectServerDBUtil;
            return projectServerDBUtil;
        }

        public static ProjectUrlTable getFileUrl(string paramString)
        {
            ProjectUrlTable projectUrlTable = new ProjectUrlTable();
            projectUrlTable.Dbms = Convert.ToInt32(CEP_FILE);
            projectUrlTable.Url = paramString;
            projectUrlTable.Revision = "";
            return projectUrlTable;
        }

        public static bool checkDatabaseExists(ProjectUrlTable paramProjectUrlTable)
        {
            if (paramProjectUrlTable.Dbms.Equals(Convert.ToInt32(CEP_FILE)))
            {
                return Directory.Exists(paramProjectUrlTable.Url) || File.Exists(paramProjectUrlTable.Url);
            }
            try
            {
                initDriver(paramProjectUrlTable.Dbms.Value);
                string str1 = CryptUtil.Instance.decryptHexString(paramProjectUrlTable.Username);
                string str2 = AddOnUtil.Instance.decryptHexString(paramProjectUrlTable.Password);
                Connection connection = DriverManager.getConnection(paramProjectUrlTable.Url, str1, str2);
                connection.close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static ProjectUrlTable getUrlFromProperties(Properties paramProperties)
        {
            ProjectUrlTable projectUrlTable = new ProjectUrlTable();
            if (paramProperties.getProperty("project.connection.server") == null || paramProperties.getProperty("project.connection.server").Equals("false"))
            {
                projectUrlTable.Dbms = Convert.ToInt32(CEP_FILE);
                projectUrlTable.Url = paramProperties.getProperty("project.init.file");
                projectUrlTable.CreatesNewDatabases = Convert.ToBoolean(true);
            }
            else
            {
                projectUrlTable.Dbms = Convert.ToInt32((new int?(paramProperties.getProperty("project.connection.dbmsType"))));
                projectUrlTable.DbmsName = paramProperties.getProperty("project.connection.dbmsName");
                projectUrlTable.Url = paramProperties.getProperty("project.connection.url");
                projectUrlTable.Hostname = paramProperties.getProperty("project.connection.hostname");
                projectUrlTable.Username = paramProperties.getProperty("project.connection.username");
                projectUrlTable.Password = paramProperties.getProperty("project.connection.password");
                projectUrlTable.Port = paramProperties.getProperty("project.connection.port");
                projectUrlTable.DatabaseName = paramProperties.getProperty("project.connection.databaseName");
                if (paramProperties.getProperty("project.connection.singleProjectDatabase") == null || paramProperties.getProperty("project.connection.singleProjectDatabase").Equals("true"))
                {
                    projectUrlTable.CreatesNewDatabases = Convert.ToBoolean(true);
                }
                else
                {
                    projectUrlTable.CreatesNewDatabases = Convert.ToBoolean(false);
                }
            }
            if (paramProperties.containsKey("project.name"))
            {
                projectUrlTable.Name = paramProperties.getProperty("project.name");
            }
            if (paramProperties.containsKey("project.revision"))
            {
                projectUrlTable.Revision = paramProperties.getProperty("project.revision");
            }
            if (paramProperties.containsKey("project.description"))
            {
                projectUrlTable.Description = paramProperties.getProperty("project.description");
            }
            return projectUrlTable;
        }

        public static ProjectInfoTable findProjectInfoFromUrl(ProjectUrlTable paramProjectUrlTable)
        {
            Query query = DatabaseDBUtil.currentSession().createQuery("select prjInfo from ProjectInfoTable as prjInfo join prjInfo.urlSet as urlTable with urlTable.projectUrlId = :urlid");
            query.setLong("urlid", paramProjectUrlTable.ProjectUrlId.Value);
            System.Collections.IEnumerator iterator = query.iterate();
            //JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
            if (!iterator.hasNext())
            {
                DatabaseDBUtil.closeSession();
                return null;
            }
            //JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
            ProjectInfoTable projectInfoTable = (ProjectInfoTable)DatabaseDBUtil.currentSession().load(typeof(ProjectInfoTable), ((ProjectInfoTable)iterator.next()).Id);
            projectInfoTable = projectInfoTable.copyWithAssignments();
            DatabaseDBUtil.closeSession();
            return projectInfoTable;
        }

        public static void dropUrl(ProjectUrlTable paramProjectUrlTable)
        {
            if (paramProjectUrlTable.CreatesNewDatabases != null && !paramProjectUrlTable.CreatesNewDatabases.Value)
            {
                return;
            }
            if (paramProjectUrlTable.Dbms.Equals(Convert.ToInt32(CEP_FILE)))
            {
                File file = new File(paramProjectUrlTable.Url);
                if (file.exists())
                {
                    file.delete();
                }
                return;
            }
            string str1 = null;
            string str2 = null;
            if (paramProjectUrlTable.Dbms.Equals(Convert.ToInt32(MYSQL_DBMS)))
            {
                str1 = "DROP DATABASE " + paramProjectUrlTable.DatabaseName;
                str2 = "mysql";
            }
            else if (paramProjectUrlTable.Dbms.Equals(Convert.ToInt32(SQLSERVER_DBMS)))
            {
                str1 = "DROP DATABASE " + paramProjectUrlTable.DatabaseName;
                str2 = "master";
            }
            else if (paramProjectUrlTable.Dbms.Equals(Convert.ToInt32(ORACLE_DBMS)))
            {
                str1 = "DROP DATABASE " + paramProjectUrlTable.DatabaseName;
                str2 = "sys";
            }
            Connection connection = null;
            Statement statement = null;
            try
            {
                initDriver(paramProjectUrlTable.Dbms.Value);
                string str = createJdbcUrl(paramProjectUrlTable.Hostname, str2, paramProjectUrlTable.Port, paramProjectUrlTable.Dbms.Value);
                try
                {
                    string str3 = CryptUtil.Instance.decryptHexString(paramProjectUrlTable.Username);
                    string str4 = AddOnUtil.Instance.decryptHexString(paramProjectUrlTable.Password);
                    connection = DriverManager.getConnection(str, str3, str4);
                    statement = connection.createStatement();
                }
                catch (Exception)
                {
                    str = createJdbcUrl(paramProjectUrlTable.Hostname, "CostOS", paramProjectUrlTable.Port, paramProjectUrlTable.Dbms.Value);
                    connection = DriverManager.getConnection(str, paramProjectUrlTable.Username, paramProjectUrlTable.Password);
                    statement = connection.createStatement();
                }
                if (paramProjectUrlTable.Dbms.Equals(Convert.ToInt32(SQLSERVER_DBMS)))
                {
                    statement.executeUpdate("ALTER DATABASE " + paramProjectUrlTable.DatabaseName + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                }
                statement.executeUpdate(str1);
                statement.close();
                connection.close();
                Console.WriteLine("SUCCESSFULLY DROPPED: " + paramProjectUrlTable.DatabaseName);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                if (statement != null)
                {
                    try
                    {
                        statement.close();
                    }
                    catch (SQLException sQLException)
                    {
                        Console.WriteLine(sQLException.ToString());
                        Console.Write(sQLException.StackTrace);
                    }
                }
                if (connection != null)
                {
                    try
                    {
                        connection.close();
                    }
                    catch (SQLException sQLException)
                    {
                        Console.WriteLine(sQLException.ToString());
                        Console.Write(sQLException.StackTrace);
                    }
                }
            }
        }

        public virtual File ProjectFolder
        {
            get
            {
                return this.projectFolder;
            }
        }

        public virtual PersistentClass findPersisentClass(Type paramClass)
        {
            System.Collections.IEnumerator iterator = Configuration.ClassMappings;
            while (iterator.MoveNext())
            {
                PersistentClass persistentClass = (PersistentClass)iterator.Current;
                //JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
                if (persistentClass.ClassName.Equals(paramClass.FullName))
                {
                    return persistentClass;
                }
            }
            return null;
        }

        public virtual IList<PersistentClass> listClasses()
        {
            LinkedList linkedList = new LinkedList();
            System.Collections.IEnumerator iterator = Configuration.ClassMappings;
            while (iterator.MoveNext())
            {
                linkedList.AddLast(iterator.Current);
            }
            return linkedList;
        }

        public virtual IList<Column> listAllColumns(PersistentClass paramPersistentClass)
        {
            List<Column> list = new List<Column>();
            list.AddRange(listNonPropertyColumns(paramPersistentClass));
            return list;
        }

        public virtual IList<Column> listNonPropertyColumns(PersistentClass paramPersistentClass)
        {
            List<object> arrayList = new List<object>();
            List<Column> list = new List<Column>();

            IEnumerator iterator = paramPersistentClass.RootTable.ColumnIterator;
            while (iterator.MoveNext())
            {
                Column column = (Column)iterator.Current;
                if (!list.Contains(column))
                {
                    arrayList.Add(column);
                }
            }
            return arrayList.Cast<Column>().ToList();
        }

        public virtual IList<Column> listPropertyColumns(PersistentClass paramPersistentClass)
        {
            List<object> arrayList = new List<object>();
            System.Collections.IEnumerator iterator1 = paramPersistentClass.Identifier.ColumnIterator;
            //JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
            if (iterator1.hasNext())
            {
                //JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
                Column column = (Column)iterator1.next();
                arrayList.Add(column);
            }
            System.Collections.IEnumerator iterator2 = paramPersistentClass.PropertyIterator;
            while (iterator2.MoveNext())
            {
                Property property = (Property)iterator2.Current;
                if (!isInsertable(property))
                {
                    continue;
                }
                iterator1 = property.ColumnIterator;
                //JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
                if (iterator1.hasNext())
                {
                    //JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
                    Column column = (Column)iterator1.next();
                    arrayList.Add(column);
                }
            }
            return arrayList;
        }

        private bool isInsertable(Property paramProperty)
        {
            bool @bool = true;
            try
            {
                @bool = paramProperty.Insertable;
            }
            catch (Exception)
            {
                Console.WriteLine("NULL INSERTABLE for " + paramProperty);
            }
            return @bool;
        }

        public virtual IList<Property> listProperties(PersistentClass paramPersistentClass)
        {
            List<object> arrayList = new List<object>();
            Property property = new PropertyAnonymousInnerClass(this);
            arrayList.Add(property);
            System.Collections.IEnumerator iterator = paramPersistentClass.PropertyIterator;
            while (iterator.MoveNext())
            {
                Property property1 = (Property)iterator.Current;
                if (!isInsertable(property1))
                {
                    continue;
                }
                System.Collections.IEnumerator iterator1 = property1.ColumnIterator;
                //JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
                if (iterator1.hasNext())
                {
                    arrayList.Add(property1);
                }
            }
            return arrayList;
        }

        private class PropertyAnonymousInnerClass : Property
        {
            private readonly ProjectDBUtil outerInstance;

            public PropertyAnonymousInnerClass(ProjectDBUtil outerInstance)
            {
                this.outerInstance = outerInstance;
                lType = new LongType();
            }

            private LongType lType;

            //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
            //ORIGINAL LINE: public org.hibernate.type.Type getType() throws org.hibernate.MappingException
            public Type Type
            {
                get
                {
                    return this.lType;
                }
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public java.sql.Connection createJdbcConnection() throws Exception
        public virtual Connection createJdbcConnection()
        {
            string str1 = Configuration.getProperty("hibernate.connection.url");
            string str2 = Configuration.getProperty("hibernate.connection.username");
            string str3 = Configuration.getProperty("hibernate.connection.password");
            return DriverManager.getConnection(str1, str2, str3);
        }

        public static ProjectGroupCodesProviderFactory ProjectGroupCodesProviderFactory
        {
            set
            {
                s_providerFactory = value;
            }
        }

        public virtual ProjectGroupCodesProvider ProjectGroupCodesProvider
        {
            get
            {
                if (this.o_overridenFactory == null && s_providerFactory == null)
                {
                    throw new System.InvalidOperationException("ProjectGroupCodesProvider is not set or null");
                }
                if (this.projectGroupCodesProvider == null)
                {
                    if (this.o_overridenFactory != null)
                    {
                        this.projectGroupCodesProvider = this.o_overridenFactory.createNewFactory(this);
                    }
                    else
                    {
                        this.projectGroupCodesProvider = s_providerFactory.createNewFactory(this);
                    }
                }
                return this.projectGroupCodesProvider;
            }
        }

        public virtual long? ProjectUrlId
        {
            get
            {
                return this.projectUrlId;
            }
            set
            {
                this.projectUrlId = value;
            }
        }


        public abstract int DbmsType { get; }

        public static void pushVariablesTemplate(ProjectTemplateTable paramProjectTemplateTable)
        {
            if (s_projectTemplateMap == null)
            {
                s_projectTemplateMap = new Hashtable(1);
            }
            s_projectTemplateMap[paramProjectTemplateTable.Id] = paramProjectTemplateTable;
        }

        public static ProjectTemplateTable peekVariablesTemplate(long paramLong)
        {
            if (s_projectTemplateMap == null)
            {
                return null;
            }
            ProjectTemplateTable projectTemplateTable = (ProjectTemplateTable)s_projectTemplateMap[Convert.ToInt64(paramLong)];
            if (projectTemplateTable != null)
            {
                s_projectTemplateMap.Remove(Convert.ToInt64(paramLong));
            }
            if (s_projectTemplateMap.Count == 0)
            {
                s_projectTemplateMap = null;
            }
            return projectTemplateTable;
        }

        public abstract ProjectUrlTable ProjectUrl { get; }

        public virtual BaseCache Wbs1Cache
        {
            get
            {
                if (this.wbs1Cache == null)
                {
                    this.wbs1Cache = new WBSCache(this, false);
                }
                return this.wbs1Cache;
            }
        }

        public virtual BaseCache Wbs2Cache
        {
            get
            {
                if (this.wbs2Cache == null)
                {
                    this.wbs2Cache = new WBS2Cache(this, false);
                }
                return this.wbs2Cache;
            }
        }

        public virtual BaseCache LocationCache
        {
            get
            {
                if (this.locationCache == null)
                {
                    this.locationCache = new LocationCache(this);
                }
                return this.locationCache;
            }
        }

        public virtual BaseCache ParamItemCache
        {
            get
            {
                if (this.paramItemCache == null)
                {
                    this.paramItemCache = new ParamItemCache(this, false);
                }
                return this.paramItemCache;
            }
        }

        public virtual ProjectVariableCache ProjectVariableCache
        {
            get
            {
                if (this.projectVariableCache == null)
                {
                    this.projectVariableCache = new ProjectVariableCache(this);
                }
                return this.projectVariableCache;
            }
        }
    }


    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\ProjectDBUtil.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}