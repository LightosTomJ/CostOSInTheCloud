using Models.DB.Project;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Project
{
    public class FnctonBase : ComponentBase
    {
        protected IList<Models.DB.Project.Fncton> fnctons = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //fnctons = await GetFnctonsAsync();
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
