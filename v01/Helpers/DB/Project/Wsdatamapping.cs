using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Wsdatamapping
	{
		private ProjectContext projectContext;

		public Wsdatamapping(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long WsdatamappingCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Wsdatamapping.Count();
		}

		public List<Models.DB.Project.Wsdatamapping> GetAllWsdatamapping()
		{
			List<Models.DB.Project.Wsdatamapping> Wsdatamapping = new List<Models.DB.Project.Wsdatamapping>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Wsdatamapping = projectContext.Wsdatamapping.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Wsdatamapping;
		}
		public long Createwsdatamapping(List<Models.DB.Project.Wsdatamapping> Wsdatamapping)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Wsdatamapping wsdatamapping in Wsdatamapping)
				{
					projectContext.Wsdatamapping.Add(wsdatamapping);
					projectContext.SaveChanges();
					returnid = wsdatamapping.WsdatamappingId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatewsdatamapping(long id, Models.DB.Project.Wsdatamapping wsdatamapping)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Wsdatamapping.Update(wsdatamapping);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletewsdatamapping(long wsdatamappingId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Wsdatamapping wsdatamapping = projectContext.Wsdatamapping.First(p => p.WsdatamappingId == wsdatamappingId);
				projectContext.Wsdatamapping.Remove(wsdatamapping);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
