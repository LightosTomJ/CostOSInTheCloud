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
	public class ParamItemsService
	{
		private LocalContext localContext;

		public ParamItemsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> ParamItemCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.ParamItem.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.ParamItem>> GetAllParamItems()
		{
			IList<Models.DB.Local.ParamItem> ParamItems = new List<Models.DB.Local.ParamItem>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.ParamItem> paramItems = await localContext.ParamItem.ToListAsync();
				return paramItems;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateParamItem(List<Models.DB.Local.ParamItem> ParamItems)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.ParamItem paramItem in ParamItems)
				{
					localContext.ParamItem.Add(paramItem);
					await localContext.SaveChangesAsync();
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

		public async Task<bool> UpdateParamItem(long id, Models.DB.Local.ParamItem paramItem)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.ParamItem.Update(paramItem);
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
		public async Task<bool> DeleteParamItem(long paramItemId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.ParamItem paramItem = localContext.ParamItem.First(p => p.Paramitemid == paramItemId);
				localContext.ParamItem.Remove(paramItem);
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
