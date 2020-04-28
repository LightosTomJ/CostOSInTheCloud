using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class AssemblySubcontractor
	{
		private ProjectContext projectContext;

		public AssemblySubcontractor(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long AssemblySubcontractorCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.AssemblySubcontractor.Count();
		}

		public List<Models.DB.Project.AssemblySubcontractor> GetAllAssemblySubcontractor()
		{
			List<Models.DB.Project.AssemblySubcontractor> AssemblySubcontractor = new List<Models.DB.Project.AssemblySubcontractor>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				AssemblySubcontractor = projectContext.AssemblySubcontractor.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AssemblySubcontractor;
		}
		public long CreateassemblySubcontractor(List<Models.DB.Project.AssemblySubcontractor> AssemblySubcontractor)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.AssemblySubcontractor assemblySubcontractor in AssemblySubcontractor)
				{
					projectContext.AssemblySubcontractor.Add(assemblySubcontractor);
					projectContext.SaveChanges();
					returnid = assemblySubcontractor.AssemblySubcontractorId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateassemblySubcontractor(long id, Models.DB.Project.AssemblySubcontractor assemblySubcontractor)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.AssemblySubcontractor.Update(assemblySubcontractor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteassemblySubcontractor(long assemblySubcontractorId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.AssemblySubcontractor assemblySubcontractor = projectContext.AssemblySubcontractor.First(p => p.AssemblySubcontractorId == assemblySubcontractorId);
				projectContext.AssemblySubcontractor.Remove(assemblySubcontractor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
