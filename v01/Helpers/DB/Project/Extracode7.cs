using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Extracode7
	{
		private ProjectContext projectContext;

		public Extracode7(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long Extracode7Count()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Extracode7.Count();
		}

		public List<Models.DB.Project.Extracode7> GetAllExtracode7()
		{
			List<Models.DB.Project.Extracode7> Extracode7 = new List<Models.DB.Project.Extracode7>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Extracode7 = projectContext.Extracode7.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Extracode7;
		}
		public long Createextracode7(List<Models.DB.Project.Extracode7> Extracode7)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Extracode7 extracode7 in Extracode7)
				{
					projectContext.Extracode7.Add(extracode7);
					projectContext.SaveChanges();
					returnid = extracode7.Extracode7Id;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateextracode7(long id, Models.DB.Project.Extracode7 extracode7)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Extracode7.Update(extracode7);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteextracode7(long extracode7Id)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Extracode7 extracode7 = projectContext.Extracode7.First(p => p.Extracode7Id == extracode7Id);
				projectContext.Extracode7.Remove(extracode7);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
