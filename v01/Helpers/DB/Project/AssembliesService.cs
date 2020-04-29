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
	public class AssembliesService
	{
		private ProjectContext projectContext;

		public AssembliesService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> AssemblyCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Assembly.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Assembly>> GetAllAssemblies()
		{
			IList<Models.DB.Project.Assembly> Assemblies = new List<Models.DB.Project.Assembly>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Assembly> assemblies = await projectContext.Assembly.ToListAsync();
				return assemblies;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateAssembly(List<Models.DB.Project.Assembly> Assemblies)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Assembly assembly in Assemblies)
				{
					projectContext.Assembly.Add(assembly);
					await projectContext.SaveChangesAsync();
					returnid = assembly.Assemblyid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAssembly(long id, Models.DB.Project.Assembly assembly)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Assembly.Update(assembly);
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
		public async Task<bool> DeleteAssembly(long assemblyId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Assembly assembly = projectContext.Assembly.First(p => p.Assemblyid == assemblyId);
				projectContext.Assembly.Remove(assembly);
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
