using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Cndon
	{
		private ProjectContext projectContext;

		public Cndon(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long CndonCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Cndon.Count();
		}

		public List<Models.DB.Project.Cndon> GetAllCndon()
		{
			List<Models.DB.Project.Cndon> Cndon = new List<Models.DB.Project.Cndon>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Cndon = projectContext.Cndon.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Cndon;
		}
		public long Createcndon(List<Models.DB.Project.Cndon> Cndon)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Cndon cndon in Cndon)
				{
					projectContext.Cndon.Add(cndon);
					projectContext.SaveChanges();
					returnid = cndon.CndonId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatecndon(long id, Models.DB.Project.Cndon cndon)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Cndon.Update(cndon);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletecndon(long cndonId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Cndon cndon = projectContext.Cndon.First(p => p.CndonId == cndonId);
				projectContext.Cndon.Remove(cndon);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
