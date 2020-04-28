using Models.DB.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Config
{
	public class AspNetUserLogins
	{
		private ConfigContext configContext;

		public AspNetUserLogins(ConfigContext dbContext)
		{
			configContext = dbContext;
		}

		public long AspNetUserLoginsCount()
		{
			if (configContext == null) configContext = new ConfigContext();
			return configContext.AspNetUserLogins.Count();
		}

		public List<Models.DB.Config.AspNetUserLogins> GetAllAspNetUserLogins()
		{
			List<Models.DB.Config.AspNetUserLogins> AspNetUserLogins = new List<Models.DB.Config.AspNetUserLogins>();
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				AspNetUserLogins = configContext.AspNetUserLogins.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AspNetUserLogins;
		}
		public long CreateaspNetUserLogins(List<Models.DB.Config.AspNetUserLogins> AspNetUserLogins)
		{
			long returnid = 0;
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				foreach (Models.DB.Config.AspNetUserLogins aspNetUserLogins in AspNetUserLogins)
				{
					configContext.AspNetUserLogins.Add(aspNetUserLogins);
					configContext.SaveChanges();
					returnid = aspNetUserLogins.AspNetUserLoginsId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateaspNetUserLogins(long id, Models.DB.Config.AspNetUserLogins aspNetUserLogins)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				configContext.AspNetUserLogins.Update(aspNetUserLogins);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteaspNetUserLogins(long aspNetUserLoginsId)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				Models.DB.Config.AspNetUserLogins aspNetUserLogins = configContext.AspNetUserLogins.First(p => p.AspNetUserLoginsId == aspNetUserLoginsId);
				configContext.AspNetUserLogins.Remove(aspNetUserLogins);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
