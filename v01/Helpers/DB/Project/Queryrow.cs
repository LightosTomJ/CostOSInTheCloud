using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Queryrow
	{
		private ProjectContext projectContext;

		public Queryrow(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long QueryrowCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Queryrow.Count();
		}

		public List<Models.DB.Project.Queryrow> GetAllQueryrow()
		{
			List<Models.DB.Project.Queryrow> Queryrow = new List<Models.DB.Project.Queryrow>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Queryrow = projectContext.Queryrow.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Queryrow;
		}
		public long Createqueryrow(List<Models.DB.Project.Queryrow> Queryrow)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Queryrow queryrow in Queryrow)
				{
					projectContext.Queryrow.Add(queryrow);
					projectContext.SaveChanges();
					returnid = queryrow.QueryrowId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatequeryrow(long id, Models.DB.Project.Queryrow queryrow)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Queryrow.Update(queryrow);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletequeryrow(long queryrowId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Queryrow queryrow = projectContext.Queryrow.First(p => p.QueryrowId == queryrowId);
				projectContext.Queryrow.Remove(queryrow);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
