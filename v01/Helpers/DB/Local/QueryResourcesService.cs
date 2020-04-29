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
	public class QueryResourcesService
	{
		private LocalContext localContext;

		public QueryResourcesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> QueryResourceCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.QueryResource.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.QueryResource>> GetAllQueryResources()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.QueryResource> queryResources = await localContext.QueryResource.ToListAsync();
				return queryResources;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateQueryResource(List<Models.DB.Local.QueryResource> QueryResources)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.QueryResource queryResource in QueryResources)
				{
					localContext.QueryResource.Add(queryResource);
					await localContext.SaveChangesAsync();
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

		public async Task<bool> UpdateQueryResource(Models.DB.Local.QueryResource queryResource)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.QueryResource.Update(queryResource);
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
		public async Task<bool> DeleteQueryResource(long queryResourceId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.QueryResource queryResource = localContext.QueryResource.First(p => p.Qresid == queryResourceId);
				localContext.QueryResource.Remove(queryResource);
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
