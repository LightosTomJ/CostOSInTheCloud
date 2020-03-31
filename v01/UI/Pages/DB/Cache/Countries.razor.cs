using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.DB.Cache;
using API.Controllers.DB.Cache;

namespace UI.Pages.DB.Cache
{
    public class CountriesBase : ComponentBase
    {
        public async Task<List<Country>> listCountries()
        {
            List<Country> countries = new List<Country>();
            CountryController cc = new CountryController(new CacheContext());
            countries = await cc.GetCountries();
            return countries;
        }
    }
}
