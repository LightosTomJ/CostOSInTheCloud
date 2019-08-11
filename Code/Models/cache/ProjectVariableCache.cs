using System;
using System.Collections.Generic;

namespace Models.cache
{

	using Session = org.hibernate.Session;

	using ProjectVariableTable = nomitech.common.db.project.ProjectVariableTable;

	public class ProjectVariableCache
	{

		private ProjectDBUtil prjDbUtil;
		private Dictionary<string, object> projectVariableMap = new Dictionary<string, object>();

		public ProjectVariableCache(ProjectDBUtil prjDbUtil)
		{
			this.prjDbUtil = prjDbUtil;
			initCache();
		}

		public virtual Dictionary<string, object> ProjectVariableMap
		{
			get
			{
				return projectVariableMap;
			}
		}

		public virtual void initCache()
		{
			bool mustCloseSession = !prjDbUtil.hasOpenedSession();
			Session projectSession = prjDbUtil.currentSession();

			try
			{
				projectVariableMap.Clear();

				IList<ProjectVariableTable> projectVariables = new List<ProjectVariableTable>();
				bool useAllTemplateVariables = prjDbUtil.Properties.getBooleanProperty("project.use.all.projectvariables");
				if (useAllTemplateVariables)
				{
					projectVariables = projectSession.createQuery("from ProjectVariableTable as o where o.projectId = :projectId").setLong("projectId", prjDbUtil.ProjectUrlId).list();
				}
				else
				{
					projectVariables = projectSession.createQuery("from ProjectVariableTable as o where o.projectId = :projectId and projectTemplateTable.selected='1'").setLong("projectId", prjDbUtil.ProjectUrlId).list();
				}
				foreach (ProjectVariableTable projectVariableTable in projectVariables)
				{

					string key = projectVariableTable.Name;
					object value = null;

					if (projectVariableTable.Number.Value)
					{
						value = projectVariableTable.StoredValueNum;
					}
					else
					{
						value = projectVariableTable.StoredValue;
					}

					if (value == null)
					{
						continue;
					}

					projectVariableMap[key] = value;
				}

				if (mustCloseSession)
				{
					try
					{
						projectSession.close();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.ToString());
						Console.Write(e.StackTrace);
					}
				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);

				if (mustCloseSession)
				{
					try
					{
						projectSession.close();
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.ToString());
						Console.Write(ex.StackTrace);
					}
				}
			}
		}

	}

}