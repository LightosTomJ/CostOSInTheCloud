using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Paraminput
	{
		private ProjectContext projectContext;

		public Paraminput(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long ParaminputCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Paraminput.Count();
		}

		public List<Models.DB.Project.Paraminput> GetAllParaminput()
		{
			List<Models.DB.Project.Paraminput> Paraminput = new List<Models.DB.Project.Paraminput>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Paraminput = projectContext.Paraminput.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Paraminput;
		}
		public long Createparaminput(List<Models.DB.Project.Paraminput> Paraminput)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Paraminput paraminput in Paraminput)
				{
					projectContext.Paraminput.Add(paraminput);
					projectContext.SaveChanges();
					returnid = paraminput.ParaminputId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateparaminput(long id, Models.DB.Project.Paraminput paraminput)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Paraminput.Update(paraminput);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteparaminput(long paraminputId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Paraminput paraminput = projectContext.Paraminput.First(p => p.ParaminputId == paraminputId);
				projectContext.Paraminput.Remove(paraminput);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
