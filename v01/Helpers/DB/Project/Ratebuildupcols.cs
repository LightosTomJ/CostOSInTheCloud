using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Ratebuildupcols
	{
		private ProjectContext projectContext;

		public Ratebuildupcols(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long RatebuildupcolsCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Ratebuildupcols.Count();
		}

		public List<Models.DB.Project.Ratebuildupcols> GetAllRatebuildupcols()
		{
			List<Models.DB.Project.Ratebuildupcols> Ratebuildupcols = new List<Models.DB.Project.Ratebuildupcols>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Ratebuildupcols = projectContext.Ratebuildupcols.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Ratebuildupcols;
		}
		public long Createratebuildupcols(List<Models.DB.Project.Ratebuildupcols> Ratebuildupcols)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Ratebuildupcols ratebuildupcols in Ratebuildupcols)
				{
					projectContext.Ratebuildupcols.Add(ratebuildupcols);
					projectContext.SaveChanges();
					returnid = ratebuildupcols.RatebuildupcolsId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateratebuildupcols(long id, Models.DB.Project.Ratebuildupcols ratebuildupcols)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Ratebuildupcols.Update(ratebuildupcols);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteratebuildupcols(long ratebuildupcolsId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Ratebuildupcols ratebuildupcols = projectContext.Ratebuildupcols.First(p => p.RatebuildupcolsId == ratebuildupcolsId);
				projectContext.Ratebuildupcols.Remove(ratebuildupcols);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
