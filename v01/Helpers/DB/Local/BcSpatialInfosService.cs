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
	public class BcSpatialInfosService
	{
		private LocalContext localContext;

		public BcSpatialInfosService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcSpatialInfoCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcSpatialInfo.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcSpatialInfo>> GetAllBcSpatialInfos()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcSpatialInfo> bcSpatialInfos = await localContext.BcSpatialInfo.ToListAsync();
				return bcSpatialInfos;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcSpatialInfo(List<Models.DB.Local.BcSpatialInfo> BcSpatialInfos)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcSpatialInfo bcSpatialInfo in BcSpatialInfos)
				{
					localContext.BcSpatialInfo.Add(bcSpatialInfo);
					await localContext.SaveChangesAsync();
					returnid = bcSpatialInfo.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcSpatialInfo(Models.DB.Local.BcSpatialInfo bcSpatialInfo)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcSpatialInfo.Update(bcSpatialInfo);
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
		public async Task<bool> DeleteBcSpatialInfo(long bcSpatialInfoId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcSpatialInfo bcSpatialInfo = localContext.BcSpatialInfo.First(p => p.Id == bcSpatialInfoId);
				localContext.BcSpatialInfo.Remove(bcSpatialInfo);
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
