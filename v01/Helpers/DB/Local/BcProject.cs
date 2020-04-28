using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcProject
	{
		private LocalContext localContext;

		public BcProject(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcProjectCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcProject.Count();
		}

		public List<Models.DB.Local.BcProject> GetAllBcProject()
		{
			List<Models.DB.Local.BcProject> BcProject = new List<Models.DB.Local.BcProject>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcProject = localContext.BcProject.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcProject;
		}
		public long CreatebcProject(List<Models.DB.Local.BcProject> BcProject)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcProject bcProject in BcProject)
				{
					localContext.BcProject.Add(bcProject);
					localContext.SaveChanges();
					returnid = bcProject.BcProjectId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcProject(long id, Models.DB.Local.BcProject bcProject)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcProject.Update(bcProject);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcProject(long bcProjectId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcProject bcProject = localContext.BcProject.First(p => p.BcProjectId == bcProjectId);
				localContext.BcProject.Remove(bcProject);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
