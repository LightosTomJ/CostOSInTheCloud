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
	public class LictblsService
	{
		private LocalContext localContext;

		public LictblsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> LictblCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Lictbl.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Lictbl>> GetAllLictbls()
		{
			IList<Models.DB.Local.Lictbl> Lictbls = new List<Models.DB.Local.Lictbl>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Lictbl> lictbls = await localContext.Lictbl.ToListAsync();
				return lictbls;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateLictbl(List<Models.DB.Local.Lictbl> Lictbls)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Lictbl lictbl in Lictbls)
				{
					localContext.Lictbl.Add(lictbl);
					await localContext.SaveChangesAsync();
					returnid = lictbl.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateLictbl(long id, Models.DB.Local.Lictbl lictbl)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Lictbl.Update(lictbl);
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
		public async Task<bool> DeleteLictbl(long lictblId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Lictbl lictbl = localContext.Lictbl.First(p => p.Id == lictblId);
				localContext.Lictbl.Remove(lictbl);
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
