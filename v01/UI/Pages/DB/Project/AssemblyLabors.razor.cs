using Models.DB.Project;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Project
{
    public class AssemblyLaborBase : ComponentBase
    {
        protected IList<Models.DB.Project.AssemblyLabor> assemblylabors = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //assemblylabors = await GetAssemblyLaborsAsync();
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
