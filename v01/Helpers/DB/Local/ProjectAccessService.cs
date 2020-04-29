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
	public class ProjectAccessService
	{
		private LocalContext localContext;

		public ProjectAccessService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> ProjectAccessCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.ProjectAccess.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.ProjectAccess>> GetAllProjectAccess()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.ProjectAccess> projectAccess = await localContext.ProjectAccess.ToListAsync();
				return projectAccess;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateProjectAccess(List<Models.DB.Local.ProjectAccess> ProjectAccess)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.ProjectAccess projectAccess in ProjectAccess)
				{
					localContext.ProjectAccess.Add(projectAccess);
					await localContext.SaveChangesAsync();
					returnid = projectAccess.Paid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateProjectAccess(Models.DB.Local.ProjectAccess projectAccess)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.ProjectAccess.Update(projectAccess);
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
		public async Task<bool> DeleteProjectAccess(long projectAccessId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.ProjectAccess projectAccess = localContext.ProjectAccess.First(p => p.Paid == projectAccessId);
				localContext.ProjectAccess.Remove(projectAccess);
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
