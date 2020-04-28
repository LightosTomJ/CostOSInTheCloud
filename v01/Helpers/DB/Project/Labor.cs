using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Labor
	{
		private ProjectContext projectContext;

		public Labor(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long LaborCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Labor.Count();
		}

		public List<Models.DB.Project.Labor> GetAllLabor()
		{
			List<Models.DB.Project.Labor> Labor = new List<Models.DB.Project.Labor>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Labor = projectContext.Labor.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Labor;
		}
		public long Createlabor(List<Models.DB.Project.Labor> Labor)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Labor labor in Labor)
				{
					projectContext.Labor.Add(labor);
					projectContext.SaveChanges();
					returnid = labor.LaborId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatelabor(long id, Models.DB.Project.Labor labor)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Labor.Update(labor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletelabor(long laborId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Labor labor = projectContext.Labor.First(p => p.LaborId == laborId);
				projectContext.Labor.Remove(labor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
