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
	public class XcellFilesService
	{
		private ProjectContext projectContext;

		public XcellFilesService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> XcellFileCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.XcellFile.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.XcellFile>> GetAllXcellFiles()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.XcellFile> xcellFiles = await projectContext.XcellFile.ToListAsync();
				return xcellFiles;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateXcellFile(List<Models.DB.Project.XcellFile> XcellFiles)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.XcellFile xcellFile in XcellFiles)
				{
					projectContext.XcellFile.Add(xcellFile);
					await projectContext.SaveChangesAsync();
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

		public async Task<bool> UpdateXcellFile(Models.DB.Project.XcellFile xcellFile)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.XcellFile.Update(xcellFile);
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
		public async Task<bool> DeleteXcellFile(long xcellFileId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.XcellFile xcellFile = projectContext.XcellFile.First(p => p.Xcellid == xcellFileId);
				projectContext.XcellFile.Remove(xcellFile);
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
