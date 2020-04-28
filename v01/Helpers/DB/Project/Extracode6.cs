using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Extracode6
	{
		private ProjectContext projectContext;

		public Extracode6(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long Extracode6Count()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Extracode6.Count();
		}

		public List<Models.DB.Project.Extracode6> GetAllExtracode6()
		{
			List<Models.DB.Project.Extracode6> Extracode6 = new List<Models.DB.Project.Extracode6>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Extracode6 = projectContext.Extracode6.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Extracode6;
		}
		public long Createextracode6(List<Models.DB.Project.Extracode6> Extracode6)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Extracode6 extracode6 in Extracode6)
				{
					projectContext.Extracode6.Add(extracode6);
					projectContext.SaveChanges();
					returnid = extracode6.Extracode6Id;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateextracode6(long id, Models.DB.Project.Extracode6 extracode6)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Extracode6.Update(extracode6);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteextracode6(long extracode6Id)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Extracode6 extracode6 = projectContext.Extracode6.First(p => p.Extracode6Id == extracode6Id);
				projectContext.Extracode6.Remove(extracode6);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
