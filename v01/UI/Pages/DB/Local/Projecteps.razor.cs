using Helper.DB.Local;
using Microsoft.AspNetCore.Components;
using Models.DB.Local;
using Log = Diagnostics.Logger.Log;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Pages.DTO.Local;
using Radzen.Blazor;

namespace UI.Pages.DB.Local
{
    public class ProjectEPSBase : ComponentBase
    {
        protected IList<Models.DB.Local.ProjectEPS> projectEPS = null;
        protected IList<Models.DB.Local.ProjectInfo> projects = null;
        protected static LocalContext localContext = new LocalContext();
        protected ProjectEPSService projectEPSService = new ProjectEPSService(localContext);
        protected ProjectInfoService projectInfoService = new ProjectInfoService(localContext);
        protected List<ProjectEPSDto> entries = new List<ProjectEPSDto>();
        protected Dictionary<DateTime, string> events = new Dictionary<DateTime, string>();
        [Inject] HelperService HelperService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                projectEPS = await projectEPSService.GetAllProjectEPSAsync();
                projects = await projectInfoService.GetAllProjectInfoAsync();
                foreach (var p in projectEPS.Where(p => p.Parentid == null))
                {
                    entries.Add(new ProjectEPSDto()
                    {
                        ProjectEPSId = p.Projectepsid,
                        Code = p.Code,
                        Title = p.Title,
                        Value = string.Concat(p.Code, " - ", p.Title)
                    });
                }
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
            return;
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
                TreeLog("Expand", $"Text: {entries.IndexOf((ProjectEPSDto)args.Value)}");
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
        }

        protected void OnExpand(TreeExpandEventArgs args)
        {
            ProjectEPSDto epsNode = null;
            bool HasChildren = false;
            if (args.Value.GetType() == typeof(ProjectEPSDto))
            {
                epsNode = args.Value as ProjectEPSDto;
                List<ProjectEPSDto> subEntries = new List<ProjectEPSDto>();
                if (epsNode.ProjectId == 0)
                {
                    if (projects.Count(p => p.Projectepsid == epsNode.ProjectEPSId) > 0)    //Checks for EPS subnodes
                    {
                        subEntries.AddRange(epsNode.FromInfoList(
                            localContext.ProjectInfo.Where(p => p.Projectepsid == epsNode.ProjectEPSId).ToList()));
                        HasChildren = false;
                    }
                    if (localContext.ProjectEPS.Count(p => p.Parentid == epsNode.ProjectEPSId) > 0)         //Checks for EPS subnodes
                    {
                        subEntries.AddRange(epsNode.FromEPSList(
                            localContext.ProjectEPS.Where(p => p.Parentid == epsNode.ProjectEPSId).ToList()));
                        HasChildren = true;
                    }
                    args.Children.Data = subEntries;
                    args.Children.TextProperty = "Value";
                    args.Children.HasChildren = (epsNode) => HasChildren;
                    LogExpand(args);
                }
                else
                {
                    HelperService.ChangePage("/project/" + epsNode.ProjectId.ToString(), true);
                }
            }
        }

        protected RenderFragment NavigateNode(object data)
        {
            if (data.GetType() == typeof(RadzenTreeItem))
            {
                RadzenTreeItem rti = (RadzenTreeItem)data;
                //return rti.Template as RenderFragment;
            }
            return (RenderFragment)data;
        }
    }
}
