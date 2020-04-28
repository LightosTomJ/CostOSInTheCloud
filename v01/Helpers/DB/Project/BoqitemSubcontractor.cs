using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class BoqitemSubcontractor
	{
		private ProjectContext projectContext;

		public BoqitemSubcontractor(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long BoqitemSubcontractorCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.BoqitemSubcontractor.Count();
		}

		public List<Models.DB.Project.BoqitemSubcontractor> GetAllBoqitemSubcontractor()
		{
			List<Models.DB.Project.BoqitemSubcontractor> BoqitemSubcontractor = new List<Models.DB.Project.BoqitemSubcontractor>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				BoqitemSubcontractor = projectContext.BoqitemSubcontractor.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BoqitemSubcontractor;
		}
		public long CreateboqitemSubcontractor(List<Models.DB.Project.BoqitemSubcontractor> BoqitemSubcontractor)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.BoqitemSubcontractor boqitemSubcontractor in BoqitemSubcontractor)
				{
					projectContext.BoqitemSubcontractor.Add(boqitemSubcontractor);
					projectContext.SaveChanges();
					returnid = boqitemSubcontractor.BoqitemSubcontractorId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateboqitemSubcontractor(long id, Models.DB.Project.BoqitemSubcontractor boqitemSubcontractor)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.BoqitemSubcontractor.Update(boqitemSubcontractor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteboqitemSubcontractor(long boqitemSubcontractorId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.BoqitemSubcontractor boqitemSubcontractor = projectContext.BoqitemSubcontractor.First(p => p.BoqitemSubcontractorId == boqitemSubcontractorId);
				projectContext.BoqitemSubcontractor.Remove(boqitemSubcontractor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
