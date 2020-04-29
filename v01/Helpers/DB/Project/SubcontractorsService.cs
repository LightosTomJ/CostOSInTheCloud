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
	public class SubcontractorsService
	{
		private ProjectContext projectContext;

		public SubcontractorsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> SubcontractorCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Subcontractor.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Subcontractor>> GetAllSubcontractors()
		{
			IList<Models.DB.Project.Subcontractor> Subcontractors = new List<Models.DB.Project.Subcontractor>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Subcontractor> subcontractors = await projectContext.Subcontractor.ToListAsync();
				return subcontractors;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateSubcontractor(List<Models.DB.Project.Subcontractor> Subcontractors)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Subcontractor subcontractor in Subcontractors)
				{
					projectContext.Subcontractor.Add(subcontractor);
					await projectContext.SaveChangesAsync();
					returnid = subcontractor.Subcontractorid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateSubcontractor(long id, Models.DB.Project.Subcontractor subcontractor)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Subcontractor.Update(subcontractor);
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
		public async Task<bool> DeleteSubcontractor(long subcontractorId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Subcontractor subcontractor = projectContext.Subcontractor.First(p => p.Subcontractorid == subcontractorId);
				projectContext.Subcontractor.Remove(subcontractor);
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
