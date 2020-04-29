using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Config
{
	public class AspNetUserRolesService
	{
		private ConfigContext configContext;

		public AspNetUserRolesService(ConfigContext dbContext)
		{
			configContext = dbContext;
		}

		public async Task<long> AspNetUserRolesCount()
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				return await configContext.AspNetUserRoles.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Config.AspNetUserRoles>> GetAllAspNetUserRoles()
		{
			IList<Models.DB.Config.AspNetUserRoles> AspNetUserRoles = new List<Models.DB.Config.AspNetUserRoles>();
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				IList<Models.DB.Config.AspNetUserRoles> aspNetUserRoles = await configContext.AspNetUserRoles.ToListAsync();
				return aspNetUserRoles;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<string> CreateAspNetUserRoles(List<Models.DB.Config.AspNetUserRoles> AspNetUserRoles)
		{
			string returnid = "";
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				foreach (Models.DB.Config.AspNetUserRoles aspNetUserRoles in AspNetUserRoles)
				{
					configContext.AspNetUserRoles.Add(aspNetUserRoles);
					await configContext.SaveChangesAsync();
					returnid = aspNetUserRoles.RoleId;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAspNetUserRoles(long id, Models.DB.Config.AspNetUserRoles aspNetUserRoles)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				configContext.AspNetUserRoles.Update(aspNetUserRoles);
				await configContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
		public async Task<bool> DeleteAspNetUserRoles(string aspNetUserRolesId)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				Models.DB.Config.AspNetUserRoles aspNetUserRoles = configContext.AspNetUserRoles.First(p => p.RoleId == aspNetUserRolesId);
				configContext.AspNetUserRoles.Remove(aspNetUserRoles);
				await configContext.SaveChangesAsync();
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
