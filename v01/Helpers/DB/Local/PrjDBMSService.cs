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
	public class PrjDBMSService
	{
		private LocalContext localContext;

		public PrjDBMSService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> PrjDBMSCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.PrjDBMS.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.PrjDBMS>> GetAllPrjDBMS()
		{
			IList<Models.DB.Local.PrjDBMS> PrjDBMS = new List<Models.DB.Local.PrjDBMS>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.PrjDBMS> prjDBMS = await localContext.PrjDBMS.ToListAsync();
				return prjDBMS;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreatePrjDBMS(List<Models.DB.Local.PrjDBMS> PrjDBMS)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.PrjDBMS prjDBMS in PrjDBMS)
				{
					localContext.PrjDBMS.Add(prjDBMS);
					await localContext.SaveChangesAsync();
					returnid = prjDBMS.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdatePrjDBMS(long id, Models.DB.Local.PrjDBMS prjDBMS)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.PrjDBMS.Update(prjDBMS);
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
		public async Task<bool> DeletePrjDBMS(long prjDBMSId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.PrjDBMS prjDBMS = localContext.PrjDBMS.First(p => p.Id == prjDBMSId);
				localContext.PrjDBMS.Remove(prjDBMS);
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
