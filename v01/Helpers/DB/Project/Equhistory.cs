using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Equhistories
	{
		private ProjectContext projectContext;

		public Equhistories(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long EquhistoryCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Equhistory.Count();
		}

		public List<Models.DB.Project.Equhistory> GetAllEquhistories()
		{
			List<Models.DB.Project.Equhistory> Equhistories = new List<Models.DB.Project.Equhistory>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Equhistories = projectContext.Equhistory.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Equhistories;
		}
		public long Createequhistory(List<Models.DB.Project.Equhistory> Equhistories)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Equhistory equhistory in Equhistories)
				{
					projectContext.Equhistory.Add(equhistory);
					projectContext.SaveChanges();
					returnid = equhistory.EquhistoryId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateequhistory(long id, Models.DB.Project.Equhistory equhistory)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Equhistory.Update(equhistory);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteequhistory(long equhistoryId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Equhistory equhistory = projectContext.Equhistory.First(p => p.EquhistoryId == equhistoryId);
				projectContext.Equhistory.Remove(equhistory);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
