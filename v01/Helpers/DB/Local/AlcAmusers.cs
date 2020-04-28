using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class AlcAmusers
	{
		private LocalContext localContext;

		public AlcAmusers(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long AlcAmusersCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.AlcAmusers.Count();
		}

		public List<Models.DB.Local.AlcAmusers> GetAllAlcAmusers()
		{
			List<Models.DB.Local.AlcAmusers> AlcAmusers = new List<Models.DB.Local.AlcAmusers>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				AlcAmusers = localContext.AlcAmusers.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AlcAmusers;
		}
		public long CreatealcAmusers(List<Models.DB.Local.AlcAmusers> AlcAmusers)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AlcAmusers alcAmusers in AlcAmusers)
				{
					localContext.AlcAmusers.Add(alcAmusers);
					localContext.SaveChanges();
					returnid = alcAmusers.AlcAmusersId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatealcAmusers(long id, Models.DB.Local.AlcAmusers alcAmusers)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AlcAmusers.Update(alcAmusers);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletealcAmusers(long alcAmusersId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AlcAmusers alcAmusers = localContext.AlcAmusers.First(p => p.AlcAmusersId == alcAmusersId);
				localContext.AlcAmusers.Remove(alcAmusers);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
