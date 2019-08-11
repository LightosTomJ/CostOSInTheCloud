using System;
using System.Threading;

namespace Desktop.common.nomitech.ces
{
    using AssemblyTable = Models.local.AssemblyTable;
    using ConsumableTable = Models.local.ConsumableTable;
    using EquipmentTable = Models.local.EquipmentTable;
    using ExtraCode1Table = Models.local.ExtraCode1Table;
    using ExtraCode2Table = Models.local.ExtraCode2Table;
    using ExtraCode3Table = Models.local.ExtraCode3Table;
    using ExtraCode4Table = Models.local.ExtraCode4Table;
    using ExtraCode5Table = Models.local.ExtraCode5Table;
    using ExtraCode6Table = Models.local.ExtraCode6Table;
    using ExtraCode7Table = Models.local.ExtraCode7Table;
    using GekCodeTable = Models.local.GekCodeTable;
    using GroupCodeTable = Models.local.GroupCodeTable;
    using LaborTable = Models.local.LaborTable;
    using MaterialTable = Models.local.MaterialTable;
    using ParamItemTable = Models.local.ParamItemTable;org	using ProjectInfoTable = Models.local.ProjectInfoTable;
    using ProjectWBSTable = Models.local.ProjectWBSTable;
    using SubcontractorTable = Models.local.SubcontractorTable;
    using SupplierTable = Models.local.SupplierTable;
    using ServiceMBeanSupport = Desktop.common.nomitech.common.management.ServiceMBeanSupport;
    using NamingUtil = Desktop.common.nomitech.common.util.NamingUtil;
    using CacheMode = Desktop.common.org.hibernate.CacheMode;
    using FlushMode = Desktop.common.org.hibernate.FlushMode;
    using ScrollMode = Desktop.common.org.hibernate.ScrollMode;
    using ScrollableResults = Desktop.common.org.hibernate.ScrollableResults;
    using Session = Desktop.common.org.hibernate.Session;
    using SessionFactory = Desktop.common.org.hibernate.SessionFactory;
    using Transaction = Desktop.common.org.hibernate.Transaction;
    using Session = Desktop.common.org.hibernate.classic.Session;
    using Order = Desktop.common.org.hibernate.criterion.Order;
    using Restrictions = Desktop.common.org.hibernate.criterion.Restrictions;
    using FullTextSession = Desktop.common.org.hibernate.search.FullTextSession;
    using Search = Desktop.common.org.hibernate.search.Search;

    public class CESIndex : ServiceMBeanSupport, CESIndexMBean, ThreadStart
    {
        private const int BATCH_SIZE = 4000;

        private const int RESCROLL_LIMIT = 52000;

        private Context o_namingContext = null;

        private bool indexing = false;

        private string indexStatus = "NOT_RUNNING";

        public override string Name
        {
            get
            {
                return "CES - CostOS Enterprise Server Full Text Search Indexing Interface";
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

        private SessionFactory SessionFactory
        {
            get
            {
                SessionFactory sessionFactory = null;
                try
                {
                    sessionFactory = (SessionFactory)lookup(NamingUtil.Instance.prefixName("hibernate/SessionFactory"));
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                    Console.Write(exception.StackTrace);
                }
                return sessionFactory;
            }
        }

        public virtual string startIndexing()
        {
            if (Indexing)
            {
                return "ALREADY_STARTED";
            }
            Thread thread = new Thread(this);
            thread.Start();
            return "SUCCESS";
        }

        public virtual void run()
        {
            Indexing = false;
            Session session = SessionFactory.openSession();
            Indexing = true;
            try
            {
                session = indexParamItem(session);
                session = indexAssembly(session);
                session = indexEquipment(session);
                session = indexSubcontractor(session);
                session = indexLabor(session);
                session = indexSuppliers(session);
                session = indexMaterials(session);
                session = indexConsumable(session);
                session = indexGroupCode(session);
                session = indexGekCode(session);
                session = indexExtraCode1(session);
                session = indexExtraCode2(session);
                session = indexExtraCode3(session);
                session = indexExtraCode4(session);
                session = indexExtraCode5(session);
                session = indexExtraCode6(session);
                session = indexExtraCode7(session);
                session = indexProjectInfo(session);
                session = indexProjectWBS(session);
                Text = "FINISHED";
            }
            catch (Exception exception)
            {
                if (!exception.Message.Equals("canceled by user"))
                {
                    Console.WriteLine(exception.ToString());
                    Console.Write(exception.StackTrace);
                }
                Text = "ERROR: " + exception.Message;
            }
            Indexing = false;
            session.flush();
            session.close();
        }

        private string Text
        {
            set
            {
                IndexStatus = "STARTED: " + value;
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexParamItem(org.hibernate.Session paramSession) throws Exception
        private Session indexParamItem(Session paramSession)
        {
            string str = "ParamItem: ";
            sbyte b = 0;
            long l = 0L;
            if (b)
            {
                Text = str + b;
            }
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(ParamItemTable)).add(Restrictions.gt("paramitemId", new long?(l))).addOrder(Order.asc("paramitemId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    ParamItemTable paramItemTable = (ParamItemTable)scrollableResults.get(0);
                    fullTextSession.index(paramItemTable);
                    l = paramItemTable.ParamitemId.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(ParamItemTable)).add(Restrictions.gt("paramitemId", new long?(l))).addOrder(Order.asc("paramitemId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            if (!session.Open)
            {
                session = SessionFactory.openSession();
            }
            return session;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexAssembly(org.hibernate.Session paramSession) throws Exception
        private Session indexAssembly(Session paramSession)
        {
            string str = "Assembly: ";
            sbyte b = 0;
            long l = 0L;
            if (b)
            {
                Text = str + b;
            }
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(AssemblyTable)).add(Restrictions.gt("assemblyId", new long?(l))).addOrder(Order.asc("assemblyId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    AssemblyTable assemblyTable = (AssemblyTable)scrollableResults.get(0);
                    fullTextSession.index(assemblyTable);
                    l = assemblyTable.AssemblyId.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(AssemblyTable)).add(Restrictions.gt("assemblyId", new long?(l))).addOrder(Order.asc("assemblyId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            if (!session.Open)
            {
                session = SessionFactory.openSession();
            }
            return session;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexEquipment(org.hibernate.Session paramSession) throws Exception
        private Session indexEquipment(Session paramSession)
        {
            string str = "Equipment: ";
            sbyte b = 0;
            long l = 0L;
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            if (b)
            {
                Text = str + b;
            }
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(EquipmentTable)).add(Restrictions.gt("equipmentId", new long?(l))).addOrder(Order.asc("equipmentId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    EquipmentTable equipmentTable = (EquipmentTable)scrollableResults.get(0);
                    fullTextSession.index(equipmentTable);
                    l = equipmentTable.EquipmentId.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(EquipmentTable)).add(Restrictions.gt("equipmentId", new long?(l))).addOrder(Order.asc("equipmentId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            if (!session.Open)
            {
                session = SessionFactory.openSession();
            }
            return session;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexSubcontractor(org.hibernate.Session paramSession) throws Exception
        private Session indexSubcontractor(Session paramSession)
        {
            string str = "Subcontractor: ";
            sbyte b = 0;
            long l = 0L;
            if (b)
            {
                Text = str + b;
            }
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(SubcontractorTable)).add(Restrictions.gt("subcontractorId", new long?(l))).addOrder(Order.asc("subcontractorId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    SubcontractorTable subcontractorTable = (SubcontractorTable)scrollableResults.get(0);
                    fullTextSession.index(subcontractorTable);
                    l = subcontractorTable.SubcontractorId.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(SubcontractorTable)).add(Restrictions.gt("subcontractorId", new long?(l))).addOrder(Order.asc("subcontractorId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            if (!session.Open)
            {
                session = SessionFactory.openSession();
            }
            return session;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexLabor(org.hibernate.Session paramSession) throws Exception
        private Session indexLabor(Session paramSession)
        {
            string str = "Labor: ";
            sbyte b = 0;
            long l = 0L;
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            if (b)
            {
                Text = str + b;
            }
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(LaborTable)).add(Restrictions.gt("laborId", new long?(l))).addOrder(Order.asc("laborId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    LaborTable laborTable = (LaborTable)scrollableResults.get(0);
                    fullTextSession.index(laborTable);
                    l = laborTable.LaborId.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(LaborTable)).add(Restrictions.gt("laborId", new long?(l))).addOrder(Order.asc("laborId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            if (!session.Open)
            {
                session = SessionFactory.openSession();
            }
            return session;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexSuppliers(org.hibernate.Session paramSession) throws Exception
        private Session indexSuppliers(Session paramSession)
        {
            string str = "Suppliers: ";
            sbyte b = 0;
            long l = 0L;
            if (b)
            {
                Text = str + b;
            }
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(SupplierTable)).add(Restrictions.gt("supplierId", new long?(l))).addOrder(Order.asc("supplierId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    SupplierTable supplierTable = (SupplierTable)scrollableResults.get(0);
                    fullTextSession.index(supplierTable);
                    l = supplierTable.SupplierId.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(SupplierTable)).add(Restrictions.gt("supplierId", new long?(l))).addOrder(Order.asc("supplierId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            if (!session.Open)
            {
                session = SessionFactory.openSession();
            }
            return session;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexMaterials(org.hibernate.Session paramSession) throws Exception
        private Session indexMaterials(Session paramSession)
        {
            string str = "Materials: ";
            sbyte b = 0;
            long l = 0L;
            if (b)
            {
                Text = str + b;
            }
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(MaterialTable)).add(Restrictions.gt("materialId", new long?(l))).addOrder(Order.asc("materialId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    MaterialTable materialTable = (MaterialTable)scrollableResults.get(0);
                    fullTextSession.index(materialTable);
                    l = materialTable.MaterialId.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(MaterialTable)).add(Restrictions.gt("materialId", new long?(l))).addOrder(Order.asc("materialId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            return session;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexConsumable(org.hibernate.Session paramSession) throws Exception
        private Session indexConsumable(Session paramSession)
        {
            string str = "Consumables: ";
            sbyte b = 0;
            long l = 0L;
            if (b)
            {
                Text = str + b;
            }
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(ConsumableTable)).add(Restrictions.gt("consumableId", new long?(l))).addOrder(Order.asc("consumableId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    ConsumableTable consumableTable = (ConsumableTable)scrollableResults.get(0);
                    fullTextSession.index(consumableTable);
                    l = consumableTable.ConsumableId.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(ConsumableTable)).add(Restrictions.gt("consumableId", new long?(l))).addOrder(Order.asc("consumableId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            if (!session.Open)
            {
                session = SessionFactory.openSession();
            }
            return session;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexGroupCode(org.hibernate.Session paramSession) throws Exception
        private Session indexGroupCode(Session paramSession)
        {
            string str = "Group Code: ";
            sbyte b = 0;
            long l = 0L;
            if (b)
            {
                Text = str + b;
            }
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(GroupCodeTable)).add(Restrictions.gt("groupCodeId", new long?(l))).addOrder(Order.asc("groupCodeId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    GroupCodeTable groupCodeTable = (GroupCodeTable)scrollableResults.get(0);
                    fullTextSession.index(groupCodeTable);
                    l = groupCodeTable.GroupCodeId.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(GroupCodeTable)).add(Restrictions.gt("groupCodeId", new long?(l))).addOrder(Order.asc("groupCodeId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            if (!session.Open)
            {
                session = SessionFactory.openSession();
            }
            return session;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexGekCode(org.hibernate.Session paramSession) throws Exception
        private Session indexGekCode(Session paramSession)
        {
            string str = "Gek Code: ";
            sbyte b = 0;
            long l = 0L;
            if (b)
            {
                Text = str + b;
            }
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(GekCodeTable)).add(Restrictions.gt("gekCodeId", new long?(l))).addOrder(Order.asc("gekCodeId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    GekCodeTable gekCodeTable = (GekCodeTable)scrollableResults.get(0);
                    fullTextSession.index(gekCodeTable);
                    l = gekCodeTable.GekCodeId.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(GekCodeTable)).add(Restrictions.gt("gekCodeId", new long?(l))).addOrder(Order.asc("gekCodeId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            if (!session.Open)
            {
                session = SessionFactory.openSession();
            }
            return session;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexExtraCode1(org.hibernate.Session paramSession) throws Exception
        private Session indexExtraCode1(Session paramSession)
        {
            string str = "Extra Code1: ";
            sbyte b = 0;
            long l = 0L;
            if (b)
            {
                Text = str + b;
            }
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(ExtraCode1Table)).add(Restrictions.gt("extraCode1Id", new long?(l))).addOrder(Order.asc("extraCode1Id")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    ExtraCode1Table extraCode1Table = (ExtraCode1Table)scrollableResults.get(0);
                    fullTextSession.index(extraCode1Table);
                    l = extraCode1Table.ExtraCode1Id.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(ExtraCode1Table)).add(Restrictions.gt("extraCode1Id", new long?(l))).addOrder(Order.asc("extraCode1Id")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            if (!session.Open)
            {
                session = SessionFactory.openSession();
            }
            return session;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexExtraCode2(org.hibernate.Session paramSession) throws Exception
        private Session indexExtraCode2(Session paramSession)
        {
            string str = "Extra Code2: ";
            sbyte b = 0;
            long l = 0L;
            if (b)
            {
                Text = str + b;
            }
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(ExtraCode2Table)).add(Restrictions.gt("extraCode2Id", new long?(l))).addOrder(Order.asc("extraCode2Id")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    ExtraCode2Table extraCode2Table = (ExtraCode2Table)scrollableResults.get(0);
                    fullTextSession.index(extraCode2Table);
                    l = extraCode2Table.ExtraCode2Id.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(ExtraCode2Table)).add(Restrictions.gt("extraCode2Id", new long?(l))).addOrder(Order.asc("extraCode2Id")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            if (!session.Open)
            {
                session = SessionFactory.openSession();
            }
            return session;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexExtraCode3(org.hibernate.Session paramSession) throws Exception
        private Session indexExtraCode3(Session paramSession)
        {
            string str = "Extra Code3: ";
            sbyte b = 0;
            long l = 0L;
            if (b)
            {
                Text = str + b;
            }
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(ExtraCode3Table)).add(Restrictions.gt("extraCode3Id", new long?(l))).addOrder(Order.asc("extraCode3Id")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    ExtraCode3Table extraCode3Table = (ExtraCode3Table)scrollableResults.get(0);
                    fullTextSession.index(extraCode3Table);
                    l = extraCode3Table.ExtraCode3Id.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(ExtraCode3Table)).add(Restrictions.gt("extraCode3Id", new long?(l))).addOrder(Order.asc("extraCode3Id")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            if (!session.Open)
            {
                session = SessionFactory.openSession();
            }
            return session;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexExtraCode4(org.hibernate.Session paramSession) throws Exception
        private Session indexExtraCode4(Session paramSession)
        {
            string str = "Extra Code4: ";
            sbyte b = 0;
            long l = 0L;
            if (b)
            {
                Text = str + b;
            }
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(ExtraCode4Table)).add(Restrictions.gt("extraCode4Id", new long?(l))).addOrder(Order.asc("extraCode4Id")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    ExtraCode4Table extraCode4Table = (ExtraCode4Table)scrollableResults.get(0);
                    fullTextSession.index(extraCode4Table);
                    l = extraCode4Table.ExtraCode4Id.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(ExtraCode4Table)).add(Restrictions.gt("extraCode4Id", new long?(l))).addOrder(Order.asc("extraCode4Id")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            if (!session.Open)
            {
                session = SessionFactory.openSession();
            }
            return session;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexExtraCode5(org.hibernate.Session paramSession) throws Exception
        private Session indexExtraCode5(Session paramSession)
        {
            string str = "Extra Code5: ";
            sbyte b = 0;
            long l = 0L;
            if (b)
            {
                Text = str + b;
            }
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(ExtraCode5Table)).add(Restrictions.gt("extraCode5Id", new long?(l))).addOrder(Order.asc("extraCode5Id")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    ExtraCode5Table extraCode5Table = (ExtraCode5Table)scrollableResults.get(0);
                    fullTextSession.index(extraCode5Table);
                    l = extraCode5Table.ExtraCode5Id.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(ExtraCode5Table)).add(Restrictions.gt("extraCode5Id", new long?(l))).addOrder(Order.asc("extraCode5Id")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            if (!session.Open)
            {
                session = SessionFactory.openSession();
            }
            return session;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexExtraCode6(org.hibernate.Session paramSession) throws Exception
        private Session indexExtraCode6(Session paramSession)
        {
            string str = "Extra Code6: ";
            sbyte b = 0;
            long l = 0L;
            if (b)
            {
                Text = str + b;
            }
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(ExtraCode6Table)).add(Restrictions.gt("extraCode6Id", new long?(l))).addOrder(Order.asc("extraCode6Id")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    ExtraCode6Table extraCode6Table = (ExtraCode6Table)scrollableResults.get(0);
                    fullTextSession.index(extraCode6Table);
                    l = extraCode6Table.ExtraCode6Id.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(ExtraCode6Table)).add(Restrictions.gt("extraCode6Id", new long?(l))).addOrder(Order.asc("extraCode6Id")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            if (!session.Open)
            {
                session = SessionFactory.openSession();
            }
            return session;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexExtraCode7(org.hibernate.Session paramSession) throws Exception
        private Session indexExtraCode7(Session paramSession)
        {
            string str = "Extra Code7: ";
            sbyte b = 0;
            long l = 0L;
            if (b)
            {
                Text = str + b;
            }
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(ExtraCode7Table)).add(Restrictions.gt("extraCode7Id", new long?(l))).addOrder(Order.asc("extraCode7Id")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    ExtraCode7Table extraCode7Table = (ExtraCode7Table)scrollableResults.get(0);
                    fullTextSession.index(extraCode7Table);
                    l = extraCode7Table.ExtraCode7Id.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(ExtraCode7Table)).add(Restrictions.gt("extraCode7Id", new long?(l))).addOrder(Order.asc("extraCode7Id")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            if (!session.Open)
            {
                session = SessionFactory.openSession();
            }
            return session;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexProjectInfo(org.hibernate.Session paramSession) throws Exception
        private Session indexProjectInfo(Session paramSession)
        {
            string str = "Project Info: ";
            sbyte b = 0;
            long l = 0L;
            if (b)
            {
                Text = str + b;
            }
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(ProjectInfoTable)).add(Restrictions.gt("projectInfoId", new long?(l))).addOrder(Order.asc("projectInfoId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    ProjectInfoTable projectInfoTable = (ProjectInfoTable)scrollableResults.get(0);
                    fullTextSession.index(projectInfoTable);
                    l = projectInfoTable.ProjectInfoId.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(ProjectInfoTable)).add(Restrictions.gt("projectInfoId", new long?(l))).addOrder(Order.asc("projectInfoId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            if (!session.Open)
            {
                session = SessionFactory.openSession();
            }
            return session;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private org.hibernate.Session indexProjectWBS(org.hibernate.Session paramSession) throws Exception
        private Session indexProjectWBS(Session paramSession)
        {
            string str = "Project WBS: ";
            sbyte b = 0;
            long l = 0L;
            if (b)
            {
                Text = str + b;
            }
            if (paramSession.Open)
            {
                paramSession.flush();
                paramSession.close();
            }
            Session session = SessionFactory.openSession();
            FullTextSession fullTextSession = Search.getFullTextSession(session);
            fullTextSession.FlushMode = FlushMode.MANUAL;
            fullTextSession.CacheMode = CacheMode.IGNORE;
            Transaction transaction = fullTextSession.beginTransaction();
            ScrollableResults scrollableResults = fullTextSession.createCriteria(typeof(ProjectWBSTable)).add(Restrictions.gt("projectWBSId", new long?(l))).addOrder(Order.asc("projectWBSId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
            try
            {
                while (scrollableResults.next())
                {
                    ProjectWBSTable projectWBSTable = (ProjectWBSTable)scrollableResults.get(0);
                    fullTextSession.index(projectWBSTable);
                    l = projectWBSTable.ProjectWBSId.Value;
                    Text = str + b;
                    if (b % 'ྠ' == '\x0000')
                    {
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                    }
                    if (b % '쬠' == '\x0000' && b != 0)
                    {
                        scrollableResults.close();
                        fullTextSession.flushToIndexes();
                        fullTextSession.clear();
                        transaction.commit();
                        if (session.Open)
                        {
                            session.flush();
                            session.close();
                        }
                        session = SessionFactory.openSession();
                        fullTextSession = Search.getFullTextSession(session);
                        fullTextSession.FlushMode = FlushMode.MANUAL;
                        fullTextSession.CacheMode = CacheMode.IGNORE;
                        transaction = fullTextSession.beginTransaction();
                        scrollableResults = fullTextSession.createCriteria(typeof(ProjectWBSTable)).add(Restrictions.gt("projectWBSId", new long?(l))).addOrder(Order.asc("projectWBSId")).setMaxResults(52002).setFetchSize(4000).scroll(ScrollMode.FORWARD_ONLY);
                    }
                    b++;
                }
                scrollableResults.close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.Write(exception.StackTrace);
                fullTextSession.flushToIndexes();
                if (fullTextSession.Open)
                {
                    fullTextSession.clear();
                }
                if (transaction.Active)
                {
                    transaction.rollback();
                }
                throw exception;
            }
            fullTextSession.flushToIndexes();
            if (fullTextSession.Open)
            {
                fullTextSession.clear();
            }
            if (transaction.Active)
            {
                transaction.commit();
            }
            if (!session.Open)
            {
                session = SessionFactory.openSession();
            }
            return session;
        }

        public virtual bool Indexing
        {
            get
            {
                return this.indexing;
            }
            set
            {
                this.indexing = value;
            }
        }


        public virtual string IndexStatus
        {
            get
            {
                return this.indexStatus;
            }
            set
            {
                this.indexStatus = value;
            }
        }


        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @PostConstruct public void postConstruct()
        public virtual void postConstruct()
        {
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
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @PreDestroy public void preDestroy()
        public virtual void preDestroy()
        {
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
        }
    }


    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\ces\CESIndex.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}