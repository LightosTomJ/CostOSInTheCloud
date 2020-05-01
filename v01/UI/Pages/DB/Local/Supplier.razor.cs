using Diagnostics.Logger;
using Models.DB.Local;
using Helper.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;
using System.Globalization;

namespace UI.Pages.DB.Local
{
    public class SupplierBase : ComponentBase
    {
        protected IList<Models.DB.Local.Supplier> suppliers = null;
        protected static LocalContext localContext = new LocalContext();
        protected SuppliersService suppliersService = new SuppliersService(localContext);
        protected CurrenciesService currencyService = new CurrenciesService(localContext);
        protected NumberFormatInfo nfi = new CultureInfo("en-GB", false).NumberFormat;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                suppliers = await suppliersService.GetAllSuppliers();
                nfi.CurrencyPositivePattern = 2;
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
