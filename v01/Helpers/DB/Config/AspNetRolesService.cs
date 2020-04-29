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
	public class AspNetRolesService
	{
		private ConfigContext configContext;

		public AspNetRolesService(ConfigContext dbContext)
		{
			configContext = dbContext;
		}

		public async Task<long> AspNetRolesCount()
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				return await configContext.AspNetRoles.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Config.AspNetRoles>> GetAllAspNetRoles()
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				IList<Models.DB.Config.AspNetRoles> aspNetRoles = await configContext.AspNetRoles.ToListAsync();
				return aspNetRoles;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<string> CreateAspNetRoles(List<Models.DB.Config.AspNetRoles> AspNetRoles)
		{
			string returnid = "";
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				foreach (Models.DB.Config.AspNetRoles aspNetRoles in AspNetRoles)
				{
					configContext.AspNetRoles.Add(aspNetRoles);
					await configContext.SaveChangesAsync();
					returnid = aspNetRoles.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAspNetRoles(Models.DB.Config.AspNetRoles aspNetRoles)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				configContext.AspNetRoles.Update(aspNetRoles);
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
		public async Task<bool> DeleteAspNetRoles(string aspNetRolesId)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				Models.DB.Config.AspNetRoles aspNetRoles = configContext.AspNetRoles.First(p => p.Id == aspNetRolesId);
				configContext.AspNetRoles.Remove(aspNetRoles);
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
