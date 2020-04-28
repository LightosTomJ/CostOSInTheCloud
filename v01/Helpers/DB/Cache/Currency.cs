using Models.DB.Cache;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Cache
{
	public class Currencies
	{
		private CacheContext cacheContext;

		public Currencies(CacheContext dbContext)
		{
			cacheContext = dbContext;
		}

		public long CurrencyCount()
		{
			if (cacheContext == null) cacheContext = new CacheContext();
			return cacheContext.Currency.Count();
		}

		public List<Models.DB.Cache.Currency> GetAllCurrencies()
		{
			List<Models.DB.Cache.Currency> Currencies = new List<Models.DB.Cache.Currency>();
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				Currencies = cacheContext.Currency.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Currencies;
		}
		public long Createcurrency(List<Models.DB.Cache.Currency> Currencies)
		{
			long returnid = 0;
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				foreach (Models.DB.Cache.Currency currency in Currencies)
				{
					cacheContext.Currency.Add(currency);
					cacheContext.SaveChanges();
					returnid = currency.CurrencyId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatecurrency(long id, Models.DB.Cache.Currency currency)
		{
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				cacheContext.Currency.Update(currency);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletecurrency(long currencyId)
		{
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				Models.DB.Cache.Currency currency = cacheContext.Currency.First(p => p.CurrencyId == currencyId);
				cacheContext.Currency.Remove(currency);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
