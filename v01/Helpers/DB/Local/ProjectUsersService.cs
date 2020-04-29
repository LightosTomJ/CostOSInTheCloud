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
	public class ProjectUsersService
	{
		private LocalContext localContext;

		public ProjectUsersService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> ProjectUserCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.ProjectUser.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.ProjectUser>> GetAllProjectUsers()
		{
			IList<Models.DB.Local.ProjectUser> ProjectUsers = new List<Models.DB.Local.ProjectUser>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.ProjectUser> projectUsers = await localContext.ProjectUser.ToListAsync();
				return projectUsers;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateProjectUser(List<Models.DB.Local.ProjectUser> ProjectUsers)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.ProjectUser projectUser in ProjectUsers)
				{
					localContext.ProjectUser.Add(projectUser);
					await localContext.SaveChangesAsync();
					returnid = projectUser.Puid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateProjectUser(long id, Models.DB.Local.ProjectUser projectUser)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.ProjectUser.Update(projectUser);
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
		public async Task<bool> DeleteProjectUser(long projectUserId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.ProjectUser projectUser = localContext.ProjectUser.First(p => p.Puid == projectUserId);
				localContext.ProjectUser.Remove(projectUser);
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
