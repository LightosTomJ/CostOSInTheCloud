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
	public class BcElemClassItemsService
	{
		private LocalContext localContext;

		public BcElemClassItemsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcElemClassItemCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcElemClassItem.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcElemClassItem>> GetAllBcElemClassItems()
		{
			IList<Models.DB.Local.BcElemClassItem> BcElemClassItems = new List<Models.DB.Local.BcElemClassItem>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcElemClassItem> bcElemClassItems = await localContext.BcElemClassItem.ToListAsync();
				return bcElemClassItems;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcElemClassItem(List<Models.DB.Local.BcElemClassItem> BcElemClassItems)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcElemClassItem bcElemClassItem in BcElemClassItems)
				{
					localContext.BcElemClassItem.Add(bcElemClassItem);
					await localContext.SaveChangesAsync();
					returnid = bcElemClassItem.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcElemClassItem(long id, Models.DB.Local.BcElemClassItem bcElemClassItem)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcElemClassItem.Update(bcElemClassItem);
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
		public async Task<bool> DeleteBcElemClassItem(long bcElemClassItemId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcElemClassItem bcElemClassItem = localContext.BcElemClassItem.First(p => p.Id == bcElemClassItemId);
				localContext.BcElemClassItem.Remove(bcElemClassItem);
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
