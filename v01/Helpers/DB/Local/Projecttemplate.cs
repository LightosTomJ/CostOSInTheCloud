using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Projecttemplate
	{
		private LocalContext localContext;

		public Projecttemplate(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long ProjecttemplateCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Projecttemplate.Count();
		}

		public List<Models.DB.Local.Projecttemplate> GetAllProjecttemplate()
		{
			List<Models.DB.Local.Projecttemplate> Projecttemplate = new List<Models.DB.Local.Projecttemplate>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Projecttemplate = localContext.Projecttemplate.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Projecttemplate;
		}
		public long Createprojecttemplate(List<Models.DB.Local.Projecttemplate> Projecttemplate)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Projecttemplate projecttemplate in Projecttemplate)
				{
					localContext.Projecttemplate.Add(projecttemplate);
					localContext.SaveChanges();
					returnid = projecttemplate.ProjecttemplateId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateprojecttemplate(long id, Models.DB.Local.Projecttemplate projecttemplate)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Projecttemplate.Update(projecttemplate);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteprojecttemplate(long projecttemplateId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Projecttemplate projecttemplate = localContext.Projecttemplate.First(p => p.ProjecttemplateId == projecttemplateId);
				localContext.Projecttemplate.Remove(projecttemplate);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
