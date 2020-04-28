using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Extracode2
	{
		private ProjectContext projectContext;

		public Extracode2(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long Extracode2Count()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Extracode2.Count();
		}

		public List<Models.DB.Project.Extracode2> GetAllExtracode2()
		{
			List<Models.DB.Project.Extracode2> Extracode2 = new List<Models.DB.Project.Extracode2>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Extracode2 = projectContext.Extracode2.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Extracode2;
		}
		public long Createextracode2(List<Models.DB.Project.Extracode2> Extracode2)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Extracode2 extracode2 in Extracode2)
				{
					projectContext.Extracode2.Add(extracode2);
					projectContext.SaveChanges();
					returnid = extracode2.Extracode2Id;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateextracode2(long id, Models.DB.Project.Extracode2 extracode2)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Extracode2.Update(extracode2);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteextracode2(long extracode2Id)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Extracode2 extracode2 = projectContext.Extracode2.First(p => p.Extracode2Id == extracode2Id);
				projectContext.Extracode2.Remove(extracode2);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
