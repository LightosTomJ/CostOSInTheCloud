using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class BoqitemMaterial
	{
		private ProjectContext projectContext;

		public BoqitemMaterial(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long BoqitemMaterialCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.BoqitemMaterial.Count();
		}

		public List<Models.DB.Project.BoqitemMaterial> GetAllBoqitemMaterial()
		{
			List<Models.DB.Project.BoqitemMaterial> BoqitemMaterial = new List<Models.DB.Project.BoqitemMaterial>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				BoqitemMaterial = projectContext.BoqitemMaterial.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BoqitemMaterial;
		}
		public long CreateboqitemMaterial(List<Models.DB.Project.BoqitemMaterial> BoqitemMaterial)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.BoqitemMaterial boqitemMaterial in BoqitemMaterial)
				{
					projectContext.BoqitemMaterial.Add(boqitemMaterial);
					projectContext.SaveChanges();
					returnid = boqitemMaterial.BoqitemMaterialId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateboqitemMaterial(long id, Models.DB.Project.BoqitemMaterial boqitemMaterial)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.BoqitemMaterial.Update(boqitemMaterial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteboqitemMaterial(long boqitemMaterialId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.BoqitemMaterial boqitemMaterial = projectContext.BoqitemMaterial.First(p => p.BoqitemMaterialId == boqitemMaterialId);
				projectContext.BoqitemMaterial.Remove(boqitemMaterial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
