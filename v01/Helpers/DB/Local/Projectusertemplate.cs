using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Projectusertemplate
	{
		private LocalContext localContext;

		public Projectusertemplate(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long ProjectusertemplateCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Projectusertemplate.Count();
		}

		public List<Models.DB.Local.Projectusertemplate> GetAllProjectusertemplate()
		{
			List<Models.DB.Local.Projectusertemplate> Projectusertemplate = new List<Models.DB.Local.Projectusertemplate>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Projectusertemplate = localContext.Projectusertemplate.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Projectusertemplate;
		}
		public long Createprojectusertemplate(List<Models.DB.Local.Projectusertemplate> Projectusertemplate)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Projectusertemplate projectusertemplate in Projectusertemplate)
				{
					localContext.Projectusertemplate.Add(projectusertemplate);
					localContext.SaveChanges();
					returnid = projectusertemplate.ProjectusertemplateId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateprojectusertemplate(long id, Models.DB.Local.Projectusertemplate projectusertemplate)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Projectusertemplate.Update(projectusertemplate);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteprojectusertemplate(long projectusertemplateId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Projectusertemplate projectusertemplate = localContext.Projectusertemplate.First(p => p.ProjectusertemplateId == projectusertemplateId);
				localContext.Projectusertemplate.Remove(projectusertemplate);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
