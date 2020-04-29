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
	public class AspNetRoleClaimsService
	{
		private ConfigContext configContext;

		public AspNetRoleClaimsService(ConfigContext dbContext)
		{
			configContext = dbContext;
		}

		public async Task<long> AspNetRoleClaimsCount()
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				return await configContext.AspNetRoleClaims.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Config.AspNetRoleClaims>> GetAllAspNetRoleClaims()
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				IList<Models.DB.Config.AspNetRoleClaims> aspNetRoleClaims = await configContext.AspNetRoleClaims.ToListAsync();
				return aspNetRoleClaims;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateAspNetRoleClaims(List<Models.DB.Config.AspNetRoleClaims> AspNetRoleClaims)
		{
			long returnid = -1;
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				foreach (Models.DB.Config.AspNetRoleClaims aspNetRoleClaims in AspNetRoleClaims)
				{
					configContext.AspNetRoleClaims.Add(aspNetRoleClaims);
					await configContext.SaveChangesAsync();
					returnid = aspNetRoleClaims.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAspNetRoleClaims(Models.DB.Config.AspNetRoleClaims aspNetRoleClaims)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				configContext.AspNetRoleClaims.Update(aspNetRoleClaims);
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
		public async Task<bool> DeleteAspNetRoleClaims(long aspNetRoleClaimsId)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				Models.DB.Config.AspNetRoleClaims aspNetRoleClaims = configContext.AspNetRoleClaims.First(p => p.Id == aspNetRoleClaimsId);
				configContext.AspNetRoleClaims.Remove(aspNetRoleClaims);
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
