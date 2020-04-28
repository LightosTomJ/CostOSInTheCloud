using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Queryresource
	{
		private ProjectContext projectContext;

		public Queryresource(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long QueryresourceCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Queryresource.Count();
		}

		public List<Models.DB.Project.Queryresource> GetAllQueryresource()
		{
			List<Models.DB.Project.Queryresource> Queryresource = new List<Models.DB.Project.Queryresource>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Queryresource = projectContext.Queryresource.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Queryresource;
		}
		public long Createqueryresource(List<Models.DB.Project.Queryresource> Queryresource)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Queryresource queryresource in Queryresource)
				{
					projectContext.Queryresource.Add(queryresource);
					projectContext.SaveChanges();
					returnid = queryresource.QueryresourceId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatequeryresource(long id, Models.DB.Project.Queryresource queryresource)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Queryresource.Update(queryresource);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletequeryresource(long queryresourceId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Queryresource queryresource = projectContext.Queryresource.First(p => p.QueryresourceId == queryresourceId);
				projectContext.Queryresource.Remove(queryresource);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
