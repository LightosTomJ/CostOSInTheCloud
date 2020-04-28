using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Prjprop
	{
		private ProjectContext projectContext;

		public Prjprop(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long PrjpropCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Prjprop.Count();
		}

		public List<Models.DB.Project.Prjprop> GetAllPrjprop()
		{
			List<Models.DB.Project.Prjprop> Prjprop = new List<Models.DB.Project.Prjprop>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Prjprop = projectContext.Prjprop.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Prjprop;
		}
		public long Createprjprop(List<Models.DB.Project.Prjprop> Prjprop)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Prjprop prjprop in Prjprop)
				{
					projectContext.Prjprop.Add(prjprop);
					projectContext.SaveChanges();
					returnid = prjprop.PrjpropId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateprjprop(long id, Models.DB.Project.Prjprop prjprop)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Prjprop.Update(prjprop);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteprjprop(long prjpropId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Prjprop prjprop = projectContext.Prjprop.First(p => p.PrjpropId == prjpropId);
				projectContext.Prjprop.Remove(prjprop);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
