using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Projecturl
	{
		private LocalContext localContext;

		public Projecturl(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long ProjecturlCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Projecturl.Count();
		}

		public List<Models.DB.Local.Projecturl> GetAllProjecturl()
		{
			List<Models.DB.Local.Projecturl> Projecturl = new List<Models.DB.Local.Projecturl>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Projecturl = localContext.Projecturl.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Projecturl;
		}
		public long Createprojecturl(List<Models.DB.Local.Projecturl> Projecturl)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Projecturl projecturl in Projecturl)
				{
					localContext.Projecturl.Add(projecturl);
					localContext.SaveChanges();
					returnid = projecturl.ProjecturlId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateprojecturl(long id, Models.DB.Local.Projecturl projecturl)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Projecturl.Update(projecturl);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteprojecturl(long projecturlId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Projecturl projecturl = localContext.Projecturl.First(p => p.ProjecturlId == projecturlId);
				localContext.Projecturl.Remove(projecturl);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
