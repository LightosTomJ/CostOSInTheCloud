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
	public class AssemblyConsumablesService
	{
		private ProjectContext projectContext;

		public AssemblyConsumablesService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> AssemblyConsumableCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.AssemblyConsumable.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.AssemblyConsumable>> GetAllAssemblyConsumables()
		{
			IList<Models.DB.Project.AssemblyConsumable> AssemblyConsumables = new List<Models.DB.Project.AssemblyConsumable>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.AssemblyConsumable> assemblyConsumables = await projectContext.AssemblyConsumable.ToListAsync();
				return assemblyConsumables;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateAssemblyConsumable(List<Models.DB.Project.AssemblyConsumable> AssemblyConsumables)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.AssemblyConsumable assemblyConsumable in AssemblyConsumables)
				{
					projectContext.AssemblyConsumable.Add(assemblyConsumable);
					await projectContext.SaveChangesAsync();
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

		public async Task<bool> UpdateAssemblyConsumable(long id, Models.DB.Project.AssemblyConsumable assemblyConsumable)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.AssemblyConsumable.Update(assemblyConsumable);
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
		public async Task<bool> DeleteAssemblyConsumable(long assemblyConsumableId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.AssemblyConsumable assemblyConsumable = projectContext.AssemblyConsumable.First(p => p.Assemblyconsumableid == assemblyConsumableId);
				projectContext.AssemblyConsumable.Remove(assemblyConsumable);
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
