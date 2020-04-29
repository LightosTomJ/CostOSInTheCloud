using Models.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Local
{
    public class BcSpatialinfoBase : ComponentBase
    {
        protected IList<Models.DB.Local.BcSpatialInfo> bcspatialinfo = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //bcspatialinfo = await GetBcSpatialinfoAsync();
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
