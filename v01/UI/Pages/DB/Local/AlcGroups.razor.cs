using Models.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Local
{
    public class AlcGroupsBase : ComponentBase
    {
        protected IList<Models.DB.Local.AlcGroups> alcgroups = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //alcgroups = await GetAlcGroupsAsync();
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
