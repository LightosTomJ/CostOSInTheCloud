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
	public class BcElemMaterialsService
	{
		private LocalContext localContext;

		public BcElemMaterialsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcElemMaterialCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcElemMaterial.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcElemMaterial>> GetAllBcElemMaterials()
		{
			IList<Models.DB.Local.BcElemMaterial> BcElemMaterials = new List<Models.DB.Local.BcElemMaterial>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcElemMaterial> bcElemMaterials = await localContext.BcElemMaterial.ToListAsync();
				return bcElemMaterials;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcElemMaterial(List<Models.DB.Local.BcElemMaterial> BcElemMaterials)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcElemMaterial bcElemMaterial in BcElemMaterials)
				{
					localContext.BcElemMaterial.Add(bcElemMaterial);
					await localContext.SaveChangesAsync();
					returnid = bcElemMaterial.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcElemMaterial(long id, Models.DB.Local.BcElemMaterial bcElemMaterial)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcElemMaterial.Update(bcElemMaterial);
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
		public async Task<bool> DeleteBcElemMaterial(long bcElemMaterialId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcElemMaterial bcElemMaterial = localContext.BcElemMaterial.First(p => p.Id == bcElemMaterialId);
				localContext.BcElemMaterial.Remove(bcElemMaterial);
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
