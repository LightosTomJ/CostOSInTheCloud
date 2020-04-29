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
	public class BcClassificationsService
	{
		private LocalContext localContext;

		public BcClassificationsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcClassificationCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcClassification.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcClassification>> GetAllBcClassifications()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcClassification> bcClassifications = await localContext.BcClassification.ToListAsync();
				return bcClassifications;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcClassification(List<Models.DB.Local.BcClassification> BcClassifications)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcClassification bcClassification in BcClassifications)
				{
					localContext.BcClassification.Add(bcClassification);
					await localContext.SaveChangesAsync();
					returnid = bcClassification.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcClassification(Models.DB.Local.BcClassification bcClassification)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcClassification.Update(bcClassification);
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
		public async Task<bool> DeleteBcClassification(long bcClassificationId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcClassification bcClassification = localContext.BcClassification.First(p => p.Id == bcClassificationId);
				localContext.BcClassification.Remove(bcClassification);
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
