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
	public class CurrenciesService
	{
		private LocalContext localContext;

		public CurrenciesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> CurrencyCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Currency.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Currency>> GetAllCurrencies()
		{
			IList<Models.DB.Local.Currency> Currencies = new List<Models.DB.Local.Currency>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Currency> currencies = await localContext.Currency.ToListAsync();
				return currencies;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateCurrency(List<Models.DB.Local.Currency> Currencies)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Currency currency in Currencies)
				{
					localContext.Currency.Add(currency);
					await localContext.SaveChangesAsync();
					returnid = currency.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateCurrency(long id, Models.DB.Local.Currency currency)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Currency.Update(currency);
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
		public async Task<bool> DeleteCurrency(long currencyId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Currency currency = localContext.Currency.First(p => p.Id == currencyId);
				localContext.Currency.Remove(currency);
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
