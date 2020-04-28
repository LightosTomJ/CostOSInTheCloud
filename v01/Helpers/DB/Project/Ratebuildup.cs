using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Ratebuildup
	{
		private ProjectContext projectContext;

		public Ratebuildup(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long RatebuildupCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Ratebuildup.Count();
		}

		public List<Models.DB.Project.Ratebuildup> GetAllRatebuildup()
		{
			List<Models.DB.Project.Ratebuildup> Ratebuildup = new List<Models.DB.Project.Ratebuildup>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Ratebuildup = projectContext.Ratebuildup.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Ratebuildup;
		}
		public long Createratebuildup(List<Models.DB.Project.Ratebuildup> Ratebuildup)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Ratebuildup ratebuildup in Ratebuildup)
				{
					projectContext.Ratebuildup.Add(ratebuildup);
					projectContext.SaveChanges();
					returnid = ratebuildup.RatebuildupId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateratebuildup(long id, Models.DB.Project.Ratebuildup ratebuildup)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Ratebuildup.Update(ratebuildup);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteratebuildup(long ratebuildupId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Ratebuildup ratebuildup = projectContext.Ratebuildup.First(p => p.RatebuildupId == ratebuildupId);
				projectContext.Ratebuildup.Remove(ratebuildup);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
