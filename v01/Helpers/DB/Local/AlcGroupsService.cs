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
	public class AlcGroupsService
	{
		private LocalContext localContext;

		public AlcGroupsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> AlcGroupsCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.AlcGroups.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.AlcGroups>> GetAllAlcGroups()
		{
			IList<Models.DB.Local.AlcGroups> AlcGroups = new List<Models.DB.Local.AlcGroups>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.AlcGroups> alcGroups = await localContext.AlcGroups.ToListAsync();
				return alcGroups;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<Guid> CreateAlcGroups(List<Models.DB.Local.AlcGroups> AlcGroups)
		{
			Guid returnid;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AlcGroups alcGroups in AlcGroups)
				{
					localContext.AlcGroups.Add(alcGroups);
					await localContext.SaveChangesAsync();
					returnid = alcGroups.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return Guid.Empty;
		}

		public async Task<bool> UpdateAlcGroups(long id, Models.DB.Local.AlcGroups alcGroups)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AlcGroups.Update(alcGroups);
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
		public async Task<bool> DeleteAlcGroups(Guid alcGroupsId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AlcGroups alcGroups = localContext.AlcGroups.First(p => p.Id == alcGroupsId);
				localContext.AlcGroups.Remove(alcGroups);
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
