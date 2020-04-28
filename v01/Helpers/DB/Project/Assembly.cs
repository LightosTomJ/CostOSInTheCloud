using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Assemblies
	{
		private ProjectContext projectContext;

		public Assemblies(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long AssemblyCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Assembly.Count();
		}

		public List<Models.DB.Project.Assembly> GetAllAssemblies()
		{
			List<Models.DB.Project.Assembly> Assemblies = new List<Models.DB.Project.Assembly>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Assemblies = projectContext.Assembly.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Assemblies;
		}
		public long Createassembly(List<Models.DB.Project.Assembly> Assemblies)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Assembly assembly in Assemblies)
				{
					projectContext.Assembly.Add(assembly);
					projectContext.SaveChanges();
					returnid = assembly.AssemblyId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateassembly(long id, Models.DB.Project.Assembly assembly)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Assembly.Update(assembly);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteassembly(long assemblyId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Assembly assembly = projectContext.Assembly.First(p => p.AssemblyId == assemblyId);
				projectContext.Assembly.Remove(assembly);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
