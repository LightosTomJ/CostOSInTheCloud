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
	public class AlcObjectsStatusService
	{
		private LocalContext localContext;

		public AlcObjectsStatusService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> AlcObjectsStatusCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.AlcObjectsStatus.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.AlcObjectsStatus>> GetAllAlcObjectsStatus()
		{
			IList<Models.DB.Local.AlcObjectsStatus> AlcObjectsStatus = new List<Models.DB.Local.AlcObjectsStatus>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.AlcObjectsStatus> alcObjectsStatus = await localContext.AlcObjectsStatus.ToListAsync();
				return alcObjectsStatus;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<string> CreateAlcObjectsStatus(List<Models.DB.Local.AlcObjectsStatus> AlcObjectsStatus)
		{
			string returnid = "";
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AlcObjectsStatus alcObjectsStatus in AlcObjectsStatus)
				{
					localContext.AlcObjectsStatus.Add(alcObjectsStatus);
					await localContext.SaveChangesAsync();
					returnid = alcObjectsStatus.ObjId;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAlcObjectsStatus(long id, Models.DB.Local.AlcObjectsStatus alcObjectsStatus)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AlcObjectsStatus.Update(alcObjectsStatus);
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
		public async Task<bool> DeleteAlcObjectsStatus(string alcObjectsStatusId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AlcObjectsStatus alcObjectsStatus = localContext.AlcObjectsStatus.First(p => p.ObjId == alcObjectsStatusId);
				localContext.AlcObjectsStatus.Remove(alcObjectsStatus);
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
