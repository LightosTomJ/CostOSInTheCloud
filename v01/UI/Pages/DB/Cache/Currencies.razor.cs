using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.DB.Cache;
using API.Controllers.DB.Cache;

namespace UI.Pages.DB.Cache
{
    public class CurrenciesBase : ComponentBase
    {
        protected List<Currency> currencies = new List<Currency>();
        internal protected List<Country> countries = new List<Country>();
        protected override async Task OnInitializedAsync()
        {
            try
            {
                cacheContext cacheC = new cacheContext();
                //Get currencies
                CurrencyController cc = new CurrencyController(cacheC);
                currencies = await cc.GetCurrencies();

                //Get associated countries
                CountryController countC = new CountryController(cacheC);
                countries = await countC.GetCountries();

                currencies.ForEach(c => c.Country = countries.FirstOrDefault(co => co.CountryId == c.CountryId));
            }
            catch (Exception ae)
            {
                string strError = ae.Message.ToString();
            }
            return;
        }
    }
}
