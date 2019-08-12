using System.Collections.Generic;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace Model.report
{

	using JRRewindableDataSource = net.sf.jasperreports.engine.JRRewindableDataSource;

	/// <summary>
	/// Hibernate data source that uses <code>org.hibernate.Query.list()</code>.
	/// <p/>
	/// The query result can be paginated by not retrieving all the rows at once.
	/// 
	/// @author Lucian Chirita (lucianc@users.sourceforge.net)
	/// @version $Id: ProjectListDataSource.java 5180 2012-03-29 13:23:12Z teodord $ </summary>
	/// <seealso cref= net.sf.jasperreports.engine.query.ProjectQueryExecuterFactory#PROPERTY_HIBERNATE_QUERY_LIST_PAGE_SIZE </seealso>
	public class ProjectListDataSource : ProjectDataSource, JRRewindableDataSource
	{
		private readonly int pageSize;
		private int pageCount;
		private bool nextPage;
//JAVA TO C# CONVERTER WARNING: Java wildcard generics have no direct equivalent in .NET:
//ORIGINAL LINE: private java.util.List<?> returnValues;
		private IList<object> returnValues;
//JAVA TO C# CONVERTER WARNING: Java wildcard generics have no direct equivalent in .NET:
//ORIGINAL LINE: private java.util.Iterator<?> iterator;
		private IEnumerator<object> iterator;

		public ProjectListDataSource(ProjectQueryExecuter queryExecuter, bool useFieldDescription, int pageSize) : base(queryExecuter, useFieldDescription, false)
		{

			this.pageSize = pageSize;

			pageCount = 0;
			fetchPage();
		}

		protected internal virtual void fetchPage()
		{
			if (pageSize <= 0)
			{
				returnValues = queryExecuter.list();
				nextPage = false;
			}
			else
			{
				returnValues = queryExecuter.list(pageCount * pageSize, pageSize);
				nextPage = returnValues.Count == pageSize;
			}

			++pageCount;

			initIterator();
		}

		public virtual bool next()
		{
			if (iterator == null)
			{
				return false;
			}

//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			bool hasNext = iterator.hasNext();
			if (!hasNext && nextPage)
			{
				fetchPage();
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
				hasNext = iterator != null && iterator.hasNext();
			}

			if (hasNext)
			{
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
				CurrentRowValue = iterator.next();
			}

			return hasNext;
		}

		public virtual void moveFirst()
		{
			if (pageCount == 1)
			{
				initIterator();
			}
			else
			{
				pageCount = 0;
				fetchPage();
			}
		}

		private void initIterator()
		{
			iterator = returnValues == null ? null : returnValues.GetEnumerator();
		}
	}
}