using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Currencies
	{
		private LocalContext localContext;

		public Currencies(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long CurrencyCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Currency.Count();
		}

		public List<Models.DB.Local.Currency> GetAllCurrencies()
		{
			List<Models.DB.Local.Currency> Currencies = new List<Models.DB.Local.Currency>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Currencies = localContext.Currency.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Currencies;
		}
		public long Createcurrency(List<Models.DB.Local.Currency> Currencies)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Currency currency in Currencies)
				{
					localContext.Currency.Add(currency);
					localContext.SaveChanges();
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

		public void Updatecurrency(long id, Models.DB.Local.Currency currency)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Currency.Update(currency);
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
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Currency currency = localContext.Currency.First(p => p.CurrencyId == currencyId);
				localContext.Currency.Remove(currency);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
