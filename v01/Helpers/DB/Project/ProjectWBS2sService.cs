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
	public class ProjectWBS2sService
	{
		private ProjectContext projectContext;

		public ProjectWBS2sService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> ProjectWBS2Count()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.ProjectWBS2.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.ProjectWBS2>> GetAllProjectWBS2s()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.ProjectWBS2> projectWBS2s = await projectContext.ProjectWBS2.ToListAsync();
				return projectWBS2s;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateProjectWBS2(List<Models.DB.Project.ProjectWBS2> ProjectWBS2s)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.ProjectWBS2 projectWBS2 in ProjectWBS2s)
				{
					projectContext.ProjectWBS2.Add(projectWBS2);
					await projectContext.SaveChangesAsync();
					returnid = projectWBS2.Projectwbsid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateProjectWBS2(Models.DB.Project.ProjectWBS2 projectWBS2)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.ProjectWBS2.Update(projectWBS2);
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
		public async Task<bool> DeleteProjectWBS2(long projectWBS2Id)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.ProjectWBS2 projectWBS2 = projectContext.ProjectWBS2.First(p => p.Projectwbsid == projectWBS2Id);
				projectContext.ProjectWBS2.Remove(projectWBS2);
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
