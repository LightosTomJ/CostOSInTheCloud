using Diagnostics.Logger;
using Helper.DB.Cache;
using Microsoft.AspNetCore.Components;
using Models.DB.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Pages.DB.Cache
{
    public class CurrenciesBase : ComponentBase
    {
        protected IList<Currency> currencies = null;
        protected IList<Country> countries = new List<Country>();
        protected static CacheContext cacheContext = new CacheContext();
        protected CountriesService countriesService = new CountriesService(cacheContext);
        protected CurrenciesService currenciesService = new CurrenciesService(cacheContext);
        protected override async Task OnInitializedAsync()
        {
                
            try
            {
                //Get currencies
                currencies = await currenciesService.GetAllCurrencies();

                //Get associated countries
                countries = await countriesService.GetAllCountries();

                foreach (Currency c in currencies)
                {
                    c.Country = countries.FirstOrDefault(co => co.CountryId == c.CountryId);
                }
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
            return;
        }
    }
}
