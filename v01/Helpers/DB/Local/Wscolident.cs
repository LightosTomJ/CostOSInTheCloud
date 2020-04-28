using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Wscolident
	{
		private LocalContext localContext;

		public Wscolident(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long WscolidentCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Wscolident.Count();
		}

		public List<Models.DB.Local.Wscolident> GetAllWscolident()
		{
			List<Models.DB.Local.Wscolident> Wscolident = new List<Models.DB.Local.Wscolident>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Wscolident = localContext.Wscolident.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Wscolident;
		}
		public long Createwscolident(List<Models.DB.Local.Wscolident> Wscolident)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Wscolident wscolident in Wscolident)
				{
					localContext.Wscolident.Add(wscolident);
					localContext.SaveChanges();
					returnid = wscolident.WscolidentId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatewscolident(long id, Models.DB.Local.Wscolident wscolident)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Wscolident.Update(wscolident);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletewscolident(long wscolidentId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Wscolident wscolident = localContext.Wscolident.First(p => p.WscolidentId == wscolidentId);
				localContext.Wscolident.Remove(wscolident);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
