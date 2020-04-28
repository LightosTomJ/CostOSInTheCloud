using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class AlcUserGroups
	{
		private LocalContext localContext;

		public AlcUserGroups(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long AlcUserGroupsCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.AlcUserGroups.Count();
		}

		public List<Models.DB.Local.AlcUserGroups> GetAllAlcUserGroups()
		{
			List<Models.DB.Local.AlcUserGroups> AlcUserGroups = new List<Models.DB.Local.AlcUserGroups>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				AlcUserGroups = localContext.AlcUserGroups.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AlcUserGroups;
		}
		public long CreatealcUserGroups(List<Models.DB.Local.AlcUserGroups> AlcUserGroups)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AlcUserGroups alcUserGroups in AlcUserGroups)
				{
					localContext.AlcUserGroups.Add(alcUserGroups);
					localContext.SaveChanges();
					returnid = alcUserGroups.AlcUserGroupsId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatealcUserGroups(long id, Models.DB.Local.AlcUserGroups alcUserGroups)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AlcUserGroups.Update(alcUserGroups);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletealcUserGroups(long alcUserGroupsId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AlcUserGroups alcUserGroups = localContext.AlcUserGroups.First(p => p.AlcUserGroupsId == alcUserGroupsId);
				localContext.AlcUserGroups.Remove(alcUserGroups);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
