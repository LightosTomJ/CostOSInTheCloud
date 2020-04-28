using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Rawmaterial
	{
		private ProjectContext projectContext;

		public Rawmaterial(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long RawmaterialCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Rawmaterial.Count();
		}

		public List<Models.DB.Project.Rawmaterial> GetAllRawmaterial()
		{
			List<Models.DB.Project.Rawmaterial> Rawmaterial = new List<Models.DB.Project.Rawmaterial>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Rawmaterial = projectContext.Rawmaterial.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Rawmaterial;
		}
		public long Createrawmaterial(List<Models.DB.Project.Rawmaterial> Rawmaterial)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Rawmaterial rawmaterial in Rawmaterial)
				{
					projectContext.Rawmaterial.Add(rawmaterial);
					projectContext.SaveChanges();
					returnid = rawmaterial.RawmaterialId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updaterawmaterial(long id, Models.DB.Project.Rawmaterial rawmaterial)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Rawmaterial.Update(rawmaterial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleterawmaterial(long rawmaterialId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Rawmaterial rawmaterial = projectContext.Rawmaterial.First(p => p.RawmaterialId == rawmaterialId);
				projectContext.Rawmaterial.Remove(rawmaterial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
