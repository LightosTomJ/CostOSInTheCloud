using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Xchangerate
	{
		private ProjectContext projectContext;

		public Xchangerate(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long XchangerateCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Xchangerate.Count();
		}

		public List<Models.DB.Project.Xchangerate> GetAllXchangerate()
		{
			List<Models.DB.Project.Xchangerate> Xchangerate = new List<Models.DB.Project.Xchangerate>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Xchangerate = projectContext.Xchangerate.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Xchangerate;
		}
		public long Createxchangerate(List<Models.DB.Project.Xchangerate> Xchangerate)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Xchangerate xchangerate in Xchangerate)
				{
					projectContext.Xchangerate.Add(xchangerate);
					projectContext.SaveChanges();
					returnid = xchangerate.XchangerateId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatexchangerate(long id, Models.DB.Project.Xchangerate xchangerate)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Xchangerate.Update(xchangerate);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletexchangerate(long xchangerateId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Xchangerate xchangerate = projectContext.Xchangerate.First(p => p.XchangerateId == xchangerateId);
				projectContext.Xchangerate.Remove(xchangerate);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
