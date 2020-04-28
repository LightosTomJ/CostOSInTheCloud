using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Extracode3
	{
		private ProjectContext projectContext;

		public Extracode3(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long Extracode3Count()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Extracode3.Count();
		}

		public List<Models.DB.Project.Extracode3> GetAllExtracode3()
		{
			List<Models.DB.Project.Extracode3> Extracode3 = new List<Models.DB.Project.Extracode3>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Extracode3 = projectContext.Extracode3.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Extracode3;
		}
		public long Createextracode3(List<Models.DB.Project.Extracode3> Extracode3)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Extracode3 extracode3 in Extracode3)
				{
					projectContext.Extracode3.Add(extracode3);
					projectContext.SaveChanges();
					returnid = extracode3.Extracode3Id;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateextracode3(long id, Models.DB.Project.Extracode3 extracode3)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Extracode3.Update(extracode3);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteextracode3(long extracode3Id)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Extracode3 extracode3 = projectContext.Extracode3.First(p => p.Extracode3Id == extracode3Id);
				projectContext.Extracode3.Remove(extracode3);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
