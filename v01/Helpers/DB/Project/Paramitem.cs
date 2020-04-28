using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Paramitem
	{
		private ProjectContext projectContext;

		public Paramitem(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long ParamitemCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Paramitem.Count();
		}

		public List<Models.DB.Project.Paramitem> GetAllParamitem()
		{
			List<Models.DB.Project.Paramitem> Paramitem = new List<Models.DB.Project.Paramitem>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Paramitem = projectContext.Paramitem.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Paramitem;
		}
		public long Createparamitem(List<Models.DB.Project.Paramitem> Paramitem)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Paramitem paramitem in Paramitem)
				{
					projectContext.Paramitem.Add(paramitem);
					projectContext.SaveChanges();
					returnid = paramitem.ParamitemId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateparamitem(long id, Models.DB.Project.Paramitem paramitem)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Paramitem.Update(paramitem);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteparamitem(long paramitemId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Paramitem paramitem = projectContext.Paramitem.First(p => p.ParamitemId == paramitemId);
				projectContext.Paramitem.Remove(paramitem);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
