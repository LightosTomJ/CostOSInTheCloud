using Diagnostics.Logger; using Models.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Local
{
    public class Extracode4Base : ComponentBase
    {
        protected IList<Models.DB.Local.Extracode4> extracode4 = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //extracode4 = await GetExtracode4Async();
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
