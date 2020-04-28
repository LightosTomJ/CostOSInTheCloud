using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class BoqitemLabor
	{
		private ProjectContext projectContext;

		public BoqitemLabor(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long BoqitemLaborCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.BoqitemLabor.Count();
		}

		public List<Models.DB.Project.BoqitemLabor> GetAllBoqitemLabor()
		{
			List<Models.DB.Project.BoqitemLabor> BoqitemLabor = new List<Models.DB.Project.BoqitemLabor>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				BoqitemLabor = projectContext.BoqitemLabor.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BoqitemLabor;
		}
		public long CreateboqitemLabor(List<Models.DB.Project.BoqitemLabor> BoqitemLabor)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.BoqitemLabor boqitemLabor in BoqitemLabor)
				{
					projectContext.BoqitemLabor.Add(boqitemLabor);
					projectContext.SaveChanges();
					returnid = boqitemLabor.BoqitemLaborId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateboqitemLabor(long id, Models.DB.Project.BoqitemLabor boqitemLabor)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.BoqitemLabor.Update(boqitemLabor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteboqitemLabor(long boqitemLaborId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.BoqitemLabor boqitemLabor = projectContext.BoqitemLabor.First(p => p.BoqitemLaborId == boqitemLaborId);
				projectContext.BoqitemLabor.Remove(boqitemLabor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
