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
	public class GekcodesService
	{
		private LocalContext localContext;

		public GekcodesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> GekcodeCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Gekcode.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Gekcode>> GetAllGekcodes()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Gekcode> gekcodes = await localContext.Gekcode.ToListAsync();
				return gekcodes;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateGekcode(List<Models.DB.Local.Gekcode> Gekcodes)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Gekcode gekcode in Gekcodes)
				{
					localContext.Gekcode.Add(gekcode);
					await localContext.SaveChangesAsync();
					returnid = gekcode.Gekcodeid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateGekcode(Models.DB.Local.Gekcode gekcode)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Gekcode.Update(gekcode);
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
		public async Task<bool> DeleteGekcode(long gekcodeId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Gekcode gekcode = localContext.Gekcode.First(p => p.Gekcodeid == gekcodeId);
				localContext.Gekcode.Remove(gekcode);
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
