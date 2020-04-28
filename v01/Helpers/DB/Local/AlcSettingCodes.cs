using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class AlcSettingCodes
	{
		private LocalContext localContext;

		public AlcSettingCodes(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long AlcSettingCodesCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.AlcSettingCodes.Count();
		}

		public List<Models.DB.Local.AlcSettingCodes> GetAllAlcSettingCodes()
		{
			List<Models.DB.Local.AlcSettingCodes> AlcSettingCodes = new List<Models.DB.Local.AlcSettingCodes>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				AlcSettingCodes = localContext.AlcSettingCodes.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AlcSettingCodes;
		}
		public long CreatealcSettingCodes(List<Models.DB.Local.AlcSettingCodes> AlcSettingCodes)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AlcSettingCodes alcSettingCodes in AlcSettingCodes)
				{
					localContext.AlcSettingCodes.Add(alcSettingCodes);
					localContext.SaveChanges();
					returnid = alcSettingCodes.AlcSettingCodesId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatealcSettingCodes(long id, Models.DB.Local.AlcSettingCodes alcSettingCodes)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AlcSettingCodes.Update(alcSettingCodes);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletealcSettingCodes(long alcSettingCodesId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AlcSettingCodes alcSettingCodes = localContext.AlcSettingCodes.First(p => p.AlcSettingCodesId == alcSettingCodesId);
				localContext.AlcSettingCodes.Remove(alcSettingCodes);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
