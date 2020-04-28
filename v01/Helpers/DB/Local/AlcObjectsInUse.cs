using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class AlcObjectsInUse
	{
		private LocalContext localContext;

		public AlcObjectsInUse(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long AlcObjectsInUseCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.AlcObjectsInUse.Count();
		}

		public List<Models.DB.Local.AlcObjectsInUse> GetAllAlcObjectsInUse()
		{
			List<Models.DB.Local.AlcObjectsInUse> AlcObjectsInUse = new List<Models.DB.Local.AlcObjectsInUse>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				AlcObjectsInUse = localContext.AlcObjectsInUse.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AlcObjectsInUse;
		}
		public long CreatealcObjectsInUse(List<Models.DB.Local.AlcObjectsInUse> AlcObjectsInUse)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AlcObjectsInUse alcObjectsInUse in AlcObjectsInUse)
				{
					localContext.AlcObjectsInUse.Add(alcObjectsInUse);
					localContext.SaveChanges();
					returnid = alcObjectsInUse.AlcObjectsInUseId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatealcObjectsInUse(long id, Models.DB.Local.AlcObjectsInUse alcObjectsInUse)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AlcObjectsInUse.Update(alcObjectsInUse);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletealcObjectsInUse(long alcObjectsInUseId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AlcObjectsInUse alcObjectsInUse = localContext.AlcObjectsInUse.First(p => p.AlcObjectsInUseId == alcObjectsInUseId);
				localContext.AlcObjectsInUse.Remove(alcObjectsInUse);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
