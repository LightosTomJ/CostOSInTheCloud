using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcElemconnection
	{
		private LocalContext localContext;

		public BcElemconnection(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcElemconnectionCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcElemconnection.Count();
		}

		public List<Models.DB.Local.BcElemconnection> GetAllBcElemconnection()
		{
			List<Models.DB.Local.BcElemconnection> BcElemconnection = new List<Models.DB.Local.BcElemconnection>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcElemconnection = localContext.BcElemconnection.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcElemconnection;
		}
		public long CreatebcElemconnection(List<Models.DB.Local.BcElemconnection> BcElemconnection)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcElemconnection bcElemconnection in BcElemconnection)
				{
					localContext.BcElemconnection.Add(bcElemconnection);
					localContext.SaveChanges();
					returnid = bcElemconnection.BcElemconnectionId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcElemconnection(long id, Models.DB.Local.BcElemconnection bcElemconnection)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcElemconnection.Update(bcElemconnection);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcElemconnection(long bcElemconnectionId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcElemconnection bcElemconnection = localContext.BcElemconnection.First(p => p.BcElemconnectionId == bcElemconnectionId);
				localContext.BcElemconnection.Remove(bcElemconnection);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
