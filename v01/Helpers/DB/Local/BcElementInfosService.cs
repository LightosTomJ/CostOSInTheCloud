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
	public class BcElementInfosService
	{
		private LocalContext localContext;

		public BcElementInfosService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcElementInfoCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcElementInfo.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcElementInfo>> GetAllBcElementInfos()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcElementInfo> bcElementInfos = await localContext.BcElementInfo.ToListAsync();
				return bcElementInfos;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcElementInfo(List<Models.DB.Local.BcElementInfo> BcElementInfos)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcElementInfo bcElementInfo in BcElementInfos)
				{
					localContext.BcElementInfo.Add(bcElementInfo);
					await localContext.SaveChangesAsync();
					returnid = bcElementInfo.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcElementInfo(Models.DB.Local.BcElementInfo bcElementInfo)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcElementInfo.Update(bcElementInfo);
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
		public async Task<bool> DeleteBcElementInfo(long bcElementInfoId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcElementInfo bcElementInfo = localContext.BcElementInfo.First(p => p.Id == bcElementInfoId);
				localContext.BcElementInfo.Remove(bcElementInfo);
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
