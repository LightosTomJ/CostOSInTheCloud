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
	public class QueryResourcesService
	{
		private ProjectContext projectContext;

		public QueryResourcesService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> QueryResourceCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.QueryResource.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.QueryResource>> GetAllQueryResources()
		{
			IList<Models.DB.Project.QueryResource> QueryResources = new List<Models.DB.Project.QueryResource>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.QueryResource> queryResources = await projectContext.QueryResource.ToListAsync();
				return queryResources;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateQueryResource(List<Models.DB.Project.QueryResource> QueryResources)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.QueryResource queryResource in QueryResources)
				{
					projectContext.QueryResource.Add(queryResource);
					await projectContext.SaveChangesAsync();
					returnid = queryResource.Qresid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateQueryResource(long id, Models.DB.Project.QueryResource queryResource)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.QueryResource.Update(queryResource);
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
		public async Task<bool> DeleteQueryResource(long queryResourceId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.QueryResource queryResource = projectContext.QueryResource.First(p => p.Qresid == queryResourceId);
				projectContext.QueryResource.Remove(queryResource);
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
