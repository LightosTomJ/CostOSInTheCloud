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
	public class AssembliesService
	{
		private LocalContext localContext;

		public AssembliesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> AssemblyCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Assembly.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Assembly>> GetAllAssemblies()
		{
			IList<Models.DB.Local.Assembly> Assemblies = new List<Models.DB.Local.Assembly>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Assembly> assemblies = await localContext.Assembly.ToListAsync();
				return assemblies;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateAssembly(List<Models.DB.Local.Assembly> Assemblies)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Assembly assembly in Assemblies)
				{
					localContext.Assembly.Add(assembly);
					await localContext.SaveChangesAsync();
					returnid = assembly.Assemblyid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAssembly(long id, Models.DB.Local.Assembly assembly)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Assembly.Update(assembly);
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
		public async Task<bool> DeleteAssembly(long assemblyId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Assembly assembly = localContext.Assembly.First(p => p.Assemblyid == assemblyId);
				localContext.Assembly.Remove(assembly);
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
