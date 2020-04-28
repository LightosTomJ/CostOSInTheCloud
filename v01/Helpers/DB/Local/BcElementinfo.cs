using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcElementinfo
	{
		private LocalContext localContext;

		public BcElementinfo(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcElementinfoCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcElementinfo.Count();
		}

		public List<Models.DB.Local.BcElementinfo> GetAllBcElementinfo()
		{
			List<Models.DB.Local.BcElementinfo> BcElementinfo = new List<Models.DB.Local.BcElementinfo>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcElementinfo = localContext.BcElementinfo.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcElementinfo;
		}
		public long CreatebcElementinfo(List<Models.DB.Local.BcElementinfo> BcElementinfo)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcElementinfo bcElementinfo in BcElementinfo)
				{
					localContext.BcElementinfo.Add(bcElementinfo);
					localContext.SaveChanges();
					returnid = bcElementinfo.BcElementinfoId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcElementinfo(long id, Models.DB.Local.BcElementinfo bcElementinfo)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcElementinfo.Update(bcElementinfo);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcElementinfo(long bcElementinfoId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcElementinfo bcElementinfo = localContext.BcElementinfo.First(p => p.BcElementinfoId == bcElementinfoId);
				localContext.BcElementinfo.Remove(bcElementinfo);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
