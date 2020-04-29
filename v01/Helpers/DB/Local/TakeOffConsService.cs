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
	public class TakeOffConsService
	{
		private LocalContext localContext;

		public TakeOffConsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> TakeOffConCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.TakeOffCon.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.TakeOffCon>> GetAllTakeOffCons()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.TakeOffCon> takeOffCons = await localContext.TakeOffCon.ToListAsync();
				return takeOffCons;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateTakeOffCon(List<Models.DB.Local.TakeOffCon> TakeOffCons)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.TakeOffCon takeOffCon in TakeOffCons)
				{
					localContext.TakeOffCon.Add(takeOffCon);
					await localContext.SaveChangesAsync();
					returnid = takeOffCon.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateTakeOffCon(Models.DB.Local.TakeOffCon takeOffCon)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.TakeOffCon.Update(takeOffCon);
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
		public async Task<bool> DeleteTakeOffCon(long takeOffConId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.TakeOffCon takeOffCon = localContext.TakeOffCon.First(p => p.Id == takeOffConId);
				localContext.TakeOffCon.Remove(takeOffCon);
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
