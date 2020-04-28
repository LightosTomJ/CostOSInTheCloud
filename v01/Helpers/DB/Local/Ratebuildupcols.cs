using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Ratebuildupcols
	{
		private LocalContext localContext;

		public Ratebuildupcols(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long RatebuildupcolsCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Ratebuildupcols.Count();
		}

		public List<Models.DB.Local.Ratebuildupcols> GetAllRatebuildupcols()
		{
			List<Models.DB.Local.Ratebuildupcols> Ratebuildupcols = new List<Models.DB.Local.Ratebuildupcols>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Ratebuildupcols = localContext.Ratebuildupcols.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Ratebuildupcols;
		}
		public long Createratebuildupcols(List<Models.DB.Local.Ratebuildupcols> Ratebuildupcols)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Ratebuildupcols ratebuildupcols in Ratebuildupcols)
				{
					localContext.Ratebuildupcols.Add(ratebuildupcols);
					localContext.SaveChanges();
					returnid = ratebuildupcols.RatebuildupcolsId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateratebuildupcols(long id, Models.DB.Local.Ratebuildupcols ratebuildupcols)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Ratebuildupcols.Update(ratebuildupcols);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteratebuildupcols(long ratebuildupcolsId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Ratebuildupcols ratebuildupcols = localContext.Ratebuildupcols.First(p => p.RatebuildupcolsId == ratebuildupcolsId);
				localContext.Ratebuildupcols.Remove(ratebuildupcols);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
