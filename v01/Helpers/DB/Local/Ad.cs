using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Ad
	{
		private LocalContext localContext;

		public Ad(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long AdCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Ad.Count();
		}

		public List<Models.DB.Local.Ad> GetAllAd()
		{
			List<Models.DB.Local.Ad> Ad = new List<Models.DB.Local.Ad>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Ad = localContext.Ad.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Ad;
		}
		public long Createad(List<Models.DB.Local.Ad> Ad)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Ad ad in Ad)
				{
					localContext.Ad.Add(ad);
					localContext.SaveChanges();
					returnid = ad.AdId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatead(long id, Models.DB.Local.Ad ad)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Ad.Update(ad);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletead(long adId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Ad ad = localContext.Ad.First(p => p.AdId == adId);
				localContext.Ad.Remove(ad);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
