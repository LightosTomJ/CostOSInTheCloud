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
	public class BcProjectsService
	{
		private LocalContext localContext;

		public BcProjectsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcProjectCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcProject.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcProject>> GetAllBcProjects()
		{
			IList<Models.DB.Local.BcProject> BcProjects = new List<Models.DB.Local.BcProject>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcProject> bcProjects = await localContext.BcProject.ToListAsync();
				return bcProjects;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcProject(List<Models.DB.Local.BcProject> BcProjects)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcProject bcProject in BcProjects)
				{
					localContext.BcProject.Add(bcProject);
					await localContext.SaveChangesAsync();
					returnid = bcProject.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcProject(long id, Models.DB.Local.BcProject bcProject)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcProject.Update(bcProject);
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
		public async Task<bool> DeleteBcProject(long bcProjectId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcProject bcProject = localContext.BcProject.First(p => p.Id == bcProjectId);
				localContext.BcProject.Remove(bcProject);
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
