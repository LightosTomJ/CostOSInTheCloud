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
	public class ParamreturnsService
	{
		private ProjectContext projectContext;

		public ParamreturnsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> ParamreturnCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Paramreturn.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Paramreturn>> GetAllParamreturns()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Paramreturn> paramreturns = await projectContext.Paramreturn.ToListAsync();
				return paramreturns;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateParamreturn(List<Models.DB.Project.Paramreturn> Paramreturns)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Paramreturn paramreturn in Paramreturns)
				{
					projectContext.Paramreturn.Add(paramreturn);
					await projectContext.SaveChangesAsync();
					returnid = paramreturn.Paramreturnid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateParamreturn(Models.DB.Project.Paramreturn paramreturn)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Paramreturn.Update(paramreturn);
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
		public async Task<bool> DeleteParamreturn(long paramreturnId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Paramreturn paramreturn = projectContext.Paramreturn.First(p => p.Paramreturnid == paramreturnId);
				projectContext.Paramreturn.Remove(paramreturn);
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
