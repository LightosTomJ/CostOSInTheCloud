using Models.DB.Cache;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Cache
{
	public class Countries
	{
		private CacheContext cacheContext;

		public Countries(CacheContext dbContext)
		{
			cacheContext = dbContext;
		}

		public long CountryCount()
		{
			if (cacheContext == null) cacheContext = new CacheContext();
			return cacheContext.Country.Count();
		}

		public List<Models.DB.Cache.Country> GetAllCountries()
		{
			List<Models.DB.Cache.Country> Countries = new List<Models.DB.Cache.Country>();
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				Countries = cacheContext.Country.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Countries;
		}
		public long Createcountry(List<Models.DB.Cache.Country> Countries)
		{
			long returnid = 0;
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				foreach (Models.DB.Cache.Country country in Countries)
				{
					cacheContext.Country.Add(country);
					cacheContext.SaveChanges();
					returnid = country.CountryId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatecountry(long id, Models.DB.Cache.Country country)
		{
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				cacheContext.Country.Update(country);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletecountry(long countryId)
		{
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				Models.DB.Cache.Country country = cacheContext.Country.First(p => p.CountryId == countryId);
				cacheContext.Country.Remove(country);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
