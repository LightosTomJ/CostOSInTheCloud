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
	public class TakeOffPointsService
	{
		private LocalContext localContext;

		public TakeOffPointsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> TakeOffPointCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.TakeOffPoint.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.TakeOffPoint>> GetAllTakeOffPoints()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.TakeOffPoint> takeOffPoints = await localContext.TakeOffPoint.ToListAsync();
				return takeOffPoints;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateTakeOffPoint(List<Models.DB.Local.TakeOffPoint> TakeOffPoints)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.TakeOffPoint takeOffPoint in TakeOffPoints)
				{
					localContext.TakeOffPoint.Add(takeOffPoint);
					await localContext.SaveChangesAsync();
					returnid = takeOffPoint.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateTakeOffPoint(Models.DB.Local.TakeOffPoint takeOffPoint)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.TakeOffPoint.Update(takeOffPoint);
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
		public async Task<bool> DeleteTakeOffPoint(long takeOffPointId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.TakeOffPoint takeOffPoint = localContext.TakeOffPoint.First(p => p.Id == takeOffPointId);
				localContext.TakeOffPoint.Remove(takeOffPoint);
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
