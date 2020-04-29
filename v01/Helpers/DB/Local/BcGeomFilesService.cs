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
	public class BcGeomFilesService
	{
		private LocalContext localContext;

		public BcGeomFilesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcGeomFileCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcGeomFile.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcGeomFile>> GetAllBcGeomFiles()
		{
			IList<Models.DB.Local.BcGeomFile> BcGeomFiles = new List<Models.DB.Local.BcGeomFile>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcGeomFile> bcGeomFiles = await localContext.BcGeomFile.ToListAsync();
				return bcGeomFiles;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcGeomFile(List<Models.DB.Local.BcGeomFile> BcGeomFiles)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcGeomFile bcGeomFile in BcGeomFiles)
				{
					localContext.BcGeomFile.Add(bcGeomFile);
					await localContext.SaveChangesAsync();
					returnid = bcGeomFile.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcGeomFile(long id, Models.DB.Local.BcGeomFile bcGeomFile)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcGeomFile.Update(bcGeomFile);
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
		public async Task<bool> DeleteBcGeomFile(long bcGeomFileId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcGeomFile bcGeomFile = localContext.BcGeomFile.First(p => p.Id == bcGeomFileId);
				localContext.BcGeomFile.Remove(bcGeomFile);
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
