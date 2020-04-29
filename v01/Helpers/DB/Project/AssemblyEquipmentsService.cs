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
	public class AssemblyEquipmentsService
	{
		private ProjectContext projectContext;

		public AssemblyEquipmentsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> AssemblyEquipmentCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.AssemblyEquipment.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.AssemblyEquipment>> GetAllAssemblyEquipments()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.AssemblyEquipment> assemblyEquipments = await projectContext.AssemblyEquipment.ToListAsync();
				return assemblyEquipments;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateAssemblyEquipment(List<Models.DB.Project.AssemblyEquipment> AssemblyEquipments)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.AssemblyEquipment assemblyEquipment in AssemblyEquipments)
				{
					projectContext.AssemblyEquipment.Add(assemblyEquipment);
					await projectContext.SaveChangesAsync();
					returnid = assemblyEquipment.Assemblyequipmentid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAssemblyEquipment(Models.DB.Project.AssemblyEquipment assemblyEquipment)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.AssemblyEquipment.Update(assemblyEquipment);
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
		public async Task<bool> DeleteAssemblyEquipment(long assemblyEquipmentId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.AssemblyEquipment assemblyEquipment = projectContext.AssemblyEquipment.First(p => p.Assemblyequipmentid == assemblyEquipmentId);
				projectContext.AssemblyEquipment.Remove(assemblyEquipment);
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
