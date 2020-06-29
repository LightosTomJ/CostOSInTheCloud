using Models.DB.Project;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;
using Diagnostics.Logger;

namespace UI.Pages.DB.Project
{
    public class BoqitemAssemblyBase : ComponentBase
    {
        protected IList<BoqItemAssembly> boqitemassemblies = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //boqitemassemblies = await GetBoqItemAssembliesAsync();
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message.ToString());
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.Message.ToString());
            }
            return;
        }
    }
}
