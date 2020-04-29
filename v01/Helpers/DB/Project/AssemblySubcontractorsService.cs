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
	public class AssemblySubcontractorsService
	{
		private ProjectContext projectContext;

		public AssemblySubcontractorsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> AssemblySubcontractorCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.AssemblySubcontractor.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.AssemblySubcontractor>> GetAllAssemblySubcontractors()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.AssemblySubcontractor> assemblySubcontractors = await projectContext.AssemblySubcontractor.ToListAsync();
				return assemblySubcontractors;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateAssemblySubcontractor(List<Models.DB.Project.AssemblySubcontractor> AssemblySubcontractors)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.AssemblySubcontractor assemblySubcontractor in AssemblySubcontractors)
				{
					projectContext.AssemblySubcontractor.Add(assemblySubcontractor);
					await projectContext.SaveChangesAsync();
					returnid = assemblySubcontractor.Assemblysubcontractorid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAssemblySubcontractor(Models.DB.Project.AssemblySubcontractor assemblySubcontractor)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.AssemblySubcontractor.Update(assemblySubcontractor);
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
		public async Task<bool> DeleteAssemblySubcontractor(long assemblySubcontractorId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.AssemblySubcontractor assemblySubcontractor = projectContext.AssemblySubcontractor.First(p => p.Assemblysubcontractorid == assemblySubcontractorId);
				projectContext.AssemblySubcontractor.Remove(assemblySubcontractor);
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
