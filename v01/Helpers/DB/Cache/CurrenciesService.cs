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
	public class CurrenciesService
	{
		private CacheContext cacheContext;

		public CurrenciesService(CacheContext dbContext)
		{
			cacheContext = dbContext;
		}

		public async Task<long> CurrencyCount()
		{
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				return await cacheContext.Currency.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Cache.Currency>> GetAllCurrencies()
		{
			IList<Models.DB.Cache.Currency> Currencies = new List<Models.DB.Cache.Currency>();
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				IList<Models.DB.Cache.Currency> currencies = await cacheContext.Currency.ToListAsync();
				return currencies;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateCurrency(List<Models.DB.Cache.Currency> Currencies)
		{
			long returnid = -1;
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				foreach (Models.DB.Cache.Currency currency in Currencies)
				{
					cacheContext.Currency.Add(currency);
					await cacheContext.SaveChangesAsync();
					returnid = currency.CurrencyId;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateCurrency(Models.DB.Cache.Currency currency)
		{
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				cacheContext.Currency.Update(currency);
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
		public async Task<bool> DeleteCurrency(long currencyId)
		{
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				Models.DB.Cache.Currency currency = cacheContext.Currency.First(p => p.CurrencyId == currencyId);
				cacheContext.Currency.Remove(currency);
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
