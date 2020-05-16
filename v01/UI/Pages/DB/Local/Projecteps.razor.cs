using Diagnostics.Logger;
using Helper.DB.Local;
using Models.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using System.IO;

namespace UI.Pages.DB.Local
{
    public class ProjectepsBase : ComponentBase
    {
        protected IList<Models.DB.Local.ProjectEPS> projectEPS = null;
        protected static LocalContext localContext = new LocalContext();
        protected ProjectEPSService projectEPSService = new ProjectEPSService(localContext);
        protected List<string> entries = null;
        protected Dictionary<DateTime, string> events = new Dictionary<DateTime, string>();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                projectEPS = await projectEPSService.GetAllProjectEPSAsync();
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
            return;
        }

        protected async Task<int> CountParentNodes()
        {
            IList<Models.DB.Local.ProjectEPS> lNodes = new List<Models.DB.Local.ProjectEPS>();
            try
            {
                var nodes = await projectEPSService.GetProjectEPSParentsAsync();
                if (nodes != null)
                {
                    return nodes.Count;
                }
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
            return 0;
        }

        protected async Task<IList<Models.DB.Local.ProjectEPS>> GetParentNodes()
        {
            IList<Models.DB.Local.ProjectEPS> lNodes = new List<Models.DB.Local.ProjectEPS>();
            try
            {
                var nodes = await projectEPSService.GetProjectEPSParentsAsync();
                if (nodes != null)
                {
                    lNodes = nodes;
                }
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
            return lNodes;
        }

        protected async Task<bool> HasSubNodes(Models.DB.Local.ProjectEPS node)
        {
            try
            {
                var nodes = await projectEPSService.GetProjectEPSByNodeAsync(node);
                if (nodes != null)
                {
                    return true;
                }
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
            return false;
        }

        protected async Task<IList<Models.DB.Local.ProjectEPS>> GetSubNodes(Models.DB.Local.ProjectEPS node)
        {
            IList<Models.DB.Local.ProjectEPS> lNodes = new List<Models.DB.Local.ProjectEPS>();
            try
            {
                var nodes = await projectEPSService.GetProjectEPSByNodeAsync(node);
                if (nodes != null)
                {
                    lNodes = nodes;
                }
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
            return lNodes;
        }

        protected void TreeLog(string eventName, string value)
        {
            events.Add(DateTime.Now, $"{eventName}: {value}");
        }

        protected void LogChange(TreeEventArgs args)
        {
            TreeLog("Change", $"Item Text: {args.Text}");
        }

        protected void LogExpand(TreeExpandEventArgs args)
        {
            try
            {
                TreeLog("Expand", $"Text: {entries.IndexOf(args.Text.ToString())}");
            }
            catch (Exception ae)
            {
                Diagnostics.Logger.Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Diagnostics.Logger.Log.WriteLine(ae.InnerException.ToString());
            }
        }
    }
}
