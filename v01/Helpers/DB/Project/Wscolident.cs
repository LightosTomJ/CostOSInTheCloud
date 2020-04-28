using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Wscolident
	{
		private ProjectContext projectContext;

		public Wscolident(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long WscolidentCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Wscolident.Count();
		}

		public List<Models.DB.Project.Wscolident> GetAllWscolident()
		{
			List<Models.DB.Project.Wscolident> Wscolident = new List<Models.DB.Project.Wscolident>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Wscolident = projectContext.Wscolident.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Wscolident;
		}
		public long Createwscolident(List<Models.DB.Project.Wscolident> Wscolident)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Wscolident wscolident in Wscolident)
				{
					projectContext.Wscolident.Add(wscolident);
					projectContext.SaveChanges();
					returnid = wscolident.WscolidentId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatewscolident(long id, Models.DB.Project.Wscolident wscolident)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Wscolident.Update(wscolident);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletewscolident(long wscolidentId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Wscolident wscolident = projectContext.Wscolident.First(p => p.WscolidentId == wscolidentId);
				projectContext.Wscolident.Remove(wscolident);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
