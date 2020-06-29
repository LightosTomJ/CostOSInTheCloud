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
	public class ProjectURLsService
	{
		private LocalContext localContext;

		public ProjectURLsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> ProjectURLCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Projecturl.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<ProjectURL>> GetAllProjectURLs(int projectInfoId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<ProjectURL> projectURLs = await localContext.Projecturl
									.Where(p => p.Projectinfoid == projectInfoId)
									.ToListAsync();
				return projectURLs;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateProjectURL(List<ProjectURL> ProjectURLs)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (ProjectURL projectURL in ProjectURLs)
				{
					localContext.Projecturl.Add(projectURL);
					await localContext.SaveChangesAsync();
					returnid = projectURL.Projecturlid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateProjectURL(ProjectURL projectURL)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Projecturl.Update(projectURL);
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
		public async Task<bool> DeleteProjectURL(long projectURLId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				ProjectURL projectURL = localContext.Projecturl.First(p => p.Projecturlid == projectURLId);
				localContext.Projecturl.Remove(projectURL);
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
