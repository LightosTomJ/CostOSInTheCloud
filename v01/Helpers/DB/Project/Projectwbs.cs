using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Projectwbs
	{
		private ProjectContext projectContext;

		public Projectwbs(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long ProjectwbsCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Projectwbs.Count();
		}

		public List<Models.DB.Project.Projectwbs> GetAllProjectwbs()
		{
			List<Models.DB.Project.Projectwbs> Projectwbs = new List<Models.DB.Project.Projectwbs>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Projectwbs = projectContext.Projectwbs.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Projectwbs;
		}
		public long Createprojectwbs(List<Models.DB.Project.Projectwbs> Projectwbs)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Projectwbs projectwbs in Projectwbs)
				{
					projectContext.Projectwbs.Add(projectwbs);
					projectContext.SaveChanges();
					returnid = projectwbs.ProjectwbsId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateprojectwbs(long id, Models.DB.Project.Projectwbs projectwbs)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Projectwbs.Update(projectwbs);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteprojectwbs(long projectwbsId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Projectwbs projectwbs = projectContext.Projectwbs.First(p => p.ProjectwbsId == projectwbsId);
				projectContext.Projectwbs.Remove(projectwbs);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
