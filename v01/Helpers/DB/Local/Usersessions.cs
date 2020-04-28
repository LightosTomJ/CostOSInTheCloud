using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Usersessions
	{
		private LocalContext localContext;

		public Usersessions(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long UsersessionsCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Usersessions.Count();
		}

		public List<Models.DB.Local.Usersessions> GetAllUsersessions()
		{
			List<Models.DB.Local.Usersessions> Usersessions = new List<Models.DB.Local.Usersessions>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Usersessions = localContext.Usersessions.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Usersessions;
		}
		public long Createusersessions(List<Models.DB.Local.Usersessions> Usersessions)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Usersessions usersessions in Usersessions)
				{
					localContext.Usersessions.Add(usersessions);
					localContext.SaveChanges();
					returnid = usersessions.UsersessionsId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateusersessions(long id, Models.DB.Local.Usersessions usersessions)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Usersessions.Update(usersessions);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteusersessions(long usersessionsId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Usersessions usersessions = localContext.Usersessions.First(p => p.UsersessionsId == usersessionsId);
				localContext.Usersessions.Remove(usersessions);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
