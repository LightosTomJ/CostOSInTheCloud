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
	public class LocProfsService
	{
		private LocalContext localContext;

		public LocProfsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> LocProfCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.LocProf.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.LocProf>> GetAllLocProfs()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.LocProf> locProfs = await localContext.LocProf.ToListAsync();
				return locProfs;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateLocProf(List<Models.DB.Local.LocProf> LocProfs)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.LocProf locProf in LocProfs)
				{
					localContext.LocProf.Add(locProf);
					await localContext.SaveChangesAsync();
					//TODO check that this is the correct key (should be primary)
					returnid = locProf.Functionid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateLocProf(Models.DB.Local.LocProf locProf)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.LocProf.Update(locProf);
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
		public async Task<bool> DeleteLocProf(long locProfId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				//TODO check that this is the correct key (should be primary)
				Models.DB.Local.LocProf locProf = localContext.LocProf.First(p => p.Functionid == locProfId);
				localContext.LocProf.Remove(locProf);
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
