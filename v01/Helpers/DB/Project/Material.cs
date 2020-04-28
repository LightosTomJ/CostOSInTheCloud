using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Material
	{
		private ProjectContext projectContext;

		public Material(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long MaterialCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Material.Count();
		}

		public List<Models.DB.Project.Material> GetAllMaterial()
		{
			List<Models.DB.Project.Material> Material = new List<Models.DB.Project.Material>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Material = projectContext.Material.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Material;
		}
		public long Creatematerial(List<Models.DB.Project.Material> Material)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Material material in Material)
				{
					projectContext.Material.Add(material);
					projectContext.SaveChanges();
					returnid = material.MaterialId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatematerial(long id, Models.DB.Project.Material material)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Material.Update(material);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletematerial(long materialId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Material material = projectContext.Material.First(p => p.MaterialId == materialId);
				projectContext.Material.Remove(material);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
