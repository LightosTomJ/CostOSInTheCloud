using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Wsfile
	{
		private ProjectContext projectContext;

		public Wsfile(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long WsfileCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Wsfile.Count();
		}

		public List<Models.DB.Project.Wsfile> GetAllWsfile()
		{
			List<Models.DB.Project.Wsfile> Wsfile = new List<Models.DB.Project.Wsfile>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Wsfile = projectContext.Wsfile.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Wsfile;
		}
		public long Createwsfile(List<Models.DB.Project.Wsfile> Wsfile)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Wsfile wsfile in Wsfile)
				{
					projectContext.Wsfile.Add(wsfile);
					projectContext.SaveChanges();
					returnid = wsfile.WsfileId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatewsfile(long id, Models.DB.Project.Wsfile wsfile)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Wsfile.Update(wsfile);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletewsfile(long wsfileId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Wsfile wsfile = projectContext.Wsfile.First(p => p.WsfileId == wsfileId);
				projectContext.Wsfile.Remove(wsfile);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
