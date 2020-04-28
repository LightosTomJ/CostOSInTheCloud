using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Fncton
	{
		private ProjectContext projectContext;

		public Fncton(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long FnctonCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Fncton.Count();
		}

		public List<Models.DB.Project.Fncton> GetAllFncton()
		{
			List<Models.DB.Project.Fncton> Fncton = new List<Models.DB.Project.Fncton>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Fncton = projectContext.Fncton.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Fncton;
		}
		public long Createfncton(List<Models.DB.Project.Fncton> Fncton)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Fncton fncton in Fncton)
				{
					projectContext.Fncton.Add(fncton);
					projectContext.SaveChanges();
					returnid = fncton.FnctonId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatefncton(long id, Models.DB.Project.Fncton fncton)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Fncton.Update(fncton);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletefncton(long fnctonId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Fncton fncton = projectContext.Fncton.First(p => p.FnctonId == fnctonId);
				projectContext.Fncton.Remove(fncton);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
