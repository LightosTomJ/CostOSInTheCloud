using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class ParamItemsService
	{
		private ProjectContext projectContext;

		public ParamItemsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> ParamItemCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.ParamItem.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.ParamItem>> GetAllParamItems()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.ParamItem> paramItems = await projectContext.ParamItem.ToListAsync();
				return paramItems;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateParamItem(List<Models.DB.Project.ParamItem> ParamItems)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.ParamItem paramItem in ParamItems)
				{
					projectContext.ParamItem.Add(paramItem);
					await projectContext.SaveChangesAsync();
					returnid = paramItem.Paramitemid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateParamItem(Models.DB.Project.ParamItem paramItem)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.ParamItem.Update(paramItem);
				await projectContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
		public async Task<bool> DeleteParamItem(long paramItemId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.ParamItem paramItem = projectContext.ParamItem.First(p => p.Paramitemid == paramItemId);
				projectContext.ParamItem.Remove(paramItem);
				await projectContext.SaveChangesAsync();
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
