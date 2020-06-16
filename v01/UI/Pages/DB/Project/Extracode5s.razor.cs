using Models.DB.Project;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Project
{
    public class Extracode5Base : ComponentBase
    {
        protected IList<Models.DB.Project.Extracode5> extracode5s = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //extracode5s = await GetExtracode5sAsync();
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
