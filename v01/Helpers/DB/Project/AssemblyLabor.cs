using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class AssemblyLabor
	{
		private ProjectContext projectContext;

		public AssemblyLabor(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long AssemblyLaborCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.AssemblyLabor.Count();
		}

		public List<Models.DB.Project.AssemblyLabor> GetAllAssemblyLabor()
		{
			List<Models.DB.Project.AssemblyLabor> AssemblyLabor = new List<Models.DB.Project.AssemblyLabor>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				AssemblyLabor = projectContext.AssemblyLabor.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AssemblyLabor;
		}
		public long CreateassemblyLabor(List<Models.DB.Project.AssemblyLabor> AssemblyLabor)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.AssemblyLabor assemblyLabor in AssemblyLabor)
				{
					projectContext.AssemblyLabor.Add(assemblyLabor);
					projectContext.SaveChanges();
					returnid = assemblyLabor.AssemblyLaborId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateassemblyLabor(long id, Models.DB.Project.AssemblyLabor assemblyLabor)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.AssemblyLabor.Update(assemblyLabor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteassemblyLabor(long assemblyLaborId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.AssemblyLabor assemblyLabor = projectContext.AssemblyLabor.First(p => p.AssemblyLaborId == assemblyLaborId);
				projectContext.AssemblyLabor.Remove(assemblyLabor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
