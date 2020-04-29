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
	public class AssemblyEquipmentsService
	{
		private LocalContext localContext;

		public AssemblyEquipmentsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> AssemblyEquipmentCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.AssemblyEquipment.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.AssemblyEquipment>> GetAllAssemblyEquipments()
		{
			IList<Models.DB.Local.AssemblyEquipment> AssemblyEquipments = new List<Models.DB.Local.AssemblyEquipment>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.AssemblyEquipment> assemblyEquipments = await localContext.AssemblyEquipment.ToListAsync();
				return assemblyEquipments;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateAssemblyEquipment(List<Models.DB.Local.AssemblyEquipment> AssemblyEquipments)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AssemblyEquipment assemblyEquipment in AssemblyEquipments)
				{
					localContext.AssemblyEquipment.Add(assemblyEquipment);
					await localContext.SaveChangesAsync();
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

		public async Task<bool> UpdateAssemblyEquipment(long id, Models.DB.Local.AssemblyEquipment assemblyEquipment)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AssemblyEquipment.Update(assemblyEquipment);
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
		public async Task<bool> DeleteAssemblyEquipment(long assemblyEquipmentId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AssemblyEquipment assemblyEquipment = localContext.AssemblyEquipment.First(p => p.Assemblyequipmentid == assemblyEquipmentId);
				localContext.AssemblyEquipment.Remove(assemblyEquipment);
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
