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
	public class MaterialPartialsService
	{
		private ResultsContext resultsContext;

		public MaterialPartialsService(ResultsContext dbContext)
		{
			resultsContext = dbContext;
		}

		public async Task<long> MaterialPartialCount()
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				return await resultsContext.MaterialPartial.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Results.MaterialPartial>> GetAllMaterialPartials()
		{
			IList<Models.DB.Results.MaterialPartial> MaterialPartials = new List<Models.DB.Results.MaterialPartial>();
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				IList<Models.DB.Results.MaterialPartial> materialPartials = await resultsContext.MaterialPartial.ToListAsync();
				return materialPartials;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateMaterialPartial(List<Models.DB.Results.MaterialPartial> MaterialPartials)
		{
			long returnid = -1;
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				foreach (Models.DB.Results.MaterialPartial materialPartial in MaterialPartials)
				{
					resultsContext.MaterialPartial.Add(materialPartial);
					await resultsContext.SaveChangesAsync();
					returnid = materialPartial.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateMaterialPartial(long id, Models.DB.Results.MaterialPartial materialPartial)
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				resultsContext.MaterialPartial.Update(materialPartial);
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
		public async Task<bool> DeleteMaterialPartial(long materialPartialId)
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				Models.DB.Results.MaterialPartial materialPartial = resultsContext.MaterialPartial.First(p => p.Id == materialPartialId);
				resultsContext.MaterialPartial.Remove(materialPartial);
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
