using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class AlcUserSettings
	{
		private LocalContext localContext;

		public AlcUserSettings(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long AlcUserSettingsCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.AlcUserSettings.Count();
		}

		public List<Models.DB.Local.AlcUserSettings> GetAllAlcUserSettings()
		{
			List<Models.DB.Local.AlcUserSettings> AlcUserSettings = new List<Models.DB.Local.AlcUserSettings>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				AlcUserSettings = localContext.AlcUserSettings.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AlcUserSettings;
		}
		public long CreatealcUserSettings(List<Models.DB.Local.AlcUserSettings> AlcUserSettings)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AlcUserSettings alcUserSettings in AlcUserSettings)
				{
					localContext.AlcUserSettings.Add(alcUserSettings);
					localContext.SaveChanges();
					returnid = alcUserSettings.AlcUserSettingsId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatealcUserSettings(long id, Models.DB.Local.AlcUserSettings alcUserSettings)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AlcUserSettings.Update(alcUserSettings);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletealcUserSettings(long alcUserSettingsId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AlcUserSettings alcUserSettings = localContext.AlcUserSettings.First(p => p.AlcUserSettingsId == alcUserSettingsId);
				localContext.AlcUserSettings.Remove(alcUserSettings);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
