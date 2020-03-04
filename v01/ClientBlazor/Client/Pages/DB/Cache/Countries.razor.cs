using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.DB.Cache;
using ClientBlazor.Shared.Cache;

namespace ClientBlazor.Client.Pages.DB.Cache
{
    public class CountriesBase : ComponentBase
    {
        public async Task<List<Country>> listCountries()
        {
            List<Country> countries = new List<Country>();
            CountryController cc = new CountryController(new cacheContext());
            countries = await cc.GetCountries();
            return countries;
        }
    }
}
