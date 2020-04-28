using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Cnmhistories
	{
		private ProjectContext projectContext;

		public Cnmhistories(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long CnmhistoryCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Cnmhistory.Count();
		}

		public List<Models.DB.Project.Cnmhistory> GetAllCnmhistories()
		{
			List<Models.DB.Project.Cnmhistory> Cnmhistories = new List<Models.DB.Project.Cnmhistory>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Cnmhistories = projectContext.Cnmhistory.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Cnmhistories;
		}
		public long Createcnmhistory(List<Models.DB.Project.Cnmhistory> Cnmhistories)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Cnmhistory cnmhistory in Cnmhistories)
				{
					projectContext.Cnmhistory.Add(cnmhistory);
					projectContext.SaveChanges();
					returnid = cnmhistory.CnmhistoryId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatecnmhistory(long id, Models.DB.Project.Cnmhistory cnmhistory)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Cnmhistory.Update(cnmhistory);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletecnmhistory(long cnmhistoryId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Cnmhistory cnmhistory = projectContext.Cnmhistory.First(p => p.CnmhistoryId == cnmhistoryId);
				projectContext.Cnmhistory.Remove(cnmhistory);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
