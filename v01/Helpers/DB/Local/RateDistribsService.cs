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
	public class RateDistribsService
	{
		private LocalContext localContext;

		public RateDistribsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> RateDistribCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.RateDistrib.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.RateDistrib>> GetAllRateDistribs()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.RateDistrib> rateDistribs = await localContext.RateDistrib.ToListAsync();
				return rateDistribs;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateRateDistrib(List<Models.DB.Local.RateDistrib> RateDistribs)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.RateDistrib rateDistrib in RateDistribs)
				{
					localContext.RateDistrib.Add(rateDistrib);
					await localContext.SaveChangesAsync();
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

		public async Task<bool> UpdateRateDistrib(Models.DB.Local.RateDistrib rateDistrib)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.RateDistrib.Update(rateDistrib);
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
		public async Task<bool> DeleteRateDistrib(long rateDistribId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.RateDistrib rateDistrib = localContext.RateDistrib.First(p => p.Id == rateDistribId);
				localContext.RateDistrib.Remove(rateDistrib);
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
