using Models.DB.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Results
{
	public class EquipmentPartial
	{
		private resultsContext resultsContext;

		public EquipmentPartial(resultsContext dbContext)
		{
			resultsContext = dbContext;
		}

		public long EquipmentPartialCount()
		{
			if (resultsContext == null) resultsContext = new resultsContext();
			return resultsContext.EquipmentPartial.Count();
		}

		public List<Models.DB.Results.EquipmentPartial> GetAllEquipmentPartial()
		{
			List<Models.DB.Results.EquipmentPartial> EquipmentPartial = new List<Models.DB.Results.EquipmentPartial>();
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				EquipmentPartial = resultsContext.EquipmentPartial.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return EquipmentPartial;
		}
		public long CreateequipmentPartial(List<Models.DB.Results.EquipmentPartial> EquipmentPartial)
		{
			long returnid = 0;
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				foreach (Models.DB.Results.EquipmentPartial equipmentPartial in EquipmentPartial)
				{
					resultsContext.EquipmentPartial.Add(equipmentPartial);
					resultsContext.SaveChanges();
					returnid = equipmentPartial.EquipmentPartialId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateequipmentPartial(long id, Models.DB.Results.EquipmentPartial equipmentPartial)
		{
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				resultsContext.EquipmentPartial.Update(equipmentPartial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteequipmentPartial(long equipmentPartialId)
		{
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				Models.DB.Results.EquipmentPartial equipmentPartial = resultsContext.EquipmentPartial.First(p => p.EquipmentPartialId == equipmentPartialId);
				resultsContext.EquipmentPartial.Remove(equipmentPartial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
