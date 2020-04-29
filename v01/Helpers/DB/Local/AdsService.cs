using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class AdsService
	{
		private LocalContext localContext;

		public AdsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> AdCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Ad.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Ad>> GetAllAds()
		{
			IList<Models.DB.Local.Ad> Ads = new List<Models.DB.Local.Ad>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Ad> ads = await localContext.Ad.ToListAsync();
				return ads;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateAd(List<Models.DB.Local.Ad> Ads)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Ad ad in Ads)
				{
					localContext.Ad.Add(ad);
					await localContext.SaveChangesAsync();
					returnid = ad.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAd(long id, Models.DB.Local.Ad ad)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Ad.Update(ad);
				await localContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
		public async Task<bool> DeleteAd(long adId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Ad ad = localContext.Ad.First(p => p.Id == adId);
				localContext.Ad.Remove(ad);
				await localContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
	}
}
