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
    public class ExchangeRateBase : ComponentBase
    {
        protected IList<Models.DB.Cache.ExchangeRate> rates = null;
        protected static CacheContext cacheContext = new CacheContext();
        protected ExchangeRatesService exchangeRatesService = new ExchangeRatesService(cacheContext);
        
        protected override async Task OnInitializedAsync()
        {
            try
            {
                rates = await exchangeRatesService.GetAllExchangeRates();
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
