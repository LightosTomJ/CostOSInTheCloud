using Models.DB.Project;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Helper.DB.Project;
using System.Globalization;
using Diagnostics.Logger;

namespace UI.Pages.DB.Project
{
    public class BoqitemBase : ComponentBase
    {
        protected IList<Models.DB.Project.BoqItem> boqItems = null;
        protected static ProjectContext projectContext = new ProjectContext();
        protected BoqItemsService boqItemsService = new BoqItemsService(projectContext);
        protected NumberFormatInfo nfi = new CultureInfo("en-GB", false).NumberFormat;
        [Inject] HelperService HelperService { get; set; }

        [Parameter]
        public string ProjectId { get; set; }
        protected int iProjectId = int.MinValue;
        [Parameter]
        public string ProjectInfoId { get; set; }
        protected int iProjectInfoId = int.MinValue;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                int.TryParse(ProjectInfoId, out iProjectInfoId);
                int.TryParse(ProjectId, out iProjectId);
                if (iProjectInfoId > int.MinValue && iProjectId > int.MinValue)
                {
                    boqItems = await boqItemsService.GetAllBoqItemsAsync(iProjectId);
                }
                else
                {
                    boqItems = new List<Models.DB.Project.BoqItem>();
                }
            }
            catch (Exception ae)
            {
                ae.Message.ToString();
                if (ae.InnerException != null) _ = ae.InnerException.Message.ToString();
            }
            return;
        }
        protected void RowSelected(object oBoqItem)
        {
            try
            {
                if (oBoqItem.GetType() == typeof(Models.DB.Project.BoqItem))
                {
                    Models.DB.Local.ProjectInfo pi = (Models.DB.Local.ProjectInfo)oBoqItem;
                    HelperService.ChangePage("/project/" + ProjectId + "/Sub-Project/" + 
                        pi.Projectinfoid.ToString() + "/Items/", true);
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
