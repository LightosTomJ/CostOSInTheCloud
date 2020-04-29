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
	public class CountriesService
	{
		private LocalContext localContext;

		public CountriesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> CountryCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Country.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Country>> GetAllCountries()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Country> countries = await localContext.Country.ToListAsync();
				return countries;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateCountry(List<Models.DB.Local.Country> Countries)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Country country in Countries)
				{
					localContext.Country.Add(country);
					await localContext.SaveChangesAsync();
					returnid = country.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateCountry(Models.DB.Local.Country country)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Country.Update(country);
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
		public async Task<bool> DeleteCountry(long countryId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Country country = localContext.Country.First(p => p.Id == countryId);
				localContext.Country.Remove(country);
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
