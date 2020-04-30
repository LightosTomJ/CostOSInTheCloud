using Diagnostics.Logger; using Models.DB.Config;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Config
{
    public class AspNetUserRolesBase : ComponentBase
    {
        protected IList<Models.DB.Config.AspNetUserRoles> aspnetuserroles = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //aspnetuserroles = await GetAspNetUserRolesAsync();
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
