using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Queryrow
	{
		private LocalContext localContext;

		public Queryrow(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long QueryrowCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Queryrow.Count();
		}

		public List<Models.DB.Local.Queryrow> GetAllQueryrow()
		{
			List<Models.DB.Local.Queryrow> Queryrow = new List<Models.DB.Local.Queryrow>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Queryrow = localContext.Queryrow.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Queryrow;
		}
		public long Createqueryrow(List<Models.DB.Local.Queryrow> Queryrow)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Queryrow queryrow in Queryrow)
				{
					localContext.Queryrow.Add(queryrow);
					localContext.SaveChanges();
					returnid = queryrow.QueryrowId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatequeryrow(long id, Models.DB.Local.Queryrow queryrow)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Queryrow.Update(queryrow);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletequeryrow(long queryrowId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Queryrow queryrow = localContext.Queryrow.First(p => p.QueryrowId == queryrowId);
				localContext.Queryrow.Remove(queryrow);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
