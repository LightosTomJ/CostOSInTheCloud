using Models.DB.Project;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Project
{
    public class Extracode3Base : ComponentBase
    {
        protected IList<Models.DB.Project.Extracode3> extracode3s = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //extracode3s = await GetExtracode3sAsync();
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
