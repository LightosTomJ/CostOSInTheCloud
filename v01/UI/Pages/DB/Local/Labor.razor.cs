using API.Controllers.DB.Local;
using Helper.DB.Local;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Diagnostics.Logger; using Models.DB.Local;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Pages.DB.Local
{
    public class LaborBase : ComponentBase
    {
        protected IList<Models.DB.Local.Labor> laborers = null;
        protected static LocalContext localContext = new LocalContext();
        protected LaborsService laborsService = new LaborsService(localContext);
        protected NumberFormatInfo nfi = new CultureInfo("en-GB", false).NumberFormat;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                laborers = await laborsService.GetAllLaborers();
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
