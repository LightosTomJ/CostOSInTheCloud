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
	public class RateBuildUpColsService
	{
		private ProjectContext projectContext;

		public RateBuildUpColsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> RateBuildUpColsCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.RateBuildUpCols.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.RateBuildUpCols>> GetAllRateBuildUpCols()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.RateBuildUpCols> rateBuildUpcols = await projectContext.RateBuildUpCols.ToListAsync();
				return rateBuildUpcols;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateRateBuildUpCols(List<Models.DB.Project.RateBuildUpCols> RateBuildUpCols)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.RateBuildUpCols rateBuildUpcols in RateBuildUpCols)
				{
					projectContext.RateBuildUpCols.Add(rateBuildUpcols);
					await projectContext.SaveChangesAsync();
					returnid = rateBuildUpcols.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateRateBuildUpCols(Models.DB.Project.RateBuildUpCols rateBuildUpcols)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.RateBuildUpCols.Update(rateBuildUpcols);
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
		public async Task<bool> DeleteRateBuildUpCols(long rateBuildUpcolsId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.RateBuildUpCols rateBuildUpcols = projectContext.RateBuildUpCols.First(p => p.Id == rateBuildUpcolsId);
				projectContext.RateBuildUpCols.Remove(rateBuildUpcols);
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
