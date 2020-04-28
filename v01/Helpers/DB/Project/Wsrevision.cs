using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Wsrevision
	{
		private ProjectContext projectContext;

		public Wsrevision(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long WsrevisionCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Wsrevision.Count();
		}

		public List<Models.DB.Project.Wsrevision> GetAllWsrevision()
		{
			List<Models.DB.Project.Wsrevision> Wsrevision = new List<Models.DB.Project.Wsrevision>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Wsrevision = projectContext.Wsrevision.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Wsrevision;
		}
		public long Createwsrevision(List<Models.DB.Project.Wsrevision> Wsrevision)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Wsrevision wsrevision in Wsrevision)
				{
					projectContext.Wsrevision.Add(wsrevision);
					projectContext.SaveChanges();
					returnid = wsrevision.WsrevisionId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatewsrevision(long id, Models.DB.Project.Wsrevision wsrevision)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Wsrevision.Update(wsrevision);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletewsrevision(long wsrevisionId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Wsrevision wsrevision = projectContext.Wsrevision.First(p => p.WsrevisionId == wsrevisionId);
				projectContext.Wsrevision.Remove(wsrevision);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
