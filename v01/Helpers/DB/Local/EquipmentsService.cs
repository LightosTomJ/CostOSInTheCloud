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
	public class EquipmentsService
	{
		private LocalContext localContext;

		public EquipmentsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> EquipmentCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Equipment.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Equipment>> GetAllEquipments()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Equipment> equipments = await localContext.Equipment.ToListAsync();
				return equipments;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateEquipment(List<Models.DB.Local.Equipment> Equipments)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Equipment equipment in Equipments)
				{
					localContext.Equipment.Add(equipment);
					await localContext.SaveChangesAsync();
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

		public async Task<bool> UpdateEquipment(Models.DB.Local.Equipment equipment)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Equipment.Update(equipment);
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
		public async Task<bool> DeleteEquipment(long equipmentId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Equipment equipment = localContext.Equipment.First(p => p.Equipmentid == equipmentId);
				localContext.Equipment.Remove(equipment);
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
