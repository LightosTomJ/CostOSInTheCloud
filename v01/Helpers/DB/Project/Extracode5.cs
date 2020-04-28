using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Extracode5
	{
		private ProjectContext projectContext;

		public Extracode5(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long Extracode5Count()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Extracode5.Count();
		}

		public List<Models.DB.Project.Extracode5> GetAllExtracode5()
		{
			List<Models.DB.Project.Extracode5> Extracode5 = new List<Models.DB.Project.Extracode5>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Extracode5 = projectContext.Extracode5.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Extracode5;
		}
		public long Createextracode5(List<Models.DB.Project.Extracode5> Extracode5)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Extracode5 extracode5 in Extracode5)
				{
					projectContext.Extracode5.Add(extracode5);
					projectContext.SaveChanges();
					returnid = extracode5.Extracode5Id;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateextracode5(long id, Models.DB.Project.Extracode5 extracode5)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Extracode5.Update(extracode5);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteextracode5(long extracode5Id)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Extracode5 extracode5 = projectContext.Extracode5.First(p => p.Extracode5Id == extracode5Id);
				projectContext.Extracode5.Remove(extracode5);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
