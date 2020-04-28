using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Equipment
	{
		private LocalContext localContext;

		public Equipment(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long EquipmentCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Equipment.Count();
		}

		public List<Models.DB.Local.Equipment> GetAllEquipment()
		{
			List<Models.DB.Local.Equipment> Equipment = new List<Models.DB.Local.Equipment>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Equipment = localContext.Equipment.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Equipment;
		}
		public long Createequipment(List<Models.DB.Local.Equipment> Equipment)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Equipment equipment in Equipment)
				{
					localContext.Equipment.Add(equipment);
					localContext.SaveChanges();
					returnid = equipment.EquipmentId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateequipment(long id, Models.DB.Local.Equipment equipment)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Equipment.Update(equipment);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteequipment(long equipmentId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Equipment equipment = localContext.Equipment.First(p => p.EquipmentId == equipmentId);
				localContext.Equipment.Remove(equipment);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
