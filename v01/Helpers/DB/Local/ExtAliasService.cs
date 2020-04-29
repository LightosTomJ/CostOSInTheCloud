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
	public class ExtAliasService
	{
		private LocalContext localContext;

		public ExtAliasService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> ExtAliasCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.ExtAlias.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.ExtAlias>> GetAllExtAlias()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.ExtAlias> extAlias = await localContext.ExtAlias.ToListAsync();
				return extAlias;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateExtAlias(List<Models.DB.Local.ExtAlias> ExtAlias)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.ExtAlias extAlias in ExtAlias)
				{
					localContext.ExtAlias.Add(extAlias);
					await localContext.SaveChangesAsync();
					returnid = extAlias.Aliasid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateExtAlias(Models.DB.Local.ExtAlias extAlias)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.ExtAlias.Update(extAlias);
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
		public async Task<bool> DeleteExtAlias(long extAliasId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.ExtAlias extAlias = localContext.ExtAlias.First(p => p.Aliasid == extAliasId);
				localContext.ExtAlias.Remove(extAlias);
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
