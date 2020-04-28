using Models.DB.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Config
{
	public class AspNetUserRoles
	{
		private ConfigContext configContext;

		public AspNetUserRoles(ConfigContext dbContext)
		{
			configContext = dbContext;
		}

		public long AspNetUserRolesCount()
		{
			if (configContext == null) configContext = new ConfigContext();
			return configContext.AspNetUserRoles.Count();
		}

		public List<Models.DB.Config.AspNetUserRoles> GetAllAspNetUserRoles()
		{
			List<Models.DB.Config.AspNetUserRoles> AspNetUserRoles = new List<Models.DB.Config.AspNetUserRoles>();
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				AspNetUserRoles = configContext.AspNetUserRoles.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AspNetUserRoles;
		}
		public long CreateaspNetUserRoles(List<Models.DB.Config.AspNetUserRoles> AspNetUserRoles)
		{
			long returnid = 0;
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				foreach (Models.DB.Config.AspNetUserRoles aspNetUserRoles in AspNetUserRoles)
				{
					configContext.AspNetUserRoles.Add(aspNetUserRoles);
					configContext.SaveChanges();
					returnid = aspNetUserRoles.AspNetUserRolesId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateaspNetUserRoles(long id, Models.DB.Config.AspNetUserRoles aspNetUserRoles)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				configContext.AspNetUserRoles.Update(aspNetUserRoles);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteaspNetUserRoles(long aspNetUserRolesId)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				Models.DB.Config.AspNetUserRoles aspNetUserRoles = configContext.AspNetUserRoles.First(p => p.AspNetUserRolesId == aspNetUserRolesId);
				configContext.AspNetUserRoles.Remove(aspNetUserRoles);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
