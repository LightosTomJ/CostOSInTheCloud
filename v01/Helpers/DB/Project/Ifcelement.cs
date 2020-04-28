using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Ifcelement
	{
		private ProjectContext projectContext;

		public Ifcelement(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long IfcelementCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Ifcelement.Count();
		}

		public List<Models.DB.Project.Ifcelement> GetAllIfcelement()
		{
			List<Models.DB.Project.Ifcelement> Ifcelement = new List<Models.DB.Project.Ifcelement>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Ifcelement = projectContext.Ifcelement.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Ifcelement;
		}
		public long Createifcelement(List<Models.DB.Project.Ifcelement> Ifcelement)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Ifcelement ifcelement in Ifcelement)
				{
					projectContext.Ifcelement.Add(ifcelement);
					projectContext.SaveChanges();
					returnid = ifcelement.IfcelementId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateifcelement(long id, Models.DB.Project.Ifcelement ifcelement)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Ifcelement.Update(ifcelement);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteifcelement(long ifcelementId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Ifcelement ifcelement = projectContext.Ifcelement.First(p => p.IfcelementId == ifcelementId);
				projectContext.Ifcelement.Remove(ifcelement);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
