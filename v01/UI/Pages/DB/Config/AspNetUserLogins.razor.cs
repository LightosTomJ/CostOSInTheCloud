using Models.DB.Config;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Config
{
    public class AspNetUserLoginsBase : ComponentBase
    {
        protected IList<Models.DB.Config.AspNetUserLogins> aspnetuserlogins = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //aspnetuserlogins = await GetAspNetUserLoginsAsync();
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
