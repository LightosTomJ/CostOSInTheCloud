using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Subcontractor
	{
		private ProjectContext projectContext;

		public Subcontractor(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long SubcontractorCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Subcontractor.Count();
		}

		public List<Models.DB.Project.Subcontractor> GetAllSubcontractor()
		{
			List<Models.DB.Project.Subcontractor> Subcontractor = new List<Models.DB.Project.Subcontractor>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Subcontractor = projectContext.Subcontractor.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Subcontractor;
		}
		public long Createsubcontractor(List<Models.DB.Project.Subcontractor> Subcontractor)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Subcontractor subcontractor in Subcontractor)
				{
					projectContext.Subcontractor.Add(subcontractor);
					projectContext.SaveChanges();
					returnid = subcontractor.SubcontractorId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatesubcontractor(long id, Models.DB.Project.Subcontractor subcontractor)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Subcontractor.Update(subcontractor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletesubcontractor(long subcontractorId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Subcontractor subcontractor = projectContext.Subcontractor.First(p => p.SubcontractorId == subcontractorId);
				projectContext.Subcontractor.Remove(subcontractor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
