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
	public class ParamInputsService
	{
		private ProjectContext projectContext;

		public ParamInputsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> ParamInputCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.ParamInput.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.ParamInput>> GetAllParamInputs()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.ParamInput> paramInputs = await projectContext.ParamInput.ToListAsync();
				return paramInputs;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateParamInput(List<Models.DB.Project.ParamInput> ParamInputs)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.ParamInput paramInput in ParamInputs)
				{
					projectContext.ParamInput.Add(paramInput);
					await projectContext.SaveChangesAsync();
					returnid = paramInput.Paraminputid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateParamInput(Models.DB.Project.ParamInput paramInput)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.ParamInput.Update(paramInput);
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
		public async Task<bool> DeleteParamInput(long paramInputId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.ParamInput paramInput = projectContext.ParamInput.First(p => p.Paramitemid == paramInputId);
				projectContext.ParamInput.Remove(paramInput);
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
