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
	public class ConsumablesService
	{
		private LocalContext localContext;

		public ConsumablesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> ConsumableCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Consumable.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Consumable>> GetAllConsumables()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Consumable> consumables = await localContext.Consumable.ToListAsync();
				return consumables;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateConsumable(List<Models.DB.Local.Consumable> Consumables)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Consumable consumable in Consumables)
				{
					localContext.Consumable.Add(consumable);
					await localContext.SaveChangesAsync();
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

		public async Task<bool> UpdateConsumable(Models.DB.Local.Consumable consumable)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Consumable.Update(consumable);
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
		public async Task<bool> DeleteConsumable(long consumableId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Consumable consumable = localContext.Consumable.First(p => p.Consumableid == consumableId);
				localContext.Consumable.Remove(consumable);
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
