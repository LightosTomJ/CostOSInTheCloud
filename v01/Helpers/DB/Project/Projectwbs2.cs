using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Projectwbs2
	{
		private ProjectContext projectContext;

		public Projectwbs2(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long Projectwbs2Count()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Projectwbs2.Count();
		}

		public List<Models.DB.Project.Projectwbs2> GetAllProjectwbs2()
		{
			List<Models.DB.Project.Projectwbs2> Projectwbs2 = new List<Models.DB.Project.Projectwbs2>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Projectwbs2 = projectContext.Projectwbs2.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Projectwbs2;
		}
		public long Createprojectwbs2(List<Models.DB.Project.Projectwbs2> Projectwbs2)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Projectwbs2 projectwbs2 in Projectwbs2)
				{
					projectContext.Projectwbs2.Add(projectwbs2);
					projectContext.SaveChanges();
					returnid = projectwbs2.Projectwbs2Id;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateprojectwbs2(long id, Models.DB.Project.Projectwbs2 projectwbs2)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Projectwbs2.Update(projectwbs2);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteprojectwbs2(long projectwbs2Id)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Projectwbs2 projectwbs2 = projectContext.Projectwbs2.First(p => p.Projectwbs2Id == projectwbs2Id);
				projectContext.Projectwbs2.Remove(projectwbs2);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
