using Models.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Local
{
    public class BcModelBase : ComponentBase
    {
        protected IList<Models.DB.Local.BcModel> bcmodel = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //bcmodel = await GetBcModelAsync();
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
