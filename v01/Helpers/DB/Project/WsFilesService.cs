using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class WsFilesService
	{
		private ProjectContext projectContext;

		public WsFilesService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> WsFileCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.WsFile.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.WsFile>> GetAllWsFiles()
		{
			IList<Models.DB.Project.WsFile> WsFiles = new List<Models.DB.Project.WsFile>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.WsFile> wsFiles = await projectContext.WsFile.ToListAsync();
				return wsFiles;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateWsFile(List<Models.DB.Project.WsFile> WsFiles)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.WsFile wsFile in WsFiles)
				{
					projectContext.WsFile.Add(wsFile);
					await projectContext.SaveChangesAsync();
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

		public async Task<bool> UpdateWsFile(long id, Models.DB.Project.WsFile wsFile)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.WsFile.Update(wsFile);
				await projectContext.SaveChangesAsync();
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
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.WsFile wsFile = projectContext.WsFile.First(p => p.Id == wsFileId);
				projectContext.WsFile.Remove(wsFile);
				await projectContext.SaveChangesAsync();
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
