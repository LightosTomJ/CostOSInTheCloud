using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class AssemblyConsumable
	{
		private ProjectContext projectContext;

		public AssemblyConsumable(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long AssemblyConsumableCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.AssemblyConsumable.Count();
		}

		public List<Models.DB.Project.AssemblyConsumable> GetAllAssemblyConsumable()
		{
			List<Models.DB.Project.AssemblyConsumable> AssemblyConsumable = new List<Models.DB.Project.AssemblyConsumable>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				AssemblyConsumable = projectContext.AssemblyConsumable.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AssemblyConsumable;
		}
		public long CreateassemblyConsumable(List<Models.DB.Project.AssemblyConsumable> AssemblyConsumable)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.AssemblyConsumable assemblyConsumable in AssemblyConsumable)
				{
					projectContext.AssemblyConsumable.Add(assemblyConsumable);
					projectContext.SaveChanges();
					returnid = assemblyConsumable.AssemblyConsumableId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateassemblyConsumable(long id, Models.DB.Project.AssemblyConsumable assemblyConsumable)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.AssemblyConsumable.Update(assemblyConsumable);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteassemblyConsumable(long assemblyConsumableId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.AssemblyConsumable assemblyConsumable = projectContext.AssemblyConsumable.First(p => p.AssemblyConsumableId == assemblyConsumableId);
				projectContext.AssemblyConsumable.Remove(assemblyConsumable);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
