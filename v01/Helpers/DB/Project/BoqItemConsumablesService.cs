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
	public class BoqItemConsumablesService
	{
		private ProjectContext projectContext;

		public BoqItemConsumablesService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> BoqItemConsumableCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.BoqItemConsumable.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.BoqItemConsumable>> GetAllBoqItemConsumables()
		{
			IList<Models.DB.Project.BoqItemConsumable> BoqItemConsumables = new List<Models.DB.Project.BoqItemConsumable>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.BoqItemConsumable> boqItemConsumables = await projectContext.BoqItemConsumable.ToListAsync();
				return boqItemConsumables;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBoqItemConsumable(List<Models.DB.Project.BoqItemConsumable> BoqItemConsumables)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.BoqItemConsumable boqItemConsumable in BoqItemConsumables)
				{
					projectContext.BoqItemConsumable.Add(boqItemConsumable);
					await projectContext.SaveChangesAsync();
					returnid = boqItemConsumable.Boqitemconsumableid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBoqItemConsumable(long id, Models.DB.Project.BoqItemConsumable boqItemConsumable)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.BoqItemConsumable.Update(boqItemConsumable);
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
		public async Task<bool> DeleteBoqItemConsumable(long boqItemConsumableId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.BoqItemConsumable boqItemConsumable = projectContext.BoqItemConsumable.First(p => p.Boqitemconsumableid == boqItemConsumableId);
				projectContext.BoqItemConsumable.Remove(boqItemConsumable);
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
