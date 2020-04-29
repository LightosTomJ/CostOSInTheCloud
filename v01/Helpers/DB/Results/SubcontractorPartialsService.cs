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
	public class SubcontractorPartialsService
	{
		private ResultsContext resultsContext;

		public SubcontractorPartialsService(ResultsContext dbContext)
		{
			resultsContext = dbContext;
		}

		public async Task<long> SubcontractorPartialCount()
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				return await resultsContext.SubcontractorPartial.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Results.SubcontractorPartial>> GetAllSubcontractorPartials()
		{
			IList<Models.DB.Results.SubcontractorPartial> SubcontractorPartials = new List<Models.DB.Results.SubcontractorPartial>();
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				IList<Models.DB.Results.SubcontractorPartial> subcontractorPartials = await resultsContext.SubcontractorPartial.ToListAsync();
				return subcontractorPartials;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateSubcontractorPartial(List<Models.DB.Results.SubcontractorPartial> SubcontractorPartials)
		{
			long returnid = -1;
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				foreach (Models.DB.Results.SubcontractorPartial subcontractorPartial in SubcontractorPartials)
				{
					resultsContext.SubcontractorPartial.Add(subcontractorPartial);
					await resultsContext.SaveChangesAsync();
					returnid = subcontractorPartial.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateSubcontractorPartial(long id, Models.DB.Results.SubcontractorPartial subcontractorPartial)
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				resultsContext.SubcontractorPartial.Update(subcontractorPartial);
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
		public async Task<bool> DeleteSubcontractorPartial(long subcontractorPartialId)
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				Models.DB.Results.SubcontractorPartial subcontractorPartial = resultsContext.SubcontractorPartial.First(p => p.Id == subcontractorPartialId);
				resultsContext.SubcontractorPartial.Remove(subcontractorPartial);
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
