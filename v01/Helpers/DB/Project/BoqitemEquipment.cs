using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class BoqitemEquipment
	{
		private ProjectContext projectContext;

		public BoqitemEquipment(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long BoqitemEquipmentCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.BoqitemEquipment.Count();
		}

		public List<Models.DB.Project.BoqitemEquipment> GetAllBoqitemEquipment()
		{
			List<Models.DB.Project.BoqitemEquipment> BoqitemEquipment = new List<Models.DB.Project.BoqitemEquipment>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				BoqitemEquipment = projectContext.BoqitemEquipment.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BoqitemEquipment;
		}
		public long CreateboqitemEquipment(List<Models.DB.Project.BoqitemEquipment> BoqitemEquipment)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.BoqitemEquipment boqitemEquipment in BoqitemEquipment)
				{
					projectContext.BoqitemEquipment.Add(boqitemEquipment);
					projectContext.SaveChanges();
					returnid = boqitemEquipment.BoqitemEquipmentId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateboqitemEquipment(long id, Models.DB.Project.BoqitemEquipment boqitemEquipment)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.BoqitemEquipment.Update(boqitemEquipment);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteboqitemEquipment(long boqitemEquipmentId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.BoqitemEquipment boqitemEquipment = projectContext.BoqitemEquipment.First(p => p.BoqitemEquipmentId == boqitemEquipmentId);
				projectContext.BoqitemEquipment.Remove(boqitemEquipment);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
