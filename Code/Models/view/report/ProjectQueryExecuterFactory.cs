namespace Models.report
{
    public class ProjectQueryExecuterFactory
    {
        /// <summary>
        /// HQL query language.
        /// </summary>
        public const string QUERY_LANGUAGE_HQL = "CostosHQL";

        /// <summary>
        /// Built-in parameter holding the value of the Hibernate session to be used for creating the query.
        /// </summary>
        public const string PARAMETER_HIBERNATE_SESSION = "HIBERNATE_SESSION";

        /// <summary>
        /// Built-in parameter used for collection filter queries.
        /// <p/>
        /// The value of this parameter will be used as the collection to filter using the query.
        /// </summary>
        public const string PARAMETER_HIBERNATE_FILTER_COLLECTION = "HIBERNATE_FILTER_COLLECTION";

        private static readonly object[] HIBERNATE_BUILTIN_PARAMETERS = new object[] { PARAMETER_HIBERNATE_SESSION, "org.hibernate.Session", PARAMETER_HIBERNATE_FILTER_COLLECTION, "java.lang.Object" };

        /// <summary>
        /// Property specifying the query execution type.
        /// <p/>
        /// Possible values are:
        /// <ul>
        /// 	<li><em>list</em> (default) - the query will be run by calling <code>org.hibernate.Query.list()</code></li>
        /// 	<li><em>iterate</em> - the query will be run by calling <code>org.hibernate.Query.iterate()</code></li>
        /// 	<li><em>scroll</em> - the query will be run by calling <code>org.hibernate.Query.scroll()</code></li>
        /// </ul>
        /// </summary>
        //public static readonly string PROPERTY_HIBERNATE_QUERY_RUN_TYPE = JRPropertiesUtil.PROPERTY_PREFIX + "hql.query.run.type";

        /// <summary>
        /// Property specifying the number of result rows to be retrieved at once when the execution type is <em>list</em>.
        /// <p/>
        /// Result pagination is implemented by <code>org.hibernate.Query.setFirstResult()</code> and <code>org.hibernate.Query.setMaxResults()</code>.
        /// <p/>
        /// By default, all the rows are retrieved (no result pagination is performed).
        /// </summary>
        //public static readonly string PROPERTY_HIBERNATE_QUERY_LIST_PAGE_SIZE = JRPropertiesUtil.PROPERTY_PREFIX + "hql.query.list.page.size";

        /// <summary>
        /// Property specifying whether hibernate session cache should be cleared between two consecutive fetches when using pagination.
        /// <p/>
        /// By default, the cache cleanup is not performed.
        /// <p/> </summary>
        /// <seealso cref= net.sf.jasperreports.engine.query.ProjectQueryExecuterFactory#PROPERTY_HIBERNATE_QUERY_LIST_PAGE_SIZE </seealso>
        //public static readonly string PROPERTY_HIBERNATE_CLEAR_CACHE = JRPropertiesUtil.PROPERTY_PREFIX + "hql.clear.cache";

        /// <summary>
        /// Property specifying whether field descriptions should be used to determine the mapping between the fields
        /// and the query return values.
        /// </summary>
        //public static readonly string PROPERTY_HIBERNATE_FIELD_MAPPING_DESCRIPTIONS = JRPropertiesUtil.PROPERTY_PREFIX + "hql.field.mapping.descriptions";

        /// <summary>
        /// Value of the <seealso cref="PROPERTY_HIBERNATE_QUERY_RUN_TYPE PROPERTY_HIBERNATE_QUERY_RUN_TYPE"/> property
        /// corresponding to <em>list</em> execution type.
        /// </summary>
        //public const string VALUE_HIBERNATE_QUERY_RUN_TYPE_LIST = "list";

        /// <summary>
        /// Value of the <seealso cref="PROPERTY_HIBERNATE_QUERY_RUN_TYPE PROPERTY_HIBERNATE_QUERY_RUN_TYPE"/> property
        /// corresponding to <em>iterate</em> execution type.
        /// </summary>
        public const string VALUE_HIBERNATE_QUERY_RUN_TYPE_ITERATE = "iterate";

        /// <summary>
        /// Value of the <seealso cref="PROPERTY_HIBERNATE_QUERY_RUN_TYPE PROPERTY_HIBERNATE_QUERY_RUN_TYPE"/> property
        /// corresponding to <em>scroll</em> execution type.
        /// </summary>
        public const string VALUE_HIBERNATE_QUERY_RUN_TYPE_SCROLL = "scroll";

        public ProjectQueryExecuterFactory()
        { }
    }
}