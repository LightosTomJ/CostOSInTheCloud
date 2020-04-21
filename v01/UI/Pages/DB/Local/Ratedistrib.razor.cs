using Models.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Local
{
    public class RatedistribBase : ComponentBase
    {
        protected IList<Models.DB.Local.Ratedistrib> ratedistrib = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //ratedistrib = await GetRatedistribAsync();
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
