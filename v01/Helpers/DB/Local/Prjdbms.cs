using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Prjdbms
	{
		private LocalContext localContext;

		public Prjdbms(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long PrjdbmsCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Prjdbms.Count();
		}

		public List<Models.DB.Local.Prjdbms> GetAllPrjdbms()
		{
			List<Models.DB.Local.Prjdbms> Prjdbms = new List<Models.DB.Local.Prjdbms>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Prjdbms = localContext.Prjdbms.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Prjdbms;
		}
		public long Createprjdbms(List<Models.DB.Local.Prjdbms> Prjdbms)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Prjdbms prjdbms in Prjdbms)
				{
					localContext.Prjdbms.Add(prjdbms);
					localContext.SaveChanges();
					returnid = prjdbms.PrjdbmsId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateprjdbms(long id, Models.DB.Local.Prjdbms prjdbms)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Prjdbms.Update(prjdbms);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteprjdbms(long prjdbmsId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Prjdbms prjdbms = localContext.Prjdbms.First(p => p.PrjdbmsId == prjdbmsId);
				localContext.Prjdbms.Remove(prjdbms);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
