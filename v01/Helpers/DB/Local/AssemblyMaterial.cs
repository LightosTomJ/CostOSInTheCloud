using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class AssemblyMaterial
	{
		private LocalContext localContext;

		public AssemblyMaterial(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long AssemblyMaterialCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.AssemblyMaterial.Count();
		}

		public List<Models.DB.Local.AssemblyMaterial> GetAllAssemblyMaterial()
		{
			List<Models.DB.Local.AssemblyMaterial> AssemblyMaterial = new List<Models.DB.Local.AssemblyMaterial>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				AssemblyMaterial = localContext.AssemblyMaterial.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AssemblyMaterial;
		}
		public long CreateassemblyMaterial(List<Models.DB.Local.AssemblyMaterial> AssemblyMaterial)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AssemblyMaterial assemblyMaterial in AssemblyMaterial)
				{
					localContext.AssemblyMaterial.Add(assemblyMaterial);
					localContext.SaveChanges();
					returnid = assemblyMaterial.AssemblyMaterialId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateassemblyMaterial(long id, Models.DB.Local.AssemblyMaterial assemblyMaterial)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AssemblyMaterial.Update(assemblyMaterial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteassemblyMaterial(long assemblyMaterialId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AssemblyMaterial assemblyMaterial = localContext.AssemblyMaterial.First(p => p.AssemblyMaterialId == assemblyMaterialId);
				localContext.AssemblyMaterial.Remove(assemblyMaterial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
