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
	public class ExtQueriesService
	{
		private LocalContext localContext;

		public ExtQueriesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> ExtQueryCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.ExtQuery.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.ExtQuery>> GetAllExtQueries()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.ExtQuery> extQueries = await localContext.ExtQuery.ToListAsync();
				return extQueries;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateExtQuery(List<Models.DB.Local.ExtQuery> ExtQueries)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.ExtQuery extQuery in ExtQueries)
				{
					localContext.ExtQuery.Add(extQuery);
					await localContext.SaveChangesAsync();
					returnid = extQuery.Queryid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateExtQuery(Models.DB.Local.ExtQuery extQuery)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.ExtQuery.Update(extQuery);
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
		public async Task<bool> DeleteExtQuery(long extQueryId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.ExtQuery extQuery = localContext.ExtQuery.First(p => p.Queryid == extQueryId);
				localContext.ExtQuery.Remove(extQuery);
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
