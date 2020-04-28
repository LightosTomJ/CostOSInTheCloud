using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Gekcode
	{
		private ProjectContext projectContext;

		public Gekcode(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long GekcodeCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Gekcode.Count();
		}

		public List<Models.DB.Project.Gekcode> GetAllGekcode()
		{
			List<Models.DB.Project.Gekcode> Gekcode = new List<Models.DB.Project.Gekcode>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Gekcode = projectContext.Gekcode.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Gekcode;
		}
		public long Creategekcode(List<Models.DB.Project.Gekcode> Gekcode)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Gekcode gekcode in Gekcode)
				{
					projectContext.Gekcode.Add(gekcode);
					projectContext.SaveChanges();
					returnid = gekcode.GekcodeId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updategekcode(long id, Models.DB.Project.Gekcode gekcode)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Gekcode.Update(gekcode);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletegekcode(long gekcodeId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Gekcode gekcode = projectContext.Gekcode.First(p => p.GekcodeId == gekcodeId);
				projectContext.Gekcode.Remove(gekcode);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
