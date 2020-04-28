using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Equipment
	{
		private ProjectContext projectContext;

		public Equipment(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long EquipmentCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Equipment.Count();
		}

		public List<Models.DB.Project.Equipment> GetAllEquipment()
		{
			List<Models.DB.Project.Equipment> Equipment = new List<Models.DB.Project.Equipment>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Equipment = projectContext.Equipment.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Equipment;
		}
		public long Createequipment(List<Models.DB.Project.Equipment> Equipment)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Equipment equipment in Equipment)
				{
					projectContext.Equipment.Add(equipment);
					projectContext.SaveChanges();
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

		public void Updateequipment(long id, Models.DB.Project.Equipment equipment)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Equipment.Update(equipment);
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
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Equipment equipment = projectContext.Equipment.First(p => p.EquipmentId == equipmentId);
				projectContext.Equipment.Remove(equipment);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
