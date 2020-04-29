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
	public class ExtDatasourcesService
	{
		private LocalContext localContext;

		public ExtDatasourcesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> ExtDatasourceCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.ExtDatasource.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.ExtDatasource>> GetAllExtDatasources()
		{
			IList<Models.DB.Local.ExtDatasource> ExtDatasources = new List<Models.DB.Local.ExtDatasource>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.ExtDatasource> extDatasources = await localContext.ExtDatasource.ToListAsync();
				return extDatasources;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateExtDatasource(List<Models.DB.Local.ExtDatasource> ExtDatasources)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.ExtDatasource extDatasource in ExtDatasources)
				{
					localContext.ExtDatasource.Add(extDatasource);
					await localContext.SaveChangesAsync();
					returnid = extDatasource.Datasourceid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateExtDatasource(long id, Models.DB.Local.ExtDatasource extDatasource)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.ExtDatasource.Update(extDatasource);
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
		public async Task<bool> DeleteExtDatasource(long extDatasourceId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.ExtDatasource extDatasource = localContext.ExtDatasource.First(p => p.Datasourceid == extDatasourceId);
				localContext.ExtDatasource.Remove(extDatasource);
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
