using Microsoft.AspNetCore.Components;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Pages.DTO.Config
{
    public class AccessRolesBase : ComponentBase
    {
        //TreeView variables
        protected List<string> entries = null;
        protected Dictionary<DateTime, string> events = new Dictionary<DateTime, string>();

        protected List<Models.DTO.Config.AccessRoles> roles = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //roles = await PopulateRolesAsync();
                List<Task> tasks = new List<Task>();
                tasks.Add(Task.Run(() => 
                {
                    if (roles == null) roles = PopulateRoles();
                }));
                tasks.Add(Task.Run(() =>
                {
                    if (entries == null) entries = PopulateEntries();
                }
                ));
                await Task.WhenAll(tasks.ToArray());
            }
            catch (Exception ae)
            {
                Diagnostics.Logger.Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Diagnostics.Logger.Log.WriteLine(ae.InnerException.ToString());
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
                if (entries == null) entries = PopulateEntries();
                if (args.Text != null)
                {
                    Log("Expand", $"Text: {entries.IndexOf(args.Text.ToString())}");
                }
            }
            catch (Exception ae)
            {
                Diagnostics.Logger.Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Diagnostics.Logger.Log.WriteLine(ae.InnerException.ToString());
            }
        }

        protected void Toggle(bool toggled)
        {
            if (toggled)
            { }
            else
            { }
        }

        protected IList<string> GetRoles()
        {
            IList<string> r = new List<string>();
            try
            {
                if (roles != null) roles = PopulateRoles();
                r = roles.Select(g => g.Group).Distinct().ToList();
            }
            catch (Exception ae)
            {
                Diagnostics.Logger.Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Diagnostics.Logger.Log.WriteLine(ae.InnerException.ToString());
            }
            return r;
        }

        private List<string> PopulateEntries()
        {
            return new List<string>()
                {
                    "Projects",
                    "Quotes",
                    "Lite Items",
                    "Resources",
                    "Features",
                    "Escalation"
                };
        }
        private List<Models.DTO.Config.AccessRoles> PopulateRoles()
        {
            List<Models.DTO.Config.AccessRoles> roles = new List<Models.DTO.Config.AccessRoles>();
            //List<Task> tasks = new List<Task>();
            //tasks.Add(Task.Run(() =>
            //{
                //Projects
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
                //Quotes
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Quotes",
                    Name = "Request",
                    CanView = true,
                    CanEdit = true
                });
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Quotes",
                    Name = "Submit",
                    CanView = true,
                    CanEdit = true
                });
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Quotes",
                    Name = "Award",
                    CanView = true,
                    CanEdit = false
                });
                //Line items
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Line Items",
                    Name = "Take-off",
                    CanView = true,
                    CanEdit = true
                });
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Line Items",
                    Name = "WBS",
                    CanView = true,
                    CanEdit = true
                });
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Line Items",
                    Name = "Resources",
                    CanView = true,
                    CanEdit = false
                });
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Line Items",
                    Name = "Custom columns",
                    CanView = true,
                    CanEdit = true
                });
                //Resources
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Resources",
                    Name = "Materials",
                    CanView = true,
                    CanEdit = true
                });
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Resources",
                    Name = "Labour",
                    CanView = true,
                    CanEdit = true
                });
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Resources",
                    Name = "Plant",
                    CanView = true,
                    CanEdit = false
                });
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Resources",
                    Name = "Consumables",
                    CanView = true,
                    CanEdit = true
                });
                //Escalation
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Escalation",
                    Name = "Materials",
                    CanView = true,
                    CanEdit = true
                });
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Escalation",
                    Name = "Exchanage Rates",
                    CanView = true,
                    CanEdit = true
                });
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Escalation",
                    Name = "Inflation",
                    CanView = true,
                    CanEdit = false
                });
                roles.Add(new Models.DTO.Config.AccessRoles
                {
                    Group = "Escalation",
                    Name = "Other",
                    CanView = true,
                    CanEdit = true
                });
            //}));

            //await Task.WhenAll(tasks);
            return roles;
        }
    }
}
