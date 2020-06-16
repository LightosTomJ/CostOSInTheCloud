using Models.DB.Project;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Project
{
    public class ParamitemBase : ComponentBase
    {
        protected IList<Models.DB.Project.Paramitem> paramitems = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //paramitems = await GetParamItemsAsync();
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
