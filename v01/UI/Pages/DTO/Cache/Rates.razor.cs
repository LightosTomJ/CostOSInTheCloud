using API.Controllers.DB.Cache;
using Microsoft.AspNetCore.Components;
using Models.DB.Cache;
using Models.DTO.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Pages.DTO.Cache
{
    public class RatesBase : ComponentBase
    {
        protected IEnumerable<ForExHistory> rates = null;
        internal protected List<Country> countries = new List<Country>();
        internal protected List<Currency> currencies = new List<Currency>();
        internal protected List<ExchangeRate> exchangerates = new List<ExchangeRate>();
        protected Dictionary<DateTime, string> events = new Dictionary<DateTime, string>();
        protected override async Task OnInitializedAsync()
        {
            try
            {
                cacheContext cacheC = new cacheContext();
                List<Task> tasks = new List<Task>();
                CountryController countC = new CountryController(cacheC);
                CurrencyController currC = new CurrencyController(cacheC);
                ExchangeRateController rateC = new ExchangeRateController(cacheC);

                //Get currencies
                currencies = await currC.GetCurrencies();
                //Get associated countries
                countries = await countC.GetCountries();
                //Get associated countries
                exchangerates = await rateC.AllExchangeRates();

                //Combine countries to currencies
                currencies.ForEach(c => c.Country = countries.FirstOrDefault(co => co.CountryId == c.CountryId));
                exchangerates.ForEach(e => e.Currency = currencies.FirstOrDefault(cu => cu.CurrencyId == e.CurrencyId));

                List<ForExHistory> lForX = new List<ForExHistory>();
                foreach (Country c in countries)
                {
                    ForExHistory fx = new ForExHistory();
                    fx.country = c;
                    fx.currencies = new List<Currency>();
                    fx.currencies.AddRange(currencies.Where(s => s.Country == c).ToList());
                    foreach (Currency cu in fx.currencies)
                    {
                        List<ExchangeRate> lEx = exchangerates.Where(ex => ex.Currency == cu).ToList();
                        fx.rates = new List<List<ExchangeRate>>();
                        fx.rates.Add(lEx);
                    }
                    lForX.Add(fx);
                }

                rates = lForX;
            }
            catch (Exception ae)
            {
                ae.Message.ToString();
                if (ae.InnerException != null) _ = ae.InnerException.Message.ToString();
            }
            return;
        }
    }
}
