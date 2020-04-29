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
	public class AlcSettingCodesService
	{
		private LocalContext localContext;

		public AlcSettingCodesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> AlcSettingCodesCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.AlcSettingCodes.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.AlcSettingCodes>> GetAllAlcSettingCodes()
		{
			IList<Models.DB.Local.AlcSettingCodes> AlcSettingCodes = new List<Models.DB.Local.AlcSettingCodes>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.AlcSettingCodes> alcSettingCodes = await localContext.AlcSettingCodes.ToListAsync();
				return alcSettingCodes;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<Guid> CreateAlcSettingCodes(List<Models.DB.Local.AlcSettingCodes> AlcSettingCodes)
		{
			Guid returnid = Guid.Empty;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AlcSettingCodes alcSettingCodes in AlcSettingCodes)
				{
					localContext.AlcSettingCodes.Add(alcSettingCodes);
					await localContext.SaveChangesAsync();
					returnid = alcSettingCodes.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAlcSettingCodes(long id, Models.DB.Local.AlcSettingCodes alcSettingCodes)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AlcSettingCodes.Update(alcSettingCodes);
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
		public async Task<bool> DeleteAlcSettingCodes(Guid alcSettingCodesId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AlcSettingCodes alcSettingCodes = localContext.AlcSettingCodes.First(p => p.Id == alcSettingCodesId);
				localContext.AlcSettingCodes.Remove(alcSettingCodes);
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
