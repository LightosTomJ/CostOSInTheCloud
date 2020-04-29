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
	public class AssemblyChildsService
	{
		private ProjectContext projectContext;

		public AssemblyChildsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> AssemblyChildCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.AssemblyChild.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.AssemblyChild>> GetAllAssemblyChilds()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.AssemblyChild> assemblyChilds = await projectContext.AssemblyChild.ToListAsync();
				return assemblyChilds;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateAssemblyChild(List<Models.DB.Project.AssemblyChild> AssemblyChilds)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.AssemblyChild assemblyChild in AssemblyChilds)
				{
					projectContext.AssemblyChild.Add(assemblyChild);
					await projectContext.SaveChangesAsync();
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

		public async Task<bool> UpdateAssemblyChild(Models.DB.Project.AssemblyChild assemblyChild)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.AssemblyChild.Update(assemblyChild);
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
		public async Task<bool> DeleteAssemblyChild(long assemblyChildId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.AssemblyChild assemblyChild = projectContext.AssemblyChild.First(p => p.Assemblychildid == assemblyChildId);
				projectContext.AssemblyChild.Remove(assemblyChild);
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
