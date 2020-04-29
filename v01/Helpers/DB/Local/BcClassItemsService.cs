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
	public class BcClassItemsService
	{
		private LocalContext localContext;

		public BcClassItemsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcClassItemCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcClassItem.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcClassItem>> GetAllBcClassItems()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcClassItem> bcClassItems = await localContext.BcClassItem.ToListAsync();
				return bcClassItems;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcClassItem(List<Models.DB.Local.BcClassItem> BcClassItems)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcClassItem bcClassItem in BcClassItems)
				{
					localContext.BcClassItem.Add(bcClassItem);
					await localContext.SaveChangesAsync();
					returnid = bcClassItem.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcClassItem(Models.DB.Local.BcClassItem bcClassItem)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcClassItem.Update(bcClassItem);
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
		public async Task<bool> DeleteBcClassItem(long bcClassItemId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcClassItem bcClassItem = localContext.BcClassItem.First(p => p.Id == bcClassItemId);
				localContext.BcClassItem.Remove(bcClassItem);
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
