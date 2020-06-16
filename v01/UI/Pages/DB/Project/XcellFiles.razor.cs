using Models.DB.Project;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Project
{
    public class XcellfileBase : ComponentBase
    {
        protected IList<Models.DB.Project.Xcellfile> xcellfiles = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //xcellfiles = await GetXcellFilesAsync();
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
