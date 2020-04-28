using Models.DB.Cache;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Cache
{
	public class ExchangeRate
	{
		private CacheContext cacheContext;

		public ExchangeRate(CacheContext dbContext)
		{
			cacheContext = dbContext;
		}

		public long ExchangeRateCount()
		{
			if (cacheContext == null) cacheContext = new CacheContext();
			return cacheContext.ExchangeRate.Count();
		}

		public List<Models.DB.Cache.ExchangeRate> GetAllExchangeRate()
		{
			List<Models.DB.Cache.ExchangeRate> ExchangeRate = new List<Models.DB.Cache.ExchangeRate>();
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				ExchangeRate = cacheContext.ExchangeRate.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return ExchangeRate;
		}
		public long CreateexchangeRate(List<Models.DB.Cache.ExchangeRate> ExchangeRate)
		{
			long returnid = 0;
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				foreach (Models.DB.Cache.ExchangeRate exchangeRate in ExchangeRate)
				{
					cacheContext.ExchangeRate.Add(exchangeRate);
					cacheContext.SaveChanges();
					returnid = exchangeRate.ExchangeRateId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateexchangeRate(long id, Models.DB.Cache.ExchangeRate exchangeRate)
		{
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				cacheContext.ExchangeRate.Update(exchangeRate);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteexchangeRate(long exchangeRateId)
		{
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				Models.DB.Cache.ExchangeRate exchangeRate = cacheContext.ExchangeRate.First(p => p.ExchangeRateId == exchangeRateId);
				cacheContext.ExchangeRate.Remove(exchangeRate);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
