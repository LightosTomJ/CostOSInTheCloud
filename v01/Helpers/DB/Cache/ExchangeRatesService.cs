using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Cache;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Cache
{
	public class ExchangeRatesService
	{
		private CacheContext cacheContext;

		public ExchangeRatesService(CacheContext dbContext)
		{
			cacheContext = dbContext;
		}

		public async Task<long> ExchangeRateCount()
		{
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				return await cacheContext.ExchangeRate.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Cache.ExchangeRate>> GetAllExchangeRates()
		{
			IList<Models.DB.Cache.ExchangeRate> ExchangeRates = new List<Models.DB.Cache.ExchangeRate>();
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				IList<Models.DB.Cache.ExchangeRate> exchangeRates = await cacheContext.ExchangeRate.ToListAsync();
				return exchangeRates;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<Guid> CreateExchangeRate(List<Models.DB.Cache.ExchangeRate> ExchangeRates)
		{
			Guid returnid = Guid.Empty;
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				foreach (Models.DB.Cache.ExchangeRate exchangeRate in ExchangeRates)
				{
					cacheContext.ExchangeRate.Add(exchangeRate);
					await cacheContext.SaveChangesAsync();
					returnid = exchangeRate.ExchangeRateId;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateExchangeRate(long id, Models.DB.Cache.ExchangeRate exchangeRate)
		{
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				cacheContext.ExchangeRate.Update(exchangeRate);
				await cacheContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
		public async Task<bool> DeleteExchangeRate(Guid exchangeRateId)
		{
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				Models.DB.Cache.ExchangeRate exchangeRate = cacheContext.ExchangeRate.First(p => p.ExchangeRateId == exchangeRateId);
				cacheContext.ExchangeRate.Remove(exchangeRate);
				await cacheContext.SaveChangesAsync();
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
