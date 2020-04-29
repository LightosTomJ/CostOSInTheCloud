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
	public class ProjectWBSService
	{
		private ProjectContext projectContext;

		public ProjectWBSService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> ProjectWBSCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.ProjectWBS.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.ProjectWBS>> GetAllProjectWBS()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.ProjectWBS> projectWBS = await projectContext.ProjectWBS.ToListAsync();
				return projectWBS;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateProjectWBS(List<Models.DB.Project.ProjectWBS> ProjectWBS)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.ProjectWBS projectWBS in ProjectWBS)
				{
					projectContext.ProjectWBS.Add(projectWBS);
					await projectContext.SaveChangesAsync();
					returnid = projectWBS.Projectwbsid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateProjectWBS(Models.DB.Project.ProjectWBS projectWBS)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.ProjectWBS.Update(projectWBS);
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
		public async Task<bool> DeleteProjectWBS(long projectWBSId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.ProjectWBS projectWBS = projectContext.ProjectWBS.First(p => p.Projectwbsid == projectWBSId);
				projectContext.ProjectWBS.Remove(projectWBS);
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
