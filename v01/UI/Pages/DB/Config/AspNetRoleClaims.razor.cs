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
    public class AspNetRoleClaimsBase : ComponentBase
    {
        protected IList<Models.DB.Config.AspNetRoleClaims> aspnetroleclaims = null;
        protected static ConfigContext configContext = new ConfigContext();
        protected AspNetRoleClaimsService aspNetRoleClaimsService = new AspNetRoleClaimsService(configContext);

        protected override async Task OnInitializedAsync()
        {
            try
            {
                aspnetroleclaims = await aspNetRoleClaimsService.GetAllAspNetRoleClaims();
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
