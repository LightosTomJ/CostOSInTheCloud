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
    public class AspNetUserClaimsBase : ComponentBase
    {
        protected IList<Models.DB.Config.AspNetUserClaims> aspnetuserclaims = null;
        protected static ConfigContext configContext = new ConfigContext();
        protected AspNetUserClaimsService aspNetUserClaimsService = new AspNetUserClaimsService(configContext);

        protected override async Task OnInitializedAsync()
        {
            try
            {
                aspnetuserclaims = await aspNetUserClaimsService.GetAllAspNetUserClaims();
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
