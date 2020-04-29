using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class RateBuildUpsService
	{
		private LocalContext localContext;

		public RateBuildUpsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> RateBuildUpCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.RateBuildUp.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.RateBuildUp>> GetAllRateBuildUps()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.RateBuildUp> rateBuildUps = await localContext.RateBuildUp.ToListAsync();
				return rateBuildUps;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateRateBuildUp(List<Models.DB.Local.RateBuildUp> RateBuildUps)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.RateBuildUp rateBuildUp in RateBuildUps)
				{
					localContext.RateBuildUp.Add(rateBuildUp);
					await localContext.SaveChangesAsync();
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

		public async Task<bool> UpdateRateBuildUp(Models.DB.Local.RateBuildUp rateBuildUp)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.RateBuildUp.Update(rateBuildUp);
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
		public async Task<bool> DeleteRateBuildUp(long rateBuildUpId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.RateBuildUp rateBuildUp = localContext.RateBuildUp.First(p => p.Id == rateBuildUpId);
				localContext.RateBuildUp.Remove(rateBuildUp);
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
