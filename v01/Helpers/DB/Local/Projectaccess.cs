using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Projectaccess
	{
		private LocalContext localContext;

		public Projectaccess(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long ProjectaccessCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Projectaccess.Count();
		}

		public List<Models.DB.Local.Projectaccess> GetAllProjectaccess()
		{
			List<Models.DB.Local.Projectaccess> Projectaccess = new List<Models.DB.Local.Projectaccess>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Projectaccess = localContext.Projectaccess.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Projectaccess;
		}
		public long Createprojectaccess(List<Models.DB.Local.Projectaccess> Projectaccess)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Projectaccess projectaccess in Projectaccess)
				{
					localContext.Projectaccess.Add(projectaccess);
					localContext.SaveChanges();
					returnid = projectaccess.ProjectaccessId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateprojectaccess(long id, Models.DB.Local.Projectaccess projectaccess)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Projectaccess.Update(projectaccess);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteprojectaccess(long projectaccessId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Projectaccess projectaccess = localContext.Projectaccess.First(p => p.ProjectaccessId == projectaccessId);
				localContext.Projectaccess.Remove(projectaccess);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
