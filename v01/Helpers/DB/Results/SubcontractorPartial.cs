using Models.DB.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Results
{
	public class SubcontractorPartial
	{
		private resultsContext resultsContext;

		public SubcontractorPartial(resultsContext dbContext)
		{
			resultsContext = dbContext;
		}

		public long SubcontractorPartialCount()
		{
			if (resultsContext == null) resultsContext = new resultsContext();
			return resultsContext.SubcontractorPartial.Count();
		}

		public List<Models.DB.Results.SubcontractorPartial> GetAllSubcontractorPartial()
		{
			List<Models.DB.Results.SubcontractorPartial> SubcontractorPartial = new List<Models.DB.Results.SubcontractorPartial>();
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				SubcontractorPartial = resultsContext.SubcontractorPartial.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return SubcontractorPartial;
		}
		public long CreatesubcontractorPartial(List<Models.DB.Results.SubcontractorPartial> SubcontractorPartial)
		{
			long returnid = 0;
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				foreach (Models.DB.Results.SubcontractorPartial subcontractorPartial in SubcontractorPartial)
				{
					resultsContext.SubcontractorPartial.Add(subcontractorPartial);
					resultsContext.SaveChanges();
					returnid = subcontractorPartial.SubcontractorPartialId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatesubcontractorPartial(long id, Models.DB.Results.SubcontractorPartial subcontractorPartial)
		{
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				resultsContext.SubcontractorPartial.Update(subcontractorPartial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletesubcontractorPartial(long subcontractorPartialId)
		{
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				Models.DB.Results.SubcontractorPartial subcontractorPartial = resultsContext.SubcontractorPartial.First(p => p.SubcontractorPartialId == subcontractorPartialId);
				resultsContext.SubcontractorPartial.Remove(subcontractorPartial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
