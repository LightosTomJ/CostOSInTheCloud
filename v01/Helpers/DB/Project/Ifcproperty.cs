using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Ifcproperties
	{
		private ProjectContext projectContext;

		public Ifcproperties(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long IfcpropertyCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Ifcproperty.Count();
		}

		public List<Models.DB.Project.Ifcproperty> GetAllIfcproperties()
		{
			List<Models.DB.Project.Ifcproperty> Ifcproperties = new List<Models.DB.Project.Ifcproperty>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Ifcproperties = projectContext.Ifcproperty.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Ifcproperties;
		}
		public long Createifcproperty(List<Models.DB.Project.Ifcproperty> Ifcproperties)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Ifcproperty ifcproperty in Ifcproperties)
				{
					projectContext.Ifcproperty.Add(ifcproperty);
					projectContext.SaveChanges();
					returnid = ifcproperty.IfcpropertyId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateifcproperty(long id, Models.DB.Project.Ifcproperty ifcproperty)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Ifcproperty.Update(ifcproperty);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteifcproperty(long ifcpropertyId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Ifcproperty ifcproperty = projectContext.Ifcproperty.First(p => p.IfcpropertyId == ifcpropertyId);
				projectContext.Ifcproperty.Remove(ifcproperty);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
