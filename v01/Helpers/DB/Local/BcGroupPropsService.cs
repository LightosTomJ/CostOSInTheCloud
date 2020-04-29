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
	public class BcGroupPropsService
	{
		private LocalContext localContext;

		public BcGroupPropsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcGroupPropCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcGroupProp.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcGroupProp>> GetAllBcGroupProps()
		{
			IList<Models.DB.Local.BcGroupProp> BcGroupProps = new List<Models.DB.Local.BcGroupProp>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcGroupProp> bcGroupProps = await localContext.BcGroupProp.ToListAsync();
				return bcGroupProps;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcGroupProp(List<Models.DB.Local.BcGroupProp> BcGroupProps)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcGroupProp bcGroupProp in BcGroupProps)
				{
					localContext.BcGroupProp.Add(bcGroupProp);
					await localContext.SaveChangesAsync();
					returnid = bcGroupProp.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcGroupProp(long id, Models.DB.Local.BcGroupProp bcGroupProp)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcGroupProp.Update(bcGroupProp);
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
		public async Task<bool> DeleteBcGroupProp(long bcGroupPropId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcGroupProp bcGroupProp = localContext.BcGroupProp.First(p => p.Id == bcGroupPropId);
				localContext.BcGroupProp.Remove(bcGroupProp);
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
