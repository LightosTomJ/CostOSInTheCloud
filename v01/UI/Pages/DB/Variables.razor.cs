using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using System;
using System.Collections.Generic;
using System.IO;

namespace UI.Pages.DB
{
    public class VariablesBase : ComponentBase
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
            Log("Expand", $"Text: {entries[(int)args.Value]}");
        }

        protected override void OnInitialized()
        {
            entries = new List<string>()
            {
                "Country",
                "Currency",
                "Exchange Rate"
            };
        }
    }
}
