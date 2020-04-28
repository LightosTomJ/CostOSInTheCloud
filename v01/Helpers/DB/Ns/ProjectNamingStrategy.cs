using Models.DB.Ns;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Ns
{
	public class ProjectNamingStrategies
	{
		private NsContext nsContext;

		public ProjectNamingStrategies(NsContext dbContext)
		{
			nsContext = dbContext;
		}

		public long ProjectNamingStrategyCount()
		{
			if (nsContext == null) nsContext = new NsContext();
			return nsContext.ProjectNamingStrategy.Count();
		}

		public List<Models.DB.Ns.ProjectNamingStrategy> GetAllProjectNamingStrategies()
		{
			List<Models.DB.Ns.ProjectNamingStrategy> ProjectNamingStrategies = new List<Models.DB.Ns.ProjectNamingStrategy>();
			try
			{
				if (nsContext == null) nsContext = new NsContext();
				ProjectNamingStrategies = nsContext.ProjectNamingStrategy.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return ProjectNamingStrategies;
		}
		public long CreateprojectNamingStrategy(List<Models.DB.Ns.ProjectNamingStrategy> ProjectNamingStrategies)
		{
			long returnid = 0;
			try
			{
				if (nsContext == null) nsContext = new NsContext();
				foreach (Models.DB.Ns.ProjectNamingStrategy projectNamingStrategy in ProjectNamingStrategies)
				{
					nsContext.ProjectNamingStrategy.Add(projectNamingStrategy);
					nsContext.SaveChanges();
					returnid = projectNamingStrategy.ProjectNamingStrategyId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateprojectNamingStrategy(long id, Models.DB.Ns.ProjectNamingStrategy projectNamingStrategy)
		{
			try
			{
				if (nsContext == null) nsContext = new NsContext();
				nsContext.ProjectNamingStrategy.Update(projectNamingStrategy);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteprojectNamingStrategy(long projectNamingStrategyId)
		{
			try
			{
				if (nsContext == null) nsContext = new NsContext();
				Models.DB.Ns.ProjectNamingStrategy projectNamingStrategy = nsContext.ProjectNamingStrategy.First(p => p.ProjectNamingStrategyId == projectNamingStrategyId);
				nsContext.ProjectNamingStrategy.Remove(projectNamingStrategy);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
