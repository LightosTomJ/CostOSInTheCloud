using Diagnostics.Logger;
using Helper.DB.Project;
using Microsoft.AspNetCore.Components;
using Models.DB.Project;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Globalization;
using Radzen.Blazor;

namespace UI.Pages.DB.Project
{
    public class BoqitemBase : ComponentBase
    {
        protected RadzenGrid<BoqItem> boqGrid;
        protected IList<Models.DB.Project.BoqItem> boqItems = null;
        protected static ProjectContext projectContext = new ProjectContext();
        protected BoqItemsService boqItemsService = new BoqItemsService(projectContext);
        protected NumberFormatInfo nfi = new CultureInfo("en-GB", false).NumberFormat;
        [Inject] HelperService HelperService { get; set; }

        //[Parameter]
        //public string ProjectId { get; set; }
        //protected int iProjectId = int.MinValue;
        [Parameter]
        public string ProjectInfoId { get; set; }
        protected int iProjectInfoId = int.MinValue;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                int.TryParse(ProjectInfoId, out iProjectInfoId);
                //int.TryParse(ProjectId, out iProjectId);
                //if (iProjectInfoId > int.MinValue && iProjectId > int.MinValue)
                //{
                //    boqItems = await boqItemsService.GetAllBoqItemsAsync(iProjectId);
                //}
                if (iProjectInfoId > int.MinValue)
                {
                    boqItems = await boqItemsService.GetAllBoqItemsAsync(iProjectInfoId);
                }
                else
                {
                    boqItems = new List<Models.DB.Project.BoqItem>();
                }
                await base.OnInitializedAsync();
            }
            catch (Exception ae)
            {
                ae.Message.ToString();
                if (ae.InnerException != null) _ = ae.InnerException.Message.ToString();
            }
            return;
        }
        protected void RowSelected(Models.DB.Project.BoqItem oBoqItem)
        {
            try
            {
                
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
            return;
        }

        protected void EditRow(Models.DB.Project.BoqItem oBoqItem)
        {
            try
            {
                boqGrid.EditRow(oBoqItem);
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
            return;
        }

        protected async Task OnUpdateRow(Models.DB.Project.BoqItem oBoqItem)
        {
            try
            {
                await boqItemsService.UpdateBoqItemAsync(oBoqItem);
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
            return;
        }

        protected async Task SaveRow(Models.DB.Project.BoqItem oBoqItem)
        {
            try
            {
                await boqItemsService.UpdateBoqItemAsync(oBoqItem);
                await boqGrid.UpdateRow(oBoqItem);
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
            return;
        }

        protected void CancelEdit(Models.DB.Project.BoqItem oBoqItem)
        {
            try
            {
                boqItemsService.CancelBoqEdit(oBoqItem);
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message);
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
            return;
        }

        protected async Task DeleteRow(Models.DB.Project.BoqItem oBoqItem)
        {
            try
            {
                if (oBoqItem.Prjid != null)
                { await boqItemsService.DeleteBoqItemAsync((long)oBoqItem.Prjid); }
                else
                { }

                await boqGrid.Reload();
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