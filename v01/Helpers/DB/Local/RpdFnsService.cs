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
	public class RpdFnsService
	{
		private LocalContext localContext;

		public RpdFnsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> RpdFnCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.RpdFn.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.RpdFn>> GetAllRpdFns()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.RpdFn> rpdFns = await localContext.RpdFn.ToListAsync();
				return rpdFns;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateRpdFn(List<Models.DB.Local.RpdFn> RpdFns)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.RpdFn rpdFn in RpdFns)
				{
					localContext.RpdFn.Add(rpdFn);
					await localContext.SaveChangesAsync();
					returnid = rpdFn.Rpdfnid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateRpdFn(Models.DB.Local.RpdFn rpdFn)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.RpdFn.Update(rpdFn);
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
		public async Task<bool> DeleteRpdFn(long rpdFnId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.RpdFn rpdFn = localContext.RpdFn.First(p => p.Rpdfnid == rpdFnId);
				localContext.RpdFn.Remove(rpdFn);
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
