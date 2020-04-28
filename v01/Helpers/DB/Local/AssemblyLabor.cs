using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class AssemblyLabor
	{
		private LocalContext localContext;

		public AssemblyLabor(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long AssemblyLaborCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.AssemblyLabor.Count();
		}

		public List<Models.DB.Local.AssemblyLabor> GetAllAssemblyLabor()
		{
			List<Models.DB.Local.AssemblyLabor> AssemblyLabor = new List<Models.DB.Local.AssemblyLabor>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				AssemblyLabor = localContext.AssemblyLabor.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AssemblyLabor;
		}
		public long CreateassemblyLabor(List<Models.DB.Local.AssemblyLabor> AssemblyLabor)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AssemblyLabor assemblyLabor in AssemblyLabor)
				{
					localContext.AssemblyLabor.Add(assemblyLabor);
					localContext.SaveChanges();
					returnid = assemblyLabor.AssemblyLaborId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateassemblyLabor(long id, Models.DB.Local.AssemblyLabor assemblyLabor)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AssemblyLabor.Update(assemblyLabor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteassemblyLabor(long assemblyLaborId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AssemblyLabor assemblyLabor = localContext.AssemblyLabor.First(p => p.AssemblyLaborId == assemblyLaborId);
				localContext.AssemblyLabor.Remove(assemblyLabor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
