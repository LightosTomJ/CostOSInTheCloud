using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Countries
	{
		private LocalContext localContext;

		public Countries(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long CountryCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Country.Count();
		}

		public List<Models.DB.Local.Country> GetAllCountries()
		{
			List<Models.DB.Local.Country> Countries = new List<Models.DB.Local.Country>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Countries = localContext.Country.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Countries;
		}
		public long Createcountry(List<Models.DB.Local.Country> Countries)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Country country in Countries)
				{
					localContext.Country.Add(country);
					localContext.SaveChanges();
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

		public void Updatecountry(long id, Models.DB.Local.Country country)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Country.Update(country);
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
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Country country = localContext.Country.First(p => p.CountryId == countryId);
				localContext.Country.Remove(country);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
