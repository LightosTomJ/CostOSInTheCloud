using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Wsrevision
	{
		private LocalContext localContext;

		public Wsrevision(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long WsrevisionCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Wsrevision.Count();
		}

		public List<Models.DB.Local.Wsrevision> GetAllWsrevision()
		{
			List<Models.DB.Local.Wsrevision> Wsrevision = new List<Models.DB.Local.Wsrevision>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Wsrevision = localContext.Wsrevision.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Wsrevision;
		}
		public long Createwsrevision(List<Models.DB.Local.Wsrevision> Wsrevision)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Wsrevision wsrevision in Wsrevision)
				{
					localContext.Wsrevision.Add(wsrevision);
					localContext.SaveChanges();
					returnid = wsrevision.WsrevisionId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatewsrevision(long id, Models.DB.Local.Wsrevision wsrevision)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Wsrevision.Update(wsrevision);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletewsrevision(long wsrevisionId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Wsrevision wsrevision = localContext.Wsrevision.First(p => p.WsrevisionId == wsrevisionId);
				localContext.Wsrevision.Remove(wsrevision);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
