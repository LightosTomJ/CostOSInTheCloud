using Models.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Local
{
    public class TakeoffareaBase : ComponentBase
    {
        protected IList<Models.DB.Local.Takeoffarea> takeoffarea = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //takeoffarea = await GetTakeoffareaAsync();
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
