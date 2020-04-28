using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Boqitemmetadata
	{
		private ProjectContext projectContext;

		public Boqitemmetadata(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long BoqitemmetadataCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Boqitemmetadata.Count();
		}

		public List<Models.DB.Project.Boqitemmetadata> GetAllBoqitemmetadata()
		{
			List<Models.DB.Project.Boqitemmetadata> Boqitemmetadata = new List<Models.DB.Project.Boqitemmetadata>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Boqitemmetadata = projectContext.Boqitemmetadata.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Boqitemmetadata;
		}
		public long Createboqitemmetadata(List<Models.DB.Project.Boqitemmetadata> Boqitemmetadata)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Boqitemmetadata boqitemmetadata in Boqitemmetadata)
				{
					projectContext.Boqitemmetadata.Add(boqitemmetadata);
					projectContext.SaveChanges();
					returnid = boqitemmetadata.BoqitemmetadataId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateboqitemmetadata(long id, Models.DB.Project.Boqitemmetadata boqitemmetadata)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Boqitemmetadata.Update(boqitemmetadata);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteboqitemmetadata(long boqitemmetadataId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Boqitemmetadata boqitemmetadata = projectContext.Boqitemmetadata.First(p => p.BoqitemmetadataId == boqitemmetadataId);
				projectContext.Boqitemmetadata.Remove(boqitemmetadata);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
