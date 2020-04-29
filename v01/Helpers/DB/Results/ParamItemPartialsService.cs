using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Results
{
	public class ParamItemPartialsService
	{
		private ResultsContext resultsContext;

		public ParamItemPartialsService(ResultsContext dbContext)
		{
			resultsContext = dbContext;
		}

		public async Task<long> ParamItemPartialCount()
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				return await resultsContext.ParamItemPartial.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Results.ParamItemPartial>> GetAllParamItemPartials()
		{
			IList<Models.DB.Results.ParamItemPartial> ParamItemPartials = new List<Models.DB.Results.ParamItemPartial>();
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				IList<Models.DB.Results.ParamItemPartial> paramItemPartials = await resultsContext.ParamItemPartial.ToListAsync();
				return paramItemPartials;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateParamItemPartial(List<Models.DB.Results.ParamItemPartial> ParamItemPartials)
		{
			long returnid = -1;
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				foreach (Models.DB.Results.ParamItemPartial paramItemPartial in ParamItemPartials)
				{
					resultsContext.ParamItemPartial.Add(paramItemPartial);
					await resultsContext.SaveChangesAsync();
					returnid = paramItemPartial.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateParamItemPartial(long id, Models.DB.Results.ParamItemPartial paramItemPartial)
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				resultsContext.ParamItemPartial.Update(paramItemPartial);
				await resultsContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
		public async Task<bool> DeleteParamItemPartial(long paramItemPartialId)
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				Models.DB.Results.ParamItemPartial paramItemPartial = resultsContext.ParamItemPartial.First(p => p.Id == paramItemPartialId);
				resultsContext.ParamItemPartial.Remove(paramItemPartial);
				await resultsContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
	}
}
