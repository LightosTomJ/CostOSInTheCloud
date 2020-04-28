using Models.DB.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Results
{
	public class ParamItemPartial
	{
		private resultsContext resultsContext;

		public ParamItemPartial(resultsContext dbContext)
		{
			resultsContext = dbContext;
		}

		public long ParamItemPartialCount()
		{
			if (resultsContext == null) resultsContext = new resultsContext();
			return resultsContext.ParamItemPartial.Count();
		}

		public List<Models.DB.Results.ParamItemPartial> GetAllParamItemPartial()
		{
			List<Models.DB.Results.ParamItemPartial> ParamItemPartial = new List<Models.DB.Results.ParamItemPartial>();
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				ParamItemPartial = resultsContext.ParamItemPartial.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return ParamItemPartial;
		}
		public long CreateparamItemPartial(List<Models.DB.Results.ParamItemPartial> ParamItemPartial)
		{
			long returnid = 0;
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				foreach (Models.DB.Results.ParamItemPartial paramItemPartial in ParamItemPartial)
				{
					resultsContext.ParamItemPartial.Add(paramItemPartial);
					resultsContext.SaveChanges();
					returnid = paramItemPartial.ParamItemPartialId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateparamItemPartial(long id, Models.DB.Results.ParamItemPartial paramItemPartial)
		{
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				resultsContext.ParamItemPartial.Update(paramItemPartial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteparamItemPartial(long paramItemPartialId)
		{
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				Models.DB.Results.ParamItemPartial paramItemPartial = resultsContext.ParamItemPartial.First(p => p.ParamItemPartialId == paramItemPartialId);
				resultsContext.ParamItemPartial.Remove(paramItemPartial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
