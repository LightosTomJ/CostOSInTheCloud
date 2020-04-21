using Models.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Local
{
    public class GekcodeBase : ComponentBase
    {
        protected IList<Models.DB.Local.Gekcode> gekcode = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //gekcode = await GetGekcodeAsync();
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
