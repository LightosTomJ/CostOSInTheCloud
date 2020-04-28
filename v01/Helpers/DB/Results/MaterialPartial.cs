using Models.DB.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Results
{
	public class MaterialPartial
	{
		private resultsContext resultsContext;

		public MaterialPartial(resultsContext dbContext)
		{
			resultsContext = dbContext;
		}

		public long MaterialPartialCount()
		{
			if (resultsContext == null) resultsContext = new resultsContext();
			return resultsContext.MaterialPartial.Count();
		}

		public List<Models.DB.Results.MaterialPartial> GetAllMaterialPartial()
		{
			List<Models.DB.Results.MaterialPartial> MaterialPartial = new List<Models.DB.Results.MaterialPartial>();
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				MaterialPartial = resultsContext.MaterialPartial.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return MaterialPartial;
		}
		public long CreatematerialPartial(List<Models.DB.Results.MaterialPartial> MaterialPartial)
		{
			long returnid = 0;
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				foreach (Models.DB.Results.MaterialPartial materialPartial in MaterialPartial)
				{
					resultsContext.MaterialPartial.Add(materialPartial);
					resultsContext.SaveChanges();
					returnid = materialPartial.MaterialPartialId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatematerialPartial(long id, Models.DB.Results.MaterialPartial materialPartial)
		{
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				resultsContext.MaterialPartial.Update(materialPartial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletematerialPartial(long materialPartialId)
		{
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				Models.DB.Results.MaterialPartial materialPartial = resultsContext.MaterialPartial.First(p => p.MaterialPartialId == materialPartialId);
				resultsContext.MaterialPartial.Remove(materialPartial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
