using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Ostdbcon
	{
		private ProjectContext projectContext;

		public Ostdbcon(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long OstdbconCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Ostdbcon.Count();
		}

		public List<Models.DB.Project.Ostdbcon> GetAllOstdbcon()
		{
			List<Models.DB.Project.Ostdbcon> Ostdbcon = new List<Models.DB.Project.Ostdbcon>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Ostdbcon = projectContext.Ostdbcon.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Ostdbcon;
		}
		public long Createostdbcon(List<Models.DB.Project.Ostdbcon> Ostdbcon)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Ostdbcon ostdbcon in Ostdbcon)
				{
					projectContext.Ostdbcon.Add(ostdbcon);
					projectContext.SaveChanges();
					returnid = ostdbcon.OstdbconId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateostdbcon(long id, Models.DB.Project.Ostdbcon ostdbcon)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Ostdbcon.Update(ostdbcon);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteostdbcon(long ostdbconId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Ostdbcon ostdbcon = projectContext.Ostdbcon.First(p => p.OstdbconId == ostdbconId);
				projectContext.Ostdbcon.Remove(ostdbcon);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
