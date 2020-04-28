using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Principals
	{
		private LocalContext localContext;

		public Principals(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long PrincipalsCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Principals.Count();
		}

		public List<Models.DB.Local.Principals> GetAllPrincipals()
		{
			List<Models.DB.Local.Principals> Principals = new List<Models.DB.Local.Principals>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Principals = localContext.Principals.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Principals;
		}
		public long Createprincipals(List<Models.DB.Local.Principals> Principals)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Principals principals in Principals)
				{
					localContext.Principals.Add(principals);
					localContext.SaveChanges();
					returnid = principals.PrincipalsId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateprincipals(long id, Models.DB.Local.Principals principals)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Principals.Update(principals);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteprincipals(long principalsId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Principals principals = localContext.Principals.First(p => p.PrincipalsId == principalsId);
				localContext.Principals.Remove(principals);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
