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
	public class ConsumablePartialsService
	{
		private ResultsContext resultsContext;

		public ConsumablePartialsService(ResultsContext dbContext)
		{
			resultsContext = dbContext;
		}

		public async Task<long> ConsumablePartialCount()
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				return await resultsContext.ConsumablePartial.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Results.ConsumablePartial>> GetAllConsumablePartials()
		{
			IList<Models.DB.Results.ConsumablePartial> ConsumablePartials = new List<Models.DB.Results.ConsumablePartial>();
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				IList<Models.DB.Results.ConsumablePartial> consumablePartials = await resultsContext.ConsumablePartial.ToListAsync();
				return consumablePartials;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateConsumablePartial(List<Models.DB.Results.ConsumablePartial> ConsumablePartials)
		{
			long returnid = -1;
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				foreach (Models.DB.Results.ConsumablePartial consumablePartial in ConsumablePartials)
				{
					resultsContext.ConsumablePartial.Add(consumablePartial);
					await resultsContext.SaveChangesAsync();
					returnid = consumablePartial.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateConsumablePartial(long id, Models.DB.Results.ConsumablePartial consumablePartial)
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				resultsContext.ConsumablePartial.Update(consumablePartial);
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
		public async Task<bool> DeleteConsumablePartial(long consumablePartialId)
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				Models.DB.Results.ConsumablePartial consumablePartial = resultsContext.ConsumablePartial.First(p => p.Id == consumablePartialId);
				resultsContext.ConsumablePartial.Remove(consumablePartial);
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
