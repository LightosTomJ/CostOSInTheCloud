using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Projecttemplate
	{
		private ProjectContext projectContext;

		public Projecttemplate(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long ProjecttemplateCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Projecttemplate.Count();
		}

		public List<Models.DB.Project.Projecttemplate> GetAllProjecttemplate()
		{
			List<Models.DB.Project.Projecttemplate> Projecttemplate = new List<Models.DB.Project.Projecttemplate>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Projecttemplate = projectContext.Projecttemplate.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Projecttemplate;
		}
		public long Createprojecttemplate(List<Models.DB.Project.Projecttemplate> Projecttemplate)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Projecttemplate projecttemplate in Projecttemplate)
				{
					projectContext.Projecttemplate.Add(projecttemplate);
					projectContext.SaveChanges();
					returnid = projecttemplate.ProjecttemplateId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateprojecttemplate(long id, Models.DB.Project.Projecttemplate projecttemplate)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Projecttemplate.Update(projecttemplate);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteprojecttemplate(long projecttemplateId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Projecttemplate projecttemplate = projectContext.Projecttemplate.First(p => p.ProjecttemplateId == projecttemplateId);
				projectContext.Projecttemplate.Remove(projecttemplate);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
