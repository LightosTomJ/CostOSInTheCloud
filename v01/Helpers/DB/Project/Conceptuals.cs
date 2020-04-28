using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Conceptuals
	{
		private ProjectContext projectContext;

		public Conceptuals(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long ConceptualsCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Conceptuals.Count();
		}

		public List<Models.DB.Project.Conceptuals> GetAllConceptuals()
		{
			List<Models.DB.Project.Conceptuals> Conceptuals = new List<Models.DB.Project.Conceptuals>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Conceptuals = projectContext.Conceptuals.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Conceptuals;
		}
		public long Createconceptuals(List<Models.DB.Project.Conceptuals> Conceptuals)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Conceptuals conceptuals in Conceptuals)
				{
					projectContext.Conceptuals.Add(conceptuals);
					projectContext.SaveChanges();
					returnid = conceptuals.ConceptualsId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateconceptuals(long id, Models.DB.Project.Conceptuals conceptuals)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Conceptuals.Update(conceptuals);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteconceptuals(long conceptualsId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Conceptuals conceptuals = projectContext.Conceptuals.First(p => p.ConceptualsId == conceptualsId);
				projectContext.Conceptuals.Remove(conceptuals);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
