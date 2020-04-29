using API.Controllers.DB.Local;
using Helper.DB.Local;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Models.DB.Local;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Pages.DB.Local
{
    public class LaborBase : ComponentBase
    {
        protected IList<Models.DB.Local.Labor> labors = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                LaborsService laborsService = new LaborsService(new LocalContext());
                labors = await laborsService.GetAllLaborers();
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
