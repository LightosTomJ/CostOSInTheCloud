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
	public class RateDistribsService
	{
		private ProjectContext projectContext;

		public RateDistribsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> RateDistribCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.RateDistrib.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.RateDistrib>> GetAllRateDistribs()
		{
			IList<Models.DB.Project.RateDistrib> RateDistribs = new List<Models.DB.Project.RateDistrib>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.RateDistrib> rateDistribs = await projectContext.RateDistrib.ToListAsync();
				return rateDistribs;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateRateDistrib(List<Models.DB.Project.RateDistrib> RateDistribs)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.RateDistrib rateDistrib in RateDistribs)
				{
					projectContext.RateDistrib.Add(rateDistrib);
					await projectContext.SaveChangesAsync();
					returnid = rateDistrib.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateRateDistrib(long id, Models.DB.Project.RateDistrib rateDistrib)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.RateDistrib.Update(rateDistrib);
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
		public async Task<bool> DeleteRateDistrib(long rateDistribId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.RateDistrib rateDistrib = projectContext.RateDistrib.First(p => p.Id == rateDistribId);
				projectContext.RateDistrib.Remove(rateDistrib);
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
