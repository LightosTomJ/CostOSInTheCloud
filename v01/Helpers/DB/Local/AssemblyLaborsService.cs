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
	public class AssemblyLaborsService
	{
		private LocalContext localContext;

		public AssemblyLaborsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> AssemblyLaborCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.AssemblyLabor.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.AssemblyLabor>> GetAllAssemblyLabors()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.AssemblyLabor> assemblyLabors = await localContext.AssemblyLabor.ToListAsync();
				return assemblyLabors;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateAssemblyLabor(List<Models.DB.Local.AssemblyLabor> AssemblyLabors)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AssemblyLabor assemblyLabor in AssemblyLabors)
				{
					localContext.AssemblyLabor.Add(assemblyLabor);
					await localContext.SaveChangesAsync();
					returnid = assemblyLabor.Assemblylaborid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAssemblyLabor(Models.DB.Local.AssemblyLabor assemblyLabor)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AssemblyLabor.Update(assemblyLabor);
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
		public async Task<bool> DeleteAssemblyLabor(long assemblyLaborId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AssemblyLabor assemblyLabor = localContext.AssemblyLabor.First(p => p.Assemblylaborid == assemblyLaborId);
				localContext.AssemblyLabor.Remove(assemblyLabor);
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
