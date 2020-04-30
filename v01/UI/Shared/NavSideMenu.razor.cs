using Microsoft.AspNetCore.Components;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Shared
{
    public class NavSideMenuBase : ComponentBase
    {

        protected List<string> entries = null;
        protected Dictionary<DateTime, string> events = new Dictionary<DateTime, string>();
        protected void Log(string eventName, string value)
        {
            events.Add(DateTime.Now, $"{eventName}: {value}");
        }

        protected void LogChange(TreeEventArgs args)
        {
            Log("Change", $"Item Text: {args.Text}");
        }

        protected void LogExpand(TreeExpandEventArgs args)
        {
            try
            {
                Log("Expand", $"Text: {entries.IndexOf(args.Text.ToString())}");
            }
            catch (Exception ae)
            {
                Diagnostics.Logger.Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Diagnostics.Logger.Log.WriteLine(ae.InnerException.ToString());
            }
        }

        protected override void OnInitialized()
        {
            entries = new List<string>()
            {
                "Variables",
                "Country",
                "Currency",
                "Exchange Rate"
            };
        }
    }
}