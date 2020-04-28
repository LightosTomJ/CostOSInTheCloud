using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Prjuserprop
	{
		private ProjectContext projectContext;

		public Prjuserprop(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long PrjuserpropCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Prjuserprop.Count();
		}

		public List<Models.DB.Project.Prjuserprop> GetAllPrjuserprop()
		{
			List<Models.DB.Project.Prjuserprop> Prjuserprop = new List<Models.DB.Project.Prjuserprop>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Prjuserprop = projectContext.Prjuserprop.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Prjuserprop;
		}
		public long Createprjuserprop(List<Models.DB.Project.Prjuserprop> Prjuserprop)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Prjuserprop prjuserprop in Prjuserprop)
				{
					projectContext.Prjuserprop.Add(prjuserprop);
					projectContext.SaveChanges();
					returnid = prjuserprop.PrjuserpropId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateprjuserprop(long id, Models.DB.Project.Prjuserprop prjuserprop)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Prjuserprop.Update(prjuserprop);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteprjuserprop(long prjuserpropId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Prjuserprop prjuserprop = projectContext.Prjuserprop.First(p => p.PrjuserpropId == prjuserpropId);
				projectContext.Prjuserprop.Remove(prjuserprop);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
