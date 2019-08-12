/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace Model.report
{
	using JRException = net.sf.jasperreports.engine.JRException;
	using JRRewindableDataSource = net.sf.jasperreports.engine.JRRewindableDataSource;

	using ScrollableResults = org.hibernate.ScrollableResults;

	/// <summary>
	/// Hibernate data source that uses <code>org.hibernate.Query.scroll()</code>.
	/// 
	/// @author Lucian Chirita (lucianc@users.sourceforge.net)
	/// @version $Id: JRHibernateScrollDataSource.java 5180 2012-03-29 13:23:12Z teodord $
	/// </summary>
	public class ProjectScrollDataSource : ProjectDataSource, JRRewindableDataSource
	{
		private ScrollableResults scrollableResults;

		public ProjectScrollDataSource(ProjectQueryExecuter queryExecuter, bool useFieldDescription) : base(queryExecuter, useFieldDescription, true)
		{

			scrollableResults = queryExecuter.scroll();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public boolean next() throws net.sf.jasperreports.engine.JRException
		public override bool next()
		{
			if (scrollableResults != null && scrollableResults.next())
			{
				CurrentRowValue = scrollableResults.get();
				return true;
			}

			return false;
		}

		public override void moveFirst()
		{
			queryExecuter.closeScrollableResults();
			scrollableResults = queryExecuter.scroll();
		}
	}
}