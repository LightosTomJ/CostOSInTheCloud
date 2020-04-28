using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Projectuser
	{
		private LocalContext localContext;

		public Projectuser(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long ProjectuserCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Projectuser.Count();
		}

		public List<Models.DB.Local.Projectuser> GetAllProjectuser()
		{
			List<Models.DB.Local.Projectuser> Projectuser = new List<Models.DB.Local.Projectuser>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Projectuser = localContext.Projectuser.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Projectuser;
		}
		public long Createprojectuser(List<Models.DB.Local.Projectuser> Projectuser)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Projectuser projectuser in Projectuser)
				{
					localContext.Projectuser.Add(projectuser);
					localContext.SaveChanges();
					returnid = projectuser.ProjectuserId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateprojectuser(long id, Models.DB.Local.Projectuser projectuser)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Projectuser.Update(projectuser);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteprojectuser(long projectuserId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Projectuser projectuser = localContext.Projectuser.First(p => p.ProjectuserId == projectuserId);
				localContext.Projectuser.Remove(projectuser);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
