using Models.DB.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Config
{
	public class AspNetRoles
	{
		private ConfigContext configContext;

		public AspNetRoles(ConfigContext dbContext)
		{
			configContext = dbContext;
		}

		public long AspNetRolesCount()
		{
			if (configContext == null) configContext = new ConfigContext();
			return configContext.AspNetRoles.Count();
		}

		public List<Models.DB.Config.AspNetRoles> GetAllAspNetRoles()
		{
			List<Models.DB.Config.AspNetRoles> AspNetRoles = new List<Models.DB.Config.AspNetRoles>();
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				AspNetRoles = configContext.AspNetRoles.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AspNetRoles;
		}
		public long CreateaspNetRoles(List<Models.DB.Config.AspNetRoles> AspNetRoles)
		{
			long returnid = 0;
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				foreach (Models.DB.Config.AspNetRoles aspNetRoles in AspNetRoles)
				{
					configContext.AspNetRoles.Add(aspNetRoles);
					configContext.SaveChanges();
					returnid = aspNetRoles.AspNetRolesId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateaspNetRoles(long id, Models.DB.Config.AspNetRoles aspNetRoles)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				configContext.AspNetRoles.Update(aspNetRoles);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteaspNetRoles(long aspNetRolesId)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				Models.DB.Config.AspNetRoles aspNetRoles = configContext.AspNetRoles.First(p => p.AspNetRolesId == aspNetRolesId);
				configContext.AspNetRoles.Remove(aspNetRoles);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
