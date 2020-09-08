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
using System.IO;
using Microsoft.AspNetCore.Blazor.RenderTree;
using Microsoft.AspNetCore.Authentication;
using System.Runtime.CompilerServices;

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
                    var eps = new ProjectEPSDto()
                    {
                        ProjectEPSId = p.Projectepsid,
                        Code = p.Code,
                        Title = p.Title,
                        Value = string.Concat(p.Code, " - ", p.Title),
                        Level = 1
                    };
                    if (projectEPS.Count(p => p.Parentid == eps.ProjectEPSId) > 0)
                    { eps.HasChildren = true; }
                    else
                    { eps.HasChildren = false; }
                    entries.Add(eps);
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
            if (args.Value.GetType() == typeof(ProjectEPSDto))
                try
                {
                    epsNode = args.Value as ProjectEPSDto;
                    List<ProjectEPSDto> subEntries = new List<ProjectEPSDto>();
                    if (epsNode.ProjectId == 0)
                    {
                        if (projects.Count(p => p.Projectepsid == epsNode.ProjectEPSId) > 0)    //Checks for EPS projects
                        {
                            subEntries.AddRange(epsNode.FromInfoList(
                                localContext.ProjectInfo.Where(p => p.Projectepsid == epsNode.ProjectEPSId).ToList()));
                        }
                        if (localContext.ProjectEPS.Count(p => p.Parentid == epsNode.ProjectEPSId) > 0)         //Checks for EPS branches
                        {
                            subEntries.AddRange(epsNode.FromEPSList(
                                localContext.ProjectEPS.Where(p => p.Parentid == epsNode.ProjectEPSId).ToList()));
                        }
                    }
                    //Determine if items have children
                    subEntries = SubChildren(epsNode, subEntries).ToList();

                    args.Children.Data = subEntries;
                    args.Children.TextProperty = "Value";
                    args.Children.HasChildren = (epsNode) => true; //+/- chevron added manually in RenderFragment below
                    args.Children.Template = NavigateNode;
                    if (epsNode.HasChildren == false)
                    {
                        RedirectToPage("/project/" + epsNode.ProjectId.ToString() + "/Sub-Projects", true);
                    }
                    else
                    { LogExpand(args); }
                }
                catch (Exception ae)
                {
                    Log.WriteLine(ae.Message);
                    if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
                }
        }

        protected async Task Change(object value, string name)
        {
            if (value.ToString() == "Cloud")
            {
                Shared.DataSource.Current = 2;
                var pro = await REST.Projects.Service.GetAllProjectsAsync();
                //var pro2 = await REST.Projects.Service.GetAllProjectInfoAsync();
            }
            else
            {
                Shared.DataSource.Current = 1;
                projectEPS = await projectEPSService.GetAllProjectEPSAsync();
                projects = await projectInfoService.GetAllProjectInfoAsync();
            }
            events.Add(DateTime.Now, $"{name} value changed to " + value);
            StateHasChanged();
        }

        protected RenderFragment<RadzenTreeItem> NavigateNode = (context) => builder =>
        {
            ProjectEPSDto epsNode = context.Value as ProjectEPSDto;

            builder.OpenComponent(0, typeof(RadzenIcon));
            if (epsNode.HasChildren)
            {
                //if (epsNode.Level > 1)
                //{
                //    builder.AddAttribute(1, "Class", "ui-tree-toggler pi pi-caret-right");
                //    builder.AddAttribute(4, "onclick", EventCallback.Factory.Create<TreeExpandEventArgs>(context, OnExpand));
                //}
                builder.AddAttribute(2, "Icon", "folder");
                //builder.AddAttribute(3, "Style", "margin-left: " + (((epsNode.Level - 1) * 18)).ToString() + "px");
            }
            else
            {
                builder.AddAttribute(2, "Icon", "insert_drive_file");
                //builder.AddAttribute(3, "Style", "margin-left: " + (((epsNode.Level - 1) * 18) + 24).ToString() + "px");
            }
            builder.CloseComponent();
            builder.AddContent(4, context.Text);

            //return (RenderFragment)context.Value;
        };

        ////protected RenderFragment<RadzenTreeItem> TreeOrProject(RenderTreeBuilder builder, RadzenTreeItem context)
        //protected RenderFragment<RadzenTreeItem> TreeOrProject = (context) => builder =>
        //{
        //    ProjectEPSDto epsNode = context.Value as ProjectEPSDto;
        //    List<ProjectEPSDto> subEntries = new List<ProjectEPSDto>();

        //    builder.OpenComponent(0, typeof(RadzenIcon));
        //    //builder.OpenComponent<RadzenIcon>(0);
        //    if (epsNode.HasChildren)
        //    {
        //        if (epsNode.Level > 1)
        //        {
        //            builder.AddAttribute(1, "Class", "ui-tree-toggler pi pi-caret-right");
        //            //builder.AddAttribute(4, "onclick", EventCallback.Factory.Create<TreeExpandEventArgs>(context, OnExpand));
        //        }
        //        builder.AddAttribute(2, "Icon", "folder");
        //        builder.AddAttribute(3, "Style", "margin-left: " + (((epsNode.Level - 1) * 18)).ToString() + "px");
        //    }
        //    else
        //    {
        //        builder.AddAttribute(2, "Icon", "insert_drive_file");
        //        builder.AddAttribute(3, "Style", "margin-left: " + (((epsNode.Level - 1) * 18) + 24).ToString() + "px");
        //    }
        //    builder.CloseComponent();
        //    builder.AddContent(4, context.Text);
        //    //builder.AddContent(4, (RenderFragment)((builder) =>
        //    //{
        //    //    builder.AddContent(5, context.Text);
        //    //    builder
        //    //}));
        //    //builder.AddAttribute(4, "ChildContent", (RenderFragment)((builder) =>
        //    //{
        //    //    builder.AddContent(5, context.Text);
        //    //}));
        //    //return (RenderFragment<RadzenTreeItem>)context;
        //};

        protected void RedirectToPage(string uri, bool force)
        {
            HelperService.ChangePage(uri, force);
        }

        protected IList<ProjectEPSDto> SubChildren(ProjectEPSDto dto, IList<ProjectEPSDto> children)
        {

            foreach (var c in children)
            {
                var lEps = localContext.ProjectEPS.Where(p => p.Parentid == c.ProjectEPSId).ToList();
                var lInfo = lEps.SelectMany(p => p.Projectinfo.Where(
                                            q => q.Projectinfoid == c.ProjectId)
                                            .ToList())
                                            .ToList();
                if (lInfo.Count > 0 || c.ProjectId == 0)
                {
                    c.HasChildren = true;
                }
                else
                {
                    c.HasChildren = false;
                }
                c.Level = (short)(dto.Level + 1);
            }

            return children;
        }
    }
}
