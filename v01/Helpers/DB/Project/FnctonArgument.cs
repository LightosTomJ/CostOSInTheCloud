using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class FnctonArgument
	{
		private ProjectContext projectContext;

		public FnctonArgument(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long FnctonArgumentCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.FnctonArgument.Count();
		}

		public List<Models.DB.Project.FnctonArgument> GetAllFnctonArgument()
		{
			List<Models.DB.Project.FnctonArgument> FnctonArgument = new List<Models.DB.Project.FnctonArgument>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				FnctonArgument = projectContext.FnctonArgument.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return FnctonArgument;
		}
		public long CreatefnctonArgument(List<Models.DB.Project.FnctonArgument> FnctonArgument)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.FnctonArgument fnctonArgument in FnctonArgument)
				{
					projectContext.FnctonArgument.Add(fnctonArgument);
					projectContext.SaveChanges();
					returnid = fnctonArgument.FnctonArgumentId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatefnctonArgument(long id, Models.DB.Project.FnctonArgument fnctonArgument)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.FnctonArgument.Update(fnctonArgument);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletefnctonArgument(long fnctonArgumentId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.FnctonArgument fnctonArgument = projectContext.FnctonArgument.First(p => p.FnctonArgumentId == fnctonArgumentId);
				projectContext.FnctonArgument.Remove(fnctonArgument);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
