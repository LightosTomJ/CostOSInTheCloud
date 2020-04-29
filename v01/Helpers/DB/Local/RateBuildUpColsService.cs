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
	public class RateBuildUpColsService
	{
		private LocalContext localContext;

		public RateBuildUpColsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> RateBuildUpColsCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.RateBuildUpCols.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.RateBuildUpCols>> GetAllRateBuildUpCols()
		{
			IList<Models.DB.Local.RateBuildUpCols> RateBuildUpCols = new List<Models.DB.Local.RateBuildUpCols>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.RateBuildUpCols> rateBuildUpCols = await localContext.RateBuildUpCols.ToListAsync();
				return rateBuildUpCols;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateRateBuildUpCols(List<Models.DB.Local.RateBuildUpCols> RateBuildUpCols)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.RateBuildUpCols rateBuildUpCols in RateBuildUpCols)
				{
					localContext.RateBuildUpCols.Add(rateBuildUpCols);
					await localContext.SaveChangesAsync();
					returnid = rateBuildUpCols.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateRateBuildUpCols(long id, Models.DB.Local.RateBuildUpCols rateBuildUpCols)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.RateBuildUpCols.Update(rateBuildUpCols);
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
		public async Task<bool> DeleteRateBuildUpCols(long rateBuildUpColsId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.RateBuildUpCols rateBuildUpCols = localContext.RateBuildUpCols.First(p => p.Id == rateBuildUpColsId);
				localContext.RateBuildUpCols.Remove(rateBuildUpCols);
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
