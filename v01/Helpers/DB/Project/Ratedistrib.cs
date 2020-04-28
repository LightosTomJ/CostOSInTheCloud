using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Ratedistrib
	{
		private ProjectContext projectContext;

		public Ratedistrib(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long RatedistribCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Ratedistrib.Count();
		}

		public List<Models.DB.Project.Ratedistrib> GetAllRatedistrib()
		{
			List<Models.DB.Project.Ratedistrib> Ratedistrib = new List<Models.DB.Project.Ratedistrib>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Ratedistrib = projectContext.Ratedistrib.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Ratedistrib;
		}
		public long Createratedistrib(List<Models.DB.Project.Ratedistrib> Ratedistrib)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Ratedistrib ratedistrib in Ratedistrib)
				{
					projectContext.Ratedistrib.Add(ratedistrib);
					projectContext.SaveChanges();
					returnid = ratedistrib.RatedistribId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateratedistrib(long id, Models.DB.Project.Ratedistrib ratedistrib)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Ratedistrib.Update(ratedistrib);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteratedistrib(long ratedistribId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Ratedistrib ratedistrib = projectContext.Ratedistrib.First(p => p.RatedistribId == ratedistribId);
				projectContext.Ratedistrib.Remove(ratedistrib);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
