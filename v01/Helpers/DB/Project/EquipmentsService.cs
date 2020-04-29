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
	public class EquipmentsService
	{
		private ProjectContext projectContext;

		public EquipmentsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> EquipmentCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Equipment.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Equipment>> GetAllEquipments()
		{
			IList<Models.DB.Project.Equipment> Equipments = new List<Models.DB.Project.Equipment>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Equipment> equipments = await projectContext.Equipment.ToListAsync();
				return equipments;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateEquipment(List<Models.DB.Project.Equipment> Equipments)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Equipment equipment in Equipments)
				{
					projectContext.Equipment.Add(equipment);
					await projectContext.SaveChangesAsync();
					returnid = equipment.Equipmentid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateEquipment(long id, Models.DB.Project.Equipment equipment)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Equipment.Update(equipment);
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
		public async Task<bool> DeleteEquipment(long equipmentId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Equipment equipment = projectContext.Equipment.First(p => p.Equipmentid == equipmentId);
				projectContext.Equipment.Remove(equipment);
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
