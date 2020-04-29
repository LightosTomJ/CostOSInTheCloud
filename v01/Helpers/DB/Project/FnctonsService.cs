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
	public class FnctonsService
	{
		private ProjectContext projectContext;

		public FnctonsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> FnctonCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Fncton.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Fncton>> GetAllFnctons()
		{
			IList<Models.DB.Project.Fncton> Fnctons = new List<Models.DB.Project.Fncton>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Fncton> fnctons = await projectContext.Fncton.ToListAsync();
				return fnctons;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateFncton(List<Models.DB.Project.Fncton> Fnctons)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Fncton fncton in Fnctons)
				{
					projectContext.Fncton.Add(fncton);
					await projectContext.SaveChangesAsync();
					returnid = fncton.Functionid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateFncton(long id, Models.DB.Project.Fncton fncton)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Fncton.Update(fncton);
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
		public async Task<bool> DeleteFncton(long fnctonId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Fncton fncton = projectContext.Fncton.First(p => p.Functionid == fnctonId);
				projectContext.Fncton.Remove(fncton);
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
