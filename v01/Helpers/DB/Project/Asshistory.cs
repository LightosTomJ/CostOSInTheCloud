using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Asshistories
	{
		private ProjectContext projectContext;

		public Asshistories(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long AsshistoryCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Asshistory.Count();
		}

		public List<Models.DB.Project.Asshistory> GetAllAsshistories()
		{
			List<Models.DB.Project.Asshistory> Asshistories = new List<Models.DB.Project.Asshistory>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Asshistories = projectContext.Asshistory.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Asshistories;
		}
		public long Createasshistory(List<Models.DB.Project.Asshistory> Asshistories)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Asshistory asshistory in Asshistories)
				{
					projectContext.Asshistory.Add(asshistory);
					projectContext.SaveChanges();
					returnid = asshistory.AsshistoryId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateasshistory(long id, Models.DB.Project.Asshistory asshistory)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Asshistory.Update(asshistory);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteasshistory(long asshistoryId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Asshistory asshistory = projectContext.Asshistory.First(p => p.AsshistoryId == asshistoryId);
				projectContext.Asshistory.Remove(asshistory);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
