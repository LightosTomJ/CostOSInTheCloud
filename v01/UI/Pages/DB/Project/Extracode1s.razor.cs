using Models.DB.Project;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Project
{
    public class Extracode1Base : ComponentBase
    {
        protected IList<Models.DB.Project.Extracode1> extracode1s = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //extracode1s = await GetExtracode1sAsync();
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
