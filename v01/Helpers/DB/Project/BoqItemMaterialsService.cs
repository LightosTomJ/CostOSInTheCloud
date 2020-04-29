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
	public class BoqItemMaterialsService
	{
		private ProjectContext projectContext;

		public BoqItemMaterialsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> BoqItemMaterialCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.BoqItemMaterial.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.BoqItemMaterial>> GetAllBoqItemMaterials()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.BoqItemMaterial> boqItemMaterials = await projectContext.BoqItemMaterial.ToListAsync();
				return boqItemMaterials;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBoqItemMaterial(List<Models.DB.Project.BoqItemMaterial> BoqItemMaterials)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.BoqItemMaterial boqItemMaterial in BoqItemMaterials)
				{
					projectContext.BoqItemMaterial.Add(boqItemMaterial);
					await projectContext.SaveChangesAsync();
					returnid = boqItemMaterial.Boqitemmaterialid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBoqItemMaterial(Models.DB.Project.BoqItemMaterial boqItemMaterial)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.BoqItemMaterial.Update(boqItemMaterial);
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
		public async Task<bool> DeleteBoqItemMaterial(long boqItemMaterialId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.BoqItemMaterial boqItemMaterial = projectContext.BoqItemMaterial.First(p => p.Boqitemmaterialid == boqItemMaterialId);
				projectContext.BoqItemMaterial.Remove(boqItemMaterial);
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
