using Models.DB.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Results
{
	public class Partial
	{
		private resultsContext resultsContext;

		public Partial(resultsContext dbContext)
		{
			resultsContext = dbContext;
		}

		public long PartialCount()
		{
			if (resultsContext == null) resultsContext = new resultsContext();
			return resultsContext.Partial.Count();
		}

		public List<Models.DB.Results.Partial> GetAllPartial()
		{
			List<Models.DB.Results.Partial> Partial = new List<Models.DB.Results.Partial>();
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				Partial = resultsContext.Partial.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Partial;
		}
		public long Createpartial(List<Models.DB.Results.Partial> Partial)
		{
			long returnid = 0;
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				foreach (Models.DB.Results.Partial partial in Partial)
				{
					resultsContext.Partial.Add(partial);
					resultsContext.SaveChanges();
					returnid = partial.PartialId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatepartial(long id, Models.DB.Results.Partial partial)
		{
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				resultsContext.Partial.Update(partial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletepartial(long partialId)
		{
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				Models.DB.Results.Partial partial = resultsContext.Partial.First(p => p.PartialId == partialId);
				resultsContext.Partial.Remove(partial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
