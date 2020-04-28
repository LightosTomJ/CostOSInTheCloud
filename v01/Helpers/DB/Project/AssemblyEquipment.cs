using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class AssemblyEquipment
	{
		private ProjectContext projectContext;

		public AssemblyEquipment(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long AssemblyEquipmentCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.AssemblyEquipment.Count();
		}

		public List<Models.DB.Project.AssemblyEquipment> GetAllAssemblyEquipment()
		{
			List<Models.DB.Project.AssemblyEquipment> AssemblyEquipment = new List<Models.DB.Project.AssemblyEquipment>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				AssemblyEquipment = projectContext.AssemblyEquipment.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AssemblyEquipment;
		}
		public long CreateassemblyEquipment(List<Models.DB.Project.AssemblyEquipment> AssemblyEquipment)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.AssemblyEquipment assemblyEquipment in AssemblyEquipment)
				{
					projectContext.AssemblyEquipment.Add(assemblyEquipment);
					projectContext.SaveChanges();
					returnid = assemblyEquipment.AssemblyEquipmentId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateassemblyEquipment(long id, Models.DB.Project.AssemblyEquipment assemblyEquipment)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.AssemblyEquipment.Update(assemblyEquipment);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteassemblyEquipment(long assemblyEquipmentId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.AssemblyEquipment assemblyEquipment = projectContext.AssemblyEquipment.First(p => p.AssemblyEquipmentId == assemblyEquipmentId);
				projectContext.AssemblyEquipment.Remove(assemblyEquipment);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
