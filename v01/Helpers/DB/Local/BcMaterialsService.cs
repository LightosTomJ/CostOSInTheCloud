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
	public class BcMaterialsService
	{
		private LocalContext localContext;

		public BcMaterialsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcMaterialCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcMaterial.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcMaterial>> GetAllBcMaterials()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcMaterial> bcMaterials = await localContext.BcMaterial.ToListAsync();
				return bcMaterials;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcMaterial(List<Models.DB.Local.BcMaterial> BcMaterials)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcMaterial bcMaterial in BcMaterials)
				{
					localContext.BcMaterial.Add(bcMaterial);
					await localContext.SaveChangesAsync();
					returnid = bcMaterial.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcMaterial(Models.DB.Local.BcMaterial bcMaterial)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcMaterial.Update(bcMaterial);
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
		public async Task<bool> DeleteBcMaterial(long bcMaterialId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcMaterial bcMaterial = localContext.BcMaterial.First(p => p.Id == bcMaterialId);
				localContext.BcMaterial.Remove(bcMaterial);
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
