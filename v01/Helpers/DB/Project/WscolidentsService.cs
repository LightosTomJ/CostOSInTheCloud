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
	public class WscolidentsService
	{
		private ProjectContext projectContext;

		public WscolidentsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> WscolidentCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Wscolident.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Wscolident>> GetAllWscolidents()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Wscolident> wscolidents = await projectContext.Wscolident.ToListAsync();
				return wscolidents;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateWscolident(List<Models.DB.Project.Wscolident> WsColidents)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Wscolident wscolident in WsColidents)
				{
					projectContext.Wscolident.Add(wscolident);
					await projectContext.SaveChangesAsync();
					returnid = wscolident.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateWscolident(Models.DB.Project.Wscolident wscolident)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Wscolident.Update(wscolident);
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
		public async Task<bool> DeleteWscolident(long wscolidentId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Wscolident wscolident = projectContext.Wscolident.First(p => p.Id == wscolidentId);
				projectContext.Wscolident.Remove(wscolident);
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
