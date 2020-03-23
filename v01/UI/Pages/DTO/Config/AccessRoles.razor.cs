using Models.DTO.Config;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DTO.Config
{
    public class AccessRolesBase : ComponentBase
    {
        //TreeView variables
        protected List<string> entries = null;
        protected Dictionary<DateTime, string> events = new Dictionary<DateTime, string>();
        //
        protected IEnumerable<Models.DTO.Config.AccessRoles> roles = null;

        protected override async Task OnInitializedAsync()
        //protected override void OnInitialized()
        {
            try
            {
                roles = await PopulateRolesAsync();
                entries = new List<string>()
                {
                    "Projects",
                    "Quotes",
                    "Lite Items",
                    "Resources",
                    "Features",
                    "Escalation"
                };

            }
            catch (Exception ae)
            {
                ae.Message.ToString();
                if (ae.InnerException != null) _ = ae.InnerException.Message.ToString();
            }
            return;
        }

        //TreeView methods
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
                ae.Message.ToString();
                if (ae.InnerException != null) _ = ae.InnerException.Message.ToString();
            }
        }

        protected void Toggle(bool toggled)
        {
            if (toggled)
            { }
            else
            { }
        }

        private async Task<List<Models.DTO.Config.AccessRoles>> PopulateRolesAsync()
        {
            List<Models.DTO.Config.AccessRoles> roles = new List<Models.DTO.Config.AccessRoles>();
            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() =>
            {
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Projects",
                    Name = "Properties",
                    CanView = true,
                    CanEdit = true
                });
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Projects",
                    Name = "WBS",
                    CanView = true,
                    CanEdit = true
                });
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Projects",
                    Name = "Import from Central DB",
                    CanView = true,
                    CanEdit = false
                });
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Projects",
                    Name = "Export to Central DB",
                    CanView = true,
                    CanEdit = true
                });
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Projects",
                    Name = "Custom Attributes",
                    CanView = true,
                    CanEdit = true
                });
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Projects",
                    Name = "Escalation",
                    CanView = false,
                    CanEdit = false
                });
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Projects",
                    Name = "Works Packages",
                    CanView = false,
                    CanEdit = false
                });
            }));

            await Task.WhenAll(tasks);
            return roles;
        }
    }
}
