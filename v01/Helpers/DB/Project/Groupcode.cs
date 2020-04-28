using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Groupcode
	{
		private ProjectContext projectContext;

		public Groupcode(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long GroupcodeCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Groupcode.Count();
		}

		public List<Models.DB.Project.Groupcode> GetAllGroupcode()
		{
			List<Models.DB.Project.Groupcode> Groupcode = new List<Models.DB.Project.Groupcode>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Groupcode = projectContext.Groupcode.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Groupcode;
		}
		public long Creategroupcode(List<Models.DB.Project.Groupcode> Groupcode)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Groupcode groupcode in Groupcode)
				{
					projectContext.Groupcode.Add(groupcode);
					projectContext.SaveChanges();
					returnid = groupcode.GroupcodeId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updategroupcode(long id, Models.DB.Project.Groupcode groupcode)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Groupcode.Update(groupcode);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletegroupcode(long groupcodeId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Groupcode groupcode = projectContext.Groupcode.First(p => p.GroupcodeId == groupcodeId);
				projectContext.Groupcode.Remove(groupcode);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
