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
	public class AspNetUsersService
	{
		private ConfigContext configContext;

		public AspNetUsersService(ConfigContext dbContext)
		{
			configContext = dbContext;
		}

		public async Task<long> AspNetUsersCount()
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				return await configContext.AspNetUsers.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Config.AspNetUsers>> GetAllAspNetUsers()
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				IList<Models.DB.Config.AspNetUsers> aspNetUsers = await configContext.AspNetUsers.ToListAsync();
				return aspNetUsers;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<string> CreateAspNetUsers(List<Models.DB.Config.AspNetUsers> AspNetUsers)
		{
			string returnid = "";
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				foreach (Models.DB.Config.AspNetUsers aspNetUsers in AspNetUsers)
				{
					configContext.AspNetUsers.Add(aspNetUsers);
					await configContext.SaveChangesAsync();
					returnid = aspNetUsers.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAspNetUsers(Models.DB.Config.AspNetUsers aspNetUsers)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				configContext.AspNetUsers.Update(aspNetUsers);
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
		public async Task<bool> DeleteAspNetUsers(string aspNetUsersId)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				Models.DB.Config.AspNetUsers aspNetUsers = configContext.AspNetUsers.First(p => p.Id == aspNetUsersId);
				configContext.AspNetUsers.Remove(aspNetUsers);
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
