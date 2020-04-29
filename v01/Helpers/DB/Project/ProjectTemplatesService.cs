using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class ProjectTemplatesService
	{
		private ProjectContext projectContext;

		public ProjectTemplatesService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> ProjectTemplateCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.ProjectTemplate.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.ProjectTemplate>> GetAllProjectTemplates()
		{
			IList<Models.DB.Project.ProjectTemplate> ProjectTemplates = new List<Models.DB.Project.ProjectTemplate>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.ProjectTemplate> projectTemplates = await projectContext.ProjectTemplate.ToListAsync();
				return projectTemplates;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateProjectTemplate(List<Models.DB.Project.ProjectTemplate> ProjectTemplates)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.ProjectTemplate projectTemplate in ProjectTemplates)
				{
					projectContext.ProjectTemplate.Add(projectTemplate);
					await projectContext.SaveChangesAsync();
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

		public async Task<bool> UpdateProjectTemplate(long id, Models.DB.Project.ProjectTemplate projectTemplate)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.ProjectTemplate.Update(projectTemplate);
				await projectContext.SaveChangesAsync();
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
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.ProjectTemplate projectTemplate = projectContext.ProjectTemplate.First(p => p.Id == projectTemplateId);
				projectContext.ProjectTemplate.Remove(projectTemplate);
				await projectContext.SaveChangesAsync();
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
