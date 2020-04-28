using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Extqueries
	{
		private LocalContext localContext;

		public Extqueries(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long ExtqueryCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Extquery.Count();
		}

		public List<Models.DB.Local.Extquery> GetAllExtqueries()
		{
			List<Models.DB.Local.Extquery> Extqueries = new List<Models.DB.Local.Extquery>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Extqueries = localContext.Extquery.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Extqueries;
		}
		public long Createextquery(List<Models.DB.Local.Extquery> Extqueries)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Extquery extquery in Extqueries)
				{
					localContext.Extquery.Add(extquery);
					localContext.SaveChanges();
					returnid = extquery.ExtqueryId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateextquery(long id, Models.DB.Local.Extquery extquery)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Extquery.Update(extquery);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteextquery(long extqueryId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Extquery extquery = localContext.Extquery.First(p => p.ExtqueryId == extqueryId);
				localContext.Extquery.Remove(extquery);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
