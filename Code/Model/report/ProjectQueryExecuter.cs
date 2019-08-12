using System;
using System.Collections.Generic;
using System.Numerics;

namespace Model.report
{

	using DefaultJasperReportsContext = net.sf.jasperreports.engine.DefaultJasperReportsContext;
	using JRDataSource = net.sf.jasperreports.engine.JRDataSource;
	using JRDataset = net.sf.jasperreports.engine.JRDataset;
	using JRException = net.sf.jasperreports.engine.JRException;
	using JRParameter = net.sf.jasperreports.engine.JRParameter;
	using JRRuntimeException = net.sf.jasperreports.engine.JRRuntimeException;
	using JRValueParameter = net.sf.jasperreports.engine.JRValueParameter;
	using JasperReportsContext = net.sf.jasperreports.engine.JasperReportsContext;
	using JRAbstractQueryExecuter = net.sf.jasperreports.engine.query.JRAbstractQueryExecuter;
	using JRJdbcQueryExecuterFactory = net.sf.jasperreports.engine.query.JRJdbcQueryExecuterFactory;
	using JRStringUtil = net.sf.jasperreports.engine.util.JRStringUtil;

	using Query = org.hibernate.Query;
	using ScrollMode = org.hibernate.ScrollMode;
	using ScrollableResults = org.hibernate.ScrollableResults;
	using Session = org.hibernate.Session;
	using BigDecimalType = org.hibernate.type.BigDecimalType;
	using BigIntegerType = org.hibernate.type.BigIntegerType;
	using BooleanType = org.hibernate.type.BooleanType;
	using ByteType = org.hibernate.type.ByteType;
	using CharacterType = org.hibernate.type.CharacterType;
	using DateType = org.hibernate.type.DateType;
	using DoubleType = org.hibernate.type.DoubleType;
	using FloatType = org.hibernate.type.FloatType;
	using IntegerType = org.hibernate.type.IntegerType;
	using LongType = org.hibernate.type.LongType;
	using ShortType = org.hibernate.type.ShortType;
	using StringType = org.hibernate.type.StringType;
	using TimeType = org.hibernate.type.TimeType;
	using TimestampType = org.hibernate.type.TimestampType;
	using Type = org.hibernate.type.Type;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("deprecation") public class ProjectQueryExecuter extends net.sf.jasperreports.engine.query.JRAbstractQueryExecuter
	public class ProjectQueryExecuter : JRAbstractQueryExecuter
	{
		protected internal const string CANONICAL_LANGUAGE = "CostosHQL";

		private static readonly IDictionary<Type, Type> hibernateTypeMap;

		static ProjectQueryExecuter()
		{
			hibernateTypeMap = new Dictionary<Type, Type>();
			hibernateTypeMap[typeof(Boolean)] = BooleanType.INSTANCE;
			hibernateTypeMap[typeof(Byte)] = ByteType.INSTANCE;
			hibernateTypeMap[typeof(Double)] = DoubleType.INSTANCE;
			hibernateTypeMap[typeof(Float)] = FloatType.INSTANCE;
			hibernateTypeMap[typeof(Integer)] = IntegerType.INSTANCE;
			hibernateTypeMap[typeof(Long)] = LongType.INSTANCE;
			hibernateTypeMap[typeof(Short)] = ShortType.INSTANCE;
			hibernateTypeMap[typeof(decimal)] = BigDecimalType.INSTANCE;
			hibernateTypeMap[typeof(BigInteger)] = BigIntegerType.INSTANCE;
			hibernateTypeMap[typeof(Character)] = CharacterType.INSTANCE;
			hibernateTypeMap[typeof(string)] = StringType.INSTANCE;
			hibernateTypeMap[typeof(DateTime)] = DateType.INSTANCE;
			hibernateTypeMap[typeof(java.sql.Timestamp)] = TimestampType.INSTANCE;
			hibernateTypeMap[typeof(java.sql.Time)] = TimeType.INSTANCE;
		}

		private readonly int? reportMaxCount;

		private Session session;
		private Query query;
		private bool queryRunning;
		private ScrollableResults scrollableResults;
		private bool isClearCache;
		private bool isSubquery = false;
		private bool mustCloseSession = false;
		/// 
		public ProjectQueryExecuter<T1>(JasperReportsContext jasperReportsContext, JRDataset dataset, IDictionary<T1> parameters) where T1 : net.sf.jasperreports.engine.JRValueParameter : base(jasperReportsContext, dataset, parameters)
		{
			//		QueryExecuterReport
			//		System.out.println("-------------");
			//		System.out.println("PARAMETERS: ");
			//		for ( String param : parameters.keySet() ) {
			//			System.out.println(param+" = "+parameters.get(param).getClass().getName());
			//		}

			session = (Session) getParameterValue(ProjectQueryExecuterFactory.PARAMETER_HIBERNATE_SESSION);


			reportMaxCount = (int?) getParameterValue(JRParameter.REPORT_MAX_COUNT);
			isClearCache = PropertiesUtil.getBooleanProperty(dataset, ProjectQueryExecuterFactory.PROPERTY_HIBERNATE_CLEAR_CACHE, false);

			if (session == null)
			{
				isSubquery = true;
				mustCloseSession = !ProjectDBUtil.currentProjectDBUtil().hasOpenedSession();
				session = ProjectDBUtil.currentProjectDBUtil().currentSession();
				throw new Exception("Session is null");
			}

			parseQuery();
		}


		protected internal override object getParameterValue(string parameterName)
		{
			try
			{
				return base.getParameterValue(parameterName);
			}
			catch (Exception)
			{
				return null;
			}
	//		Object value = super.getJasperReportsContext().getValue(parameterName);
	//		if ( value == null ) {
	//			try {
	//				value = super.getParameterValue(parameterName);		
	//				if ( value != null )
	//					super.getJasperReportsContext().setValue(parameterName, value);
	//			} catch (Exception ex) {
	//				ex.printStackTrace();
	//			}
	//		}
	//		return value;
		}


		/// @deprecated Replaced by <seealso cref="ProjectQueryExecuter(JasperReportsContext, JRDataset, System.Collections.IDictionary)"/>.  
		public ProjectQueryExecuter<T1>(JRDataset dataset, IDictionary<T1> parameters) where T1 : net.sf.jasperreports.engine.JRValueParameter : this(DefaultJasperReportsContext.Instance, dataset, parameters)
		{
		}

		protected internal override string CanonicalQueryLanguage
		{
			get
			{
				return CANONICAL_LANGUAGE;
			}
		}


		/// <summary>
		/// Creates an instance of <seealso cref="ProjectListDataSource ProjectListDataSource"/>,
		/// <seealso cref="ProjectIterateDataSource ProjectIterateDataSource"/> or
		/// <seealso cref="ProjectScrollDataSource ProjectScrollDataSource"/>, depending on the 
		/// </summary>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public net.sf.jasperreports.engine.JRDataSource createDatasource() throws net.sf.jasperreports.engine.JRException
		public virtual JRDataSource createDatasource()
		{
			JRDataSource datasource = null;
			string queryString = QueryString;

			if (session != null && !string.ReferenceEquals(queryString, null) && queryString.Trim().Length > 0)
			{
				createQuery(queryString);

				datasource = createResultDatasource();
			}

			if (mustCloseSession && isSubquery)
			{
				ProjectDBUtil.currentProjectDBUtil().closeSession();
			}

			return datasource;
		}

		/// <summary>
		/// Creates a data source out of the query result.
		/// </summary>
		/// <returns> the data source </returns>
		protected internal virtual JRDataSource createResultDatasource()
		{
			JRDataSource resDatasource;

			string runType = PropertiesUtil.getProperty(dataset, ProjectQueryExecuterFactory.PROPERTY_HIBERNATE_QUERY_RUN_TYPE);
			bool useFieldDescriptions = PropertiesUtil.getBooleanProperty(dataset, ProjectQueryExecuterFactory.PROPERTY_HIBERNATE_FIELD_MAPPING_DESCRIPTIONS, true);

			if (string.ReferenceEquals(runType, null) || runType.Equals(ProjectQueryExecuterFactory.VALUE_HIBERNATE_QUERY_RUN_TYPE_LIST))
			{
				try
				{
					int pageSize = PropertiesUtil.getIntegerProperty(dataset, ProjectQueryExecuterFactory.PROPERTY_HIBERNATE_QUERY_LIST_PAGE_SIZE, 0);

					resDatasource = new ProjectListDataSource(this, useFieldDescriptions, pageSize);
				}
				catch (System.FormatException e)
				{
					throw new JRRuntimeException("The " + ProjectQueryExecuterFactory.PROPERTY_HIBERNATE_QUERY_LIST_PAGE_SIZE + " property must be numerical.", e);
				}
			}
			else if (runType.Equals(ProjectQueryExecuterFactory.VALUE_HIBERNATE_QUERY_RUN_TYPE_ITERATE))
			{
				resDatasource = new ProjectIterateDataSource(this, useFieldDescriptions);
			}
			else if (runType.Equals(ProjectQueryExecuterFactory.VALUE_HIBERNATE_QUERY_RUN_TYPE_SCROLL))
			{
				resDatasource = new ProjectScrollDataSource(this, useFieldDescriptions);
			}
			else
			{
				throw new JRRuntimeException("Unknown value for the " + ProjectQueryExecuterFactory.PROPERTY_HIBERNATE_QUERY_RUN_TYPE + " property.  Possible values are " + ProjectQueryExecuterFactory.VALUE_HIBERNATE_QUERY_RUN_TYPE_LIST + ", " + ProjectQueryExecuterFactory.VALUE_HIBERNATE_QUERY_RUN_TYPE_ITERATE + " and " + ProjectQueryExecuterFactory.VALUE_HIBERNATE_QUERY_RUN_TYPE_SCROLL + ".");
			}

			return resDatasource;
		}


		/// <summary>
		/// Creates the Hibernate query object.
		/// <p/>
		/// If the value of the <seealso cref="ProjectQueryExecuterFactory.PARAMETER_HIBERNATE_FILTER_COLLECTION PARAMETER_HIBERNATE_FILTER_COLLECTION"/>
		/// is not null, then a filter query is created using the value of the parameter as the collection.
		/// </summary>
		/// <param name="queryString"> the query string </param>
		protected internal virtual void createQuery(string queryString)
		{
			lock (this)
			{
				//		if (log.isDebugEnabled())
				//		{
				//			log.debug("HQL query: " + queryString);
				//		}
        
				object filterCollection = getParameterValue(ProjectQueryExecuterFactory.PARAMETER_HIBERNATE_FILTER_COLLECTION);
				if (filterCollection == null)
				{
					query = session.createQuery(queryString);
				}
				else
				{
					query = session.createFilter(filterCollection, queryString);
				}
				query.ReadOnly = true;
        
				int fetchSize = PropertiesUtil.getIntegerProperty(dataset, JRJdbcQueryExecuterFactory.PROPERTY_JDBC_FETCH_SIZE, 0);
				if (fetchSize != 0)
				{
					query.FetchSize = fetchSize;
				}
        
				setParameters();
			}
		}

		/// <summary>
		/// Binds values for all the query parameters.
		/// </summary>
		protected internal virtual void setParameters()
		{
			IList<string> parameterNames = CollectedParameterNames;

			if (parameterNames.Count > 0)
			{
				ISet<string> namesSet = new HashSet<string>();

				for (IEnumerator<string> iter = parameterNames.GetEnumerator(); iter.MoveNext();)
				{
					string parameterName = iter.Current;
					if (namesSet.Add(parameterName))
					{
						JRValueParameter parameter = getValueParameter(parameterName);
						Parameter = parameter;
					}
				}
			}
		}


		/// <summary>
		/// Binds a parameter value to a query parameter.
		/// </summary>
		/// <param name="parameter"> the report parameter </param>
		protected internal virtual JRValueParameter Parameter
		{
			set
			{
				string hqlParamName = getHqlParameterName(value.Name);
				Type clazz = value.ValueClass;
				object parameterValue = value.Value;
    
				//		if (log.isDebugEnabled())
				//		{
				//			log.debug("Parameter " + hqlParamName + " of type " + clazz.getName() + ": " + parameterValue);
				//		}
    
				Type type = hibernateTypeMap[clazz];
    
				if (type != null)
				{
					query.setParameter(hqlParamName, parameterValue, type);
				}
				else if (clazz.IsAssignableFrom(typeof(System.Collections.ICollection)))
				{
	//JAVA TO C# CONVERTER WARNING: Java wildcard generics have no direct equivalent in .NET:
	//ORIGINAL LINE: query.setParameterList(hqlParamName, (java.util.Collection<?>) parameterValue);
					query.setParameterList(hqlParamName, (ICollection<object>) parameterValue);
				}
				else
				{
					if (session.SessionFactory.getClassMetadata(clazz) != null) //param type is a hibernate mapped entity
					{
						query.setEntity(hqlParamName, parameterValue);
					}
					else //let hibernate try to guess the type
					{
						query.setParameter(hqlParamName, parameterValue);
					}
				}
			}
		}


		/// <summary>
		/// Closes the scrollable result when <em>scroll</em> execution type is used.
		/// </summary>
		public virtual void close()
		{
			lock (this)
			{
				closeScrollableResults();
        
				query = null;
			}
		}


		/// <summary>
		/// Closes the scrollable results of the query.
		/// </summary>
		public virtual void closeScrollableResults()
		{
			if (scrollableResults != null)
			{
				try
				{
					scrollableResults.close();
				}
				finally
				{
					scrollableResults = null;
				}
			}
		}


//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized boolean cancelQuery() throws net.sf.jasperreports.engine.JRException
		public virtual bool cancelQuery()
		{
			lock (this)
			{
				if (queryRunning)
				{
					session.cancelQuery();
					return true;
				}
        
				return false;
			}
		}

		protected internal virtual string getParameterReplacement(string parameterName)
		{
			return ':' + getHqlParameterName(parameterName);
		}

		protected internal virtual string getHqlParameterName(string parameterName)
		{
			return '_' + JRStringUtil.getJavaIdentifier(parameterName);
		}


		/// <summary>
		/// Returns the return types of the HQL query.
		/// </summary>
		/// <returns> the return types of the HQL query </returns>
		public virtual Type[] ReturnTypes
		{
			get
			{
				return query.ReturnTypes;
			}
		}


		/// <summary>
		/// Returns the aliases of the HQL query.
		/// </summary>
		/// <returns> the aliases of the HQL query </returns>
		public virtual string[] ReturnAliases
		{
			get
			{
				return query.ReturnAliases;
			}
		}


		/// <summary>
		/// Returns the dataset for which the query executer has been created.
		/// </summary>
		/// <returns> the dataset for which the query executer has been created </returns>
		public virtual JRDataset Dataset
		{
			get
			{
				return dataset;
			}
		}


		/// <summary>
		/// Runs the query by calling <code>org.hibernate.Query.list()</code>.
		/// <p/>
		/// All the result rows are returned.
		/// </summary>
		/// <returns> the result of the query as a list </returns>
//JAVA TO C# CONVERTER WARNING: Java wildcard generics have no direct equivalent in .NET:
//ORIGINAL LINE: public java.util.List<?> list()
		public virtual IList<object> list()
		{
			setMaxCount();

			QueryRunning = true;
			try
			{
				return query.list();
			}
			finally
			{
				QueryRunning = false;
			}
		}

		protected internal virtual bool QueryRunning
		{
			set
			{
				lock (this)
				{
					this.queryRunning = value;
				}
			}
		}


		private void setMaxCount()
		{
			if (reportMaxCount != null)
			{
				query.MaxResults = reportMaxCount.Value;
			}
		}


		/// <summary>
		/// Returns a page of the query results by calling <code>org.hibernate.Query.iterate()</code>.
		/// </summary>
		/// <param name="firstIndex"> the index of the first row to return </param>
		/// <param name="resultCount"> the number of rows to return </param>
		/// <returns> result row list </returns>
//JAVA TO C# CONVERTER WARNING: Java wildcard generics have no direct equivalent in .NET:
//ORIGINAL LINE: public java.util.List<?> list(int firstIndex, int resultCount)
		public virtual IList<object> list(int firstIndex, int resultCount)
		{
			if (reportMaxCount != null && firstIndex + resultCount > reportMaxCount.Value)
			{
				resultCount = reportMaxCount.Value - firstIndex;
			}

			query.FirstResult = firstIndex;
			query.MaxResults = resultCount;
			if (isClearCache)
			{
				clearCache();
			}
			return query.list();
		}


		/// <summary>
		/// Runs the query by calling <code>org.hibernate.Query.iterate()</code>.
		/// </summary>
		/// <returns> query iterator </returns>
//JAVA TO C# CONVERTER WARNING: Java wildcard generics have no direct equivalent in .NET:
//ORIGINAL LINE: public java.util.Iterator<?> iterate()
		public virtual IEnumerator<object> iterate()
		{
			setMaxCount();

			QueryRunning = true;
			try
			{
				return query.iterate();
			}
			finally
			{
				QueryRunning = false;
			}
		}


		/// <summary>
		/// Runs the query by calling <code>org.hibernate.Query.scroll()</code>.
		/// </summary>
		/// <returns> scrollable results of the query </returns>
		public virtual ScrollableResults scroll()
		{
			setMaxCount();

			QueryRunning = true;
			try
			{
				scrollableResults = query.scroll(ScrollMode.FORWARD_ONLY);
			}
			finally
			{
				QueryRunning = false;
			}

			return scrollableResults;
		}

		public virtual void clearCache()
		{
			session.flush();
			session.clear();
		}
	}
}