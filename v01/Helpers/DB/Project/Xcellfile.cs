using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Xcellfile
	{
		private ProjectContext projectContext;

		public Xcellfile(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long XcellfileCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Xcellfile.Count();
		}

		public List<Models.DB.Project.Xcellfile> GetAllXcellfile()
		{
			List<Models.DB.Project.Xcellfile> Xcellfile = new List<Models.DB.Project.Xcellfile>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Xcellfile = projectContext.Xcellfile.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Xcellfile;
		}
		public long Createxcellfile(List<Models.DB.Project.Xcellfile> Xcellfile)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Xcellfile xcellfile in Xcellfile)
				{
					projectContext.Xcellfile.Add(xcellfile);
					projectContext.SaveChanges();
					returnid = xcellfile.XcellfileId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatexcellfile(long id, Models.DB.Project.Xcellfile xcellfile)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Xcellfile.Update(xcellfile);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletexcellfile(long xcellfileId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Xcellfile xcellfile = projectContext.Xcellfile.First(p => p.XcellfileId == xcellfileId);
				projectContext.Xcellfile.Remove(xcellfile);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
