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
	public class MaterialsService
	{
		private LocalContext localContext;

		public MaterialsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> MaterialCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Material.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Material>> GetAllMaterials()
		{
			IList<Models.DB.Local.Material> Materials = new List<Models.DB.Local.Material>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Material> materials = await localContext.Material.ToListAsync();
				return materials;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<IList<long>> CreateMaterial(IList<Models.DB.Local.Material> Materials)
		{
			IList<long> lReturns = new List<long>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Material material in Materials)
				{
					localContext.Material.Add(material);
					await localContext.SaveChangesAsync();
					if (material.MaterialId! > 0)
					{ lReturns.Add(material.MaterialId); }
					else
					{ lReturns.Add(-1); }
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return lReturns;
		}

		public async Task<bool> UpdateMaterial(long id, Models.DB.Local.Material material)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Material.Update(material);
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
		public async Task<bool> DeleteMaterial(long materialId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Material material = localContext.Material.First(p => p.MaterialId == materialId);
				localContext.Material.Remove(material);
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
