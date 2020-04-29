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
	public class LaborPartialsService
	{
		private ResultsContext resultsContext;

		public LaborPartialsService(ResultsContext dbContext)
		{
			resultsContext = dbContext;
		}

		public async Task<long> LaborPartialCount()
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				return await resultsContext.LaborPartial.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Results.LaborPartial>> GetAllLaborPartials()
		{
			IList<Models.DB.Results.LaborPartial> LaborPartials = new List<Models.DB.Results.LaborPartial>();
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				IList<Models.DB.Results.LaborPartial> laborPartials = await resultsContext.LaborPartial.ToListAsync();
				return laborPartials;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateLaborPartial(List<Models.DB.Results.LaborPartial> LaborPartials)
		{
			long returnid = -1;
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				foreach (Models.DB.Results.LaborPartial laborPartial in LaborPartials)
				{
					resultsContext.LaborPartial.Add(laborPartial);
					await resultsContext.SaveChangesAsync();
					returnid = laborPartial.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateLaborPartial(long id, Models.DB.Results.LaborPartial laborPartial)
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				resultsContext.LaborPartial.Update(laborPartial);
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
		public async Task<bool> DeleteLaborPartial(long laborPartialId)
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				Models.DB.Results.LaborPartial laborPartial = resultsContext.LaborPartial.First(p => p.Id == laborPartialId);
				resultsContext.LaborPartial.Remove(laborPartial);
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
