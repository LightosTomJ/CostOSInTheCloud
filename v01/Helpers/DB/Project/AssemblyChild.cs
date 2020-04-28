using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class AssemblyChild
	{
		private ProjectContext projectContext;

		public AssemblyChild(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long AssemblyChildCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.AssemblyChild.Count();
		}

		public List<Models.DB.Project.AssemblyChild> GetAllAssemblyChild()
		{
			List<Models.DB.Project.AssemblyChild> AssemblyChild = new List<Models.DB.Project.AssemblyChild>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				AssemblyChild = projectContext.AssemblyChild.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AssemblyChild;
		}
		public long CreateassemblyChild(List<Models.DB.Project.AssemblyChild> AssemblyChild)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.AssemblyChild assemblyChild in AssemblyChild)
				{
					projectContext.AssemblyChild.Add(assemblyChild);
					projectContext.SaveChanges();
					returnid = assemblyChild.AssemblyChildId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateassemblyChild(long id, Models.DB.Project.AssemblyChild assemblyChild)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.AssemblyChild.Update(assemblyChild);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteassemblyChild(long assemblyChildId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.AssemblyChild assemblyChild = projectContext.AssemblyChild.First(p => p.AssemblyChildId == assemblyChildId);
				projectContext.AssemblyChild.Remove(assemblyChild);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
