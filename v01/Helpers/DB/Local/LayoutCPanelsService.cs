using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class LayoutCPanelsService
	{
		private LocalContext localContext;

		public LayoutCPanelsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> LayoutCPanelCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.LayoutCPanel.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.LayoutCPanel>> GetAllLayoutCPanels()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.LayoutCPanel> layoutCPanels = await localContext.LayoutCPanel.ToListAsync();
				return layoutCPanels;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateLayoutCPanel(List<Models.DB.Local.LayoutCPanel> LayoutCPanels)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.LayoutCPanel layoutCPanel in LayoutCPanels)
				{
					localContext.LayoutCPanel.Add(layoutCPanel);
					await localContext.SaveChangesAsync();
					returnid = layoutCPanel.Layoutcpanelid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateLayoutCPanel(Models.DB.Local.LayoutCPanel layoutCPanel)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.LayoutCPanel.Update(layoutCPanel);
				await localContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
		public async Task<bool> DeleteLayoutCPanel(long layoutCPanelId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.LayoutCPanel layoutCPanel = localContext.LayoutCPanel.First(p => p.Layoutcpanelid == layoutCPanelId);
				localContext.LayoutCPanel.Remove(layoutCPanel);
				await localContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
	}
}
