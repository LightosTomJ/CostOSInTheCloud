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
	public class CountriesService
	{
		private CacheContext cacheContext;

		public CountriesService(CacheContext dbContext)
		{
			cacheContext = dbContext;
		}

		public async Task<long> CountryCount()
		{
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				return await cacheContext.Country.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Cache.Country>> GetAllCountries()
		{
			IList<Models.DB.Cache.Country> Countries = new List<Models.DB.Cache.Country>();
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				IList<Models.DB.Cache.Country> countries = await cacheContext.Country.ToListAsync();
				return countries;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateCountry(List<Models.DB.Cache.Country> Countries)
		{
			long returnid = -1;
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				foreach (Models.DB.Cache.Country country in Countries)
				{
					cacheContext.Country.Add(country);
					await cacheContext.SaveChangesAsync();
					returnid = country.CountryId;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateCountry(long id, Models.DB.Cache.Country country)
		{
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				cacheContext.Country.Update(country);
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
		public async Task<bool> DeleteCountry(long countryId)
		{
			try
			{
				if (cacheContext == null) cacheContext = new CacheContext();
				Models.DB.Cache.Country country = cacheContext.Country.First(p => p.CountryId == countryId);
				cacheContext.Country.Remove(country);
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
