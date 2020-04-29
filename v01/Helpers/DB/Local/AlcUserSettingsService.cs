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
	public class AlcUserSettingsService
	{
		private LocalContext localContext;

		public AlcUserSettingsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> AlcUserSettingsCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.AlcUserSettings.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.AlcUserSettings>> GetAllAlcUserSettings()
		{
			IList<Models.DB.Local.AlcUserSettings> AlcUserSettings = new List<Models.DB.Local.AlcUserSettings>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.AlcUserSettings> alcUserSettings = await localContext.AlcUserSettings.ToListAsync();
				return alcUserSettings;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<Guid> CreateAlcUserSettings(List<Models.DB.Local.AlcUserSettings> AlcUserSettings)
		{
			Guid returnid = Guid.Empty;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AlcUserSettings alcUserSettings in AlcUserSettings)
				{
					localContext.AlcUserSettings.Add(alcUserSettings);
					await localContext.SaveChangesAsync();
					returnid = alcUserSettings.SettingId;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAlcUserSettings(long id, Models.DB.Local.AlcUserSettings alcUserSettings)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AlcUserSettings.Update(alcUserSettings);
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
		public async Task<bool> DeleteAlcUserSettings(Guid alcUserSettingsId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AlcUserSettings alcUserSettings = localContext.AlcUserSettings.First(p => p.SettingId == alcUserSettingsId);
				localContext.AlcUserSettings.Remove(alcUserSettings);
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
