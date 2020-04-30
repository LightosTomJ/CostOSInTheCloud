using Helper.DB.Local;
using Diagnostics.Logger; using Models.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;
using System.Globalization;

namespace UI.Pages.DB.Local
{
    public class EquipmentBase : ComponentBase
    {
        protected IList<Models.DB.Local.Equipment> equipment = null;
        protected static LocalContext localContext = new LocalContext();
        protected EquipmentsService equipmentsService = new EquipmentsService(localContext);
        protected NumberFormatInfo nfi = new CultureInfo("en-GB", false).NumberFormat;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                equipment = await equipmentsService.GetAllEquipments();
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
