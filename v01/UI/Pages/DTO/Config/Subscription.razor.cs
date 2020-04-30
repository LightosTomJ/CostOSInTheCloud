using Diagnostics.Logger;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Pages.DTO.Config
{
    public class PricingBase : ComponentBase
    {
        protected List<bool> pricing = null;
        protected override void OnInitialized()
        {
            try
            {
                pricing = new List<bool>();
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
            return;
        }
    }
}
