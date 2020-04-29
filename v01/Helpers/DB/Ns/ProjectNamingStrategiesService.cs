using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.NS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Ns
{
	public class ProjectNamingStrategiesService
	{
		private NsContext nsContext;

		public ProjectNamingStrategiesService(NsContext dbContext)
		{
			nsContext = dbContext;
		}

		public async Task<long> ProjectNamingStrategyCount()
		{
			try
			{
				if (nsContext == null) nsContext = new NsContext();
				return await nsContext.ProjectNamingStrategy.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.NS.ProjectNamingStrategy>> GetAllProjectNamingStrategies()
		{
			IList<Models.DB.NS.ProjectNamingStrategy> ProjectNamingStrategies = new List<Models.DB.NS.ProjectNamingStrategy>();
			try
			{
				if (nsContext == null) nsContext = new NsContext();
				IList<Models.DB.NS.ProjectNamingStrategy> projectNamingStrategies = await nsContext.ProjectNamingStrategy.ToListAsync();
				return projectNamingStrategies;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateProjectNamingStrategy(List<Models.DB.NS.ProjectNamingStrategy> ProjectNamingStrategies)
		{
			long returnid = -1;
			try
			{
				if (nsContext == null) nsContext = new NsContext();
				foreach (Models.DB.NS.ProjectNamingStrategy projectNamingStrategy in ProjectNamingStrategies)
				{
					nsContext.ProjectNamingStrategy.Add(projectNamingStrategy);
					await nsContext.SaveChangesAsync();
					returnid = projectNamingStrategy.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateProjectNamingStrategy(long id, Models.DB.NS.ProjectNamingStrategy projectNamingStrategy)
		{
			try
			{
				if (nsContext == null) nsContext = new NsContext();
				nsContext.ProjectNamingStrategy.Update(projectNamingStrategy);
				await nsContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
		public async Task<bool> DeleteProjectNamingStrategy(long projectNamingStrategyId)
		{
			try
			{
				if (nsContext == null) nsContext = new NsContext();
				Models.DB.NS.ProjectNamingStrategy projectNamingStrategy = nsContext.ProjectNamingStrategy.First(p => p.Id == projectNamingStrategyId);
				nsContext.ProjectNamingStrategy.Remove(projectNamingStrategy);
				await nsContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
	}
}
