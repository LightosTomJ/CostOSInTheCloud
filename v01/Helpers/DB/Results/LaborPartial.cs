using Models.DB.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Results
{
	public class LaborPartial
	{
		private resultsContext resultsContext;

		public LaborPartial(resultsContext dbContext)
		{
			resultsContext = dbContext;
		}

		public long LaborPartialCount()
		{
			if (resultsContext == null) resultsContext = new resultsContext();
			return resultsContext.LaborPartial.Count();
		}

		public List<Models.DB.Results.LaborPartial> GetAllLaborPartial()
		{
			List<Models.DB.Results.LaborPartial> LaborPartial = new List<Models.DB.Results.LaborPartial>();
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				LaborPartial = resultsContext.LaborPartial.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return LaborPartial;
		}
		public long CreatelaborPartial(List<Models.DB.Results.LaborPartial> LaborPartial)
		{
			long returnid = 0;
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				foreach (Models.DB.Results.LaborPartial laborPartial in LaborPartial)
				{
					resultsContext.LaborPartial.Add(laborPartial);
					resultsContext.SaveChanges();
					returnid = laborPartial.LaborPartialId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatelaborPartial(long id, Models.DB.Results.LaborPartial laborPartial)
		{
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				resultsContext.LaborPartial.Update(laborPartial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletelaborPartial(long laborPartialId)
		{
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				Models.DB.Results.LaborPartial laborPartial = resultsContext.LaborPartial.First(p => p.LaborPartialId == laborPartialId);
				resultsContext.LaborPartial.Remove(laborPartial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
