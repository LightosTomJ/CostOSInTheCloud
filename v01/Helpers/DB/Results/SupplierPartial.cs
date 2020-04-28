using Models.DB.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Results
{
	public class SupplierPartial
	{
		private resultsContext resultsContext;

		public SupplierPartial(resultsContext dbContext)
		{
			resultsContext = dbContext;
		}

		public long SupplierPartialCount()
		{
			if (resultsContext == null) resultsContext = new resultsContext();
			return resultsContext.SupplierPartial.Count();
		}

		public List<Models.DB.Results.SupplierPartial> GetAllSupplierPartial()
		{
			List<Models.DB.Results.SupplierPartial> SupplierPartial = new List<Models.DB.Results.SupplierPartial>();
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				SupplierPartial = resultsContext.SupplierPartial.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return SupplierPartial;
		}
		public long CreatesupplierPartial(List<Models.DB.Results.SupplierPartial> SupplierPartial)
		{
			long returnid = 0;
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				foreach (Models.DB.Results.SupplierPartial supplierPartial in SupplierPartial)
				{
					resultsContext.SupplierPartial.Add(supplierPartial);
					resultsContext.SaveChanges();
					returnid = supplierPartial.SupplierPartialId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatesupplierPartial(long id, Models.DB.Results.SupplierPartial supplierPartial)
		{
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				resultsContext.SupplierPartial.Update(supplierPartial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletesupplierPartial(long supplierPartialId)
		{
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				Models.DB.Results.SupplierPartial supplierPartial = resultsContext.SupplierPartial.First(p => p.SupplierPartialId == supplierPartialId);
				resultsContext.SupplierPartial.Remove(supplierPartial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
