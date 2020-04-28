using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Subhistories
	{
		private ProjectContext projectContext;

		public Subhistories(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long SubhistoryCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Subhistory.Count();
		}

		public List<Models.DB.Project.Subhistory> GetAllSubhistories()
		{
			List<Models.DB.Project.Subhistory> Subhistories = new List<Models.DB.Project.Subhistory>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Subhistories = projectContext.Subhistory.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Subhistories;
		}
		public long Createsubhistory(List<Models.DB.Project.Subhistory> Subhistories)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Subhistory subhistory in Subhistories)
				{
					projectContext.Subhistory.Add(subhistory);
					projectContext.SaveChanges();
					returnid = subhistory.SubhistoryId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatesubhistory(long id, Models.DB.Project.Subhistory subhistory)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Subhistory.Update(subhistory);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletesubhistory(long subhistoryId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Subhistory subhistory = projectContext.Subhistory.First(p => p.SubhistoryId == subhistoryId);
				projectContext.Subhistory.Remove(subhistory);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
