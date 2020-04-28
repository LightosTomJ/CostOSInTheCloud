using Models.DB.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Config
{
	public class AspNetRoleClaims
	{
		private ConfigContext configContext;

		public AspNetRoleClaims(ConfigContext dbContext)
		{
			configContext = dbContext;
		}

		public long AspNetRoleClaimsCount()
		{
			if (configContext == null) configContext = new ConfigContext();
			return configContext.AspNetRoleClaims.Count();
		}

		public List<Models.DB.Config.AspNetRoleClaims> GetAllAspNetRoleClaims()
		{
			List<Models.DB.Config.AspNetRoleClaims> AspNetRoleClaims = new List<Models.DB.Config.AspNetRoleClaims>();
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				AspNetRoleClaims = configContext.AspNetRoleClaims.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AspNetRoleClaims;
		}
		public long CreateaspNetRoleClaims(List<Models.DB.Config.AspNetRoleClaims> AspNetRoleClaims)
		{
			long returnid = 0;
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				foreach (Models.DB.Config.AspNetRoleClaims aspNetRoleClaims in AspNetRoleClaims)
				{
					configContext.AspNetRoleClaims.Add(aspNetRoleClaims);
					configContext.SaveChanges();
					returnid = aspNetRoleClaims.AspNetRoleClaimsId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateaspNetRoleClaims(long id, Models.DB.Config.AspNetRoleClaims aspNetRoleClaims)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				configContext.AspNetRoleClaims.Update(aspNetRoleClaims);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteaspNetRoleClaims(long aspNetRoleClaimsId)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				Models.DB.Config.AspNetRoleClaims aspNetRoleClaims = configContext.AspNetRoleClaims.First(p => p.AspNetRoleClaimsId == aspNetRoleClaimsId);
				configContext.AspNetRoleClaims.Remove(aspNetRoleClaims);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
