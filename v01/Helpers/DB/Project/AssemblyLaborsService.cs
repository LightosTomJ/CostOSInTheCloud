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
	public class AssemblyLaborsService
	{
		private ProjectContext projectContext;

		public AssemblyLaborsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> AssemblyLaborCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.AssemblyLabor.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.AssemblyLabor>> GetAllAssemblyLabors()
		{
			IList<Models.DB.Project.AssemblyLabor> AssemblyLabors = new List<Models.DB.Project.AssemblyLabor>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.AssemblyLabor> assemblyLabors = await projectContext.AssemblyLabor.ToListAsync();
				return assemblyLabors;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateAssemblyLabor(List<Models.DB.Project.AssemblyLabor> AssemblyLabors)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.AssemblyLabor assemblyLabor in AssemblyLabors)
				{
					projectContext.AssemblyLabor.Add(assemblyLabor);
					await projectContext.SaveChangesAsync();
					returnid = assemblyLabor.Assemblylaborid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAssemblyLabor(long id, Models.DB.Project.AssemblyLabor assemblyLabor)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.AssemblyLabor.Update(assemblyLabor);
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
		public async Task<bool> DeleteAssemblyLabor(long assemblyLaborId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.AssemblyLabor assemblyLabor = projectContext.AssemblyLabor.First(p => p.Assemblylaborid == assemblyLaborId);
				projectContext.AssemblyLabor.Remove(assemblyLabor);
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
