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
	public class WsRevisionsService
	{
		private ProjectContext projectContext;

		public WsRevisionsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> WsRevisionCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.WsRevision.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.WsRevision>> GetAllWsRevisions()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.WsRevision> wsRevisions = await projectContext.WsRevision.ToListAsync();
				return wsRevisions;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateWsRevision(List<Models.DB.Project.WsRevision> WsRevisions)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.WsRevision wsRevision in WsRevisions)
				{
					projectContext.WsRevision.Add(wsRevision);
					await projectContext.SaveChangesAsync();
					returnid = wsRevision.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateWsRevision(Models.DB.Project.WsRevision wsRevision)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.WsRevision.Update(wsRevision);
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
		public async Task<bool> DeleteWsRevision(long wsRevisionId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.WsRevision wsRevision = projectContext.WsRevision.First(p => p.Id == wsRevisionId);
				projectContext.WsRevision.Remove(wsRevision);
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
