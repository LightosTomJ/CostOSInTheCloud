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
	public class AlcUserGroupsService
	{
		private LocalContext localContext;

		public AlcUserGroupsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> AlcUserGroupsCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.AlcUserGroups.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.AlcUserGroups>> GetAllAlcUserGroups()
		{

			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.AlcUserGroups> alcUserGroups = await localContext.AlcUserGroups.ToListAsync();
				return alcUserGroups;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<Guid> CreateAlcUserGroups(List<Models.DB.Local.AlcUserGroups> AlcUserGroups)
		{
			Guid returnid = Guid.Empty;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AlcUserGroups alcUserGroups in AlcUserGroups)
				{
					localContext.AlcUserGroups.Add(alcUserGroups);
					await localContext.SaveChangesAsync();
					returnid = alcUserGroups.GroupId;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAlcUserGroups(Models.DB.Local.AlcUserGroups alcUserGroups)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AlcUserGroups.Update(alcUserGroups);
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
		public async Task<bool> DeleteAlcUserGroups(Guid alcUserGroupsId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AlcUserGroups alcUserGroups = localContext.AlcUserGroups.First(p => p.GroupId == alcUserGroupsId);
				localContext.AlcUserGroups.Remove(alcUserGroups);
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
