using Models.DB.Project;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Project
{
    public class BoqitemMaterialBase : ComponentBase
    {
        protected IList<Models.DB.Project.BoqitemMaterial> boqitemmaterials = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //boqitemmaterials = await GetBoqItemMaterialsAsync();
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
