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
	public class CntrLogsService
	{
		private LocalContext localContext;

		public CntrLogsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> CntrLogCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.CntrLog.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.CntrLog>> GetAllCntrLogs()
		{
			IList<Models.DB.Local.CntrLog> CntrLogs = new List<Models.DB.Local.CntrLog>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.CntrLog> cntrLogs = await localContext.CntrLog.ToListAsync();
				return cntrLogs;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateCntrLog(List<Models.DB.Local.CntrLog> CntrLogs)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.CntrLog cntrLog in CntrLogs)
				{
					localContext.CntrLog.Add(cntrLog);
					await localContext.SaveChangesAsync();
					returnid = cntrLog.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateCntrLog(long id, Models.DB.Local.CntrLog cntrLog)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.CntrLog.Update(cntrLog);
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
		public async Task<bool> DeleteCntrLog(long cntrLogId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.CntrLog cntrLog = localContext.CntrLog.First(p => p.Id == cntrLogId);
				localContext.CntrLog.Remove(cntrLog);
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
