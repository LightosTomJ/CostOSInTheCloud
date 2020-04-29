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
	public class CntrLogItemsService
	{
		private LocalContext localContext;

		public CntrLogItemsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> CntrLogItemCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.CntrLogItem.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.CntrLogItem>> GetAllCntrLogItems()
		{
			IList<Models.DB.Local.CntrLogItem> CntrLogItems = new List<Models.DB.Local.CntrLogItem>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.CntrLogItem> cntrLogItems = await localContext.CntrLogItem.ToListAsync();
				return cntrLogItems;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateCntrLogItem(List<Models.DB.Local.CntrLogItem> CntrLogItems)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.CntrLogItem cntrLogItem in CntrLogItems)
				{
					localContext.CntrLogItem.Add(cntrLogItem);
					await localContext.SaveChangesAsync();
					returnid = cntrLogItem.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateCntrLogItem(long id, Models.DB.Local.CntrLogItem cntrLogItem)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.CntrLogItem.Update(cntrLogItem);
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
		public async Task<bool> DeleteCntrLogItem(long cntrLogItemId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.CntrLogItem cntrLogItem = localContext.CntrLogItem.First(p => p.Id == cntrLogItemId);
				localContext.CntrLogItem.Remove(cntrLogItem);
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
