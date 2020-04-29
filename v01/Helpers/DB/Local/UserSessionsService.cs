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
	public class UserSessionsService
	{
		private LocalContext localContext;

		public UserSessionsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> UserSessionsCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.UserSessions.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.UserSessions>> GetAllUserSessions()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.UserSessions> userSessions = await localContext.UserSessions.ToListAsync();
				return userSessions;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateUserSessions(List<Models.DB.Local.UserSessions> UserSessions)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.UserSessions userSessions in UserSessions)
				{
					localContext.UserSessions.Add(userSessions);
					await localContext.SaveChangesAsync();
					returnid = userSessions.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateUserSessions(Models.DB.Local.UserSessions userSessions)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.UserSessions.Update(userSessions);
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
		public async Task<bool> DeleteUserSessions(long userSessionsId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.UserSessions userSessions = localContext.UserSessions.First(p => p.Id == userSessionsId);
				localContext.UserSessions.Remove(userSessions);
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
