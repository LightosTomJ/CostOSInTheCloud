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
	public class XcellFilesService
	{
		private LocalContext localContext;

		public XcellFilesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> XcellFileCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.XcellFile.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.XcellFile>> GetAllXcellFiles()
		{
			IList<Models.DB.Local.XcellFile> XcellFiles = new List<Models.DB.Local.XcellFile>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.XcellFile> xcellFiles = await localContext.XcellFile.ToListAsync();
				return xcellFiles;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateXcellFile(List<Models.DB.Local.XcellFile> XcellFiles)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.XcellFile xcellFile in XcellFiles)
				{
					localContext.XcellFile.Add(xcellFile);
					await localContext.SaveChangesAsync();
					returnid = xcellFile.Xcellid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateXcellFile(long id, Models.DB.Local.XcellFile xcellFile)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.XcellFile.Update(xcellFile);
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
		public async Task<bool> DeleteXcellFile(long xcellFileId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.XcellFile xcellFile = localContext.XcellFile.First(p => p.Xcellid == xcellFileId);
				localContext.XcellFile.Remove(xcellFile);
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
