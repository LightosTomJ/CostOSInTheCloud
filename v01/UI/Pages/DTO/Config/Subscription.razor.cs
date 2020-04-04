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
                ae.Message.ToString();
                if (ae.InnerException != null) _ = ae.InnerException.Message.ToString();
            }
            return;
        }
    }
}
