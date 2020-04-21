using Models.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Local
{
    public class ParamreturnBase : ComponentBase
    {
        protected IList<Models.DB.Local.Paramreturn> paramreturn = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //paramreturn = await GetParamreturnAsync();
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
