using Models.DB.Config;
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
                ae.Message.ToString();
                if (ae.InnerException != null) _ = ae.InnerException.Message.ToString();
            }
            return;
        }
    }
}
