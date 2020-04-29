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
	public class BcElemPropsService
	{
		private LocalContext localContext;

		public BcElemPropsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcElemPropCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcElemProp.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcElemProp>> GetAllBcElemProps()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcElemProp> bcElemProps = await localContext.BcElemProp.ToListAsync();
				return bcElemProps;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcElemProp(List<Models.DB.Local.BcElemProp> BcElemProps)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcElemProp bcElemProp in BcElemProps)
				{
					localContext.BcElemProp.Add(bcElemProp);
					await localContext.SaveChangesAsync();
					returnid = bcElemProp.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcElemProp(Models.DB.Local.BcElemProp bcElemProp)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcElemProp.Update(bcElemProp);
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
		public async Task<bool> DeleteBcElemProp(long bcElemPropId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcElemProp bcElemProp = localContext.BcElemProp.First(p => p.Id == bcElemPropId);
				localContext.BcElemProp.Remove(bcElemProp);
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
