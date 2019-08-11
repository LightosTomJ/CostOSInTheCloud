using System.Collections.Generic;

namespace Models.report
{

	using JRDataset = net.sf.jasperreports.engine.JRDataset;
	using JRException = net.sf.jasperreports.engine.JRException;
	using JRPropertiesUtil = net.sf.jasperreports.engine.JRPropertiesUtil;
	using JRValueParameter = net.sf.jasperreports.engine.JRValueParameter;
	using JasperReportsContext = net.sf.jasperreports.engine.JasperReportsContext;
	using AbstractQueryExecuterFactory = net.sf.jasperreports.engine.query.AbstractQueryExecuterFactory;
	using JRQueryExecuter = net.sf.jasperreports.engine.query.JRQueryExecuter;

	/// <summary>
	/// Query executer factory for HQL queries that uses Hibernate 3.
	/// <p/>
	/// The factory creates <seealso cref="net.sf.jasperreports.engine.query.ProjectQueryExecuter ProjectQueryExecuter"/>
	/// query executers. 
	/// 
	/// @author Lucian Chirita (lucianc@users.sourceforge.net)
	/// @version $Id: ProjectQueryExecuterFactory.java 5305 2012-04-26 15:17:33Z teodord $
	/// </summary>
	public class ProjectQueryExecuterFactory : AbstractQueryExecuterFactory
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

		private static readonly object[] HIBERNATE_BUILTIN_PARAMETERS = new object[] {PARAMETER_HIBERNATE_SESSION, "org.hibernate.Session", PARAMETER_HIBERNATE_FILTER_COLLECTION, "java.lang.Object"};

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
		public static readonly string PROPERTY_HIBERNATE_QUERY_RUN_TYPE = JRPropertiesUtil.PROPERTY_PREFIX + "hql.query.run.type";

		/// <summary>
		/// Property specifying the number of result rows to be retrieved at once when the execution type is <em>list</em>.
		/// <p/>
		/// Result pagination is implemented by <code>org.hibernate.Query.setFirstResult()</code> and <code>org.hibernate.Query.setMaxResults()</code>.
		/// <p/>
		/// By default, all the rows are retrieved (no result pagination is performed).
		/// </summary>
		public static readonly string PROPERTY_HIBERNATE_QUERY_LIST_PAGE_SIZE = JRPropertiesUtil.PROPERTY_PREFIX + "hql.query.list.page.size";

		/// <summary>
		/// Property specifying whether hibernate session cache should be cleared between two consecutive fetches when using pagination.
		/// <p/>
		/// By default, the cache cleanup is not performed.
		/// <p/> </summary>
		/// <seealso cref= net.sf.jasperreports.engine.query.ProjectQueryExecuterFactory#PROPERTY_HIBERNATE_QUERY_LIST_PAGE_SIZE </seealso>
		public static readonly string PROPERTY_HIBERNATE_CLEAR_CACHE = JRPropertiesUtil.PROPERTY_PREFIX + "hql.clear.cache";

		/// <summary>
		/// Property specifying whether field descriptions should be used to determine the mapping between the fields
		/// and the query return values.
		/// </summary>
		public static readonly string PROPERTY_HIBERNATE_FIELD_MAPPING_DESCRIPTIONS = JRPropertiesUtil.PROPERTY_PREFIX + "hql.field.mapping.descriptions";

		/// <summary>
		/// Value of the <seealso cref="PROPERTY_HIBERNATE_QUERY_RUN_TYPE PROPERTY_HIBERNATE_QUERY_RUN_TYPE"/> property
		/// corresponding to <em>list</em> execution type.
		/// </summary>
		public const string VALUE_HIBERNATE_QUERY_RUN_TYPE_LIST = "list";

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


		/// <summary>
		/// Returns an array containing the <seealso cref="PARAMETER_HIBERNATE_SESSION PARAMETER_HIBERNATE_SESSION"/> and
		/// <seealso cref="PARAMETER_HIBERNATE_FILTER_COLLECTION PARAMETER_HIBERNATE_FILTER_COLLECTION"/> parameters.
		/// </summary>
		public virtual object[] BuiltinParameters
		{
			get
			{
				return HIBERNATE_BUILTIN_PARAMETERS;
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public net.sf.jasperreports.engine.query.JRQueryExecuter createQueryExecuter(net.sf.jasperreports.engine.JasperReportsContext jasperReportsContext, net.sf.jasperreports.engine.JRDataset dataset, java.util.Map<String, ? extends net.sf.jasperreports.engine.JRValueParameter> parameters) throws net.sf.jasperreports.engine.JRException
		public virtual JRQueryExecuter createQueryExecuter<T1>(JasperReportsContext jasperReportsContext, JRDataset dataset, IDictionary<T1> parameters) where T1 : net.sf.jasperreports.engine.JRValueParameter
		{
	//		net.sf.jasperreports.engine.fill.JRFillParameter a;
	//		a = new net.sf.jasperreports.engine.fill.JRFillParamete
	//		if ( !parameters.containsKey(PARAMETER_HIBERNATE_SESSION) ) {
	//			parameters.put(PARAMETER_HIBERNATE_SESSION, new net.sf.jasperreports.engine.fill.JRFillParameter( ProjectDBUtil.currentProjectDBUtil().currentSession());
	//		}
	//		Map<String,String> props = jasperReportsContext.getProperties();
	//		
	//		System.out.println("FACTORY STAAAAART");
	//		for ( String key : props.keySet() ) {
	//			System.out.println(key+" = "+props.get(key));
	//		}
			//System.out.println("session is: "+jasperReportsContext.getValue(PARAMETER_HIBERNATE_SESSION));
			return new ProjectQueryExecuter(jasperReportsContext, dataset, parameters);
		}

		/// <summary>
		/// Returns <code>true</code> for all parameter types.
		/// </summary>
		public virtual bool supportsQueryParameterType(string className)
		{
			return true;
		}
	}

}