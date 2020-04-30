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
    public class AspNetRolesBase : ComponentBase
    {
        protected IList<Models.DB.Config.AspNetRoles> aspnetroles = null;
        protected static ConfigContext configContext = new ConfigContext();
        protected AspNetRolesService aspNetRolesService = new AspNetRolesService(configContext);

        protected override async Task OnInitializedAsync()
        {
            try
            {
                aspnetroles = await aspNetRolesService.GetAllAspNetRoles();
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
