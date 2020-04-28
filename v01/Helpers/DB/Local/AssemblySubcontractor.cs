using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class AssemblySubcontractor
	{
		private LocalContext localContext;

		public AssemblySubcontractor(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long AssemblySubcontractorCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.AssemblySubcontractor.Count();
		}

		public List<Models.DB.Local.AssemblySubcontractor> GetAllAssemblySubcontractor()
		{
			List<Models.DB.Local.AssemblySubcontractor> AssemblySubcontractor = new List<Models.DB.Local.AssemblySubcontractor>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				AssemblySubcontractor = localContext.AssemblySubcontractor.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AssemblySubcontractor;
		}
		public long CreateassemblySubcontractor(List<Models.DB.Local.AssemblySubcontractor> AssemblySubcontractor)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AssemblySubcontractor assemblySubcontractor in AssemblySubcontractor)
				{
					localContext.AssemblySubcontractor.Add(assemblySubcontractor);
					localContext.SaveChanges();
					returnid = assemblySubcontractor.AssemblySubcontractorId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateassemblySubcontractor(long id, Models.DB.Local.AssemblySubcontractor assemblySubcontractor)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AssemblySubcontractor.Update(assemblySubcontractor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteassemblySubcontractor(long assemblySubcontractorId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AssemblySubcontractor assemblySubcontractor = localContext.AssemblySubcontractor.First(p => p.AssemblySubcontractorId == assemblySubcontractorId);
				localContext.AssemblySubcontractor.Remove(assemblySubcontractor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
