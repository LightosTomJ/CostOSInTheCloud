using Models.DB.Project;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Project
{
    public class Extracode2Base : ComponentBase
    {
        protected IList<Models.DB.Project.Extracode2> extracode2s = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //extracode2s = await GetExtracode2sAsync();
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
