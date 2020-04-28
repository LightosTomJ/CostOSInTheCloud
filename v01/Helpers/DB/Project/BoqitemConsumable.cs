using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class BoqitemConsumable
	{
		private ProjectContext projectContext;

		public BoqitemConsumable(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long BoqitemConsumableCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.BoqitemConsumable.Count();
		}

		public List<Models.DB.Project.BoqitemConsumable> GetAllBoqitemConsumable()
		{
			List<Models.DB.Project.BoqitemConsumable> BoqitemConsumable = new List<Models.DB.Project.BoqitemConsumable>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				BoqitemConsumable = projectContext.BoqitemConsumable.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BoqitemConsumable;
		}
		public long CreateboqitemConsumable(List<Models.DB.Project.BoqitemConsumable> BoqitemConsumable)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.BoqitemConsumable boqitemConsumable in BoqitemConsumable)
				{
					projectContext.BoqitemConsumable.Add(boqitemConsumable);
					projectContext.SaveChanges();
					returnid = boqitemConsumable.BoqitemConsumableId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateboqitemConsumable(long id, Models.DB.Project.BoqitemConsumable boqitemConsumable)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.BoqitemConsumable.Update(boqitemConsumable);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteboqitemConsumable(long boqitemConsumableId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.BoqitemConsumable boqitemConsumable = projectContext.BoqitemConsumable.First(p => p.BoqitemConsumableId == boqitemConsumableId);
				projectContext.BoqitemConsumable.Remove(boqitemConsumable);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
