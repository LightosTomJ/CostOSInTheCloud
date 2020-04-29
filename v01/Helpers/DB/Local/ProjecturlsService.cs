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
	public class ProjecturlsService
	{
		private LocalContext localContext;

		public ProjecturlsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> ProjecturlCount()
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

		public async Task<IList<Models.DB.Local.Projecturl>> GetAllProjecturls()
		{
			IList<Models.DB.Local.Projecturl> Projecturls = new List<Models.DB.Local.Projecturl>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Projecturl> projecturls = await localContext.Projecturl.ToListAsync();
				return projecturls;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateProjecturl(List<Models.DB.Local.Projecturl> Projecturls)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Projecturl projecturl in Projecturls)
				{
					localContext.Projecturl.Add(projecturl);
					await localContext.SaveChangesAsync();
					returnid = projecturl.Projecturlid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateProjecturl(long id, Models.DB.Local.Projecturl projecturl)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Projecturl.Update(projecturl);
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
		public async Task<bool> DeleteProjecturl(long projecturlId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Projecturl projecturl = localContext.Projecturl.First(p => p.Projecturlid == projecturlId);
				localContext.Projecturl.Remove(projecturl);
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
