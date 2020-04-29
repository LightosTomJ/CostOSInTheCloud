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
	public class ProjectUserTemplatesService
	{
		private LocalContext localContext;

		public ProjectUserTemplatesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> ProjectUserTemplateCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.ProjectUserTemplate.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.ProjectUserTemplate>> GetAllProjectUserTemplates()
		{
			IList<Models.DB.Local.ProjectUserTemplate> ProjectUserTemplates = new List<Models.DB.Local.ProjectUserTemplate>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.ProjectUserTemplate> projectUserTemplates = await localContext.ProjectUserTemplate.ToListAsync();
				return projectUserTemplates;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateProjectUserTemplate(List<Models.DB.Local.ProjectUserTemplate> ProjectUserTemplates)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.ProjectUserTemplate projectUserTemplate in ProjectUserTemplates)
				{
					localContext.ProjectUserTemplate.Add(projectUserTemplate);
					await localContext.SaveChangesAsync();
					returnid = projectUserTemplate.Templateid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateProjectUserTemplate(long id, Models.DB.Local.ProjectUserTemplate projectUserTemplate)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.ProjectUserTemplate.Update(projectUserTemplate);
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
		public async Task<bool> DeleteProjectUserTemplate(long projectUserTemplateId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.ProjectUserTemplate projectUserTemplate = localContext.ProjectUserTemplate.First(p => p.Templateid == projectUserTemplateId);
				localContext.ProjectUserTemplate.Remove(projectUserTemplate);
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
