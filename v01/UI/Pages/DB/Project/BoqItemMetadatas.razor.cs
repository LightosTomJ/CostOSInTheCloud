using Models.DB.Project;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Project
{
    public class BoqitemmetadataBase : ComponentBase
    {
        protected IList<Models.DB.Project.Boqitemmetadata> boqitemmetadatas = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //boqitemmetadatas = await GetBoqItemMetadatasAsync();
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
