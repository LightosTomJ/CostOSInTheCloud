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
	public class WsFilesService
	{
		private LocalContext localContext;

		public WsFilesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> WsFileCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.WsFile.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.WsFile>> GetAllWsFiles()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.WsFile> wsFiles = await localContext.WsFile.ToListAsync();
				return wsFiles;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateWsFile(List<Models.DB.Local.WsFile> WsFiles)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.WsFile wsFile in WsFiles)
				{
					localContext.WsFile.Add(wsFile);
					await localContext.SaveChangesAsync();
					returnid = wsFile.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateWsFile(Models.DB.Local.WsFile wsFile)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.WsFile.Update(wsFile);
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
		public async Task<bool> DeleteWsFile(long wsFileId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.WsFile wsFile = localContext.WsFile.First(p => p.Id == wsFileId);
				localContext.WsFile.Remove(wsFile);
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
