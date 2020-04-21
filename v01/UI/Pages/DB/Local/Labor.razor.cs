using API.Controllers.DB.Local;
using Microsoft.AspNetCore.Components;
using Models.DB.Local;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Pages.DB.Local
{
    public class LaborBase : ComponentBase
    {
        protected IList<Models.DB.Local.Material> materials = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                MaterialController materialsC = new MaterialController(new localContext());
                materials = await materialsC.GetMaterial();

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
