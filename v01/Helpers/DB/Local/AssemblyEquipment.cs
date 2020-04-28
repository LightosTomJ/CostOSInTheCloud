using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class AssemblyEquipment
	{
		private LocalContext localContext;

		public AssemblyEquipment(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long AssemblyEquipmentCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.AssemblyEquipment.Count();
		}

		public List<Models.DB.Local.AssemblyEquipment> GetAllAssemblyEquipment()
		{
			List<Models.DB.Local.AssemblyEquipment> AssemblyEquipment = new List<Models.DB.Local.AssemblyEquipment>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				AssemblyEquipment = localContext.AssemblyEquipment.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AssemblyEquipment;
		}
		public long CreateassemblyEquipment(List<Models.DB.Local.AssemblyEquipment> AssemblyEquipment)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AssemblyEquipment assemblyEquipment in AssemblyEquipment)
				{
					localContext.AssemblyEquipment.Add(assemblyEquipment);
					localContext.SaveChanges();
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

		public void UpdateassemblyEquipment(long id, Models.DB.Local.AssemblyEquipment assemblyEquipment)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AssemblyEquipment.Update(assemblyEquipment);
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
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AssemblyEquipment assemblyEquipment = localContext.AssemblyEquipment.First(p => p.AssemblyEquipmentId == assemblyEquipmentId);
				localContext.AssemblyEquipment.Remove(assemblyEquipment);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
