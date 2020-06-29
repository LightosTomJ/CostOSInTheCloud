using Diagnostics.Logger;
using Models.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Helper.DB.Local;
using System.Globalization;

namespace UI.Pages.DB.Local
{
    public class ProjectInfoBase : ComponentBase
    {
        protected IList<Models.DB.Local.ProjectInfo> projectInfo = null;
        protected static LocalContext localContext = new LocalContext();
        protected ProjectInfoService infoService = new ProjectInfoService(localContext);
        protected ProjectURLsService urlService = new ProjectURLsService(localContext);
        protected NumberFormatInfo nfi = new CultureInfo("en-GB", false).NumberFormat;
        [Inject] HelperService HelperService { get; set; }

        [Parameter]
        public string ProjectId { get; set; }
        protected int iProjectId = int.MinValue;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                int.TryParse(ProjectId, out iProjectId);
                if (iProjectId > int.MinValue)
                {
                    projectInfo = await infoService.GetAllProjectInfoByIdAsync(iProjectId);
                }
                else
                {
                    projectInfo = new List<Models.DB.Local.ProjectInfo>();
                }
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
            return;
        }

        protected void RowSelected(object oProject)
        {
            try
            {
                if (oProject.GetType() == typeof(Models.DB.Local.ProjectInfo))
                {
                    Models.DB.Local.ProjectInfo pi = (Models.DB.Local.ProjectInfo)oProject;
                    HelperService.ChangePage("/project/" + ProjectId + "/Sub-Projects", true);
                }
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
