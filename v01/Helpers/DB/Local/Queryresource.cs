using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Queryresource
	{
		private LocalContext localContext;

		public Queryresource(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long QueryresourceCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Queryresource.Count();
		}

		public List<Models.DB.Local.Queryresource> GetAllQueryresource()
		{
			List<Models.DB.Local.Queryresource> Queryresource = new List<Models.DB.Local.Queryresource>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Queryresource = localContext.Queryresource.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Queryresource;
		}
		public long Createqueryresource(List<Models.DB.Local.Queryresource> Queryresource)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Queryresource queryresource in Queryresource)
				{
					localContext.Queryresource.Add(queryresource);
					localContext.SaveChanges();
					returnid = queryresource.QueryresourceId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatequeryresource(long id, Models.DB.Local.Queryresource queryresource)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Queryresource.Update(queryresource);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletequeryresource(long queryresourceId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Queryresource queryresource = localContext.Queryresource.First(p => p.QueryresourceId == queryresourceId);
				localContext.Queryresource.Remove(queryresource);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
