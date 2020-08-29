using Diagnostics.Logger;
using Models.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;
using Helper.DB.Local;
using System.Globalization;

namespace UI.Pages.DB.Local
{
    public class ProjectURLBase : ComponentBase
    {
        protected IList<Models.DB.Local.ProjectURL> projectURLs = null;
        protected static LocalContext localContext = new LocalContext();
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
                    projectURLs = await urlService.GetAllProjectURLs(iProjectId);
                }
                else
                {
                    projectURLs = new List<Models.DB.Local.ProjectURL>();
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
                if (oProject.GetType() == typeof(Models.DB.Local.ProjectURL))
                {
                    Models.DB.Local.ProjectURL pURL = (Models.DB.Local.ProjectURL)oProject;
                    HelperService.ChangePage("/Sub-Project/"
                        + pURL.Projecturlid.ToString() + "/LineItems", true);
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
