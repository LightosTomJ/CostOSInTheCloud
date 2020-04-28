using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Roles
	{
		private LocalContext localContext;

		public Roles(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long RolesCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Roles.Count();
		}

		public List<Models.DB.Local.Roles> GetAllRoles()
		{
			List<Models.DB.Local.Roles> Roles = new List<Models.DB.Local.Roles>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Roles = localContext.Roles.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Roles;
		}
		public long Createroles(List<Models.DB.Local.Roles> Roles)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Roles roles in Roles)
				{
					localContext.Roles.Add(roles);
					localContext.SaveChanges();
					returnid = roles.RolesId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateroles(long id, Models.DB.Local.Roles roles)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Roles.Update(roles);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteroles(long rolesId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Roles roles = localContext.Roles.First(p => p.RolesId == rolesId);
				localContext.Roles.Remove(roles);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
