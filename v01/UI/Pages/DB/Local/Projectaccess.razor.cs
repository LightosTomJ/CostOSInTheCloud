using Models.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Local
{
    public class ProjectaccessBase : ComponentBase
    {
        protected IList<Models.DB.Local.ProjectAccess> projectaccess = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //projectaccess = await GetProjectaccessAsync();
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
