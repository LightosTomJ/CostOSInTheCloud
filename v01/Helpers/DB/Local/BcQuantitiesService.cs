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
	public class BcQuantitiesService
	{
		private LocalContext localContext;

		public BcQuantitiesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcQuantityCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcQuantity.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcQuantity>> GetAllBcQuantities()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcQuantity> bcQuantities = await localContext.BcQuantity.ToListAsync();
				return bcQuantities;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcQuantity(List<Models.DB.Local.BcQuantity> BcQuantities)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcQuantity bcQuantity in BcQuantities)
				{
					localContext.BcQuantity.Add(bcQuantity);
					await localContext.SaveChangesAsync();
					returnid = bcQuantity.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcQuantity(Models.DB.Local.BcQuantity bcQuantity)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcQuantity.Update(bcQuantity);
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
		public async Task<bool> DeleteBcQuantity(long bcQuantityId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcQuantity bcQuantity = localContext.BcQuantity.First(p => p.Id == bcQuantityId);
				localContext.BcQuantity.Remove(bcQuantity);
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
