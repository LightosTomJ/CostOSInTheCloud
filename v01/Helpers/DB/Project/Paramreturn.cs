using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Paramreturn
	{
		private ProjectContext projectContext;

		public Paramreturn(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long ParamreturnCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Paramreturn.Count();
		}

		public List<Models.DB.Project.Paramreturn> GetAllParamreturn()
		{
			List<Models.DB.Project.Paramreturn> Paramreturn = new List<Models.DB.Project.Paramreturn>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Paramreturn = projectContext.Paramreturn.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Paramreturn;
		}
		public long Createparamreturn(List<Models.DB.Project.Paramreturn> Paramreturn)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Paramreturn paramreturn in Paramreturn)
				{
					projectContext.Paramreturn.Add(paramreturn);
					projectContext.SaveChanges();
					returnid = paramreturn.ParamreturnId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateparamreturn(long id, Models.DB.Project.Paramreturn paramreturn)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Paramreturn.Update(paramreturn);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteparamreturn(long paramreturnId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Paramreturn paramreturn = projectContext.Paramreturn.First(p => p.ParamreturnId == paramreturnId);
				projectContext.Paramreturn.Remove(paramreturn);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
