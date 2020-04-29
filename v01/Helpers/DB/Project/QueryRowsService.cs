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
	public class QueryRowsService
	{
		private ProjectContext projectContext;

		public QueryRowsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> QueryRowCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.QueryRow.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.QueryRow>> GetAllQueryRows()
		{
			IList<Models.DB.Project.QueryRow> QueryRows = new List<Models.DB.Project.QueryRow>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.QueryRow> queryRows = await projectContext.QueryRow.ToListAsync();
				return queryRows;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateQueryRow(List<Models.DB.Project.QueryRow> QueryRows)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.QueryRow queryRow in QueryRows)
				{
					projectContext.QueryRow.Add(queryRow);
					await projectContext.SaveChangesAsync();
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

		public async Task<bool> UpdateQueryRow(long id, Models.DB.Project.QueryRow queryRow)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.QueryRow.Update(queryRow);
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
		public async Task<bool> DeleteQueryRow(long queryRowId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.QueryRow queryRow = projectContext.QueryRow.First(p => p.Qrowid == queryRowId);
				projectContext.QueryRow.Remove(queryRow);
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
