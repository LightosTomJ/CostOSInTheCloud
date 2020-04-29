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
	public class ParamOutputsService
	{
		private ProjectContext projectContext;

		public ParamOutputsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> ParamOutputCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.ParamOutput.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.ParamOutput>> GetAllParamOutputs()
		{
			IList<Models.DB.Project.ParamOutput> ParamOutputs = new List<Models.DB.Project.ParamOutput>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.ParamOutput> paramOutputs = await projectContext.ParamOutput.ToListAsync();
				return paramOutputs;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateParamOutput(List<Models.DB.Project.ParamOutput> ParamOutputs)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.ParamOutput paramOutput in ParamOutputs)
				{
					projectContext.ParamOutput.Add(paramOutput);
					await projectContext.SaveChangesAsync();
					returnid = paramOutput.Paramoutputid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateParamOutput(long id, Models.DB.Project.ParamOutput paramOutput)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.ParamOutput.Update(paramOutput);
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
		public async Task<bool> DeleteParamOutput(long paramOutputId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.ParamOutput paramOutput = projectContext.ParamOutput.First(p => p.Paramoutputid == paramOutputId);
				projectContext.ParamOutput.Remove(paramOutput);
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
