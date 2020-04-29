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
	public class PartialsService
	{
		private ResultsContext resultsContext;

		public PartialsService(ResultsContext dbContext)
		{
			resultsContext = dbContext;
		}

		public async Task<long> PartialCount()
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				return await resultsContext.Partial.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Results.Partial>> GetAllPartials()
		{
			IList<Models.DB.Results.Partial> Partials = new List<Models.DB.Results.Partial>();
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				IList<Models.DB.Results.Partial> partials = await resultsContext.Partial.ToListAsync();
				return partials;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreatePartial(List<Models.DB.Results.Partial> Partials)
		{
			long returnid = -1;
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				foreach (Models.DB.Results.Partial partial in Partials)
				{
					resultsContext.Partial.Add(partial);
					await resultsContext.SaveChangesAsync();
					returnid = partial.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdatePartial(long id, Models.DB.Results.Partial partial)
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				resultsContext.Partial.Update(partial);
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
		public async Task<bool> DeletePartial(long partialId)
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				Models.DB.Results.Partial partial = resultsContext.Partial.First(p => p.Id == partialId);
				resultsContext.Partial.Remove(partial);
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
