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
	public class ConsumablesService
	{
		private ProjectContext projectContext;

		public ConsumablesService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> ConsumableCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Consumable.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Consumable>> GetAllConsumables()
		{
			IList<Models.DB.Project.Consumable> Consumables = new List<Models.DB.Project.Consumable>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Consumable> consumables = await projectContext.Consumable.ToListAsync();
				return consumables;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateConsumable(List<Models.DB.Project.Consumable> Consumables)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Consumable consumable in Consumables)
				{
					projectContext.Consumable.Add(consumable);
					await projectContext.SaveChangesAsync();
					returnid = consumable.Consumableid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateConsumable(long id, Models.DB.Project.Consumable consumable)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Consumable.Update(consumable);
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
		public async Task<bool> DeleteConsumable(long consumableId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Consumable consumable = projectContext.Consumable.First(p => p.Consumableid == consumableId);
				projectContext.Consumable.Remove(consumable);
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
