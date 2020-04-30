using Diagnostics.Logger; using Models.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Local
{
    public class AlcObjectsStatusBase : ComponentBase
    {
        protected IList<Models.DB.Local.AlcObjectsStatus> alcobjectsstatus = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //alcobjectsstatus = await GetAlcObjectsStatusAsync();
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
