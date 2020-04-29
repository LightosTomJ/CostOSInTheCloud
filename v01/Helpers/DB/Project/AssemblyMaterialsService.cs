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
	public class AssemblyMaterialsService
	{
		private ProjectContext projectContext;

		public AssemblyMaterialsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> AssemblyMaterialCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.AssemblyMaterial.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.AssemblyMaterial>> GetAllAssemblyMaterials()
		{
			IList<Models.DB.Project.AssemblyMaterial> AssemblyMaterials = new List<Models.DB.Project.AssemblyMaterial>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.AssemblyMaterial> assemblyMaterials = await projectContext.AssemblyMaterial.ToListAsync();
				return assemblyMaterials;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateAssemblyMaterial(List<Models.DB.Project.AssemblyMaterial> AssemblyMaterials)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.AssemblyMaterial assemblyMaterial in AssemblyMaterials)
				{
					projectContext.AssemblyMaterial.Add(assemblyMaterial);
					await projectContext.SaveChangesAsync();
					returnid = assemblyMaterial.Assemblymaterialid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAssemblyMaterial(long id, Models.DB.Project.AssemblyMaterial assemblyMaterial)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.AssemblyMaterial.Update(assemblyMaterial);
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
		public async Task<bool> DeleteAssemblyMaterial(long assemblyMaterialId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.AssemblyMaterial assemblyMaterial = projectContext.AssemblyMaterial.First(p => p.Assemblymaterialid == assemblyMaterialId);
				projectContext.AssemblyMaterial.Remove(assemblyMaterial);
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
