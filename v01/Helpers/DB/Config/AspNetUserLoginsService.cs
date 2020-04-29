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
	public class AspNetUserLoginsService
	{
		private ConfigContext configContext;

		public AspNetUserLoginsService(ConfigContext dbContext)
		{
			configContext = dbContext;
		}

		public async Task<long> AspNetUserLoginsCount()
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				return await configContext.AspNetUserLogins.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Config.AspNetUserLogins>> GetAllAspNetUserLogins()
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				IList<Models.DB.Config.AspNetUserLogins> aspNetUserLogins = await configContext.AspNetUserLogins.ToListAsync();
				return aspNetUserLogins;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<string> CreateAspNetUserLogins(List<Models.DB.Config.AspNetUserLogins> AspNetUserLogins)
		{
			string returnid = "";
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				foreach (Models.DB.Config.AspNetUserLogins aspNetUserLogins in AspNetUserLogins)
				{
					configContext.AspNetUserLogins.Add(aspNetUserLogins);
					await configContext.SaveChangesAsync();
					returnid = aspNetUserLogins.UserId;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAspNetUserLogins(Models.DB.Config.AspNetUserLogins aspNetUserLogins)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				configContext.AspNetUserLogins.Update(aspNetUserLogins);
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
		public async Task<bool> DeleteAspNetUserLogins(string aspNetUserLoginsId)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				Models.DB.Config.AspNetUserLogins aspNetUserLogins = configContext.AspNetUserLogins.First(p => p.UserId == aspNetUserLoginsId);
				configContext.AspNetUserLogins.Remove(aspNetUserLogins);
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
