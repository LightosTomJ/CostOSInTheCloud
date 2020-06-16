using Models.DB.Project;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Project
{
    public class Extracode4Base : ComponentBase
    {
        protected IList<Models.DB.Project.Extracode4> extracode4s = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //extracode4s = await GetExtracode4sAsync();
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
