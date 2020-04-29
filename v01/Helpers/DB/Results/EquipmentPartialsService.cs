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
	public class EquipmentPartialsService
	{
		private ResultsContext resultsContext;

		public EquipmentPartialsService(ResultsContext dbContext)
		{
			resultsContext = dbContext;
		}

		public async Task<long> EquipmentPartialCount()
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				return await resultsContext.EquipmentPartial.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Results.EquipmentPartial>> GetAllEquipmentPartials()
		{
			IList<Models.DB.Results.EquipmentPartial> EquipmentPartials = new List<Models.DB.Results.EquipmentPartial>();
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				IList<Models.DB.Results.EquipmentPartial> equipmentPartials = await resultsContext.EquipmentPartial.ToListAsync();
				return equipmentPartials;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateEquipmentPartial(List<Models.DB.Results.EquipmentPartial> EquipmentPartials)
		{
			long returnid = -1;
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				foreach (Models.DB.Results.EquipmentPartial equipmentPartial in EquipmentPartials)
				{
					resultsContext.EquipmentPartial.Add(equipmentPartial);
					await resultsContext.SaveChangesAsync();
					returnid = equipmentPartial.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateEquipmentPartial(long id, Models.DB.Results.EquipmentPartial equipmentPartial)
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				resultsContext.EquipmentPartial.Update(equipmentPartial);
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
		public async Task<bool> DeleteEquipmentPartial(long equipmentPartialId)
		{
			try
			{
				if (resultsContext == null) resultsContext = new ResultsContext();
				Models.DB.Results.EquipmentPartial equipmentPartial = resultsContext.EquipmentPartial.First(p => p.Id == equipmentPartialId);
				resultsContext.EquipmentPartial.Remove(equipmentPartial);
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
