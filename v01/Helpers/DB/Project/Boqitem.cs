using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Boqitem
	{
		private ProjectContext projectContext;

		public Boqitem(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long BoqitemCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Boqitem.Count();
		}

		public List<Models.DB.Project.Boqitem> GetAllBoqitem()
		{
			List<Models.DB.Project.Boqitem> Boqitem = new List<Models.DB.Project.Boqitem>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Boqitem = projectContext.Boqitem.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Boqitem;
		}
		public long Createboqitem(List<Models.DB.Project.Boqitem> Boqitem)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Boqitem boqitem in Boqitem)
				{
					projectContext.Boqitem.Add(boqitem);
					projectContext.SaveChanges();
					returnid = boqitem.BoqitemId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateboqitem(long id, Models.DB.Project.Boqitem boqitem)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Boqitem.Update(boqitem);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteboqitem(long boqitemId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Boqitem boqitem = projectContext.Boqitem.First(p => p.BoqitemId == boqitemId);
				projectContext.Boqitem.Remove(boqitem);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
