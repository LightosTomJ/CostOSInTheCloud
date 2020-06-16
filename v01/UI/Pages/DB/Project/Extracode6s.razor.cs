using Models.DB.Project;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Project
{
    public class Extracode6Base : ComponentBase
    {
        protected IList<Models.DB.Project.Extracode6> extracode6s = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //extracode6s = await GetExtracode6sAsync();
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
