using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Paramoutput
	{
		private ProjectContext projectContext;

		public Paramoutput(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long ParamoutputCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Paramoutput.Count();
		}

		public List<Models.DB.Project.Paramoutput> GetAllParamoutput()
		{
			List<Models.DB.Project.Paramoutput> Paramoutput = new List<Models.DB.Project.Paramoutput>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Paramoutput = projectContext.Paramoutput.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Paramoutput;
		}
		public long Createparamoutput(List<Models.DB.Project.Paramoutput> Paramoutput)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Paramoutput paramoutput in Paramoutput)
				{
					projectContext.Paramoutput.Add(paramoutput);
					projectContext.SaveChanges();
					returnid = paramoutput.ParamoutputId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateparamoutput(long id, Models.DB.Project.Paramoutput paramoutput)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Paramoutput.Update(paramoutput);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteparamoutput(long paramoutputId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Paramoutput paramoutput = projectContext.Paramoutput.First(p => p.ParamoutputId == paramoutputId);
				projectContext.Paramoutput.Remove(paramoutput);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
