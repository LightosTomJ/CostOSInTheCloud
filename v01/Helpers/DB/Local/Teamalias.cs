using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Teamalias
	{
		private LocalContext localContext;

		public Teamalias(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long TeamaliasCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Teamalias.Count();
		}

		public List<Models.DB.Local.Teamalias> GetAllTeamalias()
		{
			List<Models.DB.Local.Teamalias> Teamalias = new List<Models.DB.Local.Teamalias>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Teamalias = localContext.Teamalias.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Teamalias;
		}
		public long Createteamalias(List<Models.DB.Local.Teamalias> Teamalias)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Teamalias teamalias in Teamalias)
				{
					localContext.Teamalias.Add(teamalias);
					localContext.SaveChanges();
					returnid = teamalias.TeamaliasId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateteamalias(long id, Models.DB.Local.Teamalias teamalias)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Teamalias.Update(teamalias);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteteamalias(long teamaliasId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Teamalias teamalias = localContext.Teamalias.First(p => p.TeamaliasId == teamaliasId);
				localContext.Teamalias.Remove(teamalias);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
