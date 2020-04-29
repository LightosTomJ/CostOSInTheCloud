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
	public class ConceptualsService
	{
		private ProjectContext projectContext;

		public ConceptualsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> ConceptualsCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Conceptuals.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Conceptuals>> GetAllConceptuals()
		{
			IList<Models.DB.Project.Conceptuals> Conceptuals = new List<Models.DB.Project.Conceptuals>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Conceptuals> conceptuals = await projectContext.Conceptuals.ToListAsync();
				return conceptuals;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateConceptuals(List<Models.DB.Project.Conceptuals> Conceptuals)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Conceptuals conceptuals in Conceptuals)
				{
					projectContext.Conceptuals.Add(conceptuals);
					await projectContext.SaveChangesAsync();
					returnid = conceptuals.Conceptualid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateConceptuals(long id, Models.DB.Project.Conceptuals conceptuals)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Conceptuals.Update(conceptuals);
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
		public async Task<bool> DeleteConceptuals(long conceptualsId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Conceptuals conceptuals = projectContext.Conceptuals.First(p => p.Conceptualid == conceptualsId);
				projectContext.Conceptuals.Remove(conceptuals);
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
