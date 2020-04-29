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
	public class OSTDBConsService
	{
		private ProjectContext projectContext;

		public OSTDBConsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> OSTDBConCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.OSTDBCon.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.OSTDBCon>> GetAllOSTDBCons()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.OSTDBCon> oSTDBCons = await projectContext.OSTDBCon.ToListAsync();
				return oSTDBCons;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateOSTDBCon(List<Models.DB.Project.OSTDBCon> OSTDBCons)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.OSTDBCon oSTDBCon in OSTDBCons)
				{
					projectContext.OSTDBCon.Add(oSTDBCon);
					await projectContext.SaveChangesAsync();
					returnid = oSTDBCon.Ostconid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateOSTDBCon(Models.DB.Project.OSTDBCon oSTDBCon)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.OSTDBCon.Update(oSTDBCon);
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
		public async Task<bool> DeleteOSTDBCon(long oSTDBConId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.OSTDBCon oSTDBCon = projectContext.OSTDBCon.First(p => p.Ostconid == oSTDBConId);
				projectContext.OSTDBCon.Remove(oSTDBCon);
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
