using Models.DB.Project;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Project
{
    public class ParamconditionBase : ComponentBase
    {
        protected IList<Models.DB.Project.Paramcondition> paramconditions = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //paramconditions = await GetParamConditionsAsync();
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
