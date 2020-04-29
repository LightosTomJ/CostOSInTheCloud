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
	public class BoqItemsService
	{
		private ProjectContext projectContext;

		public BoqItemsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> BoqItemCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.BoqItem.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.BoqItem>> GetAllBoqItems()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.BoqItem> boqItems = await projectContext.BoqItem.ToListAsync();
				return boqItems;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBoqItem(List<Models.DB.Project.BoqItem> BoqItems)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.BoqItem boqItem in BoqItems)
				{
					projectContext.BoqItem.Add(boqItem);
					await projectContext.SaveChangesAsync();
					returnid = boqItem.Boqitemid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBoqItem(Models.DB.Project.BoqItem boqItem)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.BoqItem.Update(boqItem);
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
		public async Task<bool> DeleteBoqItem(long boqItemId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.BoqItem boqItem = projectContext.BoqItem.First(p => p.Boqitemid == boqItemId);
				projectContext.BoqItem.Remove(boqItem);
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
