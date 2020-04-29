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
	public class TakeOffAreasService
	{
		private LocalContext localContext;

		public TakeOffAreasService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> TakeOffAreaCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.TakeOffArea.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.TakeOffArea>> GetAllTakeOffAreas()
		{
			IList<Models.DB.Local.TakeOffArea> TakeOffAreas = new List<Models.DB.Local.TakeOffArea>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.TakeOffArea> takeOffAreas = await localContext.TakeOffArea.ToListAsync();
				return takeOffAreas;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateTakeOffArea(List<Models.DB.Local.TakeOffArea> TakeOffAreas)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.TakeOffArea takeOffArea in TakeOffAreas)
				{
					localContext.TakeOffArea.Add(takeOffArea);
					await localContext.SaveChangesAsync();
					returnid = takeOffArea.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateTakeOffArea(long id, Models.DB.Local.TakeOffArea takeOffArea)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.TakeOffArea.Update(takeOffArea);
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
		public async Task<bool> DeleteTakeOffArea(long takeOffAreaId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.TakeOffArea takeOffArea = localContext.TakeOffArea.First(p => p.Id == takeOffAreaId);
				localContext.TakeOffArea.Remove(takeOffArea);
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
