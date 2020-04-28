using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Extracode4
	{
		private ProjectContext projectContext;

		public Extracode4(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long Extracode4Count()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Extracode4.Count();
		}

		public List<Models.DB.Project.Extracode4> GetAllExtracode4()
		{
			List<Models.DB.Project.Extracode4> Extracode4 = new List<Models.DB.Project.Extracode4>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Extracode4 = projectContext.Extracode4.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Extracode4;
		}
		public long Createextracode4(List<Models.DB.Project.Extracode4> Extracode4)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Extracode4 extracode4 in Extracode4)
				{
					projectContext.Extracode4.Add(extracode4);
					projectContext.SaveChanges();
					returnid = extracode4.Extracode4Id;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateextracode4(long id, Models.DB.Project.Extracode4 extracode4)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Extracode4.Update(extracode4);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteextracode4(long extracode4Id)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Extracode4 extracode4 = projectContext.Extracode4.First(p => p.Extracode4Id == extracode4Id);
				projectContext.Extracode4.Remove(extracode4);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
