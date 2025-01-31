using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
    public class ProjectInfoService
	{
		private LocalContext localContext;

		public ProjectInfoService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> ProjectInfoCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.ProjectInfo.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<ProjectInfo>> GetAllProjectInfoAsync()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<ProjectInfo> projectInfos = await localContext.ProjectInfo.ToListAsync();
				return projectInfos;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}

		public async Task<IList<ProjectInfo>> GetAllProjectInfoByIdAsync(int projectInfoId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<ProjectInfo> projectInfos = await localContext.ProjectInfo
					.Where(p => p.Projectinfoid == projectInfoId)
					.ToListAsync();
				return projectInfos;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}

		public async Task<long> CreateProjectInfo(List<ProjectInfo> ProjectInfos)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.ProjectInfo projectInfo in ProjectInfos)
				{
					localContext.ProjectInfo.Add(projectInfo);
					await localContext.SaveChangesAsync();
					returnid = projectInfo.Projectinfoid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateProjectInfo(ProjectInfo projectInfo)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.ProjectInfo.Update(projectInfo);
				await localContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}

		public async Task<bool> DeleteProjectInfo(long projectInfoId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.ProjectInfo projectInfo = localContext.ProjectInfo.First(p => p.Projectinfoid == projectInfoId);
				localContext.ProjectInfo.Remove(projectInfo);
				await localContext.SaveChangesAsync();
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
