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
	public class AssemblyChildsService
	{
		private LocalContext localContext;

		public AssemblyChildsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> AssemblyChildCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.AssemblyChild.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.AssemblyChild>> GetAllAssemblyChilds()
		{
			IList<Models.DB.Local.AssemblyChild> AssemblyChilds = new List<Models.DB.Local.AssemblyChild>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.AssemblyChild> assemblyChilds = await localContext.AssemblyChild.ToListAsync();
				return assemblyChilds;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateAssemblyChild(List<Models.DB.Local.AssemblyChild> AssemblyChilds)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AssemblyChild assemblyChild in AssemblyChilds)
				{
					localContext.AssemblyChild.Add(assemblyChild);
					await localContext.SaveChangesAsync();
					returnid = assemblyChild.Assemblychildid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAssemblyChild(long id, Models.DB.Local.AssemblyChild assemblyChild)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AssemblyChild.Update(assemblyChild);
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
		public async Task<bool> DeleteAssemblyChild(long assemblyChildId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AssemblyChild assemblyChild = localContext.AssemblyChild.First(p => p.Assemblychildid == assemblyChildId);
				localContext.AssemblyChild.Remove(assemblyChild);
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
