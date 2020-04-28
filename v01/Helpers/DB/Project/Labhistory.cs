using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Labhistories
	{
		private ProjectContext projectContext;

		public Labhistories(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long LabhistoryCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Labhistory.Count();
		}

		public List<Models.DB.Project.Labhistory> GetAllLabhistories()
		{
			List<Models.DB.Project.Labhistory> Labhistories = new List<Models.DB.Project.Labhistory>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Labhistories = projectContext.Labhistory.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Labhistories;
		}
		public long Createlabhistory(List<Models.DB.Project.Labhistory> Labhistories)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Labhistory labhistory in Labhistories)
				{
					projectContext.Labhistory.Add(labhistory);
					projectContext.SaveChanges();
					returnid = labhistory.LabhistoryId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatelabhistory(long id, Models.DB.Project.Labhistory labhistory)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Labhistory.Update(labhistory);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletelabhistory(long labhistoryId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Labhistory labhistory = projectContext.Labhistory.First(p => p.LabhistoryId == labhistoryId);
				projectContext.Labhistory.Remove(labhistory);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
