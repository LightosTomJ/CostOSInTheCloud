using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class BoqitemAssemblies
	{
		private ProjectContext projectContext;

		public BoqitemAssemblies(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long BoqitemAssemblyCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.BoqitemAssembly.Count();
		}

		public List<Models.DB.Project.BoqitemAssembly> GetAllBoqitemAssemblies()
		{
			List<Models.DB.Project.BoqitemAssembly> BoqitemAssemblies = new List<Models.DB.Project.BoqitemAssembly>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				BoqitemAssemblies = projectContext.BoqitemAssembly.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BoqitemAssemblies;
		}
		public long CreateboqitemAssembly(List<Models.DB.Project.BoqitemAssembly> BoqitemAssemblies)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.BoqitemAssembly boqitemAssembly in BoqitemAssemblies)
				{
					projectContext.BoqitemAssembly.Add(boqitemAssembly);
					projectContext.SaveChanges();
					returnid = boqitemAssembly.BoqitemAssemblyId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateboqitemAssembly(long id, Models.DB.Project.BoqitemAssembly boqitemAssembly)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.BoqitemAssembly.Update(boqitemAssembly);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteboqitemAssembly(long boqitemAssemblyId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.BoqitemAssembly boqitemAssembly = projectContext.BoqitemAssembly.First(p => p.BoqitemAssemblyId == boqitemAssemblyId);
				projectContext.BoqitemAssembly.Remove(boqitemAssembly);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
