using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Mathistories
	{
		private ProjectContext projectContext;

		public Mathistories(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long MathistoryCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Mathistory.Count();
		}

		public List<Models.DB.Project.Mathistory> GetAllMathistories()
		{
			List<Models.DB.Project.Mathistory> Mathistories = new List<Models.DB.Project.Mathistory>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Mathistories = projectContext.Mathistory.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Mathistories;
		}
		public long Createmathistory(List<Models.DB.Project.Mathistory> Mathistories)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Mathistory mathistory in Mathistories)
				{
					projectContext.Mathistory.Add(mathistory);
					projectContext.SaveChanges();
					returnid = mathistory.MathistoryId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatemathistory(long id, Models.DB.Project.Mathistory mathistory)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Mathistory.Update(mathistory);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletemathistory(long mathistoryId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Mathistory mathistory = projectContext.Mathistory.First(p => p.MathistoryId == mathistoryId);
				projectContext.Mathistory.Remove(mathistory);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
