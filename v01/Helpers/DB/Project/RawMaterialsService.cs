using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class RawMaterialsService
	{
		private ProjectContext projectContext;

		public RawMaterialsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> RawMaterialCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.RawMaterial.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.RawMaterial>> GetAllRawMaterials()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.RawMaterial> rawMaterials = await projectContext.RawMaterial.ToListAsync();
				return rawMaterials;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateRawMaterial(List<Models.DB.Project.RawMaterial> RawMaterials)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.RawMaterial rawMaterial in RawMaterials)
				{
					projectContext.RawMaterial.Add(rawMaterial);
					await projectContext.SaveChangesAsync();
					returnid = rawMaterial.Rawmatid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateRawMaterial(Models.DB.Project.RawMaterial rawMaterial)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.RawMaterial.Update(rawMaterial);
				await projectContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
		public async Task<bool> DeleteRawMaterial(long rawMaterialId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.RawMaterial rawMaterial = projectContext.RawMaterial.First(p => p.Rawmatid == rawMaterialId);
				projectContext.RawMaterial.Remove(rawMaterial);
				await projectContext.SaveChangesAsync();
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
