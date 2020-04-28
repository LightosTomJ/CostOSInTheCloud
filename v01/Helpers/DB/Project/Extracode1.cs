using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Extracode1
	{
		private ProjectContext projectContext;

		public Extracode1(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long Extracode1Count()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Extracode1.Count();
		}

		public List<Models.DB.Project.Extracode1> GetAllExtracode1()
		{
			List<Models.DB.Project.Extracode1> Extracode1 = new List<Models.DB.Project.Extracode1>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Extracode1 = projectContext.Extracode1.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Extracode1;
		}
		public long Createextracode1(List<Models.DB.Project.Extracode1> Extracode1)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Extracode1 extracode1 in Extracode1)
				{
					projectContext.Extracode1.Add(extracode1);
					projectContext.SaveChanges();
					returnid = extracode1.Extracode1Id;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateextracode1(long id, Models.DB.Project.Extracode1 extracode1)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Extracode1.Update(extracode1);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteextracode1(long extracode1Id)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Extracode1 extracode1 = projectContext.Extracode1.First(p => p.Extracode1Id == extracode1Id);
				projectContext.Extracode1.Remove(extracode1);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
