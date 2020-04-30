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
    public class AspNetUsersBase : ComponentBase
    {
        protected IList<Models.DB.Config.AspNetUsers> roles = null;
        protected static ConfigContext configContext = new ConfigContext();
        protected AspNetUsersService aspNetUsersService = new AspNetUsersService(configContext);

        protected override async Task OnInitializedAsync()
        {
            try
            {
                roles = await aspNetUsersService.GetAllAspNetUsers();
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
