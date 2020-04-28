using Models.DB.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Config
{
	public class AspNetUserClaims
	{
		private ConfigContext configContext;

		public AspNetUserClaims(ConfigContext dbContext)
		{
			configContext = dbContext;
		}

		public long AspNetUserClaimsCount()
		{
			if (configContext == null) configContext = new ConfigContext();
			return configContext.AspNetUserClaims.Count();
		}

		public List<Models.DB.Config.AspNetUserClaims> GetAllAspNetUserClaims()
		{
			List<Models.DB.Config.AspNetUserClaims> AspNetUserClaims = new List<Models.DB.Config.AspNetUserClaims>();
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				AspNetUserClaims = configContext.AspNetUserClaims.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AspNetUserClaims;
		}
		public long CreateaspNetUserClaims(List<Models.DB.Config.AspNetUserClaims> AspNetUserClaims)
		{
			long returnid = 0;
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				foreach (Models.DB.Config.AspNetUserClaims aspNetUserClaims in AspNetUserClaims)
				{
					configContext.AspNetUserClaims.Add(aspNetUserClaims);
					configContext.SaveChanges();
					returnid = aspNetUserClaims.AspNetUserClaimsId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateaspNetUserClaims(long id, Models.DB.Config.AspNetUserClaims aspNetUserClaims)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				configContext.AspNetUserClaims.Update(aspNetUserClaims);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteaspNetUserClaims(long aspNetUserClaimsId)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				Models.DB.Config.AspNetUserClaims aspNetUserClaims = configContext.AspNetUserClaims.First(p => p.AspNetUserClaimsId == aspNetUserClaimsId);
				configContext.AspNetUserClaims.Remove(aspNetUserClaims);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
