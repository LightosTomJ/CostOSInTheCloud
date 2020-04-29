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
	public class LaborsService
	{
		private ProjectContext projectContext;

		public LaborsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> LaborCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Labor.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Labor>> GetAllLabors()
		{
			IList<Models.DB.Project.Labor> Labors = new List<Models.DB.Project.Labor>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Labor> labors = await projectContext.Labor.ToListAsync();
				return labors;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateLabor(List<Models.DB.Project.Labor> Labors)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Labor labor in Labors)
				{
					projectContext.Labor.Add(labor);
					await projectContext.SaveChangesAsync();
					returnid = labor.Laborid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateLabor(long id, Models.DB.Project.Labor labor)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Labor.Update(labor);
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
		public async Task<bool> DeleteLabor(long laborId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Labor labor = projectContext.Labor.First(p => p.Laborid == laborId);
				projectContext.Labor.Remove(labor);
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
