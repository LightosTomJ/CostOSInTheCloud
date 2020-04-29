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
	public class RateBuildUpsService
	{
		private ProjectContext projectContext;

		public RateBuildUpsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> RateBuildUpCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.RateBuildUp.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.RateBuildUp>> GetAllRateBuildUps()
		{
			IList<Models.DB.Project.RateBuildUp> RateBuildUps = new List<Models.DB.Project.RateBuildUp>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.RateBuildUp> rateBuildUps = await projectContext.RateBuildUp.ToListAsync();
				return rateBuildUps;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateRateBuildUp(List<Models.DB.Project.RateBuildUp> RateBuildUps)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.RateBuildUp rateBuildUp in RateBuildUps)
				{
					projectContext.RateBuildUp.Add(rateBuildUp);
					await projectContext.SaveChangesAsync();
					returnid = rateBuildUp.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateRateBuildUp(long id, Models.DB.Project.RateBuildUp rateBuildUp)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.RateBuildUp.Update(rateBuildUp);
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
		public async Task<bool> DeleteRateBuildUp(long rateBuildUpId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.RateBuildUp rateBuildUp = projectContext.RateBuildUp.First(p => p.Id == rateBuildUpId);
				projectContext.RateBuildUp.Remove(rateBuildUp);
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
