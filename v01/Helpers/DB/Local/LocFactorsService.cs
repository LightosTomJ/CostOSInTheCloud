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
	public class LocFactorsService
	{
		private LocalContext localContext;

		public LocFactorsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> LocFactorCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.LocFactor.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.LocFactor>> GetAllLocFactors()
		{
			IList<Models.DB.Local.LocFactor> LocFactors = new List<Models.DB.Local.LocFactor>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.LocFactor> locFactors = await localContext.LocFactor.ToListAsync();
				return locFactors;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateLocFactor(List<Models.DB.Local.LocFactor> LocFactors)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.LocFactor locFactor in LocFactors)
				{
					localContext.LocFactor.Add(locFactor);
					await localContext.SaveChangesAsync();
					returnid = locFactor.Lfid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateLocFactor(long id, Models.DB.Local.LocFactor locFactor)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.LocFactor.Update(locFactor);
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
		public async Task<bool> DeleteLocFactor(long locFactorId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.LocFactor locFactor = localContext.LocFactor.First(p => p.Fid == locFactorId);
				localContext.LocFactor.Remove(locFactor);
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
