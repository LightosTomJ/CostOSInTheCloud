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
	public class AssemblySubcontractorsService
	{
		private LocalContext localContext;

		public AssemblySubcontractorsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> AssemblySubcontractorCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.AssemblySubcontractor.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.AssemblySubcontractor>> GetAllAssemblySubcontractors()
		{
			IList<Models.DB.Local.AssemblySubcontractor> AssemblySubcontractors = new List<Models.DB.Local.AssemblySubcontractor>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.AssemblySubcontractor> assemblySubcontractors = await localContext.AssemblySubcontractor.ToListAsync();
				return assemblySubcontractors;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateAssemblySubcontractor(List<Models.DB.Local.AssemblySubcontractor> AssemblySubcontractors)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AssemblySubcontractor assemblySubcontractor in AssemblySubcontractors)
				{
					localContext.AssemblySubcontractor.Add(assemblySubcontractor);
					await localContext.SaveChangesAsync();
					returnid = assemblySubcontractor.Assemblysubcontractorid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAssemblySubcontractor(long id, Models.DB.Local.AssemblySubcontractor assemblySubcontractor)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AssemblySubcontractor.Update(assemblySubcontractor);
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
		public async Task<bool> DeleteAssemblySubcontractor(long assemblySubcontractorId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AssemblySubcontractor assemblySubcontractor = localContext.AssemblySubcontractor.First(p => p.Assemblysubcontractorid == assemblySubcontractorId);
				localContext.AssemblySubcontractor.Remove(assemblySubcontractor);
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
