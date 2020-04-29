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
	public class RolesService
	{
		private LocalContext localContext;

		public RolesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> RolesCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Roles.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Roles>> GetAllRoles()
		{
			IList<Models.DB.Local.Roles> Roles = new List<Models.DB.Local.Roles>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Roles> roles = await localContext.Roles.ToListAsync();
				return roles;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<string> CreateRoles(List<Models.DB.Local.Roles> Roles)
		{
			string returnid = "";
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Roles roles in Roles)
				{
					localContext.Roles.Add(roles);
					await localContext.SaveChangesAsync();
					returnid = roles.Roleid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateRoles(long id, Models.DB.Local.Roles roles)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Roles.Update(roles);
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
		public async Task<bool> DeleteRoles(string rolesId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Roles roles = localContext.Roles.First(p => p.Roleid == rolesId);
				localContext.Roles.Remove(roles);
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
