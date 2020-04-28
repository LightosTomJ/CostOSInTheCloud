using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class AlcGroups
	{
		private LocalContext localContext;

		public AlcGroups(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long AlcGroupsCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.AlcGroups.Count();
		}

		public List<Models.DB.Local.AlcGroups> GetAllAlcGroups()
		{
			List<Models.DB.Local.AlcGroups> AlcGroups = new List<Models.DB.Local.AlcGroups>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				AlcGroups = localContext.AlcGroups.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AlcGroups;
		}
		public long CreatealcGroups(List<Models.DB.Local.AlcGroups> AlcGroups)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AlcGroups alcGroups in AlcGroups)
				{
					localContext.AlcGroups.Add(alcGroups);
					localContext.SaveChanges();
					returnid = alcGroups.AlcGroupsId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatealcGroups(long id, Models.DB.Local.AlcGroups alcGroups)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AlcGroups.Update(alcGroups);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletealcGroups(long alcGroupsId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AlcGroups alcGroups = localContext.AlcGroups.First(p => p.AlcGroupsId == alcGroupsId);
				localContext.AlcGroups.Remove(alcGroups);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
