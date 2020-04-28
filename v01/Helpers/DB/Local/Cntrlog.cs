using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Cntrlog
	{
		private LocalContext localContext;

		public Cntrlog(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long CntrlogCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Cntrlog.Count();
		}

		public List<Models.DB.Local.Cntrlog> GetAllCntrlog()
		{
			List<Models.DB.Local.Cntrlog> Cntrlog = new List<Models.DB.Local.Cntrlog>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Cntrlog = localContext.Cntrlog.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Cntrlog;
		}
		public long Createcntrlog(List<Models.DB.Local.Cntrlog> Cntrlog)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Cntrlog cntrlog in Cntrlog)
				{
					localContext.Cntrlog.Add(cntrlog);
					localContext.SaveChanges();
					returnid = cntrlog.CntrlogId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatecntrlog(long id, Models.DB.Local.Cntrlog cntrlog)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Cntrlog.Update(cntrlog);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletecntrlog(long cntrlogId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Cntrlog cntrlog = localContext.Cntrlog.First(p => p.CntrlogId == cntrlogId);
				localContext.Cntrlog.Remove(cntrlog);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
