using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Projectspecvar
	{
		private ProjectContext projectContext;

		public Projectspecvar(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long ProjectspecvarCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Projectspecvar.Count();
		}

		public List<Models.DB.Project.Projectspecvar> GetAllProjectspecvar()
		{
			List<Models.DB.Project.Projectspecvar> Projectspecvar = new List<Models.DB.Project.Projectspecvar>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Projectspecvar = projectContext.Projectspecvar.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Projectspecvar;
		}
		public long Createprojectspecvar(List<Models.DB.Project.Projectspecvar> Projectspecvar)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Projectspecvar projectspecvar in Projectspecvar)
				{
					projectContext.Projectspecvar.Add(projectspecvar);
					projectContext.SaveChanges();
					returnid = projectspecvar.ProjectspecvarId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateprojectspecvar(long id, Models.DB.Project.Projectspecvar projectspecvar)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Projectspecvar.Update(projectspecvar);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteprojectspecvar(long projectspecvarId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Projectspecvar projectspecvar = projectContext.Projectspecvar.First(p => p.ProjectspecvarId == projectspecvarId);
				projectContext.Projectspecvar.Remove(projectspecvar);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
