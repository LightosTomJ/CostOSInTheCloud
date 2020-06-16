using Models.DB.Project;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Project
{
    public class Extracode7Base : ComponentBase
    {
        protected IList<Models.DB.Project.Extracode7> extracode7s = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //extracode7s = await GetExtracode7sAsync();
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
