using Diagnostics.Logger; using Models.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Local
{
    public class BcMaterialBase : ComponentBase
    {
        protected IList<Models.DB.Local.BcMaterial> bcmaterial = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //bcmaterial = await GetBcMaterialAsync();
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
