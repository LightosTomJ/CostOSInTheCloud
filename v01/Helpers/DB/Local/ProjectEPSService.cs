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
	public class ProjectEPSService
	{
		private LocalContext localContext;

		public ProjectEPSService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> ProjectEPSCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.ProjectEPS.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.ProjectEPS>> GetAllProjectEPS()
		{
			IList<Models.DB.Local.ProjectEPS> ProjectEPS = new List<Models.DB.Local.ProjectEPS>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.ProjectEPS> projectEPS = await localContext.ProjectEPS.ToListAsync();
				return projectEPS;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateProjectEPS(List<Models.DB.Local.ProjectEPS> ProjectEPS)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.ProjectEPS projectEPS in ProjectEPS)
				{
					localContext.ProjectEPS.Add(projectEPS);
					await localContext.SaveChangesAsync();
					returnid = projectEPS.Projectepsid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateProjectEPS(long id, Models.DB.Local.ProjectEPS projectEPS)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.ProjectEPS.Update(projectEPS);
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
		public async Task<bool> DeleteProjectEPS(long projectEPSId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.ProjectEPS projectEPS = localContext.ProjectEPS.First(p => p.Projectepsid == projectEPSId);
				localContext.ProjectEPS.Remove(projectEPS);
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
