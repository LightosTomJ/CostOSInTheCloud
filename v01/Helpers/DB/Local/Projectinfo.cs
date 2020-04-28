using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Projectinfo
	{
		private LocalContext localContext;

		public Projectinfo(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long ProjectinfoCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Projectinfo.Count();
		}

		public List<Models.DB.Local.Projectinfo> GetAllProjectinfo()
		{
			List<Models.DB.Local.Projectinfo> Projectinfo = new List<Models.DB.Local.Projectinfo>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Projectinfo = localContext.Projectinfo.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Projectinfo;
		}
		public long Createprojectinfo(List<Models.DB.Local.Projectinfo> Projectinfo)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Projectinfo projectinfo in Projectinfo)
				{
					localContext.Projectinfo.Add(projectinfo);
					localContext.SaveChanges();
					returnid = projectinfo.ProjectinfoId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateprojectinfo(long id, Models.DB.Local.Projectinfo projectinfo)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Projectinfo.Update(projectinfo);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteprojectinfo(long projectinfoId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Projectinfo projectinfo = localContext.Projectinfo.First(p => p.ProjectinfoId == projectinfoId);
				localContext.Projectinfo.Remove(projectinfo);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
