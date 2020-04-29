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
	public class TakeOffLegendsService
	{
		private LocalContext localContext;

		public TakeOffLegendsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> TakeOffLegendCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.TakeOffLegend.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.TakeOffLegend>> GetAllTakeOffLegends()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.TakeOffLegend> takeOffLegends = await localContext.TakeOffLegend.ToListAsync();
				return takeOffLegends;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateTakeOffLegend(List<Models.DB.Local.TakeOffLegend> TakeOffLegends)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.TakeOffLegend takeOffLegend in TakeOffLegends)
				{
					localContext.TakeOffLegend.Add(takeOffLegend);
					await localContext.SaveChangesAsync();
					returnid = takeOffLegend.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateTakeOffLegend(Models.DB.Local.TakeOffLegend takeOffLegend)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.TakeOffLegend.Update(takeOffLegend);
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
		public async Task<bool> DeleteTakeOffLegend(long takeOffLegendId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.TakeOffLegend takeOffLegend = localContext.TakeOffLegend.First(p => p.Id == takeOffLegendId);
				localContext.TakeOffLegend.Remove(takeOffLegend);
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
