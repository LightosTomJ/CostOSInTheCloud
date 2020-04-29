using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class ProjectspecvarsService
	{
		private ProjectContext projectContext;

		public ProjectspecvarsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> ProjectspecvarCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Projectspecvar.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.ProjectSpecVar>> GetAllProjectspecvars()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.ProjectSpecVar> projectspecvars = await projectContext.Projectspecvar.ToListAsync();
				return projectspecvars;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateProjectspecvar(List<Models.DB.Project.ProjectSpecVar> Projectspecvars)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.ProjectSpecVar projectspecvar in Projectspecvars)
				{
					projectContext.Projectspecvar.Add(projectspecvar);
					await projectContext.SaveChangesAsync();
					returnid = projectspecvar.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateProjectspecvar(Models.DB.Project.ProjectSpecVar projectspecvar)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Projectspecvar.Update(projectspecvar);
				await projectContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
		public async Task<bool> DeleteProjectspecvar(long projectspecvarId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.ProjectSpecVar projectspecvar = projectContext.Projectspecvar.First(p => p.Id == projectspecvarId);
				projectContext.Projectspecvar.Remove(projectspecvar);
				await projectContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
	}
}
