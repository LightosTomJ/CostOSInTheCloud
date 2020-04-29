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
	public class QueryRowsService
	{
		private LocalContext localContext;

		public QueryRowsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> QueryRowCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.QueryRow.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.QueryRow>> GetAllQueryRows()
		{
			IList<Models.DB.Local.QueryRow> QueryRows = new List<Models.DB.Local.QueryRow>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.QueryRow> queryRows = await localContext.QueryRow.ToListAsync();
				return queryRows;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateQueryRow(List<Models.DB.Local.QueryRow> QueryRows)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.QueryRow queryRow in QueryRows)
				{
					localContext.QueryRow.Add(queryRow);
					await localContext.SaveChangesAsync();
					returnid = queryRow.Qrowid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateQueryRow(long id, Models.DB.Local.QueryRow queryRow)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.QueryRow.Update(queryRow);
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
		public async Task<bool> DeleteQueryRow(long queryRowId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.QueryRow queryRow = localContext.QueryRow.First(p => p.Qrowid == queryRowId);
				localContext.QueryRow.Remove(queryRow);
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
