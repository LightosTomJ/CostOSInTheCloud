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
	public class AssemblyConsumablesService
	{
		private LocalContext localContext;

		public AssemblyConsumablesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> AssemblyConsumableCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.AssemblyConsumable.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.AssemblyConsumable>> GetAllAssemblyConsumables()
		{
			IList<Models.DB.Local.AssemblyConsumable> AssemblyConsumables = new List<Models.DB.Local.AssemblyConsumable>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.AssemblyConsumable> assemblyConsumables = await localContext.AssemblyConsumable.ToListAsync();
				return assemblyConsumables;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateAssemblyConsumable(List<Models.DB.Local.AssemblyConsumable> AssemblyConsumables)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AssemblyConsumable assemblyConsumable in AssemblyConsumables)
				{
					localContext.AssemblyConsumable.Add(assemblyConsumable);
					await localContext.SaveChangesAsync();
					returnid = assemblyConsumable.Assemblyconsumableid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAssemblyConsumable(long id, Models.DB.Local.AssemblyConsumable assemblyConsumable)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AssemblyConsumable.Update(assemblyConsumable);
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
		public async Task<bool> DeleteAssemblyConsumable(long assemblyConsumableId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AssemblyConsumable assemblyConsumable = localContext.AssemblyConsumable.First(p => p.Assemblyconsumableid == assemblyConsumableId);
				localContext.AssemblyConsumable.Remove(assemblyConsumable);
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
