using API.Controllers.DB.Cache;
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
        protected IEnumerable<Models.DB.Cache.ExchangeRate> rates = null;
        protected Dictionary<DateTime, string> events = new Dictionary<DateTime, string>();
        protected override async Task OnInitializedAsync()
        {
            try
            {
                ExchangeRateController rateC = new ExchangeRateController(new CacheContext());
                rates = await rateC.AllExchangeRates();

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
