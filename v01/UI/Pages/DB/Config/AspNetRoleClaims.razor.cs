using Models.DB.Config;
using Microsoft.AspNetCore.Components;
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

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //aspnetroleclaims = await GetAspNetRoleClaimsAsync();
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
