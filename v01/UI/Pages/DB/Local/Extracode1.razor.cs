using Models.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Local
{
    public class Extracode1Base : ComponentBase
    {
        protected IList<Models.DB.Local.Extracode1> extracode1 = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //extracode1 = await GetExtracode1Async();
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
