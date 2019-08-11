using System.Collections.Generic;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace Models.report
{

	using JRException = net.sf.jasperreports.engine.JRException;
	using JRRewindableDataSource = net.sf.jasperreports.engine.JRRewindableDataSource;

	public class ProjectIterateDataSource : ProjectDataSource, JRRewindableDataSource
	{
//JAVA TO C# CONVERTER WARNING: Java wildcard generics have no direct equivalent in .NET:
//ORIGINAL LINE: private java.util.Iterator<?> iterator;
		private IEnumerator<object> iterator;

		public ProjectIterateDataSource(ProjectQueryExecuter queryExecuter, bool useFieldDescription) : base(queryExecuter, useFieldDescription, false)
		{

			moveFirst();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public boolean next() throws net.sf.jasperreports.engine.JRException
		public override bool next()
		{
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			if (iterator != null && iterator.hasNext())
			{
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
				CurrentRowValue = iterator.next();
				return true;
			}

			return false;
		}

		public override void moveFirst()
		{
			iterator = queryExecuter.iterate();
		}
	}

}