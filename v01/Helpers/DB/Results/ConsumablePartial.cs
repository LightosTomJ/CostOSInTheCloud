using Models.DB.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Results
{
	public class ConsumablePartial
	{
		private resultsContext resultsContext;

		public ConsumablePartial(resultsContext dbContext)
		{
			resultsContext = dbContext;
		}

		public long ConsumablePartialCount()
		{
			if (resultsContext == null) resultsContext = new resultsContext();
			return resultsContext.ConsumablePartial.Count();
		}

		public List<Models.DB.Results.ConsumablePartial> GetAllConsumablePartial()
		{
			List<Models.DB.Results.ConsumablePartial> ConsumablePartial = new List<Models.DB.Results.ConsumablePartial>();
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				ConsumablePartial = resultsContext.ConsumablePartial.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return ConsumablePartial;
		}
		public long CreateconsumablePartial(List<Models.DB.Results.ConsumablePartial> ConsumablePartial)
		{
			long returnid = 0;
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				foreach (Models.DB.Results.ConsumablePartial consumablePartial in ConsumablePartial)
				{
					resultsContext.ConsumablePartial.Add(consumablePartial);
					resultsContext.SaveChanges();
					returnid = consumablePartial.ConsumablePartialId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateconsumablePartial(long id, Models.DB.Results.ConsumablePartial consumablePartial)
		{
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				resultsContext.ConsumablePartial.Update(consumablePartial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteconsumablePartial(long consumablePartialId)
		{
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				Models.DB.Results.ConsumablePartial consumablePartial = resultsContext.ConsumablePartial.First(p => p.ConsumablePartialId == consumablePartialId);
				resultsContext.ConsumablePartial.Remove(consumablePartial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
