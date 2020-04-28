using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class AssemblyMaterial
	{
		private ProjectContext projectContext;

		public AssemblyMaterial(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long AssemblyMaterialCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.AssemblyMaterial.Count();
		}

		public List<Models.DB.Project.AssemblyMaterial> GetAllAssemblyMaterial()
		{
			List<Models.DB.Project.AssemblyMaterial> AssemblyMaterial = new List<Models.DB.Project.AssemblyMaterial>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				AssemblyMaterial = projectContext.AssemblyMaterial.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AssemblyMaterial;
		}
		public long CreateassemblyMaterial(List<Models.DB.Project.AssemblyMaterial> AssemblyMaterial)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.AssemblyMaterial assemblyMaterial in AssemblyMaterial)
				{
					projectContext.AssemblyMaterial.Add(assemblyMaterial);
					projectContext.SaveChanges();
					returnid = assemblyMaterial.AssemblyMaterialId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateassemblyMaterial(long id, Models.DB.Project.AssemblyMaterial assemblyMaterial)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.AssemblyMaterial.Update(assemblyMaterial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteassemblyMaterial(long assemblyMaterialId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.AssemblyMaterial assemblyMaterial = projectContext.AssemblyMaterial.First(p => p.AssemblyMaterialId == assemblyMaterialId);
				projectContext.AssemblyMaterial.Remove(assemblyMaterial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
