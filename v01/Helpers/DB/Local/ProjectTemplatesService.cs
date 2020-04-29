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
	public class ProjectTemplatesService
	{
		private LocalContext localContext;

		public ProjectTemplatesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> ProjectTemplateCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.ProjectTemplate.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.ProjectTemplate>> GetAllProjectTemplates()
		{
			IList<Models.DB.Local.ProjectTemplate> ProjectTemplates = new List<Models.DB.Local.ProjectTemplate>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.ProjectTemplate> projectTemplates = await localContext.ProjectTemplate.ToListAsync();
				return projectTemplates;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateProjectTemplate(List<Models.DB.Local.ProjectTemplate> ProjectTemplates)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.ProjectTemplate projectTemplate in ProjectTemplates)
				{
					localContext.ProjectTemplate.Add(projectTemplate);
					await localContext.SaveChangesAsync();
					returnid = projectTemplate.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateProjectTemplate(long id, Models.DB.Local.ProjectTemplate projectTemplate)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.ProjectTemplate.Update(projectTemplate);
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
		public async Task<bool> DeleteProjectTemplate(long projectTemplateId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.ProjectTemplate projectTemplate = localContext.ProjectTemplate.First(p => p.Id == projectTemplateId);
				localContext.ProjectTemplate.Remove(projectTemplate);
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
