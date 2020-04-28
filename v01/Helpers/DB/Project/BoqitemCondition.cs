using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class BoqitemCondition
	{
		private ProjectContext projectContext;

		public BoqitemCondition(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long BoqitemConditionCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.BoqitemCondition.Count();
		}

		public List<Models.DB.Project.BoqitemCondition> GetAllBoqitemCondition()
		{
			List<Models.DB.Project.BoqitemCondition> BoqitemCondition = new List<Models.DB.Project.BoqitemCondition>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				BoqitemCondition = projectContext.BoqitemCondition.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BoqitemCondition;
		}
		public long CreateboqitemCondition(List<Models.DB.Project.BoqitemCondition> BoqitemCondition)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.BoqitemCondition boqitemCondition in BoqitemCondition)
				{
					projectContext.BoqitemCondition.Add(boqitemCondition);
					projectContext.SaveChanges();
					returnid = boqitemCondition.BoqitemConditionId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateboqitemCondition(long id, Models.DB.Project.BoqitemCondition boqitemCondition)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.BoqitemCondition.Update(boqitemCondition);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteboqitemCondition(long boqitemConditionId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.BoqitemCondition boqitemCondition = projectContext.BoqitemCondition.First(p => p.BoqitemConditionId == boqitemConditionId);
				projectContext.BoqitemCondition.Remove(boqitemCondition);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
