using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Ratebuildup
	{
		private LocalContext localContext;

		public Ratebuildup(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long RatebuildupCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Ratebuildup.Count();
		}

		public List<Models.DB.Local.Ratebuildup> GetAllRatebuildup()
		{
			List<Models.DB.Local.Ratebuildup> Ratebuildup = new List<Models.DB.Local.Ratebuildup>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Ratebuildup = localContext.Ratebuildup.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Ratebuildup;
		}
		public long Createratebuildup(List<Models.DB.Local.Ratebuildup> Ratebuildup)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Ratebuildup ratebuildup in Ratebuildup)
				{
					localContext.Ratebuildup.Add(ratebuildup);
					localContext.SaveChanges();
					returnid = ratebuildup.RatebuildupId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateratebuildup(long id, Models.DB.Local.Ratebuildup ratebuildup)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Ratebuildup.Update(ratebuildup);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteratebuildup(long ratebuildupId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Ratebuildup ratebuildup = localContext.Ratebuildup.First(p => p.RatebuildupId == ratebuildupId);
				localContext.Ratebuildup.Remove(ratebuildup);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
