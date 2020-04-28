using Models.DB.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Config
{
	public class AspNetUsers
	{
		private ConfigContext configContext;

		public AspNetUsers(ConfigContext dbContext)
		{
			configContext = dbContext;
		}

		public long AspNetUsersCount()
		{
			if (configContext == null) configContext = new ConfigContext();
			return configContext.AspNetUsers.Count();
		}

		public List<Models.DB.Config.AspNetUsers> GetAllAspNetUsers()
		{
			List<Models.DB.Config.AspNetUsers> AspNetUsers = new List<Models.DB.Config.AspNetUsers>();
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				AspNetUsers = configContext.AspNetUsers.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AspNetUsers;
		}
		public long CreateaspNetUsers(List<Models.DB.Config.AspNetUsers> AspNetUsers)
		{
			long returnid = 0;
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				foreach (Models.DB.Config.AspNetUsers aspNetUsers in AspNetUsers)
				{
					configContext.AspNetUsers.Add(aspNetUsers);
					configContext.SaveChanges();
					returnid = aspNetUsers.AspNetUsersId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateaspNetUsers(long id, Models.DB.Config.AspNetUsers aspNetUsers)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				configContext.AspNetUsers.Update(aspNetUsers);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteaspNetUsers(long aspNetUsersId)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				Models.DB.Config.AspNetUsers aspNetUsers = configContext.AspNetUsers.First(p => p.AspNetUsersId == aspNetUsersId);
				configContext.AspNetUsers.Remove(aspNetUsers);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
