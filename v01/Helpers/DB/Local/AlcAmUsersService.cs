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
	public class AlcAmUsersService
	{
		private LocalContext localContext;

		public AlcAmUsersService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> AlcAmUsersCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.AlcAmUsers.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.AlcAmUsers>> GetAllAlcAmUsers()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.AlcAmUsers> alcAmUsers = await localContext.AlcAmUsers.ToListAsync();
				return alcAmUsers;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<string> CreateAlcAmUsers(List<Models.DB.Local.AlcAmUsers> AlcAmUsers)
		{
			string returnid;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AlcAmUsers alcAmUsers in AlcAmUsers)
				{
					localContext.AlcAmUsers.Add(alcAmUsers);
					await localContext.SaveChangesAsync();
					returnid = alcAmUsers.UserId;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return "";
		}

		public async Task<bool> UpdateAlcAmUsers(Models.DB.Local.AlcAmUsers alcAmUsers)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AlcAmUsers.Update(alcAmUsers);
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
		public async Task<bool> DeleteAlcAmUsers(string alcAmUsersId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AlcAmUsers alcAmUsers = localContext.AlcAmUsers.First(p => p.UserId == alcAmUsersId);
				localContext.AlcAmUsers.Remove(alcAmUsers);
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
