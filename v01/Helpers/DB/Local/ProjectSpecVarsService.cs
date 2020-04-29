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
	public class ProjectSpecVarsService
	{
		private LocalContext localContext;

		public ProjectSpecVarsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> ProjectSpecVarCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.ProjectSpecVar.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.ProjectSpecVar>> GetAllProjectSpecVars()
		{
			IList<Models.DB.Local.ProjectSpecVar> ProjectSpecVars = new List<Models.DB.Local.ProjectSpecVar>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.ProjectSpecVar> projectSpecVars = await localContext.ProjectSpecVar.ToListAsync();
				return projectSpecVars;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateProjectSpecVar(List<Models.DB.Local.ProjectSpecVar> ProjectSpecVars)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.ProjectSpecVar projectSpecVar in ProjectSpecVars)
				{
					localContext.ProjectSpecVar.Add(projectSpecVar);
					await localContext.SaveChangesAsync();
					returnid = projectSpecVar.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateProjectSpecVar(long id, Models.DB.Local.ProjectSpecVar projectSpecVar)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.ProjectSpecVar.Update(projectSpecVar);
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
		public async Task<bool> DeleteProjectSpecVar(long projectSpecVarId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.ProjectSpecVar projectSpecVar = localContext.ProjectSpecVar.First(p => p.Id == projectSpecVarId);
				localContext.ProjectSpecVar.Remove(projectSpecVar);
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
