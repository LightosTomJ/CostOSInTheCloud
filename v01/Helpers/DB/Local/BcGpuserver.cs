using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcGpuserver
	{
		private LocalContext localContext;

		public BcGpuserver(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcGpuserverCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcGpuserver.Count();
		}

		public List<Models.DB.Local.BcGpuserver> GetAllBcGpuserver()
		{
			List<Models.DB.Local.BcGpuserver> BcGpuserver = new List<Models.DB.Local.BcGpuserver>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcGpuserver = localContext.BcGpuserver.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcGpuserver;
		}
		public long CreatebcGpuserver(List<Models.DB.Local.BcGpuserver> BcGpuserver)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcGpuserver bcGpuserver in BcGpuserver)
				{
					localContext.BcGpuserver.Add(bcGpuserver);
					localContext.SaveChanges();
					returnid = bcGpuserver.BcGpuserverId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcGpuserver(long id, Models.DB.Local.BcGpuserver bcGpuserver)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcGpuserver.Update(bcGpuserver);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcGpuserver(long bcGpuserverId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcGpuserver bcGpuserver = localContext.BcGpuserver.First(p => p.BcGpuserverId == bcGpuserverId);
				localContext.BcGpuserver.Remove(bcGpuserver);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
