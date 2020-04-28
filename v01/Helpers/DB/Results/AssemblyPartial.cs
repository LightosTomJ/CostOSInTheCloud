using Models.DB.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Results
{
	public class AssemblyPartial
	{
		private resultsContext resultsContext;

		public AssemblyPartial(resultsContext dbContext)
		{
			resultsContext = dbContext;
		}

		public long AssemblyPartialCount()
		{
			if (resultsContext == null) resultsContext = new resultsContext();
			return resultsContext.AssemblyPartial.Count();
		}

		public List<Models.DB.Results.AssemblyPartial> GetAllAssemblyPartial()
		{
			List<Models.DB.Results.AssemblyPartial> AssemblyPartial = new List<Models.DB.Results.AssemblyPartial>();
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				AssemblyPartial = resultsContext.AssemblyPartial.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AssemblyPartial;
		}
		public long CreateassemblyPartial(List<Models.DB.Results.AssemblyPartial> AssemblyPartial)
		{
			long returnid = 0;
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				foreach (Models.DB.Results.AssemblyPartial assemblyPartial in AssemblyPartial)
				{
					resultsContext.AssemblyPartial.Add(assemblyPartial);
					resultsContext.SaveChanges();
					returnid = assemblyPartial.AssemblyPartialId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateassemblyPartial(long id, Models.DB.Results.AssemblyPartial assemblyPartial)
		{
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				resultsContext.AssemblyPartial.Update(assemblyPartial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteassemblyPartial(long assemblyPartialId)
		{
			try
			{
				if (resultsContext == null) resultsContext = new resultsContext();
				Models.DB.Results.AssemblyPartial assemblyPartial = resultsContext.AssemblyPartial.First(p => p.AssemblyPartialId == assemblyPartialId);
				resultsContext.AssemblyPartial.Remove(assemblyPartial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
