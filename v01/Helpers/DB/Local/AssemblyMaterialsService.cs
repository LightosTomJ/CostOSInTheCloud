using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class AssemblyMaterialsService
	{
		private LocalContext localContext;

		public AssemblyMaterialsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> AssemblyMaterialCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.AssemblyMaterial.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.AssemblyMaterial>> GetAllAssemblyMaterials()
		{
			IList<Models.DB.Local.AssemblyMaterial> AssemblyMaterials = new List<Models.DB.Local.AssemblyMaterial>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.AssemblyMaterial> assemblyMaterials = await localContext.AssemblyMaterial.ToListAsync();
				return assemblyMaterials;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateAssemblyMaterial(List<Models.DB.Local.AssemblyMaterial> AssemblyMaterials)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AssemblyMaterial assemblyMaterial in AssemblyMaterials)
				{
					localContext.AssemblyMaterial.Add(assemblyMaterial);
					await localContext.SaveChangesAsync();
					returnid = assemblyMaterial.Assemblymaterialid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAssemblyMaterial(long id, Models.DB.Local.AssemblyMaterial assemblyMaterial)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AssemblyMaterial.Update(assemblyMaterial);
				await localContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
		public async Task<bool> DeleteAssemblyMaterial(long assemblyMaterialId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AssemblyMaterial assemblyMaterial = localContext.AssemblyMaterial.First(p => p.Assemblymaterialid == assemblyMaterialId);
				localContext.AssemblyMaterial.Remove(assemblyMaterial);
				await localContext.SaveChangesAsync();
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
