using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Paramcondition
	{
		private ProjectContext projectContext;

		public Paramcondition(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long ParamconditionCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Paramcondition.Count();
		}

		public List<Models.DB.Project.Paramcondition> GetAllParamcondition()
		{
			List<Models.DB.Project.Paramcondition> Paramcondition = new List<Models.DB.Project.Paramcondition>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Paramcondition = projectContext.Paramcondition.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Paramcondition;
		}
		public long Createparamcondition(List<Models.DB.Project.Paramcondition> Paramcondition)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Paramcondition paramcondition in Paramcondition)
				{
					projectContext.Paramcondition.Add(paramcondition);
					projectContext.SaveChanges();
					returnid = paramcondition.ParamconditionId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateparamcondition(long id, Models.DB.Project.Paramcondition paramcondition)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Paramcondition.Update(paramcondition);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteparamcondition(long paramconditionId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Paramcondition paramcondition = projectContext.Paramcondition.First(p => p.ParamconditionId == paramconditionId);
				projectContext.Paramcondition.Remove(paramcondition);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
