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
	public class BcGeometriesService
	{
		private LocalContext localContext;

		public BcGeometriesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcGeometryCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcGeometry.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcGeometry>> GetAllBcGeometries()
		{
			IList<Models.DB.Local.BcGeometry> BcGeometries = new List<Models.DB.Local.BcGeometry>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcGeometry> bcGeometries = await localContext.BcGeometry.ToListAsync();
				return bcGeometries;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcGeometry(List<Models.DB.Local.BcGeometry> BcGeometries)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcGeometry bcGeometry in BcGeometries)
				{
					localContext.BcGeometry.Add(bcGeometry);
					await localContext.SaveChangesAsync();
					returnid = bcGeometry.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcGeometry(long id, Models.DB.Local.BcGeometry bcGeometry)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcGeometry.Update(bcGeometry);
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
		public async Task<bool> DeleteBcGeometry(long bcGeometryId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcGeometry bcGeometry = localContext.BcGeometry.First(p => p.Id == bcGeometryId);
				localContext.BcGeometry.Remove(bcGeometry);
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
