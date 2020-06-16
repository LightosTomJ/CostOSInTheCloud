using Models.DB.Project;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Project
{
    public class Projectwbs2Base : ComponentBase
    {
        protected IList<Models.DB.Project.Projectwbs2> projectwbs2s = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //projectwbs2s = await GetProjectWBS2sAsync();
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
