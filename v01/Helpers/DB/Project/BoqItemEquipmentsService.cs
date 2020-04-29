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
	public class BoqItemEquipmentsService
	{
		private ProjectContext projectContext;

		public BoqItemEquipmentsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> BoqItemEquipmentCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.BoqItemEquipment.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.BoqItemEquipment>> GetAllBoqItemEquipments()
		{
			IList<Models.DB.Project.BoqItemEquipment> BoqItemEquipments = new List<Models.DB.Project.BoqItemEquipment>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.BoqItemEquipment> boqItemEquipments = await projectContext.BoqItemEquipment.ToListAsync();
				return boqItemEquipments;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBoqItemEquipment(List<Models.DB.Project.BoqItemEquipment> BoqItemEquipments)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.BoqItemEquipment boqItemEquipment in BoqItemEquipments)
				{
					projectContext.BoqItemEquipment.Add(boqItemEquipment);
					await projectContext.SaveChangesAsync();
					returnid = boqItemEquipment.Boqitemequipmentid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBoqItemEquipment(long id, Models.DB.Project.BoqItemEquipment boqItemEquipment)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.BoqItemEquipment.Update(boqItemEquipment);
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
		public async Task<bool> DeleteBoqItemEquipment(long boqItemEquipmentId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.BoqItemEquipment boqItemEquipment = projectContext.BoqItemEquipment.First(p => p.Boqitemequipmentid == boqItemEquipmentId);
				projectContext.BoqItemEquipment.Remove(boqItemEquipment);
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
