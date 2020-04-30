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
    public class CountriesBase : ComponentBase
    {
        protected IList<Country> countries = null;
        protected static CacheContext cacheContext = new CacheContext();
        protected CountriesService countriesService = new CountriesService(cacheContext);
        protected override async Task OnInitializedAsync()
        {
            try
            {
                countries = await countriesService.GetAllCountries();
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
