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
	public class BcElemCoveringsService
	{
		private LocalContext localContext;

		public BcElemCoveringsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcElemCoveringCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcElemCovering.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcElemCovering>> GetAllBcElemCoverings()
		{
			IList<Models.DB.Local.BcElemCovering> BcElemCoverings = new List<Models.DB.Local.BcElemCovering>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcElemCovering> bcElemCoverings = await localContext.BcElemCovering.ToListAsync();
				return bcElemCoverings;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcElemCovering(List<Models.DB.Local.BcElemCovering> BcElemCoverings)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcElemCovering bcElemCovering in BcElemCoverings)
				{
					localContext.BcElemCovering.Add(bcElemCovering);
					await localContext.SaveChangesAsync();
					returnid = bcElemCovering.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcElemCovering(long id, Models.DB.Local.BcElemCovering bcElemCovering)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcElemCovering.Update(bcElemCovering);
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
		public async Task<bool> DeleteBcElemCovering(long bcElemCoveringId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcElemCovering bcElemCovering = localContext.BcElemCovering.First(p => p.Id == bcElemCoveringId);
				localContext.BcElemCovering.Remove(bcElemCovering);
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
