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
	public class UserPropsService
	{
		private LocalContext localContext;

		public UserPropsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> UserPropCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.UserProp.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.UserProp>> GetAllUserProps()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.UserProp> userProps = await localContext.UserProp.ToListAsync();
				return userProps;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateUserProp(List<Models.DB.Local.UserProp> UserProps)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.UserProp userProp in UserProps)
				{
					localContext.UserProp.Add(userProp);
					await localContext.SaveChangesAsync();
					returnid = userProp.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateUserProp(Models.DB.Local.UserProp userProp)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.UserProp.Update(userProp);
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
		public async Task<bool> DeleteUserProp(long userPropId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.UserProp userProp = localContext.UserProp.First(p => p.Id == userPropId);
				localContext.UserProp.Remove(userProp);
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
