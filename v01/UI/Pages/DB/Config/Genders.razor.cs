using Diagnostics.Logger;
using Helper.DB.Config;
using Microsoft.AspNetCore.Components;
using Models.DB.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Config
{
    public class GendersBase : ComponentBase
    {
        protected IList<Models.DB.Config.Genders> genders = null;
        protected static ConfigContext configContext = new ConfigContext();
        protected GendersService gendersService = new GendersService(configContext);

        protected override async Task OnInitializedAsync()
        {
            try
            {
                genders = await gendersService.GetAllGenders();
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
