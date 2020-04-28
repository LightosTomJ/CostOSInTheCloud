using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class AlcUl
	{
		private LocalContext localContext;

		public AlcUl(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long AlcUlCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.AlcUl.Count();
		}

		public List<Models.DB.Local.AlcUl> GetAllAlcUl()
		{
			List<Models.DB.Local.AlcUl> AlcUl = new List<Models.DB.Local.AlcUl>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				AlcUl = localContext.AlcUl.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AlcUl;
		}
		public long CreatealcUl(List<Models.DB.Local.AlcUl> AlcUl)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AlcUl alcUl in AlcUl)
				{
					localContext.AlcUl.Add(alcUl);
					localContext.SaveChanges();
					returnid = alcUl.AlcUlId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatealcUl(long id, Models.DB.Local.AlcUl alcUl)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AlcUl.Update(alcUl);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletealcUl(long alcUlId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AlcUl alcUl = localContext.AlcUl.First(p => p.AlcUlId == alcUlId);
				localContext.AlcUl.Remove(alcUl);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
