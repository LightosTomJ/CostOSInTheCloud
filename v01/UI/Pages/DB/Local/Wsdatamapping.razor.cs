using Diagnostics.Logger; using Models.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Local
{
    public class WsdatamappingBase : ComponentBase
    {
        protected IList<Models.DB.Local.WsDataMapping> wsdatamapping = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //wsdatamapping = await GetWsdatamappingAsync();
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
